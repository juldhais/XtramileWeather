import { Component } from '@angular/core';
import { CountryResource } from './resources/country.resource';
import { CountryService } from './services/country.service'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Xtramile Weather';
  countries: CountryResource[] | undefined = [];
  selectedCountry = new CountryResource();

  constructor(private countryService: CountryService) { }

  async ngOnInit() {
    this.countries = await this.countryService.getAll();
  }
}
