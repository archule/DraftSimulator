import React, { Component } from 'react';
import players from './data/playerData.js';
import PlayerRow from './PlayerRow.js';



export default class PlayerTable extends Component {
    render() {
        console.log("PlayerTable rendered. ");
        return (
            <table>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Age</th>
                        {/* Add more table headers as needed */}
                    </tr>
                </thead>
                <tbody>
                    {players.map((player) => (
                        <PlayerRow key={player.id} player={player} updatePlayer={this.props.callBack}  />
                    ))}
                </tbody>
            </table>
        )
    }
}
