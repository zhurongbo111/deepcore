<template>
  <a-card title="库存管理" class="search-card">
    <a-row>
      <a-col :flex="1">
        <a-form :model="searchModel">
          <a-row :gutter="16">
            <a-col :span="8">
              <a-form-item field="name" label="商品名称">
                <a-input v-model="searchModel.name" placeholder="请输入商品名称"></a-input>
              </a-form-item>
            </a-col>
            <a-col :span="8">
              <a-form-item field="code" label="商品编码">
                <a-input v-model="searchModel.code" placeholder="请输入商品编码"></a-input>
              </a-form-item>
            </a-col>
            <a-col :span="8">
              <a-space>
                <a-button type="primary" @click="handleSearch" :loading="loading">
                  <template #icon>
                    <IconSearch />
                  </template>
                  查询
                </a-button>
                <a-button @click="handleReset">
                  <template #icon>
                    <IconRefresh />
                  </template>
                  重置
                </a-button>
              </a-space>
            </a-col>
          </a-row>
        </a-form>
      </a-col>
    </a-row>
    <a-table :columns="columns" :data="items" :pagination="pagination">
      <template #actions="{ record }">
        <a-button type="primary" size="small" shape="round" @click="viewInventory(record)">查看</a-button>
      </template>
    </a-table>
  </a-card>

  <a-modal v-model:visible="detailVisible" title="库存详情" :width="700" :mask-closable="false" @ok="() => (detailVisible = false)">
    <a-descriptions :data="detailData" layout="horizontal" />
  </a-modal>
</template>

<script lang="ts">
import { IconSearch, IconRefresh } from '@arco-design/web-vue/es/icon';
import type { TableColumnData } from '@arco-design/web-vue';
import { http } from '@/api';
import type { InventoryItemDto } from '@/api/Api';

export default {
  components: {
    IconRefresh,
    IconSearch,
  },
  async created() {
    await this.fetchInventory();
  },
  methods: {
    async fetchInventory() {
      this.loading = true;
      const res = await http.v1InventoriesList({
        Name: this.searchModel.name,
        Code: this.searchModel.code,
      });
      this.items = res.items || [];
      this.loading = false;
    },
    async handleSearch() {
      await this.fetchInventory();
    },
    handleReset() {
      this.searchModel.name = '';
      this.searchModel.code = '';
    },
    async viewInventory(record: InventoryItemDto) {
      const res = await http.v1InventoriesProductDetail(record.productId!);
      if (res.success) {
        this.detailData = [
          { label: '商品名称', value: res.productName },
          { label: '商品编码', value: record.productCode },
          { label: '总库存', value: res.quantity },
          { label: '锁定库存', value: res.lockedQuantity },
          { label: '可用库存', value: res.availableQuantity },
        ];
        this.detailVisible = true;
      }
    },
  },
  data() {
    const columns: TableColumnData[] = [
      { title: '商品编码', dataIndex: 'productCode' },
      { title: '商品名称', dataIndex: 'productName' },
      { title: '总库存', dataIndex: 'quantity' },
      { title: '锁定库存', dataIndex: 'lockedQuantity' },
      { title: '可用库存', dataIndex: 'availableQuantity' },
      { title: '操作', slotName: 'actions' },
    ];
    return {
      searchModel: { name: '', code: '' },
      columns,
      items: [] as InventoryItemDto[],
      loading: false,
      detailVisible: false,
      detailData: [] as Array<{ label: string; value: unknown }>,
      pagination: { pageSize: 6 },
    };
  },
};
</script>

<style lang="less" scoped>
.search-card {
  border: none;
  min-height: 100%;

  .arco-card-header {
    border: none;
  }
}
</style>
