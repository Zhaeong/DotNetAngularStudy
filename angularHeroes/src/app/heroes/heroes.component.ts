import { Component, OnInit } from '@angular/core';
import { Hero } from '../hero';

import { HeroService } from '../hero.service';
import { MessageService } from '../message.service';

@Component({
  selector: 'app-heroes',
  templateUrl: './heroes.component.html',
  styleUrls: ['./heroes.component.css'],
})
export class HeroesComponent implements OnInit {
  hero: Hero[] = [];

  selectedHero?: Hero;
  constructor(
    private heroService: HeroService,
    private messageService: MessageService
  ) {}

  ngOnInit(): void {
    this.getHeroes();
    console.log('inittied');
  }

  onSelectHero(hero: Hero): void {
    this.selectedHero = hero;
    console.log('selected: ' + hero.name);
    this.messageService.add('Selected: ' + hero.name);
  }

  getHeroes(): void {
    this.heroService.getHeroes().subscribe((heroes) => (this.hero = heroes));
  }
}

//https://angular.io/tutorial/toh-pt4
