/**
 * 菜单模型
 */
export class MenuModel {
  /**
   * id
   */
  id: string = "";
  /**
   * pId
   */
  pId: string = "";
  /**
   * 菜单名称
   */
  name: string = "";
  /**
   * 菜单全路径
   */
  fullPath: string = "";
  /**
   * 路由路径
   */
  path: string = "";
  /**
   * 菜单图标
   */
  menuIcon: string = "";
  /**
   * 子节点
   */
  children: Array<MenuModel> = [];
}