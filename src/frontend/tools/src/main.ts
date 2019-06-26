import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import SvgIcon from 'vue-svgicon'
import ElementUI from 'element-ui'
import 'normalize.css'
import 'element-ui/lib/theme-chalk/index.css'
import '@/styles/index.scss'
import '@/icons/components'

Vue.use(ElementUI)
Vue.use(SvgIcon, {
  tagName: 'svg-icon',
  defaultWidth: '1em',
  defaultHeight: '1em'
})

import '@/utils/vue.extenssions'

Vue.config.productionTip = false

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
