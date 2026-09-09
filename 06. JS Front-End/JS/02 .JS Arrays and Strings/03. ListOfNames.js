function listOfNames(names) {
    let sortedNames = names.sort((a, b) => a.localeCompare(b));
    return sortedNames.map((name, index) => `${index + 1}.${name}`).join('\n');
}

console.log(listOfNames(["John", "Bob", "Christina", "Ema"]));