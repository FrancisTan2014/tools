import Vue from 'vue'
import NProgress from 'nprogress'
import { MessageBox } from 'element-ui'

const fn = Vue.prototype
const factory = (type: string) => (message: string) => fn.$message({
  type,
  message
})

fn.$success = factory('success')
fn.$warning = factory('warning')
fn.$error = factory('error')
fn.$confirm = (msg: string) => MessageBox.confirm(msg, '提示', {
  confirmButtonText: '确定',
  cancelButtonText: '取消',
  type: 'warning',
  center: false,
})

fn.$log = function(...args: any[]) {
  const env = process.env.NODE_ENV
  if (env === 'development' || env === 'test') {
    console.log(...args)
  }
}
fn.$logError = function(...args: any[]) {
    console.error(...args)
}

fn.$progress = NProgress
fn.$ajaxStart = (_this: Vue, _loadingPropName: string) => {
    _this.$set(_this, _loadingPropName, true)
    NProgress.start()
}
fn.$ajaxDone = (_this: Vue, _loadingPropName: string) => {
    _this.$set(_this, _loadingPropName, false)
    NProgress.done()
}
