import { Component, OnInit, ViewChild } from "@angular/core";
import { Router } from "@angular/router";
import { NgForm } from "@angular/forms";
import { Car } from "../models/car";
import { DataPassService } from "../services/data-pass.service";

@Component({
  selector: "app-rental-form",
  templateUrl: "./rental-form.component.html",
  styleUrls: ["./rental-form.component.css"]
})
export class RentalFormComponent implements OnInit {
  @ViewChild("f") rentalForm: NgForm;

  updated = false;
  defaultReturnLocation = true;

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

  constructor(
    private router: Router,
    private dataPassService: DataPassService
  ) {}

  ngOnInit() {
    this.updated = this.dataPassService.getUpdated();
  }

  onCheckAvailableCars() {
    if (!this.updated) {
      if (!this.defaultReturnLocation) {
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
      } else {
        this.reservation = {
          clientAge: this.rentalForm.value.clientAge,
          clientLastName: this.rentalForm.value.clientLastName,
          pickUpLocation: this.rentalForm.value.pickUpLocation,
          returnLocation: this.rentalForm.value.pickUpLocation,
          id: 0,
          carId: 0,
          car: new Car(),
          pickUpDate: new Date(this.rentalForm.value.pickUpDate),
          returnDate: new Date(this.rentalForm.value.returnDate)
        };
      }
    } else {
      if (!this.defaultReturnLocation) {
        this.reservation = {
          clientAge: 0,
          clientLastName: "",
          pickUpLocation: this.rentalForm.value.pickUpLocation,
          returnLocation: this.rentalForm.value.returnLocation,
          id: 0,
          carId: 0,
          car: new Car(),
          pickUpDate: new Date(this.rentalForm.value.pickUpDate),
          returnDate: new Date(this.rentalForm.value.returnDate)
        };
      } else {
        this.reservation = {
          clientAge: 0,
          clientLastName: "",
          pickUpLocation: this.rentalForm.value.pickUpLocation,
          returnLocation: this.rentalForm.value.pickUpLocation,
          id: 0,
          carId: 0,
          car: new Car(),
          pickUpDate: new Date(this.rentalForm.value.pickUpDate),
          returnDate: new Date(this.rentalForm.value.returnDate)
        };
      }
    }
  }
}
