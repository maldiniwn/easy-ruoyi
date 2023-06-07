<template>
  <el-row :gutter="10" class="usercenter">
    <el-col :span="6">
      <el-card>
        <template #header>
          个人信息
        </template>
        <el-row class="userinfo-avatar">
          <el-col :span="24">
            <div class="userinfo-head" @click="handleUserAvatar">
              <!-- <img src="@/assets/images/profile.jpg" title="点击上传头像" style="width: 120px; height: 120px"
                class="img-circle" /> -->
              <el-image :src="headUrl" style="width: 120px; height: 120px" class="img-circle">
                <template #error>
                  <div class="image-error-slot">
                    <el-icon>
                      <Picture />
                    </el-icon>
                  </div>
                  <!-- <el-icon><icon-picture /></el-icon> -->
                </template>
              </el-image>
            </div>
          </el-col>
        </el-row>
        <el-row class="userinfo-row">
          <el-col :span="8"><svg-icon icon-class="user" style="margin-right: 5px" />用户名称</el-col>
          <el-col :span="16" class="userinfo-row-text">{{ reactiveData.userInfo.userName }}</el-col>
        </el-row>
        <el-row class="userinfo-row">
          <el-col :span="8"><svg-icon icon-class="people" style="margin-right: 5px" />用户姓名</el-col>
          <el-col :span="16" class="userinfo-row-text">{{ reactiveData.userInfo.name }}</el-col>
        </el-row>
        <el-row class="userinfo-row">
          <el-col :span="8"><svg-icon icon-class="theme" style="margin-right: 5px" />用户性别</el-col>
          <el-col :span="16" class="userinfo-row-text">{{ reactiveData.userInfo.enumGenderStr }}</el-col>
        </el-row>
        <el-row class="userinfo-row">
          <el-col :span="8"><svg-icon icon-class="phone" style="margin-right: 5px" />手机号码</el-col>
          <el-col :span="16" class="userinfo-row-text">{{ reactiveData.userInfo.tel }}</el-col>
        </el-row>
        <el-row class="userinfo-row">
          <el-col :span="8"><svg-icon icon-class="date" style="margin-right: 5px" />出生日期</el-col>
          <el-col :span="16" class="userinfo-row-text">{{ reactiveData.userInfo.bornDateStr }}</el-col>
        </el-row>
        <el-row class="userinfo-row">
          <el-col :span="8"><svg-icon icon-class="time" style="margin-right: 5px" />创建时间</el-col>
          <el-col :span="16" class="userinfo-row-text">{{ reactiveData.userInfo.createdTimeStr }}</el-col>
        </el-row>
      </el-card>
    </el-col>
    <el-col :span="18">
      <el-card>
        <template #header>
          基本资料
        </template>
        <el-tabs v-model="activeName" class="demo-tabs">
          <el-tab-pane label="基本资料" name="BaseEmp">
            <el-form ref="empFormRef" :model="reactiveData.employeeForm" :rules="empRules" label-width="100px">
              <el-form-item label="用户姓名" prop="name">
                <el-input v-model="reactiveData.employeeForm.name" placeholder="请输入用户姓名" maxlength="50"
                  show-word-limit></el-input>
              </el-form-item>
              <el-form-item label="用户性别" prop="enumGender">
                <el-radio-group v-model="reactiveData.employeeForm.enumGender">
                  <el-radio v-for="(item, index) in reactiveData.enumGenderList" :index="index" :label="item.value">
                    {{ item.label }}</el-radio>
                </el-radio-group>
              </el-form-item>
              <el-form-item label="手机号码" prop="tel">
                <el-input v-model="reactiveData.employeeForm.tel" placeholder="请输入手机号码" maxlength="11"
                  show-word-limit></el-input>
              </el-form-item>
              <el-form-item label="身份证号" prop="sid">
                <el-input v-model="reactiveData.employeeForm.sid" placeholder="请输入身份证号" maxlength="18"
                  show-word-limit></el-input>
              </el-form-item>
              <el-form-item label="出生日期" prop="bornDate">
                <el-date-picker v-model="reactiveData.employeeForm.bornDate" type="date" placeholder="请选择出生日期"
                  style="width:100%;" />
              </el-form-item>
              <el-form-item>
                <el-button type="primary" @click="submitEmp(empFormRef)">保 存</el-button>
                <el-button @click="resetEmp">重 置</el-button>
              </el-form-item>
            </el-form>
          </el-tab-pane>
          <el-tab-pane label="修改密码" name="EditPwd">
            <el-form ref="editPwdFormRef" :model="reactiveData.editPwdForm" :rules="editPwdRules" label-width="100px">
              <el-form-item label="旧密码" prop="oldPwd">
                <el-input v-model="reactiveData.editPwdForm.oldPwd" type="password" placeholder="请输入旧密码" maxlength="20"
                  show-word-limit show-password></el-input>
              </el-form-item>
              <el-form-item label="新密码" prop="newPwd1">
                <el-input v-model="reactiveData.editPwdForm.newPwd1" type="password" placeholder="请输入新密码" maxlength="20"
                  show-word-limit show-password></el-input>
              </el-form-item>
              <el-form-item label="确认密码" prop="newPwd2">
                <el-input v-model="reactiveData.editPwdForm.newPwd2" type="password" placeholder="请输入确认密码" maxlength="20"
                  show-word-limit show-password></el-input>
              </el-form-item>
              <el-form-item>
                <el-button type="primary" @click="submitPwd(editPwdFormRef)">修改密码</el-button>
                <el-button @click="clearPwd">清 空</el-button>
              </el-form-item>
            </el-form>
          </el-tab-pane>
        </el-tabs>
      </el-card>
    </el-col>
  </el-row>

  <userAvatar ref="userAvatarRef"></userAvatar>
