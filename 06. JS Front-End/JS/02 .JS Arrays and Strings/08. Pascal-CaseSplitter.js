function pascalCaseSplitter(str) {
    const words = str.match(/[A-Z][a-z]*/g);
    console.log(words ? words.join(', ') : '');
}

pascalCaseSplitter('SplitMeIfYouCanHaHaYouCantOrYouCan'); // Output: "Pascal Case Splitter"