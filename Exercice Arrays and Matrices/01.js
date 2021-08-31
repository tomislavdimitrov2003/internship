function solve(arr) {
    let sym = arr.pop();
    
    return arr.join(sym);
}

console.log(solve(['One', 'Two', 'Three', 'Four', 'Five', '-']));