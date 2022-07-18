import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { SuperHero } from 'src/model/super-hero';

@Injectable({
  providedIn: 'root',
})
export class SuperHeroService {

  private url = "superhero"
  private HeroUrl = environment.apiUrl + "/" + this.url;
  constructor(private http : HttpClient) {

  }

  public getSuperHeroes(): Observable<SuperHero[]> {
    return this.http.get<SuperHero[]>(this.HeroUrl);
  }

  public getSuperHeroById(id: string): Observable<SuperHero> {
    return this.http.get<SuperHero>(this.HeroUrl + "/" + id);
  }

  public createSuperHero(superHero: SuperHero): Observable<SuperHero> {
    return this.http.post<SuperHero>(this.HeroUrl, superHero);
  }

  public deleteSuperHero(id: string): Observable<any> {
    return this.http.delete<any>(this.HeroUrl + "/" + id);
  }

  public updateHero(superHero: SuperHero): Observable<SuperHero> {
    return this.http.put<SuperHero>(this.HeroUrl + "/" + superHero._id, superHero);
  }

}
