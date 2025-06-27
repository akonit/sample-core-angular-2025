import { Routes } from '@angular/router';
import { WeatherAppComponent } from './weather-app/weather-app.component';
import { WeatherSettingsComponent } from './weather-settings/weather-settings.component';
import { HomeComponent } from './home/home.component';
import { authGuardFn } from '@auth0/auth0-angular';

export const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'weather', component: WeatherAppComponent, canActivate: [authGuardFn] },
  { path: 'weather-settings', component: WeatherSettingsComponent, canActivate: [authGuardFn] },
];
