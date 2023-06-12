import React, { Component } from 'react';
import players from './data/playerData.js';
import PlayerRow from './PlayerRow.js';
import PlayerTable from './PlayerTable.js';
import SelectedPlayerTable from './SelectedPlayerTable.js';




export default class Draft extends Component {

    constructor(props) {

        super(props);
        this.state = {
            player:     {
                id: 2,
                name: "John Doe",
                age: 25,
                position: "Forward",
                a: "USA",
                natifonality: "USA",
                natiofnality: "USA",
                nationgality: "USA",
                nationahlity: "USA",
                nationaljity: "USA",
                nationalhity: "USA",
                nationaglity: "USA",
                nationahlity: "USA",
                nationahlity: "USA",
                nationjality: "USA",
            }
        }

        this.updatePlayer = this.updatePlayer.bind(this);
    }

    updatePlayer(selectedPlayer) {
        this.setState({ player: selectedPlayer });
    }

    render() {
        console.log("Draft rendered. ");
        return (
            <React.Fragment>
                <PlayerTable callBack={this.updatePlayer} />
                <SelectedPlayerTable player={this.state.player} />
            </React.Fragment>
        )
    }

}
