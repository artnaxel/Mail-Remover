import * as React from "react";

const UserContext = React.createContext();

function userReducer(state, action) {
  switch (action.type) {
    case "login": {
      localStorage.setItem("mail_remover_user_id", action.payload);
      return { user_id: action.payload };
    }
    case "register": {
      return { user: action.payload };
    }
    case "logout": {
      localStorage.removeItem("mail_remover_user_id");
      localStorage.removeItem("mail_remover_gmail_id");
      return { user: null, user_id: null, user_gmail_id: null };
    }
    case "mail_remover_gmail_id": {
      localStorage.setItem("mail_remover_gmail_id", action.payload);
      return { user_gmail_id: action.payload };
    }
    default: {
      throw new Error(`Unhandled action type: ${action.type}`);
    }
  }
}

function UserProvider({ children }) {
  const [state, dispatch] = React.useReducer(userReducer, { user: null });
  const value = { state, dispatch };
  return <UserContext.Provider value={value}>{children}</UserContext.Provider>;
}

function useUser() {
  const context = React.useContext(UserContext);
  if (context === undefined) {
    throw new Error("useUser must be used within a UserProvider");
  }
  return context;
}

export { UserProvider, useUser };
