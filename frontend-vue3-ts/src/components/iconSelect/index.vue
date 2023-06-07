<template>
  <div class="icon-body">
    <el-input v-model="data.name" style="{position: relative}" clearable placeholder="请输入图标名称" @clear="filterIcons"
      @input.native="filterIcons">
      <i slot="suffix" class="search el-input__icon" />
    </el-input>
    <div class="icon-list">
      <div v-for="(item, index) in data.iconList" :key="index" @click="selectedIcon(item)">
        <svg-icon :icon-class="item" style="height: 40px; width: 25px; margin-right: 5px;" />
        <span>{{ item }}</span>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref, reactive } from "vue";
import icons from "./requireIcons";

const data = reactive({
  name: "",
  iconList: icons,
})

const emit = defineEmits(["selected"])

const filterIcons = () => {
  data.iconList = icons;
  if (data.name) {
    data.iconList = data.iconList.filter((item) =>
      item.includes(data.name)
    );
  }
}

const selectedIcon = (name: string) => {
  emit("selected", name);
  document.body.click();
}

const reset = () => {
  data.name = "";
  data.iconList = icons;
  console.log("reset")
}

defineExpose({
  reset
})
</script>

<style lang="scss" scoped>
.icon-body {
  width: 100%;
  padding: 10px;

  .icon-list {
    height: 200px;
    overflow-y: scroll;

    div {
      height: 40px;
      line-height: 40px;
      font-size: 16px;
      margin: 0 0 -5px 10px;
      cursor: pointer;
      width: 30%;
      float: left;
    }

    span {
      display: inline-block;
      vertical-align: -0.15em;
      fill: currentColor;
      overflow: hidden;
    }
  }
}
</style>