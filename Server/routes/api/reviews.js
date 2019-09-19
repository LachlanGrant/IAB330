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

	app.get('/', multer().none(), (req, res) => {
		ReviewModel.find()
			.then((reviews) => {
				res.json({ success: true, reviews });
			}).catch((err) => {
				res.json({ success: false, message: err.toString().replace("Error: ", "") });
			});
	});

	app.get('/search', multer().none(), (req, res) => {
		const { name, studentNumber, subject } = req.body;
		let query = {};

		if (name !== null && name !== undefined) {
			query.name = { $regex: name, $options: 'i' }
		}

		if (studentNumber !== null && studentNumber !== undefined) {
			query.studentNumber = { $regex: studentNumber, $options: 'i' };
		}

		if (subject !== null && subject !== undefined) {
			query.subject = { $regex: subject, $options: 'i' };
		}

		ReviewModel.find(query)
			.then((reviews) => {
				res.json({ success: true, reviews });
			})
			.catch((err) => {
				res.json({ success: false, message: err.toString() });
			});
	});

	app.post('/create', multer().none(), (req, res) => {
		const { name, friendliness, workEthic, workQuality, studentNumber, subject } = req.body;

		let newReview = new ReviewModel({
			name,
			friendliness,
			workEthic,
			workQuality,
			studentNumber,
			subject,
		});

		newReview.save().then(() => {
			res.json({ success: true });
		}).catch((err) => {
			res.json({ success: false, message: err.toString().replace("Error: ", "") });
		})
	});

	return app;
}());