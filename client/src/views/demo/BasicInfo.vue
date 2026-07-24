<template>
  <a-space direction="vertical" :size="16" fill>
    <a-card class="general-card" title="审批流程">
      <template #extra>
        <a-space>
          <a-button>取消流程</a-button>
          <a-button type="primary">
            返回
          </a-button>
        </a-space>
      </template>
      <a-steps v-model:current="step" line-less class="steps">
        <a-step>提交修改</a-step>
        <a-step>审批中</a-step>
        <a-step>修改完成</a-step>
      </a-steps>
    </a-card>
    <a-card>
      <a-descriptions :data="data" title="User Info"></a-descriptions>
    </a-card>
    <a-card>
      <a-descriptions :data="data" title="User Info">
        <template #value="{ value, data }">
          <a-tag v-if="data.label === '测试2'" color="green" size="small">
            已认证
          </a-tag>
          <span v-else>{{ value }}</span>
        </template>
      </a-descriptions>
    </a-card>
  </a-space>

</template>

<script lang="ts">
export default {
  data() {
    return {
      loading: false,
      step: 2,
      data: [
        {
          label: "测试1",
          value: "Value1"
        },
        {
          label: "测试2",
          value: "Value1"
        },
        {
          label: "测试3",
          value: "Value1"
        },
        {
          label: "测试4",
          value: "Value1"
        }
      ]
    }
  }
}
</script>

<style scoped lang="less">
.container {
  padding: 0 20px 20px 20px;
}

.steps {
  max-width: 548px;
  margin: 0 auto 10px;
}
</style>
