const uri = 'api/Colors';
let colors = [];

function getColors() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayColors(data))
        .catch(error => console.error('Unable to get Colors.', error));
}

function addColor() {
    const addNameTextbox = document.getElementById('add-name');

    const color = {
        name: addNameTextbox.value.trim(),
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(color)
    })
        .then(response => response.json())
        .then(() => {
            getColors();
            addNameTextbox.value = '';
        })
        .catch(error => console.error('Unable to add color.', error));
}

function deleteColor(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getColors())
        .catch(error => console.error('Unable to delete color.', error));
}

function displayEditForm(id) {
    const color = colors.find(color => color.id === id);

    document.getElementById('edit-id').value = color.id;
    document.getElementById('edit-name').value = color.name;
    document.getElementById('editForm').style.display = 'block';
}

function updateColor() {
    const colorId = document.getElementById('edit-id').value;
    const color = {
        id: parseInt(colorId, 10),
        name: document.getElementById('edit-name').value.trim(),
    };

    fetch(`${uri}/${colorId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(color)
    })
        .then(() => getColors())
        .catch(error => console.error('Unable to update color.', error));

    closeInput();

    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}


function _displayColors(data) {
    const tBody = document.getElementById('colors');
    tBody.innerHTML = '';


    const button = document.createElement('button');

    data.forEach(color => {
        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${color.id})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteColor(${color.id})`);

        let tr = tBody.insertRow();


        let td1 = tr.insertCell(0);
        let textNode = document.createTextNode(color.name);
        td1.appendChild(textNode);

        let td2 = tr.insertCell(1);
        td2.appendChild(editButton);

        let td3 = tr.insertCell(2);
        td3.appendChild(deleteButton);
    });

    colors = data;
}

