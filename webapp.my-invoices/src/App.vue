<template>
  <div
    id="app"
    class="h-screen"
  >
    <NavHeader />
    <div class="flex">
      <div class="w-1/5 lg:w-1/6 bg-orange-200 h-screen p-1 text-orange-800">
        <Sidebar class="tex" />
      </div>
      <div class="w-4/5 lg:w-5/6 p-1">
        <BreadCrump />
        <router-view />
      </div>
    </div>
    <Debug />
  </div>
</template>

<script lang="ts" setup>
import NavHeader from './components/page/NavHeader.vue';
import Sidebar from './components/page/Sidebar.vue';
import Debug from './components/page/DebugLayout.vue';
import BreadCrump from './components/BreadCrump.vue';

</script>
