function sortingNumbers(arr) {

    let result = [];
    let left = 0;
    let right = arr.length - 1;

    arr.sort((a, b) => a - b);

    while (left <= right) {
       result.push(arr[left]);
       left++;
        if (left <= right){
            result.push(arr[right]);
            --right;
        }
    }
    return result;
}

    console.log(sortingNumbers([1, 65, 3, 52, 48, 63, 31, -3, 18, 56])); // Output: [-3, 65, 1, 63, 3, 56, 18, 52, 31, 48]