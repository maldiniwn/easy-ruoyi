import instance from "@/utils/request"
import { download } from "@/utils/util"

export const pageMenu = (params: any) => {
  return instance.get("menu/page", { params });
}

export const listMenu = () => {
  return instance.get("menu/list");
}

export const detailMenu = (params: any) => {
  return instance.get("menu/detail", { params });
}

export const addMenu = (data: {}) => {
  return instance.post("menu/add", data);
}

export const editMenu = (data: {}) => {
  return instance.post("menu/edit", data);
}

export const delMenu = (data: {}) => {
  return instance.post("menu/delete", data);
}

export const batchdelMenu = (data: {}) => {
  return instance.post("menu/batchdelete", data);
}

// export const downloadtemplateMenu = () => {
//   download("menu/downloadtemplate", {}, "菜单导入模板.xlsx");
// }

// export const importMenu = (file: Blob, updateSupport: Boolean) => {
//   var formData = new FormData();
//   formData.append("file", file);
//   formData.append("updateSupport", updateSupport.toString());
//   return instance.post("menu/import", formData);
// }

export const exportMenu = (params: any) => {
  download("menu/export", params, "菜单列表.xlsx");
}

export const menuTree = () => {
  return instance.get("menu/tree");
}

