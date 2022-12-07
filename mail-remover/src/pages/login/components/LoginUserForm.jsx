import {
  TextField,
  Paper,
  Box,
  Button,
  Typography,
  Alert,
} from "@mui/material";
import React, { useState } from "react";
import axios from "axios";

import Style from "./LoginUserForm.module.css";

const LoginUserForm = () => {
  const [id, setId] = useState("");
  const [status, setStatus] = useState(null);
  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState("");
  const [password, setPassword] = useState("");

  const handleTextFieldChange = (setValue) => (e) => setValue(e.target.value);

  const loginUser = async () => {
    try {
      const response = await axios.post("https://localhost:7151/login", {
        firstName,
        lastName,
        password,
      });

      if (response.status === 200) {
        setId(response.data);
        setStatus({
          code: 200,
          message: `All ok! User id is: ${response.data}`,
        });
      }
    } catch (error) {
      setStatus({ code: 500, message: error.message });
    }
  };

  return (
    <Box display="flex" justifyContent="center">
      <Paper className={Style.Paper} elevation={3}>
        {status && (
          <Alert severity={status.code === 200 ? "success" : "warning"}>
            {status.message}
          </Alert>
        )}
        <Typography variant="h5" className={Style.haeder}>
          Login
        </Typography>
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
          onClick={loginUser}
        >
          Login
        </Button>
      </Paper>
    </Box>
  );
};

export default LoginUserForm;
