require('custom-env').env(true);
const faker = require('faker');
const UserModel = require('../models/user');
const ReviewModel = require('../models/review');
const bcrypt = require('bcrypt-nodejs');
const dbClass = require('../helpers/database');

const db = new dbClass();

const newData = {
	users: 10,
	reviews: 100
};

setTimeout(() => {
	for (var i = 0; i < newData.users; i++) {
		let newUser = new UserModel({
			username: faker.internet.userName,
			password: bcrypt.hashSync(faker.internet.password, null),
		});

		newUser.save().then(() => {
			console.log(`Created User: ${newUser.username}`);
		}).catch((err) => {
			console.error(err);
			process.exit(0);
		});
	}

	UserModel.find().then((users) => {
		for (var i = 0; i < newData.reviews; i++) {
			let newReview = new ReviewModel({
				user: users[randomNumberBetweenOandX(users.length - 1)],
				creator: users[randomNumberBetweenOandX(users.length - 1)],
				friendlienss: randomNumberBetweenOandX(5),
				workEthic: randomNumberBetweenOandX(5),
				workQuality: randomNumberBetweenOandX(5),
			});

			newReview.save().then((nR) => {
				console.log(`Created Review: ${nR}`);
			}).catch((err) => {
				console.error(err);
				process.exit(0);
			});
		}
	});

}, 1000);

function randomNumberBetweenOandX(x) {
	return Math.round(Math.random() * x);
}