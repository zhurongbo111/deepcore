<template>
  <a-card title="客户列表" class="search-card">
    <a-row>
      <a-col :flex="1">
        <a-form :model="searchModel">
          <a-row :gutter="16">
            <a-col :span="8">
              <a-form-item field="name" label="客户名称">
                <a-input v-model="searchModel.name" placeholder="请输入客户名称"></a-input>
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
          <a-button type="primary" @click="handleCustomerSearch" :loading="loading">
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
          <a-button type="primary" @click="addCustomer">
            <template #icon>
              <icon-plus />
            </template>
            新建
          </a-button>
        </a-space>
      </a-col>
    </a-row>
    <a-table :columns="columns" :data="customers" :pagination="pagination">
      <template #status="{ record }">
        <a-tag v-if="(record as any).status === 1" color="rgb(var(--green-6))">已启用</a-tag>
        <a-tag v-else color="var(--color-neutral-6)">已禁用</a-tag>
      </template>
      <template #actions="{ record }">
        <a-space>
          <a-button type="primary" status="warning" size="small" shape="round" @click="handleEditCustomer(record)">
            <template #icon>
              <icon-edit />
            </template>
            <template #default>编辑</template>
          </a-button>
          <a-button v-if="(record as any).status === 0" type="primary" status="success" size="small" shape="round" @click="handleUpdateStatus(record, 1)">
            <template #icon>
              <icon-check />
            </template>
            <template #default>启用</template>
          </a-button>
          <a-button v-if="(record as any).status === 1" type="primary" status="danger" size="small" shape="round" @click="handleUpdateStatus(record, 0)">
            <template #icon>
              <icon-close />
            </template>
            <template #default>禁用</template>
          </a-button>
        </a-space>
      </template>
    </a-table>
  </a-card>
  <CustomerAdd v-model:visible="customerAddVisible" @item-added="customerAdded"></CustomerAdd>
  <CustomerEdit v-model:visible="customerEditVisible" :record="editRecord" @item-updated="customerUpdated"></CustomerEdit>
</template>

<script lang="ts">
import { IconSearch, IconRefresh, IconPlus, IconEdit, IconCheck, IconClose } from '@arco-design/web-vue/es/icon';
import type { TableColumnData } from '@arco-design/web-vue';
import { http } from '@/api';
import type { CustomerDto } from '@/api/Api';
import CustomerAdd from './CustomerAdd.vue';
import CustomerEdit from './CustomerEdit.vue';
import message from '@/utils/message';

export default {
  components: {
    IconRefresh,
    IconSearch,
    IconPlus,
    IconEdit,
    IconCheck,
    IconClose,
    CustomerAdd,
    CustomerEdit,
  },
  async created() {
    await this.fetchCustomers();
  },
  methods: {
    addCustomer() {
      this.customerAddVisible = true;
    },
    handleReset() {
      this.searchModel.name = '';
      this.searchModel.contact = '';
      this.searchModel.phone = '';
    },
    async handleCustomerSearch() {
      await this.fetchCustomers();
    },
    handleEditCustomer(record: CustomerDto) {
      this.editRecord = record;
      this.customerEditVisible = true;
    },
    async handleUpdateStatus(record: CustomerDto, status: number) {
      const res = await http.v1CustomersStatusUpdate(record.id!, { status });
      if (res.success) {
        (record as CustomerDto & { status?: number }).status = status;
        message.success('状态更新成功');
      } else {
        message.error(res.message || '状态更新失败');
      }
    },
    async customerAdded() {
      await this.fetchCustomers();
    },
    async customerUpdated() {
      await this.fetchCustomers();
    },
    async fetchCustomers() {
      this.loading = true;
      const res = await http.v1CustomersList({
        Name: this.searchModel.name,
        Contact: this.searchModel.contact,
        Phone: this.searchModel.phone,
      });
      this.customers = res.items || [];
      this.loading = false;
    },
  },
  data() {
    const columns: TableColumnData[] = [
      {
        title: '客户名称',
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
      customers: [] as CustomerDto[],
      pagination: {
        pageSize: 6,
      },
      customerAddVisible: false,
      customerEditVisible: false,
      loading: false,
      editRecord: {} as CustomerDto,
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
