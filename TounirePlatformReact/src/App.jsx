import React from "react";
import AuthContainer from "./Components/Authenticator/AuthContainer";
import UserProfilePage from "./Components/Authenticator/UserProfile/UserProfilePage";
import GamesList from "./Components/Games/GamesList";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
const App = () => {
  return (
    <Router>
      <div>
        <Routes> 
          <Route path="/auth" element={<AuthContainer />} /> 
          <Route path="/profile" element={<UserProfilePage />} />
          <Route path="/games" element={<GamesList />} />
          <Route path="/games/create" element={<addGame />} />
        </Routes>
      </div>
    </Router>
  );
};

export default App;
