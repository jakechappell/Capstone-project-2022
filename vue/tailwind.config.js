module.exports = {
  content: [],
  theme: {
    extend: {
      colors: {
        accuBlue: '#02204C',
        accuOrange: '#FF800D',
        'orange-500': '#FFA500'
      },
      minHeight: (theme) => ({
        ...theme('spacing'),
      }),
      backgroundImage: {
        'accounting': "url('/assets/accounting.jpg')"
      },
      fontFamily: {
        'montserrat': ['Montserrat'],
        'lato': ['Lato'],
        'garamond': ['Garamond'],
        'arial': ['Arial'],
        'circular': ['Circular'],
        'helvetica': ['Helvetica']
      }
    },
    variants: {
      extend: {
        fontWeight: ['hover'],
        backgroundColor: ['hover', 'focus'],
      }
    }
  },
  plugins: [],
}
