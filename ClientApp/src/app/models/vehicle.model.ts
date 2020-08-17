import { VehicleType, VehicleTypeMap } from "./type.enum";
import { Inspection } from "./inspection.model";

export class Vehicle {
  constructor(private id: string, public model: string, public topSpeed: number, public type: VehicleType, public inspectionTypes: Inspection[], public trackId: string) { }

  public getType(): string {
    return VehicleTypeMap.get(this.type);
  }
}
