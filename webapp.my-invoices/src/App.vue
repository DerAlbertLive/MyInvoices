<template>
  <div id="app" class="h-screen">
    <NavHeader />
    <div class="flex">
      <div class="w-1/5 lg:w-1/6 bg-orange-200 h-screen p-1 text-orange-800">
        <Sidebar class="tex" />
      </div>
      <div class="w-4/5 lg:w-5/6 p-1">
        <router-view />
      </div>
    </div>
    <Debug />
  </div>
</template>

<script lang="ts">
import NavHeader from './components/NavHeader.vue';
import Sidebar from '@/components/Sidebar.vue';
import Debug from '@/components/Debug.vue';
import { defineComponent } from 'vue';

export default defineComponent({
  components: {
    NavHeader,
    Sidebar,
    Debug,
  },
});
</script>
<style lang="scss" src="./assets/css/site.scss"></style>
