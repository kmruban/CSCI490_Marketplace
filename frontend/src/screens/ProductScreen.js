import React, { useEffect, useReducer } from "react";
import axios from "axios";
import { useParams } from "react-router-dom";
import Col from "react-bootstrap/Col";
import Row from "react-bootstrap/Row";
import ListGroup from "react-bootstrap/ListGroup";
import Button from "react-bootstrap/Button";

const reducer = (state, action) => {
  switch (action.type) {
    case "FETCH_REQUEST":
      return { ...state, loading: true };
    case "FETCH_SUCCESS":
      return { ...state, product: action.payload, loading: false };
    case "FETCH_FAIL":
      return { ...state, loading: false, error: action.payload };
    default:
      return state;
  }
};

function ProductScreen() {
  const params = useParams();
  const { itemID } = params;

  const [{ loading, error, product }, dispatch] = useReducer(reducer, {
    product: [],
    loading: true,
    error: "",
  });

  useEffect(() => {
    const fetchData = async () => {
      dispatch({ type: "FETCH_REQUEST" });
      try {
        const result = await axios.get(
          `https://localhost:5001/Product/${itemID}/itemid`
        );
        console.log(result);
        console.log(result.name);
        console.log(itemID);
        dispatch({ type: "FETCH_SUCCESS", payload: result.data });
      } catch (err) {
        dispatch({ type: "FETCH_FAIL", payload: err.message });
      }
    };
    fetchData();
  }, [itemID]);

  return (
    <div className="product-screen">
      <Row>
        <Col className="img">
          <img
            className="product-image"
            src={`/pictures/${product.image}`}
          ></img>
        </Col>
        <Col className="product-details mt-3">
          <ListGroup variant="flush">
            <ListGroup.Item>
              <h3>{product.name}</h3>
            </ListGroup.Item>
            <Col className="mt-3">Price: ${product.price}</Col>
            <Col>Quantity: {product.quantity}</Col>
            {product.quantity > 0 ? (
              <div className="d-grid mt-3">
                <Button variant="primary">Add to Cart</Button>
              </div>
            ) : (
              <div className="d-grid mt-3">
                <Button variant="danger">Not In Stock</Button>
              </div>
            )}
          </ListGroup>
        </Col>
      </Row>
    </div>
  );
}

export default ProductScreen;
