<template>
  <a-modal :visible="visible" @update:visible="$emit('update:visible', $event)" title="修改商品" :closable="false"
    :mask-closable="false" @before-ok="handleSubmit" ok-text="提交" cancel-text="取消">
    <a-form :model="product">
      <a-form-item required field="code" disabled label="商品编码">
        <a-input v-model="product.code!"/>
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
    </a-form>
  </a-modal>
</template>
<script lang="ts">
import { http } from '@/api';
import type { ProductDto } from '@/api/Api';
import type { PropType } from 'vue';

export default {
  props: {
    visible: {
      type: Boolean,
      default: false
    },
    record: {
      type: Object as PropType<ProductDto>,
      required: true
    }
  },
  emits: ["update:visible", "itemUpdated"],
  methods: {
    async handleSubmit() {
      console.log(this.product);
      const res = await http.v1ProductsUpdate(this.record.id!, this.product);
      if(res.success) {
        this.$emit("itemUpdated");
      }

      return res.success;
    },
  },
  watch: {
    record(newRecord) {
      this.product = { ...newRecord };
    }
  },
  data() {
    return {
      product: {
        ...this.record
      }
    }
  }
}
</script>
