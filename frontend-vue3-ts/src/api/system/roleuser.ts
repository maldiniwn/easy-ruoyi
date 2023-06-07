import instance from "@/utils/request"

export const getUserRoles = (params: any) => {
  return instance.get("roleuser/getUserRoles", { params });
}

export const save = (data: {}) => {
  return instance.post("roleuser/save", data);
}