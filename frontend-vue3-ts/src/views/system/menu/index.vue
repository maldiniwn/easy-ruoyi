<template>
  <div class="app-container">
    <!-- 查询 -->
    <el-form :model="reactiveData.queryParams" ref="queryFormRef" v-show="showSearch" :inline="true" label-width="70px">
      <el-form-item label="菜单名称">
        <el-input v-model="reactiveData.queryParams.name" placeholder="请输入菜单名称" clearable style="width: 240px" />
      </el-form-item>
      <el-form-item label="菜单状态">
        <el-select v-model="reactiveData.queryParams.isEnable" placeholder="请选择状态" clearable style="width: 240px">
          <el-option label="启用" :value="true" />
          <el-option label="禁用" :value="false" />
        </el-select>
      </el-form-item>
      <form-search @reset="resetSearch()" @search="handleSearch()" />
    </el-form>

    <!-- 功能按钮 -->
    <el-row :gutter="10" class="mb8">
      <el-col :span="1.5">
        <el-button type="primary" plain icon="plus" size="small" @click="handleAdd"
          v-hasPermi="['system:menu:add']">新增</el-button>
      </el-col>
      <!-- <el-col :span="1.5">
        <el-button type="success" plain icon="edit" size="small" :disabled="single" @click="handleUpdate"
          v-hasPermi="['system:menu:edit']">修改</el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" plain icon="delete" size="small" :loading="exportLoading" :disabled="multiple"
          @click="handleBatchDelete" v-hasPermi="['system:menu:remove']">删除</el-button>
      </el-col> -->
      <el-col :span="1.5">
        <el-button type="warning" plain icon="download" size="small" @click="handleExport"
          v-hasPermi="['system:menu:export']">导出</el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @refresh="handleRefresh" />
    </el-row>

    <!-- 数据列表 -->
    <el-table stripe border ref="pageTableRef" v-loading="loading" :data="reactiveData.data.rows" row-key="id"
      @selection-change="handleSelectionChange">
      <!-- <el-table-column type="selection" width="55" align="center" :selectable="handleTableSelectable" /> -->

      <el-table-column label="菜单名称" prop="name" min-width="150" show-overflow-tooltip />

      <el-table-column label="菜单图标" prop="menuIcon" align="center" min-width="100">
        <template #default="scope">
          <svg-icon :icon-class="scope.row.menuIcon" />
        </template>
      </el-table-column>

      <el-table-column label="权限标识" prop="permissionCode" min-width="160" show-overflow-tooltip />

      <el-table-column label="路由地址" prop="path" min-width="150" show-overflow-tooltip />

      <el-table-column label="菜单状态" align="center" min-width="80" show-overflow-tooltip>
        <template #default="scope">
          <el-tag type="success" v-if="scope.row.isEnable">{{ scope.row.isEnableStr }}</el-tag>
          <el-tag type="danger" v-if="!scope.row.isEnable">{{ scope.row.isEnableStr }}</el-tag>
        </template>
      </el-table-column>

      <el-table-column label="创建人" prop="createdUserName" min-width="150" show-overflow-tooltip />

      <el-table-column label="创建时间" prop="createdTime" min-width="150" show-overflow-tooltip />

      <el-table-column label="修改人" prop="updatedUserName" min-width="150" show-overflow-tooltip />

      <el-table-column label="修改时间" prop="updatedTime" min-width="150" show-overflow-tooltip />

      <el-table-column label="操作" align="center" min-width="230" class-name="small-padding fixed-width">
        <template #default="scope">
          <el-link class="el-link-spacing" :underline="false" size="small" type="primary" icon="document"
            @click="handleDetail(scope.row)"><span class="table_link_text">详情</span></el-link>
          <el-link class="el-link-spacing" :underline="false" size="small" type="primary" icon="edit"
            @click="handleUpdate(scope.row)" v-hasPermi="['system:menu:edit']"><span
              class="table_link_text">修改</span></el-link>
          <el-link class="el-link-spacing" :underline="false" size="small" type="danger" icon="delete"
            @click="handleDelete(scope.row)" v-hasPermi="['system:menu:remove']"><span
              class="table_link_text">删除</span></el-link>
        </template>
      </el-table-column>
    </el-table>

    <el-pagination small background class="pagination-container" :current-page="reactiveData.data.pageIndex"
      :total="reactiveData.data.totalRows" :page-sizes="[10, 20, 30, 50]" :page-size="reactiveData.data.pageSize"
      layout="total, sizes, prev, pager, next" @size-change="handleSizeChange" @current-change="handlePageChange">
    </el-pagination>
  </div>

  <detailForm ref="detailFormRef"></detailForm>
  <addForm ref="addFormRef"></addForm>
  <editForm ref="editFormRef"></editForm>
</template>

<script setup lang="ts">
import { ref, reactive, getCurrentInstance } from "vue";
import { ElMessage, ElMessageBox, ElLoading } from "element-plus";
import formSearch from "@/components/formSearch/index.vue"
import rightToolbar from "@/components/rightToolbar/index.vue"
import { pageMenu, addMenu, editMenu, delMenu, batchdelMenu, exportMenu } from "@/api/system/menu"
import detailForm from "./detailForm.vue"
import addForm from "./addForm.vue"
import editForm from "./editForm.vue"

const { proxy }: any = getCurrentInstance()

