import "./App.scss";
import { BrowserRouter, Link, Route, Routes } from "react-router-dom";
import { toast, ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import Container from "react-bootstrap/Container";

import Topbar from "./components//navbar/Topbar";
import Login from "./screens/Login";
import Register from "./screens/Register";
import Home from "./screens/Home";
import Account from "./screens/Account";
import ProductScreen from "./screens/ProductScreen";


function App() {
  return (
    <BrowserRouter>
      <div className="app">
      <ToastContainer position="top-center" limit={1} />
        <header>
          <Topbar />
        </header>
        <main>
          <Container className="mt-4">
            <Routes>
              <Route path="/" element={<Home />} />
              <Route path="/login" element={<Login />} />
              <Route path="/register" element={<Register />} />
              <Route path="/account" element={<Account />} />
              <Route path="/Product/:itemID" element={<ProductScreen />} />
            </Routes>
          </Container>
        </main>
      </div>
    </BrowserRouter>
  );
}

export default App;
