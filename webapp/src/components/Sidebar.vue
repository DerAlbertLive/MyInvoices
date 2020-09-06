<template>
  <div>Sidebar
    <router-view name="sidebar"></router-view>
  </div>
</template>

<script lang="ts">

export default {
  data() {
    return {
      expandOnHover: false,
      mobile: 'reduce',
      reduce: false
    };
  }
};
</script>

<style lang="scss"></style>
