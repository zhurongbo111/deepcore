import type { Router } from "vue-router";
import { useUserInfoStore } from "@/stores/userInfo";
import { http } from "@/api";

export function useAuthGuard(router: Router) {
  router.beforeEach(async(to) => {
    if(to.meta.requiresAuth){
      const userInfo = useUserInfoStore();
      if(!userInfo.isLogin) {
        // 只要没登录就去请求
        const authMeResponse = await http.v1AuthMeList().catch(() => { return { success: false }});
        if(authMeResponse.success) {
          userInfo.isLogin = true;
        }
        else {
          return { name: 'login' }
        }
      }
    }
  })
}
