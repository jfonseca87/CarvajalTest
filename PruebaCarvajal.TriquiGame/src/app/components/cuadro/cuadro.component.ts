import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-cuadro',
  templateUrl: './cuadro.component.html',
  styleUrls: ['./cuadro.component.css']
})
export class CuadroComponent implements OnInit {
  @Input() valor = undefined;
  @Input() finJuego = false;

  constructor() { }

  ngOnInit() {
  }

}
