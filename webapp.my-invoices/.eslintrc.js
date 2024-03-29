module.exports = {
  root: true,
  env: {
    es2021: true
  },
  extends: [
    'plugin:@typescript-eslint/recommended',
    'plugin:vue/vue3-strongly-recommended'
  ],
  parserOptions: {
    ecmaVersion: 2020,
    parser: '@typescript-eslint/parser',
  },
  rules: {
    'no-console': process.env.NODE_ENV === 'production' ? 'warn' : 'off',
    'no-debugger': process.env.NODE_ENV === 'production' ? 'warn' : 'off',
    'quotes': ['warn', 'single'],
    'vue/no-multiple-template-root': 'off',
    'vue/singleline-html-element-content-newline': 'off',
    'vue/max-attributes-per-line': 'off',
    'vue/multi-word-component-names' : 'off',
    '@typescript-eslint/no-unused-vars': 'off'
  },
  overrides: [
    {
      files: ['**/__tests__/*.{j,t}s?(x)', '**/__tests__/unit/**/*.spec.{j,t}s?(x)'],
      env: {
        jest: true
      }
    }
  ],
};
