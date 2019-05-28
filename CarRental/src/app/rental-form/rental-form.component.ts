import { Component, OnInit, ElementRef, ViewChild, Input } from "@angular/core";
import { Router } from "@angular/router";
import { NgForm } from "@angular/forms";
import { CarService } from "../services/car.service";
import { Reservation } from "../models/reservation";
import { Car } from "../models/car";

@Component({
  selector: "app-rental-form",
  templateUrl: "./rental-form.component.html",
  styleUrls: ["./rental-form.component.css"]
})
export class RentalFormComponent implements OnInit {
  private carService: CarService;

  dates = {
    pickUpDate: new Date(),
    returnDate: new Date()
  };

  @ViewChild("f") rentalForm: NgForm;

  reservation = {
    pickUpLocation: "",
    returnLocation: "",
    clientLastName: "",
    clientAge: 0
  };

  constructor(private router: Router) {}

  ngOnInit() {}

  onCheckAvailableCars() {
    //this.router.navigateByUrl("/availableCars");
    this.reservation.clientAge = this.rentalForm.value.clientAge;
    this.reservation.clientLastName = this.rentalForm.value.clientLastName;
    this.reservation.pickUpLocation = this.rentalForm.value.pickUpLocation;
    this.reservation.returnLocation = this.rentalForm.value.returnLocation;

    this.dates = {
      pickUpDate: new Date(this.rentalForm.value.pickUpDate),
      returnDate: new Date(this.rentalForm.value.returnDate)
    };
  }
}
