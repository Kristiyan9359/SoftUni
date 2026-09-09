function solve() {
    const BASE_URL = 'http://localhost:3030/jsonstore/matches';

    let hostInput = document.getElementById('host');
    let scoreInput = document.getElementById('score');
    let guestInput = document.getElementById('guest');

    let loadBtn = document.getElementById('load-matches');
    let addBtn = document.getElementById('add-match');
    let editBtn = document.getElementById('edit-match');
    let list = document.getElementById('list');

    let currentId = null;

    loadBtn.addEventListener('click', loadMatches);
    addBtn.addEventListener('click', addMatch);
    editBtn.addEventListener('click', editMatch);

    async function loadMatches() {
        list.innerHTML = '';

        addBtn.disabled = false;
        editBtn.disabled = true;

        let response = await fetch(BASE_URL);
        let data = await response.json();

        let matches = Object.values(data);

        for (let match of matches) {
            let li = createMatchElement(match);
            list.appendChild(li);
        }
    }

    async function addMatch() {
        let host = hostInput.value;
        let score = scoreInput.value;
        let guest = guestInput.value;

        await fetch(BASE_URL, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ host, score, guest })
        });

        clearInputs();
        await loadMatches();
    }

    function createMatchElement(match) {
        let li = document.createElement('li');
        li.className = 'match';

        let infoDiv = document.createElement('div');
        infoDiv.className = 'info';

        let hostP = document.createElement('p');
        hostP.textContent = match.host;

        let scoreP = document.createElement('p');
        scoreP.textContent = match.score;

        let guestP = document.createElement('p');
        guestP.textContent = match.guest;

        infoDiv.appendChild(hostP);
        infoDiv.appendChild(scoreP);
        infoDiv.appendChild(guestP);

        let btnWrapper = document.createElement('div');
        btnWrapper.className = 'btn-wrapper';

        let changeBtn = document.createElement('button');
        changeBtn.className = 'change-btn';
        changeBtn.textContent = 'Change';

        let deleteBtn = document.createElement('button');
        deleteBtn.className = 'delete-btn';
        deleteBtn.textContent = 'Delete';

        btnWrapper.appendChild(changeBtn);
        btnWrapper.appendChild(deleteBtn);

        li.appendChild(infoDiv);
        li.appendChild(btnWrapper);

        changeBtn.addEventListener('click', function () {
            hostInput.value = match.host;
            scoreInput.value = match.score;
            guestInput.value = match.guest;

            currentId = match._id;

            addBtn.disabled = true;
            editBtn.disabled = false;
        });

        deleteBtn.addEventListener('click', async function () {
            await fetch(`${BASE_URL}/${match._id}`, {
                method: 'DELETE'
            });

            await loadMatches();
        });

        return li;
    }

    async function editMatch() {
        let host = hostInput.value;
        let score = scoreInput.value;
        let guest = guestInput.value;

        await fetch(`${BASE_URL}/${currentId}`, {
            method: 'PATCH',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ host, score, guest })
        });

        clearInputs();

        currentId = null;

        addBtn.disabled = false;
        editBtn.disabled = true;

        await loadMatches();
    }

    function clearInputs() {
        hostInput.value = '';
        scoreInput.value = '';
        guestInput.value = '';
    }
}

solve();