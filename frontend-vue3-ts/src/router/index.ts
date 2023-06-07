import { createRouter, createWebHistory } from "vue-router"
/* Layout */
import Layout from "@/components/layout/index.vue";

//公共路由
export const constantRoutes = [
  {
    path: "",
    name: "Home",
    redirect: "/index",
    hidden: true,
    component: Layout,
    children: [
      {
        path: "/index",
        name: "Index",
        hidden: false,
        component: () => import("@/views/index.vue"),
        meta: { title: "首页", icon: "dashboard", affix: true },
      },
      {
        path: "/usercenter",
        name: "UserCenter",
        component: () => import("@/views/system/usercenter/index.vue"),
        hidden: true,
        meta: { title: "个人中心", icon: "user", affix: false },
      },
    ]
  },
  // {
  //   path: "/index",
  //   name: "Index",
  //   component: () => import("@/views/index.vue"),
  //   hidden: true,
  //   meta: { title: "首页", icon: "dashboard", affix: true },
  //   children: [
  //     // {
  //     //   path: "/system/user",
  //     //   name: "User",
  //     //   component: () => import("@/views/system/user/index.vue"),
  //     //   hidden: false
  //     // },
  //     // {
  //     //   path: "/system/role",
  //     //   name: "Role",
  //     //   component: () => import("@/views/system/role/index.vue"),
  //     //   hidden: false
  //     // }
  //   ]
  // },  
  {
    path: "/login",
    name: "Login",
    component: () => import("@/views/login.vue"),
    hidden: true,
    meta: { title: "登录" }
  },
  {
    path: "/register",
    name: "Register",
    component: () => import("@/views/register.vue"),
    hidden: true,
    meta: { title: "注册" }
  },
  {
    path: "/:pathMatch(.*)*",
    name: "NotFound",
    component: () => import("@/views/error/404.vue"),
    hidden: true,
  }
]

//创建路由
const router = createRouter({
  history: createWebHistory(),
  routes: constantRoutes,
  // 刷新时，滚动条位置还原
  scrollBehavior(to, from, savedPosition) {
    if (savedPosition) {
      return savedPosition
    } else {
      return { top: 0 }
    }
  },
});

export default router;