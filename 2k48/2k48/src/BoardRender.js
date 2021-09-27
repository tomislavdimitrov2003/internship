import React from 'react';


export function renderBoard(board, score, message) {
    return (
        <div>
            <div className="score">Score: {score}</div>
            <table border="1px solid black" border-collapse="collapse">
                {board.map((row, i) => (<Row key={i} row={row} />))}
            </table>
            <div>{message}</div>
        </div>
    );
}

const Row = ({ row }) => {
    return (
        <tr>
            {row.map((cell, i) => (<Cell key={i} cellValue={cell} />))}
        </tr>
    );
};

const Cell = ({ cellValue }) => {
    let value = (cellValue === 0) ? '' : cellValue;

    return (
        <td border="1px solid black" border-collapse="collapse" width="50" height="50" align="center">
            <div >{value}</div>
        </td>
    );
};

var color = function(value) {
    if(!value){
        return "white";
    }
    var blue = Math.round(Math.log2(value) * 3 + 200);
    var green =  Math.round(Math.log2(value)  * 3 + 200);
    var red =  Math.round(Math.log2(value) * 3 + 200);
  
    return "RGB(" + red + ", " + green + ", " + blue + ")";
  }