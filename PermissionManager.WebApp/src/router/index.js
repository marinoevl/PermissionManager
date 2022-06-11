import {createRouter, createWebHistory} from "vue-router";
import PermissionsView from "../views/PermissionsView.vue";

const router = createRouter({
    history: createWebHistory(import.meta.env.BASE_URL),
    routes: [
        {
            path: "/",
            name: "Permissions",
            component: PermissionsView,
        },
        {            
            path: "/Permission/:id(\\d+)*",
            name: "Permission",
            component: () => import("../views/Permissions/PermissionView.vue"),
        },
    ],
});

export default router;
