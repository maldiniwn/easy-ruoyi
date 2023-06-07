<template>
  <!-- 导入用户 -->
  <el-dialog title="导入用户" v-model="dialogVisible" width="400px" :close-on-click-modal="false" append-to-body
    @close="close">
    <el-upload ref="importRef" action="" accept=".xls, .xlsx" v-loading="reactiveData.upload.isUploading"
      :disabled="reactiveData.upload.isUploading" :http-request="importData" :auto-upload="false" :limit="1" drag>
      <el-icon class="el-icon--upload"><upload-filled /></el-icon>
      <div class="el-upload__text">
        将文件拖到此处，或
        <em>点击上传</em>
      </div>
      <template #tip>
        <div class="el-upload__tip" style="overflow: hidden; clear:both;">
          <div style="float:left;width:180px;"><el-checkbox
              v-model="reactiveData.upload.updateSupport">是否更新已经存在的用户数据</el-checkbox></div>
          <div style="float:left;margin-left:5px;margin-top:-1px; height: 24px; line-height: 24px;"><el-link type="info"
              style="font-size:12px" @click="downloadTemplate">【下载模板】</el-link></div>
        </div>
        <div class="el-upload__tip" style="color:red">提示：仅允许导入“xls”或“xlsx”格式文件！</div>
      </template>
    </el-upload>
    <template #footer>
      <div class="dialog-footer">
        <el-button @click="close">取 消</el-button>
        <el-button type="primary" @click="submit">确 定</el-button>
      </div>
    </template>
  </el-dialog>
</template>

<script setup lang="ts">
import { ref, reactive } from "vue";
import { ElMessage, ElLoading, UploadRequestOptions, ElUpload } from "element-plus";
import { downloadtemplateUser, importUser } from "@/api/system/user"
import { downloadImportErrorFile } from "@/api/system/sysfile"

const dialogVisible = ref(false)
let callback: Function;

const importRef = ref<InstanceType<typeof ElUpload>>();

//reactiveData
const reactiveData = reactive({
  //上传数据
  upload: {
    // 是否禁用上传
    isUploading: false,
    // 是否更新已经存在的数据
    updateSupport: false
  }
})

//显示
const show = (cb: Function) => {
  callback = cb;
  reactiveData.upload.isUploading = false;
  reactiveData.upload.updateSupport = false;

  dialogVisible.value = true;
}

//下载导入模板
const downloadTemplate = () => {
  downloadtemplateUser();
}

//导入方法
const importData = (options: UploadRequestOptions) => {
  reactiveData.upload.isUploading = true;
  var pro = new Promise((resolve, reject) => {
    importUser(options.file, reactiveData.upload.updateSupport).then((resp: any) => {
      if (resp.success) {
        if (resp.data.code == 200) {
          ElMessage({
            type: "success",
            message: resp.data.message
          });

          // dialogVisible.value = false;
          if (callback) {
            callback();
          }
        } else if (resp.data.code == 20001) {
          ElMessage({
            type: "warning",
            message: resp.data.message
          });
          downloadErrorFile(resp.data.data);
        } else {
          console.log("unknow", resp);
        }
      }
    }).finally(() => {
      reactiveData.upload.isUploading = false;
    })
  })

  return pro;
}

//下载导入错误提示文件
const downloadErrorFile = (id: string) => {
  downloadImportErrorFile(id, "用户导入模板_Error.xlsx");
}

//提交
const submit = () => {
  importRef.value?.submit();
}

//关闭
const close = () => {
  importRef.value?.clearFiles();
  dialogVisible.value = false;
}

defineExpose({
  show,
  close
})
</script>

<style lang="scss" scoped></style>