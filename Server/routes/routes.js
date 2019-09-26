const APIRoutes = require('./api');

module.exports = function routes(app) {
	app.use('/api', APIRoutes);
};