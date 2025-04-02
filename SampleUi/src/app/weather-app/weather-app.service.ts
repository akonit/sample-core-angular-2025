import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from 'rxjs';

export interface IWeatherForecast
{
    date: Date,
    temperature: number,
    temperatureUnit: TemperatureUnit,
    summary?: string
}

export enum TemperatureUnit {
    celsius = 0,
    fahrenheit = 1
}

@Injectable({providedIn: 'root'})
export class WeatherService {
    constructor(private http: HttpClient) {
    }

    public getForecasts() : Observable<IWeatherForecast[]> {
        return this.http.get<IWeatherForecast[]>('http://localhost:5285/weatherforecast');
    }

    public useCelsius() : Observable<Object> {
        const params = new HttpParams().set('temperatureUnit', TemperatureUnit.celsius);
        return this.http.post('http://localhost:5285/weatherforecast/temperatureUnit', null, {params});
    }

    public useFahrenheit() : Observable<Object> {
        const params = new HttpParams().set('temperatureUnit', TemperatureUnit.fahrenheit);
        return this.http.post('http://localhost:5285/weatherforecast/temperatureUnit', null, {params});
    }
}