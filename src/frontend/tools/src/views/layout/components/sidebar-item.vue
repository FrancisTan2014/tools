<template>
  <div v-if="visible" class="menu-wrapper">
    <el-menu-item
      v-if="!hasChildren"
      :index="menuIndex"
      :class="{'submenu-title-noDropdown' : !isNest}"
    >
        <svg-icon v-if="!!icon" :name="icon" />
        <span v-if="!!title">{{ title }}</span>
    </el-menu-item>

    <el-submenu v-else ref="subMenu" :index="menuIndex" popper-append-to-body>
      <template slot="title">
        <svg-icon v-if="!!icon" :name="icon" />
        <span v-if="!!title">{{ title }}</span>
      </template>
      <sidebar-item
        v-for="child in route.children"
        :is-nest="true"
        :route="child"
        :key="child.path"
        :base-path="routePath"
        class="nest-menu" />
    </el-submenu>

  </div>
</template>

<script lang="ts">
import { Vue, Component, Prop } from 'vue-property-decorator'
import { RouteConfig } from 'vue-router'
import path from 'path'

@Component({
    name: 'SidebarItem'
})
export default class SidebarItem extends Vue {
    
    @Prop({ required: true })
    route !: RouteConfig

    @Prop({ default: false })
    isNest !: boolean

    @Prop({ default: '' })
    basePath !: string

    get visible() {
        return !!this.route.meta.hidden === false
    }

    get hasChildren() {
        const sub = this.route.children || []
        return sub.length > 0
    }

    get icon() {
        return this.route.meta.icon
    }

    get title() {
        return this.route.meta.title
    }

    get routePath() {
        return this.resolvePath(this.route.path)
    }

    get menuIndex() {
        return this.routePath
    }

    resolvePath(routePath: string) {
        return path.resolve(this.basePath, routePath)
    }

    mounted() {
    }
}

</script>
