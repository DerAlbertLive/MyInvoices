<template>
  <section>
    <div class="prose">
      <h1>Welcome to Invoics,</h1>
      <h2>the time recording and invoice management.</h2>
    </div>
    <div class="bg-black text-white md:text-yellow-500">Test</div>
    <div class="foo">Test</div>
  </section>
</template>

<script lang="ts">
import { defineComponent } from 'vue';

export default defineComponent({
  name: 'HomeView',
});
</script>
<style>
.foo {
  @apply bg-black text-white md:text-yellow-500;
}
</style>
