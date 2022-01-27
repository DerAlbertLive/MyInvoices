import { mountComposition, mountCompositionWithWrapper } from '../../src/useHelper';
import { onMounted, onUnmounted, ref } from 'vue';

function useTestComposition(text: string, lifeCycle: boolean) {
  const theText = ref(text);

  if (lifeCycle) {
    onMounted(() => {
      theText.value = 'Mounted';
    });

    onUnmounted(() => {
      theText.value = 'Unmounted';
    });
  }

  return {
    theText,
  };
}

describe('useStateValidator', () => {
  it('Hello Text ist given, so no onMounted lifecycle is registered', () => {
    const composition = mountComposition(() => useTestComposition('Hello', false));
    expect(composition.theText.value).toBe('Hello');
  });

  it('Mounted Text ist given, so onMounted lifecycle is called', () => {
    const composition = mountComposition(() => useTestComposition('Hello', true));
    expect(composition.theText.value).toBe('Mounted');
  });

  it('Unmounted Text ist given, so onUnmounted lifecycle is called on unmount', () => {
    const result = mountCompositionWithWrapper(() => useTestComposition('Hello', true));

    result.wrapper.unmount();

    expect(result.composition.theText.value).toBe('Unmounted');
  });
});
