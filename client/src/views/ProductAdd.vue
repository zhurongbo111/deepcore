<template>
  <a-modal :visible="visible" @update:visible="$emit('update:visible', $event)" title="新增商品" :closable="false"
    :mask-closable="false" @before-ok="handleSubmit" ok-text="提交" cancel-text="取消">
    <a-form :model="product">
      <a-form-item required field="code" label="商品编码">
        <a-input v-model="product.code!" :max-length="50" :show-word-limit="true" />
      </a-form-item>
      <a-form-item required field="name" label="商品名称">
        <a-input v-model="product.name!" :max-length="100" :show-word-limit="true" />
      </a-form-item>
      <a-form-item required field="purchasePrice" label="采购价">
        <a-input-number v-model="product.purchasePrice!" :min="0" :step="0.01" />
      </a-form-item>
      <a-form-item required field="salePrice" label="销售价">
        <a-input-number v-model="product.salePrice!" :min="0" :step="0.01" />
      </a-form-item>
      <a-form-item field="status" label="是否启用">
        <a-select v-model="product.status">
          <a-option :value="0">禁用</a-option>
          <a-option :value="1">启用</a-option>
        </a-select>
      </a-form-item>
    </a-form>
  </a-modal>
</template>
<script lang="ts">
import { http } from '@/api';
import type { CreateProductRequest } from '@/api/Api';
import message from '@/utils/message';

export default {
  props: {
    visible: {
      type: Boolean,
      default: false
    }
  },
  emits: ["update:visible", "itemAdded"],
  methods: {
    async handleSubmit() {
      console.log(this.product);
      const res = await http.v1ProductsCreate(this.product);
      if(res.codeExist) {
        message.warn("此商品编码也存在");
      }

      if(res.success) {
        this.$emit("itemAdded");
      }
      return res.success;
    },
  },
  watch: {
  },
  data() {
    return {
      product: {
        code: '',
        name: "",
        salePrice: 0.00,
        status: 1,
        purchasePrice: 0.00,
        unit: '个'
      } as CreateProductRequest
    }
  }
}
</script>
