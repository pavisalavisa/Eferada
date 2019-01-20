import React from "react";

class Confirmation extends React.Component {
  render() {
    return (
      <div
        style={{
          display: "flex",
          justifyContent: "center",
          alignItems: "center"
        }}
      >
        <div
          style={{
            margin: 20,
            padding: 50,
            width: 400,
            border: "2px solid silver",
            backgroundColor: "#eaeaea"
          }}
        >
          <h3>
            Sveučilište u Splitu
            <br />
            Fakultet
            <br />
            Klasa:32.32/4
            <br />
            UR.BROJ:3232/2121/21
          </h3>
          <h4>
            Na temelju članka 159. Zakona o općem upravnom postupku, izdaje se
          </h4>
          <h5>
            &nbsp;&nbsp;&nbsp;<b>POTVRDNICA</b>
          </h5>
          <p>
            kojom se potvrđuje da student {}
            <br />
            matični broj 111-2014, rođen 1.1.1990.
            <br />
            prvi put upisuje treću godinu{} preddiplomskog sveučilišnog studija
            kao redovni student <br />
            Potvrda se izdaje na traženje studenta, a služi za
            <br />
            <input placeholder="Upisi svrhu" />
            <br />i u druge svrhe se ne može upotrijebiti
          </p>
        </div>
      </div>
    );
  }
}

export default Confirmation;
