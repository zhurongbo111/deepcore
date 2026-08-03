<template>
  <a-card title="销售订单" class="search-card">
    <a-row>
      <a-col :flex="1">
        <a-form :model="searchModel">
          <a-row :gutter="16">
            <a-col :span="8">
              <a-form-item field="orderNumber" label="订单号">
                <a-input v-model="searchModel.orderNumber" placeholder="请输入订单号"></a-input>
              </a-form-item>
            </a-col>
            <a-col :span="8">
              <a-form-item field="customerId" label="客户">
                <a-select v-model="searchModel.customerId" :options="customerOptions" placeholder="请选择客户" />
              </a-form-item>
            </a-col>
            <a-col :span="8">
              <a-form-item field="status" label="状态">
                <a-select v-model="searchModel.status" :options="statusOptions" placeholder="请选择状态" />
              </a-form-item>
            </a-col>
          </a-row>
        </a-form>
      </a-col>
    </a-row>
    <a-row style="margin-bottom: 16px">
      <a-col :span="24">
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
          <a-button type="primary" @click="openCreateModal">
            <template #icon>
              <icon-plus />
            </template>
            新建
          </a-button>
        </a-space>
      </a-col>
    </a-row>
    <a-table :columns="columns" :data="orders" :pagination="pagination">
      <template #status="{ record }">
        <a-tag v-if="record.status === 1" color="rgb(var(--green-6))">已生效</a-tag>
        <a-tag v-else-if="record.status === 2" color="rgb(var(--blue-6))">已出库</a-tag>
        <a-tag v-else-if="record.status === 3" color="var(--color-neutral-6)">已取消</a-tag>
        <a-tag v-else color="var(--color-neutral-6)">草稿</a-tag>
      </template>
      <template #actions="{ record }">
        <a-space>
          <a-button type="primary" size="small" shape="round" @click="viewOrder(record)">查看</a-button>
          <a-button v-if="record.status === 0" type="primary" status="success" size="small" shape="round" @click="submitOrder(record)">提交</a-button>
          <a-button v-if="record.status === 1" type="primary" status="danger" size="small" shape="round" @click="cancelOrder(record)">取消</a-button>
          <a-button v-if="record.status === 1" type="primary" status="warning" size="small" shape="round" @click="stockOutOrder(record)">出库</a-button>
        </a-space>
      </template>
    </a-table>
  </a-card>

  <a-modal v-model:visible="createVisible" title="新增销售订单" :width="900" :mask-closable="false" @ok="submitCreate">
    <a-form :model="draftOrder">
      <a-form-item field="customerId" label="客户">
        <a-select v-model="draftOrder.customerId" :options="customerOptions" placeholder="请选择客户" />
      </a-form-item>
      <a-form-item field="remark" label="备注">
        <a-input v-model="draftOrder.remark" placeholder="请输入备注" />
      </a-form-item>
      <a-form-item label="商品明细">
        <a-table :columns="detailColumns" :data="draftOrder.items" size="small" :pagination="false">
          <template #productId="{ record }">
            <a-select v-model="record.productId" :options="productOptions" placeholder="请选择商品" />
          </template>
          <template #quantity="{ record }">
            <a-input-number v-model="record.quantity" :min="1" />
          </template>
          <template #unitPrice="{ record }">
            <a-input-number v-model="record.unitPrice" :min="0" :step="0.01" />
          </template>
          <template #amount="{ record }">
            <span>{{ ((record.quantity || 0) * (record.unitPrice || 0)).toFixed(2) }}</span>
          </template>
          <template #actions="{ record }">
            <a-button type="text" status="danger" @click="removeDetail(record)">删除</a-button>
          </template>
        </a-table>
        <a-button style="margin-top: 8px" @click="addDetail">新增明细</a-button>
      </a-form-item>
    </a-form>
  </a-modal>

  <a-modal v-model:visible="detailVisible" title="销售订单详情" :width="900" :mask-closable="false" @ok="() => (detailVisible = false)">
    <a-descriptions :data="detailData" layout="horizontal" />
    <a-divider />
    <a-table :columns="detailViewColumns" :data="detailItems" size="small" :pagination="false" />
  </a-modal>
</template>

<script lang="ts">
import { IconSearch, IconRefresh, IconPlus } from '@arco-design/web-vue/es/icon';
import type { TableColumnData } from '@arco-design/web-vue';
import { http } from '@/api';
import type { CreateSalesOrderRequest, SalesOrderItemDto, SalesOrderListItemDto, GetSalesOrderByIdResponse, CustomerDto, ProductDto } from '@/api/Api';
import message from '@/utils/message';

