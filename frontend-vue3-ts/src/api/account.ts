import instance from "@/utils/request"

/**
 * 获取验证码图片base64
 * @returns 
 */
export const captchaImage = () => {
  return instance.get("account/captchaImage");
}

/**
 * 登录
 * @param data 
 * @returns 
 */
export const login = (data: {}) => {
  return instance.post("account/login", data);
}

/**
 * 获取当前登录用户信息
 * @returns 
 */
export const getLoginUserInfo = () => {
  return instance.get("account/getLoginUserInfo");
}

/**
 * 获取路由信息
 * @returns 
 */
export const getRouterAndMenu = () => {
  return instance.get("account/getRouterAndMenu");
}