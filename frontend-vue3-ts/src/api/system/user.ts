import instance from "@/utils/request"
import { download } from "@/utils/util"

export const pageUser = (params: any) => {
  return instance.get("userinfo/page", { params });
}

export const detailUser = (params: any) => {
  return instance.get("userinfo/detail", { params });
}

export const addUser = (data: {}) => {
  return instance.post("userinfo/add", data);
}

export const editUser = (data: {}) => {
  return instance.post("userinfo/edit", data);
}

export const delUser = (data: {}) => {
  return instance.post("userinfo/delete", data);
}

export const batchdelUser = (data: {}) => {
  return instance.post("userinfo/batchdelete", data);
}

export const downloadtemplateUser = () => {
  download("userinfo/downloadtemplate", {}, "用户导入模板.xlsx");
}

export const importUser = (file: Blob, updateSupport: Boolean) => {
  var formData = new FormData();
  formData.append("file", file);
  formData.append("updateSupport", updateSupport.toString());
  return instance.post("userinfo/import", formData);
}

export const exportUser = (params: any) => {
  download("userinfo/export", params, "用户列表.xlsx");
}



