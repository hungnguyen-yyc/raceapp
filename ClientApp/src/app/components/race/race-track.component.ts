import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RaceTrackService } from '../../services/race-track.service';
import { Observable } from 'rxjs';
import { Vehicle } from '../../models/vehicle.model';
import { VehicleType, VehicleTypeMap } from '../../models/type.enum';
import { Inspection, InspectionType } from '../../models/inspection.model';
import { Track } from '../../models/track.model';

@Component({
  selector: 'race-track',
  templateUrl: './race-track.component.html',
  providers: [RaceTrackService]
})
export class RaceTrackComponent {
  public tracks$: Observable<Track>;
  public newParticipant: Vehicle;
  public types: typeof VehicleType = VehicleType;
  public typeValues: number[] = Array.from(VehicleTypeMap.keys());
  public vehicleTypes = VehicleTypeMap;
  public towStrap: boolean = false;
  public lifted: boolean = false;
  public tireWear: boolean = false;
  public track

  constructor(private raceTrackService: RaceTrackService) {
    this.reload();
  }

  public addParticipant(track: Track) {
    const towStrap = new Inspection(null, InspectionType.TOW_STRAP, this.towStrap);
    const lifted = new Inspection(null, InspectionType.NOT_LIFTED_MORE_THAN_5_INCHES, this.lifted);
    const tireWear = new Inspection(null, InspectionType.LESS_THAN_85_TIRE_WEAR, this.tireWear);
    this.newParticipant.inspectionTypes.push(towStrap);
    this.newParticipant.inspectionTypes.push(this.newParticipant.type === VehicleType.CAR ? tireWear : lifted);
    this.newParticipant.trackId = track.id;
    this.raceTrackService.addParticipant(this.newParticipant).subscribe(
      data => this.reload(),
      error => {
        alert(error.error);
        this.reload();
      }
    );
  }

  public removeParticipant(id: string) {
    this.raceTrackService.deleteParticipant(id).subscribe(
      data => this.reload(),
      error => {
        alert(error.error);
        this.reload();
      });
  }

  private reload(): void {
    this.newParticipant = new Vehicle(null, null, 100, VehicleType.TRUCK, [], null);
    this.tracks$ = this.raceTrackService.getTrack();
  }
}
