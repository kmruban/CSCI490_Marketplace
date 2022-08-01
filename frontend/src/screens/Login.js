import React, { useState, useContext, useEffect } from 'react';
import axios from "axios";
import { useNavigate, useLocation, Link } from "react-router-dom";

import { Store } from "../Store";

import { toast } from "react-toastify";
import Form from "react-bootstrap/Form";
import Button from "react-bootstrap/Button";

function Login() {
  const navigate = useNavigate();
  const { search } = useLocation();
  const redirectInUrl = new URLSearchParams(search).get("redirect");
  const redirect = redirectInUrl ? redirectInUrl : "/";

  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");

  const { state, dispatch: ctxDispatch } = useContext(Store);
  const { userInfo } = state;

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const { data } = await axios.post(
        "https://localhost:5001/User/login",
        {
          username,
          password,
        }
      );
      ctxDispatch({ type: "USER_LOGIN", payload: data });
      localStorage.setItem("userInfo", JSON.stringify(data));
      toast.success("Login Successful");
      console.log("Login Successful");
      navigate(redirect || "/");
    } catch (err) {
      console.log(err);
    }
  };

  useEffect(() => {
    if (localStorage.getItem("userInfo")) {
      navigate("/");
      console.log("user");
    }
  }, []);

  return (
    <Form onSubmit={handleSubmit}>
      <h3 className="pb-3">Login</h3>
      <Form.Group className="mb-3" controlId="formBasicEmail">
        <Form.Label>Username</Form.Label>
        <Form.Control
          type="text"
          placeholder="Enter username"
          onChange={(e) => setUsername(e.target.value)}
        />
      </Form.Group>

      <Form.Group className="mb-3" controlId="formBasicPassword">
        <Form.Label>Password</Form.Label>
        <Form.Control
          type="password"
          placeholder="Password"
          onChange={(e) => setPassword(e.target.value)}
        />
      </Form.Group>

      <div className="mt-4">
        <Button variant="primary" type="submit">
          Submit
        </Button>
      </div>
      <div className="mt-3">
        New customer?{" "}
        <Link to={`/register`}>Create your account here.</Link>
      </div>
    </Form>
  )
}

export default Login;
