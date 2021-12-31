import { SimpleStore, useStoreFactory } from '@/store/simple-store';

type ProjectsState = {
  projects: string[];
};

class ProjectStore extends SimpleStore<ProjectsState> {
  protected setup(): ProjectsState {
    return {
      projects: ['Eins', 'Zwei'],
    };
  }

  addProject(project: string) {
    this._state.projects.push(project);
  }
}

const defaultKey = 'Projects';

export function useProjectsStore(): ProjectStore {
  return useStoreFactory(defaultKey, () => new ProjectStore());
}
