function sumDigits(numbers) {
    let sum = 0;
    let number = String(numbers);
    for (let i = 0; i < number.length; i++) {
        sum += Number(number[i]);
    }
    console.log(sum);
}

sumDigits(245678);