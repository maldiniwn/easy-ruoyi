import { defineStore } from "pinia"
import router, { constantRoutes } from "@/router"
import { getRouterAndMenu } from "@/api/account"
import { MenuModel } from "@/models/MenuModel"
import Layout from "@/components/layout/index.vue";

// 匹配views里面所有的.vue文件
const modules = import.meta.glob("../views/**/*.vue");

export const permissionStore = defineStore("permissionStore", {
  state: () => {
    return {
      routes: [] as any,
      defaultRoutes: [] as any,
      topbarRoutes: [] as any,
      sidebarRoutes: [] as Array<MenuModel>,
      /**
       * 所有叶子节点菜单。用于headerSearch菜单查询
       */
      leafMenus: [] as MenuModel[]
    }
  },
  actions: {
    setRoutes(routes: any) {
      this.routes = constantRoutes.concat(routes);
      // console.log("setRoutes", this.routes)
    },
    setDefaultRoutes(routes: any) {
      this.defaultRoutes = constantRoutes.concat(routes);
    },
    setTopbarRoutes(routes: any) {
      this.topbarRoutes = routes;
    },
    setSidebarRouters(routes: any) {
      this.sidebarRoutes = routes;
    },
    generateRouterAndMenu() {
      return new Promise(async (resolve: any) => {
        getRouterAndMenu().then((resp: any) => {
          // console.log(resp);
          if (resp.code == 200 && resp.success) {
            const routes = filterRouter(JSON.parse(JSON.stringify(resp.data.routers)), this.leafMenus);
            const defaultRoutes = JSON.parse(JSON.stringify(resp.data.routers));
            const topbarRoutes = JSON.parse(JSON.stringify(resp.data.menus));
            const sidebarRoutes = JSON.parse(JSON.stringify(resp.data.menus));

            this.setRoutes(routes);
            this.setDefaultRoutes(defaultRoutes);
            this.setTopbarRoutes(topbarRoutes);
            this.setSidebarRouters(sidebarRoutes);
            resolve(routes)
          }
        })
        // let resp = await getRouters() as any;
        // console.log("getRouters", resp);
        // resolve(resp);
      })
    }
  },
  // persist: {
  //   enabled: true,	//默认持久化到sessionStorage
  //   strategies: [
  //     {
  //       key: 'permissionStore',	//持久化的key
  //       // storage: localStorage,	//持久化的区域 sessionStorage、localStorage、cookiesStorage(default: sessionStorage)
  //       //paths: ['firstName', 'lastName']	//持久化的state中的key列表
  //     },
  //   ],
  // }
})

/**
 * 遍历后台传来的路由字符串，转换为组件对象
 * @param allRoutes 
 * @param leafMenus 
 */
function filterRouter(allRoutes: any[], leafMenus: MenuModel[]) {
  // console.log("modules", modules)
  return allRoutes.filter((route) => {
    // if (type && route.children) {
    //   // route.children = 
    // }

    //菜单类型只有Menu的有Component，其他的类型没有
    if (route.component && route.component.length > 0) {
      route.component = modules[`../views/${route.component}.vue`];
      // route.component = loadView(route.component);
      // console.log("route.component", route.component)

      //填充叶节点菜单，用于headerSearch菜单查询
      let m = new MenuModel();
      m.id = route.pId;
      m.pId = route.pId;
      m.name = route.meta.title;
      m.fullPath = route.fullPath.substring(0, route.fullPath.length - 1).replaceAll("/", " > ");
      m.path = route.path;
      m.menuIcon = route.meta.icon;
      leafMenus.push(m);
    } else {
      route.component = Layout;
    }

    if (route.children && route.children.length > 0) {
      route.children = filterRouter(route.children, leafMenus);
    } else {
      delete route["children"];
    }

    return true;
  })
}

// function filterChildren(childrenRoutes: any[], lastRouter?: any) {
//   let children: any[] = [];
//   childrenRoutes.forEach((el, index) => {
//     if (el.children && el.children.length > 0) {

//     }
//   })
// }

// export const loadView = (view: string) => {
//   let res;
//   for (const path in modules) {
//     const dir = path.split("views/")[1].split(".vue")[0];
//     if (dir === view) {
//       res = () => modules[path]();
//     }
//   }
//   return res;
// };