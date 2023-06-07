<template>
  <el-dialog title="新增菜单" v-model="dialogVisible" :close-on-click-modal="false" append-to-body @close="close()">
    <el-form ref="formRef" :model="reactiveData.form" :rules="rules" label-width="100px">
      <el-row>
        <el-col :span="24">
          <el-form-item label="上级菜单" prop="pId">
            <el-cascader v-model="reactiveData.form.pId" :options="reactiveData.menuOptions"
              :props="{ checkStrictly: true, emitPath: false, value: 'id', label: 'name' }" style="width:100%;"
              clearable />
          </el-form-item>
        </el-col>
        <el-col :span="24">
          <el-form-item label="菜单类型" prop="enumMenuType">
            <!-- 0:Directory目录  1:Menu菜单  2:Operation操作 -->
            <el-radio-group v-model="reactiveData.form.enumMenuType">
              <el-radio v-for="(item, index) in reactiveData.enumMenuTypeList" :index="index" :label="item.value">
                {{ item.label }}</el-radio>
            </el-radio-group>
          </el-form-item>
        </el-col>
        <el-col :span="12">
          <el-form-item label="菜单名称" prop="name">
            <el-input v-model="reactiveData.form.name" placeholder="请输入菜单名称" maxlength="50" show-word-limit></el-input>
          </el-form-item>
        </el-col>
        <el-col :span="12">
          <el-form-item label="显示排序" prop="sort">
            <el-input-number v-model="reactiveData.form.sort" placeholder="请输入手机号" :min="0" :max="99999" />
          </el-form-item>
        </el-col>
        <el-col :span="24" v-if="reactiveData.form.enumMenuType != 2">
          <el-form-item label="菜单图标" prop="menuIcon">
            <el-popover placement="bottom-start" :width="560" trigger="click">
              <template #reference>
                <el-input size="small" v-model="reactiveData.form.menuIcon" placeholder="点击选择图标" @click="showSelectIcon"
                  readonly>
                  <template #prefix>
                    <svg-icon v-if="reactiveData.form.menuIcon" :icon-class="reactiveData.form.menuIcon"
                      class="el-input__icon" style="height: 18px;width: 18px;" />
                    <el-icon v-else style="height: 18px;width: 18px;">
                      <search />
                    </el-icon>
                  </template>
                </el-input>
              </template>
              <!-- @visible="showSelectIcon" v-click-outside="hideSelectIcon" -->
              <icon-select ref="iconSelectRef" @selected="handleSelectedIcon" />
            </el-popover>
          </el-form-item>
        </el-col>
        <el-col :span="12" v-if="reactiveData.form.enumMenuType != 2">
          <el-form-item label="路由名称" prop="routerName">
            <el-input v-model="reactiveData.form.routerName" placeholder="请输入路由名称" maxlength="50"
              show-word-limit></el-input>
          </el-form-item>
        </el-col>
        <el-col :span="12" v-if="reactiveData.form.enumMenuType != 2">
          <el-form-item label="路由地址" prop="path">
            <el-input v-model="reactiveData.form.path" placeholder="请输入路由地址" maxlength="128" show-word-limit></el-input>
          </el-form-item>
        </el-col>
        <el-col :span="12" v-if="reactiveData.form.enumMenuType == 1">
          <el-form-item label="组件路径" prop="component">
            <el-input v-model="reactiveData.form.component" placeholder="请输入组件路径" maxlength="128"
              show-word-limit></el-input>
          </el-form-item>
        </el-col>
        <el-col :span="12" v-if="reactiveData.form.enumMenuType != 0">
          <el-form-item label="权限标识" prop="permissionCode">
            <el-input v-model="reactiveData.form.permissionCode" placeholder="请输入权限标识" maxlength="128"
              show-word-limit></el-input>
          </el-form-item>
        </el-col>
        <el-col :span="12" v-if="reactiveData.form.enumMenuType == 1">
          <el-form-item label="是否缓存" prop="isCache">
            <el-switch v-model="reactiveData.form.isCache" active-text="是" inactive-text="否" />
          </el-form-item>
        </el-col>
        <el-col :span="12" v-if="reactiveData.form.enumMenuType != 2">
          <el-form-item label="是否显示" prop="isShow">
            <el-switch v-model="reactiveData.form.isShow" active-text="是" inactive-text="否" />
          </el-form-item>
        </el-col>
        <el-col :span="12">
          <el-form-item label="菜单状态" prop="isEnable">
            <el-switch v-model="reactiveData.form.isEnable" active-text="启用" inactive-text="禁用" />
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
import { FormInstance, FormRules, ClickOutside as vClickOutside } from "element-plus";
import { menuTree } from "@/api/system/menu"
import { getenums } from "@/api/system/common"
import svgIcon from "@/components/svgIcon/index.vue";
import iconSelect from "@/components/iconSelect/index.vue";

const dialogVisible = ref(false)
const formRef = ref<FormInstance>()
let callback: Function;
const showChooseIcon = ref<boolean>(false);

const iconSelectRef = ref<any>();

const reactiveData = reactive({
  form: {
    name: "",
    pId: "",
    enumMenuType: 0,
    permissionCode: "",
    menuIcon: "",
    routerName: "",
    path: "",
    component: "",
    sort: 1,
    isCache: false,
    isShow: true,
    isEnable: true,
  },
  //菜单类型数据源
  enumMenuTypeList: [] as any[],
  //菜单数据源
  menuOptions: [] as any[],
})

// 表单校验
const rules = reactive<FormRules>({
  name: [{ required: true, message: "菜单名称不能为空", trigger: "blur" }],
  routerName: [{ required: true, message: "路由名称不能为空", trigger: "blur" }],
  path: [{ required: true, message: '路由地址不能为空' }],
});

/** 显示 */
const show = (cb: any) => {
  getEnumMenuTypeList();
  getMenuOptions();
  callback = cb;
  dialogVisible.value = true;
}

/** 获取菜单类型枚举列表 */
const getEnumMenuTypeList = () => {
  let params = { enumTypeName: "EnumMenuType" };
  getenums(params).then((resp: any) => {
    if (resp.code == 200 && resp.success) {
      reactiveData.enumMenuTypeList = resp.data;
    }
  })
}

/** 获取菜单数据源 */
const getMenuOptions = () => {
  menuTree().then((resp: any) => {
    if (resp.code == 200 && resp.success) {
      reactiveData.menuOptions = resp.data;
    }
  })
}

/** 展示下拉图标 */
const showSelectIcon = () => {
  iconSelectRef.value?.reset();
  showChooseIcon.value = true;
  // console.log("showSelectIcon")
};

/** 选择图标 */
const handleSelectedIcon = (name: string) => {
  reactiveData.form.menuIcon = name;
  showChooseIcon.value = false;
  // console.log("handleSelectedIcon")
};

/** 图标外层点击隐藏下拉列表 */
const hideSelectIcon = () => {
  showChooseIcon.value = false;
  // console.log("hideSelectIcon")
};

/** 关闭 */
const close = () => {
  if (dialogVisible.value == false) return;

  // console.log("dialog close" + new Date().getTime())
  formRef.value?.resetFields();
  dialogVisible.value = false;
}

/** 提交 */
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