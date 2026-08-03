<template>
  <a-card title="供应商列表" class="search-card">
    <a-row>
      <a-col :flex="1">
        <a-form :model="searchModel">
          <a-row :gutter="16">
            <a-col :span="8">
              <a-form-item field="name" label="供应商名称">
                <a-input v-model="searchModel.name" placeholder="请输入供应商名称"></a-input>
              </a-form-item>
            </a-col>
            <a-col :span="8">
              <a-form-item field="contact" label="联系人">
                <a-input v-model="searchModel.contact" placeholder="请输入联系人"></a-input>
              </a-form-item>
            </a-col>
            <a-col :span="8">
              <a-form-item field="phone" label="联系电话">
                <a-input v-model="searchModel.phone" placeholder="请输入手机号"></a-input>
              </a-form-item>
            </a-col>
          </a-row>
        </a-form>
      </a-col>
    </a-row>
    <a-row style="margin-bottom: 16px">
      <a-col :span="24">
        <a-space>
          <a-button type="primary" @click="handleSupplierSearch" :loading="loading">
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
          <a-button type="primary" @click="addSupplier">
            <template #icon>
              <icon-plus />
            </template>
            新建
          </a-button>
        </a-space>
      </a-col>
    </a-row>
    <a-table :columns="columns" :data="suppliers" :pagination="pagination">
      <template #status="{ record }">
        <a-tag v-if="record.status === 1" color="rgb(var(--green-6))">已启用</a-tag>
        <a-tag v-else color="var(--color-neutral-6)">已禁用</a-tag>
      </template>
      <template #actions="{ record }">
        <a-space>
          <a-button type="primary" status="warning" size="small" shape="round" @click="handleEditSupplier(record)">
            <template #icon>
              <icon-edit />
            </template>
            <template #default>编辑</template>
          </a-button>
          <a-button v-if="record.status === 0" type="primary" status="success" size="small" shape="round" @click="handleUpdateStatus(record, 1)">
            <template #icon>
              <icon-check />
            </template>
            <template #default>启用</template>
          </a-button>
          <a-button v-if="record.status === 1" type="primary" status="danger" size="small" shape="round" @click="handleUpdateStatus(record, 0)">
            <template #icon>
              <icon-close />
            </template>
            <template #default>禁用</template>
          </a-button>
        </a-space>
      </template>
    </a-table>
  </a-card>
  <SupplierAdd v-model:visible="supplierAddVisible" @item-added="supplierAdded"></SupplierAdd>
  <SupplierEdit v-model:visible="supplierEditVisible" :record="editRecord" @item-updated="supplierUpdated"></SupplierEdit>
</template>

<script lang="ts">
import { IconSearch, IconRefresh, IconPlus, IconEdit, IconCheck, IconClose } from '@arco-design/web-vue/es/icon';
import type { TableColumnData } from '@arco-design/web-vue';
import { http } from '@/api';
import type { SupplierDto } from '@/api/Api';
import SupplierAdd from './SupplierAdd.vue';
import SupplierEdit from './SupplierEdit.vue';
import message from '@/utils/message';

export default {
  components: {
    IconRefresh,
    IconSearch,
    IconPlus,
    IconEdit,
    IconCheck,
    IconClose,
    SupplierAdd,
    SupplierEdit,
  },
  async created() {
    await this.fetchSuppliers();
  },
  methods: {
    addSupplier() {
      this.supplierAddVisible = true;
    },
    handleReset() {
      this.searchModel.name = '';
      this.searchModel.contact = '';
      this.searchModel.phone = '';
    },
    async handleSupplierSearch() {
      await this.fetchSuppliers();
    },
    handleEditSupplier(record: SupplierDto) {
      this.editRecord = record;
      this.supplierEditVisible = true;
    },
    async handleUpdateStatus(record: SupplierDto, status: number) {
      const res = await http.v1SuppliersStatusUpdate(record.id!, { status });
      if (res.success) {
        record.status = status;
        message.success('状态更新成功');
      } else {
        message.error(res.message || '状态更新失败');
      }
    },
    async supplierAdded() {
      await this.fetchSuppliers();
    },
    async supplierUpdated() {
      await this.fetchSuppliers();
    },
    async fetchSuppliers() {
      this.loading = true;
      const res = await http.v1SuppliersList({
        Name: this.searchModel.name,
        Contact: this.searchModel.contact,
        Phone: this.searchModel.phone,
      });
      this.suppliers = res.items || [];
      this.loading = false;
    },
  },
  data() {
    const columns: TableColumnData[] = [
      {
        title: '供应商名称',
        dataIndex: 'name',
      },
      {
        title: '联系人',
        dataIndex: 'contact',
      },
      {
        title: '联系电话',
        dataIndex: 'phone',
      },
      {
        title: '状态',
        slotName: 'status',
      },
      {
        title: '操作',
        slotName: 'actions',
      },
    ];
    return {
      searchModel: {
        name: '' as string,
        contact: '' as string,
        phone: '' as string,
      },
      columns,
      suppliers: [] as SupplierDto[],
      pagination: {
        pageSize: 6,
      },
      supplierAddVisible: false,
      supplierEditVisible: false,
      loading: false,
      editRecord: {} as SupplierDto,
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
