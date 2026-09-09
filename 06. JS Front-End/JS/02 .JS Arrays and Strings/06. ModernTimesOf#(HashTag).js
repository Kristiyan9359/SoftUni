function hashTag(text) {
    let words = text.split(' ');

    for (const word of words) {
        if (word.startsWith('#') && word.length > 1) {
            let specialWord = word.substring(1);
            let isValid = true;

            for (const ch of specialWord) {
                if (!/[a-zA-Z]/.test(ch)) {
                    isValid = false;
                    break;
                }
            }

            if (isValid) {
                console.log(specialWord);
            }
        }
    }
}

hashTag('The symbol # is known #variously in English-speaking #regions as the #number sign');