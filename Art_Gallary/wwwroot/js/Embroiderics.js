const uri = 'api/Embroiderics';
let embs = [];

function getEmbs() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayEmbs(data))
        .catch(error => console.error('Unable to get Embs.', error));
}

function addEmb() {
    const addSizeTextbox = document.getElementById('add-size');
    const addFirmTextbox = document.getElementById('add-firm');
    const addTypeTextbox = document.getElementById('add-type');
    const addNameTextbox = document.getElementById('add-name');
    const addNumTextbox = document.getElementById('add-num');
    const addImageTextbox = document.getElementById('add-image');
    const addPriceTextbox = document.getElementById('add-price');

    const emb = {
        sizeid: parseInt(addSizeTextbox.value.trim()),
        firmid: parseInt(addFirmTextbox.value.trim()),
        embtypeid: parseInt(addTypeTextbox.value.trim()),
        name: addNameTextbox.value.trim(),
        num: addNumTextbox.value.trim(),
        image: addImageTextbox.value.trim(),
        price: parseInt(addPriceTextbox.value.trim()),
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(emb)
    })
        .then(response => response.json())
        .then(() => {
            getEmbs();
            addSizeTextbox.value = '';
            addFirmTextbox = '';
            addTypeTextbox = '';
            addNameTextbox = '';
            addNumTextbox = '';
            addImageTextbox = '';
            addPriceTextbox = '';
        })
        .catch(error => console.error('Unable to add emb.', error));
}

function deleteEmb(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getEmbs())
        .catch(error => console.error('Unable to delete emb.', error));
}

function displayEditForm(id) {
    const emb = embs.find(emb => emb.id === id);

    document.getElementById('edit-id').value = emb.id;
    document.getElementById('edit-size').value = emb.sizeId;
    document.getElementById('edit-firm').value = emb.firmId;
    document.getElementById('edit-type').value = emb.embTypeId;
    document.getElementById('edit-name').value = emb.name;
    document.getElementById('edit-num').value = emb.num;
    document.getElementById('edit-image').value = emb.image;
    document.getElementById('edit-price').value = emb.price;
    document.getElementById('editForm').style.display = 'block';
}

function updateEmb() {
    const embId = document.getElementById('edit-id').value;
    const emb = {
        id: parseInt(embId, 10),
        sizeid: parseInt(document.getElementById('edit-size').value.trim()),
        firmid: parseInt(document.getElementById('edit-firm').value.trim()),
        embtypeid: parseInt(document.getElementById('edit-type').value.trim()),
        name: document.getElementById('edit-name').value.trim(),
        num: document.getElementById('edit-num').value.trim(),
        image: document.getElementById('edit-image').value.trim(),
        price: parseInt(document.getElementById('edit-price').value.trim()),
    };

    fetch(`${uri}/${embId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(emb)
    })
        .then(() => getEmbs())
        .catch(error => console.error('Unable to update emb.', error));

    closeInput();

    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}


function _displayEmbs(data) {
    const tBody = document.getElementById('embs');
    tBody.innerHTML = '';


    const button = document.createElement('button');

    data.forEach(emb => {
        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${emb.id})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteEmb(${emb.id})`);

        let tr = tBody.insertRow();


        let td1 = tr.insertCell(0);
        let textNode = document.createTextNode(emb.sizeId);
        td1.appendChild(textNode);

        let td2 = tr.insertCell(1);
        let textNode2 = document.createTextNode(emb.firmId);
        td2.appendChild(textNode2);

        let td3 = tr.insertCell(2);
        let textNode3 = document.createTextNode(emb.embTypeId);
        td3.appendChild(textNode3);

        let td4 = tr.insertCell(3);
        let textNode4 = document.createTextNode(emb.name);
        td4.appendChild(textNode4);

        let td5 = tr.insertCell(4);
        let textNode5 = document.createTextNode(emb.num);
        td5.appendChild(textNode5);

        let td6 = tr.insertCell(5);
        let image = document.createElement("img");
        image.src = emb.image;
        td6.appendChild(image);

        let td7 = tr.insertCell(6);
        let textNode7 = document.createTextNode(emb.price);
        td7.appendChild(textNode7);

        let td8 = tr.insertCell(7);
        td8.appendChild(editButton);

        let td9 = tr.insertCell(8);
        td9.appendChild(deleteButton);
    });

    embs = data;
}

