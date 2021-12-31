<template>
  <table />
</template>

<script lang="ts">
import { defineComponent, PropType } from 'vue';
import { Product } from '../types';

export default defineComponent({
  name: 'ProductList',
  props: {
    products: {
      type: Array as PropType<Product[]>,
      required: true,
      default: (): [] => [],
    },
  },
  setup() {
    return {};
  },
});
</script>

<style scoped lang="scss"></style>
