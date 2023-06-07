import axios, { AxiosResponse } from "axios"
import { ElMessage } from "element-plus"
import router from "@/router/index"
import { userStore } from "@/store/userStore"

//创建一个axios实例 
const instance = axios.create({
  // headers: {
  //   'content-type': 'application/json;charset=utf-8',
  // },
  //自动加在url前面
  baseURL: import.meta.env.VITE_APP_API_HOST,
  //跨域凭证
  // withCredentials: true,
  timeout: 100000  //10秒
})

//响应和请求 拦截器配置
instance.interceptors.request.use(
  config => {
    // console.log("config", config)
    let token = userStore().getToken();
    let refreshToken = userStore().getRefreshToken();
    if (token && token.length > 0) {
      config.headers["Authorization"] = `bearer ${token}`;
    }
    if (refreshToken && refreshToken.length > 0) {
      config.headers["X-Authorization"] = `bearer ${refreshToken}`;
    }

    return config
  }, error => {
    Promise.reject(error)
  }
)

instance.interceptors.response.use((resp: AxiosResponse) => {
  if (resp.headers['access-token']) {
    userStore().setToken(resp.headers['access-token'])
  }

  if (resp.headers['x-access-token']) {
    userStore().setRefreshToken(resp.headers['x-access-token']);
  }

  // 二进制数据则直接返回
  if (resp.request.responseType === "blob" || resp.request.responseType === "arraybuffer") {
    return resp.data;
  }

  // console.log("resp", resp)

  if (resp.data) {
    let code = resp.data.code || 200;
    if (401 == code) {
      console.log("401");
      userStore().logout().then(() => {
        // router.replace("/login");  //不能使用router.replace()，否则如果401，userStore.getLoginUserInfo()还是会继续执行，回调中的 resp 是 undifiend，会产生error
        location.href = "/login";
      }).catch((error) => {
        console.log("error", error);
        location.href = "/login";
      });
    } else if (400 == code) {
      // console.log("400");
      let message = "opps~~";
      if (resp.data.message) message += resp.data.message;
      // ElMessage({
      //   type: "warning",
      //   message: message
      // });
      // return Promise.reject(new Error(message));
      return Promise.reject(message);
    } else if (500 == code) {
      console.log("500");
    } else if (200 != code) {
      console.log("未知错误", code)
    } else {
      return resp.data;
    }
  } else {
    console.log("服务器错误~~");
    router.replace("/login");
  }
},
  error => {
    console.log("error", error);
  }
)

// instance.interceptors.response.use(
//   response => {
//     // console.log("response", response);

//     //拦截请求，统一相应
//     // if (response.data.success) {
//     //     return response.data
//     // } else {
//     //     ElMessage.error(response.data.msg)
//     //     return response.data.result
//     // }

//     if (response.data) {
//       let resp = response.data;
//       if (resp.code == 401) //未认证
//       {
//         store.commit("SetUserInfo", null);
//         router.replace("/Login");
//       } else if (resp.code == 450) {
//         localStorage["accessToken"] = null;
//         store.commit("SetUserInfo", null);
//         router.replace("/Login");
//       } else if (resp.code >= 400 && resp.code <= 500) {
//         //ElMessage.error(resp.message)
//         console.log(resp);
//       }
//       return resp;
//     } else {
//       console.log(response);
//       ElMessage.error("内部服务器错误，请联系系统管理员！")
//       return null;
//     }
//   },
//   //error也可以处理
//   error => {
//     console.log("error", error);
//     if (error.response) {
//       switch (error.response.status) {
//         case 401:
//           ElMessage.warning("资源没有访问权限！")
//           break
//         case 404:
//           ElMessage.warning("接口不存在，请检查接口地址是否正确！")
//           break
//         case 500:
//           ElMessage.warning("内部服务器错误，请联系系统管理员！")
//           break
//         default:
//           return Promise.reject(error.response.data)   // 返回接口返回的错误信息 
//       }
//     }
//     else {
//       ElMessage.error("遇到跨域错误，请设置代理或者修改后端允许跨域访问！")
//     }
//   }
// )

export default instance