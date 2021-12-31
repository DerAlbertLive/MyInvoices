// eslint-disable-next-line @typescript-eslint/no-var-requires
const colors = require('tailwindcss/colors');

module.exports = {
  content: ['./src/**/*.{html,vue,js}'],
  theme: {
    extend: {
      colors: {
        orange: colors.orange,
      },
    },
  },
  variants: {},
  plugins: [],
};
