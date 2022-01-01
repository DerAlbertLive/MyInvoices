<template>
  <div class="block sm:hidden right-0 h-full flex flex-col bg-inherit">
    <div class="">
      <button
        class="float-right flex items-center px-3 py-2 border rounded text-green-200 border-green-400 hover:text-white hover:border-white"
        @click="toggleMenu"
      >
        <MenuIcon class="fill-slate-300" />
      </button>
    </div>
    <div
      v-if="showMenu"
      class="block sm:hidden bg-inherit"
    >
      <ul class="mobile-nav">
        <li
          v-for="item in items"
          :key="item.route"
          class="block px-2 py-2"
        >
          <router-link
            :to="{ name: item.route }"
            @click="hideMenu"
          >
            {{ item.caption }}
          </router-link>
        </li>
      </ul>
    </div>
  </div>
</template>
<script setup lang="ts">
import { computed } from 'vue';
import { useNavigationStore } from '../../store/navigation-store';
import { MenuIcon } from '@heroicons/vue/outline';
import { MenuItem } from './Menu';

withDefaults(defineProps<{
  items?: Array<MenuItem>
}>(), {
  items: () => [],
});


const store = useNavigationStore();

const showMenu = computed(() => store.state.hamburgerMenuVisible);
const toggleMenu = () => store.toggleHamburgerMenu();

const hideMenu = () => store.hideHamburgerMenu();

</script>
<style lang="scss" scoped>
@import "../../assets/css/site.scss";


.mobile-nav {
  li {
    position: relative;
  }

  a {
    &::before {
      content: '';
      @apply absolute;
      @apply left-0 border-l-4 border-nav-hover;
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
      @apply border-nav-active;
    }
  }
}
</style>
