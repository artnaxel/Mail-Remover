import React from "react";
import "./App.css";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import Layout from "./components/layout/Layout";
import AddNewUser from "./pages/addNewEmail/AddNewUser";
import MainPage from "./pages/mainPage/MainPage";
import UserInfo from "./pages/user/UserInfo";
import Login from "./pages/login/Login";
import { UserProvider, useUser } from "./context/user-context";

function App() {
  return (
    <BrowserRouter>
      <UserProvider>
        <Layout>
          <div className="App">
            <Routes>
              <Route path="/signup" element={<AddNewUser />} />
              <Route path="/login" element={<Login />} />
              <Route path="/" element={<MainPage />} />
              <Route path="/user_info" element={<UserInfo />} />
            </Routes>
          </div>
        </Layout>
      </UserProvider>
    </BrowserRouter>
  );
}

export default App;
