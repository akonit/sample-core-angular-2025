import { Component } from '@angular/core';
import { WeatherAppComponent } from './weather-app/weather-app.component';

@Component({
  selector: 'app-root',
  imports: [WeatherAppComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Hello Sample UI';
}
