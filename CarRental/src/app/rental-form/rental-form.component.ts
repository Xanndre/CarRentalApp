import { Component, OnInit, ViewChild } from "@angular/core";
import { Router } from "@angular/router";
import { NgForm } from "@angular/forms";
import { Car } from "../models/car";

@Component({
  selector: "app-rental-form",
  templateUrl: "./rental-form.component.html",
  styleUrls: ["./rental-form.component.css"]
})
export class RentalFormComponent implements OnInit {
  @ViewChild("f") rentalForm: NgForm;

  reservation = {
    id: 0,
    pickUpLocation: "",
    returnLocation: "",
    pickUpDate: new Date(),
    returnDate: new Date(),
    clientLastName: "",
    clientAge: 0,
    carId: 0,
    car: new Car()
  };

  constructor(private router: Router) {}

  ngOnInit() {}

  onCheckAvailableCars() {
    this.reservation = {
      clientAge: this.rentalForm.value.clientAge,
      clientLastName: this.rentalForm.value.clientLastName,
      pickUpLocation: this.rentalForm.value.pickUpLocation,
      returnLocation: this.rentalForm.value.returnLocation,
      id: 0,
      carId: 0,
      car: new Car(),
      pickUpDate: new Date(this.rentalForm.value.pickUpDate),
      returnDate: new Date(this.rentalForm.value.returnDate)
    };
  }
}
