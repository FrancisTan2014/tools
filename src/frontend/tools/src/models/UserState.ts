import { AdminUser } from './index'

export interface UserState {
    token: string;
    name: string;
    avatar: string;
    user: AdminUser | object;
}