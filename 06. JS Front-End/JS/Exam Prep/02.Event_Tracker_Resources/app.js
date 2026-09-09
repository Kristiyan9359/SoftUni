window.addEventListener("load", solve);

function solve() {
    let eventInput = document.getElementById('event');
    let noteInput = document.getElementById('note');
    let dateInput = document.getElementById('date');

    let saveButton = document.getElementById('save');
    let upcomingList = document.getElementById('upcoming-list');
    let eventsList = document.getElementById('events-list');
    let deleteButton = document.querySelector('.delete');

    saveButton.addEventListener('click', saveEvent);
    deleteButton.addEventListener('click', deleteEvents);

    function saveEvent() {
        let eventName = eventInput.value;
        let note = noteInput.value;
        let date = dateInput.value;

        if (eventName === '' || note === '' || date === '') {
            return;
        }

        let li = createUpcomingEvent(eventName, note, date);
        upcomingList.appendChild(li);

        eventInput.value = '';
        noteInput.value = '';
        dateInput.value = '';
    }

    function createUpcomingEvent(eventName, note, date) {
        let li = document.createElement('li');
        li.className = 'event-item';

        let div = document.createElement('div');
        div.className = 'event-container';

        let article = document.createElement('article');

        let nameP = document.createElement('p');
        nameP.textContent = `Name: ${eventName}`;

        let noteP = document.createElement('p');
        noteP.textContent = `Note: ${note}`;

        let dateP = document.createElement('p');
        dateP.textContent = `Date: ${date}`;

        article.appendChild(nameP);
        article.appendChild(noteP);
        article.appendChild(dateP);

        let buttonsDiv = document.createElement('div');
        buttonsDiv.className = 'buttons';

        let editButton = document.createElement('button');
        editButton.className = 'btn edit';
        editButton.textContent = 'Edit';

        let doneButton = document.createElement('button');
        doneButton.className = 'btn done';
        doneButton.textContent = 'Done';

        buttonsDiv.appendChild(editButton);
        buttonsDiv.appendChild(doneButton);

        div.appendChild(article);
        div.appendChild(buttonsDiv);
        li.appendChild(div);

        editButton.addEventListener('click', function () {
            eventInput.value = eventName;
            noteInput.value = note;
            dateInput.value = date;

            li.remove();
        });

        doneButton.addEventListener('click', function () {
            let endedLi = document.createElement('li');
            endedLi.className = 'event-item';

            let endedArticle = document.createElement('article');

            endedArticle.appendChild(nameP);
            endedArticle.appendChild(noteP);
            endedArticle.appendChild(dateP);

            endedLi.appendChild(endedArticle);
            eventsList.appendChild(endedLi);

            li.remove();
        });

        return li;
    }

    function deleteEvents() {
        eventsList.innerHTML = '';
    }
}