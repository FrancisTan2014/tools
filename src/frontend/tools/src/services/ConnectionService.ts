import BaseService from './BaseService'
import { ApiResponse, Connection } from '@/models'

export class ConnectionService extends BaseService {

    getList() {
        return this.get('/connections') as Promise<ApiResponse<Connection[]>>
    }

    add(connection: Connection) {
        return this.post('/connections', connection) as Promise<ApiResponse<number>>
    }

    update(connection: Connection) {
        return this.put(`/connections/${connection.id}`, connection) as Promise<ApiResponse<any>>
    }

    remove(id: number) {
        return this.delete(`/connections/${id}`) as Promise<ApiResponse<any>>
    }
    
}