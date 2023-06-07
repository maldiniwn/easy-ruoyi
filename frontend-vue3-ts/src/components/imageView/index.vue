<template>
  <el-image :style="{ width: props.width + 'px', height: props.height + 'px' }" v-for="(file, index) in  fileList "
    :key="file.id" :src="file.url" :zoom-rate="1.2" :preview-src-list="[file.url]" fit="fill" />
</template>

<script setup lang="ts">
import { ref, reactive, watch } from "vue";
import { UploadItemModel } from "@/models/uploadItemModel"

const props = defineProps({
  /** 
   * 数组json字符串。
   * 格式: "[{id:'',name:'',length:'',url:''},{id:'',name:'',length:'',url:''}]"
   */
  modelValue: {
    type: String,
    default: ""
  },
  width: {
    type: Number,
    default: 150
  },
  height: {
    type: Number,
    default: 150
  }
})

const fileList = ref<UploadItemModel[]>();

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

<style lang="scss" scoped></style>