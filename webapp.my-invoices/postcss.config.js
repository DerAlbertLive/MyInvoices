module.exports = {
  plugins: [
    // eslint-disable-next-line @typescript-eslint/no-var-requires
    require('tailwindcss')('tailwind.js'),
    // eslint-disable-next-line @typescript-eslint/no-var-requires
    require('autoprefixer')(),
  ],
};
