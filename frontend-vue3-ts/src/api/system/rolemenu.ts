import instance from "@/utils/request"

export const getRoleMenus = (params: any) => {
  return instance.get("rolemenu/getRoleMenus", { params });
}

export const save = (data: {}) => {
  return instance.post("rolemenu/save", data);
}