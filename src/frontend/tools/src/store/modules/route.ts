import { MutationTree, ActionTree, Module } from 'vuex'
import { RouteState } from '@/models'

const state: RouteState = {
  currentRouteName: ''
}

const mutations: MutationTree<RouteState> = {
  SET_CURRENT_ROUTE_NAME: (state, name: string) => {
    state.currentRouteName = name
  }
}

const actions: ActionTree<RouteState, RouteState> = {
  SetCurrentRouteName({ commit }, routeName: string) {
    commit('SET_CURRENT_ROUTE_NAME', routeName)
  },
}

const routeStore: Module<RouteState, RouteState> = {
  state,
  mutations,
  actions
}

export default routeStore
