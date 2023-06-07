/**
 * 操作权限处理
 * Copyright (c) 2019 ruoyi
 */
import { Directive, DirectiveBinding } from "vue";
import { userStore } from "@/store/userStore";

export const hasPermi: Directive = {
  mounted(el: HTMLElement, binding: DirectiveBinding) {
    const { value } = binding;
    const all_permission = "*:*:*";
    const store = userStore();
    const permissions = store.permissions;

    if (value && value instanceof Array && value.length > 0) {
      const permissionFlag = value;

      const hasPermissions = permissions.some((permission: string) => {
        return (
          all_permission === permission ||
          permissionFlag.includes(permission)
        );
      });

      // console.log("hasPermissions", hasPermissions)

      if (!hasPermissions) {
        el.parentNode && el.parentNode.removeChild(el);
      }
    } else {
      throw new Error(`请设置操作权限标签值`);
    }
  },
};

/**
 * 角色权限处理
 * Copyright (c) 2019 ruoyi
 */
export const hasRole: Directive = {
  mounted(el: HTMLElement, binding: DirectiveBinding) {
    const { value } = binding;
    const super_admin = "admin";
    const store = userStore();
    const roles = store.roles;

    if (value && value instanceof Array && value.length > 0) {
      const roleFlag = value;

      const hasRole = roles.some((role: string) => {
        return super_admin === role || roleFlag.includes(role);
      });

      if (!hasRole) {
        el.parentNode && el.parentNode.removeChild(el);
      }
    } else {
      throw new Error(`请设置角色权限标签值"`);
    }
  },
};
