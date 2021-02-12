import React, { Component } from 'react';
import { Route } from 'react-router';
import { Container } from 'reactstrap';
import Sections from '../sections';
import TopSections from '../topsections';
import TopUsers from '../topusers';

export default class App extends Component {
  render() {
    return (
      <Container>
        <Route exact path='/' component={Sections} />
        <Route path='/topsections' component={TopSections} />
        <Route path='/topusers' component={TopUsers} />
      </Container>
    );
  }
}