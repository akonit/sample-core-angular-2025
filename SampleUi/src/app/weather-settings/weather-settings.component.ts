import { Component } from '@angular/core';
import { WeatherService } from '../weather-app/weather-app.service';
import { take } from 'rxjs';

@Component({
  selector: 'app-weather-settings',
  imports: [],
  templateUrl: './weather-settings.component.html',
  styleUrl: './weather-settings.component.css'
})
export class WeatherSettingsComponent {
  constructor(private readonly service: WeatherService) {
  }

  public useCelsius() {
    this.service.useCelsius().pipe(take(1)).subscribe(() => alert("Switched to Celsius"));
  }

  public useFahrenheit() {
    this.service.useFahrenheit().pipe(take(1)).subscribe(() => alert("Switched to Fahrenheit"));
  }
}
