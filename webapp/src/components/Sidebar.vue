<template>
  <b-sidebar position="static" mobile="reduced" type="is-light" open>
    <router-view name="sidebar"></router-view>
  </b-sidebar>
</template>

<script lang="ts">
import { defineComponent } from '@vue/composition-api';

export default defineComponent({
  data() {
    return {
      expandOnHover: false,
      mobile: 'reduce',
      reduce: false
    };
  }
});
</script>

<style lang="scss"></style>
