/// <reference path="./../models/RouteMeta.ts"></reference>

import { RouteConfig } from 'vue-router'

declare module 'vue-router/types/router' {
    interface RouteConfig {
        hidden?: boolean
    }
}