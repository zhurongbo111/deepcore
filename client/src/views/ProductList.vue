<template>
  <a-card title="商品列表" class="search-card">
    <a-row>
      <a-col :flex="1">
        <a-form :model="searchModel">
          <a-row :gutter="16">
            <a-col :span="8">
              <a-form-item field="keywords" label="商品">
                <a-input v-model="searchModel.keywords" placeholder="请输入商品编号/名称"></a-input>
              </a-form-item>
            </a-col>
            <a-col :span="8">
              <a-form-item field="status" label="状态">
                <a-select v-model="searchModel.status" :options="[{ label: '启用', value: 1 }, { label: '停用', value: 0 }]"
                  placeholder="请选择状态" />
              </a-form-item>
            </a-col>
            <a-col :span="8">
              <a-space direction="horizontal" :size="18">
                <a-button type="primary" @click="handleProductSearch" :loading="productLoading">
                  <template #icon>
                    <IconSearch />
                  </template>
                  查询
                </a-button>
                <a-button @click="handleRseset">
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
    <a-divider style="margin-top: 0" />
    <a-row style="margin-bottom: 16px">
      <a-col :span="12">
        <a-space>
          <a-button type="primary" @click="addProduct">
            <template #icon>
              <icon-plus />
            </template>
            新建
          </a-button>
        </a-space>
      </a-col>
    </a-row>
    <a-table :columns="columns" :data="products" :pagination="pagination">
      <template #status="{ record }">
        <a-tag v-if="record.status == 1" color="rgb(var(--green-6))">已启用</a-tag>
        <a-tag v-else color="var(--color-neutral-6)">已禁用</a-tag>
      </template>
      <template #actions="{ record }">
        <a-space>
          <a-button type="primary" status="warning" size="small" shape="round" @click="handleEditProduct(record)">
            <template #icon>
              <icon-edit />
            </template>
            <template #default>编辑</template>
          </a-button>
          <a-button v-if="record.status == 0" type="primary" status="success" size="small" shape="round"
            @click="handleUpdateStatus(record, 1)">
            <template #icon>
              <icon-check />
            </template>
            <template #default>启用</template>
          </a-button>
          <a-button v-if="record.status == 1" type="primary" status="danger" size="small" shape="round"
            @click="handleUpdateStatus(record, 0)">
            <template #icon>
              <icon-close />
            </template>
            <template #default>禁用</template>
          </a-button>
        </a-space>

      </template>
    </a-table>
  </a-card>
  <ProductAdd v-model:visible="productAddvisible" @item-added="productAdded"></ProductAdd>
  <ProductEdit v-model:visible="productEditvisible" :record="editRecord" @item-updated="productUpdated"></ProductEdit>
</template>

<script lang="ts">
import { IconSearch, IconRefresh, IconPlus, IconEdit, IconCheck, IconClose } from '@arco-design/web-vue/es/icon';
import type { TableColumnData } from '@arco-design/web-vue';
import { http } from '@/api';
import { type ProductDto } from '@/api/Api';
import ProductAdd from './ProductAdd.vue';
import ProductEdit from './ProductEdit.vue';

export default {
  components: {
    IconRefresh,
    IconSearch,
    IconPlus,
    IconEdit,
    IconCheck,
    IconClose,
    ProductAdd,
    ProductEdit
  },
  async created() {
    await this.fetchProducts();
  },
  methods: {
    addProduct() {
      this.productAddvisible = true;
    },
    handleRseset() {
      this.searchModel.keywords = "";
      this.searchModel.status = undefined;
    },
    async handleProductSearch() {
      await this.fetchProducts();
    },
    handleEditProduct(record: ProductDto) {
      this.editRecord = record;
      this.productEditvisible = true;
    },
    async handleUpdateStatus(record: ProductDto, status: number) {
      const res = await http.v1ProductsStatusPartialUpdate(record.id!, { status: status });
      if(res.success) {
        record.status = status;
      }
    },
    async productAdded() {
      await this.fetchProducts();
    },
    async productUpdated() {
      await this.fetchProducts();
    },
    async fetchProducts() {
      this.productLoading = true;
      const products = await http.v1ProductsList({ KeyWord: this.searchModel.keywords, Status: this.searchModel.status });
      this.products = products.items || [];
      this.productLoading = false;
    }
  },
  data() {
    const columns: TableColumnData[] = [
      {
        title: '商品编号',
        dataIndex: 'code',
      },
      {
        title: '商品名称',
        dataIndex: 'name',
      },
      {
        title: '采购价',
        dataIndex: 'purchasePrice',
      },
      {
        title: '销售价',
        dataIndex: 'salePrice',
      },
      {
        title: '状态',
        slotName: 'status',
      },
      {
        title: '操作',
        slotName: 'actions'
      }
    ];
    return {
      searchModel: { keywords: "" as string, status: undefined as number | undefined },
      columns,
      products: [] as ProductDto[],
      pagination: {
        pageSize: 6
      },
      productAddvisible: false,
      productLoading: false,
      productEditvisible: false,
      editRecord: {} as ProductDto
    }
  }
}
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
