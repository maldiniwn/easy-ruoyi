<template>
  <el-menu background-color="#304156" text-color="#ffffff" :collapse="collapse" :default-active="activeMenu" router>
    <!-- 默认会有个首页的入口 -->
    <el-menu-item index="/index">
      <svg-icon icon-class="dashboard"></svg-icon>
      <template #title>
        <span style="padding-left:10px;">首页</span>
      </template>
    </el-menu-item>

    <sidebarItem :menus="menus"></sidebarItem>
  </el-menu>
</template>

<script setup lang="ts">
import { ref, reactive, computed } from "vue";
import { useRoute } from "vue-router";
import { MenuModel } from "@/models/MenuModel"
import sidebarItem from "@/components/layout/sidebar/sidebarItem.vue"
import { permissionStore } from "@/store/permissionStore"

const props = defineProps({
  collapse: {
    type: Boolean,
    default: false
  }
})

const route = useRoute();

const menus: Array<MenuModel> = permissionStore().sidebarRoutes;

const activeMenu: any = computed(() => {
  if (route.meta && route.meta.activeMenu) {
    return route.meta.activeMenu;
  } else {
    return route.path;
  }
  // const { meta, path } = route;
  // // if set path, the sidebar will highlight the path you set
  // if (meta.activeMenu) {
  //   return meta.activeMenu;
  // }
  // return path;
});

// console.log("menus", menus);

// const menus: Array<MenuModel> = [
//   {
//     id: "1", name: "企业管理", path: "enterprise", menuIcon: "component", children: [
//       { id: "11", name: "企业类别", path: "/enterprise/type", menuIcon: "nested", children: [] },
//       { id: "12", name: "企业列表", path: "/enterprise/list", menuIcon: "list", children: [] }
//     ]
//   },
//   {
//     id: "2", name: "系统管理", path: "system", menuIcon: "system", children: [
//       { id: "21", name: "角色列表", path: "/system/role", menuIcon: "peoples", children: [] },
//       { id: "22", name: "用户列表", path: "/system/user", menuIcon: "user", children: [] }
//     ]
//   },
//   { id: "3", name: "修改密码", path: "updatePassword", menuIcon: "password", children: [] }
// ];

</script>

<style lang="scss" scoped></style>