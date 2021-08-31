function solve(input) {
    let result = input.slice();
    let rotation = Number(result.pop()) % result.length;
    
    if (rotation === 0) {
        result = result.join(' ');
    }else{
        result = (result.slice(-rotation).concat(result.slice(0, result.length - rotation))).join(' ');
    }
    
    return result;
}
console.log(solve(['Banana', 'Orange', 'Coconut', 'Apple', '15']))

console.log(solve(['1', '2', '3', '4', '2']))