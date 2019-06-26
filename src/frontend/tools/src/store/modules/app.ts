import Cookies from 'js-cookie'
import { MutationTree, ActionTree, Module } from 'vuex'
import { AppState } from '@/models'

const state: AppState = {
  sidebar: {
    opened: !+(Cookies.get('sidebarStatus') || ''),
    withoutAnimation: false
  },
  device: 'desktop'
}

const mutations: MutationTree<AppState> =  {
  TOGGLE_SIDEBAR: (state) => {
    if (state.sidebar.opened) {
      Cookies.set('sidebarStatus', '1')
    } else {
      Cookies.set('sidebarStatus', '0')
    }
    state.sidebar.opened = !state.sidebar.opened
    state.sidebar.withoutAnimation = false
  },
  CLOSE_SIDEBAR: (state, withoutAnimation: boolean) => {
    Cookies.set('sidebarStatus', '1')
    state.sidebar.opened = false
    state.sidebar.withoutAnimation = withoutAnimation
  },
  TOGGLE_DEVICE: (state, device: string) => {
    state.device = device
  }
}

const actions: ActionTree<AppState, AppState> = {
  ToggleSideBar: ({ commit }) => {
    commit('TOGGLE_SIDEBAR')
  },
  CloseSideBar({ commit }, { withoutAnimation }) {
    commit('CLOSE_SIDEBAR', withoutAnimation)
  },
  ToggleDevice({ commit }, device) {
    commit('TOGGLE_DEVICE', device)
  }
}

const appStore: Module<AppState, AppState> = {
  state,
  mutations,
  actions,
}

export default appStore
