function attachEvents() {
    const BASE_URL = 'http://localhost:3030/jsonstore/orders';

    let nameInput = document.getElementById('name');
    let quantityInput = document.getElementById('quantity');
    let dateInput = document.getElementById('date');

    let loadBtn = document.getElementById('load-orders');
    let orderBtn = document.getElementById('order-btn');
    let editBtn = document.getElementById('edit-order');
    let list = document.getElementById('list');

    let currentId = null;

    loadBtn.addEventListener('click', loadOrders);
    orderBtn.addEventListener('click', createOrder);
    editBtn.addEventListener('click', editOrder);

    async function loadOrders() {
        list.innerHTML = '';

        orderBtn.disabled = false;
        editBtn.disabled = true;

        let response = await fetch(BASE_URL);
        let data = await response.json();

        let orders = Array.isArray(data) ? data : Object.values(data);

        for (let order of orders) {
            let container = createOrderElement(order);
            list.appendChild(container);
        }
    }

    async function createOrder(e) {
        e.preventDefault();

        let name = nameInput.value;
        let quantity = quantityInput.value;
        let date = dateInput.value;

        if (name === '' || quantity === '' || date === '') {
            return;
        }

        await fetch(BASE_URL, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                name,
                quantity,
                date
            })
        });

        clearInputs();
        await loadOrders();
    }

    function createOrderElement(order) {
        let container = document.createElement('div');
        container.className = 'container';

        let nameH2 = document.createElement('h2');
        nameH2.textContent = order.name;

        let dateH3 = document.createElement('h3');
        dateH3.textContent = order.date;

        let quantityH3 = document.createElement('h3');
        quantityH3.textContent = order.quantity;

        let changeBtn = document.createElement('button');
        changeBtn.className = 'change-btn';
        changeBtn.textContent = 'Change';

        let doneBtn = document.createElement('button');
        doneBtn.className = 'done-btn';
        doneBtn.textContent = 'Done';

        container.appendChild(nameH2);
        container.appendChild(dateH3);
        container.appendChild(quantityH3);
        container.appendChild(changeBtn);
        container.appendChild(doneBtn);

        changeBtn.addEventListener('click', function () {
            nameInput.value = order.name;
            quantityInput.value = order.quantity;
            dateInput.value = order.date;

            currentId = order._id;

            container.remove();

            orderBtn.disabled = true;
            editBtn.disabled = false;
        });

        doneBtn.addEventListener('click', async function () {
            await fetch(`${BASE_URL}/${order._id}`, {
                method: 'DELETE'
            });

            await loadOrders();
        });

        return container;
    }

    async function editOrder(e) {
        e.preventDefault();

        let name = nameInput.value;
        let quantity = quantityInput.value;
        let date = dateInput.value;

        await fetch(`${BASE_URL}/${currentId}`, {
            method: 'PATCH',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                name,
                quantity,
                date
            })
        });

        clearInputs();

        currentId = null;

        orderBtn.disabled = false;
        editBtn.disabled = true;

        await loadOrders();
    }

    function clearInputs() {
        nameInput.value = '';
        quantityInput.value = '';
        dateInput.value = '';
    }
}

attachEvents();