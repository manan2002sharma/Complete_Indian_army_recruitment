import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DeviceDetectService {

  constructor() { }

  getDeviceType(): string {
    return navigator.userAgent;
  }
}
