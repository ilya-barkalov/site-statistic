import React, { Component } from 'react';

export default class Sections extends Component {

  constructor(props) {
    super(props);

    this.state = {
      sections: [],
      loading: true
    };
  }

  componentDidMount() {
    this.populateWeatherData();
  }

  async populateWeatherData() {
    const response = await fetch('/api/statistic/sections');
    const data = await response.json();

    this.setState({
      sections: data,
      loading: false
    });
  }

  static renderResult(sections) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Name</th>
          </tr>
        </thead>
        <tbody>
          {sections.map(section =>
            <tr key={section.name}>
              <td>{section.name}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {

    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : Sections.renderResult(this.state.sections);

    return (
      <div>
        {contents}
      </div>
    );
  }
}