import { Component, Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Vehicle } from '../models/vehicle.model';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { VehicleType } from '../models/type.enum';
import { Inspection } from '../models/inspection.model';
import { Track } from '../models/track.model';

@Injectable({
  providedIn: 'root',
})
export class RaceTrackService {
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    
  }

  public getTrack(): Observable<Track> {
    return this.http.get<Track>(this.baseUrl + 'tracks')
      .pipe(map((data: any) => this.createTracksFromData(data)));
  }

  public addParticipant(vehicle: Vehicle): Observable<Vehicle> {
    return this.http.post<Vehicle>(this.baseUrl + 'vehicles', vehicle);
  }

  public deleteParticipant(id: string): Observable<Vehicle> {
    return this.http.delete<Vehicle>(this.baseUrl + 'vehicles/' + id);
  }

  private createVehicle(vehicle: any, inspections: Inspection[], trackId: string): Vehicle {
    return new Vehicle(
      vehicle.id,
      vehicle.model,
      vehicle.topSpeed,
      vehicle.type ? VehicleType.CAR : VehicleType.TRUCK,
      inspections,
      trackId
    )
  }

  private createTracksFromData(data: any): any {
    return data.map(track => {
      const vehicles = track.vehicles.map(vehicle => {
        const inspections: Inspection[] = [];
        vehicle.inspectionTypes.forEach(inspection => {
          inspections.push(new Inspection(inspection.id, inspection.inspectionType, inspection.passed));
        });
        return this.createVehicle(vehicle, inspections, track.id);
      });
      return new Track(track.id, track.location, track.length, vehicles);
    });
  }
}
