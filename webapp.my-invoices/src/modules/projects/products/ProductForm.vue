<template>
  <form @submit.prevent="onSubmit">
    <button class="btn" type="submit">{{ buttonText }}</button>
  </form>
</template>

<script lang="ts">
import { defineComponent } from 'vue';

interface Arvato {
  sdfin: () => void;
}

const a = new Arvato.sdfin();
export default defineComponent({
  name: 'ProductForm',
  emits: ['submitted'],
  props: {
    buttonText: {
      type: String,
      default: 'Save',
    },
  },
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
