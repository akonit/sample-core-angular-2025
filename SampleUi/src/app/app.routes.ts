import { Routes } from '@angular/router';
import { WeatherAppComponent } from './weather-app/weather-app.component';
import { WeatherSettingsComponent } from './weather-settings/weather-settings.component';

export const routes: Routes = [
  { path: '', redirectTo: '/weather', pathMatch: 'full' },
  { path: 'weather', component: WeatherAppComponent },
  { path: 'weather-settings', component: WeatherSettingsComponent },
];
