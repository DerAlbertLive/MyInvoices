import { App } from '@vue/runtime-core';
import { createSimpleStoreKey, SimpleStore } from '@/store/simple-store';
import { inject } from 'vue';

type ProjectsState = {
  projects: string[];
};

class ProjectStore extends SimpleStore<ProjectsState> {
  protected data(): ProjectsState {
    return {
      projects: ['Eins', 'Zwei'],
    };
  }

  addProject(project: string) {
    this.internalState.projects.push(project);
  }
}

const ProjectStoreKey = createSimpleStoreKey<ProjectStore>('ProjectsVuexKey');

export function createProjectsStore(app: App) {
  const store = new ProjectStore();
  app.provide(ProjectStoreKey, store);
}

export function useProjectsStore(): ProjectStore {
  return inject(ProjectStoreKey) as ProjectStore;
}
