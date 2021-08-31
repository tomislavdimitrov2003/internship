function sumOfLine(arr) {
    return arr.reduce((a, b) => a +b);
}

function solve(input) {
    let sum = input[0].reduce((a, b) => a + b);
    let result = true;

    for (let i = 0; i < input.length && result; i++) {
        let row = sumOfLine(input[i]);
        let column = sumOfLine(input.map((n) => n[i]));
        
        if (row != sum || column != sum) {
            result = false;
        }
    }
    console.log(result);
}

solve([[4, 5, 6], [6, 5, 4], [5, 5, 5]]);