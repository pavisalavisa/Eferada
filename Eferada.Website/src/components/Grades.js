import React from "react";

class Grades extends React.Component {
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
            marginTop: 20,
            backgroundColor: "#eaeaea",
            padding: "80px 160px"
          }}
        >
          <h3>Pregled ocjena</h3>
          <h2>2016/2017</h2>
          <table>
            <thead>
              <tr>
                <th>Ime kolegija</th>
                <th>Ocjena</th>
              </tr>
            </thead>
            <tbody>
              <tr>
                <td>Elektronika</td>
                <td>
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{" "}
                  {Math.floor(Math.random() * 4 + 2)}
                </td>
              </tr>
              <tr>
                <td>Elektrotehnika</td>
                <td>
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{" "}
                  {Math.floor(Math.random() * 4 + 2)}
                </td>
              </tr>
              <tr>
                <td>Mreže</td>
                <td>
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{" "}
                  {Math.floor(Math.random() * 4 + 2)}
                </td>
              </tr>
            </tbody>
          </table>

          <h2>2017/2018</h2>
          <table>
            <thead>
              <tr>
                <th>Ime kolegija</th>
                <th>Ocjena</th>
              </tr>
            </thead>
            <tbody>
              <tr>
                <td>Praktikum</td>
                <td>
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{" "}
                  {Math.floor(Math.random() * 4 + 2)}
                </td>
              </tr>
              <tr>
                <td>Baze</td>
                <td>
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{" "}
                  {Math.floor(Math.random() * 4 + 2)}
                </td>
              </tr>
              <tr>
                <td>Statistika</td>
                <td>
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{" "}
                  {Math.floor(Math.random() * 4 + 2)}
                </td>
              </tr>
            </tbody>
          </table>

          <h2>2018/2019</h2>
          <table>
            <thead>
              <tr>
                <th>Ime kolegija</th>
                <th>Ocjena</th>
              </tr>
            </thead>
            <tbody>
              <tr>
                <td>Fizika</td>
                <td>nije upisana</td>
              </tr>
              <tr>
                <td>Algoritmi</td>
                <td>nije upisana</td>
              </tr>
              <tr>
                <td>Matematika I</td>
                <td>nije upisana</td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>
    );
  }
}

export default Grades;
