import { Component, DestroyRef, effect, OnInit, signal } from '@angular/core';
import { IWeatherForecast, TemperatureUnit, WeatherService } from './weather-app.service';
import { retry, switchMap, timer } from 'rxjs';
import { CommonModule, DatePipe } from '@angular/common';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { TemperaturePipe } from '../pipes/temperature.pipe';

@Component({
  selector: 'app-weather-app',
  imports: [CommonModule, DatePipe, TemperaturePipe],
  templateUrl: './weather-app.component.html',
  styleUrl: './weather-app.component.css'
})
export class WeatherAppComponent implements OnInit {
  public forecasts = signal<IWeatherForecast[] | undefined>(undefined);
  public lastUpdateDate = signal<Date | undefined>(undefined);

  public isLoading = signal(true);

  constructor(private readonly service: WeatherService, private readonly destroyRef: DestroyRef) {
      effect(() => {
          this.forecasts();
          this.lastUpdateDate.set(new Date());
      });
  }

  public ngOnInit(): void {
    timer(0, 15 * 1000).pipe(
      takeUntilDestroyed(this.destroyRef), 
      switchMap(() => this.service.getForecasts()),
      retry()).subscribe((x) =>
        {
          this.forecasts.set(x);
          this.isLoading.set(false);
        });
  }
}
