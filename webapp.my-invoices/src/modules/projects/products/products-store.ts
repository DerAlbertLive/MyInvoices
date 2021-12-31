import { SimpleStore, storeFactory } from '../../../store/simple-store';
import { Product } from '../types';

type ProductsState = {
  products: Product[];
};

class ProductsStore extends SimpleStore<ProductsState> {
  protected setup(): ProductsState {
    return {
      products: [],
    };
  }

  addProduct(product: Product) {
    this._state.products.push(product);
  }
}

const defaultKey = 'Products';

export function useProductsStore(): ProductsStore {
  return storeFactory(defaultKey, () => new ProductsStore());
}
