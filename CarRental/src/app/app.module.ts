import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";

import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { NavbarComponent } from "./navbar/navbar.component";
import { HomePageComponent } from "./home-page/home-page.component";
import { HttpClientModule } from "@angular/common/http";
import { CarService } from "./services/car.service";

@NgModule({
  declarations: [AppComponent, NavbarComponent, HomePageComponent],
  imports: [BrowserModule, AppRoutingModule, HttpClientModule],
  providers: [CarService],
  bootstrap: [AppComponent]
})
export class AppModule {}
