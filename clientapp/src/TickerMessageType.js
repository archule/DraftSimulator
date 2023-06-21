import React from 'react';
import './Ticker.css';

const TickerMessageType = ({ currentMessageType }) => {


    return (

        <div className="ticker-message-type">{currentMessageType}</div>
    );
};

export default TickerMessageType;

