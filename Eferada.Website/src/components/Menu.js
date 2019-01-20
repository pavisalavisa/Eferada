import React from "react";
import "./style.css";
import { Link } from "react-router-dom";

const link = {
  textDecoration: "none",
  textAlign: "center",
  color: "black",
  padding: 5
};

class Menu extends React.Component {
  render() {
    return (
      <React.Fragment>
        <header
          style={{
            backgroundColor: "lightseagreen",
            color: "black",
            display: "flex",
            justifyContent: "space-between",
            alignItems: "center",
            padding: "0.5em",
            top: 0,
            height: 60
          }}
        >
          <div>
            <img
              src={require("../assets/logo.png")}
              style={{
                width: 50,
                height: 50,
                display: "inline-block",
                marginBottom: "-15px"
              }}
            />
            <a
              style={{
                fontSize: "2em",
                display: "inline-block",
                margin: 10,
                textDecoration: "none",
                color: "rgba(0,0,0,0.95)"
              }}
            >
              EFERADA
            </a>
          </div>
          <Link to="/">
            <button style={{ color: "black", padding: "5px 10px" }}>
              Odjava
            </button>
          </Link>
        </header>
        <nav
          style={{
            float: "left",
            display: "grid",
            rowGap: "0.2em",
            width: "200px",
            height: "500px",
            backgroundColor: "silver"
          }}
        >
          <section className="izbor">
            <Link style={link} to="/home">
              POCETNA
            </Link>
          </section>
          <section className="izbor">
            <Link style={link} to="/potvrda">
              POTVRDA
            </Link>
          </section>
          <section className="izbor">
            <Link style={link} to="/prijava-ispita">
              PRIJAVA ISPITA
            </Link>
          </section>
          <section className="izbor">
            <Link style={link} to="/pregled-ocjena">
              PREGLED OCJENA
            </Link>
          </section>
          <section className="izbor">
            <Link style={link} to="/pregled-kolegija">
              KONTAKT
            </Link>
          </section>
        </nav>
      </React.Fragment>
    );
  }
}

export default Menu;
