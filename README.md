# weather-forecast-assignment
## Run
```
docker build -t weatherassignment:latest .
```
```
docker run -p 80:8080 --name weather-api weatherassignment:latest
```
Open Swagger
```
http://localhost/
```
Open Hangfire
```
http://localhost/hangfire
```
## Summary
### Requirements
- Build a simple RESTful API backed by any kind of database.
- It should store weather forecasts based on provided geographic location (latitude and longitude).
- It should allow you to
	- Add a new forecast location;
	- Delete an existing forecast location;
	- List all locations;
	- Get the latest weather forecast for a given location.
- It should operate using JSON for both input and output.
- The solution should include base specs/tests coverage.
- The solution should provide a quick and easy way to get the system up and running.
- The solution should be robust and handle unexpected issues well.

### Suggestions
- You can use https://open-meteo.com to get a weather forecast.
- You can use IPStack API for the geolocation of IP addresses and URLs.

### Assumptions

#### Weather Forecast

For the purpose of the assignment, a weather forecast will include temperature, precipitation probability, and surface pressure. Its duration will be equal to three days and the data will be provided in hourly intervals.

#### Geographic Location

For the purpose of the assignment, a geographic location will consist of a latitude and longitude. The values will be rounded up to two decimal places, resulting in a precision of approximately 1.1 kilometers.
