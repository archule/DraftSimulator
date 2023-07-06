import React, { useState, useEffect } from 'react';

const Clock = ({ seconds }) => {
    const [time, setTime] = useState(seconds);

    useEffect(() => {
        if (time > 0) {
            const timer = setTimeout(() => setTime(time - 1), 1000);
            return () => clearTimeout(timer);
        }
    }, [time]);

    const formatTime = (time) => {
        const minutes = Math.floor(time / 60);
        const seconds = time % 60;
        return `${minutes.toString().padStart(2, '0')}:${seconds.toString().padStart(2, '0')}`;
    };

    return (
        <div>
            <h1>Countdown Timer</h1>
            <p>{formatTime(time)}</p>
        </div>
    );
};

export default Clock;