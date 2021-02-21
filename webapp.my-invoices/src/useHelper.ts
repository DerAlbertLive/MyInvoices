import { MountingOptions, shallowMount } from '@vue/test-utils';
import { defineComponent, h } from 'vue';

export function mountCompositionWithWrapper<TComposition>(factory: () => TComposition) {
  // eslint-disable-next-line @typescript-eslint/ban-ts-ignore
  // @ts-ignore
  let composition: TComposition = null;

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

  if (composition === null) {
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
