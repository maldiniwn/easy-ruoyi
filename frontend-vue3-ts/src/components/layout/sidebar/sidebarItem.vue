<template>
  <template v-for="item in menus">
    <el-sub-menu v-if="item.children != null && item.children.length > 0" :index="item.path" :key="item.id">
      <template #title>
        <svg-icon :icon-class="item.menuIcon"></svg-icon>
        <span style="padding-left:10px;">{{ item.name }}</span>
      </template>
      <sidebarItem :menus="item.children"></sidebarItem>
    </el-sub-menu>

    <el-menu-item v-else :index="item.path">
      <svg-icon :icon-class="item.menuIcon"></svg-icon>
      <template #title>
        <span style="padding-left:10px;">{{ item.name }}</span>
      </template>
    </el-menu-item>
  </template>
</template>

<script setup lang="ts">
import { ref, reactive } from "vue";
import { MenuModel } from "@/models/MenuModel"

const props = defineProps({
  menus: {
    type: Array<MenuModel>,
    default: []
  }
})
</script>

<style lang="scss" scoped></style>