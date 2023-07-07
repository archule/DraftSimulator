import React, { Component } from 'react';

class LoginForm extends Component {
    constructor(props) {
        super(props);
        this.state = {
            username: '',
            password: ''
        };
    }

    handleSubmit = async (e) => {
        e.preventDefault();

        try {
            const { username,  password } = this.state;

            const data = {
                username,
                password
            };

            console.log({
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(data)
            }); 

            const response = await fetch('http://localhost:5000/api/User/login', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(data)
            });

            if (response.ok) {
                // Registration successful
                console.log('login successful');
            } else {
                // Registration failed
                console.error('login failed');
            }
        } catch (error) {
            console.error('login Error occurred:', error);
        }
    };

    handleChange = (e) => {
        this.setState({ [e.target.name]: e.target.value });
    };

    render() {
        return (
            <form onSubmit={this.handleSubmit}>
                <div>
                    <label>Username:</label>
                    <input
                        type="text"
                        name="username"
                        value={this.state.username}
                        onChange={this.handleChange}
                    />
                </div>
               
                <div>
                    <label>Password:</label>
                    <input
                        type="password"
                        name="password"
                        value={this.state.password}
                        onChange={this.handleChange}
                    />
                </div>
                <button type="submit">Login</button>
            </form>
        );
    }
}

export default LoginForm;