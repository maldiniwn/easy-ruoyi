import { tagsViewStore } from "@/store/tagsViewStore";
import router from "@/router";

export default {
	// 刷新当前tab页签
	async refreshPage(obj: any) {
		const { path, matched }: any = router.currentRoute;
		if (obj === undefined) {
			matched.forEach(
				(m: { components: { default: { name: string } } }) => {
					// prettier-ignore
					if (m.components && m.components.default && m.components.default.name) {
						if (!["Layout", "ParentView"].includes(m.components.default.name)) {
							obj = { name: m.components.default.name, path: path };
						}
					}
				}
			);
		}
		await tagsViewStore().delCachedView(obj);
		router.replace({
			path: obj.path
		});
		// const { path: path_1 } = obj;
		// console.log("refreshPage", obj.path)
		// console.log("path_1", path_1)
		// router.replace({
		// 	path: "/redirect" + path_1,
		// });
	},
	// 关闭当前tab页签，打开新页签
	closeOpenPage(obj: any) {
		const viewStore = tagsViewStore();
		viewStore.delView(router.currentRoute.value);
		if (obj !== undefined) {
			return router.push(obj);
		}
	},
	// 关闭指定tab页签
	async closePage(obj: any) {
		if (obj === undefined) {
			// prettier-ignore
			const lastPath = await tagsViewStore().delView(router.currentRoute) as any;
			return await router.push(lastPath || "/");
		}
		return tagsViewStore().delView(obj);
	},
	// 关闭所有tab页签
	closeAllPage() {
		return tagsViewStore().delAllViews();
	},
	// 关闭左侧tab页签
	closeLeftPage(obj: any) {
		// prettier-ignore
		return tagsViewStore().delLeftTags(obj || router.currentRoute);
	},
	// 关闭右侧tab页签
	closeRightPage(obj: any) {
		// prettier-ignore
		return tagsViewStore().delRightTags(obj || router.currentRoute);
	},
	// 关闭其他tab页签
	closeOtherPage(obj: any) {
		// prettier-ignore
		return tagsViewStore().delOthersViews(obj || router.currentRoute);
	},
	// 添加tab页签
	openPage(title: any, url: any) {
		var obj = { path: url, meta: { title: title } };
		tagsViewStore().addView(obj);
		return router.push(url);
	},
	// 修改tab页签
	updatePage(obj: any) {
		return tagsViewStore().updateVisitedView(obj);
	},
};
