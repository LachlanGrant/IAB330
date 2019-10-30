const express = require('express');
const body = require('body-parser');
const morgan = require('morgan');
const passport = require('passport');
const path = require('path');
const fs = require('fs');
const http = require('http');

require('custom-env').env(true);

const app = express();

require('./helpers/database');

app.use(passport.initialize());
app.use(passport.session());

require('./helpers/auth')(passport);

app.use(
	body.urlencoded({
		extended: true,
	}),
);
app.use(body.json());

require('./routes/routes')(app);

app.listen(8080, () => {
	console.log("Running");
});

const reviewsToKeep = ["5d85e949c09f990031643cea", "5d85ebfcc09f990031643ceb", "5d883955c09f990031643cec", "5d88406fc09f990031643ced", "5d8843bcc09f990031643cee", "5d8b702dc09f990031643cef"];

const ReviewModel = require('./models/review');

ReviewModel.find().then((reviews) => {
	reviews.forEach((review) => {
		if (reviewsToKeep.indexOf(review._id) == -1) {
			review.remove();
		}
	});
});