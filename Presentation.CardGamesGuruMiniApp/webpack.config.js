const path = require('path');

module.exports = {
    mode: 'development',
    entry: './wwwroot/js/index.js',
    output: {
        path: path.resolve(__dirname, 'wwwroot/dist'),
        filename: 'bundle.js'
    }
}