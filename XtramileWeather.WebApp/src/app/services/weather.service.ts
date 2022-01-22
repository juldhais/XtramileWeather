import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { lastValueFrom } from 'rxjs';
import { WeatherResource } from '../resources/weather.resource';

@Injectable({
  providedIn: 'root'
})
export class WeatherService {
  baseUrl = "/weather";

  constructor(private http: HttpClient) { }

  async get(city: string) {
    return lastValueFrom(await this.http.get<WeatherResource>(this.baseUrl + `?city=${city}`));
  }
}
