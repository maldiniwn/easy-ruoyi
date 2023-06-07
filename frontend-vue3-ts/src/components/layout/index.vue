<template>
  <el-container>
    <el-header>
      <div class="logo">
        <img src="@/assets/logo/logo.png" width="50" height="50" />
      </div>
      <div class="logo-text">EasyRuoyi</div>
      <rightmenu></rightmenu>
    </el-header>
    <el-container>
      <el-aside :class="classObj">
        <sidebar :collapse="menuCollapse"></sidebar>
      </el-aside>
      <el-main>
        <div class="main-top">
          <div style="float: left; padding:0px 4px" @click="toggle()">
            <svg :class="{ 'is-active': !menuCollapse }" class="hamburger" viewBox="0 0 1024 1024"
              xmlns="http://www.w3.org/2000/svg" width="32" height="32">
              <!-- <title>{{ menuCollapse ? "展开" : "折叠" }}</title> -->
              <path
                d="M408 442h480c4.4 0 8-3.6 8-8v-56c0-4.4-3.6-8-8-8H408c-4.4 0-8 3.6-8 8v56c0 4.4 3.6 8 8 8zm-8 204c0 4.4 3.6 8 8 8h480c4.4 0 8-3.6 8-8v-56c0-4.4-3.6-8-8-8H408c-4.4 0-8 3.6-8 8v56zm504-486H120c-4.4 0-8 3.6-8 8v56c0 4.4 3.6 8 8 8h784c4.4 0 8-3.6 8-8v-56c0-4.4-3.6-8-8-8zm0 632H120c-4.4 0-8 3.6-8 8v56c0 4.4 3.6 8 8 8h784c4.4 0 8-3.6 8-8v-56c0-4.4-3.6-8-8-8zM142.4 642.1L298.7 519a8.84 8.84 0 0 0 0-13.9L142.4 381.9c-5.8-4.6-14.4-.5-14.4 6.9v246.3a8.9 8.9 0 0 0 14.4 7z" />
            </svg>
          </div>
          <breadcrumb id="breadcrumb-container" class="breadcrumb-container"></breadcrumb>
        </div>
        <tags-view></tags-view>
        <router-view>
        </router-view>
      </el-main>
    </el-container>
  </el-container>
</template>

<script lang="ts" setup>
import { ref, reactive, computed, onMounted } from "vue";
import sidebar from "@/components/layout/sidebar/index.vue"
import tagsView from "@/components/layout/tagsView/index.vue"
import breadcrumb from "@/components/layout/breadcrumb/index.vue"
import rightmenu from "@/components/layout/rightmenu/index.vue"

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
  height: 50px;
  border-bottom: 1px solid silver;
  // background-color: skyblue;

  .logo {
    padding-left: 10px;
    height: 50px;
    width: 70px;
    float: left;
  }

  .logo-text {
    font-size: 20px;
    height: 50px;
    line-height: 50px;
    text-shadow: 0px 1px 0px #c0c0c0,
      0px 2px 0px #b0b0b0,
      0px 3px 0px #a0a0a0,
      0px 4px 0px #909090,
      0px 5px 10px rgba(0, 0, 0, .9);
    color: #fefefe;
    float: left;
  }
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

    .main-top {
      height: 40px;
      line-height: 40px;
      overflow: hidden;
    }

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

    .breadcrumb-container {
      float: left;
    }
  }
}
</style>