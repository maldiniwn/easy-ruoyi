import { createApp, Directive } from "vue"

//ElementPlus
import ElementPlus from "element-plus"  //ElementPlus
import "element-plus/dist/index.css"    //样式
import zhCn from "element-plus/es/locale/lang/zh-cn" // 中文语言

// Vue-Cropper
import VueCropper from "vue-cropper";
import "vue-cropper/dist/index.css";

// 自定义svg图标组件
import "virtual:svg-icons-register";
import svgIcon from "@/components/svgIcon/index.vue";
// element-plus图标
import elementIcons from "@/components/svgIcon/svgicon";

//pinia
import pinia from "./store"

//路由
import router from "./router/index"

//axios
import axios from "axios"

//全局css
import "@/assets/styles/index.scss";

//在VUE3中，已移除全局事件总线，官方推荐第三方库mitt代替EventBus
//全局引入
import mitt from "mitt"
const bus = mitt();

//routePermission
import "./routePermission"

//插件
import plugins from "./plugins";

//注册 自定义指令
import * as directive from "@/directive";

//util
import { download } from "./utils/util"

import App from "./App.vue"

const app = createApp(App);

app.use(pinia);

app.use(ElementPlus, {
  locale: zhCn,
  // 支持 large、default、small
  size: "small"
})

app.use(VueCropper);
app.use(elementIcons);
app.use(router)
app.use(plugins);

// TODO 对vue进行类型补充说明，不然在vue页面使用的时候会报错
// declare module "@vue/runtime-core" {
//   interface ComponentCustomProperties {
//     // getDicts: Function;
//     // getConfigKey: Function;
//     download: Function;
//     // parseTime: Function;
//     // dateTimeSub: Function;
//     // resetForm: Function;
//     // cleanTableSelection: Function;
//     // setTableRowSelected: Function;
//     // handleTree: Function;
//     // addDateRange: Function;
//     // selectDictLabel: Function;
//     // selectDictLabels: Function;
//   }
// }

//全局挂载（等同于 Vue2 的 Vue.prototype）
app.config.globalProperties.$axios = axios;
app.config.globalProperties.$download = download;
app.config.globalProperties.$superAdmin = import.meta.env.VITE_APP_SUPER_ADMIN;
app.config.globalProperties.$superRole = import.meta.env.VITE_APP_SUPER_ROLE;
app.config.globalProperties.$bus = bus;

// app.provide('$superAdmin', import.meta.env.VITE_APP_SUPER_ADMIN)
// app.provide('$superRole', import.meta.env.VITE_APP_SUPER_ROLE)

// 全局组件挂载
app.component('svg-icon', svgIcon)// 自定义svg图标组件

// 批量注册自定义指令
Object.keys(directive).forEach((key) => {
  app.directive(key, (directive as { [key: string]: Directive })[key]);
});

app.mount("#app")
