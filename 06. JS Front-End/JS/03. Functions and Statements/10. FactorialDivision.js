function factorialDivision(num1, num2) {

    function factorial(n) {

        if (n === 0 || n === 1) {
            return 1;
        }

        let result = 1;

        for (let i = 2; i <= n; i++) {
            result *= i;
        }

        return result;
    }

    const factorialNum1 = factorial(num1);

    const factorialNum2 = factorial(num2);

    const divisionResult = factorialNum1 / factorialNum2;

    console.log(divisionResult.toFixed(2));
}

factorialDivision(5, 2);