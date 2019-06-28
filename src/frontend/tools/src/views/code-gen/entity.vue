<template>
    <section class="app-container">

        <div class="app-header">
            <h2 class="title">
                代码生成器
            </h2>
        </div>

        <div class="app-body">
            
            <div>
                请选择：
                <el-select v-model="selectedConnectionId" placeholder="数据库连接" @change="onConnectionChange">
                  <el-option v-for="con in connections" :key="con.id" :label="con.name" :value="con.id"></el-option>
                </el-select>

                <el-select class="ml10" v-if="databases && databases.length > 0" v-model="selectedDatabase" placeholder="数据库" @change="onDatabaseChanged">
                  <el-option v-for="db in databases" :key="db" :label="db" :value="db"></el-option>
                </el-select>
            </div>

            <el-table :data="tables" :loading="tablesLoading" border class="mt10">
              <el-table-column type="index"></el-table-column>
              <el-table-column label="名称" prop="tableName"></el-table-column>
              <el-table-column label="说明" prop="tableComment"></el-table-column>
              <el-table-column label="引擎" prop="engine"></el-table-column>
              <el-table-column label="自动增长" prop="autoIncrement"></el-table-column>
              <el-table-column label="创建时间" prop="createTime"></el-table-column>
              <el-table-column label="操作"></el-table-column>
            </el-table>

        </div>

    </section>
</template>

<script lang="ts">
import { Vue, Component } from 'vue-property-decorator'
import { ConnectionService, CommonService, DatabaseService } from '@/services'
import { Connection as ConnectionModel, ValidatorRule, KeyValue, Table } from '@/models'

@Component
export default class Entity extends Vue {
   
    private readonly connectionService: ConnectionService = new ConnectionService()
    private readonly databaseService: DatabaseService = new DatabaseService()

    connections: ConnectionModel[] = []
    selectedConnectionId: number | string = ''
    databases: string[] = []
    selectedDatabase: string = ''
    tables: Table[] = []
    tablesLoading: boolean = false

    created() {
        this.loadConnections()
    }

    async loadConnections() {
        const response = await this.connectionService.getList()
        this.connections = response.data
    }

    async onConnectionChange(connectionId: number) {
        const response = await this.databaseService.listDatabases(connectionId)
        this.databases = response.data
    }

    async onDatabaseChanged(dbName: string) {
        this.$ajaxStart(this, 'tablesLoading')
        const response = await this.databaseService.listTables(this.selectedConnectionId as number, dbName)
        this.$ajaxDone(this, 'tablesLoading')
        this.tables = response.data
    }
    

}
</script>


<style>

</style>
