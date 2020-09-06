import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router';
import Home from '@/views/Home.vue';
import About from '@/views/About.vue';

import CustomerRoutes from '@/modules/customers/customers-routes';
import InvoicesRoutes from '@/modules/invoices/invoices-routes';
import TimeKeepingRoutes from '@/modules/timeKeeping/time-keeping-routes';

const routes: Array<RouteRecordRaw> = [
  {
    path: '/',
    name: 'home',
    component: Home
  },
  {
    path: '/about',
    name: 'about',
    component: About
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
