const path = require('path');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');
const postcssPresetEnv = require('postcss-preset-env');
const CopyPlugin = require('copy-webpack-plugin');

const devMode = false;

module.exports = {
    mode: devMode ? 'development' : 'production',

    entry: {
        site: './src/scss/site.scss', // key và file nguồn css (key site dùng để đặt tên file xuất)
        // other: './src/scss/other.scss',
    },

    output: {
        filename: 'app.min.js',
        path: path.resolve(__dirname, 'wwwroot'),
        // library: 'mylib',
        // libraryTarget: 'var',
    },


    plugins: [
        // Xuất kết quả với CSS - sau khi qua loader MiniCssExtractPlugin.loader
        new MiniCssExtractPlugin({
            filename: devMode ? 'css/[name].css' : 'css/[name].min.css',


        }),
        // Copy JS
        new CopyPlugin({patterns:
          [
            { from: 'node_modules/jquery/dist/jquery.min.js', to: 'js/jquery.min.js' },
            { from: 'node_modules/bootstrap/dist/js/bootstrap.min.js', to: 'js/bootstrap.min.js' },
            { from: 'node_modules/popper.js/dist/popper.min.js', to: 'js/popper.min.js' },
            { from: 'node_modules/bootstrap/dist/css/bootstrap.min.css', to: 'css/bootstrap.min.css' },
        ]
        }),
    ]
};