// 遮罩层
const loading = ref<boolean>(false);
// 导出遮罩层
const exportLoading = ref<boolean>(false);
// 非单个禁用
const single = ref<boolean>(true);
// 非多个禁用
const multiple = ref<boolean>(true);
//是否显示查询项
const showSearch = ref<boolean>(true);

const pageTableRef = ref();
const detailFormRef = ref();
const addFormRef = ref();
const editFormRef = ref();

//reactiveData
const reactiveData = reactive({
  // 查询参数
  queryParams: {
    pageIndex: 1,
    pageSize: 10,
    name: "",
    isEnable: undefined,
  },
  //查询返回数据
  data: {
    pageIndex: 1,
    pageSize: 10,
    totalPage: 0,
    totalRows: 0,
    rows: [] as any
  },
})

//判断el-table-cloumn 的复选框是否可以被选中
const handleTableSelectable = (row: any, index: number) => {
  if (row.id == proxy.$superAdmin) {
    return false;
  } else {
    return true;
  }
}

//重置查询
const resetSearch = () => {
  reactiveData.queryParams.pageIndex = 1;
  reactiveData.queryParams.pageSize = 10;
  reactiveData.queryParams.name = "";
  reactiveData.queryParams.isEnable = undefined;
}

//查询
const handleSearch = () => {
  reactiveData.queryParams.pageIndex = 1;
  handleRefresh();
}

//刷新
const handleRefresh = () => {
  loading.value = true;
  pageMenu(reactiveData.queryParams).then((resp: any) => {
    // console.log("resp", resp);
    if (resp.code == 200 && resp.success) {
      reactiveData.data = resp.data;
    }
  }).catch((err) => {
    console.log(err);
  }).finally(() => {
    loading.value = false;
  })
}

//改变页大小
const handleSizeChange = (val: number) => {
  reactiveData.queryParams.pageSize = val;
  handleRefresh();
}

//翻页
const handlePageChange = (val: number) => {
  reactiveData.queryParams.pageIndex = val;
  handleRefresh();
}

//详情
const handleDetail = (row: any) => {
  // console.log("handleDetail row", row);
  detailFormRef.value.show(row.id);
}

//新增
const handleAdd = () => {
  addFormRef.value.show((data: any) => {
    // console.log("add callback", data);
    const processloading = ElLoading.service({
      lock: true,
      text: 'Loading',
      // background: 'rgba(0, 0, 0, 0.7)',
    })
    addMenu(data).then((resp: any) => {
      if (resp.code == 200 && resp.success) {
        ElMessage({
          type: "success",
          message: "新增成功！"
        });
        addFormRef.value.close();
        handleSearch();
      }
    }).catch((err) => {
      console.log(err);
    }).finally(() => {
      processloading.close();
    })
  })
}

//修改
const handleUpdate = (row: any) => {
  // console.log("handleUpdate row", row);
  let id: string = "";
  if (row.id) {
    id = row.id;
  }

  if (!id || id.length == 0) return;

  editFormRef.value.show(id, (data: any) => {
    // console.log("add callback", data);
    const processloading = ElLoading.service({
      lock: true,
      text: 'Loading',
      // background: 'rgba(0, 0, 0, 0.7)',
    })
    editMenu(data).then((resp: any) => {
      if (resp.code == 200 && resp.success) {
        ElMessage({
          type: "success",
          message: "修改成功！"
        });
        editFormRef.value.close();
        handleSearch();
      }
    }).catch((err) => {
      console.log(err);
    }).finally(() => {
      processloading.close();
    })
  })
}

//删除
const handleDelete = (row: any) => {
  // console.log("handleDelete row", row);
  ElMessageBox.confirm("确定删除吗？",
    "Warning",
    {
      confirmButtonText: "确定",
      cancelButtonText: "取消",
      type: 'warning',
    }).then(() => {
      let data = { id: row.id };
      delMenu(data).then((resp: any) => {
        if (resp.code == 200 && resp.success) {
          ElMessage({
            type: "success",
            message: "删除成功！"
          });
          handleSearch();
        }
      })
    })
}

//批量删除
const handleBatchDelete = () => {
  // console.log(pageTableRef.value.getSelectionRows());
  var ids: string[] = [];
  pageTableRef.value.getSelectionRows().forEach((ele: any) => {
    ids.push(ele.id);
  });

  if (ids.length == 0) {
    ElMessage({
      type: "warning",
      message: "请选择要删除的角色"
    })
  } else {
    ElMessageBox.confirm("确定删除选中的角色吗？",
      "Warning",
      {
        confirmButtonText: "确定",
        cancelButtonText: "取消",
        type: 'warning',
      }).then(() => {
        let data = { ids };
        batchdelMenu(data).then((resp: any) => {
          if (resp.code == 200 && resp.success) {
            ElMessage({
              type: "success",
              message: "删除成功！"
            });
            handleSearch();
          }
        })
      })
  }
}

//导出
const handleExport = () => {
  exportMenu(reactiveData.queryParams);
}

//table 选择项发生变化时
const handleSelectionChange = (selection: any) => {
  single.value = !(selection.length == 1);
  multiple.value = !(selection.length > 0);

  // console.log("selection", selection);
  // console.log("single", single.value);
  // console.log("multiple", multiple.value);
}

handleSearch();
</script>

<style lang="scss" scoped></style>