CREATE TABLE WeatherUser (
    name VARCHAR(255),
    UserId INT PRIMARY KEY,
    Email VARCHAR(255),
    Password VARCHAR(255)
);

INSERT INTO WeatherUser (name, UserId, Email, Password) VALUES 
('Sethu', 1001, 'Sethu@email.com', 'qwerty'),
('Sethupathi Paneerselvam', 1002, 'mailtosethupathi@gmail.com', 'password'),
('MS Dhoni', 1003, 'msd@gmail.com', 'password');

select * from weatheruser