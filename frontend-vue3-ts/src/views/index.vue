<template>
  index
</template>

<script lang="ts" setup>
import { ref, reactive, computed, onMounted } from "vue";
import sidebar from "@/components/layout/sidebar/index.vue"
import tagsView from "@/components/layout/tagsView/index.vue"
import breadcrumb from "@/components/layout/breadcrumb/index.vue"

const menuCollapse = ref(false)

const classObj = computed(() => ({
  hideSidebar: menuCollapse.value,
  openSidebar: !menuCollapse.value,
}));

const toggle = () => {
  menuCollapse.value = !menuCollapse.value;
}
</script>

<style lang="scss" scoped>
.el-header {
  padding: 0px;
}

.el-container {
  height: 100%;

  .openSidebar {
    overflow: auto;
    width: 250px !important;
    transition-duration: 0.3s;
  }

  .hideSidebar {
    overflow-x: hidden;
    width: 64px !important;
    transition-duration: 0.3s;
  }

  aside {
    background: #304156;
    padding: 0px;
    margin: 0px;
    // border-right: solid 1px silver;

    .el-menu {
      border: none;
    }
  }

  .el-main {
    padding: 0px 10px;

    .hamburger {
      display: inline-block;
      vertical-align: middle;
      width: 20px;
      height: 20px;
      cursor: pointer;
    }

    .hamburger.is-active {
      transform: rotate(180deg);
    }
  }
}
</style>