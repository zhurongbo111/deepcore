<template>
  <a-modal
    :visible="visible"
    @update:visible="$emit('update:visible', $event)"
    title="修改用户"
    :closable="false"
    :mask-closable="false"
    @before-ok="handleSubmit"
    ok-text="提交"
    cancel-text="取消"
  >
    <a-form :model="formModel">
      <a-form-item field="userName" label="用户名">
        <a-input :model-value="formModel.userName ?? ''" disabled />
      </a-form-item>
      <a-form-item field="fullName" label="姓名">
        <a-input :model-value="formModel.fullName ?? ''" @update:model-value="(value: string) => { formModel.fullName = value }" :max-length="100" :show-word-limit="true" />
      </a-form-item>
      <a-form-item field="phone" label="手机号">
        <a-input :model-value="formModel.phone ?? ''" @update:model-value="(value: string) => { formModel.phone = value }" :max-length="20" :show-word-limit="true" />
      </a-form-item>
      <a-form-item field="email" label="邮箱">
        <a-input :model-value="formModel.email ?? ''" @update:model-value="(value: string) => { formModel.email = value }" :max-length="100" :show-word-limit="true" />
      </a-form-item>
    </a-form>
  </a-modal>
</template>

<script lang="ts">
import { http } from '@/api';
import type { UserListItemDto } from '@/api/Api';
import message from '@/utils/message';
import type { PropType } from 'vue';

export default {
  props: {
    visible: {
      type: Boolean,
      default: false,
    },
    record: {
      type: Object as PropType<UserListItemDto>,
      required: true,
    },
  },
  emits: ['update:visible', 'itemUpdated'],
  methods: {
    async handleSubmit() {
      const res = await http.v1UsersUpdate(this.record.id!, {
        fullName: this.formModel.fullName,
        phone: this.formModel.phone,
        email: this.formModel.email,
      });
      if (res.success) {
        message.success('修改用户成功');
        this.$emit('itemUpdated');
        this.$emit('update:visible', false);
      } else {
        message.error(res.message || '修改用户失败');
      }
      return !!res.success;
    },
  },
  watch: {
    record: {
      handler(newRecord) {
        this.formModel = {
          id: newRecord.id,
          userName: newRecord.userName ?? '',
          fullName: newRecord.realName ?? '',
          phone: newRecord.phone ?? '',
          email: newRecord.email ?? '',
        };
      },
      immediate: true,
    },
  },
  data() {
    return {
      formModel: {
        userName: '',
        fullName: '',
        phone: '',
        email: '',
      },
    };
  },
};
</script>
