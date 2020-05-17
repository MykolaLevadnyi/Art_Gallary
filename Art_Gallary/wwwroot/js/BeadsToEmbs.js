const uri = 'api/BeadsToEmbs';
let btes = [];

function getBtes() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayBtes(data))
        .catch(error => console.error('Unable to get btes.', error));
}

function addBte() {
    const addBeadTextbox = document.getElementById('add-bead');
    const addEmbTextbox = document.getElementById('add-emb'); 

    const bte = {
        beadid: parseInt(addBeadTextbox.value.trim()),
        embroidericId: parseInt(addEmbTextbox.value.trim()),
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(bte)
    })
        .then(response => response.json())
        .then(() => {
            getBtes();
            addBeadTextbox.value = '';
            addEmbTextbox.value = '';
        })
        .catch(error => console.error('Unable to add bte.', error));
}

function deleteBte(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getBtes())
        .catch(error => console.error('Unable to delete bts.', error));
}

function displayEditForm(id) {
    const bte = btes.find(bte => bte.id === id);

    document.getElementById('edit-id').value = bte.id;
    document.getElementById('edit-bead').value = bte.beadId;
    document.getElementById('edit-emb').value = bte.embroidericId;
    document.getElementById('editForm').style.display = 'block';
}

function updateBte() {
    const bteId = document.getElementById('edit-id').value;
    const bte = {
        id: parseInt(bteId, 10),
        beadid: parseInt(document.getElementById('edit-bead').value.trim()),
        embroidericId: parseInt(document.getElementById('edit-emb').value.trim()),
    };

    fetch(`${uri}/${bteId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(bte)
    })
        .then(() => getBtes())
        .catch(error => console.error('Unable to update bte.', error));

    closeInput();

    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}


function _displayBtes(data) {
    const tBody = document.getElementById('btes');
    tBody.innerHTML = '';


    const button = document.createElement('button');

    data.forEach(bte => {
        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${bte.id})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteBte(${bte.id})`);

        let tr = tBody.insertRow();


        let td1 = tr.insertCell(0);
        let textNode = document.createTextNode(bte.beadId);
        td1.appendChild(textNode);

        let td2 = tr.insertCell(1);
        let textNode2 = document.createTextNode(bte.embroidericId);
        td2.appendChild(textNode2);

        let td3 = tr.insertCell(2);
        td3.appendChild(editButton);

        let td4 = tr.insertCell(3);
        td4.appendChild(deleteButton);
    });

    btes = data;
}

