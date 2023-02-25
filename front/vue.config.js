const { defineConfig } = require('@vue/cli-service');

module.exports = defineConfig({
  lintOnSave: process.env.NODE_ENV !== 'production',
  productionSourceMap: false,
  configureWebpack: {
    devtool: process.env.NODE_ENV !== 'production' ? 'source-map' : false,
  },
  pages: {
    index: {
      entry: 'src/main.js',
      title: 'Fun - The Deep World',
    },
  },
  pluginOptions: {
    webpackBundleAnalyzer: {
      analyzerMode: 'disabled',
    },
  },
  css: {
    sourceMap: process.env.NODE_ENV !== 'production',
  },
  chainWebpack: (config) => {
    config.plugins.delete('friendly-errors');
  },
});
