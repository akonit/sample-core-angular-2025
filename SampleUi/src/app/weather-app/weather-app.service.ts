import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from 'rxjs';

export interface IWeatherForecast
{
    date: Date,
    temperatureC: number,
    temperatureF: number,
    summary?: string
}

@Injectable({providedIn: 'root'})
export class WeatherService {
    constructor(private http: HttpClient) {

    }

    public getForecasts() : Observable<IWeatherForecast[]> {
        return this.http.get<IWeatherForecast[]>('http://localhost:5285/weatherforecast');
    }
}