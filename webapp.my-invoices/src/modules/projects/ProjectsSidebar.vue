<template>
  <ul>
    <li>
      <router-link :to="{ name: 'projects' }">Projects</router-link>
    </li>
    <hr />
    <li>
      <router-link :to="{ name: 'products' }">Products</router-link>
    </li>
  </ul>
</template>

<script lang="ts">
export default {};
</script>
<style lang="scss"></style>
