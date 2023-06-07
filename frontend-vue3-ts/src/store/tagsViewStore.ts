import { defineStore } from 'pinia'

export const tagsViewStore = defineStore("tagsViewStore", {
  state: () => {
    return {
      visitedViews: [] as any[],
      cachedViews: [] as any[],
    }
  },
  actions: {
    addView(view: any) {
      this.addVisitedView(view);
      this.addCachedView(view);
    },
    addVisitedView(view: { name: string; path: string; fullPath: string; meta: { title: string; icon: string; affix: boolean; }; }) {
      // console.log("addVisitedView", view);
      if (this.visitedViews.some((v: { path: string; }) => v.path === view.path)) return;
      // if (this.visitedViews.some((v: { name: string; }) => v.name === view.name)) return;

      this.visitedViews.push(
        Object.assign({}, view, {
          title: view.meta.title || 'no-name'
        })
      )
      // console.log("visitedViews", this.visitedViews)
    },
    addCachedView(view: any) {
      if (this.cachedViews.includes(view.name)) return;
      if (view.meta.isCache) {
        this.cachedViews.push(view.name);
      }
    },
    delView(view: any) {
      return new Promise((resolve) => {
        this.delVisitedView(view);
        this.delCachedView(view);
        resolve({
          visitedViews: [...this.visitedViews],
          cachedViews: [...this.cachedViews],
        });
      });
    },
    delVisitedView(view: { path: string }) {
      return new Promise((resolve) => {
        for (const [i, v] of this.visitedViews.entries()) {
          if (v.path === view.path) {
            this.visitedViews.splice(i, 1);
            break;
          }
        }
        resolve([...this.visitedViews]);
      });
    },
    delCachedView(view: any) {
      return new Promise((resolve) => {
        const index = this.cachedViews.indexOf(view.name);
        index > -1 && this.cachedViews.splice(index, 1);
        resolve([...this.cachedViews]);
      });
    },
    delOthersViews(view: any) {
      return new Promise((resolve) => {
        this.delOthersVisitedViews(view);
        this.delOthersCachedViews(view);
        resolve({
          visitedViews: [...this.visitedViews],
          cachedViews: [...this.cachedViews],
        });
      });
    },
    delOthersVisitedViews(view: { path: string }) {
      return new Promise((resolve) => {
        this.visitedViews = this.visitedViews.filter((v) => {
          return v.meta.affix || v.path === view.path;
        });
        resolve([...this.visitedViews]);
      });
    },
    delOthersCachedViews(view: { name: string }) {
      return new Promise((resolve) => {
        const index = this.cachedViews.indexOf(view.name);
        if (index > -1) {
          this.cachedViews = this.cachedViews.slice(index, index + 1);
        } else {
          this.cachedViews = [];
        }
        resolve([...this.cachedViews]);
      });
    },
    delAllViews(view?: any) {
      return new Promise((resolve) => {
        this.delAllVisitedViews(view);
        this.delAllCachedViews(view);
        resolve({
          visitedViews: [...this.visitedViews],
          cachedViews: [...this.cachedViews],
        });
      });
    },
    delAllVisitedViews(view: any) {
      return new Promise((resolve) => {
        // prettier-ignore
        const affixTags = this.visitedViews.filter(tag => tag.meta.affix)
        this.visitedViews = affixTags;
        resolve([...this.visitedViews]);
      });
    },
    delAllCachedViews(view: any) {
      return new Promise((resolve) => {
        this.cachedViews = [];
        resolve([...this.cachedViews]);
      });
    },
    updateVisitedView(view: { path: string }) {
      for (let v of this.visitedViews) {
        if (v.path === view.path) {
          v = Object.assign(v, view);
          break;
        }
      }
    },
    delRightTags(view: { path: string }) {
      return new Promise((resolve) => {
        // prettier-ignore
        const index = this.visitedViews.findIndex((v: { path: string }) => v.path === view.path);
        if (index === -1) {
          return;
        }
        this.visitedViews = this.visitedViews.filter((item, idx) => {
          if (idx <= index || (item.meta && item.meta.affix)) {
            return true;
          }
          const i = this.cachedViews.indexOf(item.name);
          if (i > -1) {
            this.cachedViews.splice(i, 1);
          }
          return false;
        });
        resolve([...this.visitedViews]);
      });
    },
    delLeftTags(view: { path: string }) {
      return new Promise((resolve) => {
        // prettier-ignore
        const index = this.visitedViews.findIndex((v: { path: string }) => v.path === view.path);
        if (index === -1) {
          return;
        }
        this.visitedViews = this.visitedViews.filter((item, idx) => {
          if (idx >= index || (item.meta && item.meta.affix)) {
            return true;
          }
          const i = this.cachedViews.indexOf(item.name);
          if (i > -1) {
            this.cachedViews.splice(i, 1);
          }
          return false;
        });
        resolve([...this.visitedViews]);
      });
    },
  }
})