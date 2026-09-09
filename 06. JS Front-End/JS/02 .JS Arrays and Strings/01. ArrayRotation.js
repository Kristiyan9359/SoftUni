function arrayRotation(arr, rotations) {

    for (let i = 0; i < rotations; i++) {

        let firstElement = arr.shift();
        arr.push(firstElement);
    }

    console.log(arr.join(' '));

}

arrayRotation([51, 47, 32, 61, 21], 2);