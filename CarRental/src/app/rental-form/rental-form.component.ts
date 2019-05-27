import { Component, OnInit, ElementRef, ViewChild } from "@angular/core";
import { Router } from "@angular/router";
import { NgForm } from "@angular/forms";

@Component({
  selector: "app-rental-form",
  templateUrl: "./rental-form.component.html",
  styleUrls: ["./rental-form.component.css"]
})
export class RentalFormComponent implements OnInit {
  @ViewChild("f") rentalForm: NgForm;
  constructor(private router: Router) {}

  ngOnInit() {}

  // onCheckAvailableCars(form: NgForm) {
  //   console.log(form.value);
  //   this.router.navigateByUrl("/availableCars");
  // }

  onCheckAvailableCars() {
    this.router.navigateByUrl("/availableCars");
    console.log(this.rentalForm.value);
  }
}
