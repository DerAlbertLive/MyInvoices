import { App } from '@vue/runtime-core';
import { createSimpleStoreKey, SimpleStore } from '../../../store/simple-store';
import { inject } from 'vue';
import { Product } from '../types';

type ProductsState = {
  products: Product[];
};

class ProductsStore extends SimpleStore<ProductsState> {
  protected data(): ProductsState {
    return {
      products: [],
    };
  }

  addProduct(product: Product) {
    this.internalState.products.push(product);
  }
}

const ProductsStoreKey = createSimpleStoreKey<ProductsStore>('ProductsStoreKey');

export function createProductsStore(app: App) {
  const store = new ProductsStore();
  app.provide(ProductsStoreKey, store);
}

export function useProductsStore(): ProductsStore {
  return inject(ProductsStoreKey) as ProductsStore;
}
