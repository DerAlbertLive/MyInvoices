<template>
  <div>
    <h2>Projects</h2>
    <ul role="list">
      <li data-testid="project-list" v-for="(project, index) in projects" :key="index">
        {{ project }}
      </li>
    </ul>
    <label class="block">
      Project:
      <input v-model="newProject" type="text" />
    </label>
    <button
      @click="add"
      type="button"
      class="bg-gray-200 border border-gray-600 rounded p-2 hover:bg-gray-100"
    >
      Add
    </button>
  </div>
</template>

<script lang="ts">
import { computed, defineComponent, ref } from 'vue';
import { useProjectsStore } from './projects-store';

export default defineComponent({
  name: 'Projects',
  setup() {
    const newProject = ref('');
    const store = useProjectsStore();
    const projects = computed(() => store.state.projects);
    return {
      newProject,
      projects,
      add: () => {
        store.addProject(newProject.value);
        newProject.value = '';
      },
    };
  },
});
</script>
<style lang="scss"></style>
