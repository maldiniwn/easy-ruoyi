<template>
  <div class="right-menu">
    <header-search class="right-menu-item"></header-search>
    <div class="avatar-container">
      <el-dropdown @command="handleCommand" class="right-menu-item hover-effect" trigger="click">
        <div class="avatar-wrapper">
          <!-- <img src="@/assets/images/profile.jpg" class="user-avatar" /> -->
          <el-image :src="headUrl" class="user-avatar">
            <template #error>
              <img src="@/assets/images/unknow.jpeg" width="40" height="40" />
            </template>
          </el-image>
          <el-icon><caret-bottom /></el-icon>
        </div>
        <template #dropdown>
          <el-dropdown-menu>
            <router-link to="/usercenter">
              <el-dropdown-item>个人中心</el-dropdown-item>
            </router-link>
            <el-dropdown-item divided command="logout">
              <span>退出登录</span>
            </el-dropdown-item>
          </el-dropdown-menu>
        </template>
      </el-dropdown>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref, reactive, getCurrentInstance, onMounted } from "vue";
import { userStore } from "@/store/userStore"
import router from "@/router"
import headerSearch from "@/components/layout/headerSearch/index.vue"
import { getHeadUrl } from "@/api/system/usercenter"

const { proxy }: any = getCurrentInstance()

const myUserStore = userStore();

/** 头像url */
const headUrl = ref("")

/** 查询头像url */
const getUserHeadUrl = () => {
  getHeadUrl().then((resp: any) => {
    headUrl.value = resp.data;
  })
}

const handleCommand = (cmd: string) => {
  // console.log("cmd", cmd)
  if ("logout" == cmd) {
    myUserStore.logout();
    // location.href = "/login";
    router.push("/login");
  }
}

onMounted(() => {
  getUserHeadUrl();

  //监听mitt事件总线
  proxy.$bus.on("updateHeadUrl", (url: string) => {
    // console.log("$bus.on.updateHeadUrl", url);
    headUrl.value = url;
  })
})

</script>

<style lang="scss" scoped>
.right-menu {
  float: right;
  height: 100%;
  line-height: 50px;
  display: flex;

  &:focus {
    outline: none;
  }

  .right-menu-item {
    display: inline-block;
    padding: 0 8px;
    height: 100%;
    font-size: 18px;
    color: #5a5e66;
    vertical-align: text-bottom;

    &.hover-effect {
      cursor: pointer;
      transition: background 0.3s;

      &:hover {
        background: rgba(0, 0, 0, 0.025);
      }
    }
  }

  .avatar-container {
    margin-right: 40px;

    .avatar-wrapper {
      margin-top: 5px;
      position: relative;

      .user-avatar {
        cursor: pointer;
        width: 40px;
        height: 40px;
        border-radius: 10px;
      }

      i {
        cursor: pointer;
        position: absolute;
        right: -20px;
        top: 25px;
        font-size: 12px;
      }
    }
  }
}
</style>