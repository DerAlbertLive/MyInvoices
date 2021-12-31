/* eslint-disable @typescript-eslint/no-explicit-any */
import { getCurrentInstance, inject, InjectionKey, reactive, readonly } from 'vue';

// based on https://medium.com/@mario.brendel1990/vue-3-the-new-store-a7569d4a546f

export abstract class SimpleStore<T extends Record<string, unknown>> {
  protected _state: T;

  constructor() {
    this._state = reactive(this.setup()) as T;
    this.readOnlyState = readonly(this._state) as T;
  }

  protected abstract setup(): T;

  private readonly readOnlyState: T;

  get state(): T {
    return this.readOnlyState;
  }
}

function getStoreSymbol<T>(description: string): InjectionKey<T> {
  return Symbol.for(`SimpleStoreKey_${description}`);
}

export function storeFactory<T extends SimpleStore<any>>(key: string, factory: () => T): T {
  const storeKey = getStoreSymbol<T>(key);
  return inject(
    storeKey,
    () => {
      const instance = getCurrentInstance();
      if (instance == null) {
        throw Error(`useStoreFactory for ${key} must be used within setup`);
      }
      const provides = instance.appContext.provides;
      const s = factory();
      provides[storeKey as unknown as string] = s;
      return s;
    },
    true
  );
}
