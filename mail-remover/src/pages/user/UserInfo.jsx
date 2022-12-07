import { Card, Box, CardContent, Typography } from "@mui/material";
import "./User.css";

const UserInfo = () => {
  return (
    <div>
      <Box>
        <Card>
          <CardContent>
            <Typography variant="h5">User profile information</Typography>
            <Typography variant="body2">User name:</Typography>
            <Typography variant="body2">User email:</Typography>
          </CardContent>
        </Card>
      </Box>
    </div>
  );
};

export default UserInfo;
