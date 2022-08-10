import React, { useEffect, useReducer } from "react";
import Card from "react-bootstrap/Card";
import { Link } from "react-router-dom";
import axios from "axios";
import logger from "use-reducer-logger";

const reducer = (state, action) => {
  switch (action.type) {
    case "FETCH_REQUEST":
      return { ...state, loading: true };
    case "FETCH_SUCCESS":
      return { ...state, products: action.payload, loading: false };
    case "FETCH_FAIL":
      return { ...state, loading: false, error: action.payload };
    default:
      return state;
  }
};

function Home() {
  const [{ loading, error, products }, dispatch] = useReducer(logger(reducer), {
    products: [],
    loading: true,
    error: "",
  });

  useEffect(() => {
    const fetchData = async () => {
      dispatch({ type: "FETCH_REQUEST" });
      try {
        const result = await axios.get("https://localhost:5001/Product");
        dispatch({ type: "FETCH_SUCCESS", payload: result.data });
      } catch (err) {
        dispatch({ type: "FETCH_FAIL", payload: err.message });
      }
    };
    fetchData();
  }, []);

  return (
    <div>
      <h2 className="mb-3">Featured Products</h2>
      <div className="products">
        {products.map((product) => (
          <Card>
            <Link to="/product/1">
              <img
                src={`/pictures/${product.image}`}
                className="card-img-top"
                alt={product.name}
              />
            </Link>
            <Card.Body>
              <Link to={`/product/1`}>
                <Card.Title>{product.name}</Card.Title>
              </Link>
            </Card.Body>
          </Card>
        ))}
      </div>
    </div>
  );
}

export default Home;
