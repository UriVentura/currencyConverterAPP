import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AboutComponent } from "./about/about.component";
import { ContactComponent } from "./contact/contact.component";
import { ConversorComponent } from "./conversor/conversor.component";
import { HomeComponent } from "./home/home.component";
import { ListaComponent } from "./lista/lista.component";

const routes: Routes = [
    { path: "", component: HomeComponent },
    { path: "home", component: HomeComponent },
    { path: "contact", component: ContactComponent },
    { path: "conversor", component: ConversorComponent },
    { path: "about", component: AboutComponent },
    { path: "lista", component: ListaComponent },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
