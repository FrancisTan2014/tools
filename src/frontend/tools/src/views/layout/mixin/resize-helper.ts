
import { Vue, Component, Watch } from 'vue-property-decorator'
import { State } from 'vuex-class'
import store from '@/store'
import { AppState } from '@/models'

const { body } = document
const WIDTH = 992 // refer to Bootstrap's responsive design

@Component
export default class ResizeMixin extends Vue {

  @State('app') 
  app !: AppState

  get device() {
    return this.app.device
  }

  get sidebar() {
    return this.app.sidebar
  }

  @Watch('$route')
  onRouteChange() {
    if (this.device === 'mobile' && this.sidebar.opened) {
      store.dispatch('CloseSideBar', { withoutAnimation: false })
    }
  }

  beforeMount() {
    window.addEventListener('resize', this.resizeHandler)
  }

  mounted() {
    const isMobile = (this as any).isMobile()
    if (isMobile) {
      store.dispatch('ToggleDevice', 'mobile')
      store.dispatch('CloseSideBar', { withoutAnimation: true })
    }
  } 
  
  isMobile() {
    const rect = body.getBoundingClientRect()
    return rect.width - 1 < WIDTH
  }

  resizeHandler() {
    if (document.hidden) {
      return
    }
    const isMobile = this.isMobile()
    store.dispatch('ToggleDevice', isMobile ? 'mobile' : 'desktop')

    if (isMobile) {
      store.dispatch('CloseSideBar', { withoutAnimation: true })
    }
  }

}

