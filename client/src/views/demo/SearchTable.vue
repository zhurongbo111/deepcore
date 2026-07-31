<template>
  <a-card title="查询表格" class="search-card">
    <a-row>
      <a-col :flex="1">
        <a-form :model="formModel">
          <a-row :gutter="16">
            <a-col :span="8">
              <a-form-item label="编号">
                <a-input placeholder="请输入"></a-input>
              </a-form-item>
            </a-col>
            <a-col :span="8">
              <a-form-item label="编号名称">
                <a-input placeholder="请输入"></a-input>
              </a-form-item>
            </a-col>
            <a-col :span="8">
              <a-form-item field="filterType" label="状态">
                <a-select :options="[{ label: '启用', value: 1 }, { label: '停用', value: 2 }]"
                  placeholder="请选择状态" />
              </a-form-item>
            </a-col>
            <a-col :span="8">
              <a-form-item label="编号名称">
                <a-input placeholder="请输入"></a-input>
              </a-form-item>
            </a-col>
            <a-col :span="8">
              <a-form-item label="时间">
                <a-range-picker />
              </a-form-item>
            </a-col>
            <a-col :span="8">
              <a-form-item label="状态过滤">
                <a-input placeholder="请输入"></a-input>
              </a-form-item>
            </a-col>
          </a-row>
        </a-form>
      </a-col>
      <a-divider direction="vertical" style="height: 82px;" />
      <a-col flex="86px" style="text-align: right;">
        <a-space direction="vertical" :size="18">
          <a-button type="primary">
            <template #icon>
              <IconSearch />
            </template>
            查询
          </a-button>
          <a-button>
            <template #icon>
              <IconRefresh />
            </template>
            重置
          </a-button>
        </a-space>
      </a-col>
    </a-row>
    <a-divider style="margin-top: 0" />
    <a-row style="margin-bottom: 16px">
      <a-col :span="12">
        <a-space>
          <a-button type="primary">
            <template #icon>
              <icon-plus />
            </template>
            新建
          </a-button>
          <a-upload action="/">
            <template #upload-button>
              <a-button>
                上传
              </a-button>
            </template>
          </a-upload>
        </a-space>
      </a-col>
      <a-col :span="12" style="display: flex; align-items: center; justify-content: end">
        <a-button>
          <template #icon>
            <icon-download />
          </template>
          下载
        </a-button>
        <a-tooltip content="刷新">
          <div class="action-icon"><icon-refresh size="18" /></div>
        </a-tooltip>
      </a-col>
    </a-row>
    <a-table :columns="columns" :data="data" :pagination="pagination">

    </a-table>
  </a-card>
</template>

<script lang="ts">
import { IconSearch, IconRefresh, IconPlus, IconDownload } from '@arco-design/web-vue/es/icon';
import type { TableColumnData } from '@arco-design/web-vue';

export default {
  components: {
    IconRefresh,
    IconSearch,
    IconPlus,
    IconDownload
  },
  data() {
    const columns: TableColumnData[] = [
      {
        title: 'Name',
        dataIndex: 'name',
      },
      {
        title: 'Salary',
        dataIndex: 'salary',
      },
      {
        title: 'Address',
        dataIndex: 'address',
      },
      {
        title: 'Email',
        dataIndex: 'email',
      },
    ];
    const data = [{
      key: '1',
      name: 'Jane Doe',
      salary: 23000,
      address: '32 Park Road, London',
      email: 'jane.doe@example.com'
    }, {
      key: '2',
      name: 'Alisa Ross',
      salary: 25000,
      address: '35 Park Road, London',
      email: 'alisa.ross@example.com'
    }, {
      key: '3',
      name: 'Kevin Sandra',
      salary: 22000,
      address: '31 Park Road, London',
      email: 'kevin.sandra@example.com'
    }, {
      key: '4',
      name: 'Ed Hellen',
      salary: 17000,
      address: '42 Park Road, London',
      email: 'ed.hellen@example.com'
    }, {
      key: '5',
      name: 'William Smith',
      salary: 27000,
      address: '62 Park Road, London',
      email: 'william.smith@example.com'
    }];
    return {
      formModel: {},
      columns,
      data: [
        ...data,
        ...data,
        ...data,
        ...data
      ],
      pagination: {
        pageSize: 6
      }
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
