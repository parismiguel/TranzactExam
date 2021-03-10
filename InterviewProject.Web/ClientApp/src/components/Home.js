import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <h1>TRANZACT Exam</h1>
        <p>The following highlighted changes were implemented</p>
        <ul>
          <li>42,012 vulnerabilities fixed</li>
          <li>NET Core 5 upgrade</li>
          <li>Service Project</li>
          <li>Dependency Injection</li>
          <li>Http Resilency</li>
          <li>Circuit Breaker</li>
          <li>Toast Notifications</li>
        </ul>
      </div>
    );
  }
}
