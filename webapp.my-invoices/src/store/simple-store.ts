import { InjectionKey, reactive, readonly } from 'vue';

// based on https://medium.com/@mario.brendel1990/vue-3-the-new-store-a7569d4a546f

export abstract class SimpleStore<T extends Record<string, unknown>> {
  protected internalState: T;

  constructor() {
    this.internalState = reactive(this.data()) as T;
    this.readOnlyState = readonly(this.internalState) as T;
    this.setup();
  }

  protected abstract data(): T;

  // eslint-disable-next-line @typescript-eslint/no-empty-function
  setup() {}

  private readonly readOnlyState: T;

  get state(): T {
    return this.readOnlyState;
  }
}

export function createSimpleStoreKey<T>(description: string): InjectionKey<T> {
  return Symbol(description);
}
