import { http } from '@/api';
import { defineStore } from 'pinia';

export const useUserInfoStore = defineStore('userInfo', {
  // 为了完整类型推理，推荐使用箭头函数
  state: () => {
    return {
      isLogin: false,
      isFetched: false
    }
  },
  actions: {
    async fetchUserInfo() {
      if(this.isFetched) {
        return;
      }
      const res = await http.v1AuthMeList();
      if(res.success) {
        this.isLogin = true;
      }
      this.isFetched = true;
    }
  }
});
