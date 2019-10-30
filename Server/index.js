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

const UserModel = require('./models/user');
const ReviewModel = require('./models/review');

UserModel.findOne({ username: "lachlangrant" }).then((user) => {
	ReviewModel.find().then((reviews) => {
		reviews.forEach((review) => {
			review.user = user;
			console.log(`Updating Review ${review.name}`);
			review.save();
		});
	});
});