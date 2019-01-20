import React from "react";

class Exam extends React.Component {
  state = {};

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
            marginTop: 50,
            backgroundColor: "#eaeaea",
            padding: "80px 160px"
          }}
        >
          <h2>Moguće je prijaviti ove ispite:</h2>
          <br />
          <br />
          <h3>Matematika I</h3>
          Vrijeme održavanja ispita: 23.2.2019.
          <br />
          Rok: zimski
          <br />
          Uvjeti za izlazak: nema
          <br />
          Želim pristupiti ispitu: <button>DA</button> <button>NE</button>
          <br />
          <br />
          <h3>Fizika</h3>
          Vrijeme održavanja ispita: 21.2.2019.
          <br />
          Rok: zimski
          <br />
          Uvjeti za izlazak: minimalno 20 bodova na kolokvijima
          <br />
          Želim pristupiti ispitu: <button>DA</button> <button>NE</button>
        </div>
      </div>
    );
  }
}

export default Exam;
