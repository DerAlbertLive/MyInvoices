<template>
  <div id="app">
    <Header />
    <div class="columns">
      <div class="column is-narrow">
        <Sidebar />
      </div>
      <div class="column has-background-warning is-v">
        <router-view />
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import Header from '@/components/Header.vue';
import Sidebar from '@/components/Sidebar.vue';

export default {
  components: {
    Header,
    Sidebar
  }
};
</script>
<style lang="scss"></style>
