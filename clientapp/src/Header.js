import React, { Component } from 'react';
import './css/Header.css';

export default class Header extends Component {
    render() {
        return (
            <header>
                <div className="leftIcon">
                    <i className="fa fa-bars"></i>
                </div>
                <h1><span title="National Football League">NFL</span> Draft Simulator</h1>
                <div className="rightIcon">
                    <i className="fas fa-user"></i>
                </div>      
            </header>
        );
    }
}


