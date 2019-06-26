
import Vuex, { MutationTree, ActionTree, Module } from 'vuex'
import { UserState } from '@/models'

const state: UserState = {
  token: '',
  name: '',
  avatar: '',
  user: {},
}

const mutations: MutationTree<UserState> = {
  SET_TOKEN: (state: any, token: string) => {
    state.token = token
  },
  SET_NAME: (state: any, name: string) => {
    state.name = name
  },
  SET_AVATAR: (state: any, avatar: string) => {
    state.avatar = avatar
  },
  SET_USER: (state: any, user: any) => {
    state.user = user
  }
}

const actions: ActionTree<any, UserState> = {

}

const userStore: Module<UserState, UserState> = {
  state,
  mutations,
  actions
}

export default userStore
