import { RouteRecordRaw } from 'vue-router';

const routes: RouteRecordRaw = {
  path: '/invoices',
  name: 'invoicesContainer',
  redirect: 'invoices',
  components: {
    default: () => import(/* webpackChunkName: "Invoices" */ './InvoicesContainer.vue'),
    sidebar: () => import(/* webpackChunkName: "Invoices" */ './InvoicesSidebar.vue'),
  },
  meta: {
    title: 'Invoices',
  },
  children: [
    {
      path: '',
      name: 'invoices',
      component: () => import(/* webpackChunkName: "Invoices" */ './Invoices.vue'),
    },
  ],
};

export default routes;
