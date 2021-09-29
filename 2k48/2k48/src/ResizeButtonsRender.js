export function ResizeButtons (props) {
    return (
        <div>
            <button type="button" onClick={() => props.setCurrentSize(4)}>4x4</button>
            <button type="button" onClick={() => props.setCurrentSize(5)}>5x5</button>
            <button type="button" onClick={() => props.setCurrentSize(6)}>6x6</button>
        </div>
    );
}