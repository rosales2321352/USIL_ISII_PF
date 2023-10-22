import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'
import https from 'https'; 
import fs from 'fs';

const sslKey = fs.readFileSync('/home/rosales1015/.aspnet/https/webapp.key');
const sslCert = fs.readFileSync('/home/rosales1015/.aspnet/https/webapp.pem');

const httpsAgent = new https.Agent({
  rejectUnauthorized: false, // Acepta certificados autofirmados
});

export default defineConfig({
  base: "/app",
  resolve: {
    alias: {
      '@components': '/src/components',
      '@config': '/src/config',
      '@hooks': '/src/hooks',
      '@context': '/src/context',
      "@assets": "/src/assets",
      "@common": "/src/common",
    }
  },
  server: {
    https: {
      key : sslKey,
      cert: sslCert
    },
    port: 44445,
    proxy: {
      '/api': {
        target: 'https://localhost:7124',
        changeOrigin: true,
        agent: httpsAgent,
        rewrite: (path) => path,
      },
    },
  },
  plugins: [react()],
})
