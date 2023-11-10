import { createTheme } from '@mui/material/styles';

const ThemeDefault = createTheme({
  typography: {
    fontFamily: [
      'Open Sans',
      'sans-serif'
    ].join(','),
  }
})

export default ThemeDefault