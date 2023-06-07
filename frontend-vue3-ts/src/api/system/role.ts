import instance from "@/utils/request"
import { download } from "@/utils/util"

export const pageRole = (params: any) => {
  return instance.get("role/page", { params });
}

export const listRole = () => {
  return instance.get("role/list");
}

export const detailRole = (params: any) => {
  return instance.get("role/detail", { params });
}

export const addRole = (data: {}) => {
  return instance.post("role/add", data);
}

export const editRole = (data: {}) => {
  return instance.post("role/edit", data);
}

export const delRole = (data: {}) => {
  return instance.post("role/delete", data);
}

export const batchdelRole = (data: {}) => {
  return instance.post("role/batchdelete", data);
}

export const downloadtemplateRole = () => {
  download("role/downloadtemplate", {}, "角色导入模板.xlsx");
}

export const importRole = (file: Blob, updateSupport: Boolean) => {
  var formData = new FormData();
  formData.append("file", file);
  formData.append("updateSupport", updateSupport.toString());
  return instance.post("role/import", formData);
}

export const exportRole = (params: any) => {
  download("role/export", params, "角色列表.xlsx");
}



