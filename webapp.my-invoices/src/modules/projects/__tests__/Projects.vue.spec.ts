import { render, fireEvent } from '@testing-library/vue';

import Projects from '../Projects.vue';

import stores from '@/store';

describe('projects', () => {
  it('adds the text', async () => {
    const { getByRole, getAllByRole } = render(Projects, {
      global: {
        plugins: [stores],
      },
    });

    const input = getByRole('textbox') as HTMLInputElement;
    const button = getByRole('button');

    await fireEvent.update(input, 'Hello');

    await fireEvent.click(button);

    const result = getAllByRole('listitem');

    expect(result.length).toBe(3);
    expect(result[2].textContent).toBe('Hello');

    expect(input.value).toBe('');
  });
});
