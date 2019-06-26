import Vue from 'vue'
import Vuex, { ModuleTree } from 'vuex'
import app from './modules/app'
import user from './modules/user'
import route from './modules/route'
import getters from './getters'

Vue.use(Vuex)

const modules: ModuleTree<any> = {
  app,
  user,
  route,
}

const store = new Vuex.Store({
  modules,
  getters
})

export default store
