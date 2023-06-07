// import * as components from "@element-plus/icons-vue";
import * as ElementPlusIconsVue from "@element-plus/icons-vue";

export default {
	install: (app: any) => {
		// for (const key in ElementPlusIconsVue) {
		// 	const componentConfig = ElementPlusIconsVue[key];
		// 	app.component(componentConfig.name, componentConfig);
		// }
		for (const [key, component] of Object.entries(ElementPlusIconsVue)) {
			// console.log(`key:${key}    component:${component.name}`)
			app.component(key, component)
		}
	},
};
// const app = createApp(App)
// for (const [key, component] of Object.entries(ElementPlusIconsVue)) {
//   app.component(key, component)
// }