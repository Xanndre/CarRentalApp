import { Injectable } from "@angular/core";
import { HttpClient, HttpParams } from "@angular/common/http";
import { map } from "rxjs/Operators";
import { Observable } from "rxjs";
import { Car } from "../models/car";

@Injectable({
  providedIn: "root"
})
export class CarService {
  constructor(private client: HttpClient) {}

  getAllCars(): Observable<Car[]> {
    return this.client.get("https://localhost:44377/api/Reservation/Cars").pipe(
      map((res: Car[]) => {
        return res;
      })
    );
  }

  getAvailableCars(pickUpDate: Date, returnDate: Date): Observable<Car[]> {
    let params = new HttpParams()
      .set("pickUpDate", pickUpDate.toString())
      .set("returnDate", returnDate.toString());
    return this.client
      .get("https://localhost:44377/api/Reservation/AvailableCars", {
        params: params
      })
      .pipe(
        map((res: Car[]) => {
          return res;
        })
      );
  }
}
