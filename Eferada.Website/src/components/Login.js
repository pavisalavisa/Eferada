import React from "react";
import { withRouter } from "react-router-dom";

class Login extends React.Component {
  state = { name: "", password: "" };
  handleChange = event => {
    this.setState({ [event.target.name]: event.target.value });
  };

  handleSubmit = () => this.props.history.push("/home");
  render() {
    return (
      <div
        style={{
          display: "block",
          height: "100%",
          left: 0,
          position: "fixed",
          top: 0,
          width: "100%",
          backgroundColor: "rgba(192,192,192, 1)"
        }}
      >
        <form
          style={{
            display: "flex",
            justifyContent: "center",
            alignItems: "center",
            flexWrap: "wrap",
            flexDirection: "row",
            width: 250,
            alignSelf: "center",
            border: "none"
          }}
          onSubmit={this.handleSubmit}
        >
          <br />
          <input
            style={formStyle}
            name="name"
            type="text"
            value={this.state.value}
            onChange={this.handelChange}
            placeholder="Korisnicko Ime"
          />
          <br />
          <br />
          <input
            style={formStyle}
            name="password"
            type="password"
            value={this.state.password}
            onChange={this.handleChange}
            placeholder="Lozinka"
          />
          <br />
          <button
            style={{
              padding: "15px 30px",
              backgroundColor: "#03A6AE",
              border: "none",
              borderRadius: 5,
              margin: "5px"
            }}
            onSubmit={this.handleSubmit}
          >
            Submit
          </button>
        </form>
      </div>
    );
  }
}

const formStyle = {
  textAlign: "left",
  borderRadius: 5,
  margin: "15px 0",
  padding: "20px 80px 20px 15px ",
  textAlign: "left",
  border: "none",
  fontSize: "1.2m"
};

export default withRouter(Login);

/*
margin: 0,
            position: "absolute",
            top: "50%",
            left: "50%",
            transform: "translate(-50%, -50%)"
            */
