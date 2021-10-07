import React, { useEffect } from "react";
import RenderScoreboard from "./ScoreboardRenderer";

export default function Scoreboard(props) {
    function addRow(name, score) {
        return { name, score };
    }

    let rows = getAllStorage();

    function getAllStorage() {
        var values = [],
            keys = Object.keys(localStorage),
            i = keys.length;

        while (i--) {
            values.push(addRow(keys[i], parseInt(localStorage.getItem(keys[i]))));
        }

        return values;
    }

    useEffect(() => {
        if (props.username) {
            localStorage.setItem(props.username, props.score);
            rows = getAllStorage();
            props.setUsername(false);
            props.setScore(0);
        }
    }, [props.username]);

    return <RenderScoreboard rows={rows}/>
}