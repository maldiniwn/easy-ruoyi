<template>
  <el-dialog title="用户详情" v-model="dialogVisible" :close-on-click-modal="false" append-to-body @close="close()">
    <el-descriptions :column="2" border>
      <el-descriptions-item :span="2">
        <template #label>
          头像
        </template>
        <!-- {{ reactiveData.form.headUrl }} -->
        <image-view v-model="reactiveData.form.headUrl" :width="100" :height="100"></image-view>
        <file-view v-model="reactiveData.form.headUrl"></file-view>
      </el-descriptions-item>

      <el-descriptions-item>
        <template #label>
          用户名
        </template>
        {{ reactiveData.form.userName }}
      </el-descriptions-item>

      <el-descriptions-item>
        <template #label>
          姓名
        </template>
        {{ reactiveData.form.name }}
      </el-descriptions-item>

      <el-descriptions-item>
        <template #label>
          性别
        </template>
        {{ reactiveData.form.enumGenderStr }}
      </el-descriptions-item>

      <el-descriptions-item>
        <template #label>
          是否启用
        </template>
        {{ reactiveData.form.isEnableStr }}
      </el-descriptions-item>

      <el-descriptions-item>
        <template #label>
          手机号
        </template>
        {{ reactiveData.form.tel }}
      </el-descriptions-item>

      <el-descriptions-item>
        <template #label>
          身份证
        </template>
        {{ reactiveData.form.sid }}
      </el-descriptions-item>

      <el-descriptions-item>
        <template #label>
          出生日期
        </template>
        {{ reactiveData.form.bornDateStr }}
      </el-descriptions-item>

      <el-descriptions-item>
        <template #label>
          创建人
        </template>
        {{ reactiveData.form.createdUserName }}
      </el-descriptions-item>

      <el-descriptions-item>
        <template #label>
          创建时间
        </template>
        {{ reactiveData.form.createdTime }}
      </el-descriptions-item>

      <el-descriptions-item>
        <template #label>
          修改人
        </template>
        {{ reactiveData.form.updatedUserName }}
      </el-descriptions-item>

      <el-descriptions-item>
        <template #label>
          修改时间
        </template>
        {{ reactiveData.form.updatedTime }}
      </el-descriptions-item>
    </el-descriptions>

    <template #footer>
      <el-button type="primary" @click="dialogVisible = false">关 闭</el-button>
    </template>
  </el-dialog>
</template>

<script setup lang="ts">
import { ref, reactive } from "vue";
import imageView from "@/components/imageView/index.vue"
import fileView from "@/components/fileView/index.vue"
import { detailUser } from "@/api/system/user"

const dialogVisible = ref(false)

const reactiveData = reactive({
  form: {
    id: "",
    userName: "",
    name: "",
    enumGenderStr: "",
    tel: "",
    sid: "",
    bornDateStr: "",
    isEnableStr: "",
    headUrl: "",
    createdUserName: "",
    createdTime: "",
    updatedUserName: "",
    updatedTime: ""
  }
})

const show = (id: string) => {
  // console.log("id", id);
  let params = { id };
  detailUser(params).then((resp: any) => {
    if (resp.code == 200 && resp.success) {
      reactiveData.form = resp.data;
      // console.log("reactiveData.form", reactiveData.form);
      dialogVisible.value = true;
    }
  })
}

const close = () => {
  // console.log("dialog close" + new Date().getTime())
  dialogVisible.value = false;
}

defineExpose({
  show
})
</script>

<style lang="scss" scoped></style>