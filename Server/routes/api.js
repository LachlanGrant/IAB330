const app = require('express').Router();
const multer = require('multer');
const path = require('path');
const fs = require('fs');
const bcrypt = require('bcrypt-nodejs');
const userModel = require('../models/user');
const TokenHelper = require('../helpers/token');
const auth = require('../helpers/auth_middleware');
const UserModel = require('../models/user');
const ReviewRoutes = require('./api/reviews');

module.exports = (function () {
	app.use('/reviews', ReviewRoutes);

	app.get('/test', multer().none(), (req, res) => {
		res.json({ date: new Date(), requestBody: req.body, user: req.user });
	});

	app.post('/signup', multer().none(), (req, res) => {
		const {
			username,
			password,
		} = req.body;

		const newUser = new UserModel();

		newUser.username = username;
		newUser.password = bcrypt.hashSync(password, null);

		newUser.save((err, user) => {
			if (err) {
				res.json({
					success: false,
					message: err.toString(),
				});
			} else {
				res.json({
					success: true,
					user,
				});
			}
		});
	});

	app.post('/token', (req, res) => {
		TokenHelper.tokenForUser(req.body.username, req.body.password)
			.then((userToken) => {
				userModel
					.findOne({ username: req.body.username })
					.then((user) => {
						user.password = undefined;
						res.json({ success: true, userToken, user });
					})
					.catch((err) => {
						throw err;
					});
			})
			.catch((err) => {
				res.json({ error: err.toString().replace("Error: ", ""), success: false });
			});
	});

	app.get('/me', auth.isLoggedIn, (req, res) => {
		if (req.user !== undefined) {
			const { user } = req;
			user.password = undefined;
			res.json({ user, success: true });
		} else {
			res.json({ success: false, message: 'Not authenticated' });
		}
	});

	return app;
}());