import BaseService from './BaseService'
import { ApiResponse, KeyValue } from '@/models'

export class CommonService extends BaseService {

    getDatabaseTypes() {
        return this.get('/common/types/database') as Promise<ApiResponse<KeyValue[]>>
    }
    
}