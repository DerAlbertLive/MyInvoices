<script lang="ts" setup>
import { onBeforeRouteLeave, useRouter } from 'vue-router';
import { BookOpenIcon } from '@heroicons/vue/outline';

import { useNavigationStore } from '../../store/navigation-store';
import DesktopMenu from './DesktopMenu.vue';
import MobileMenu from './MobileMenu.vue';
import { MenuItem } from './Menu';

const router = useRouter();
const routes = router.getRoutes();
const store = useNavigationStore();
const items = routes
  .filter((r) => r.meta?.nav?.caption)
  .map<MenuItem>((r) => {
    return {
      route: r.name as string ?? 'Missing Route Name',
      caption: r.meta.nav?.caption ?? 'Missing Caption',
    };
  });

onBeforeRouteLeave(() => {
  hideMenu();
});

const hideMenu = () => store.hideHamburgerMenu();
</script>
<template>
  <header class="h-10">
    <nav class="h-full flex items-center justify-between relative bg-inherit">
      <div class="pl-2 h-full flex items-center">
        <BookOpenIcon class="w-5 h-5 fill-rose-300" />
        <span class="font-serif font-semibold text-xl tracking-tight block pl-1">My Invoices</span>
      </div>
      <DesktopMenu :items="items" />
      <MobileMenu :items="items" />
    </nav>
  </header>
</template>
<style lang="scss" scoped>
@import "../../assets/css/site.scss";

header::after {
  content: '';
  @apply table clear-both;
}

header {
  @apply header-text;
  @apply header-background;
}

</style>
