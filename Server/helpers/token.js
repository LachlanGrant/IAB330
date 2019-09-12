const jwt = require('jsonwebtoken');
const bcrypt = require('bcrypt-nodejs');
const userModel = require('../models/user');
const jwtConfig = require('./jwtConfig');

module.exports.tokenForUser = function token(username, password) {
	return new Promise((resolve, reject) => {
		if (!username || !password) {
			reject(new Error('Define username and password'));
		}

		userModel
			.findOne({ username })
			.then((user) => {
				if (user) {
					if (bcrypt.compareSync(password, user.password)) {
						resolve(
							jwt.sign({ id: user._id }, jwtConfig.jwtSecret, {}),
							// expiresIn: "30m"
						);
					} else {
						reject(new Error('Incorrect Password'));
					}
				} else {
					reject(new Error('No User Found'));
				}
			})
			.catch((err) => {
				reject(err);
			});
	});
};