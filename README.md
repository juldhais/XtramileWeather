# XtramileWeather

Xtramile Solutions Weather Application

Demo (Proof of Work): https://xtramileweather.azurewebsites.net/

## Run/Debug
1) Open solution in Visual Studio (I am using VS 2022)
2) Hit F5

## Notes
- The temperature data provided by https://openweathermap.org/ is in Kelvin, then the conversion logic is changed to: Kelvin -> Celcius, Kelvin -> Fahrenheit.

- Front-end application (XtramileWeather.WebApp) is created using Angular 13. Build output copied to wwwroot folder in XtramileWeather.WebApi project.