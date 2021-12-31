<script lang="ts" setup>
import { onBeforeRouteLeave, useRouter } from 'vue-router';
import { BookOpenIcon } from '@heroicons/vue/outline';

import { useNavigationStore } from '../../store/navigation-store';
import DesktopMenu from './DesktopMenu.vue';
import MobileMenu from './MobileMenu.vue';

const router = useRouter();
const routes = router.getRoutes();
const store = useNavigationStore();
const items = routes
  .filter((r) => r.meta?.nav?.caption)
  .map((r) => {
    return {
      route: r.name ?? 'Missing Route Name',
      caption: r.meta.nav?.caption ?? 'Missing Caption',
    };
  });

onBeforeRouteLeave(() => {
  hideMenu();
});

const hideMenu = () => store.hideHamburgerMenu();
</script>
<template>
  <header class="header-background h-10 header-text">
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
@tailwind components;
header::after {
  content: '';
  @apply table clear-both;
}

.bg-inherit {
  background-color: inherit;
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
</style>
