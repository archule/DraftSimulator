import React, { Component } from 'react';


export default class PlayerRow extends Component {

    render() {
        console.log("PlayerRow rendered. ")
        return (
            <tr onClick={() => this.props.updatePlayer(this.props.player)}>
                {Object.keys(this.props.player).map((key) => (
                    <td key={key}>{this.props.player[key]}</td>
                ))}
            </tr>
        )
    }
}
