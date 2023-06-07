<template>
  <el-form-item class="item-search">
    <el-button icon="refresh" @click="resetClick">重置</el-button>
    <el-button type="primary" icon="search" @click="searchClick">搜索</el-button>
  </el-form-item>
</template>

<script setup lang="ts">
import { ref, reactive } from "vue";

const emit = defineEmits(["reset", "search"]);  //reset、search 父组件传来的方法

const resetClick = () => {
  // console.log("emit resetQuery")
  emit("reset")
}

const searchClick = () => {
  // console.log("emit queryClick")
  emit("search")
}
</script>

<style lang="scss" scoped></style>