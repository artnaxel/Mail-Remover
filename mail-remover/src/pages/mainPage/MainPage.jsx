import {
  Card,
  Box,
  CardContent,
  Typography,
  TextField,
  Paper,
  Button,
  Alert,
} from "@mui/material";
import React, { useState } from "react";
import axios from "axios";
import "./MainPage.css";
import Style from "./MainPage.module.css";

const MainPage = () => {
  const [totalMessages, setTotalMessages] = useState("");
  const [status, setStatus] = useState(null);
  const handleTextFieldChange = (setValue) => (e) => setValue(e.target.value);

  const calculateMessages = async () => {
    try {
      const response = await axios.get(
        `https://localhost:7151/api/UnauthorizedFunctions?totalMessages=${totalMessages}`,
        {
          totalMessages,
        }
      );

      if (response.status === 200) {
        console.log(response.data);
        setStatus({
          code: 200,
          data: response.data,
        });
      }
    } catch (error) {
      setStatus({ code: 500, message: error.message });
    }
  };

  return (
    <div className="mainpage">
      <Box className={Style.main_header}>
        <Card>
          <CardContent>
            <Typography variant="h2">Welcome to Mail Remover!</Typography>
            <Typography variant="body2">
              This program is designed for deleting mail to encourage an eco
              future!
            </Typography>
          </CardContent>
        </Card>
      </Box>
      <Box display="flex" justifyContent="center" className={Style.main_header}>
        <Paper elevation={3} className={Style.Paper}>
          {/* {status && <Alert severity="warning">{status.message}</Alert>} */}
          <Typography variant="h5" className={Style.header}>
            Email CO2 Footprint Calculator
          </Typography>
          <Typography variant="caption" className={Style.caption}>
            Try it out! <br></br>And to get a more accurate estimate and to
            reduce your CO2 emissions, sign up on MailRemover!
          </Typography>
          <TextField
            className={Style.TextField}
            label="Email Amount"
            variant="outlined"
            onChange={handleTextFieldChange(setTotalMessages)}
          />
          <br />
          <Button variant="contained" onClick={calculateMessages}>
            Calculate Footprint
          </Button>
        </Paper>
      </Box>
      {status && (
        <Box display="flex" justifyContent="center">
          <Card className={Style.results}>
            <CardContent>
              <Typography variant="h4">Your estimates:</Typography>
              <div>
                <Typography variant="h5">
                  In a year you emmit approximately{" "}
                  <strong>{status.data.co2}kg </strong>
                  of CO2!
                </Typography>
              </div>
              <div>
                <Typography variant="h5">
                  The same amount of CO2 is emited by laying{" "}
                  <strong>{status.data.eggs}</strong> eggs!
                </Typography>
              </div>
            </CardContent>
          </Card>
        </Box>
      )}
    </div>
  );
};

export default MainPage;
