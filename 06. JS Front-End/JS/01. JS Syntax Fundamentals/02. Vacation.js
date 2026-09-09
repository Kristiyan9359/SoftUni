function getTypeOfPeople(peopleCount, peopleType, day) {

    let price = 0;

    if (peopleType === "Students") {
        if (day === "Friday") {
            price = 8.45;
        } else if (day === "Saturday") {
            price = 9.80;
        } else if (day === "Sunday") {
            price = 10.46;
        }
    } else if (peopleType === "Business") {
        if (day === "Friday") {
            price = 10.90;
        } else if (day === "Saturday") {
            price = 15.60;
        } else if (day === "Sunday") {
            price = 16.00;
        }

        if (peopleCount >= 100) {
            peopleCount -= 10;
        }
    } else if (peopleType === "Regular") {
        if (day === "Friday") {
            price = 15.00;
        } else if (day === "Saturday") {
            price = 20.00;
        } else if (day === "Sunday") {
            price = 22.50;
        }
    }

    let totalPrice = peopleCount * price;

    if (peopleType === "Students" && peopleCount >= 30) {
        totalPrice *= 0.85;
    }

    if (peopleType === "Regular" && peopleCount >= 10 && peopleCount <= 20) {
        totalPrice *= 0.95;
    }

    console.log(`Total price: ${totalPrice.toFixed(2)}`);
}

getTypeOfPeople(30, "Students", "Sunday");   // Total price: 266.51