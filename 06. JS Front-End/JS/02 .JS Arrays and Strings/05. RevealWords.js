function revealWords(words, text) {

        for (let word of words.split(', ')) {
            let replacement = '*'.repeat(word.length);
            text = text.replace(replacement, word);
        }
        console.log(text);    

}

revealWords('great, learning', 'softuni is ***** place for ******** new programming languages')