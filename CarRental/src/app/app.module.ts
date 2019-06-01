import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { AppComponent } from "./app.component";
import { NavbarComponent } from "./navbar/navbar.component";
import { HomePageComponent } from "./home-page/home-page.component";
import { HttpClientModule } from "@angular/common/http";
import { CarService } from "./services/car.service";
import { RentalFormComponent } from "./rental-form/rental-form.component";
import { FormsModule } from "@angular/forms";
import { CheckFormComponent } from "./check-form/check-form.component";
import { AvailableCarsComponent } from "./rental-form/available-cars/available-cars.component";
import { ReservationOverviewComponent } from "./reservation-overview/reservation-overview.component";

const appRoutes: Routes = [
  { path: "", component: HomePageComponent },
  { path: "rent", component: RentalFormComponent },
  { path: "check", component: CheckFormComponent },
  {
    path: "overview",
    component: ReservationOverviewComponent,
    children: [{ path: "update", component: RentalFormComponent }]
  }
];

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    HomePageComponent,
    RentalFormComponent,
    CheckFormComponent,
    AvailableCarsComponent,
    ReservationOverviewComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes),
    FormsModule
  ],
  providers: [CarService],
  bootstrap: [AppComponent]
})
export class AppModule {}
