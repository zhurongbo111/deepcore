<template>
  <a-card class="step-card" title="分布表单">
    <a-row>
      <a-col :span="12" :offset="6">
        <a-steps v-model:current="step" style="width: 100%; padding: 48px 0px;" line-less>
          <a-step description="创建渠道活动">
            选择基本信息
          </a-step>
          <a-step description="输入详细的渠道信息">
            输入渠道信息
          </a-step>
          <a-step description="创建成功">
            完成创建
          </a-step>
        </a-steps>
        <div style="width: 100%;">
          <a-form :model="formModel">
            <a-form-item label="名称">
              <a-input placeholder="名称" />
            </a-form-item>
            <a-form-item label="类型名称">
              <a-input placeholder="名称" />
            </a-form-item>
            <a-form-item label="名称三" required>
              <a-input placeholder="名称" />
            </a-form-item>
            <a-form-item label="">
              <a-button type="primary">
                下一步
              </a-button>
            </a-form-item>
          </a-form>
        </div>
      </a-col>
    </a-row>
  </a-card>
</template>

<script lang="ts">
export default {
  data() {
    return {
      step: 1,
      formModel: {}
    }
  }
}
</script>

<script lang="ts">
</script>

<style scoped lang="less">
.step-card {
  border: none;
  min-height: 100%;

  :deep(.arco-card-header) {
    border: none;
  }
}
</style>
