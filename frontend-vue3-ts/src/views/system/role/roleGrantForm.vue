<template>
  <el-dialog title="角色授权" v-model="dialogVisible" :close-on-click-modal="false" append-to-body @close="close()">
    <el-tree ref="treeRef" class="tree" :data="reactiveData.menus" :props="{ 'label': 'name' }" node-key="id"
      :default-checked-keys="reactiveData.checkedIds" default-expand-all show-checkbox></el-tree>

    <template #footer>
      <el-button @click="close">关 闭</el-button>
      <el-button type="primary" @click="submit">提 交</el-button>
    </template>
  </el-dialog>
</template>

<script setup lang="ts">
import { ref, reactive } from "vue";
import { ElMessage, ElTree } from "element-plus";
import { menuTree } from "@/api/system/menu"
import { getRoleMenus, save } from "@/api/system/rolemenu"

const dialogVisible = ref(false)
const treeRef = ref<InstanceType<typeof ElTree>>()

let roleId: string = "";

const reactiveData = reactive({
  //所有菜单列表
  menus: [] as any[],
  //选中的id
  checkedIds: [] as string[]
})

const show = (rid: string) => {
  roleId = rid;

  reactiveData.menus = [];
  reactiveData.checkedIds = [];

  //查询所有菜单tree
  menuTree().then((resp: any) => {
    if (resp.code == 200 && resp.success) {
      reactiveData.menus = resp.data;
    }
  })

  //查询角色菜单Ids
  let params = { roleId: roleId };
  getRoleMenus(params).then((resp: any) => {
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
  let nodes = treeRef.value?.getCheckedNodes(false, true);
  let menuIds: string[] = [];

  if (nodes && nodes.length > 0) {
    for (let i = 0; i < nodes?.length; i++) {
      // console.log(nodes[i].id)
      menuIds.push(nodes[i].id);
    }
    // console.log("menuIds", menuIds)
    let data = { roleId: roleId, menuIds: menuIds };
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
      message: "请选择菜单！"
    });
  }
}

defineExpose({
  show
})
</script>

<style lang="scss" scoped>
.tree {
  // height: calc(100% - 50px);
  max-height: 700px;
  overflow-y: auto;
}
</style>