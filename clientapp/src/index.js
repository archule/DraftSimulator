import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import CurrentTeam from './CurrentTeam.js'

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <React.StrictMode>
        <div>

            <div class="header">Header</div>
            <img src="http://localhost:5000/Images/3.jpg" alt="player" />
            <section className="teamsContainer">
               
                <CurrentTeam />
                <CurrentTeam />
                <CurrentTeam />
                <CurrentTeam />
                <CurrentTeam />
                <CurrentTeam />
                <CurrentTeam />
                <CurrentTeam />
                <CurrentTeam />
                <CurrentTeam />
                <CurrentTeam />
                <CurrentTeam />
                <CurrentTeam />
                <CurrentTeam />
                <CurrentTeam />
                <CurrentTeam />
                <CurrentTeam />
                <CurrentTeam />
                <CurrentTeam />
            </section>
            <div class="container">
                <div class="row1">
                    <div class="box"></div>
                    <div class="box"></div>
                    <div class="box"></div>
                    <div class="box"></div>
                    <div class="box"></div>
                    <div class="box"></div>
                    <div class="box"></div>
                </div>
                <div class="row2">
                    <div class="box thin"></div>
                    <div class="box thick"></div>
                </div>
                <div class="row3">
                    <div class="box"></div>
                    <div class="box"></div>
                </div>
            </div>
        </div>



  </React.StrictMode>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
