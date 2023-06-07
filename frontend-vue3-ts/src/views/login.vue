<template>
  <div class="login">
    <h2>Login</h2>
    <el-form :model="form" label-width="120px" label-position="top" class="form" :rules="rules" ref="ruleFormRef">
      <el-form-item label="用户名" prop="userName">
        <el-input v-model="form.userName" />
      </el-form-item>
      <el-form-item label="密码" prop="password">
        <el-input v-model="form.password" type="password" show-password />
      </el-form-item>
      <el-form-item label="验证码" prop="code">
        <el-input v-model="form.code">
          <template #append>
            <img :src="codeUrl" @click="getCode()" class="login-code-img" />
          </template>
        </el-input>
        <!-- <img :src="codeUrl" @click="getCode()" class="login-code-img" /> -->
      </el-form-item>
      <el-form-item>
        <div class="login-btn-item">
          <el-button type="primary" @click="onSubmit(ruleFormRef)">登录
          </el-button>
          &nbsp;&nbsp;
          <router-link :to="'/register'">立即注册</router-link>
        </div>
      </el-form-item>
    </el-form>
  </div>
</template>

<script lang="ts" setup>
import { ref, reactive } from "vue";
import type { FormInstance, FormRules } from "element-plus";
import { ElMessage } from "element-plus";
import { captchaImage } from "@/api/account"
import { userStore } from "@/store/userStore"
import router from "@/router"

//数据
const form = reactive({
  userName: "admin",
  password: "123456",
  code: "",
  captchaToken: ""
});

const codeUrl = ref("");

const ruleFormRef = ref<FormInstance>();

//表单验证规则
const rules = reactive<FormRules>({
  //用户名
  userName: [{ required: true, message: "请输入用户名", trigger: "blur" }],
  //密码
  passWord: [{ required: true, message: "请输入密码", trigger: "blur" }],
  //验证码
  code: [{ required: true, message: "请输入验证码", trigger: "blur" }]
});

//方法
const onSubmit = async (ruleFormRef: FormInstance | undefined) => {
  if (!ruleFormRef) return;
  await ruleFormRef.validate(async (valid, fields) => {
    if (valid) {
      userStore().userLogin(form).then(() => {
        ElMessage({
          type: "success",
          message: "登录成功"
        });
        // router.push("/")
        router.replace("/")
      }).catch((err) => {
        // console.log("err", err)
        ElMessage({
          type: "error",
          message: err
        })
        getCode();
      })

      // console.log("正在登录...");
    } else {
      console.log("验证不通过！", fields);

      let errors: string = "";
      fields?.userName?.forEach((ele) => {
        errors += ele.message + ";";
      });
      fields?.passWord?.forEach((ele) => {
        errors += ele.message + ";";
      });
      fields?.code?.forEach((ele) => {
        errors += ele.message + ";";
      });
      ElMessage({
        type: "warning",
        //message:"校验不通过！"
        message: errors,
      });
    }
  });
};

const getCode = () => {
  captchaImage().then(resp => {
    // console.log("resp", resp)
    codeUrl.value = resp.data.captchaImageBase64;
    form.captchaToken = resp.data.captchaToken;
  })
}

getCode();
</script>

<style lang="scss" scoped>
.login {
  margin: 50px auto;
  width: 400px;

  .login-btn-item {
    width: 100%;
    display: flex;
    justify-content: center;
  }
}
</style>