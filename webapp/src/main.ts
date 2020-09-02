import Vue from 'vue';
import VueCompositionAPI from '@vue/composition-api';
import router from './router';
import store from './store';
import FontAwesomeIcon from './appicons';

import App from './App.vue';

import Buefy from 'buefy';
import 'buefy/dist/buefy.css';

Vue.component('font-awesome-icon', FontAwesomeIcon);

Vue.config.productionTip = false;

Vue.use(Buefy, {
  defaultIconComponent: 'font-awesome-icon',
  defaultIconPack: 'fas'
});

Vue.use(VueCompositionAPI);

new Vue({
  router,
  store,
  render: (h) => h(App)
}).$mount('#app');
