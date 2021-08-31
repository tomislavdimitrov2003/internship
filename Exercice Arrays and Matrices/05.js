function solve(input) {
    let numbers = input.slice();
    let biggestNum = numbers[0];
    let result = [];
    
 numbers.forEach((num) => {
        if (num >= biggestNum) {
            result.push(num);
            biggestNum = num;
        }
    });

    console.log(result.join('\n'));
}

solve([1, 3, 8, 4, 10, 12, 3, 2, 24]);