import { SimpleStore, storeFactory } from './simple-store';

type NavigationState = {
  hamburgerMenuVisible: boolean;
};

class NavigationStore extends SimpleStore<NavigationState> {
  protected setup(): NavigationState {
    return {
      hamburgerMenuVisible: false,
    };
  }

  toggleHamburgerMenu() {
    this._state.hamburgerMenuVisible = !this._state.hamburgerMenuVisible;
  }

  hideHamburgerMenu() {
    this._state.hamburgerMenuVisible = false;
  }
}

const defaultKey = 'Navigation';

export function useNavigationStore(): NavigationStore {
  return storeFactory(defaultKey, () => new NavigationStore());
}
