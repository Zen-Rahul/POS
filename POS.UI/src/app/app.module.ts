import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { PizzaComponent } from './pizza/pizza.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import {MatNativeDateModule} from '@angular/material/core';
import { MaterialModule } from '../material.module';
import { PizzaCardComponent } from './pizza-card/pizza-card.component';
import { PizzaDialogComponent } from './pizza-dialog/pizza-dialog.component';
import { ItemSizeFilterPipe } from './pipes/inventory-type-filter.pipe';

@NgModule({
  declarations: [
    AppComponent,
    PizzaComponent,
    PizzaCardComponent,
    PizzaDialogComponent,
    ItemSizeFilterPipe
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpClientModule,
    MatNativeDateModule,
    MaterialModule,
    ReactiveFormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
