<template>
  <header class="bg-green-500 h-10">
    <nav class="h-full flex items-center justify-between relative bg-inherit">
      <div class="pl-2 h-full flex items-center">
        <span class="font-serif font-semibold text-xl tracking-tight block">My Invoices</span>
      </div>
      <div class="hidden sm:block h-full flex items-center">
        <ul class="top-nav h-full">
          <li v-for="item in items" :key="item.route" class="flex items-center pt-2">
            <router-link :to="{ name: item.route }">
              {{ item.caption }}
            </router-link>
          </li>
        </ul>
      </div>
      <div class="block sm:hidden right-0 h-full flex flex-col bg-inherit">
        <div class="">
          <button
            @click="showMenu = !showMenu"
            class="float-right flex items-center px-3 py-2 border rounded text-green-200 border-green-400 hover:text-white hover:border-white"
          >
            <SvgHamburger />
          </button>
        </div>
        <div v-if="showMenu" class="block sm:hidden bg-inherit">
          <ul class="mobile-nav">
            <li v-for="item in items" :key="item.route" class="block px-2 py-2">
              <router-link :to="{ name: item.route }">
                {{ item.caption }}
              </router-link>
            </li>
          </ul>
        </div>
      </div>
    </nav>
  </header>
</template>
<style lang="scss" scoped>
header::after {
  content: '';
  @apply table clear-both;
}

.bg-inherit {
  background-color: inherit;
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
      @apply border-t-4 border-green-700;
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
      @apply border-green-900;
    }
  }
}

.mobile-nav {
  li {
    position: relative;
  }

  a {
    &::before {
      content: '';
      @apply absolute;
      @apply left-0 border-l-4 border-green-700;
      @apply top-2/4 h-0;
      @apply opacity-0;
      transition: height ease-in-out 200ms, top ease-in-out 200ms, opacity ease-in-out 250ms;
    }

    &:hover::before,
    &.active::before {
      @apply opacity-100;
      @apply h-full top-0;
    }

    &.active:before {
      @apply opacity-100;
      @apply border-green-900;
    }
  }
}
</style>
<script lang="ts">
import { defineComponent, ref } from 'vue';
import { useRouter } from 'vue-router';
import SvgHamburger from './SvgHamburger.vue';

export default defineComponent({
  name: 'NavHeader',
  components: { SvgHamburger },
  setup() {
    const router = useRouter();
    const routes = router.getRoutes();
    const items = routes
      .filter((r) => r.meta?.nav?.caption)
      .map((r) => {
        return {
          route: r.name,
          caption: r.meta.nav?.caption ?? 'Missing Caption',
        };
      });
    console.log(items);

    const showMenu = ref(false);
    return {
      showMenu,
      items,
    };
  },
});
</script>
