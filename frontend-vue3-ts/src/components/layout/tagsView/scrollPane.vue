<template>
  <el-scrollbar ref="scrollContainer" :vertical="false" class="scroll-container" @wheel.prevent="handleScroll">
    <slot />
  </el-scrollbar>
</template>

<script setup lang="ts">
import { ref, getCurrentInstance, computed, onBeforeUnmount, onMounted } from "vue";
import { tagsViewStore } from "@/store/tagsViewStore";

const tagAndTagSpacing = ref(4);
const { proxy }: any = getCurrentInstance();
const scrollContainer = ref();
// const scrollWrapper = computed(() => proxy.$refs.scrollContainer.$refs.wrap$);
const scrollWrapper = computed(() => scrollContainer.value.$refs.wrapRef);
const visitedViews = computed(() => tagsViewStore().visitedViews);

// console.log("proxy.$refs.scrollContainer", proxy.$refs.scrollContainer)

// console.log("scrollContainer", scrollContainer)

const emit = defineEmits<{
  (event: 'scroll'): void
}>()

const emitScroll = () => {
  emit("scroll");
};

const handleScroll = (e: any) => {
  const eventDelta = e.wheelDelta || -e.deltaY * 40;
  const $scrollWrapper = scrollWrapper.value;
  $scrollWrapper.scrollLeft = $scrollWrapper.scrollLeft + eventDelta / 4;
};

const moveToTarget = (currentTag: any) => {
  const $container = proxy.$refs.scrollContainer.$el;
  const $containerWidth = $container.offsetWidth;
  const $scrollWrapper = scrollWrapper.value;
  let firstTag = null;
  let lastTag = null;
  // find first tag and last tag
  if (visitedViews.value.length > 0) {
    firstTag = visitedViews.value[0];
    lastTag = visitedViews.value[visitedViews.value.length - 1];
  }
  if (firstTag === currentTag) {
    $scrollWrapper.scrollLeft = 0;
  } else if (lastTag === currentTag) {
    $scrollWrapper.scrollLeft =
      $scrollWrapper.scrollWidth - $containerWidth;
  } else {
    const tagListDom: any = document.getElementsByClassName("tags-view-item");
    const currentIndex = visitedViews.value.findIndex(
      (item) => item === currentTag
    );
    let prevTag = null;
    let nextTag = null;
    for (const k in tagListDom) {
      if (k !== "length" && Object.hasOwnProperty.call(tagListDom, k)) {
        // prettier-ignore
        if (tagListDom[k].dataset.path === visitedViews.value[currentIndex - 1].path) {
          prevTag = tagListDom[k];
        }
        // prettier-ignore
        if (tagListDom[k].dataset.path === visitedViews.value[currentIndex + 1].path) {
          nextTag = tagListDom[k];
        }
      }
    }
    if (nextTag && prevTag) {
      // the tag's offsetLeft after of nextTag
      // prettier-ignore
      const afterNextTagOffsetLeft = nextTag.offsetLeft + nextTag.offsetWidth + tagAndTagSpacing.value;
      // the tag's offsetLeft before of prevTag
      // prettier-ignore
      const beforePrevTagOffsetLeft = prevTag.offsetLeft - tagAndTagSpacing.value;
      // prettier-ignore
      if (afterNextTagOffsetLeft > $scrollWrapper.scrollLeft + $containerWidth) {
        $scrollWrapper.scrollLeft = afterNextTagOffsetLeft - $containerWidth;
      } else if (beforePrevTagOffsetLeft < $scrollWrapper.scrollLeft) {
        $scrollWrapper.scrollLeft = beforePrevTagOffsetLeft;
      }
    }
  }
};

onMounted(() => {
  // console.log("scrollContainer.$refs", scrollContainer.$refs)
  // console.log("scrollContainer.value.$refs", scrollContainer.value.$refs)
  // console.log("scrollContainer.value.$refs.wrapRef", scrollContainer.value.$refs.wrapRef)
  scrollWrapper.value.addEventListener("scroll", emitScroll, true);
});

onBeforeUnmount(() => {
  scrollWrapper.value.removeEventListener("scroll", emitScroll);
});

defineExpose({
  moveToTarget,
});
</script>

<style lang="scss" scoped></style>