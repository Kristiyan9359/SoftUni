function sameNumbers(input) {
    let num = input.toString();
    let firstDigit = num[0];
    let isSame = true;
    let sum = 0;

    for (let i = 0; i < num.length; i++) {
        if (num[i] !== firstDigit) {
            isSame = false;
        }
        sum += Number(num[i]);
    }

    console.log(isSame);
    console.log(sum);
}

sameNumbers(1234);