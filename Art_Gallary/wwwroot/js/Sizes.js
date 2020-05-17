const uri = 'api/Sizes';
let types = [];

function getSizes() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displaySizes(data))
        .catch(error => console.error('Unable to get Sizes.', error));
}

function addSize() {
    const addNameTextbox = document.getElementById('add-name');
    const addWidthTextbox = document.getElementById('add-width');
    const addLengthTextbox = document.getElementById('add-length');

    const size = {
        name: addNameTextbox.value.trim(),
        width: parseInt(addWidthTextbox.value.trim()),
        length: parseInt(addLengthTextbox.value.trim()),
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(size)
    })
        .then(response => response.json())
        .then(() => {
            getSizes();
            addNameTextbox.value = '';
            addWidthTextbox = '';
            addLengthTextbox = '';
        })
        .catch(error => console.error('Unable to add size.', error));
}

function deleteSize(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getSizes())
        .catch(error => console.error('Unable to delete size.', error));
}

function displayEditForm(id) {
    const size = sizes.find(size => size.id === id);

    document.getElementById('edit-id').value = size.id;
    document.getElementById('edit-name').value = size.name;
    document.getElementById('edit-width').value = size.width;
    document.getElementById('edit-length').value = size.length;
    document.getElementById('editForm').style.display = 'block';
}

function updateSize() {
    const sizeId = document.getElementById('edit-id').value;
    const size = {
        id: parseInt(sizeId, 10),
        name: document.getElementById('edit-name').value.trim(),
        width: parseInt(document.getElementById('edit-width').value.trim()),
        length: parseInt(document.getElementById('edit-length').value.trim()),
    };

    fetch(`${uri}/${sizeId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(size)
    })
        .then(() => getSizes())
        .catch(error => console.error('Unable to update size.', error));

    closeInput();

    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}


function _displaySizes(data) {
    const tBody = document.getElementById('sizes');
    tBody.innerHTML = '';


    const button = document.createElement('button');

    data.forEach(size => {
        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${size.id})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteSize(${size.id})`);

        let tr = tBody.insertRow();


        let td1 = tr.insertCell(0);
        let textNode = document.createTextNode(size.name);
        td1.appendChild(textNode);
        
        let td2 = tr.insertCell(1);
        let textNode2 = document.createTextNode(size.width);
        td2.appendChild(textNode2);

        let td3 = tr.insertCell(2);
        let textNode3 = document.createTextNode(size.length);
        td3.appendChild(textNode3);

        let td4 = tr.insertCell(3);
        td4.appendChild(editButton);

        let td5 = tr.insertCell(4);
        td5.appendChild(deleteButton);
    });

    sizes = data;
}

