function isLeapYear(year) {
    if (year % 4 !== 0) {
        return "no";
    } else if (year % 100 !== 0) {
        return "yes";
    } else if (year % 400 !== 0) {
        return "no";
    } else {
        return "yes";
    }
}

console.log(isLeapYear(2003));