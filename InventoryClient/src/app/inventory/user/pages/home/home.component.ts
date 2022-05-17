import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styles: [
  ]
})
export class HomeComponent implements OnInit {

  constructor(private readonly title: Title) { }

  ngOnInit(): void {
    this.title.setTitle('Usuarios | Inventory')
  }

}
