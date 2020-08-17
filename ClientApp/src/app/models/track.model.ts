import { Vehicle } from "./vehicle.model";

export class Track {
  public constructor(public id: string, public location: string, public length: number, public vehicles: Vehicle[]) {}
}
