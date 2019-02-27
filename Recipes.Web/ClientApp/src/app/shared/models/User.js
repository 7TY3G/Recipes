"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var User = /** @class */ (function () {
    function User(firstname, lastname, username, email, password) {
        if (firstname === void 0) { firstname = ''; }
        if (lastname === void 0) { lastname = ''; }
        if (username === void 0) { username = ''; }
        if (email === void 0) { email = ''; }
        if (password === void 0) { password = ''; }
        this.firstname = firstname;
        this.lastname = lastname;
        this.username = username;
        this.email = email;
        this.password = password;
    }
    return User;
}());
exports.User = User;
//# sourceMappingURL=user.js.map