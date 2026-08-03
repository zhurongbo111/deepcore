<template>
  <a-card title="用户列表" class="search-card">
    <a-row>
      <a-col :flex="1">
        <a-form :model="searchModel">
          <a-row :gutter="16">
            <a-col :span="8">
              <a-form-item field="name" label="用户名">
                <a-input v-model="searchModel.name" placeholder="请输入用户名"></a-input>
              </a-form-item>
            </a-col>
            <a-col :span="8">
              <a-form-item field="phone" label="手机号">
                <a-input v-model="searchModel.phone" placeholder="请输入手机号"></a-input>
              </a-form-item>
            </a-col>
            <a-col :span="8">
              <a-space>
                <a-button type="primary" @click="handleUserSearch" :loading="loading">
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
                <a-button type="primary" @click="addUser">
                  <template #icon>
                    <icon-plus />
                  </template>
                  新建
                </a-button>
              </a-space>
            </a-col>
          </a-row>
        </a-form>
      </a-col>
    </a-row>
    <a-table :columns="columns" :data="users" :pagination="pagination">
      <template #status="{ record }">
        <a-tag v-if="record.status === 1" color="rgb(var(--green-6))">已启用</a-tag>
        <a-tag v-else color="var(--color-neutral-6)">已禁用</a-tag>
      </template>
      <template #actions="{ record }">
        <a-space>
          <a-button type="primary" status="warning" size="small" shape="round" @click="handleEditUser(record)">
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
  <UserAdd v-model:visible="userAddVisible" @item-added="userAdded"></UserAdd>
  <UserEdit v-model:visible="userEditVisible" :record="editRecord" @item-updated="userUpdated"></UserEdit>
</template>

<script lang="ts">
import { IconSearch, IconRefresh, IconPlus, IconEdit, IconCheck, IconClose } from '@arco-design/web-vue/es/icon';
import type { TableColumnData } from '@arco-design/web-vue';
import { http } from '@/api';
import type { UserListItemDto } from '@/api/Api';
import UserAdd from './UserAdd.vue';
import UserEdit from './UserEdit.vue';
import message from '@/utils/message';

export default {
  components: {
    IconRefresh,
    IconSearch,
    IconPlus,
    IconEdit,
    IconCheck,
    IconClose,
    UserAdd,
    UserEdit,
  },
  async created() {
    await this.fetchUsers();
  },
  methods: {
    addUser() {
      this.userAddVisible = true;
    },
    handleReset() {
      this.searchModel.name = '';
      this.searchModel.phone = '';
    },
    async handleUserSearch() {
      await this.fetchUsers();
    },
    handleEditUser(record: UserListItemDto) {
      this.editRecord = record;
      this.userEditVisible = true;
    },
    async handleUpdateStatus(record: UserListItemDto, status: number) {
      const res = await http.v1UsersStatusPartialUpdate(record.id!, { status });
      if (res.success) {
        record.status = status;
        message.success('状态更新成功');
      } else {
        message.error(res.message || '状态更新失败');
      }
    },
    async userAdded() {
      await this.fetchUsers();
    },
    async userUpdated() {
      await this.fetchUsers();
    },
    async fetchUsers() {
      this.loading = true;
      const res = await http.v1UsersList({
        Name: this.searchModel.name,
        Phone: this.searchModel.phone,
      });
      this.users = res.items || [];
      this.loading = false;
    },
  },
  data() {
    const columns: TableColumnData[] = [
      {
        title: '用户名',
        dataIndex: 'userName',
      },
      {
        title: '姓名',
        dataIndex: 'realName',
      },
      {
        title: '手机号',
        dataIndex: 'phone',
      },
      {
        title: '邮箱',
        dataIndex: 'email',
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
        phone: '' as string,
      },
      columns,
      users: [] as UserListItemDto[],
      pagination: {
        pageSize: 6,
      },
      userAddVisible: false,
      userEditVisible: false,
      loading: false,
      editRecord: {} as UserListItemDto,
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
