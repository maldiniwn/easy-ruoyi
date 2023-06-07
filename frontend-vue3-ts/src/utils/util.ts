import instance from "@/utils/request"
import { tansParams, blobValidate } from "@/utils/ruoyi";
import errorCode from "@/utils/errorCode";
import { ElNotification, ElMessageBox, ElLoading, ElMessage } from "element-plus";
import { saveAs } from "file-saver";

export const download = async (url: string, params: any, filename: string) => {
  const downloadLoadingInstance = ElLoading.service({ text: "正在下载数据，请稍候", spinner: "loading", background: "rgba(0, 0, 0, 0.7)", });
  let req = null;
  req = instance.get(url, {
    params,
    headers: { "Content-Type": "application/x-www-form-urlencoded" },
    responseType: "blob",
  });

  return await req
    .then(async (resp: any) => {
      const isLogin = await blobValidate(resp);
      if (isLogin) {
        const blob = new Blob([resp]);
        // saveAs(blob, filename, {
        // 	type: "application/octet-stream;charset=utf-8"
        // });
        saveAs(blob, filename);
        //var blob2 = new Blob([resp], {type: "text/plain;charset=utf-8"});
        //saveAs(blob, resp.msg + ".xlsx");
        console.log("%s ====>>>导出成功", filename);
      } else {
        const resText = resp.text();
        const rspObj = JSON.parse(resText);
        const errMsg = errorCode[rspObj.code] || rspObj.msg || errorCode['default']
        ElMessage.error(errMsg);
      }
      downloadLoadingInstance.close();
    })
    .catch((r) => {
      console.error(r);
      ElMessage.error("下载文件出现错误，请联系管理员！");
      downloadLoadingInstance.close();
    });
};