import { createApp } from 'vue';
import App from './App.vue';
import router from './router';
import stores from './store';
createApp(App).use(stores).use(router).mount('#app');
