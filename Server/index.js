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

app.listen(8009, () => {
	console.log("Running");
});