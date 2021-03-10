import React, { Component } from 'react';

import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';

export class NavMenu extends Component {
    static displayName = NavMenu.name;

    constructor(props) {
        super(props);

        this.toggleNavbar = this.toggleNavbar.bind(this);
        this.state = {
            collapsed: true
        };
    }

    toggleNavbar() {
        this.setState({
            collapsed: !this.state.collapsed
        });
    }

    render() {
        return (
            <header>


                <Navbar bg="primary" variant="dark">
                    <Navbar.Brand href="#home">Interview Project</Navbar.Brand>
                    <Navbar.Toggle onClick={this.toggleNavbar} aria-controls="responsive-navbar-nav" />
                    <Navbar.Collapse id="responsive-navbar-nav">
                        <Nav className="mr-auto">
                            <Nav.Link href="/">Home</Nav.Link>
                            <Nav.Link href="/weather">Weather</Nav.Link>
                        </Nav>
                    </Navbar.Collapse>
                </Navbar>

            </header>
        );
    }
}
