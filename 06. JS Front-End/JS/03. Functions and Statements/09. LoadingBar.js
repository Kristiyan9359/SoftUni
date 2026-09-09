function loadingBar(number) {

    let bar = '';
    let percent = number / 10;

    for (let i = 0; i < 10; i++) {
        if (i < percent) {
            bar += '%';
        } else {
            bar += '.';
        }
    }

    if (number === 100) {
        bar = '%%%%%%%%%%';
        console.log('100% Complete!');
        console.log(`[${bar}]`);
    } else {
        console.log(`${number}% [${bar}]`);
        console.log('Still loading...');
    }
}

loadingBar(100);