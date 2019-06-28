
import request from '@/utils/request'

export default class BaseService {

    protected request = request

    protected get = request.get

    protected post = request.post

    protected put = request.put

    protected delete = request.delete

}