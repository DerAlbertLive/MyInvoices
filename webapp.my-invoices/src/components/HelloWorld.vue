<template>
  <div>{{ message }}</div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';

export default defineComponent({
  name: 'HelloWorld',
  props: {
    message: String,
  },
  setup() {
    return {};
  },
});
</script>

<style scoped lang="scss"></style>
