import React, { Component } from 'react';

export default class TopSections extends Component {

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
    const response = await fetch('/api/statistic/topsections');
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
            <th>Number of visits</th>
          </tr>
        </thead>
        <tbody>
          {sections.map(section =>
            <tr key={section.name}>
              <td>{section.name}</td>
              <td>{section.numberOfVisits}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {

    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : TopSections.renderResult(this.state.sections);

    return (
      <div>
        {contents}
      </div>
    );
  }
}