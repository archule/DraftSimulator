import React, { Component } from 'react';


export default class SelectedPlayerRow extends Component {

    constructor(props) {
        super(props);
        this.state = {
            objectKeys: Object.keys(props.player)
        }

    }

    render() {
        console.log("SelectedPlayerRow rendered. " + this.props.player.name)
        return (
            <tr>
                {this.state.objectKeys.map((key) => (
                    <td key={key}>{this.props.player[key]}</td>
                ))}
            </tr>
        )
    }
}