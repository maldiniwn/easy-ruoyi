import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'
import { createSvgIconsPlugin } from "vite-plugin-svg-icons";
import path from 'path'

// https://vitejs.dev/config/
export default defineConfig(() => {
  return {
    server: {
      open: false,  //是否自动打开浏览器
      port: 8900    //端口
    },
    plugins: [
      vue(),
      createSvgIconsPlugin({
        // 指定需要缓存的图标文件夹
        iconDirs: [path.resolve(process.cwd(), "src/assets/icons/svg")],
        // 指定symbolId格式
        symbolId: "icon-[dir]-[name]",
      }),
    ],
    resolve: {
      alias: {
        '@': path.resolve(__dirname, "src")
      },
      // https://cn.vitejs.dev/config/#resolve-extensions
      extensions: ['.mjs', '.js', '.ts', '.jsx', '.tsx', '.json', '.vue']
    }
  }
})

// export default defineConfig({
//   plugins: [vue()],
// })

