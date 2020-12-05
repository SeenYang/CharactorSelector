import {Inject, Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {EMPTY, Observable, of} from 'rxjs';
import {catchError, tap} from 'rxjs/operators';
import {ENV, Environment} from '../../environments/environment.provider';
import {environment as testEnv} from '../../environments/environment';
import {Option} from '../Models/option';

@Injectable({providedIn: 'root'})
export class OptionService {
    private optionUrl = `${testEnv.apiPath}/api/options`;
    httpOptions = {
        headers: new HttpHeaders({'Content-Type': 'application/json'})
    };

    constructor(
        @Inject(ENV) private env: Environment,
        private http: HttpClient) {
        if (this.env.production) {
            this.optionUrl = env.apiPath;
        }
    }

    /**
     * Handle Http operation that failed.
     * Let the app continue.
     * @param operation - name of the operation that failed
     * @param result - optional value to return as the observable result
     */
    private handleError<T>(operation = 'operation', result?: T) {
        return (error: any): Observable<T> => {
            console.error(error); // log to console instead
            // Let the app keep running by returning an empty result.
            return of(result as T);
        };
    }
}
