<template>
  <div class="navbar">
    <el-dropdown class="avatar-container" trigger="click">
      <div class="avatar-wrapper">
        <img :src="defaultAvatar" class="user-avatar">
        <span class="user-name">admin</span>
        <i class="el-icon-caret-bottom"/>
      </div>
    </el-dropdown>
  </div>
</template>

<script lang="ts">
import { Vue, Component } from 'vue-property-decorator'
import defaultAvatar  from '@/assets/logo.png'

@Component
export default class NavBar extends Vue {
      defaultAvatar = defaultAvatar
}
</script>

<style rel="stylesheet/scss" lang="scss" scoped>
.navbar {
  height: 50px;
  line-height: 50px;
  border-radius: 0px !important;
  .hamburger-container {
    line-height: 58px;
    height: 50px;
    float: left;
    padding: 0 10px;
  }
  .screenfull {
    position: absolute;
    right: 90px;
    top: 16px;
    color: red;
  }
  .avatar-container {
    height: 50px;
    display: inline-block;
    position: absolute;
    right: 35px;
    .avatar-wrapper {
      cursor: pointer;
      position: relative;
      .user-name {
        display: inline-block;
        height: 40px;
        line-height: 40px;
        font-size: 16px;
        vertical-align: middle;
      }
      .user-avatar {
        width: 40px;
        height: 40px;
        border-radius: 50%;
        vertical-align: middle;
      }
      .el-icon-caret-bottom {
        position: absolute;
        right: -20px;
        top: 17px;
        font-size: 16px;
      }
    }
  }
}
</style>

