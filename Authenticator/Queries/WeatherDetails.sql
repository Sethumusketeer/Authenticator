CREATE TABLE WeatherDetails (
    temperature INT,
    description VARCHAR(50),
    humidity INT,
    windSpeed INT,
    forecast VARCHAR(255)
);

INSERT INTO WeatherDetails (temperature, description, humidity, windSpeed, forecast) VALUES 
(31, 'Sunny', 80, 10, 'Rainy day expected tomorrow'),
(26, 'Cloudy', 75, 15, 'Cold night expected'),
(24, 'Foggy', 90, 5, 'Foggy morning tomorrow'),
(30, 'Hot', 60, 12, 'Chance of rainfall'),
(33, 'Sunny', 70, 8, 'Clear sky tomorrow'),
(29, 'Rainy', 85, 10, 'Cloudy day ahead'),
(26, 'Misty', 90, 5, 'Possible showers in the evening'),
(31, 'Hot', 55, 7, 'Hot day tomorrow'),
(29, 'Sunny', 60, 10, 'Clear sky expected tomorrow'),
(28, 'Cloudy', 80, 12, 'Possibility of a cloudy morning'),
(25, 'Rainy', 85, 15, 'Expect showers throughout the day'),
(30, 'Hot', 60, 15, 'Hot day tomorrow'),
(26, 'Sunny', 70, 12, 'Clear sky expected'),
(28, 'Cloudy', 80, 10, 'Cloudy day ahead'),
(24, 'Rainy', 90, 7, 'Rainfall expected tomorrow morning'),
(26, 'Foggy', 95, 5, 'Foggy morning expected tomorrow'),
(25, 'Sunny', 70, 10, 'Clear sky tomorrow'),
(18, 'Cold', 90, 5, 'Cold day with possible rain showers'),
(28, 'Hot', 60, 12, 'Hot day tomorrow'),
(22, 'Rainy', 85, 7, 'Expect showers in the evening'),
(33, 'Sunny', 70, 10, 'Clear sky expected tomorrow'),
(29, 'Cloudy', 75, 15, 'Cloudy day ahead'),
(31, 'Hot', 65, 10, 'Hot day expected tomorrow'),
(27, 'Misty', 90, 8, 'Misty morning tomorrow'),
(21, 'Rainy', 99, 5, 'Expect heavy showers throughout the day')


select * from WeatherDetails