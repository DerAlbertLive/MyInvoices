<template>
  <form @submit.prevent="onSubmit">
    <button class="btn" type="submit">{{ buttonText }}</button>
  </form>
</template>

<script lang="ts">
import { defineComponent } from 'vue';

export default defineComponent({
  name: 'ProductForm',
  props: {
    buttonText: {
      type: String,
      default: 'Save',
    },
  },
  emits: ['submitted'],
  setup(props, { emit }) {
    const onSubmit = () => {
      emit('submitted');
    };
    return {
      onSubmit,
    };
  },
});
</script>

<style scoped lang="scss"></style>
