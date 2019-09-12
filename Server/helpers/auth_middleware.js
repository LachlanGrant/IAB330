/* eslint-disable consistent-return */
const passport = require('passport');
const jwtConfig = require('../helpers/jwtConfig');

module.exports.isLoggedIn = passport.authenticate('jwt', jwtConfig);

module.exports.isAdmin = function isAdminUser(req, res, next) {
	if (req.user === undefined) {
		res.send(401);
	}

	if (req.user.admin === true) {
		return next();
	}
	res.send(401);
};

module.exports.isActive = function isActive(req, res, next) {
	if (req.user.active === true) {
		return next();
	}
	res.json({
		success: false,
		message: 'Account has been deactivated, please contact Snapps.co for assistance.',
	});
};