</template>

<script setup lang="ts">
import { ref, reactive, getCurrentInstance } from "vue";
import { FormInstance, FormRules, ElMessage } from "element-plus";
import userAvatar from "./userAvatar.vue"
import { userStore } from "@/store/userStore"
import { detailUser } from "@/api/system/user"
import { getenums } from "@/api/system/common"
import { editEmp, updatePwd, getHeadUrl } from "@/api/system/usercenter"

const { proxy }: any = getCurrentInstance()

const userAvatarRef = ref()
/** 头像url */
const headUrl = ref("")

const empFormRef = ref<FormInstance>()
const editPwdFormRef = ref<FormInstance>()
const activeName = ref("BaseEmp")

const reactiveData = reactive({
  userInfo: {
    id: "",
    userName: "",
    employeeId: "",
    name: "",
    enumGender: "",
    enumGenderStr: "",
    isEnabel: true,
    tel: "",
    sid: "",
    bornDate: "",
    bornDateStr: "",
    createdTimeStr: ""
  },
  employeeForm: {
    id: "",
    name: "",
    enumGender: "",
    tel: "",
    sid: "",
    bornDate: "",
  },
  editPwdForm: {
    id: "",
    oldPwd: "",
    newPwd1: "",
    newPwd2: "",
  },
  //性别列表数据源
  enumGenderList: [] as any[]
})

let checkNewPwd2 = ((rule: any, value: string, callback: Function) => {
  if (value.trim().length == 0) {
    callback(new Error("确认密码不能为空"));
  } else if (value != reactiveData.editPwdForm.newPwd1) {
    callback(new Error("两次新密码不一致"));
  } else {
    callback();
  }
})

// 表单校验
const empRules = reactive<FormRules>({
  name: [{ required: true, message: "姓名不能为空", trigger: "blur" }],
  tel: [{ pattern: /^1\d{10}$/, message: '手机号格式错误' }],
  sid: [{ pattern: /(^[1-9]\d{5}(18|19|([23]\d))\d{2}((0[1-9])|(10|11|12))(([0-2][1-9])|10|20|30|31)\d{3}[0-9Xx]$)|(^[1-9]\d{5}\d{2}((0[1-9])|(10|11|12))(([0-2][1-9])|10|20|30|31)\d{2}$)/, message: '身份证格式错误' }],
});
const editPwdRules = reactive<FormRules>({
  oldPwd: [{ required: true, message: "旧密码不能为空", trigger: "blur" }],
  newPwd1: [{ required: true, message: "新密码不能为空", trigger: "blur" }],
  newPwd2: [{ required: true, validator: checkNewPwd2, trigger: "blur" }],
});



