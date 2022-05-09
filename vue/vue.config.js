module.exports = {
    devServer: {
        proxy: {
            '^/api': {
                target: 'http://localhost:44393',
                changeOrigin: true
            }
        }
    }
}