function getAgeGroup(age) {
    if (age >= 0 && age <= 2)
        return "baby";
    else if (age >= 3 && age <= 13)
        return "child";
    else if (age >= 14 && age <= 19)
        return "teenager";
    else if (age >= 20 && age <= 65)
        return "adult";
    else if (age >= 66)
        return "elder";
    else
        return "out of bounds";
}

console.log(getAgeGroup(1));    // baby
console.log(getAgeGroup(5));    // child
console.log(getAgeGroup(14));   // teenager
console.log(getAgeGroup(30));   // adult
console.log(getAgeGroup(70));   // elder
console.log(getAgeGroup(-5));   // out of bounds