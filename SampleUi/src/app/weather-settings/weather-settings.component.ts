import { Component } from '@angular/core';
import { WeatherService } from '../weather-app/weather-app.service';
import { take } from 'rxjs';
import { MatSnackBar } from '@angular/material/snack-bar';
import { AuthService } from '@auth0/auth0-angular';
import { CommonModule } from '@angular/common';
import { MatButton } from '@angular/material/button';

@Component({
  selector: 'app-weather-settings',
  imports: [CommonModule, MatButton],
  templateUrl: './weather-settings.component.html',
  styleUrl: './weather-settings.component.css',
})
export class WeatherSettingsComponent {
  constructor(private readonly service: WeatherService, private readonly snackBar: MatSnackBar, public auth: AuthService) {}

  public useCelsius() {
    this.service
      .useCelsius()
      .pipe(take(1))
      .subscribe(() => this.snackBar.open('Switched to Celsius', 'Close', { duration: 3000, verticalPosition: 'top' }));
  }

  public useFahrenheit() {
    this.service
      .useFahrenheit()
      .pipe(take(1))
      .subscribe(() => this.snackBar.open('Switched to Fahrenheit', 'Close', { duration: 3000, verticalPosition: 'top' }));
  }
}
