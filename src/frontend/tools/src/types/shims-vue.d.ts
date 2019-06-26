import Vue from 'vue'

declare module '*.vue' {
  export default Vue
}

declare module 'vue/types/vue' {
  interface Vue {
    $ajaxStart(_this: Vue, _loadingPropName: string): void
    $ajaxDone(_this: Vue, _loadingPropName: string): void
    $success: (message: string) => void
    $warning: (message: string) => void
    $error: (message: string) => void
    $log: (...args: any[]) => void
    $logError: (...args: any[]) => void
  }
}
