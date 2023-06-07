<template>
  <el-dialog title="修改头像" v-model="dialogVisible" width="800px" append-to-body @close="close()">
    <el-row>
      <el-col :xs="24" :md="12" :style="{ height: '350px' }">
        <vue-cropper ref="cropperRef" :img="options.img" :info="true" :autoCrop="options.autoCrop"
          :autoCropWidth="options.autoCropWidth" :autoCropHeight="options.autoCropHeight" :fixedBox="options.fixedBox"
          @realTime="realTime" />
      </el-col>
      <el-col :xs="24" :md="12" :style="{ height: '350px' }">
        <div class="avatar-upload-preview">
          <img :src="options.previews.url" :style="options.previews.img" />
        </div>
      </el-col>
    </el-row>
    <br />
    <el-row>
      <el-col :lg="2" :md="2">
        <el-upload action="#" :http-request="requestUpload" :show-file-list="false" :before-upload="beforeUpload">
          <el-button size="small">
            选择
            <i class="upload -right"></i>
          </el-button>
        </el-upload>
      </el-col>
      <el-col :lg="{ span: 1, offset: 2 }" :md="2">
        <el-button icon="plus" size="small" @click="changeScale(1)"></el-button>
      </el-col>
      <el-col :lg="{ span: 1, offset: 1 }" :md="2">
        <el-button icon="minus" size="small" @click="changeScale(-1)"></el-button>
      </el-col>
      <el-col :lg="{ span: 1, offset: 1 }" :md="2">
        <el-button icon="refresh-left" size="small" @click="rotateLeft()"></el-button>
      </el-col>
      <el-col :lg="{ span: 1, offset: 1 }" :md="2">
        <el-button icon="refresh-right" size="small" @click="rotateRight()"></el-button>
      </el-col>
      <el-col :lg="{ span: 2, offset: 6 }" :md="2">
        <el-button type="primary" size="small" @click="uploadImg()">提 交</el-button>
      </el-col>
    </el-row>
  </el-dialog>
</template>

<script setup lang="ts">
import { ref, reactive, getCurrentInstance } from "vue";
import { UploadRawFile } from "element-plus"
import { UploadItemModel } from "@/models/UploadItemModel"
import { uploadFile } from "@/api/fileserver/sysfile"
import { updateHeadUrl } from "@/api/system/usercenter"

const { proxy }: any = getCurrentInstance();

let callback: Function;

/** 是否显示dialog */
const dialogVisible = ref(false);
/** 选择的图片文件 */
const uploadImageFile = ref<UploadRawFile>();

const options = reactive<any>({
  /** 头像地址 */
  img: "",
  /** 是否默认生成截图框 */
  autoCrop: true,
  /** 默认生成截图框宽度 */
  autoCropWidth: 200,
  /** 默认生成截图框高度 */
  autoCropHeight: 200,
  /** 固定截图框大小 不允许改变 */
  fixedBox: true,
  /** 预览 */
  previews: {
    /** 预览url */
    url: "",
    /** 预览图片 */
    img: "",
  },
});

/** 显示 */
const show = (url: string, cb: any) => {
  options.img = url;
  callback = cb;
  dialogVisible.value = true;
}

/** 关闭 */
const close = () => {
  if (dialogVisible.value == false) return;

  dialogVisible.value = false;
}

/** 实时预览 */
const realTime = (data: any) => {
  options.previews = data;
};

/** 覆盖默认的上传行为 */
const requestUpload: any = () => { };

/** 向左旋转 */
const rotateLeft = () => {
  proxy.$refs.cropperRef.rotateLeft();
};

/** 向右旋转 */
const rotateRight = () => {
  proxy.$refs.cropperRef.rotateRight();
};

/** 图片缩放 */
const changeScale = (num: any) => {
  num = num || 1;
  proxy.$refs.cropperRef.changeScale(num);
};

/** 上传预处理 */
const beforeUpload = (file: UploadRawFile) => {
  if (file.type.indexOf("image/") == -1) {
    proxy.$modal.msgError("文件格式错误，请上传图片类型,如：JPG，PNG后缀的文件。");
    return false;
  }

  let size = file.size / 1024 / 1024;
  if (size > 5) {
    proxy.$modal.msgError(`上传图片大小不能超过 5 MB!`);
    return false;
  }

  uploadImageFile.value = file;
  const reader = new FileReader();
  reader.readAsDataURL(file);
  reader.onload = () => {
    options.img = reader.result;
  };
};

/** 上传图片 */
const uploadImg = () => {
  if (uploadImageFile.value) {
    proxy.$refs.cropperRef.getCropBlob((data: any) => {
      // console.log(uploadImageFile.value?.name)
      uploadFile(data, uploadImageFile.value?.name).then((resp: any) => {
        if (resp.code === 200) {
          return Promise.resolve(resp.data);
        }
      }).then((data: UploadItemModel) => {
        var ids: string[] = [];
        ids.push(data.id);
        let updateData = { headUrl: JSON.stringify(ids) };
        updateHeadUrl(updateData).then((resp: any) => {
          if (resp.code === 200) {
            uploadImageFile.value = undefined;
            proxy.$modal.msgSuccess("修改成功");
            if (callback) {
              callback();
            }
          }
        })
      });
    });
  } else {
    proxy.$modal.msgError("请先选择头像图片！");
  }
};

defineExpose({
  show,
  close
})
</script>

<style lang="scss" scoped></style>