export default {
  components: {
    IconRefresh,
    IconSearch,
    IconPlus,
  },
  async created() {
    await Promise.all([this.fetchOrders(), this.fetchCustomers(), this.fetchProducts()]);
  },
  methods: {
    openCreateModal() {
      this.draftOrder = {
        customerId: undefined,
        status: 0,
        items: [],
        remark: '',
      };
      this.createVisible = true;
    },
    addDetail() {
      this.draftOrder.items.push({ productId: undefined as any, quantity: 1, unitPrice: 0, amount: 0 } as SalesOrderItemDto);
    },
    removeDetail(record: SalesOrderItemDto) {
      this.draftOrder.items = this.draftOrder.items.filter((item) => item !== record);
    },
    async submitCreate() {
      const payload: CreateSalesOrderRequest = {
        customerId: this.draftOrder.customerId,
        status: this.draftOrder.status,
        items: this.draftOrder.items.map((item) => ({
          productId: item.productId,
          quantity: item.quantity,
          unitPrice: item.unitPrice,
          amount: (item.quantity || 0) * (item.unitPrice || 0),
        })),
        remark: this.draftOrder.remark,
      } as any;
      const res = await http.v1SalesOrdersCreate(payload as any);
      if (res.success) {
        message.success('新增销售订单成功');
        this.createVisible = false;
        await this.fetchOrders();
      } else {
        message.error(res.message || '新增销售订单失败');
      }
    },
    async viewOrder(record: SalesOrderListItemDto) {
      const res = await http.v1SalesOrdersDetail(record.id!);
      if (res.success) {
        this.detailData = [
          { label: '订单号', value: res.orderNumber },
          { label: '客户', value: this.customerMap.get(record.customerId as any) || '-' },
          { label: '状态', value: this.getStatusLabel(res.status) },
          { label: '总金额', value: res.totalAmount },
        ];
        this.detailItems = res.items || [];
        this.detailVisible = true;
      } else {
        message.error(res.message || '获取详情失败');
      }
    },
    async submitOrder(record: SalesOrderListItemDto) {
      const res = await http.v1SalesOrdersSubmitCreate(record.id!);
      if (res.success) {
        message.success('提交成功');
        await this.fetchOrders();
      } else {
        message.error(res.message || '提交失败');
      }
    },
    async cancelOrder(record: SalesOrderListItemDto) {
      const res = await http.v1SalesOrdersCancelCreate(record.id!);
      if (res.success) {
        message.success('取消成功');
        await this.fetchOrders();
      } else {
        message.error(res.message || '取消失败');
      }
    },
    async stockOutOrder(record: SalesOrderListItemDto) {
      const res = await http.v1SalesOrdersStockOutCreate(record.id!);
      if (res.success) {
        message.success('出库成功');
        await this.fetchOrders();
      } else {
        message.error(res.message || '出库失败');
      }
    },
    async fetchOrders() {
      this.loading = true;
      const res = await http.v1SalesOrdersList({
        OrderNumber: this.searchModel.orderNumber,
        CustomerId: this.searchModel.customerId,
        Status: this.searchModel.status,
      });
      this.orders = res.items || [];
      this.loading = false;
    },
    async fetchCustomers() {
      const res = await http.v1CustomersList({});
      this.customerOptions = (res.items || []).map((item: CustomerDto) => ({ label: item.name, value: item.id }));
      this.customerMap = new Map((res.items || []).map((item: CustomerDto) => [item.id, item.name]));
    },
    async fetchProducts() {
      const res = await http.v1ProductsList({});
      this.productOptions = (res.items || []).map((item: ProductDto) => ({ label: `${item.code} - ${item.name}`, value: item.id }));
    },
    handleReset() {
      this.searchModel.orderNumber = '';
      this.searchModel.customerId = undefined;
      this.searchModel.status = undefined;
    },
    handleSearch() {
      return this.fetchOrders();
    },
    getStatusLabel(status: number | undefined) {
      switch (status) {
        case 1:
          return '已生效';
        case 2:
          return '已出库';
        case 3:
          return '已取消';
        default:
          return '草稿';
      }
    },
  },
  data() {
    const columns: TableColumnData[] = [
      { title: '订单号', dataIndex: 'orderNumber' },
      { title: '客户', dataIndex: 'customerName' },
      { title: '金额', dataIndex: 'totalAmount' },
      { title: '状态', slotName: 'status' },
      { title: '操作', slotName: 'actions' },
    ];
    const detailColumns: TableColumnData[] = [
      { title: '商品', slotName: 'productId' },
      { title: '数量', slotName: 'quantity' },
      { title: '单价', slotName: 'unitPrice' },
      { title: '金额', slotName: 'amount' },
      { title: '操作', slotName: 'actions' },
    ];
    const detailViewColumns: TableColumnData[] = [
      { title: '商品', dataIndex: 'productName' },
      { title: '数量', dataIndex: 'quantity' },
      { title: '单价', dataIndex: 'unitPrice' },
      { title: '金额', dataIndex: 'amount' },
    ];
    return {
      searchModel: { orderNumber: '', customerId: undefined as number | undefined, status: undefined as number | undefined },
      columns,
      detailColumns,
      detailViewColumns,
      orders: [] as SalesOrderListItemDto[],
      customerOptions: [] as Array<{ label: string; value: number | undefined }>,
      productOptions: [] as Array<{ label: string; value: number | undefined }>,
      statusOptions: [
        { label: '草稿', value: 0 },
        { label: '已生效', value: 1 },
        { label: '已出库', value: 2 },
        { label: '已取消', value: 3 },
      ],
      loading: false,
      createVisible: false,
      detailVisible: false,
      detailData: [] as Array<{ label: string; value: unknown }>,
      detailItems: [] as GetSalesOrderByIdResponse['items'],
      customerMap: new Map<number | undefined, string>(),
      draftOrder: { customerId: undefined as number | undefined, status: 0, items: [] as SalesOrderItemDto[], remark: '' },
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
