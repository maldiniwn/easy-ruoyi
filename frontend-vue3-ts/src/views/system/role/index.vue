<template>
  <div class="app-container">
    <!-- 查询 -->
    <el-form :model="reactiveData.queryParams" ref="queryFormRef" v-show="showSearch" :inline="true" label-width="70px">
      <el-form-item label="角色名称" prop="roleName">
        <el-input v-model="reactiveData.queryParams.name" placeholder="请输入角色名称" clearable style="width: 240px" />
      </el-form-item>
      <el-form-item label="角色编号" prop="roleKey">
        <el-input v-model="reactiveData.queryParams.roleCode" placeholder="请输入角色编号" clearable style="width: 240px" />
      </el-form-item>
      <form-search @reset="resetSearch()" @search="handleSearch()" />
    </el-form>

    <!-- 功能按钮 -->
    <el-row :gutter="10" class="mb8">
      <el-col :span="1.5">
        <el-button type="primary" plain icon="plus" size="small" @click="handleAdd"
          v-hasPermi="['system:role:add']">新增</el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" plain icon="edit" size="small" :disabled="single" @click="handleUpdate"
          v-hasPermi="['system:role:edit']">修改</el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" plain icon="delete" size="small" :loading="exportLoading" :disabled="multiple"
          @click="handleBatchDelete" v-hasPermi="['system:role:remove']">删除</el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="info" plain icon="upload" size="small" @click="handleImport"
          v-hasPermi="['system:role:import']">导入</el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="warning" plain icon="download" size="small" @click="handleExport"
          v-hasPermi="['system:role:export']">导出</el-button>
      </el-col>
      <!-- prettier-ignore -->
      <right-toolbar v-model:showSearch="showSearch" @refresh="handleRefresh" />
    </el-row>

    <!-- 数据列表 -->
    <el-table stripe border ref="pageTableRef" v-loading="loading" :data="reactiveData.data.rows"
      @selection-change="handleSelectionChange">
      <el-table-column type="selection" width="55" align="center" :selectable="handleTableSelectable" />

      <el-table-column label="角色名称" prop="name" min-width="150" show-overflow-tooltip />

      <el-table-column label="角色编号" prop="roleCode" min-width="150" show-overflow-tooltip />

      <el-table-column label="是否启用" align="center" min-width="80" show-overflow-tooltip>
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

          <template v-if="scope.row.id != proxy.$superRole">
            <el-link class="el-link-spacing" :underline="false" size="small" type="primary" icon="edit"
              @click="handleUpdate(scope.row)" v-hasPermi="['system:role:edit']"><span
                class="table_link_text">修改</span></el-link>
            <el-link class="el-link-spacing" :underline="false" size="small" type="danger" icon="delete"
              @click="handleDelete(scope.row)" v-hasPermi="['system:role:remove']"><span
                class="table_link_text">删除</span></el-link>
            <el-link class="el-link-spacing" :underline="false" size="small" type="warning" icon="operation"
              @click="handleGrant(scope.row)" v-hasPermi="['system:user:grant']"><span
                class="table_link_text">授权</span></el-link>
            <!-- <el-link v-if="scope.row.roleId !== '1'" class="el-link-spacing" :underline="false" size="small" type="primary"
            icon="circle-check" @click="handleDataScope(scope.row)" v-hasPermi="['system:role:edit']"><span
              class="table_link_text">数据权限</span></el-link> -->
          </template>
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
  <roleGrantForm ref="roleGrantFormRef"></roleGrantForm>

  <!-- 导入 -->
  <el-dialog title="导入角色" v-model="reactiveData.upload.open" width="400px" append-to-body @close="cleanImportRef">
    <el-upload ref="importRef" action="" accept=".xls, .xlsx" :disabled="reactiveData.upload.isUploading"
      :http-request="importData" :auto-upload="false" :limit="1" drag>
      <el-icon class="el-icon--upload"><upload-filled /></el-icon>
      <div class="el-upload__text">
        将文件拖到此处，或
        <em>点击上传</em>
      </div>
      <template #tip>
        <div class="el-upload__tip" style="overflow: hidden; clear:both;">
          <div style="float:left;width:180px;"><el-checkbox
              v-model="reactiveData.upload.updateSupport">是否更新已经存在的用户数据</el-checkbox></div>
          <div style="float:left;margin-left:5px;margin-top:-1px; height: 24px; line-height: 24px;"><el-link type="info"
              style="font-size:12px" @click="downloadTemplate">【下载模板】</el-link></div>
        </div>
        <div class="el-upload__tip" style="color:red">提示：仅允许导入“xls”或“xlsx”格式文件！</div>
      </template>
    </el-upload>
    <template #footer>
      <div class="dialog-footer">
        <el-button type="primary" @click="submitImportForm">确 定</el-button>
        <el-button @click="reactiveData.upload.open = false">取 消</el-button>
      </div>
    </template>
  </el-dialog>
