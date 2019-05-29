import { Component, OnInit, ViewChild } from "@angular/core";
import { Router } from "@angular/router";
import { DataPassService } from "../services/data-pass.service";
import { ReservationService } from "../services/reservation.service";
import { NgForm } from "@angular/forms";

@Component({
  selector: "app-check-form",
  templateUrl: "./check-form.component.html",
  styleUrls: ["./check-form.component.css"]
})
export class CheckFormComponent implements OnInit {
  @ViewChild("f") checkForm: NgForm;

  constructor(
    private router: Router,
    private dataPassService: DataPassService,
    private reservationService: ReservationService
  ) {}

  formData: {
    clientLastName: string;
    reservationId: number;
  };

  ngOnInit() {}

  onChecked() {
    this.formData = {
      clientLastName: this.checkForm.value.clientLastName,
      reservationId: this.checkForm.value.reservationId
    };

    this.reservationService
      .getReservation(this.formData.reservationId, this.formData.clientLastName)
      .subscribe(res => {
        this.dataPassService.setReservation(res);
        this.router.navigateByUrl("/overview");
      });
  }
}
