import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AboutComponent } from './about/about.component';
import { ContactComponent } from './contact/contact.component';
import { ConversorComponent } from './conversor/conversor.component';
import { CustomFilter, ListaComponent } from './lista/lista.component';
import { HomeComponent } from './home/home.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { FooterComponent } from './footer/footer.component';
import { FormsModule } from '@angular/forms';
import { ApiRate } from '../services/api-rates.service';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
    declarations: [
        AppComponent,
        AboutComponent,
        ContactComponent,
        ConversorComponent,
        ListaComponent,
        HomeComponent,
        NavBarComponent,
        FooterComponent,
        CustomFilter
    ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        FormsModule,
        HttpClientModule,
        BrowserModule,
        FormsModule
    ],
    providers: [ApiRate],
    bootstrap: [AppComponent]
})
export class AppModule { }
