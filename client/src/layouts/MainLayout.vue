<template>
  <a-layout class="layout">
    <a-layout-header class="layout-header">
      <LayoutHeader></LayoutHeader>
    </a-layout-header>
    <a-layout-sider class="layout-sider" collapsible>
      <a-menu :style="{ width: '100%', height: '100%' }" @menu-item-click="onClickMenuItem">
        <a-menu-item key="home">
          <IconDashboard></IconDashboard>Home
        </a-menu-item>
        <a-sub-menu key="4">
          <template #title>
            <IconCalendar></IconCalendar>例子
          </template>
          <a-menu-item key="search-table">查询表格</a-menu-item>
          <a-menu-item key="step-form">分步表单</a-menu-item>
          <a-menu-item key="group-form">分组表单</a-menu-item>
          <a-menu-item key="basic-info">基础详情页</a-menu-item>
          <a-menu-item key="success">成功页面</a-menu-item>
          <a-menu-item key="error">错误页面</a-menu-item>
          <a-menu-item key="not-found">404</a-menu-item>
        </a-sub-menu>
        <a-menu-item key="product-list">
          <IconCommon></IconCommon>商品管理
        </a-menu-item>
        <a-menu-item key="customer-list">
          <IconCommon></IconCommon>客户管理
        </a-menu-item>
        <a-menu-item key="supplier-list">
          <IconCommon></IconCommon>供应商管理
        </a-menu-item>
        <a-menu-item key="sales-order-list">
          <IconCommon></IconCommon>销售订单
        </a-menu-item>
        <a-menu-item key="purchase-order-list">
          <IconCommon></IconCommon>采购订单
        </a-menu-item>
        <a-menu-item key="inventory-list">
          <IconCommon></IconCommon>库存管理
        </a-menu-item>
        <a-menu-item key="user-list">
          <IconCommon></IconCommon>用户管理
        </a-menu-item>
      </a-menu>
    </a-layout-sider>
    <a-layout class="layout-main">
      <a-layout class="layout-center">
        <a-layout-content>
          <RouterView></RouterView>
        </a-layout-content>
        <!-- <a-layout-footer>Footer</a-layout-footer> -->
      </a-layout>
    </a-layout>
  </a-layout>
</template>
<script lang="ts">
import {
  IconDashboard,
  IconCalendar,
  IconCommon
} from '@arco-design/web-vue/es/icon';

import LayoutHeader from '../components/LayoutHeader.vue';
export default {
  components: {
    IconDashboard,
    IconCalendar,
    IconCommon,
    LayoutHeader
  },
  data() {

  },
  methods: {
    onClickMenuItem: function (key: string) {
      this.$router.push({ name: key });
    }
  }
}
</script>
<style scoped lang="less">
@header-size-height: 60px;

.layout {
  height: 100%;
  width: 100%;

  .layout-header {
    height: @header-size-height;
    background-color: var(--color-bg-1);
    width: 100%;
    position: fixed;
    left: 0;
    top: 0;
    z-index: 100;
  }

  .layout-sider {
    height: calc(100% - @header-size-height);
    top: @header-size-height;
    left: 0;
    position: relative;
    z-index: 99;
  }

  .layout-main {
    margin-top: @header-size-height;
  }

  .layout-center {
    background-color: var(--color-fill-2);
    padding: 20px;
  }
}
</style>
