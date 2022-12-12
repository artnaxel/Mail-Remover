import { Typography, Button } from "@mui/material";
import { useNavigate } from "react-router-dom";
import React from "react";
import "./Header.css";

export default function Header() {
  const navigate = useNavigate();
  const handleClick = (option) => {
    if (option === "main") {
      navigate("/");
    } else {
      navigate(`/${option}`);
    }
  };

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
    </header>
  );
}
