<template>
    <section class="app-container">

        <div class="app-header">
            <h2 class="title">
                <span>数据库连接管理</span>
                <el-button type="primary" icon="el-icon-plus" size="medium" class="fr" @click="onNewClick">New</el-button>
            </h2>
        </div>

        <div class="app-body">
            <el-table :data="connections" border :loading="loading">
              <el-table-column label="编号" prop="id"></el-table-column>
              <el-table-column label="名称" prop="name"></el-table-column>
              <el-table-column label="类型">
                  <template slot-scope="scope">
                      <span>{{ getTypeName(scope.row.dbType) }}</span>
                  </template>
              </el-table-column>
              <el-table-column label="主机" prop="host"></el-table-column>
              <el-table-column label="端口号" prop="port"></el-table-column>
              <el-table-column label="用户名" prop="username"></el-table-column>
              <el-table-column label="密码">
                  <template slot-scope="scope">
                      <span v-if="!scope.row.password">{{ scope.row.password }}</span>
                      <span v-else>******</span>
                  </template>
              </el-table-column>
              <el-table-column label="操作">
                  <template slot-scope="scope">
                      <el-button type="text" icon="el-icon-edit-outline" title="修改" @click="onEditClick(scope.row)"></el-button>
                      <el-button type="text" icon="el-icon-delete-solid" title="删除" @click="onRemoveClick(scope.row.id)"></el-button>
                  </template>
              </el-table-column>
            </el-table>
        </div>

        <el-dialog :title="editModel.id > 0 ? '修改' : '新增'" :visible.sync="editFormVisible" @close="editForm.clearValidate()">
            <el-form ref="editForm" :model="editModel" :rules="rules" label-position="right" label-width="120px">
              <el-form-item label="连接名称：" prop="name">
                  <el-input v-model="editModel.name" placeholder="请输入连接名称"></el-input>
              </el-form-item>
              <el-form-item label="数据库类型：" prop="dbTypes">
                  <el-select v-model="editModel.dbType" placeholder="请选择">
                    <el-option v-for="type in dbTypes" :key="type.key" :label="type.key" :value="type.value"></el-option>
                  </el-select>
              </el-form-item>
              <el-form-item label="主机地址：" prop="host">
                  <el-input v-model="editModel.host" placeholder="请输入 IP 地址"></el-input>
              </el-form-item>
              <el-form-item label="端口号：" prop="port">
                  <el-input v-model="editModel.port" placeholder="请输入端口号"></el-input>
              </el-form-item>
              <el-form-item label="用户名：" prop="username">
                  <el-input v-model="editModel.username" placeholder="请输入数据库登录用户名"></el-input>
              </el-form-item>
              <el-form-item label="登录密码：" prop="password">
                  <el-input type="password" v-model="editModel.password" placeholder="请输入数据库登录密码"></el-input>
              </el-form-item>
            </el-form>

            <div slot="footer">
                <el-button :loading="saving" type="primary" size="medium" @click="onSave()">保存</el-button>
                <el-button :loading="saving" size="medium" @click="editFormVisible = false">取消</el-button>
            </div>
        </el-dialog>

    </section>
</template>

<script lang="ts">

import { Vue, Component, Model } from 'vue-property-decorator'
import { ConnectionService, CommonService } from '@/services'
import { Connection as ConnectionModel, ValidatorRule, KeyValue } from '@/models'
import { Form } from 'element-ui';

@Component({
    name: 'Connection',
    filters: {
        
    }
})
export default class Connection extends Vue {
    
    private readonly connectionService: ConnectionService = new ConnectionService()
    private readonly commonService: CommonService = new CommonService()

    // booleans
    loading: boolean = false
    editFormVisible: boolean = false
    saving: boolean = false

    connections: ConnectionModel[] = []
    dbTypes: KeyValue[] = []
    editModel: ConnectionModel = new ConnectionModel()
    rules = {
        name: ValidatorRule.createRequired('请输入连接名称'),
        host: [
            ValidatorRule.createRequired('请输入主机 IP 地址'),
            ValidatorRule.createPattern(/\b(?:(?:2(?:[0-4][0-9]|5[0-5])|[0-1]?[0-9]?[0-9])\.){3}(?:(?:2([0-4][0-9]|5[0-5])|[0-1]?[0-9]?[0-9]))\b/ig, '请输入合法的 IP 地址'),
        ],
        port: [
            ValidatorRule.createRequired('请输入端口号'),
            ValidatorRule.createPattern(/^([0-9]{1,4}|[1-5][0-9]{4}|6[0-4][0-9]{3}|65[0-4][0-9]{2}|655[0-2][0-9]|6553[0-5])$/g, '请输入有效的端口号'),
        ],
        username: [
            ValidatorRule.createRequired('请输入用户名'),
            ValidatorRule.createRange(1, 20, '用户名最大长度为 20'),
        ],
    }

    get editForm() {
        return this.$refs.editForm as Form
    }

    created() {
        this.loadData()
        this.loadDbTypes()
    }

    async loadData() {
        this.$ajaxStart(this, 'loading')
        const response = await this.connectionService.getList()
        this.connections = response.data
        this.$ajaxDone(this, 'loading')
    }

    async loadDbTypes() {
        const response = await this.commonService.getDatabaseTypes()
        this.dbTypes = response.data
        this.$log('after db types loaded', this.dbTypes)
    }

    // 点击 New 按钮
    onNewClick() {
        this.editModel = new ConnectionModel()
        this.editFormVisible = true
    }

    onEditClick(model: ConnectionModel) {
        this.editModel = Object.assign({}, model)
        this.editFormVisible = true
    }

    async onSave() {
        const valid = await this.editForm.validate()
        if (valid === false) {
            return
        }
        const request = this.editModel.id > 0 
            ? this.connectionService.update 
            : this.connectionService.add
        this.$ajaxStart(this, 'saving')
        const response = (this.editModel.id > 0)
            ? await this.connectionService.update(this.editModel)
            : await this.connectionService.add(this.editModel)
        this.$ajaxDone(this, 'saving')
        if (response.success) {
            this.$success('保存成功')
            this.loadData()
            this.editFormVisible = false
        } else {
            this.$error('保存失败，请稍后重试')
        }
    }

    onRemoveClick(id: number) {
        this.$confirm('是否确定要删除此连接？')
            .then(async () => {
                const response = await this.connectionService.remove(id)
                if (response.success) {
                    this.$success('删除成功')
                    this.loadData()
                } else {
                    this.$error('删除失败，请稍后重试')
                }
            }).catch(() => {})
    }

    getTypeName(type: number) {
        const res = this.dbTypes.find(item => item.value == type)
        if (res === undefined) {
            throw new Error(`cannot find type(${type}) from this.dbTypes `)
        }
        return res.key
    }

}
</script>

<style>

</style>
