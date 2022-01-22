import { Component } from '@angular/core';
import { CityResource } from './resources/city.resource';
import { CountryResource } from './resources/country.resource';
import { WeatherResource } from './resources/weather.resource';
import { CountryService } from './services/country.service'
import { WeatherService } from './services/weather.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Xtramile Weather';
  countries: CountryResource[] | undefined = [];
  cities: CityResource[] | undefined = [];
  selectedCountry = new CountryResource();
  selectedCity = new CityResource();
  weather = new WeatherResource();

  constructor(
    private countryService: CountryService, 
    private weatherService: WeatherService) { }

  async ngOnInit() {
    this.countries = await this.countryService.getAll();
  }

  async countryChange() {
    if (this.selectedCountry)
      this.cities = await this.countryService.getCities(this.selectedCountry.id);
  }

  async cityChange() {
    if (this.selectedCity)
      this.weather = await this.weatherService.get(this.selectedCity.name);
  }
}
