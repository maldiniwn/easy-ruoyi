<template>
  <el-breadcrumb class="app-breadcrumb" separator="/">
    <transition-group name="breadcrumb">
      <el-breadcrumb-item v-for="(item, index) in levelList" :key="item.path">
        <span v-if="((item.children && item.children.length > 0) || index == levelList.length - 1)" class="no-redirect">{{
          item.meta.title
        }}</span>
        <a v-else @click.prevent="handleLink(item)">{{ item.meta.title }}</a>
      </el-breadcrumb-item>
    </transition-group>
  </el-breadcrumb>
</template>

<script lang="ts" setup>
import { ref, computed, nextTick, watch, onMounted, getCurrentInstance, } from "vue";
import { useRoute, useRouter } from "vue-router";
import { permissionStore } from "@/store/permissionStore"
import { MenuModel } from "@/models/MenuModel"

const route = useRoute();
const router = useRouter();
// const levelList = ref([] as Array<MenuModel>);
const levelList = ref([] as any);

watch(route, () => {
  getBreadcrumb()
})

onMounted(() => {
  getBreadcrumb();
})

const getBreadcrumb = () => {
  let matched: any = route.matched.filter(item => item.meta && item.meta.title)

  if (matched && matched.length > 0) {
    if (!isDashboard(matched[0])) {
      matched = [{ path: '/index', meta: { title: '首页' } }].concat(matched)
    }
  }
  // console.log("matched", matched)
  levelList.value = matched;
}

const isDashboard = (route: any): boolean => {
  const name = route && route.name
  if (!name) {
    return false
  }
  return name.trim() === 'Index'
}

const handleLink = (item: any) => {
  const { path } = item
  router.push(path)
}
</script>

<style lang="scss" scoped>
.app-breadcrumb.el-breadcrumb {
  display: inline-block;
  font-size: 14px;
  line-height: 40px;
  margin-left: 8px;

  .no-redirect {
    color: #97a8be;
    cursor: text;
  }
}
</style>
