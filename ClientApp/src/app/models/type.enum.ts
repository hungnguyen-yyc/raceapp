export enum VehicleType {
  TRUCK,
  CAR,
}

export const VehicleTypeMap: Map<VehicleType, string> = new Map();
VehicleTypeMap.set(VehicleType.TRUCK, 'Truck');
VehicleTypeMap.set(VehicleType.CAR, 'Car');
