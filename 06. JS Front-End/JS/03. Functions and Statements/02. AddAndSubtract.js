function addAndSubtract(num1, num2, num3) {
    function add(a, b) {
        return a + b;
    }

    function subtract(a, b) {
        return a - b;
    }

    let sum = add(num1, num2);
    let result = subtract(sum, num3);
    console.log(result);
}


addAndSubtract(23, 6, 10);