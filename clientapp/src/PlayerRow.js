import React, { Component } from 'react';


export default class PlayerRow extends Component {

    constructor(props) {
        super(props);
        this.state = {
            objectKeys: Object.keys(props.player)
        }
        
    }

    render() {
        console.log("PlayerRow rendered. ")
        return (
            <tr onClick={() => this.props.updatePlayer(this.props.player)}>
                {this.state.objectKeys.map((key) => (
                    <td key={key}>{this.props.player[key]}</td>
                ))}
            </tr>
        )
    }
}
