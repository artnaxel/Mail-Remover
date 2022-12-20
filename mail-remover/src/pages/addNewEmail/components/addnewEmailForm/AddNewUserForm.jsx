import { TextField, Paper, Box, Button, Typography } from "@mui/material";
import React, { useState } from "react";
import axios from "axios";

import Style from "./AddNewUserForm.module.css";

export default function AddNewUserForm() {
  const [userEmail, setUserEmail] = useState("");
  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState("");
  const [password, setPassword] = useState("");

  const handleTextFieldChange = (setValue) => (e) => setValue(e.target.value);
  return (
    <Box display="flex" justifyContent="center">
      <Paper className={Style.Paper} elevation={3}>
        <Typography variant="h5" className={Style.haeder}>
          Register
        </Typography>
        <TextField
          className={Style.TextField}
          label="Email"
          variant="outlined"
          onChange={handleTextFieldChange(setUserEmail)}
        />
        <br />
        <TextField
          className={Style.TextField}
          label="First Name"
          variant="outlined"
          onChange={handleTextFieldChange(setFirstName)}
        />
        <br />
        <TextField
          className={Style.TextField}
          label="Last Name"
          variant="outlined"
          onChange={handleTextFieldChange(setLastName)}
        />
        <br />
        <TextField
          className={Style.TextField}
          label="Password"
          variant="outlined"
          type="password"
          onChange={handleTextFieldChange(setPassword)}
        />
        <br />
        <Button
          className={Style.Button}
          variant="contained"
          onClick={() => {
            axios.post("https://localhost:7151/api/Users", {
              userEmail,
              firstName,
              lastName,
              password,
            });
          }}
        >
          Signup
        </Button>
      </Paper>
    </Box>
  );
}
