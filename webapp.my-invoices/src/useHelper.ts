import { MountingOptions, shallowMount } from '@vue/test-utils';
import { defineComponent, h } from 'vue';

export function mountCompositionWithWrapper<TComposition>(factory: () => TComposition) {
  let composition: TComposition | undefined;

  const component = defineComponent({
    setup() {
      composition = factory();
      return composition;
    },
    render() {
      return h('div');
    },
  });

  const mountOptions: MountingOptions<never> = {};

  const wrapper = shallowMount(component, mountOptions);

  if (!composition) {
    throw Error('no composition could be created');
  }
  return {
    wrapper,
    composition,
  };
}

export function mountComposition<TComposition>(factory: () => TComposition): TComposition {
  const result = mountCompositionWithWrapper(factory);
  return result.composition;
}
