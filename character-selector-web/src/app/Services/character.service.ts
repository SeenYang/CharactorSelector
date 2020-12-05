import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {MessageService} from './message.service';
import {EMPTY, Observable, of} from 'rxjs';
import {catchError, mapTo, tap} from 'rxjs/operators';
import {Character} from '../Models/character';
import {environment as testEnv} from '../../environments/environment';

@Injectable({providedIn: 'root'})
export class CharacterService {
    private CharacterUrl = `${testEnv.apiPath}/api/Characters`;  // URL to web api

    httpOptions = {
        headers: new HttpHeaders({'Content-Type': 'application/json'})
    };

    constructor(
        private http: HttpClient,
        private messageService: MessageService) {
    }

    /** GET heroes from the server */
    getCharacters(): Observable<Character[]> {
        return this.http.get<Character[]>(`${this.CharacterUrl}/GetAllCharacters/`)
            .pipe(
                tap(_ => this.log('Fetch Characters')),
                catchError(this.handleError<Character[]>('getCharacters', []))
            );
    }

    /* GET heroes whose name contains search term */
    getCharactersById(characterId: string): Observable<Character> {
        return this.http.get<Character>(`${this.CharacterUrl}/GetCharacterById/${characterId}`).pipe(
            tap((x) => {
                this.log(`found Characters matching "${characterId}"`);
            }),
            catchError((error) => {
                this.handleError<Character>('getCharactersById', error);
                return EMPTY;
            })
        );
    }

    /** POST: add a new hero to the server */
    addCustomerCharacter(character: Character): Observable<Character> {
        return this.http.post<Character>(`${this.CharacterUrl}/CreateCharacter/`, character).pipe(
            tap((newCharacter: Character) => {
                console.log(`added event w/ id=${newCharacter.id}`);
                return newCharacter;
            }),
            catchError((error) => {
                this.handleError(error);
                return EMPTY;
            })
        );
    }

    /**
     * Handle Http operation that failed.
     * Let the app continue.
     * @param operation - name of the operation that failed
     * @param result - optional value to return as the observable result
     */
    private handleError<T>(operation = 'operation', result?: T) {
        return (error: any): Observable<T> => {

            // TODO: send the error to remote logging infrastructure
            console.error(error); // log to console instead

            // TODO: better job of transforming error for user consumption
            this.log(`${operation} failed: ${error.message}`);

            // Let the app keep running by returning an empty result.
            return of(result as T);
        };
    }

    /** Log a CharacterService message with the MessageService */
    private log(message: string) {
        this.messageService.add(`HeroService: ${message}`);
    }
}
