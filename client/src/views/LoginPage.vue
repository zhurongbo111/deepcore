<template>
  <div class="container">
    <div class="content">
      <div class="content-inner">
        <div class="login-form-wrapper">
          <div class="login-form-title">登录</div>
          <div class="login-form-sub-title">登录进销存系统</div>
          <div class="login-form-error-msg">{{ errorMessage }}</div>
          <a-form ref="loginForm" :model="userInfo" class="login-form" layout="vertical" @submit="handleSubmit">
            <a-form-item field="username" :rules="[{ required: true, message: '用户名' }]"
              :validate-trigger="['change', 'blur']" hide-label>
              <a-input v-model="userInfo.username" placeholder="请输入用户名">
                <template #prefix>
                  <icon-user />
                </template>
              </a-input>
            </a-form-item>
            <a-form-item field="password" :rules="[{ required: true, message: '密码是必须的' }]"
              :validate-trigger="['change', 'blur']" hide-label>
              <a-input-password v-model="userInfo.password" placeholder="请输入密码" allow-clear>
                <template #prefix>
                  <icon-lock />
                </template>
              </a-input-password>
            </a-form-item>
            <a-space :size="16" direction="vertical">
              <div class="login-form-password-actions">
                <a-checkbox checked="rememberPassword" :model-value="rememberPassword"
                  @change="setRememberPassword as any">
                  记住密码
                </a-checkbox>
                <a-link>忘记密码？</a-link>
              </div>
              <a-button type="primary" html-type="submit" long :loading="loading">
                登录
              </a-button>
              <a-button type="text" long class="login-form-register-btn">
                注册
              </a-button>
            </a-space>
          </a-form>
        </div>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { http } from '@/api';
import { useUserInfoStore } from '@/stores/userInfo';
import { localStore } from '@/utils/storage';
export default {
  data() {
    return {
      errorMessage: "",
      userInfo: {
        username: "admin",
        password: "admin"
      },
      loading: false,
      rememberPassword: true
    }
  },
  methods: {
    async handleSubmit() {
      this.loading = true;
      const response = await http.v1AuthLoginCreate({
        userName: this.userInfo.username,
        password: this.userInfo.password
      });
      if(response.success) {
        localStore.set("token", response.token);
        await http.v1AuthMeList();
        useUserInfoStore().isLogin = true;
        this.$router.push({ name: 'home' });
      }
      else {
        this.errorMessage = response.message!;
      }
      this.loading = false;
      return false;
    },
    setRememberPassword() {

    }
  }
}
</script>

<style lang="less" scoped>
.container {
  display: flex;
  height: 100vh;

  .content {
    position: relative;
    display: flex;
    flex: 1;
    align-items: center;
    justify-content: center;
    padding-bottom: 40px;
  }
}

.logo {
  position: fixed;
  top: 24px;
  left: 22px;
  z-index: 1;
  display: inline-flex;
  align-items: center;

  &-text {
    margin-right: 4px;
    margin-left: 4px;
    color: var(--color-fill-1);
    font-size: 20px;
  }
}

.login-form {
  &-wrapper {
    width: 320px;
  }

  &-title {
    color: var(--color-text-1);
    font-weight: 500;
    font-size: 24px;
    line-height: 32px;
  }

  &-sub-title {
    color: var(--color-text-3);
    font-size: 16px;
    line-height: 24px;
  }

  &-error-msg {
    height: 32px;
    color: rgb(var(--red-6));
    line-height: 32px;
  }

  &-password-actions {
    display: flex;
    justify-content: space-between;
  }

  &-register-btn {
    color: var(--color-text-3) !important;
  }
}
</style>
