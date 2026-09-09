function stringSubstring(word, text) {

    word = word.toLowerCase();
    let words = text.toLowerCase().split(' ');

    if (words.includes(word)) {
        console.log(word);
    }
    else {
        console.log(`${word} not found!`);
    }

}

stringSubstring('python', 'JavaScript is the best programming language');