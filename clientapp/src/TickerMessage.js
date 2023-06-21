import React from 'react';
import './Ticker.css';

const TickerMessage = ({message}) => {
    

    return (

            <div className="ticker-message">
                {message}
            </div>
    );
};

export default TickerMessage;
