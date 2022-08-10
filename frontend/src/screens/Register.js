import React, { useState, useContext, useEffect } from 'react';
import axios from "axios";
import { useNavigate, useLocation, Link } from "react-router-dom";
import { toast } from "react-toastify";
import Form from "react-bootstrap/Form";
import Button from "react-bootstrap/Button";
import { Store } from "../Store";

function Register() {
  const navigate = useNavigate();
  const { search } = useLocation();
  const redirectInUrl = new URLSearchParams(search).get("redirect");
  const redirect = redirectInUrl ? redirectInUrl : "/";

  const [username, setUsername] = useState("");
  const [firstname, setFirstname] = useState("");
  const [lastname, setLastname] = useState("");
  const [password, setPassword] = useState(""); 
  const [email, setEmail] = useState("");

  const { state, dispatch: ctxDispatch } = useContext(Store);
  const { userInfo } = state;

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const { data } = await axios.post(
        "https://localhost:5001/User",
        {
          username,
          firstname,
          lastname,
          password,
          email
        }
      );
      ctxDispatch({ type: "USER_REGISTER", payload: data });
      toast.success("Registration Successful");
      console.log("Registration Successful");
      navigate(redirect || "/");
    } catch (err) {
      toast.error(err);
    }
  };

  return (
    <Form onSubmit={handleSubmit}>
      <h3 className="pb-3">Register</h3>
      <Form.Group className="mb-3">
        <Form.Label>Username</Form.Label>
        <Form.Control
          type="text"
          placeholder="Username"
          onChange={(e) => setUsername(e.target.value)}
          required
        />
      </Form.Group>

      <Form.Group className="mb-3">
        <Form.Label>First Name</Form.Label>
        <Form.Control
          type="text"
          placeholder="First Name"
          onChange={(e) => setFirstname(e.target.value)}
          required
        />
      </Form.Group>

      <Form.Group className="mb-3">
        <Form.Label>Last Name</Form.Label>
        <Form.Control
          type="text"
          placeholder="Last Name"
          onChange={(e) => setLastname(e.target.value)}
          required
        />
      </Form.Group>

      <Form.Group className="mb-3" controlId="formBasicEmail">
        <Form.Label>Email</Form.Label>
        <Form.Control
          type="email"
          placeholder="Email"
          onChange={(e) => setEmail(e.target.value)}
          equired
        />
      </Form.Group>

      <Form.Group className="mb-3" controlId="formBasicPassword">
        <Form.Label>Password</Form.Label>
        <Form.Control
          type="password"
          placeholder="Password"
          onChange={(e) => setPassword(e.target.value)}
          required
        />
      </Form.Group>

      <div className="mt-4">
        <Button variant="primary" type="submit">
          Submit
        </Button>
      </div>
      <div className="mt-3">
        Already registered?{" "}
        <Link to={`/login`}>Login to your account here.</Link>
      </div>
    </Form>
  )
}

export default Register;
