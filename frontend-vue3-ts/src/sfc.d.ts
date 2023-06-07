//在router.ts中引入.vue文件，会提示打不到module，但是编译可能成功，运行也不报错
//解决方法：
//在src根目录下，新建一个sfc.d.ts
//输入如下内容
// declare module "*.vue" {
//   import Vue from 'vue'
//   export default Vue
// }