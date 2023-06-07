import instance from "@/utils/fileServerRequest"
import { download } from "@/utils/util"

export const uploadFile = (file: Blob, fileName?: string) => {
  var formData = new FormData();
  if (fileName && fileName.length > 0) {
    formData.append("file", file, fileName);
  } else {
    formData.append("file", file);
  }
  return instance.post("sysfile/upload", formData);
}

export const downloadFile = (id: string, filename: string) => {
  download("sysfile/download", { id }, filename);
}

export const getSysFiles = (params: any) => {
  return instance.get("sysfile/getSysFiles", { params });
}

