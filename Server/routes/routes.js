const APIRoutes = require('./api');

module.exports = function routes(app) {
	app.get('/', (req, res) => {
		res.json({ success: true, message: "Please check postman for API Docs.", url: "https://documenter.getpostman.com/view/2844630/SVmsUf3D?version=latest" });
	});

	app.use('/api', APIRoutes);
};