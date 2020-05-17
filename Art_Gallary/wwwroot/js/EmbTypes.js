const uri = 'api/EmbTypes';
let types = [];

function getTypes() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayTypes(data))
        .catch(error => console.error('Unable to get Types.', error));
}

function addType() {
    const addNameTextbox = document.getElementById('add-name');

    const type = {
        name: addNameTextbox.value.trim(),
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(type)
    })
        .then(response => response.json())
        .then(() => {
            getTypes();
            addNameTextbox.value = '';
        })
        .catch(error => console.error('Unable to add type.', error));
}

function deleteType(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getTypes())
        .catch(error => console.error('Unable to delete type.', error));
}

function displayEditForm(id) {
    const type = types.find(type => type.id === id);

    document.getElementById('edit-id').value = type.id;
    document.getElementById('edit-name').value = type.name;
    document.getElementById('editForm').style.display = 'block';
}

function updateType() {
    const typeId = document.getElementById('edit-id').value;
    const type = {
        id: parseInt(typeId, 10),
        name: document.getElementById('edit-name').value.trim(),
    };

    fetch(`${uri}/${typeId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(type)
    })
        .then(() => getTypes())
        .catch(error => console.error('Unable to update type.', error));

    closeInput();

    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}


function _displayTypes(data) {
    const tBody = document.getElementById('types');
    tBody.innerHTML = '';


    const button = document.createElement('button');

    data.forEach(type => {
        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${type.id})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteType(${type.id})`);

        let tr = tBody.insertRow();


        let td1 = tr.insertCell(0);
        let textNode = document.createTextNode(type.name);
        td1.appendChild(textNode);

        let td2 = tr.insertCell(1);
        td2.appendChild(editButton);

        let td3 = tr.insertCell(2);
        td3.appendChild(deleteButton);
    });

    types = data;
}

