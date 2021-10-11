import React from 'react';

export function ResizeButtons(props) {
    return (
        <div>
            <button className="resize4" type="button" onClick={() => props.setCurrentSize(4)}>4x4</button>
            <button className="resize5" type="button" onClick={() => props.setCurrentSize(5)}>5x5</button>
            <button className="resize6" type="button" onClick={() => props.setCurrentSize(6)}>6x6</button>
        </div>
    );
}