const uri = 'api/Beads';
let beads = [];

function getBeads() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayBeads(data))
        .catch(error => console.error('Unable to get Beads.', error));
}

function addBead() {
    const addColorTextbox = document.getElementById('add-color');
    const addNumTextbox = document.getElementById('add-num');
    const addTypeTextbox =document.getElementById('add-type');
    const addImageTextbox = document.getElementById('add-image');

    const bead = {
        ColorId: parseInt(addColorTextbox.value.trim()),
        Num: addNumTextbox.value.trim(),
        BeadsTypeId: parseInt(addTypeTextbox.value.trim()),
        Image: addImageTextbox.value.trim(),
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(bead)
    })
        .then(response => response.json())
        .then(() => {
            getBeads();
            addColorTextbox.value = '';
            addNumTextbox = '';
            addTypeTextbox = '';
            addImageTextbox = '';
        })
        .catch(error => console.error('Unable to add bead.', error));
}

function deleteBead(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getBeads())
        .catch(error => console.error('Unable to delete bead.', error));
}

function displayEditForm(id) {
    const bead = beads.find(bead => bead.id === id);

    document.getElementById('edit-id').value = bead.id;
    document.getElementById('edit-color').value = bead.colorId;
    document.getElementById('edit-num').value = bead.num;
    document.getElementById('edit-type').value = bead.beadsTypeId;
    document.getElementById('edit-image').value = bead.image;
    document.getElementById('editForm').style.display = 'block';
}

function updateBead() {
    const beadId = document.getElementById('edit-id').value;
    const bead = {
        id: parseInt(beadId, 10),
        ColorId: parseInt(document.getElementById('edit-color').value.trim()),
        Num: document.getElementById('edit-num').value.trim(),
        BeadsTypeId: parseInt(document.getElementById('edit-type').value.trim()),
        Image: document.getElementById('edit-image').value.trim(),
    };

    fetch(`${uri}/${beadId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(bead)
    })
        .then(() => getBeads())
        .catch(error => console.error('Unable to update bead.', error));

    closeInput();

    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}


function _displayBeads(data) {
    const tBody = document.getElementById('beads');
    tBody.innerHTML = '';


    const button = document.createElement('button');

    data.forEach(bead => {
        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${bead.id})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteBead(${bead.id})`);

        let tr = tBody.insertRow();


        let td1 = tr.insertCell(0);
        let textNode = document.createTextNode(bead.colorId);
        td1.appendChild(textNode);

        let td2 = tr.insertCell(1);
        let textNode2 = document.createTextNode(bead.num);
        td2.appendChild(textNode2);

        let td3 = tr.insertCell(2);
        let textNode3 = document.createTextNode(bead.beadsTypeId);
        td3.appendChild(textNode3);

        let td4 = tr.insertCell(3);
        let image = document.createElement("img");
        image.src = bead.image;
        td4.appendChild(image);

        let td5 = tr.insertCell(4);
        td5.appendChild(editButton);

        let td6 = tr.insertCell(5);
        td6.appendChild(deleteButton);

        let textNode5 = document.createElement
    });


    
    beads = data;
}

