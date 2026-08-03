<template>
  <a-modal
    :visible="visible"
    @update:visible="$emit('update:visible', $event)"
    title="新增用户"
    :closable="false"
    :mask-closable="false"
    @before-ok="handleSubmit"
    ok-text="提交"
    cancel-text="取消"
  >
    <a-form :model="user">
      <a-form-item required field="userName" label="用户名">
        <a-input v-model="user.userName" :max-length="50" :show-word-limit="true" />
      </a-form-item>
      <a-form-item field="fullName" label="姓名">
        <a-input v-model="user.fullName" :max-length="100" :show-word-limit="true" />
      </a-form-item>
      <a-form-item field="phone" label="手机号">
        <a-input v-model="user.phone" :max-length="20" :show-word-limit="true" />
      </a-form-item>
      <a-form-item field="email" label="邮箱">
        <a-input v-model="user.email" :max-length="100" :show-word-limit="true" />
      </a-form-item>
    </a-form>
  </a-modal>
</template>

<script lang="ts">
import { http } from '@/api';
import type { CreateUserRequest } from '@/api/Api';
import message from '@/utils/message';

export default {
  props: {
    visible: {
      type: Boolean,
      default: false,
    },
  },
  emits: ['update:visible', 'itemAdded'],
  methods: {
    async handleSubmit() {
      const res = await http.v1UsersCreate(this.user);
      if (res.success) {
        message.success('新增用户成功');
        this.$emit('itemAdded');
        this.$emit('update:visible', false);
      } else {
        message.error(res.message || '新增用户失败');
      }
      return !!res.success;
    },
  },
  data() {
    return {
      user: {
        userName: '',
        fullName: '',
        phone: '',
        email: '',
      } as CreateUserRequest,
    };
  },
};
</script>
