export interface SidebarInfo {
    opened: boolean
    withoutAnimation: boolean
}

export interface AppState {
    sidebar: SidebarInfo
    device: string
}