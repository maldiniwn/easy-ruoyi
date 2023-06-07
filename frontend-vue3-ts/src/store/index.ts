//pinia
import { createPinia } from "pinia"
//pinia持久化插件
import piniaPersist from "pinia-plugin-persist"

const pinia = createPinia()
pinia.use(piniaPersist)

export default pinia