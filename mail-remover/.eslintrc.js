module.exports = {
  env: {
    browser: true,
    es2021: true,
    node: 1
  },
  extends: [
    'plugin:react/recommended',
    'standard'
  ],
  overrides: [
  ],
  parserOptions: {
    ecmaVersion: 'latest',
    sourceType: 'module'
  },
  plugins: [
    'react'
  ],
  rules: {
    quotes: ['error', 'single'],
    'jsx-quotes': [2, 'prefer-double'],
    indent: ['error', 2]
  }
}
