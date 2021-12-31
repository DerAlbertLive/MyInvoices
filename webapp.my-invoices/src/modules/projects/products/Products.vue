<template>
  <div>Products</div>
  <product-list :products="products" />
  <product-form button-text="Neu" />
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import { useProductsStore } from './products-store';
import ProductList from './ProductList.vue';
import ProductForm from './ProductForm.vue';

export default defineComponent({
  name: 'ProductsView',
  components: { ProductList, ProductForm },
  setup() {
    const store = useProductsStore();
    return {
      products: store.state.products,
    };
  },
});
</script>

<style scoped lang="scss"></style>
