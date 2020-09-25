import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router';

import CustomerRoutes from '@/modules/customers/customers-routes';
import InvoicesRoutes from '@/modules/invoices/invoices-routes';
import TimeKeepingRoutes from '@/modules/timeKeeping/time-keeping-routes';

const routes: Array<RouteRecordRaw> = [
  {
    path: '/',
    name: 'home',
    component: import(/* webpackChunkName: "home" */ '@/views/Home.vue')
  },
  {
    path: '/about',
    name: 'about',
    component: import(/* webpackChunkName: "home" */ '@/views/About.vue')
  },
  TimeKeepingRoutes,
  InvoicesRoutes,
  CustomerRoutes
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
});

export default router;
