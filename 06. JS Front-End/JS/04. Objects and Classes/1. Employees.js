function employees(arr) {

    for (let i = 0; i < arr.length; i++) {
        let name = arr[i];
        let id = name.length;

        console.log(`Name: ${name} -- Personal Number: ${id}`);
    }
}

employees(['Silas Butler',
    'Adnaan Buckley',
    'Juan Peterson',
    'Brendan Villarreal'
])