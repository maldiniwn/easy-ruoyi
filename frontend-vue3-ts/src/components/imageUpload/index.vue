<template>
  <el-upload ref="uploadRef" action="" :file-list="fileList" :http-request="handleHttpRequest"
    :before-upload="handleBeforeUpload" :limit="limit" :accept="accept" :show-file-list="false" multiple
    v-loading.fullscreen.lock="loading" element-loading-text="图片上传中..." element-loading-spinner="el-icon-loading"
    element-loading-background="rgba(0,0,0,0.1)" style="width: 100%;">
    <el-button type="primary">上 传</el-button>
    <template #tip>
      <div class="el-upload__tip" v-if="props.isShowTip">
        请上传不超过 <b style="color: #f56c6c">{{ props.fileSize }}MB</b>
        的图片（{{ fileList.length }} / {{ props.limit }}）
      </div>
    </template>
  </el-upload>

  <ul class="el-upload-list el-upload-list--picture-card">
    <li class="el-upload-list__item" v-for="(file, index) in fileList" :key="file.id">
      <img class="el-upload-list__item-thumbnail" :src="file.url" :alt="file.name" />
      <span class="el-upload-list__item-actions">
        <span class="el-upload-list__item-preview" @click="handlePictureCardPreview(file.url)">
          <el-icon><zoom-in /></el-icon>
        </span>
        <span class="el-upload-list__item-delete" @click="handleRemove(index)">
          <el-icon>
            <Delete />
          </el-icon>
        </span>
      </span>
    </li>
  </ul>

  <el-dialog v-model="previewDialogVisible" append-to-body>
    <img style="width: 100%; height: 100%;" :src="previewImageUrl" />
  </el-dialog>
</template>

<script setup lang="ts">
import { ref, reactive, getCurrentInstance, watch } from "vue";
import { UploadProps, UploadUserFile, UploadRequestOptions, UploadInstance, UploadFile } from "element-plus"
import { uploadFile } from "@/api/fileserver/sysfile"

interface SysFileBase {
  id: string;
  name: string;
  length: number;
  url: string;
}


const props = defineProps({
  /** 
   * 数组json字符串。
   * 格式: "[{id:'',name:'',length:'',url:''},{id:'',name:'',length:'',url:''}]"
   */
  modelValue: {
    type: String,
    default: ""
  },
  /** 允许上传文件的最大数量 */
  limit: {
    type: Number,
    default: 5,
  },
  /** 单个文件大小（MB） */
  fileSize: {
    type: Number,
    default: 5,
  },
  /** 接受上传的文件类型 */
  accept: {
    type: String,
    default: ".tiff,.pjp,.jfif,.bmp,.gif,.svg,.png,.xbm,.dib,.jxl,.jpeg,,svgz,.jpg,.webp,.ico,.tif,.pjpeg,.avif",
  },
  /** 是否显示提示 */
  isShowTip: {
    type: Boolean,
    default: true,
  },
});

const emit = defineEmits(["update:modelValue"]);

const { proxy }: any = getCurrentInstance();

const fileList = ref<SysFileBase[]>([]);
const loading = ref<boolean>(false);
const previewDialogVisible = ref<boolean>(false);
const previewImageUrl = ref<string>("");

const uploadRef = ref<UploadInstance>();

const handleHttpRequest = (options: UploadRequestOptions) => {
  loading.value = true;
  var pro = new Promise((resolve, reject) => {
    uploadFile(options.file).then((resp: any) => {
      if (resp.code == 200 && resp.success) {
        // let uploadFile = uploadRef.value?.uploadFiles[uploadRef.value?.uploadFiles.length - 1];
        // if (null != uploadFile) {
        //   uploadFile.uid = resp.data;
        // }

        fileList.value.push(resp.data);
        emitResult();
      }
    }).finally(() => {
      loading.value = false;
    })

    resolve("");
  })

  return pro;
}

/** 上传前 */
const handleBeforeUpload: UploadProps['beforeUpload'] = (rawFile) => {
  //校检格式
  if (props.accept && props.accept.length > 0) {
    let fileExtension = rawFile.name.slice(rawFile.name.lastIndexOf("."));
    if (props.accept.indexOf(fileExtension) < 0) {
      proxy.$modal.msgError(
        `图片格式不正确, 请上传${props.accept}格式图片!`
      );
      return false;
    }
  }

  //校验大小
  if (props.fileSize) {
    let size = rawFile.size / 1024 / 1024;
    if (size > props.fileSize) {
      proxy.$modal.msgError(`上传图片大小不能超过 ${props.fileSize} MB!`);
      return false;
    }
  }

  return true;
}

const handlePictureCardPreview = (url: string) => {
  previewDialogVisible.value = true;
  previewImageUrl.value = url;
}

const handleRemove = (index: number) => {
  // console.log("handleRemove index:", index);
  fileList.value.splice(index, 1);

  emitResult();
}

const emitResult = () => {
  // console.log("fileList", fileList.value)
  let result = "";
  if (fileList.value.length > 0) {
    result = JSON.stringify(fileList.value);
  }

  // console.log("result", result)
  emit("update:modelValue", result);
}

watch(() => props.modelValue,
  (newVal, oldVal) => {
    // console.log("watch newVal", newVal);
    // console.log("watch oldVal", oldVal);
    fileList.value = [];
    if (props.modelValue) {
      let arr = JSON.parse(props.modelValue);
      if (Array.isArray(arr)) {
        for (var d of arr) {
          fileList.value.push({
            id: d.id,
            name: d.name,
            url: d.url,
            length: d.length,
          });
        }
      }
    } else {
      emit("update:modelValue", "");
    }
  },
  { immediate: true });
</script>

<style lang="scss" scoped></style>