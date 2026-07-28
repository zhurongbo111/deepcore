// src/api/index.ts
import { Api } from './Api';

const api = new Api({
  baseURL: ""
});

// 添加请求头拦截等逻辑...
api.instance.interceptors.request.use((config) => {
  const token = localStorage.getItem('token');
  if (token) {
    config.headers.Authorization = `Bearer ${token}`;
  }
  return config;
});



export const http = api.api;

