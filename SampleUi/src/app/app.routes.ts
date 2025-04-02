import { Routes } from '@angular/router';
import { WeatherAppComponent } from './weather-app/weather-app.component';

export const routes: Routes = [
  { path: '', redirectTo: '/about', pathMatch: 'full' },
  { path: 'weather', component: WeatherAppComponent },
  { path: 'about', component: WeatherAppComponent },
];
