import { RouteRecordRaw } from 'vue-router';

const routes: RouteRecordRaw = {
  path: '/timekeeping',
  name: 'timeKeepingContainer',
  redirect: 'time-keeping',
  components: {
    default: () => import(/* webpackChunkName: "TimeKeeping" */ './TimeKeepingContainer.vue'),
    sidebar: () => import(/* webpackChunkName: "TimeKeeping" */ './TimeKeepingSidebar.vue'),
  },
  meta: {
    title: 'Time Keeping',
    nav: {
      caption: 'Time Keeping',
    },
  },
  children: [
    {
      path: '',
      name: 'time-keeping',
      component: () => import(/* webpackChunkName: "TimeKeeping" */ './TimeKeeping.vue'),
    },
  ],
};

export default routes;
