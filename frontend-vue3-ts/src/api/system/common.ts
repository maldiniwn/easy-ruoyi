import instance from "@/utils/request"

export const getenums = (params: any) => {
  return instance.get("common/getenums", { params });
}