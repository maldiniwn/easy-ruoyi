import instance from "@/utils/request"
import { download } from "@/utils/util"

export const downloadImportErrorFile = (id: string, filename: string) => {
  download("sysfile/downloadimporterrorfile", { id }, filename);
}