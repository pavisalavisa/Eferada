import React from "react";

class App extends React.Component {
  render() {
    return (
      <div
        style={{
          display: "flex",
          justifyContent: "center",
          alignItems: "center",
          flexDirection: "row",
          flexWrap: "wrap"
        }}
      >
        <section
          style={{
            maxWidth: 600,
            fontSize: "1.1em",
            marginTop: 50,
            backgroundColor: "#eaeaea",
            padding: 10
          }}
        >
          <h3>Dodatni ispitni rok u srpnju</h3>
          <h4>
            Napisao:Ante Antić
            <br />
            Srijeda, 13 Lipanj 2018
          </h4>
          <p>
            Poštovane kolegice i kolege, na sjednici Fakultetskog vijeća
            održanoj u srijedu 13. lipnja 2018., na zamolbu Studentskog zbora
            FESB-a, odobren je dodatni ispitni rok za studente preddiplomskih
            sveučilišnih, preddiplomskih stručnih i diplomskih sveučilišnih
            studija kojima je do trenutka prijave na ovaj rok ostao jedan ispit
            iz zimskog semestra, kao jedini nepoloženi kolegij, a uvjet je za
            obranu završnog ili diplomskog rada. Termini održavanja ispita, koji
            će biti naknadno objavljeni, su u tjednu pauze između prvog i trećeg
            tjedna ljetnog ispitnog roka, tj. od 09. srpnja do 13. srpnja 2018.
            Ispit je potrebno prijaviti putem tiskanih prijavnica (može ih se
            nabaviti u kopirnici) na šalteru Studentske službe do petka 06.
            srpnja 2018. do 12 sati. Lijep pozdrav,
            <br />
            <br />
            Ante Antić
          </p>
        </section>
        <section
          style={{
            maxWidth: 600,
            fontSize: "1.1em",
            marginTop: 50,
            backgroundColor: "#eaeaea",
            padding: 10
          }}
        >
          <h3>Dodatni ispitni rok u srpnju</h3>
          <h4>
            Napisao:Ante Antić
            <br />
            Srijeda, 13 Lipanj 2018
          </h4>
          <p>
            Poštovane kolegice i kolege, u privitku možete pronaći Odluku dekana
            s rang listom studenata kojima se sufinancira boravak u inozemstvu
            radi odrađivanja dijela nastavnih obaveza u okviru Erasmus+
            mobilnosti, za ak. godinu 2018./2019. Lijep pozdrav
            <br />
            <br />
            Ante Antić
          </p>
        </section>
      </div>
    );
  }
}

export default App;
