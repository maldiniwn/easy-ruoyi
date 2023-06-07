<template>
  <el-dialog title="角色详情" v-model="dialogVisible" :close-on-click-modal="false" append-to-body @close="close()">
    <el-descriptions :column="2" border>
      <el-descriptions-item>
        <template #label>
          角色名称
        </template>
        {{ reactiveData.form.name }}
      </el-descriptions-item>

      <el-descriptions-item>
        <template #label>
          角色编号
        </template>
        {{ reactiveData.form.roleCode }}
      </el-descriptions-item>

      <el-descriptions-item>
        <template #label>
          是否启用
        </template>
        {{ reactiveData.form.isEnableStr }}
      </el-descriptions-item>

      <el-descriptions-item>
        <template #label>
          描述
        </template>
        {{ reactiveData.form.description }}
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
import { detailRole } from "@/api/system/role"

const dialogVisible = ref(false)

const reactiveData = reactive({
  form: {
    id: "",
    name: "",
    roleCode: "",
    isEnable: true,
    isEnableStr: "",
    description: "",
    createdUserName: "",
    createdTime: "",
    updatedUserName: "",
    updatedTime: ""
  }
})

const show = (id: string) => {
  // console.log("id", id);
  let params = { id };
  detailRole(params).then((resp: any) => {
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