import React, { useState } from "react";
import Button from "@mui/material/Button";
import api from "../api/axios";
const MainPage = () => {

  const getWords = async () => {
    const response = await api.get("words/GetAllwords");
    debugger;
  };

  return (
    <div>
      <Button variant="contained" onClick={getWords}>Hello world</Button>
    </div>
  );
};

export default MainPage;
