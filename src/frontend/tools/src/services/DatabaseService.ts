import BaseService from './BaseService'
import { ApiResponse } from '@/models'
import { Table, Column } from './../models'

export class DatabaseService extends BaseService {

    listDatabases(connectionId: number) {
        return this.get(`/database?connectionId=${connectionId}`) as Promise<ApiResponse<string[]>>
    }

    listTables(connectionId: number, dbName: string) {
        return this.get(`/database/tables?connectionId=${connectionId}&dbName=${dbName}`) as Promise<ApiResponse<Table[]>>
    }

    listColumns(connectionId: number, tableName: string) {
        return this.get(`/database/tables?connectionId=${connectionId}&tableName=${tableName}`) as Promise<ApiResponse<Column[]>>
    }

}