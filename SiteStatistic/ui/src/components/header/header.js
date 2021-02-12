import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import {
  Container,
  Navbar,
  Nav,
  NavbarBrand,
  NavItem,
  NavLink
} from 'reactstrap';

export default class Header extends Component {
  render() {
    return (
      <header>
        <Navbar>
          <Container>
            <NavbarBrand tag={Link} to="/">Main page</NavbarBrand>
            <Nav className="ml-auto">
              <NavItem>
                <NavLink tag={Link} className="text-dark" to="/">All sections</NavLink>
              </NavItem>
              <NavItem>
                <NavLink tag={Link} className="text-dark" to="/topsections">The most visited sections</NavLink>
              </NavItem>
              <NavItem>
                <NavLink tag={Link} className="text-dark" to="/topusers">The most active users</NavLink>
              </NavItem>
            </Nav>
          </Container>
        </Navbar>
      </header>
    );
  }
}