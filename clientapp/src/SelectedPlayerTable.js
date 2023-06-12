import React, { Component } from 'react';
import players from './data/playerData.js';
import PlayerRow from './PlayerRow.js';
import SelectedPlayerRow from './SelectedPlayerRow.js';



export default class SelectedPlayerTable extends Component {
    
    render() {
        console.log("SelectedPlayerTable rendered. " + this.props.player.name);
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
                        <SelectedPlayerRow key={this.props.player.id} player={this.props.player} />
                </tbody>
            </table>
        )
    }
}
