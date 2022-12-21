import React, { useState, useEffect } from "react";

// Material UI imports
import { Link } from "@mui/material";

import { useUser } from "../../context/user-context";

// Importing styles
import styles from "./GmailFunctions.module.css";

// Importing components
import AddGmailForm from "./components/AddGmailForm";
import GmailFunctionsTryout from "./components/GmailFunctionsTryout";

import axios from "axios";

const GmailFunctions = () => {
  const [authLink, setAuthLink] = useState(null);
  const [gmailId, setGmailId] = useState(null);
  const { dispatch } = useUser();

  const handleSetAuth = (link) => {
    window.location.replace(link);
    return null;
  };

  const {
    state: { user_id, user_gmail_id },
  } = useUser();

  const fetchGmailId = async () => {
    if (user_id) {
      try {
        const response = await axios.get(
          `https://localhost:7151/api/Users/get_gmail/${user_id}`
        );

        console.log(response.data[0]?.gmails[0].id);

        if (response.status === 200) {
          setGmailId(response.data[0]?.gmails[0].id);
          dispatch({
            type: "mail_remover_gmail_id",
            payload: response.data[0]?.gmails[0].id,
          });
        }
      } catch (e) {
        console.log(e);
      }
    }
  };

  useEffect(() => {
    const gmail_id = localStorage.getItem("user_gmail_id");
    if (!gmail_id) {
      fetchGmailId();
    }
  }, []);

  return (
    <div className={styles.main_box}>
      {!gmailId && <AddGmailForm handleSetAuth={handleSetAuth} />}
      {gmailId && <GmailFunctionsTryout />}
    </div>
  );
};

export default GmailFunctions;
