import React from "react";
import Card from "react-bootstrap/Card";
import { Link } from "react-router-dom";
import Button from "react-bootstrap/Button";
import Badge from "react-bootstrap/Badge";

function Product(props) {
  const { product } = props;

  return (
    <>
      <Link to={`/Product/${product.itemID}`}>
        <img
          src={`/pictures/${product.image}`}
          className="card-img-top"
          alt={product.name}
        />
      </Link>
      <Card.Body>
        <Link to={`/Product/${product.itemID}`}>
          <Card.Title>{product.name}</Card.Title>
        </Link>
        {product.quantity === 0 ? (
          <Card.Text style={{ fontSize: "18px" }}>
            ${product.price} <Badge bg="danger">Out of stock</Badge>
          </Card.Text>
        ) : (
          <Card.Text style={{ fontSize: "18px" }}>
            ${product.price}{" "}
            <Badge bg="success">{product.quantity} available</Badge>
          </Card.Text>
        )}
      </Card.Body>
    </>
  );
}

export default Product;
