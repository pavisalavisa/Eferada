import React from "react";
import { BrowserRouter, Route, Switch } from "react-router-dom";
import Login from "./Login";
import Grades from "./Grades";
import Confirmation from "./Confirmation";
import Menu from "./Menu";
import Contacts from "./Contacts";
import Exam from "./Exam";
import App from "./App";

class RouterMain extends React.Component {
  render() {
    return (
      <div
        style={{
          backgroundColor: "silver",
          height: "100vh",
          fontFamily: "Lucida Sans"
        }}
      >
        <BrowserRouter>
          <div
            style={{
              backgroundColor: "#d9d9d9",
              maxWidth: 1200,
              margin: "0 auto",
              height: "1000px"
            }}
          >
            <Menu />
            <Switch>
              <div>
                <Route exact path="/" component={Login} />
                <Route path="/home" component={App} />
                <Route path="/potvrda" component={Confirmation} />
                <Route path="/prijava-ispita" component={Exam} />
                <Route path="/pregled-ocjena" component={Grades} />
                <Route path="/pregled-kolegija" component={Contacts} />
              </div>
            </Switch>
          </div>
        </BrowserRouter>
      </div>
    );
  }
}
export default RouterMain;
