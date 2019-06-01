import { Component, OnInit, ViewChild } from "@angular/core";
import { Router } from "@angular/router";
import { DataPassService } from "../services/data-pass.service";
import { ReservationService } from "../services/reservation.service";
import { NgForm } from "@angular/forms";
import { HttpErrorResponse } from "@angular/common/http";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";

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
    private reservationService: ReservationService,
    private modal: NgbModal
  ) {}

  formData: {
    clientLastName: string;
    reservationId: number;
  };

  modalWindow: {
    title: string;
    body: string;
  };

  ngOnInit() {}

  onChecked(content) {
    this.formData = {
      clientLastName: this.checkForm.value.clientLastName,
      reservationId: this.checkForm.value.reservationId
    };

    this.reservationService
      .getReservation(this.formData.reservationId, this.formData.clientLastName)
      .subscribe(
        res => {
          this.dataPassService.setReservation(res);
          this.router.navigateByUrl("/overview");
        },
        (error: HttpErrorResponse) => {
          if (error.status == 400) {
            this.modalWindow = {
              title: "Error",
              body: "There is no reservation with such an ID and last name!"
            };
            this.modal.open(content);
          }
        }
      );
  }
}
