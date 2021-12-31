import { SimpleStore, useStoreFactory } from '../../store/simple-store';

type Customer = {
  name: string;
};
type CustomersState = {
  customers: Customer[];
};

class CustomersStore extends SimpleStore<CustomersState> {
  protected setup(): CustomersState {
    return {
      customers: [],
    };
  }
}

const defaultKey = 'Customers';

export function useCustomersStore(): CustomersStore {
  return useStoreFactory(defaultKey, () => new CustomersStore());
}
