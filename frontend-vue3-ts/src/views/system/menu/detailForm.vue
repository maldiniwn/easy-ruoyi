<template>
  <el-dialog title="用户详情" v-model="dialogVisible" :close-on-click-modal="false" append-to-body @close="close()">
    <el-descriptions :column="2" border>
      <el-descriptions-item>
        <template #label>
          菜单名称
        </template>
        {{ reactiveData.form.name }}
      </el-descriptions-item>

      <el-descriptions-item>
        <template #label>
          上级菜单
        </template>
        {{ reactiveData.form.pName }}
      </el-descriptions-item>

      <el-descriptions-item>
        <template #label>
          菜单全路径
        </template>
        {{ reactiveData.form.fullPath }}
      </el-descriptions-item>

      <el-descriptions-item>
        <template #label>
          菜单类型
        </template>
        {{ reactiveData.form.enumMenuTypeStr }}
      </el-descriptions-item>

      <el-descriptions-item>
        <template #label>
          菜单图标
        </template>
        <svg-icon :icon-class="reactiveData.form.menuIcon" />
      </el-descriptions-item>

      <el-descriptions-item>
        <template #label>
          权限标识
        </template>
        {{ reactiveData.form.permissionCode }}
      </el-descriptions-item>

      <el-descriptions-item>
        <template #label>
          路由名称
        </template>
        {{ reactiveData.form.routerName }}
      </el-descriptions-item>

      <el-descriptions-item>
        <template #label>
          路由地址
        </template>
        {{ reactiveData.form.path }}
      </el-descriptions-item>

      <el-descriptions-item>
        <template #label>
          组件路径
        </template>
        {{ reactiveData.form.component }}
      </el-descriptions-item>

      <el-descriptions-item>
        <template #label>
          菜单排序
        </template>
        {{ reactiveData.form.sort }}
      </el-descriptions-item>

      <el-descriptions-item>
        <template #label>
          是否缓存
        </template>
        {{ reactiveData.form.isCacheStr }}
      </el-descriptions-item>

      <el-descriptions-item>
        <template #label>
          菜单显示
        </template>
        {{ reactiveData.form.isShowStr }}
      </el-descriptions-item>

      <el-descriptions-item>
        <template #label>
          菜单状态
        </template>
        <el-tag type="success" v-if="reactiveData.form.isEnable">{{ reactiveData.form.isEnableStr }}</el-tag>
        <el-tag type="danger" v-if="!reactiveData.form.isEnable">{{ reactiveData.form.isEnableStr }}</el-tag>

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
import { detailMenu } from "@/api/system/menu"

const dialogVisible = ref(false)

const reactiveData = reactive({
  form: {
    id: "",
    name: "",
    pId: "",
    pName: "",
    fullPath: "",
    enumMenuType: 0,
    enumMenuTypeStr: "",
    permissionCode: "",
    menuIcon: "",
    routerName: "",
    path: "",
    component: "",
    sort: 1,
    isCache: false,
    isCacheStr: "",
    isShow: true,
    isShowStr: "",
    isEnable: true,
    isEnableStr: "",
    createdUserName: "",
    createdTime: "",
    updatedUserName: "",
    updatedTime: ""
  }
})

const show = (id: string) => {
  // console.log("id", id);
  let params = { id };
  detailMenu(params).then((resp: any) => {
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