<template>
  <a-modal
    :visible="visible"
    @update:visible="$emit('update:visible', $event)"
    title="修改客户"
    :closable="false"
    :mask-closable="false"
    @before-ok="handleSubmit"
    ok-text="提交"
    cancel-text="取消"
  >
    <a-form :model="formModel">
      <a-form-item required field="name" label="客户名称">
        <a-input v-model="formModel.name!" :max-length="100" :show-word-limit="true" />
      </a-form-item>
      <a-form-item required field="contact" label="联系人">
        <a-input v-model="formModel.contact!" :max-length="50" :show-word-limit="true" />
      </a-form-item>
      <a-form-item required field="phone" label="联系电话">
        <a-input v-model="formModel.phone!" :max-length="20" :show-word-limit="true" />
      </a-form-item>
      <a-form-item field="address" label="联系地址">
        <a-input :model-value="formModel.address ?? ''" @update:model-value="(value: string) => { formModel.address = value }" :max-length="200" :show-word-limit="true" />
      </a-form-item>
      <a-form-item field="remark" label="备注">
        <a-textarea :model-value="formModel.remark ?? ''" @update:model-value="(value: string) => { formModel.remark = value }" :max-length="500" :show-word-limit="true" />
      </a-form-item>
    </a-form>
  </a-modal>
</template>

<script lang="ts">
import { http } from '@/api';
import type { CustomerDto } from '@/api/Api';
import message from '@/utils/message';
import type { PropType } from 'vue';

export default {
  props: {
    visible: {
      type: Boolean,
      default: false,
    },
    record: {
      type: Object as PropType<CustomerDto>,
      required: true,
    },
  },
  emits: ['update:visible', 'itemUpdated'],
  methods: {
    async handleSubmit() {
      const payload = {
        ...this.formModel,
      };
      const res = await http.v1CustomersUpdate(this.record.id!, payload);
      if (res.success) {
        message.success('修改客户成功');
        this.$emit('itemUpdated');
        this.$emit('update:visible', false);
      } else {
        message.error(res.message || '修改客户失败');
      }
      return !!res.success;
    },
  },
  watch: {
    record: {
      handler(newRecord) {
        this.formModel = {
          id: newRecord.id,
          name: newRecord.name ?? '',
          contact: newRecord.contact ?? '',
          phone: newRecord.phone ?? '',
          address: (newRecord as any).address ?? '',
          remark: (newRecord as any).remark ?? '',
        } as any;
      },
      immediate: true,
    },
  },
  data(): { formModel: any } {
    return {
      formModel: {
        name: '',
        contact: '',
        phone: '',
        address: '',
        remark: '',
      } as any,
    };
  },
};
</script>
