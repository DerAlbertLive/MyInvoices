import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router';

import { routes as CustomerRoutes } from '@/modules/customers';
import ProjectRoutes from '@/modules/projects/projects-routes';
import InvoicesRoutes from '@/modules/invoices/invoices-routes';
import TimeKeepingRoutes from '@/modules/timeKeeping/time-keeping-routes';

const routes: Array<RouteRecordRaw> = [
  {
    path: '/',
    name: 'home',
    component: import(/* webpackChunkName: "home" */ '@/views/Home.vue'),
    meta: {
      nav: {
        caption: 'Home',
      },
    },
  },
  TimeKeepingRoutes,
  InvoicesRoutes,
  ProjectRoutes,
  CustomerRoutes,
  {
    path: '/about',
    name: 'about',
    component: import(/* webpackChunkName: "home" */ '@/views/About.vue'),
    meta: {
      nav: {
        caption: 'About',
      },
    },
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
