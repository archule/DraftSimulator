import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import CurrentTeam from './CurrentTeam.js'
import Draft from './Draft.js'
import Clock from './Clock.js'
import Header from './Header.js';
import Ticker from './Ticker';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <React.StrictMode>
        <div>

            <Header />

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
            <Ticker messageTypes={[
            {
                type: 'Type 1',
            messages: ['Message 1', 'Message 2', 'Message 3']
    },
            {
                type: 'Type 2',
            messages: ['Message A', 'Message B', 'Message C']
    }
    // Add more message types and messages as needed
]} />
            <div className="tableContainer">
                <div className="good">
                    <Clock seconds={90} />
                </div>
                <Draft />
      
            </div>
        </div>



  </React.StrictMode>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
