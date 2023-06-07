<template>
  <el-dialog title="用户授权" v-model="dialogVisible" :close-on-click-modal="false" append-to-body @close="close()">
    <el-tree ref="treeRef" :data="reactiveData.roles" :props="{ 'label': 'name' }" node-key="id"
      :default-checked-keys="reactiveData.checkedIds" show-checkbox></el-tree>

    <template #footer>
      <el-button @click="close">关 闭</el-button>
      <el-button type="primary" @click="submit">提 交</el-button>
    </template>
  </el-dialog>
</template>

<script setup lang="ts">
import { ref, reactive } from "vue";
import { ElMessage, ElTree } from "element-plus";
import { listRole } from "@/api/system/role"
import { getUserRoles, save } from "@/api/system/roleuser"

const dialogVisible = ref(false)
const treeRef = ref<InstanceType<typeof ElTree>>()
let callback: Function;

let userInfoId: string = "";

const reactiveData = reactive({
  //所有角色列表
  roles: [] as any[],
  //选中的id
  checkedIds: [] as string[]
})

const show = (userId: string) => {
  userInfoId = userId;

  reactiveData.roles = [];
  reactiveData.checkedIds = [];

  listRole().then((resp: any) => {
    if (resp.code == 200 && resp.success) {
      reactiveData.roles = resp.data;
    }
  })

  let params = { userId: userId }
  getUserRoles(params).then((resp: any) => {
    if (resp.code == 200 && resp.success) {
      reactiveData.checkedIds = resp.data;
    }
  })

  dialogVisible.value = true;
}

const close = () => {
  if (dialogVisible.value == false) return;

  dialogVisible.value = false;
}

const submit = () => {
  let roleIds = treeRef.value?.getCheckedKeys(true);
  if (roleIds && roleIds.length > 0) {
    let data = { userInfoId: userInfoId, roleIds: roleIds };
    save(data).then((resp: any) => {
      if (resp.code == 200 && resp.success) {
        ElMessage({
          type: "success",
          message: "保存成功！"
        });

        close();
      }
    })

  } else {
    ElMessage({
      type: "error",
      message: "请选择角色！"
    });
  }
}

defineExpose({
  show
})
</script>

<style lang="scss" scoped></style>