const path = require('path');

module.exports = {
    mode: 'development',
    entry: './wwwroot/js/index.js',
    output: {
        path: path.resolve(__dirname, 'wwwroot/dist'),
        filename: 'bundle.js'
    },
    module: {
        rules: [
            {
                test: /\.(js|jsx)$/,
                exclude: /(node_modules)/,
                use: {
                    loader: 'babel-loader',
                    options: {
                        presets: [
                          ['@babel/preset-env', { targets: "defaults" }],
                          ['@babel/preset-react']
                        ]
                    }              
                }
            }
        ]
    }
}