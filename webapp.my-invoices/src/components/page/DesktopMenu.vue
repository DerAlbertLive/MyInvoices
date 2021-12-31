<template>
  <div class="hidden sm:block h-full flex items-center">
    <ul class="top-nav h-full">
      <li
        v-for="item in items"
        :key="item.route"
        class="flex items-center pt-2"
      >
        <router-link :to="{ name: item.route }">
          {{ item.caption }}
        </router-link>
      </li>
    </ul>
  </div>
</template>
<script setup lang="ts">

import { MenuItem } from './Menu';

interface Props {
  items?: Array<MenuItem>;
}

const props = withDefaults(defineProps<Props>(), {
  items: (): [] => [],
});

</script>
<style lang="scss" scoped>
@tailwind components;
header::after {
  content: '';
  @apply table clear-both;
}

@layer components {
  .border-nav-active {
    @apply border-rose-100;
  }

  .border-nav-hover {
    @apply border-rose-200;
  }

  .header-background {
    @apply bg-rose-800;
  }

  .header-text {
    @apply text-slate-200;
  }
}

.top-nav {
  li {
    @apply inline-block ml-4 mr-1 h-full;
    @apply relative;
  }

  a {
    &::before {
      content: '';
      @apply absolute bottom-0;
      @apply border-t-4 border-nav-hover;
      @apply left-2/4 w-0;
      @apply opacity-0;

      transition: left ease-in-out 200ms, width ease-in-out 200ms, opacity ease-in-out 250ms;
    }
  }
}
</style>
