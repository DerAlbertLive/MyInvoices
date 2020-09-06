<template>
  <nav class="flex items-center justify-between flex-wrap bg-orange-500 p-6">
    <div class="flex items-center flex-shrink-0 text-white mr-6">
      <span class="font-serif font-semibold text-xl cir tracking-tight block sm:hidden">MI</span>
      <span class="font-serif font-semibold text-xl  tracking-tight hidden sm:block">
        My Invoices
      </span>
    </div>
    <div class="block md:hidden">
      <button
        class="flex items-center px-3 py-2 border rounded text-orange-200 border-orange-400 hover:text-white hover:border-white"
      >
        <svg class="fill-current h-3 w-3" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg">
          <title>Menu</title>
          <path d="M0 3h20v2H0V3zm0 6h20v2H0V9zm0 6h20v2H0v-2z" />
        </svg>
      </button>
    </div>
    <div class="w-full block flex-grow md:flex md:items-center lg:w-auto">
      <div class="text-sm md:flex-grow">
        <router-link
          v-for="item in items"
          :key="item.route"
          :to="{ name: item.route }"
          class="block mt-4 md:inline-block md:mt-0 text-orange-200 hover:text-white mr-4"
        >
          {{ item.caption }}
        </router-link>
      </div>
    </div>
  </nav>
</template>

<script lang="ts">
import { defineComponent } from 'vue';

export default defineComponent({
  name: 'header',
  data() {
    return {
      items: [
        { route: 'home', caption: 'Home' },
        { route: 'time-keeping', caption: 'TimeKeeping' },
        { route: 'invoices', caption: 'Invoices' },
        { route: 'customers', caption: 'Customers' }
      ]
    };
  }
});
</script>

<style lang="scss"></style>
