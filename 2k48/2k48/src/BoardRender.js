import React from 'react';


export function RenderBoard(board, score, message) {
    return (
        <div>
            <div className="score">Score: {score}</div>
            <table border="1px solid black" border-collapse="collapse">
                <tbody>
                    {board.map((row, i) => (<Row key={i} row={row} />))}
                </tbody>
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
        <td
            border="1px solid black"
            border-collapse="collapse"
            width="50"
            height="50"
            align="center"
            style={{ backgroundColor: color(cellValue) }}>
            <div>{value}</div>
        </td>
    );
};

var color = function (value) {
    if (!value) {
        return "white";
    }
    var blue = ((Math.log2(value) + 1) % 2) * 128;
    var green = (Math.log2(value) * 40 + 100) % 256;
    var red = (Math.log2(value) % 2) * 128;

    return "rgb(" + red + ", " + green + ", " + blue + ")";
}