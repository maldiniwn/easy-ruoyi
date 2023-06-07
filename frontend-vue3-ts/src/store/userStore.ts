import { defineStore } from 'pinia'
import { login, getLoginUserInfo } from "@/api/account"

export const userStore = defineStore('userStore', {
  state: () => {
    return {
      id: "",
      userName: "",
      name: "",
      roles: [] as any,
      permissions: [] as any,
      accessToken: "",
      refreshToken: ""
    }
  },
  actions: {
    setToken(value: string) {
      this.accessToken = value;
    },
    getToken(): string {
      return this.accessToken;
    },
    setRefreshToken(value: string) {
      this.refreshToken = value;
    },
    getRefreshToken(): string {
      return this.refreshToken;
    },
    /**
     * 登录
     * @param userInfo 
     * @returns 
     */
    userLogin(userInfo: { userName: string; password: string; code: string, captchaToken: string }) {
      return new Promise<void>((resolve, reject) => {
        login(userInfo).then((resp: any) => {
          if (resp.code == 200 && resp.success) {
            this.accessToken = resp.data.token;
            resolve();
          } else {
            reject();
          }
        }).catch((error: any) => {
          reject(error);
        })
      })
    },
    /**
     * 获取当前用户信息
     */
    getLoginUserInfo() {
      return new Promise<void>((resolve, reject) => {
        getLoginUserInfo().then((resp: any) => {
          if (resp.code == 200 && resp.success) {
            this.id = resp.data.id;
            this.userName = resp.data.userName;
            this.name = resp.data.name;
            this.roles = resp.data.roleCodes;
            this.permissions = resp.data.permissionCodes;
            resolve();
          } else {
            reject();
          }
        }).catch((error: any) => {
          console.log("getLoginUserInfo error", error)
          reject(error);
        })
      })
    },
    /**
     * 退出系统
     */
    logout() {
      return new Promise<void>((resolve, reject) => {
        this.id = "";
        this.userName = "";
        this.name = "";
        this.roles = [];
        this.permissions = [];
        this.accessToken = "";
        this.refreshToken = "";
        resolve();
      })
    }
  },
  persist: {
    enabled: true,	//默认持久化到sessionStorage
    strategies: [
      {
        key: 'userStore',	//持久化的key
        // storage: localStorage,	//持久化的区域 sessionStorage、localStorage、cookiesStorage(default: sessionStorage)
        paths: ['accessToken', 'refreshToken']	//持久化的state中的key列表
      },
    ],
  }
})