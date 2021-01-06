import { Plugin } from 'vue';
import { createProjectsStore } from '../modules/projects/projects-store';
import { createCustomersStore } from '../modules/customers';

const stores: Plugin = {
  install: (app) => {
    createProjectsStore(app);
    createCustomersStore(app);
  },
};

export default stores;
