import {InjectionToken} from '@angular/core';
import {environment} from './environment';

export interface Environment {
  production: boolean;
  name: string;
  apiPath: string;
}

export const ENV = new InjectionToken<Environment>('env');

export function getEnv(): Environment {
  return environment;
}
