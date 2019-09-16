const app = require('express').Router();
const multer = require('multer');
const auth = require('../../helpers/auth_middleware');
const UserModel = require('../../models/user');
const ReviewModel = require('../../models/review');

module.exports = (function () {
	app.get('/getUsers', auth.isLoggedIn, multer().none(), (req, res) => {
		UserModel.find().then((users) => {
			users.forEach((u) => {
				u.password = undefined;
			});

			res.json({ users, success: true });
		});
	});

	app.get('/', auth.isLoggedIn, multer().none(), (req, res) => {
		ReviewModel.find()
			.populate('user')
			.populate('creator')
			.then((reviews) => {
				reviews.forEach((r) => {
					r.user.password = undefined;
					r.creator.password = undefined;
				});
				res.json({ success: true, reviews });
			}).catch((err) => {
				res.json({ success: false, message: err.toString().replace("Error: ", "") });
			});
	})

	app.post('/create', auth.isLoggedIn, multer().none(), (req, res) => {
		const { name, friendliness, workEthic, workQuality } = req.body;

		let newReview = new ReviewModel({
			name,
			friendliness,
			workEthic,
			workQuality,
			creator: req.user,
		});

		newReview.save().then(() => {
			res.json({ success: true });
		}).catch((err) => {
			res.json({ success: false, message: err.toString().replace("Error: ", "") });
		})
	});

	return app;
}());