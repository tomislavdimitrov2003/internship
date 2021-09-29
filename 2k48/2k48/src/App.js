import React, { useState } from 'react';
import ReactDOM from 'react-dom';
import Grid from '@material-ui/core/Grid';
import { Board } from './BoardLogic';
import { TextField } from '@material-ui/core';
import Scoreboard from './Scoreboard';
import Prompt from './PromptRender';
import { ResizeButtons } from './ResizeButtonsRender';

export function App() {
  const [currentSize, setCurrentSize] = useState(4);
  const [finalScore, setFinalScore] = useState(0);
  const [username, setUsername] = useState(false);
  
  return (
    <div className="App" >
      <Grid container direction="column" alignItems="center" justify="center">
        <Grid item xs={1}>
          <ResizeButtons setCurrentSize={setCurrentSize}/>
        </Grid>
        <Grid item xs={8}>
          <Board size={currentSize} onGameOver={setFinalScore} />
          <Prompt username={setUsername} finalScore={finalScore} />
        </Grid>
        <Grid item xs={3}>
          <Scoreboard score={finalScore} setScore={setFinalScore} username={username} setUsername={setUsername} />
        </Grid>
      </Grid>
    </div>
  );
}