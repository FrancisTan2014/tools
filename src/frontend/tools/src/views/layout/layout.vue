<template>
  <div :class="classObj" class="app-wrapper">
    <div v-if="device==='mobile'&&sidebar.opened" class="drawer-bg" @click="handleClickOutside"/>
    <sidebar class="sidebar-container"/>
    <div class="main-container">
      <navbar/>
      <app-main/>
    </div>
  </div>
</template>

<script lang="ts">
import { Vue, Component } from 'vue-property-decorator'
import { Navbar, Sidebar, AppMain } from './components'
import ResizeMixin from './mixin/resize-helper'

@Component({
  components: {
    Navbar,
    Sidebar,
    AppMain
  },
})
export default class Layout extends ResizeMixin {
  name = 'Layout'

  get classObj() {
    return {
      hideSidebar: !this.sidebar.opened,
      openSidebar: this.sidebar.opened,
      withoutAnimation: this.sidebar.withoutAnimation,
      mobile: this.device === 'mobile'
    }
  }
  
  handleClickOutside() {
    this.$store.dispatch('CloseSideBar', { withoutAnimation: false })
  }
  
}
</script>

<style rel="stylesheet/scss" lang="scss" scoped>
  @import "src/styles/mixin.scss";
  .app-wrapper {
    @include clearfix;
    position: relative;
    height: 100%;
    width: 100%;
    &.mobile.openSidebar{
      position: fixed;
      top: 0;
    }
  }
  .drawer-bg {
    background: #000;
    opacity: 0.3;
    width: 100%;
    top: 0;
    height: 100%;
    position: absolute;
    z-index: 999;
  }
</style>
