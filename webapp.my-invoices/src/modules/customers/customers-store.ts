import { createSimpleStoreKey, SimpleStore } from '../../store/simple-store';
import { App } from '@vue/runtime-core';
import { inject } from 'vue';

type Customer = {
  name: string;
};
type CustomersState = {
  customers: Customer[];
};

class CustomersStore extends SimpleStore<CustomersState> {
  protected data(): CustomersState {
    return {
      customers: [],
    };
  }
}

const StoreKey = createSimpleStoreKey<CustomersStore>('PCustomersStoreVuexKey');

export function createCustomersStore(app: App) {
  const store = new CustomersStore();
  app.provide(StoreKey, store);
}

export function useCustomersStore(): CustomersStore {
  return inject(StoreKey) as CustomersStore;
}
