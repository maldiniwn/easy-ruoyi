<template>
  <div :class="{ show: show }" class="header-search">
    <svg-icon class-name="search-icon" icon-class="search" @click.stop="click" />
    <el-select ref="headerSearchSelectRef" v-model="search" :remote-method="querySearch" filterable default-first-option
      remote placeholder="Search" class="header-search-select" @change="change">
      <el-option v-for="option in options" :key="option.path" :value="option.path" :label="option.fullPath" />
    </el-select>
  </div>
</template>

<script setup lang="ts">
import { useRouter } from "vue-router";
import { ref, reactive, watch, onMounted, nextTick } from "vue";
import { permissionStore } from "@/store/permissionStore"

const show = ref<boolean>(false);
const search = ref<string>();
const options = ref([] as any);
const headerSearchSelectRef = ref();
const router = useRouter();

const click = () => {
  show.value = !show.value;
  if (show.value) {
    search.value = "";
    headerSearchSelectRef.value && headerSearchSelectRef.value.focus();
  }
}

const close = () => {
  headerSearchSelectRef.value && headerSearchSelectRef.value.blur();
  options.value = [];
  show.value = false;
}

const querySearch = (query: string) => {
  if (query === "") return;
  // console.log("query", query)
  options.value = permissionStore().leafMenus.filter((ele: any) => {
    return ele.fullPath.includes(query);
  })
}

const change = (val: string) => {
  console.log("val", val)
  router.push(val);
  nextTick(() => {
    show.value = false;
    options.value = [];
    search.value = "";
  })
}

watch(show, (value) => {
  if (value) {
    document.body.addEventListener("click", close);
  } else {
    document.body.removeEventListener("click", close);
  }
});

</script>

<style lang="scss" scoped>
.header-search {
  font-size: 0 !important;

  .search-icon {
    cursor: pointer;
    font-size: 18px;
    vertical-align: middle;
  }

  .header-search-select {
    font-size: 18px;
    transition: width 0.2s;
    width: 0;
    overflow: hidden;
    background: transparent;
    border-radius: 0;
    display: inline-block;
    vertical-align: middle;

    :deep(.el-input__inner) {
      border-radius: 0;
      border: 0;
      padding-left: 0;
      padding-right: 0;
      box-shadow: none !important;
      border-bottom: 1px solid #d9d9d9;
      vertical-align: middle;
    }
  }

  &.show {
    .header-search-select {
      width: 210px;
      margin-left: 10px;
    }
  }
}
</style>