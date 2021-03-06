import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CountryResource } from '../resources/country.resource';
import { CityResource } from '../resources/city.resource';
import { lastValueFrom } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CountryService {
  baseUrl = "/countries";

  constructor(private http: HttpClient) { }

  async getAll() {
    return lastValueFrom(await this.http.get<CountryResource[]>(this.baseUrl));
  }

  async getCities(countryId: number) {
    return lastValueFrom(await this.http.get<CityResource[]>(`${this.baseUrl}/${countryId}/cities`));
  }
}
