import { RouteRecordRaw } from 'vue-router';

const routes: RouteRecordRaw = {
  path: '/projects',
  name: 'projectsContainer',
  redirect: 'projects',
  components: {
    default: () => import(/* webpackChunkName: "Projects" */ './ProjectsContainer.vue'),
    sidebar: () => import(/* webpackChunkName: "Projects" */ './ProjectsSidebar.vue'),
  },
  meta: {
    title: 'Projects',
    nav: {
      caption: 'Projects',
    },
  },
  children: [
    {
      path: '',
      name: 'projects',
      component: () => import(/* webpackChunkName: "Projects" */ './Projects.vue'),
    },
    {
      path: 'products',
      name: 'products',
      component: () => import(/* webpackChunkName: "Projects" */ './products/Products.vue'),
    },
  ],
};

export default routes;
