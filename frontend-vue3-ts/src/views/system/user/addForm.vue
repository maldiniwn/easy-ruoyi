<template>
  <el-dialog title="新增用户" v-model="dialogVisible" :close-on-click-modal="false" append-to-body @close="close()">
    <el-form ref="formRef" :model="reactiveData.form" :rules="rules" label-width="100px">
      <el-row>
        <el-col :span="12">
          <el-form-item label="用户名" prop="userName">
            <el-input v-model="reactiveData.form.userName" placeholder="请输入用户名" maxlength="50" show-word-limit></el-input>
          </el-form-item>
        </el-col>
        <el-col :span="12">
          <el-form-item label="姓名" prop="name">
            <el-input v-model="reactiveData.form.name" placeholder="请输入姓名" maxlength="50" show-word-limit></el-input>
          </el-form-item>
        </el-col>
        <el-col :span="12">
          <el-form-item label="性别" prop="enumGender">
            <el-radio-group v-model="reactiveData.form.enumGender">
              <el-radio v-for="(item, index) in reactiveData.enumGenderList" :index="index" :label="item.value">
                {{ item.label }}</el-radio>
            </el-radio-group>
          </el-form-item>
        </el-col>
        <el-col :span="12">
          <el-form-item label="手机号" prop="tel">
            <el-input v-model="reactiveData.form.tel" placeholder="请输入手机号" maxlength="11" show-word-limit></el-input>
          </el-form-item>
        </el-col>
        <el-col :span="12">
          <el-form-item label="身份证" prop="sid">
            <el-input v-model="reactiveData.form.sid" placeholder="请输入身份证" maxlength="18" show-word-limit></el-input>
          </el-form-item>
        </el-col>
        <el-col :span="12">
          <el-form-item label="出生日期" prop="bornDate">
            <el-date-picker v-model="reactiveData.form.bornDate" type="date" placeholder="请选择出生日期" style="width:100%;" />
          </el-form-item>
        </el-col>
        <el-col :span="24">
          <el-form-item label="是否启用" prop="isEnable">
            <el-switch v-model="reactiveData.form.isEnable" active-text="是" inactive-text="否" />
          </el-form-item>
        </el-col>
        <el-col :span="24">
          <el-form-item label="图片" prop="headUrl">
            <image-upload v-model="reactiveData.form.headUrl" :limit="1"></image-upload>
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
import imageUpload from "@/components/imageUpload/index.vue"
import { getenums } from "@/api/system/common"

const dialogVisible = ref(false)
const formRef = ref<FormInstance>()
let callback: Function;

const reactiveData = reactive({
  form: {
    userName: "",
    name: "",
    enumGender: 0,
    tel: "",
    sid: "",
    bornDate: "",
    isEnable: true,
    headUrl: ""
  },
  //性别列表数据源
  enumGenderList: [] as any[]
})

// 表单校验
const rules = reactive<FormRules>({
  userName: [{ required: true, message: "用户名不能为空", trigger: "blur" }],
  name: [{ required: true, message: "姓名不能为空", trigger: "blur" }],
  tel: [{ pattern: /^1\d{10}$/, message: '手机号格式错误' }],
  sid: [{ pattern: /(^[1-9]\d{5}(18|19|([23]\d))\d{2}((0[1-9])|(10|11|12))(([0-2][1-9])|10|20|30|31)\d{3}[0-9Xx]$)|(^[1-9]\d{5}\d{2}((0[1-9])|(10|11|12))(([0-2][1-9])|10|20|30|31)\d{2}$)/, message: '身份证格式错误' }],
  isEnable: [{ required: true, message: "是否启用不能为空", trigger: "blur" }]
});

const show = (cb: any) => {
  reactiveData.form.headUrl = "";

  getEnumGenderList();
  callback = cb;
  dialogVisible.value = true;
}

//获取性别枚举列表
const getEnumGenderList = () => {
  let params = { enumTypeName: "EnumGender" };
  getenums(params).then((resp: any) => {
    if (resp.code == 200 && resp.success) {
      reactiveData.enumGenderList = resp.data;
    }
  })
}

const close = () => {
  if (dialogVisible.value == false) return;

  // console.log("dialog close" + new Date().getTime())
  formRef.value?.resetFields();
  dialogVisible.value = false;
}

const submit = (formRef: FormInstance | undefined) => {
  if (!formRef) return;
  // console.log("form", reactiveData.form)
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