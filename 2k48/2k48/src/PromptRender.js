import * as React from 'react';

import { Close } from '@material-ui/icons';
import { Button, Dialog, DialogActions, DialogContent, DialogContentText, DialogTitle, TextField } from '@material-ui/core';

export default function Prompt(props) {
    let open = props.finalScore !== 0;

    function Close(){
        open = false;
        props.username(document.getElementById("username").value);
    }
  return (
    <div>
      <Dialog open={open} onClose={open=false}>
        <DialogTitle>Game Over</DialogTitle>
        <DialogContent>
          <DialogContentText>
            You Finished with score of {props.finalScore}!
          </DialogContentText>
          <TextField
            autoFocus
            margin="dense"
            id="username"
            label="Username"
            type="username"
            fullWidth
            variant="standard"
          />
        </DialogContent>
        <DialogActions>
          <Button onClick={() => Close()}>Submit</Button>
        </DialogActions>
      </Dialog>
    </div>
  );
}