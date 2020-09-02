import Vue from 'vue';
import VueRouter, { RouteConfig } from 'vue-router';
import Home from '../views/Home.vue';
import CustomerRoutes from '@/modules/customers/customers-routes';
import InvoicesRoutes from '@/modules/invoices/invoices-routes';
import TimeKeepingRoutes from '@/modules/timeKeeping/time-keeping-routes';

Vue.use(VueRouter);
const routes: Array<RouteConfig> = [
  {
    path: '/',
    name: 'home',
    component: Home
  },
  {
    path: '/about',
    name: 'about',
    component: () => import(/* webpackChunkName: 'about' */ '../views/About.vue')
  },
  TimeKeepingRoutes,
  InvoicesRoutes,
  CustomerRoutes
];

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
});

export default router;
