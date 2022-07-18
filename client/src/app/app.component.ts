import { Component } from '@angular/core';
import { SuperHero } from 'src/model/super-hero';
import { SuperHeroService } from 'src/services/super-hero.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {

  heros: SuperHero[] = [];

  constructor(private heroService: SuperHeroService) {}

  ngOnInit() : void { 
    this.heroService.getSuperHeroes().subscribe((result: SuperHero[]) => this.heros = result);
  }

}
