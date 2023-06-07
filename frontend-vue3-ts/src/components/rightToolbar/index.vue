<template>
  <div class="top-right-btn">
    <el-row>
      <el-tooltip class="item" effect="dark" :content="showSearch ? '隐藏搜索' : '显示搜索'" placement="top">
        <el-button size="small" circle icon="search" @click="toggleSearch()" />
      </el-tooltip>
      <el-tooltip class="item" effect="dark" content="刷新" placement="top">
        <el-button size="small" circle icon="refresh" @click="refresh()" />
      </el-tooltip>
      <el-tooltip class="item" effect="dark" content="显隐列" placement="top" v-if="columns">
        <el-button size="small" circle icon="menu" @click="showColumn()" />
      </el-tooltip>
    </el-row>
    <el-dialog :title="title" v-model="open" append-to-body>
      <el-transfer :titles="['显示', '隐藏']" v-model="value" :data="columns" @change="dataChange"></el-transfer>
    </el-dialog>
  </div>
</template>

<script setup lang="ts">
import { ref, reactive } from "vue";

interface Option {
  key: string
  label: string
  disabled: boolean
}

const props = defineProps({
  showSearch: {
    type: Boolean,
    default: true,
  },
  columns: {
    type: Array<Option>,
    default: []
  },
})

const emit = defineEmits(["update:showSearch", "refresh"])

// 显隐数据
const value = ref([]);
// 弹出层标题
const title = ref("显示/隐藏");
// 是否显示弹出层
const open = ref(false);

// 显示|隐藏 搜索
const toggleSearch = () => {
  emit("update:showSearch", !props.showSearch);
}

//刷新
const refresh = () => {
  emit("refresh");
}

// 打开显隐列dialog
const showColumn = () => {
  open.value = true;
}

// 右侧穿梭框列表元素变化
const dataChange = (value: any) => {
  console.log("dataChange value", value)
  for (let i = 0; i < props.columns?.length; i++) {
    let key = props.columns[i].key;
    props.columns[i].disabled = !value.includes(key);
  }
  // for (var item in props.columns) {
  //   const key = props.columns[item].key;
  //   props.columns[item].visible = !value.includes(key);
  // }
}
</script>

<style lang="scss" scoped></style>