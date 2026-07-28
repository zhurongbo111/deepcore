<template>
  <div class="content">
    <a-result class="result" status="404" :subtitle="'抱歉，页面不见了～'"> </a-result>
    <div class="operation-row">
      <a-button key="back" type="primary" @click="back"> 返回 </a-button>
    </div>
  </div>
</template>

<script lang="ts" setup>
  import { useRouter } from 'vue-router';

  const router = useRouter();
  const back = () => {
    // warning： Go to the node that has the permission
    router.push({ name: 'home' });
  };
</script>

<style scoped lang="less">
  .content {
    min-height: 100%;
    width: 100%;
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    background-color: var(--color-bg-2);
  }
</style>
