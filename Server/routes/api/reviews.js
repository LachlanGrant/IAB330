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
			.populate('user')
			.then((reviews) => {
				reviews.forEach((review) => {
					if (review.user) {
						review.user.password = undefined;
						review.reviewerName = review.user.username;
					}
				});
				res.json({ success: true, reviews });
			}).catch((err) => {
				res.json({ success: false, message: err.toString().replace("Error: ", "") });
			});
	});

	app.post('/search', multer().none(), (req, res) => {
		const { search } = req.body;

		ReviewModel.find()
			.populate('user')
			.or(
				[
					{ 'name': { $regex: search, $options: 'i' } },
					{ 'studentNumber': { $regex: search, $options: 'i' } },
					{ 'subject': { $regex: search, $options: 'i' } }
				])
			.exec((err, results) => {
				if (err) {
					res.json({ success: false, message: err.toString() });
				} else {
					results.forEach((item) => {
						if (item.user) {
							item.user.password = undefined;
							item.reviewerName = item.user.username;
						}
					});
					res.json({ success: true, reviews: results });
				}
			});
	});

	app.post('/create', multer().none(), (req, res) => {
		const { name, friendliness, workEthic, workQuality, studentNumber, subject, username } = req.body;
		UserModel.find({ username }).then((foundUser) => {
			console.log(foundUser);
			if (foundUser) {
				console.log("Creating Review");
				let user = foundUser._id;
				console.log(`UserID: ${user}`);
				let newReview = new ReviewModel({
					user,
					name,
					friendliness,
					workEthic,
					workQuality,
					studentNumber,
					subject,
				});
				console.log(newReview);
				newReview.save().then(() => {
					res.json({ success: true });
				}).catch((err) => {
					console.error(err);
					res.json({ success: false, message: err.toString().replace("Error: ", "") });
				});
			} else {
				throw new Error("No user found");
			}
		}).catch((err) => {
			console.error(err);
			res.json({ success: false, message: err.toString().replace("Error: ", "") });
		});
	});

	return app;
}());