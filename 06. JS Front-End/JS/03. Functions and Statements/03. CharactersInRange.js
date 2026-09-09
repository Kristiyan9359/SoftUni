function charactersInRange(char1, char2) {
    let startCharCode = char1.charCodeAt(0);
    let endCharCode = char2.charCodeAt(0);

    if (startCharCode > endCharCode) {
        [startCharCode, endCharCode] = [endCharCode, startCharCode];
    }

    let result = '';
    for (let i = startCharCode + 1; i < endCharCode; i++) {
        result += String.fromCharCode(i) + ' ';
    }
    console.log(result.trim());
}

charactersInRange('#', ':');