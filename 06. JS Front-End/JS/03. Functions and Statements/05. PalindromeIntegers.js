function palindromeIntegers(arr) {
    let result = [];

    for (let i = 0; i < arr.length; i++) {
        let num = arr[i].toString();
        let reversedNum = num.split('').reverse().join('');

        if (num === reversedNum) {
            result.push(true);
        } else {
            result.push(false);
        }
    }

    console.log(result.join('\n'));
}

palindromeIntegers([123, 323, 421, 121]);