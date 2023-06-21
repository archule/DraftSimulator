import React from 'react';
import './css/currentTeam.css'
function CurrentTeam() {


    return (

        <React.Fragment>
        <div className="container">
            <div className="teamContainer">
        <img className="team" src="https://static.www.nfl.com/league/api/clubs/logos/DEN.svg" alt="TeamPicture" />
                    <p>Denver Broncos</p>
                
                </div>
                <div className="teamInfo">
                <p> On the Clock</p>
                </div>
            </div>
        </React.Fragment>
          
    );
}

export default CurrentTeam;