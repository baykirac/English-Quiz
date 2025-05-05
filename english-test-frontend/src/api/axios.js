import axios from 'axios';

const api = axios.create({
  baseURL: 'https://localhost:5000',
  headers: {
    'Content-Type': 'application/json',
  }
});

api.interceptors.request.use(
  (config) => {
    console.log(`[REQUEST] ${config.method?.toUpperCase()} ${config.url}`);
    return config;
  },
  (error) => Promise.reject(error)
);

api.interceptors.response.use(
  (response) => response.data,
  (error) => {
    console.error('[RESPONSE ERROR]', error);
    return Promise.reject(error);
  }
);

export default api;
