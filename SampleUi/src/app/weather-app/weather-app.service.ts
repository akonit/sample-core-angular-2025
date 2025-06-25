import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

const WeatherHost = 'https://localhost:6457/weather-api';

export interface IWeatherForecast {
  date: Date;
  temperature: number;
  temperatureUnit: TemperatureUnit;
  summary?: string;
}

export enum TemperatureUnit {
  celsius = 0,
  fahrenheit = 1,
}

@Injectable({ providedIn: 'root' })
export class WeatherService {
  constructor(private http: HttpClient) {}

  public getForecasts(): Observable<IWeatherForecast[]> {
    return this.http.get<IWeatherForecast[]>(`${WeatherHost}/weatherforecast`);
  }

  public useCelsius(): Observable<object> {
    const params = new HttpParams().set('temperatureUnit', TemperatureUnit.celsius);
    return this.http.post(`${WeatherHost}/weatherforecast/temperatureUnit`, null, { params });
  }

  public useFahrenheit(): Observable<object> {
    const params = new HttpParams().set('temperatureUnit', TemperatureUnit.fahrenheit);
    return this.http.post(`${WeatherHost}/weatherforecast/temperatureUnit`, null, { params });
  }
}
