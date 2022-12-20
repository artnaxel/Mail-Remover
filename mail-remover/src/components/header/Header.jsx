import { Typography, Button } from "@mui/material";
import { useNavigate } from "react-router-dom";
import React from "react";
import { useUser } from "../../context/user-context";
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

  const {
    state: { user },
  } = useUser();

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
          <Button
            onClick={() => {
              handleClick("user_info");
            }}
            variant="outlined"
          >
            User Info
          </Button>
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
