import React from "react";
import AddNewUserForm from "./components/addnewEmailForm/AddNewUserForm";
import styles from "./AddNewUser.module.css";

export default function AddNewUser() {
  return (
    <div className={styles.login_main}>
      <AddNewUserForm />
    </div>
  );
}
