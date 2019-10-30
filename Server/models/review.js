const mongoose = require('mongoose');

const reviewModel = new mongoose.Schema({
	name: {
		type: String,
		required: true,
	},

	studentNumber: {
		type: String,
		required: true,
	},

	subject: {
		type: String,
		required: true,
	},

	friendliness: {
		type: Number,
		required: true
	},

	workEthic: {
		type: Number,
		required: true,
	},

	workQuality: {
		type: Number,
		required: true,
	},

	user: {
		type: mongoose.Schema.Types.ObjectId,
		ref: "User",
		required: false,
	},
});

module.exports = mongoose.model('Review', reviewModel);