</template>

<script setup lang="ts">
import { ref, reactive, getCurrentInstance } from "vue";
import { ElMessage, ElMessageBox, ElLoading, UploadRequestOptions, ElUpload } from "element-plus";
import formSearch from "@/components/formSearch/index.vue"
import rightToolbar from "@/components/rightToolbar/index.vue"
import { pageRole, addRole, editRole, delRole, batchdelRole, downloadtemplateRole, importRole, exportRole } from "@/api/system/role"
import { downloadImportErrorFile } from "@/api/system/sysfile"
import detailForm from "./detailForm.vue"
import addForm from "./addForm.vue"
import editForm from "./editForm.vue"
import roleGrantForm from "./roleGrantForm.vue"

const { proxy }: any = getCurrentInstance();

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
const importRef = ref<InstanceType<typeof ElUpload>>();
const roleGrantFormRef = ref();

//reactiveData
const reactiveData = reactive({
  // 查询参数
  queryParams: {
    pageIndex: 1,
    pageSize: 10,
    name: "",
    roleCode: "",
  },
  //查询返回数据
  data: {
    pageIndex: 1,
    pageSize: 10,
    totalPage: 0,
    totalRows: 0,
    rows: [] as any
  },
  //上传数据
  upload: {
    // 是否显示弹出层
    open: false,
    // 是否禁用上传
    isUploading: false,
    // 是否更新已经存在的数据
    updateSupport: false
  }
})

//判断el-table-cloumn 的复选框是否可以被选中
const handleTableSelectable = (row: any, index: number) => {
  if (row.id == proxy.$superRole) {
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
  reactiveData.queryParams.roleCode = "";
}

//查询
const handleSearch = () => {
  reactiveData.queryParams.pageIndex = 1;
  handleRefresh();
}

//刷新
const handleRefresh = () => {
  loading.value = true;
  pageRole(reactiveData.queryParams).then((resp: any) => {
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
    addRole(data).then((resp: any) => {
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
  } else if (pageTableRef.value.getSelectionRows().length > 0) {
    id = pageTableRef.value.getSelectionRows()[0].id;
  }

  if (!id || id.length == 0) return;

  editFormRef.value.show(id, (data: any) => {
    // console.log("add callback", data);
    const processloading = ElLoading.service({
      lock: true,
      text: 'Loading',
      // background: 'rgba(0, 0, 0, 0.7)',
    })
    editRole(data).then((resp: any) => {
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
      delRole(data).then((resp: any) => {
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

//授权
const handleGrant = (row: any) => {
  roleGrantFormRef.value?.show(row.id);
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
        batchdelRole(data).then((resp: any) => {
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

//打开导入对话框
const handleImport = () => {
  reactiveData.upload.open = true;
}

//关闭导入对话框
const cleanImportRef = () => {
  importRef.value?.clearFiles();
  reactiveData.upload.isUploading = false;
  reactiveData.upload.updateSupport = false;
}

//下载导入模板
const downloadTemplate = () => {
  downloadtemplateRole();
}

//导入方法
const importData = (options: UploadRequestOptions) => {
  reactiveData.upload.isUploading = true;
  var pro = new Promise((resolve, reject) => {
    importRole(options.file, reactiveData.upload.updateSupport).then((resp: any) => {
      if (resp.success) {
        if (resp.data.code == 200) {
          ElMessage({
            type: "success",
            message: resp.data.message
          });

          reactiveData.upload.open = false;
          handleSearch();
        } else if (resp.data.code == 20001) {
          ElMessage({
            type: "warning",
            message: resp.data.message
          });
          downloadErrorFile(resp.data.data);
        } else {
          console.log("unknow", resp);
        }
      }
    }).finally(() => {
      reactiveData.upload.isUploading = false;
    })
  })

  return pro;
}

//下载导入错误提示文件
const downloadErrorFile = (id: string) => {
  downloadImportErrorFile(id, "角色导入模板_Error.xlsx");
}

//导入对话框确定
const submitImportForm = () => {
  importRef.value?.submit();
}

//导出
const handleExport = () => {
  exportRole(reactiveData.queryParams);
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