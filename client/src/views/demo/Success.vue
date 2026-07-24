<template>
  <div class="container">
    <div class="wrapper">
      <a-result class="result" status="success" title="提交成功" subtitle="表单提交成功">
        <template #extra>
          <a-space class="operation-wrap" :size="16">
            <a-button key="again" type="secondary">
              打印结果
            </a-button>
            <a-button key="back" type="primary">
              文件列表
            </a-button>
          </a-space>
        </template>
      </a-result>
    </div>
  </div>
</template>

<script lang="ts" setup></script>

<script lang="ts">
</script>

<style scoped lang="less">
.container {
  padding: 0 20px 20px 20px;
}

.wrapper {
  padding: 24px 150px;
  background-color: var(--color-bg-2);
  border-radius: 4px;
}

.result {
  margin: 150px 0 0 0;
}

.operation-wrap {
  margin-bottom: 40px;
  text-align: center;
}

.steps-wrapper {
  width: 100%;
  min-width: fit-content;
  margin-bottom: 150px;
  padding: 20px;
  background-color: rgb(var(--gray-1));
}
</style>

<style lang="less" scoped>
.mobile {
  .wrapper {
    padding: 24px 10px;

    .steps-wrapper {
      transform: scale(0.8);
    }
  }
}
</style>
