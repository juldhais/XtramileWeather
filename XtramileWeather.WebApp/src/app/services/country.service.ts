import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CountryResource } from '../resources/country.resource';
import { CityResource } from '../resources/city.resource';
import { firstValueFrom, lastValueFrom } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CountryService {
  baseUrl = "https://localhost:44328/countries";

  constructor(private http: HttpClient) { }

  async getAll() {
    return lastValueFrom(await this.http.get<CountryResource[]>(this.baseUrl));
  }

  async getCities(countryId: number) {
    return await this.http.get<CityResource[]>(`${this.baseUrl}/${countryId}/cities`);
  }
}
