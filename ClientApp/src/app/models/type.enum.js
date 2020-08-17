"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.VehicleTypeMap = exports.VehicleType = void 0;
var VehicleType;
(function (VehicleType) {
    VehicleType[VehicleType["TRUCK"] = 0] = "TRUCK";
    VehicleType[VehicleType["CAR"] = 1] = "CAR";
})(VehicleType = exports.VehicleType || (exports.VehicleType = {}));
exports.VehicleTypeMap = new Map();
exports.VehicleTypeMap.set(VehicleType.TRUCK, 'Truck');
exports.VehicleTypeMap.set(VehicleType.CAR, 'Car');
//# sourceMappingURL=type.enum.js.map