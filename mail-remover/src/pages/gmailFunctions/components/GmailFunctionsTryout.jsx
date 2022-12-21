import React, { useState } from "react";

// MUI Imports
import {
  Paper,
  Typography,
  TextField,
  Alert,
  Button,
  FormControl,
  InputLabel,
  Select,
  MenuItem,
} from "@mui/material";
import LoadingButton from "@mui/lab/LoadingButton";
import SendIcon from "@mui/icons-material/Send";

import { useUser } from "../../../context/user-context";

import axios from "axios";

import styles from "./AddGmailForm.module.css";

const GmailFunctionsTryout = (props) => {
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState(null);
  const [profileInfo, setProfileInfo] = useState(null);
  const [totalMessages, setTotalMessages] = useState(null);
  const [totalDeletedMessages, setTotalDeletedMessages] = useState(null);
  const [unwantedEmails, setUnwantedEmails] = useState([]);
  const [selectedEmail, setSelectedEmail] = useState([]);

  const {
    state: { user_id, user_gmail_id },
  } = useUser();

  const handleUnwantedEmailChange = (event) => {
    setSelectedEmail(event.target.value);
  };

  const handleRequest = async (option) => {
    if (option === "get_info") {
      try {
        const response = await axios.get(
          `https://localhost:7151/api/Gmails/GetProfile?Id=${user_gmail_id}`
        );

        console.log(response.data);

        if (response.status === 200) {
          setProfileInfo(response.data);
        }
      } catch (e) {
        console.log(e);
      }
    } else if (option === "get_total") {
      try {
        const response = await axios.get(
          `https://localhost:7151/api/Gmails/GetMemoryConsumptionByContacts?Id=${user_gmail_id}`
        );

        console.log(response.data);

        if (response.status === 200) {
          setTotalMessages(response.data);
          response.data.gmailEmailMemoryConsumptionPairs.forEach((item) => {
            console.log(item);
            setUnwantedEmails((current) => [...current, item]);
          });
          console.log(unwantedEmails);
        }
      } catch (e) {
        console.log(e);
      }
    } else if (option === "delete") {
      try {
        const response = await axios.delete(
          `https://localhost:7151/api/Gmails/DeleteGmailsByEmail?Id=${user_gmail_id}&emailFrom=${selectedEmail}`
        );

        console.log(response.data);

        if (response.status === 200) {
          setTotalDeletedMessages(response.data);
        }
      } catch (e) {
        console.log(e);
      }
    }
  };

  return (
    <div>
      <Paper className={styles.form_paper}>
        {error && <Alert severity="warning">{error}</Alert>}
        <Typography variant="h5">
          Here you can try out our functions!
        </Typography>
        <Typography variant="body">Choose function and try it :)</Typography>
      </Paper>
      <br />
      <br />
      <Paper className={styles.form_paper}>
        <div className={styles.tryout_functions}>
          <Typography variant="h5">
            Get statistics about your gmail account
          </Typography>
          <div className={styles.tryout_single_function}>
            <br />
            <br />
            <Button
              variant="contained"
              onClick={() => {
                handleRequest("get_info");
              }}
            >
              Get info
            </Button>
            <br />
            <br />
            {profileInfo && (
              <>
                {" "}
                <Typography className={styles.tryout_result}>
                  Your connected gmail address: {profileInfo.emailAddress}
                </Typography>
                <Typography className={styles.tryout_result}>
                  You have total of : {profileInfo.messagesTotal} messages
                </Typography>
                <Typography className={styles.tryout_result}>
                  You have total of : {profileInfo.threadsTotal} threads
                </Typography>{" "}
              </>
            )}
          </div>
        </div>
      </Paper>
      <br />
      <br />
      <Paper className={styles.form_paper}>
        <div className={styles.tryout_functions}>
          <Typography variant="h5">
            Get statistics about messages and emissions
          </Typography>
          <div className={styles.tryout_single_function}>
            <br />
            <br />
            <Button
              variant="contained"
              onClick={() => {
                handleRequest("get_total");
              }}
            >
              Get statistics
            </Button>
            <br />
            <br />
            {totalMessages && (
              <>
                {" "}
                <Typography className={styles.tryout_result}>
                  Your emails emmit:{" "}
                  {Math.round(totalMessages.co2Emissions * 100) / 100}kg of CO2
                  per year!
                </Typography>
              </>
            )}
          </div>
        </div>
      </Paper>
      <br />
      <br />
      {unwantedEmails.length > 0 && (
        <Paper className={styles.form_paper}>
          <div className={styles.tryout_functions}>
            <Typography variant="h5">
              Delete largest emails from selected account
            </Typography>
            <div className={styles.tryout_single_function}>
              <br />
              <br />
              <FormControl fullWidth>
                <InputLabel id="demo-simple-select-label">
                  Choose the address!
                </InputLabel>
                <Select
                  labelId="demo-simple-select-label"
                  id="demo-simple-select"
                  value={selectedEmail}
                  label="Emails to choose from"
                  onChange={handleUnwantedEmailChange}
                >
                  {unwantedEmails.map((item) => {
                    return <MenuItem value={item.from}>{item.from}</MenuItem>;
                  })}
                </Select>
              </FormControl>
              <br />
              <br />
              <Button
                variant="contained"
                disabled={unwantedEmails === null}
                onClick={() => {
                  handleRequest("delete");
                }}
              >
                Delete
              </Button>
              <br />
              <br />
              {totalDeletedMessages && (
                <>
                  {" "}
                  <Typography className={styles.tryout_result}>
                    We have just deleted: {totalDeletedMessages} bytes worth of
                    emails!
                  </Typography>
                </>
              )}
            </div>
          </div>
        </Paper>
      )}
    </div>
  );
};

export default GmailFunctionsTryout;
