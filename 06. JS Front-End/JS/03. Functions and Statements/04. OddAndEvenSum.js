function oddAndEvenSum(num) {
    let numStr = num.toString();
    let evenSum = 0;
    let oddSum = 0;

    for (let i = 0; i < numStr.length; i++) {
        let digit = parseInt(numStr[i]);

        if (digit % 2 === 0) {
            evenSum += digit;
        } else {
            oddSum += digit;
        }
    }

    console.log(`Odd sum = ${oddSum}, Even sum = ${evenSum}`);
}

oddAndEvenSum(1000435);