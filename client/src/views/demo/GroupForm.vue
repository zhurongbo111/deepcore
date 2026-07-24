<template>
  <a-form layout="vertical" :model="formData">
    <a-space direction="vertical" :size="16">
      <a-card title="视频参数">
        <a-row :gutter="80">
          <a-col :span="8">
            <a-form-item label="视频模型">
              <a-select placeholder="选择视频模型">
                <a-option value="custom">自定义</a-option>
                <a-option value="mode1">模式1</a-option>
                <a-option value="mode2">模式2</a-option>
              </a-select>
            </a-form-item>
          </a-col>
          <a-col :span="8">
            <a-form-item label="分辨率">
              <a-select placeholder="选择分辨率">
                <a-option value="resolution1">分辨率1</a-option>
                <a-option value="resolution2">分辨率2</a-option>
                <a-option value="resolution3">分辨率3</a-option>
              </a-select>
            </a-form-item>
          </a-col>
          <a-col :span="8">
            <a-form-item label="刷新率">
              <a-input placeholder="输入分辨率">
                <template #append> fps </template>
              </a-input>
            </a-form-item>
          </a-col>
        </a-row>
        <a-row :gutter="80">
          <a-col :span="8">
            <a-form-item label="视频模型">
              <a-select placeholder="选择视频模型">
                <a-option value="custom">自定义</a-option>
                <a-option value="mode1">模式1</a-option>
                <a-option value="mode2">模式2</a-option>
              </a-select>
            </a-form-item>
          </a-col>
          <a-col :span="8">
            <a-form-item label="分辨率">
              <a-select placeholder="选择分辨率">
                <a-option value="resolution1">分辨率1</a-option>
                <a-option value="resolution2">分辨率2</a-option>
                <a-option value="resolution3">分辨率3</a-option>
              </a-select>
            </a-form-item>
          </a-col>
          <a-col :span="8">
            <a-form-item label="刷新率">
              <a-input placeholder="输入分辨率">
                <template #append> fps </template>
              </a-input>
            </a-form-item>
          </a-col>
        </a-row>
        <a-row :gutter="80">
          <a-col :span="8">
            <a-form-item label="视频模型">
              <a-select placeholder="选择视频模型">
                <a-option value="custom">自定义</a-option>
                <a-option value="mode1">模式1</a-option>
                <a-option value="mode2">模式2</a-option>
              </a-select>
            </a-form-item>
          </a-col>
          <a-col :span="8">
            <a-form-item label="分辨率">
              <a-select placeholder="选择分辨率">
                <a-option value="resolution1">分辨率1</a-option>
                <a-option value="resolution2">分辨率2</a-option>
                <a-option value="resolution3">分辨率3</a-option>
              </a-select>
            </a-form-item>
          </a-col>
          <a-col :span="8">
            <a-form-item label="刷新率">
              <a-input placeholder="输入分辨率">
                <template #append> fps </template>
              </a-input>
            </a-form-item>
          </a-col>
        </a-row>
      </a-card>
      <a-card title="音频参数">
        <a-row :gutter="80">
          <a-col :span="8">
            <a-form-item label="视频模型">
              <a-select placeholder="选择视频模型">
                <a-option value="custom">自定义</a-option>
                <a-option value="mode1">模式1</a-option>
                <a-option value="mode2">模式2</a-option>
              </a-select>
            </a-form-item>
          </a-col>
          <a-col :span="8">
            <a-form-item label="分辨率">
              <a-select placeholder="选择分辨率">
                <a-option value="resolution1">分辨率1</a-option>
                <a-option value="resolution2">分辨率2</a-option>
                <a-option value="resolution3">分辨率3</a-option>
              </a-select>
            </a-form-item>
          </a-col>
          <a-col :span="8">
            <a-form-item label="刷新率">
              <a-input placeholder="输入分辨率">
                <template #append> fps </template>
              </a-input>
            </a-form-item>
          </a-col>
        </a-row>
        <a-row :gutter="80">
          <a-col :span="8">
            <a-form-item label="视频模型">
              <a-select placeholder="选择视频模型">
                <a-option value="custom">自定义</a-option>
                <a-option value="mode1">模式1</a-option>
                <a-option value="mode2">模式2</a-option>
              </a-select>
            </a-form-item>
          </a-col>
          <a-col :span="8">
            <a-form-item label="分辨率">
              <a-select placeholder="选择分辨率">
                <a-option value="resolution1">分辨率1</a-option>
                <a-option value="resolution2">分辨率2</a-option>
                <a-option value="resolution3">分辨率3</a-option>
              </a-select>
            </a-form-item>
          </a-col>
          <a-col :span="8">
            <a-form-item label="刷新率">
              <a-input placeholder="输入分辨率">
                <template #append> fps </template>
              </a-input>
            </a-form-item>
          </a-col>
        </a-row>
        <a-row :gutter="80">
          <a-col :span="8">
            <a-form-item label="视频模型">
              <a-select placeholder="选择视频模型">
                <a-option value="custom">自定义</a-option>
                <a-option value="mode1">模式1</a-option>
                <a-option value="mode2">模式2</a-option>
              </a-select>
            </a-form-item>
          </a-col>
          <a-col :span="8">
            <a-form-item label="分辨率">
              <a-select placeholder="选择分辨率">
                <a-option value="resolution1">分辨率1</a-option>
                <a-option value="resolution2">分辨率2</a-option>
                <a-option value="resolution3">分辨率3</a-option>
              </a-select>
            </a-form-item>
          </a-col>
          <a-col :span="8">
            <a-form-item label="刷新率">
              <a-input placeholder="输入分辨率">
                <template #append> fps </template>
              </a-input>
            </a-form-item>
          </a-col>
        </a-row>
      </a-card>
      <a-card class="general-card" title="参数说明" :bordered="false">
        <a-form-item label="填写说明">
          <a-textarea placeholder="填写说明" />
        </a-form-item>
      </a-card>
      <div class="actions">
        <a-space>
          <a-button>
            重置
          </a-button>
          <a-button type="primary">
            提交
          </a-button>
        </a-space>
      </div>
    </a-space>
  </a-form>
</template>

<script lang="ts">
export default {
  data() {
    return {
      formData: {}
    }
  }
}
</script>

<style lang="less" scoped>
:deep(.arco-card-header) {
  border: none;
}

.actions {
  padding: 14px 20px 14px 0;
  background: var(--color-bg-2);
  text-align: right;
}
</style>
