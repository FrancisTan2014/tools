<template>
  <el-scrollbar wrap-class="scrollbar-wrapper">
    <el-menu
      :show-timeout="200"
      :default-active="$route.path"
      :background-color="variables.menuBg"
      :text-color="variables.menuText"
      :active-text-color="variables.menuActiveText"
      :router="true"
      mode="vertical"
    >
        <sidebar-item v-for="route in routes" :key="route.path" :route="route" :base-path="''"/>
    </el-menu>
  </el-scrollbar>
</template>

<script lang="ts">
import { Vue, Component } from 'vue-property-decorator'
import variables from '@/styles/variables.scss'
import SidebarItem from './sidebar-item.vue'

@Component({
    components: {
      SidebarItem
    }
})
export default class SideBar extends Vue {
    get routes() {
      console.log((this.$router as any).options.routes)
      return (this.$router as any).options.routes
    }

    variables: object = variables
}
</script>


<style>

</style>
