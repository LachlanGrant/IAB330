const mongoose = require('mongoose');

const reviewModel = new mongoose.Schema({
	user: {
		type: mongoose.Schema.Types.ObjectId,
		ref: 'User',
		required: true,
	},

	creator: {
		type: mongoose.Schema.Types.ObjectId,
		ref: 'User',
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
});

module.exports = mongoose.model('Review', reviewModel);