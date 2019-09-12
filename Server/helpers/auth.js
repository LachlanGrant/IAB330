const LocalStrategy = require('passport-local').Strategy;
const bcrypt = require('bcrypt-nodejs');
const JwtStrategy = require('passport-jwt').Strategy;
const { ExtractJwt } = require('passport-jwt');
const UserModel = require('../models/user');
const jwtConfig = require('./jwtConfig');
const DatabaseClass = require('./database');

module.exports = function auth(passport) {
	// eslint-disable-next-line no-unused-vars
	const database = new DatabaseClass();

	passport.serializeUser((user, done) => {
		done(null, user.id);
	});

	passport.deserializeUser((id, done) => {
		UserModel.findById(id).then((user) => {
			done(null, user);
		});
	});

	passport.use(
		new JwtStrategy(
			{
				secretOrKey: jwtConfig.jwtSecret,
				jwtFromRequest: ExtractJwt.fromAuthHeaderAsBearerToken(),
			},
			(jwtPayload, done) => {
				UserModel.findById(jwtPayload.id, (err, user) => {
					if (err) {
						return done(err, false);
					}
					if (user) {
						return done(null, user);
					}
					return done(null, false);
				});
			},
		),
	);
};