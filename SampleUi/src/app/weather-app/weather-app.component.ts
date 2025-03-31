import { Component, OnInit, signal } from '@angular/core';
import { IWeatherForecast, WeatherService } from './weather-app.service';
import { take } from 'rxjs';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-weather-app',
  imports: [CommonModule],
  templateUrl: './weather-app.component.html',
  styleUrl: './weather-app.component.css'
})
export class WeatherAppComponent implements OnInit {
  public forecasts = signal<IWeatherForecast[] | undefined>(undefined);

  constructor(private readonly service: WeatherService) {
  }

  ngOnInit(): void {
    this.service.getForecasts().pipe(take(1)).subscribe((x) => this.forecasts.set(x));
  }
}
