<template>
  <el-dialog title="新增角色" v-model="dialogVisible" :close-on-click-modal="false" append-to-body @close="close()">
    <el-form ref="formRef" :model="reactiveData.form" :rules="rules" label-width="100px">
      <el-row>
        <el-col :span="12">
          <el-form-item label="角色名称" prop="name">
            <el-input v-model="reactiveData.form.name" placeholder="请输入角色名称" maxlength="50" show-word-limit></el-input>
          </el-form-item>
        </el-col>
        <el-col :span="12">
          <el-form-item label="角色编号" prop="roleCode">
            <el-input v-model="reactiveData.form.roleCode" placeholder="请输入角色编号" maxlength="50"
              show-word-limit></el-input>
          </el-form-item>
        </el-col>
        <el-col :span="24">
          <el-form-item label="是否启用" prop="isEnable">
            <el-switch v-model="reactiveData.form.isEnable" active-text="是" inactive-text="否" />
          </el-form-item>
        </el-col>
        <el-col :span="24">
          <el-form-item label="描述">
            <el-input v-model="reactiveData.form.description" placeholder="请输入角色描述" maxlength="1000"
              show-word-limit></el-input>
          </el-form-item>
        </el-col>
      </el-row>
    </el-form>

    <template #footer>
      <el-button @click="close">关 闭</el-button>
      <el-button type="primary" @click="submit(formRef)">提 交</el-button>
    </template>
  </el-dialog>
</template>

<script setup lang="ts">
import { ref, reactive } from "vue";
import { FormInstance, FormRules } from "element-plus";

const dialogVisible = ref(false)
const formRef = ref<FormInstance>()
let callback: Function;

const reactiveData = reactive({
  form: {
    name: "",
    roleCode: "",
    isEnable: true,
    description: "",
  }
})

// 表单校验
const rules = reactive<FormRules>({
  name: [{ required: true, message: "角色名称不能为空", trigger: "blur" }],
  roleCode: [{ required: true, message: "角色编号不能为空", trigger: "blur" },
  { pattern: /^[a-zA-Z0-9]{1,50}$/, message: '角色编号必须是字母与数字的组合' }],
  isEnable: [{ required: true, message: "是否启用不能为空", trigger: "blur" }]
});

const show = (cb: any) => {
  callback = cb;
  dialogVisible.value = true;
}

const close = () => {
  if (dialogVisible.value == false) return;

  // console.log("dialog close" + new Date().getTime())
  formRef.value?.resetFields();
  dialogVisible.value = false;
}

const submit = (formRef: FormInstance | undefined) => {
  if (!formRef) return;

  formRef.validate((valid, fields) => {
    if (valid) {
      if (callback) {
        callback(reactiveData.form);
      }
    } else {
      console.log('error submit!', fields)
    }
  })
}

defineExpose({
  show,
  close
})
</script>

<style lang="scss" scoped></style>