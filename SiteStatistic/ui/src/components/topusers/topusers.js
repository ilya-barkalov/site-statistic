import React, { Component } from 'react';

export default class TopUsers extends Component {

  constructor(props) {
    super(props);

    this.state = {
      users: [],
      loading: true
    };
  }

  componentDidMount() {
    this.populateWeatherData();
  }

  async populateWeatherData() {
    const response = await fetch('/api/statistic/topusers');
    const data = await response.json();

    console.log(data);

    this.setState({
      users: data,
      loading: false
    });
  }

  static renderResult(users) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Name</th>
            <th>Number of visits</th>
            <th>SectionName</th>
          </tr>
        </thead>
        <tbody>
          {users.map(user =>
            <tr key={user.orderId}>
              <td>{user.orderId}</td>
              <td>{user.fullName}</td>
              <td>
                {
                  user.sections.join(' ')
                }
              </td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {

    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : TopUsers.renderResult(this.state.users);

    return (
      <div>
        {contents}
      </div>
    );
  }
}