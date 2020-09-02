import { RouteConfig } from 'vue-router';

const routes: RouteConfig = {
  path: '/customers',
  name: 'customersContainer',
  redirect: 'customers',
  components: {
    default: () => import(/* webpackChunkName: "Customers" */ './CustomersContainer.vue'),
    sidebar: () => import(/* webpackChunkName: "Customers" */ './CustomersSidebar.vue')
  },
  meta: {
    title: 'Customers'
  },
  children: [
    {
      path: '',
      name: 'customers',
      component: () => import(/* webpackChunkName: "Customers" */ './Customers.vue')
    }
  ]
};

export default routes;
