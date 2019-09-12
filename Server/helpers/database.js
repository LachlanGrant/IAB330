const mongoose = require('mongoose');

class AuthDatabase {
	constructor() {
		mongoose.connect(
			process.env.databaseURL,
			{
				useNewUrlParser: true,
			},
		).then(() => {
			console.info('MongoDB Connected');
		}).catch((err) => {
			console.error(err);
		});
	}
}

module.exports = AuthDatabase;