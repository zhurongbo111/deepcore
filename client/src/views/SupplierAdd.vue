<template>
  <a-modal
    :visible="visible"
    @update:visible="$emit('update:visible', $event)"
    title="新增供应商"
    :closable="false"
    :mask-closable="false"
    @before-ok="handleSubmit"
    ok-text="提交"
    cancel-text="取消"
  >
    <a-form :model="supplier">
      <a-form-item required field="name" label="供应商名称">
        <a-input v-model="supplier.name!" :max-length="100" :show-word-limit="true" />
      </a-form-item>
      <a-form-item required field="contact" label="联系人">
        <a-input v-model="supplier.contact!" :max-length="50" :show-word-limit="true" />
      </a-form-item>
      <a-form-item required field="phone" label="联系电话">
        <a-input v-model="supplier.phone!" :max-length="20" :show-word-limit="true" />
      </a-form-item>
      <a-form-item field="address" label="联系地址">
        <a-input v-model="supplier.address!" :max-length="200" :show-word-limit="true" />
      </a-form-item>
      <a-form-item field="remark" label="备注">
        <a-textarea v-model="supplier.remark!" :max-length="500" :show-word-limit="true" />
      </a-form-item>
    </a-form>
  </a-modal>
</template>

<script lang="ts">
import { http } from '@/api';
import type { CreateSupplierRequest } from '@/api/Api';
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
      const res = await http.v1SuppliersCreate(this.supplier);
      if (res.success) {
        message.success('新增供应商成功');
        this.$emit('itemAdded');
        this.$emit('update:visible', false);
      } else {
        message.error(res.message || '新增供应商失败');
      }
      return !!res.success;
    },
  },
  data() {
    return {
      supplier: {
        name: '',
        contact: '',
        phone: '',
        address: '',
        remark: '',
      } as CreateSupplierRequest,
    };
  },
};
</script>
