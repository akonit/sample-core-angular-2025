import { Pipe, PipeTransform } from "@angular/core";
import { TemperatureUnit } from "../weather-app/weather-app.service";

@Pipe({
    name: 'temperature',
  })
  export class TemperaturePipe implements PipeTransform {
    transform(value: TemperatureUnit): string {
      return value === TemperatureUnit.celsius ? "C" : "F";
    }
  }