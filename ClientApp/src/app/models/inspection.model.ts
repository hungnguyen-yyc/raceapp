export class Inspection {
  public constructor(public id: string, public inspectionType: InspectionType, public passed: boolean) {}
}

export enum InspectionType {
  TOW_STRAP,
  NOT_LIFTED_MORE_THAN_5_INCHES,
  LESS_THAN_85_TIRE_WEAR
}

export const InspectionTypeMap: Map<InspectionType, string> = new Map();
InspectionTypeMap.set(InspectionType.TOW_STRAP, 'Tow strap on the vehicle');
InspectionTypeMap.set(InspectionType.NOT_LIFTED_MORE_THAN_5_INCHES, 'Not lifted more than 5 inches');
InspectionTypeMap.set(InspectionType.LESS_THAN_85_TIRE_WEAR, 'Less than 85% tire wear');
