"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.InspectionTypeMap = exports.InspectionType = exports.Inspection = void 0;
var Inspection = /** @class */ (function () {
    function Inspection(id, inspectionType, passed) {
        this.id = id;
        this.inspectionType = inspectionType;
        this.passed = passed;
    }
    return Inspection;
}());
exports.Inspection = Inspection;
var InspectionType;
(function (InspectionType) {
    InspectionType[InspectionType["TOW_STRAP"] = 0] = "TOW_STRAP";
    InspectionType[InspectionType["NOT_LIFTED_MORE_THAN_5_INCHES"] = 1] = "NOT_LIFTED_MORE_THAN_5_INCHES";
    InspectionType[InspectionType["LESS_THAN_85_TIRE_WEAR"] = 2] = "LESS_THAN_85_TIRE_WEAR";
})(InspectionType = exports.InspectionType || (exports.InspectionType = {}));
exports.InspectionTypeMap = new Map();
exports.InspectionTypeMap.set(InspectionType.TOW_STRAP, 'Tow strap on the vehicle');
exports.InspectionTypeMap.set(InspectionType.NOT_LIFTED_MORE_THAN_5_INCHES, 'Not lifted more than 5 inches');
exports.InspectionTypeMap.set(InspectionType.LESS_THAN_85_TIRE_WEAR, 'Less than 85% tire wear');
//# sourceMappingURL=Inspection.js.map