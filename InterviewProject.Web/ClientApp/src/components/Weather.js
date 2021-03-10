import React, { Component } from 'react';
import Card from 'react-bootstrap/Card';
import Button from 'react-bootstrap/Button';
import Table from 'react-bootstrap/Table';
import Form from 'react-bootstrap/Form';
import Spinner from 'react-bootstrap/Spinner';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

export class Weather extends Component {
    static displayName = Weather.name;

    constructor(props) {
        super(props);
        this.state = { init: true, location: '', forecasts: [], loading: false };
        this.searchWeather = this.searchWeather.bind(this);
    }

    searchWeather() {
        if (this.state.location.length < 3) {
            toast.info("Must enter at least 3 characters!");
            return;
        }

        this.setState({
            loading: true,
            init: false
        });

        this.populateWeatherData();
    }

    renderForecastsTable() {
        return (
            <div style={{ marginTop: 4 }}>

                <Table responsive striped bordered hover>
                    {this.state.loading || this.state.init ? null :
                        (<thead>
                            <tr>
                                <th>Date</th>
                                <th>Temp. (C)</th>
                                <th>Temp. (F)</th>
                                <th>Summary</th>
                            </tr>
                        </thead>) }
                    <tbody>
                        {this.state.forecasts.map(forecast =>
                            <tr key={forecast.date}>
                                <td>{forecast.date}</td>
                                <td>{forecast.temperatureC}</td>
                                <td>{forecast.temperatureF}</td>
                                <td><img className="weather-icon" src={forecast.icon} alt={forecast.summary} /><span>{forecast.summary}</span></td>
                            </tr>
                        )}
                    </tbody>
                </Table >
            </div>
        );
    }

    render() {
        let contents = this.state.loading
            ? null : this.renderForecastsTable();

        return (
            <div>
                <ToastContainer />
                <Card style={{ marginTop: 4 }}>
                    <Card.Header>Weather forecast</Card.Header>
                    <Card.Body>
                        <Card.Text>
                            Please enter the name of the location's weather you would like to know for the next 5 days...
                        </Card.Text>

                        <Form>
                            <Form.Group controlId="formLocationSearch">
                                <Form.Label>Location</Form.Label>
                                <Form.Control type="text" value={this.state.location}
                                    onChange={this.handleChange.bind(this)} placeholder="Enter Location..." />
                            </Form.Group>

                            <Button variant="primary" onClick={this.searchWeather} disabled={this.state.loading}>
                                {this.state.loading ?
                                    (<div><Spinner
                                        as="span"
                                        animation="border"
                                        size="sm"
                                        role="status"
                                        aria-hidden="true"
                                    />
                                        <span> Loading...</span></div>) : <span>Search</span>
                                }
                            </Button>
                        </Form>

                    </Card.Body>
                </Card>

                {contents}
            </div>
        );
    }

    async populateWeatherData() {
        const response = await fetch('weatherforecast/getWeatherForecast?location=' + this.state.location);
        const res = await response.json();
        this.setState({ forecasts: res, loading: false });

        toast.success("Weather loaded!");
    }

    handleChange(e) {
        this.setState({ location: e.target.value });
    }
}
