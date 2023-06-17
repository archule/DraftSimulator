import React, { useEffect, useRef } from 'react';
import * as signalR from '@microsoft/signalr';

const SignalRComponent = () => {
    const hubConnectionRef = useRef(null);

    useEffect(() => {
        // Create a new SignalR hub connection
        const hubConnection = new signalR.HubConnectionBuilder()
            .withUrl('http://localhost:5000/chatHub')
            .configureLogging(signalR.LogLevel.Information)
            .build();

        // Store the hub connection in the ref
        hubConnectionRef.current = hubConnection;

        // Start the hub connection
        hubConnection.start().catch(console.error);

        // Clean up the connection when the component is unmounted
        return () => {
            hubConnectionRef.current.stop().catch(console.error);
        };
    }, []);

    const handleButtonClick = async () => {
        const hubConnection = hubConnectionRef.current;
        if (hubConnection && hubConnection.state === signalR.HubConnectionState.Connected) {
            try {
                const message = {
                    From: "a team",//connID.innerHTML.substring(8),
                    To: "",//recipients.value,
                    Message: 'Hello, SignalR!'
                };
                const jsonString = JSON.stringify(message);

                await hubConnection.invoke('SendMessageAsync', jsonString);
                console.log(`Message sent: ${jsonString}`);
            } catch (error) {
                console.error(error);
            }
        }
    };


    return (
        <div>
            <button onClick={handleButtonClick}>Send Message</button>
        </div>
    );
};

export default SignalRComponent;
