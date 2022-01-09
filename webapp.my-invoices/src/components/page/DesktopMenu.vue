<script setup lang="ts">
import { MenuItem } from './Menu';

withDefaults(defineProps<{
  items?: Array<MenuItem>
}>(), {
  items: () => [],
});

</script>

<template>
  <div class="hidden sm:block h-full items-center">
    <ul class="top-nav h-full">
      <li
        v-for="item in items"
        :key="item.route"
        class="flex items-center pt-2"
      >
        <router-link :to="{ name: item.route, params: {} }">
          {{ item.caption }}
        </router-link>
      </li>
    </ul>
  </div>
</template>

<style lang="scss" scoped>
@import '../../assets/css/site.scss';

.top-nav {
  li {
    @apply inline-block ml-4 mr-1 h-full;
    @apply relative;
  }

  a {
    &::before {
      content: '';
      @apply border-nav-hover;
      @apply absolute bottom-0;
      @apply border-t-4;
      @apply left-2/4 w-0;
      @apply opacity-0;

      transition: left ease-in-out 200ms, width ease-in-out 200ms, opacity ease-in-out 250ms;
    }

    &:hover::before,
    &.active::before {
      @apply opacity-100;
      @apply left-0 w-full;
    }

    &.active:before {
      @apply opacity-100;
      @apply border-nav-active;
    }
  }
}

</style>
