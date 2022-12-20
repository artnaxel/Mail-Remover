import { Card, Box, CardContent, Typography } from "@mui/material";
import "./User.css";
import { useUser } from "../../context/user-context";

const UserInfo = () => {
  const {
    state: { user },
  } = useUser();
  return (
    <div>
      <Box>
        <Card>
          <CardContent>
            {user && <Typography>{user}</Typography>}
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
