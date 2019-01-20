import React from "react";

class Contacts extends React.Component {
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
            marginTop: 20,
            textAlign: "center",
            backgroundColor: "#eaeaea",
            padding: "80px 160px"
          }}
        >
          <h1>Kontakt</h1>
          <h2>
            Telefon: <h3>098-9458-874</h3>
            <h3>091-857-875</h3>
          </h2>
          <h2>
            Mail:<h3>fakultet@eferada.com</h3>
          </h2>
          <h2>
            Broj Ureda:<h3>B202</h3>
          </h2>
        </div>
      </div>
    );
  }
}
export default Contacts;
