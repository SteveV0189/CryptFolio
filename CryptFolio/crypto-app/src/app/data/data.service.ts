import { Injectable } from '@angular/core';
import { environment } from './../../environments/environment';

@Injectable()
export class DataService {
  readonly apiUrl = environment.apiUrl;
  constructor() { }

}
