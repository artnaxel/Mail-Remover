import { Card, Box, CardContent, Typography } from "@mui/material";
import "./MainPage.css";

const MainPage = () => {
  return (
    <div className="mainpage">
      <Box>
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
    </div>
  );
};

export default MainPage;
