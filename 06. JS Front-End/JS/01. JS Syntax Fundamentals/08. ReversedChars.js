function reversedChars(firstChar, secondChar, thirdChar) {
    let reversedString = thirdChar + secondChar + firstChar;
    reversedString = reversedString.split("").join(" ");
    console.log(reversedString);
}

reversedChars("A", "B", "C");
