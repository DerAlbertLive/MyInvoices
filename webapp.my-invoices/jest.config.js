module.exports = {
  preset: '@vue/cli-plugin-unit-jest/presets/typescript-and-babel',
  moduleFileExtensions: ['js', 'json', 'vue', 'ts'],
  transform: {
    '^.+\\.vue$': 'vue-jest',
  },
  moduleNameMapper: {},
};
