import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-tablero',
  templateUrl: './tablero.component.html',
  styleUrls: ['./tablero.component.css']
})
export class TableroComponent implements OnInit {
  posiciones = [];
  jugador = null;
  primerJugador = true;
  finJuego = false;
  combinacionesGanadoras = [
    [0, 1, 2],
    [3, 4, 5],
    [6, 7, 8],
    [0, 3, 6],
    [1, 4, 7],
    [2, 5, 8],
    [0, 4, 8],
    [2, 4, 6]
  ];

  constructor() { }

  ngOnInit() {
    this.nuevoJuego();
  }

  nuevoJuego() {
    this.posiciones = Array(9).fill(null);
    this.primerJugador = true;
    this.finJuego = false;
  }

  hacerJugada(index: number) {
    if (this.posiciones[index] !== null) {
      return;
    }

    this.jugador = this.primerJugador ? 'O' : 'X';
    this.posiciones[index] = this.jugador;
    this.primerJugador = !this.primerJugador;

    const jugadorGanador = this.validarGanador();
    if (jugadorGanador !== null) {
      this.finJuego = true;
      alert(`Ha ganado el jugador ${jugadorGanador}`);
    }
  }

  validarGanador(): string {
    for (const pos of this.combinacionesGanadoras) {
      const [a, b, c] = pos;

      if (this.posiciones[a] === this.jugador && this.posiciones[b] === this.jugador && this.posiciones[c] === this.jugador) {
        return this.jugador;
      }
    }

    return null;
  }

}
