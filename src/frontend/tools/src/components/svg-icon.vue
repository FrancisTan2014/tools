<template>
  <svg :class="svgClass" aria-hidden="true" v-on="$listeners">
    <use :xlink:href="iconName"/>
  </svg>
</template>

<script lang="ts">
import { Vue, Component, Prop } from 'vue-property-decorator'

@Component
export default class SvgIcon extends Vue {
    name = 'SvgIcon'
    
    @Prop({ required: true })
    iconClass !: string
    
    @Prop({ default: '' })
    className !: string

    get iconName() {
        return `#icon-${this.iconClass}`
    }

    get svgClass() {
      if (this.className) {
        return 'svg-icon ' + this.className
      } else {
        return 'svg-icon'
      }
    }
}
</script>

<style scoped>
.svg-icon {
  width: 1em;
  height: 1em;
  vertical-align: -0.15em;
  fill: currentColor;
  overflow: hidden;
}
</style>
