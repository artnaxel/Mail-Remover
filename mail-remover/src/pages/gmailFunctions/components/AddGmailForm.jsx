import React, { useState } from "react";

// MUI Imports
import {
  Paper,
  Typography,
  FormGroup,
  FormControlLabel,
  Checkbox,
  Alert,
} from "@mui/material";
import LoadingButton from "@mui/lab/LoadingButton";
import SendIcon from "@mui/icons-material/Send";

import { useUser } from "../../../context/user-context";

import axios from "axios";

import styles from "./AddGmailForm.module.css";

const AddGmailForm = (props) => {
  const [tacChecked, setTacChecked] = useState(false);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState(null);

  const {
    state: { user_id },
  } = useUser();

  const handleCheckboxChange = () => {
    let tmp = tacChecked;
    setTacChecked(!tmp);
  };

  // Getting the link right here
  const handleSubmit = async () => {
    setLoading(true);

    console.log(user_id);

    try {
      const response = await axios.get(
        `https://localhost:7151/api/GoogleAuth/Get?user_id=${user_id}`
      );

      console.log(response);
      if (response.status === 200) {
        props.handleSetAuth(response.data.result);
      } else {
        setError(response.data);
        setLoading(false);
      }
    } catch (e) {
      setError(e.message);
      setLoading(false);
    }
  };

  return (
    <div>
      <Paper className={styles.form_paper}>
        {error && <Alert severity="warning">{error}</Alert>}
        <Typography variant="h5">
          Here you can add your Gmail account!
        </Typography>
        <Typography variant="body">
          To start, accept our terms and conditions and click submit.
        </Typography>
        <div className={styles.form}>
          <Typography variant="body">
            Here is some little terms and conditions, don't mind them at the
            moment, as this paragraph is purely made as a placeholder, we do not
            really have any terms or conditions at this point in time
          </Typography>
          <FormGroup className={styles.checkbox}>
            <FormControlLabel
              control={
                <Checkbox
                  checked={tacChecked}
                  onChange={handleCheckboxChange}
                />
              }
              label="I accept the terms and conditions"
            />
            <LoadingButton
              className={styles.submit_button}
              loading={loading}
              endIcon={<SendIcon />}
              loadingPosition="end"
              variant="contained"
              disabled={!tacChecked}
              onClick={handleSubmit}
            >
              Submit
            </LoadingButton>
          </FormGroup>
        </div>
      </Paper>
    </div>
  );
};

export default AddGmailForm;
