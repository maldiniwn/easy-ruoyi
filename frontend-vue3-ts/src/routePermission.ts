import router from "@/router"
import NProgress from "nprogress"
import "nprogress/nprogress.css"
import { permissionStore } from "@/store/permissionStore"
import { userStore } from "@/store/userStore"

//白名单
const whiteList = ["/login", "/auth-redirect", "/bind", "/register"];

NProgress.configure({ showSpinner: false });

router.beforeEach((to: any, from, next) => {
  NProgress.start();
  // console.log("to", to)
  document.title = (to.meta && to.meta.title) ? `EasyRuoyi | ${to.meta.title}` : "EasyRuoyi";
  let token = userStore().getToken();
  if (token && token.length > 0) {
    if (userStore().roles.length === 0) {
      userStore().getLoginUserInfo().then(() => {
        permissionStore().generateRouterAndMenu().then((accessRoutes: any) => {
          // console.log("accessRoutes", accessRoutes)
          accessRoutes.forEach((route: any) => {
            if (route.path && route.path.length > 0) {
              // router.addRoute("Index", route);
              router.addRoute(route);
              //router.options.routes[0].children?.push(route);
            }
          });

          // console.log("router", router)
          // console.log("router.getRoutes()", router.getRoutes())
          next({ path: to.path, replace: true });
        })
      }).catch((error) => {
        console.log("error", error);
        next({ path: "/" })
      })
    } else {
      next();
    }
  } else {
    //判断白名单
    if (whiteList.indexOf(to.path) > -1) {
      // console.log("白名单")
      next();
    } else {
      //不在白名单
      // console.log("不在白名单")
      next("/login");
    }
  }
})

router.afterEach(() => {
  NProgress.done();
});
