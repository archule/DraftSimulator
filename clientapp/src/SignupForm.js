import React, { useState } from 'react';
import axios from 'axios';

function SignupForm() {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');

    const handleSubmit = async (e) => {
        e.preventDefault();

        const data = {
            username: username,
            password: password
        };

        try {
            const response = await axios.post('http://localhost:5000/api/Account/signup/', data);
            console.log(response.data); // Handle successful signup
        } catch (error) {
            console.error(error.response.data); // Handle signup error
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <input
                type="text"
                placeholder="Username"
                value={username}
                onChange={(e) => setUsername(e.target.value)}
            />
            <input
                type="password"
                placeholder="Password"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
            />
            <button type="submit">Sign Up</button>
        </form>
    );
}

export default SignupForm;
