import { SimpleStore, storeFactory } from '../../store/simple-store';

type Customer = {
  id: string;
  number: string;
  name: string;
  street: string;
  city: string;
  zipCode: string;
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

  async loadCustomers() {
    this._state.customers = [];
    this._state.customers = [
      {
        id: '123',
        number: '20023',
        name: 'Kunde 1',
        street: 'Postfach 0815',
        city: 'Woanders',
        zipCode: '2344',
      },
      {
        id: '124',
        number: '20013',
        name: 'Kunde 2',
        street: 'Sperlingsweg 6',
        city: 'Köln',
        zipCode: '3247',
      },
      {
        id: '125',
        number: '20014',
        name: 'Kunde 3',
        street: 'Woo wie 19',
        city: ' Hier',
        zipCode: '50829',
      },
    ];
  }
}

const defaultKey = 'Customers';

export function useCustomersStore(): CustomersStore {
  return storeFactory(defaultKey, () => new CustomersStore());
}
