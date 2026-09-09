function printAndSum(start, end) {
    let output = "";
    let sum = 0;

    for (let i = start; i <= end; i++) {
        output += i + " ";
        sum += i;
    }

    console.log(output.trim());
    console.log(`Sum: ${sum}`);
}

printAndSum(5, 10);