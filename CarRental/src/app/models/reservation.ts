import { Car } from "./car";

export class Reservation {
  id: number;
  pickUpLocation: string;
  returnLocation: string;
  pickUpDate: Date;
  returnDate: Date;
  clientLastName: string;
  clientAge: number;
  carId: number;
  car: Car;
}
