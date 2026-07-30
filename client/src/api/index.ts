// src/api/index.ts
import { localStore } from '@/utils/storage';
import { Api } from './Api';
import type { AxiosResponse } from 'axios';
import message from '@/utils/message';

const api = new Api({
  baseURL: ""
});

// 添加请求头拦截等逻辑...
api.instance.interceptors.request.use((config) => {
  const token = localStore.get<string>("token");
  if (token) {
    config.headers.Authorization = `Bearer ${token}`;
  }
  return config;
});

api.instance.interceptors.response.use((response) => response, (error: { response?:  AxiosResponse<string>}) => {
  switch(error.response?.status) {
    case 401:
      message.error("你的登录状态已过期，请重新登录！");
      break;
    case 403:
      message.error("你没有获取相关数据的权限！");
      break;
    case 500:
      message.error("服务器出错，请刷新页面或稍后重试！");
      break;
  }

  return Promise.reject(error);
})


export const http = api.api;

