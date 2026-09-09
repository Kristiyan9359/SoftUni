function cooking(number, op1, op2, op3, op4, op5) {

    number = Number(number);

    let operations = [op1, op2, op3, op4, op5];

    for (let i = 0; i < operations.length; i++) {
        
        let operation = operations[i];

        switch (operation) {
            case 'chop':
                number /= 2;
                console.log(number);
                break;
            case 'dice':
                number = Math.sqrt(number);
                console.log(number);
                break;
            case 'spice':
                number += 1;
                console.log(number);
                break;
            case 'bake':
                number *= 3;
                console.log(number);
                break;
            case 'fillet':
                number -= number * 0.2;
                console.log(number);
                break;
        }
    }
}

cooking('9', 'dice', 'spice', 'chop', 'bake', 'fillet');