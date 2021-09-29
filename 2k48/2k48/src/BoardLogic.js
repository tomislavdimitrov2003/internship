import React from 'react';
import Table from "@material-ui/core/Table";
import TableBody from "@material-ui/core/TableBody";
import TableCell from "@material-ui/core/TableCell";
import TableContainer from "@material-ui/core/TableContainer";
import TableHead from "@material-ui/core/TableHead";
import TableRow from "@material-ui/core/TableRow";
import Paper from "@material-ui/core/Paper";
import { makeStyles } from '@material-ui/core/styles';
import { deepPurple } from '@material-ui/core/colors';
import { renderBoard } from './BoardRender';
import { DOWN, LEFT, RIGHT, UP, N } from './KeyCodes';


export class Board extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            board: new Array(this.size).fill(0).map(() => new Array(this.size).fill(0)),
            score: 0,
            size: 4,
            gameOver: false,
            message: ""
        };
    }


    initBoard(newSize = this.state.size) {
        let board = new Array(newSize).fill(0).map(() => new Array(newSize).fill(0));
        board = this.placeRandom(this.placeRandom(board));
        this.setState({ board, score: 0, gameOver: false, message: null });
    }

    componentDidUpdate(prevProps) {
        if (this.props.size !== prevProps.size) {
            this.setState({ size: this.props.size });
            this.initBoard(this.props.size);
        }
    }

    getBlankTiles(board) {
        let blankTiles = [];

        for (let i = 0; i < board.length; i++) {
            for (let j = 0; j < board[i].length; j++) {
                if (board[i][j] === 0) {
                    blankTiles.push([i, j]);
                }
            }
        }

        return blankTiles;
    }

    placeRandom(board) {
        const blankCoordinates = this.getBlankTiles(board);
        const randomTile = Math.floor(Math.random() * blankCoordinates.length);
        const x = blankCoordinates[randomTile][0];
        const y = blankCoordinates[randomTile][1];
        const randomNumber = (Math.round(Math.random()) % 2 + 1) * 2;
        board[x][y] = randomNumber;

        return board;
    }

    boardMoved(original, updated) {
        return (JSON.stringify(updated) !== JSON.stringify(original)) ? true : false;
    }

    move(direction) {
        if (this.state.gameOver) {
            return false;
        }

        let movedBoard;

        if (direction === 'up') {
            movedBoard = this.moveUp(this.state.board);
        } else if (direction === 'right') {
            movedBoard = this.moveRight(this.state.board);
        } else if (direction === 'down') {
            movedBoard = this.moveDown(this.state.board);
        } else if (direction === 'left') {
            movedBoard = this.moveLeft(this.state.board);
        }

        if (this.boardMoved(this.state.board, movedBoard.board)) {
            const boardWithRandom = this.placeRandom(movedBoard.board);

            if (this.checkForGameOver(boardWithRandom)) {
                if (this.props.onGameOver) {
                    this.props.onGameOver(this.state.score);
                }

                this.setState({ board: boardWithRandom, gameOver: true, message: 'Game over!' });
            } else {
                this.setState({ board: boardWithRandom, score: this.state.score + movedBoard.score });
            }
        }
    }

    moveUp(inputBoard) {
        let rotatedRight = this.rotateRight(inputBoard);
        let { board, score } = this.moveRight(rotatedRight);
        board = this.rotateLeft(board);

        return { board, score };
    }

    moveRight(inputBoard) {
        let board = [];
        let score = 0;

        for (let i = 0; i < inputBoard.length; i++) {
            let row = [];

            for (let j = 0; j < inputBoard[i].length; j++) {

                let current = inputBoard[i][j];
                (current === 0) ? row.unshift(current) : row.push(current);
            }
            board.push(row);
        }

        for (let i = 0; i < board.length; i++) {
            for (let j = board[i].length - 1; j > 0; j--) {
                if (board[i][j] > 0 && board[i][j] === board[i][j - 1]) {
                    board[i][j] = board[i][j] * 2;
                    board[i][j - 1] = 0;
                    score += board[i][j];

                    for (let k = j - 2; k >= 0; k--) {
                        board[i][k + 1] = board[i][k];
                    }

                    board[i][0] = 0;
                } else if (board[i][j] === 0 && board[i][j - 1] > 0) {
                    board[i][j] = board[i][j - 1];
                    board[i][j - 1] = 0;
                }
            }
        }

        return { board, score };
    }

    moveDown(inputBoard) {
        let rotatedRight = this.rotateRight(inputBoard);
        let { board, score } = this.moveLeft(rotatedRight);
        board = this.rotateLeft(board);

        return { board, score };
    }

    moveLeft(inputBoard) {
        let board = [];
        let score = 0;

        for (let r = 0; r < inputBoard.length; r++) {
            let row = [];

            for (let c = inputBoard[r].length - 1; c >= 0; c--) {
                let current = inputBoard[r][c];
                (current === 0) ? row.push(current) : row.unshift(current);
            }
            board.push(row);
        }

        for (let r = 0; r < board.length; r++) {
            for (let c = 0; c < board.length - 1; c++) {
                if (board[r][c] > 0 && board[r][c] === board[r][c + 1]) {
                    board[r][c] = board[r][c] * 2;
                    board[r][c + 1] = 0;
                    score += board[r][c];
                    
                    for (let i = c + 2; i < board.length - 1; i++) {
                        board[r][i - 1] = board[r][i];
                    }

                    board[r][board.length - 1] = 0;
                } else if (board[r][c] === 0 && board[r][c + 1] > 0) {
                    board[r][c] = board[r][c + 1];
                    board[r][c + 1] = 0;
                }
            }
        }

        return { board, score };
    }

    rotateRight(matrix) {
        let result = [];

        for (let c = 0; c < matrix.length; c++) {
            let row = [];
            for (let r = matrix.length - 1; r >= 0; r--) {
                row.push(matrix[r][c]);
            }
            result.push(row);
        }

        return result;
    }

    rotateLeft(matrix) {
        let result = [];

        for (let c = matrix.length - 1; c >= 0; c--) {
            let row = [];
            for (let r = matrix.length - 1; r >= 0; r--) {
                row.unshift(matrix[r][c]);
            }
            result.push(row);
        }

        return result;
    }

    checkForGameOver(board) {
        let moves = [
            this.boardMoved(board, this.moveUp(board).board),
            this.boardMoved(board, this.moveRight(board).board),
            this.boardMoved(board, this.moveDown(board).board),
            this.boardMoved(board, this.moveLeft(board).board)
        ];

        return moves.every(move => move === false);
    }

    componentDidMount() {
        this.initBoard();
        const body = document.querySelector('body');
        body.addEventListener('keydown', this.handleKeyDown.bind(this));
    }

    handleKeyDown(e) {
        if (e.keyCode === UP) {
            this.move('up');
        } else if (e.keyCode === RIGHT) {
            this.move('right');
        } else if (e.keyCode === DOWN) {
            this.move('down');
        } else if (e.keyCode === LEFT) {
            this.move('left');
        } else if (e.keyCode === N) {
            this.initBoard();
        }
    }

    render() {
        const { board, score, message } = this.state;

        return renderBoard(board, score, message);
    }
};
