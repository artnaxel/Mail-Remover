import React, { useState, useEffect } from "react";
import { Card, Box, CardContent, Typography } from "@mui/material";
import "./User.css";
import { useUser } from "../../context/user-context";
import axios from "axios";

const UserInfo = () => {
  const {
    state: { user_id },
  } = useUser();

  const [user, setUser] = useState(null);

  useEffect(() => {
    if (!user && user_id) {
      fetchUserInfo();
    }
  }, []);

  const fetchUserInfo = async () => {
    try {
      const response = await axios.get(
        `https://localhost:7151/api/Users/${user_id}`
      );

      console.log(response);

      if (response.status === 200) {
        setUser(response.data);
      }
    } catch (e) {}
  };
  return (
    <div>
      <Box>
        <Card>
          <CardContent>
            {user && (
              <>
                <Typography variant="h5">User profile information</Typography>
                <Typography variant="body2">
                  User name: {user.firstName} {user.lastName}
                </Typography>
                <Typography variant="body2">
                  User email: {user.userEmail}
                </Typography>
              </>
            )}

            {!user && (
              <Typography variant="h5">Fetching user data...</Typography>
            )}
          </CardContent>
        </Card>
      </Box>
    </div>
  );
};

export default UserInfo;
