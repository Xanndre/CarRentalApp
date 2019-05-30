import { Component, OnInit } from "@angular/core";
import { DataPassService } from "../services/data-pass.service";

@Component({
  selector: "app-home-page",
  templateUrl: "./home-page.component.html",
  styleUrls: ["./home-page.component.css"]
})
export class HomePageComponent implements OnInit {
  //updated = false;

  constructor(private dataPassService: DataPassService) {}

  ngOnInit() {
    this.dataPassService.setUpdated(false);
  }
}
