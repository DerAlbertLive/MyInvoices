import { Plugin } from 'vue';
import { createProjectsStore } from '../modules/projects/projects-store';
import { createCustomersStore } from '../modules/customers';
import { createProductsStore } from '../modules/projects/products/products-store';

const stores: Plugin = {
  install: (app) => {
    createProjectsStore(app);
    createCustomersStore(app);
    createProductsStore(app);
  },
};

export default stores;
