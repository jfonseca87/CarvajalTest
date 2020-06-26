import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { TableroComponent } from './components/tablero/tablero.component';
import { CuadroComponent } from './components/cuadro/cuadro.component';

@NgModule({
  declarations: [
    AppComponent,
    TableroComponent,
    CuadroComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