/** 查询用户信息 */
const getUser = () => {
  let params = { id: userStore().id };
  detailUser(params).then((resp: any) => {
    if (resp.code == 200 && resp.success) {
      reactiveData.userInfo = resp.data;
      reactiveData.employeeForm = { ...resp.data };
      reactiveData.employeeForm.id = resp.data.employeeId;
      reactiveData.editPwdForm.id = resp.data.id;
    }
  })
}

/** 获取性别枚举列表 */
const getEnumGenderList = () => {
  // let ss = userStore().getToken().split(".")[1];
  // console.log("token", JSON.parse(atob(ss)));

  let params = { enumTypeName: "EnumGender" };
  getenums(params).then((resp: any) => {
    if (resp.code == 200 && resp.success) {
      reactiveData.enumGenderList = resp.data;
    }
  })
}

/** 查询头像url */
const getUserHeadUrl = () => {
  getHeadUrl().then((resp: any) => {
    headUrl.value = resp.data;
    return Promise.resolve();
  }).then(() => {
    //事件总线：触发updateHeadUrl事件（页面右上角用户图片更新 @/components/layout/rightmenu/index.vue）
    proxy.$bus.emit("updateHeadUrl", headUrl.value);
    // console.log("$bus.emit.updateHeadUrl", headUrl.value);
  })
}

/** 显示上传头像dialog */
const handleUserAvatar = () => {
  userAvatarRef.value.show(headUrl.value, () => {
    getUserHeadUrl();
    userAvatarRef.value.close();
  })
}

/** 保存基本资料 */
const submitEmp = (formRef: FormInstance | undefined) => {
  if (!formRef) return;

  formRef.validate((valid, fields) => {
    if (valid) {
      editEmp(reactiveData.employeeForm).then((resp: any) => {
        if (resp.code == 200 && resp.success) {
          getUser();

          ElMessage({
            type: "success",
            message: "保存成功！"
          });
        }
      })
    } else {
      console.log('error submit!', fields)
    }
  })
}

/** 重置基本资料 */
const resetEmp = () => {
  reactiveData.employeeForm.id = reactiveData.userInfo.employeeId;
  reactiveData.employeeForm.name = reactiveData.userInfo.name;
  reactiveData.employeeForm.enumGender = reactiveData.userInfo.enumGender;
  reactiveData.employeeForm.tel = reactiveData.userInfo.tel;
  reactiveData.employeeForm.sid = reactiveData.userInfo.sid;
  reactiveData.employeeForm.bornDate = reactiveData.userInfo.bornDate;
}

/** 修改密码 */
const submitPwd = (formRef: FormInstance | undefined) => {
  if (!formRef) return;

  formRef.validate((valid, fields) => {
    if (valid) {
      updatePwd(reactiveData.editPwdForm).then((resp: any) => {
        if (resp.code == 200 && resp.success) {
          clearPwd();

          ElMessage({
            type: "success",
            message: "修改密码成功！"
          });
        }
      })
    } else {
      console.log('error submit!', fields)
    }
  })
}

/** 清空密码 */
const clearPwd = () => {
  reactiveData.editPwdForm.oldPwd = "";
  reactiveData.editPwdForm.newPwd1 = "";
  reactiveData.editPwdForm.newPwd2 = "";

  editPwdFormRef.value?.resetFields();
}

getUser();
getEnumGenderList();
getUserHeadUrl();
</script>

<style lang="scss" scoped>
.usercenter {
  margin-top: 10px;

  .userinfo-avatar {
    text-align: center;
    border-bottom: 1px solid #E7EAEC;

    .userinfo-head {
      position: relative;
      display: inline-block;
      height: 120px;

      .image-error-slot {
        display: flex;
        justify-content: center;
        align-items: center;
        width: 100%;
        height: 100%;

        .el-icon {
          font-size: 30px;
        }
      }
    }

    .userinfo-head:hover:after {
      content: "+";
      position: absolute;
      left: 0;
      right: 0;
      top: 0;
      bottom: 0;
      color: #eee;
      background: rgba(0, 0, 0, 0.5);
      font-size: 24px;
      font-style: normal;
      -webkit-font-smoothing: antialiased;
      -moz-osx-font-smoothing: grayscale;
      cursor: pointer;
      line-height: 110px;
      border-radius: 50%;
    }
  }

  .userinfo-row {
    font-size: 13px;
    height: 36px;
    line-height: 36px;
    border-bottom: 1px solid #E7EAEC;

    .userinfo-row-text {
      text-align: right;
    }
  }
}
</style>