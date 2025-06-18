import { Component, DestroyRef, OnInit, resource, signal } from '@angular/core';
import { WeatherService } from './weather-app.service';
import { firstValueFrom, timer } from 'rxjs';
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
  public lastUpdateDate = signal<Date | undefined>(undefined);

  public forecastsResource = resource({
    params: () => this.timerValue(),
    loader: async () => {
      this.lastUpdateDate.set(new Date());
      return await firstValueFrom(this.service.getForecasts());
    },
  });

  private timerValue = signal(0);

  constructor(private readonly service: WeatherService, private readonly destroyRef: DestroyRef) {
  }

  public ngOnInit(): void {
    timer(0, 15 * 1000).pipe(
      takeUntilDestroyed(this.destroyRef)).subscribe((x) => this.timerValue.update(current => current + 1));
  }
}
