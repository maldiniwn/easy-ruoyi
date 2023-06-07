import instance from "@/utils/request"

export const editEmp = (data: {}) => {
  return instance.post("usercenter/editEmp", data);
}

export const updatePwd = (data: {}) => {
  return instance.post("usercenter/updatePwd", data);
}

export const getHeadUrl = () => {
  return instance.get("usercenter/getHeadUrl");
}

export const updateHeadUrl = (data: {}) => {
  return instance.post("usercenter/updateHeadUrl", data);
}