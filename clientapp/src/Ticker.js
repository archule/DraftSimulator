import React, { useEffect, useState } from 'react';
import './Ticker.css';
import TickerMessage from './TickerMessage.js';
import TickerMessageType from './TickerMessageType';

const Ticker = ({ messageTypes }) => {
    const [currentMessageTypeIndex, setCurrentMessageTypeIndex] = useState(0);
    const [currentMessageIndex, setCurrentMessageIndex] = useState(0);
    const [isAnimating, setIsAnimating] = useState(false);

    useEffect(() => {
        const messageType = messageTypes[currentMessageTypeIndex];
        const messageCount = messageType.messages.length;

        const messageTimer = setTimeout(() => {
            console.log("yolo")
            setIsAnimating(true);

            const animationTimer = setTimeout(() => {
                console.log("yo")
                setIsAnimating(false);

                if (currentMessageIndex === messageCount - 1) {
                    console.log("mo")
                    if (currentMessageTypeIndex === messageTypes.length - 1) {
                        console.log("bo")
                        setCurrentMessageTypeIndex(0);
                        setCurrentMessageIndex(0);
                    } else {
                        console.log("cho")
                        setCurrentMessageTypeIndex(currentMessageTypeIndex + 1);
                        setCurrentMessageIndex(0);
                    }
                } else {
                    console.log("o")
                    setCurrentMessageIndex(currentMessageIndex + 1);
                }
            }, 1000);

            return () => clearTimeout(animationTimer);
        }, 2000); // Change the delay to 3000ms (3 seconds)

        return () => clearTimeout(messageTimer);
    }, [currentMessageTypeIndex, currentMessageIndex, messageTypes]);

    const currentMessageType = messageTypes[currentMessageTypeIndex];
    const currentMessage = currentMessageType.messages[currentMessageIndex];

    return (
        <div className="ticker-container">
            <TickerMessageType currentMessageType={currentMessageType.type} />
            <TickerMessage message={currentMessage} />
        </div>
    );
};

export default Ticker;

