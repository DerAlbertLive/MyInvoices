<template>
  <div>
    <router-view name="sidebar"></router-view>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
export default defineComponent({
  name: 'SidebarNavigation',
  data() {
    return {
      expandOnHover: false,
      mobile: 'reduce',
      reduce: false,
    };
  },
});
</script>

<style lang="scss"></style>
