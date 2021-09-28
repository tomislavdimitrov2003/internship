import React, { useEffect, useState } from 'react';
import { Close } from '@material-ui/icons';
import { Button, Dialog, DialogActions, DialogContent, DialogContentText, DialogTitle, TextField } from '@material-ui/core';

export default function Prompt(props) {
  let [open, setOpen] = useState(false);

  React.useEffect(() => {
    setOpen(props.finalScore !== 0);
  }, [props.finalScore]);

  function Close() {
    if(document.getElementById("username").value.replaceAll(' ','')){
      setOpen(false);
      props.username(document.getElementById("username").value);
    }
  }
  return (
    <div>
      <Dialog open={open} onClose={open = false}>
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