﻿const uri = 'api/Firms';
let firms = [];

function getFirms() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayFirms(data))
        .catch(error => console.error('Unable to get firms.', error));
}

function addFirm() {
    const addNameTextbox = document.getElementById('add-name');

    const firm = {
        name: addNameTextbox.value.trim(),
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(firm)
    })
        .then(response => response.json())
        .then(() => {
            getFirms();
            addNameTextbox.value = '';
        })
        .catch(error => console.error('Unable to add firm.', error));
}

function deleteFirm(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getFirms())
        .catch(error => console.error('Unable to delete firm.', error));
}

function displayEditForm(id) {
    const firm = firms.find(firm => firm.id === id);

    document.getElementById('edit-id').value = firm.id;
    document.getElementById('edit-name').value = firm.name;
    document.getElementById('editForm').style.display = 'block';
}

function updateFirm() {
    const firmId = document.getElementById('edit-id').value;
    const firm = {
        id: parseInt(firmId, 10),
        name: document.getElementById('edit-name').value.trim(),
    };

    fetch(`${uri}/${firmId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(firm)
    })
        .then(() => getFirms())
        .catch(error => console.error('Unable to update firm.', error));

    closeInput();

    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}


function _displayFirms(data) {
    const tBody = document.getElementById('firms');
    tBody.innerHTML = '';


    const button = document.createElement('button');

    data.forEach(firm => {
        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${firm.id})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteFirm(${firm.id})`);

        let tr = tBody.insertRow();


        let td1 = tr.insertCell(0);
        let textNode = document.createTextNode(firm.name);
        td1.appendChild(textNode);

        let td2 = tr.insertCell(1);
        td2.appendChild(editButton);

        let td3 = tr.insertCell(2);
        td3.appendChild(deleteButton);
    });

    firms = data;
}

