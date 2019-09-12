const APIRoutes = require('./api');

module.exports = function routes(app) {
	app.get('/', (req, res) => {
		res.json({ success: true });
	});

	app.use('/api', APIRoutes);
};