import { Typography, Button, Link } from "@mui/material";
import { useNavigate } from "react-router-dom";
import React from "react";
import { useUser } from "../../context/user-context";
import "./Header.css";
import { useEffect } from "react";

export default function Header() {
  const navigate = useNavigate();
  const { dispatch } = useUser();
  const handleClick = (option) => {
    if (option === "logout") {
      dispatch({ type: "logout" });
      navigate("/");
    } else if (option === "main") {
      navigate("/");
    } else {
      navigate(`/${option}`);
    }
  };

  const {
    state: { user },
  } = useUser();

  useEffect(() => {
    const user_id = localStorage.getItem("mail_remover_user_id");
    if (user_id) {
      dispatch({ type: "login", payload: user_id });
    }
  }, []);

  return (
    <header>
      <Typography
        variant="body1"
        className="title"
        onClick={() => {
          handleClick("main");
        }}
      >
        Mail Remover
      </Typography>
      <div className="nav_buttons">
        {user !== null ? (
          <>
            <Button
              onClick={() => {
                handleClick("user_info");
              }}
              variant="outlined"
            >
              User Info
            </Button>
            <Button
              onClick={() => {
                handleClick("gmail_functions");
              }}
              variant="contained"
            >
              Gmail Functions
            </Button>
            <Button
              onClick={() => {
                handleClick("logout");
              }}
              variant="outlined"
            >
              Logout
            </Button>
          </>
        ) : (
          <div>
            <Button
              onClick={() => {
                handleClick("signup");
              }}
              variant="contained"
            >
              Register
            </Button>
            <Button
              onClick={() => {
                handleClick("login");
              }}
              variant="contained"
            >
              Log In
            </Button>
          </div>
        )}
      </div>
    </header>
  );
}
