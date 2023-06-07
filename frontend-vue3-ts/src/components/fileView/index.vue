<template>
  <ul class="upload-file-list el-upload-list el-upload-list--text" name="el-fade-in-linear">
    <li class="el-upload-list__item ele-upload-list__item-content" v-for="(file, index) in fileList" :key="file.id">
      <span>{{ file.name }}</span>
      <div class="ele-upload-list__item-content-action">
        <el-link :underline="false" @click="download(file)" type="primary">下载</el-link>
      </div>
    </li>
  </ul>
</template>

<script setup lang="ts">
import { ref, reactive, watch } from "vue";
import { UploadItemModel } from "@/models/uploadItemModel"
import { downloadFile } from "@/api/fileserver/sysfile"

const props = defineProps({
  /** 
   * 数组json字符串。
   * 格式: "[{id:'',name:'',length:'',url:''},{id:'',name:'',length:'',url:''}]"
   */
  modelValue: {
    type: String,
    default: ""
  }
})

const fileList = ref<UploadItemModel[]>();

const download = (file: UploadItemModel) => {
  downloadFile(file.id, file.name)
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
    }
  },
  { immediate: true });
</script>

<style lang="scss" scoped>
.upload-file-uploader {
  margin-bottom: 5px;
}

.upload-file-list .el-upload-list__item {
  // border: 1px solid #e4e7ed;
  cursor: pointer;
  line-height: 1.5;
  // margin-bottom: 5px;
  position: relative;
}

.upload-file-list .ele-upload-list__item-content {
  display: flex;
  justify-content: space-between;
  align-items: center;
  color: inherit;
}

.ele-upload-list__item-content-action .el-link {
  margin-right: 10px;
}
</style>