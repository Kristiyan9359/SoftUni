function roadRadar(speed, area) {
    
    let motorwayLimit = 130;
    let interstateLimit = 90;
    let cityLimit = 50;
    let residentialLimit = 20;
    let status = '';


    if (area === 'motorway') {

        if (speed > motorwayLimit) {

            let difference = speed - motorwayLimit;

            if (difference <= 20) {
                status = 'speeding';
            }

            else if (difference <= 40) {
                status = 'excessive speeding';
            }

            else {
                status = 'reckless driving';
            }
            console.log(`The speed is ${difference} km/h faster than the allowed speed of ${motorwayLimit} - ${status}`);
        }

        else {
            console.log(`Driving ${speed} km/h in a ${motorwayLimit} zone`);
        }
    }
    else if (area === 'interstate') {

        let difference = speed - interstateLimit;

        if (speed > interstateLimit) {

            if (difference <= 20) {
                status = 'speeding';
            }

            else if (difference <= 40) {
                status = 'excessive speeding';
            }
            
            else {
                status = 'reckless driving';
            }
            console.log(`The speed is ${difference} km/h faster than the allowed speed of ${interstateLimit} - ${status}`);
        }

        else {
            console.log(`Driving ${speed} km/h in a ${interstateLimit} zone`);
        }
    }
    else if (area === 'city') {

        if (speed > cityLimit) {

            let difference = speed - cityLimit;

            if (difference <= 20) {
                status = 'speeding';
            }

            else if (difference <= 40) {
                status = 'excessive speeding';
            }

            else {
                status = 'reckless driving';
            }
            console.log(`The speed is ${difference} km/h faster than the allowed speed of ${cityLimit} - ${status}`);
        }

        else {
            console.log(`Driving ${speed} km/h in a ${cityLimit} zone`);
        }
    }

    else if (area === 'residential') {

        let difference = speed - residentialLimit;

        if (speed > residentialLimit) {

            if (difference <= 20) {
                status = 'speeding';
            }

            else if (difference <= 40) {
                status = 'excessive speeding';
            }

            else {
                status = 'reckless driving';
            }
            console.log(`The speed is ${difference} km/h faster than the allowed speed of ${residentialLimit} - ${status}`);
        }

        else {
            console.log(`Driving ${speed} km/h in a ${residentialLimit} zone`);
        }
    }
}

roadRadar(200, 'motorway');