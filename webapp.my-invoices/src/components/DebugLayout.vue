<template>
  <div class="absolute bottom-0 left-0 bg-blue-300 p-2 bg-transparent">
    <span class="block sm:hidden">&lt; sm</span>
    <span class="hidden sm:block md:hidden">sm</span>
    <span class="hidden md:block lg:hidden">md</span>
    <span class="hidden lg:block xl:hidden">lg</span>
    <span class="hidden xl:block">xl</span>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';

export default defineComponent({
  name: 'DebugLayout',
});
</script>

<style lang="scss"></style>
