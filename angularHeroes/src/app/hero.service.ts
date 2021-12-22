import { Injectable } from '@angular/core';
import { catchError, Observable, of } from 'rxjs';
import { Hero } from './hero';
import { HEROES } from './mock-heroes';
import { MessageService } from './message.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class HeroService {
  private heroesURL = 'https://localhost:7127/Pizza';
  constructor(
    private messageService: MessageService,
    private http: HttpClient
  ) {}

  getHeroes(): Observable<Hero[]> {
    console.log('in service');
    //const heroes = of(HEROES);

    let httpOptions = {
      headers: new HttpHeaders({ rejectUnauthorized: 'false' }),
    };

    const heroes = this.http
      .get<Hero[]>(this.heroesURL, httpOptions)
      .pipe(catchError(this.handleError<Hero[]>('getHeroes', [])));
    this.messageService.add('HeroService: got all heroes');
    return heroes;
  }

  getHero(id: number): Observable<Hero> {
    let hero = <Hero>{};
    for (let i = 0; i < HEROES.length; i++) {
      if (HEROES[i].id === id) {
        hero = HEROES[i];
      }
    }
    console.log('got hero: ' + hero.name);
    return of(hero);
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      this.messageService.add(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}
