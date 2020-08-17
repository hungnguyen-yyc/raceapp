"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Vehicle = void 0;
var type_enum_1 = require("./type.enum");
var Vehicle = /** @class */ (function () {
    function Vehicle(id, model, topSpeed, type, inspectionTypes, trackId) {
        this.id = id;
        this.model = model;
        this.topSpeed = topSpeed;
        this.type = type;
        this.inspectionTypes = inspectionTypes;
        this.trackId = trackId;
    }
    Vehicle.prototype.getType = function () {
        return type_enum_1.VehicleTypeMap.get(this.type);
    };
    return Vehicle;
}());
exports.Vehicle = Vehicle;
//# sourceMappingURL=vehicle.model.js.map