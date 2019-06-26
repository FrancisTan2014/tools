/**
 * 为 async-validator 表单验证规则定义的模型，参考文档：https://github.com/yiminghe/async-validator
 */
export class ValidatorRule {
    /**
     * Indicates the type of validator to use. Recognised type values are:
     *   string: Must be of type string. This is the default type.
     *   number: Must be of type number.
     *   boolean: Must be of type boolean.
     *   method: Must be of type function.
     *   regexp: Must be an instance of RegExp or a string that does not generate an exception when creating a new RegExp.
     *   integer: Must be of type number and an integer.
     *   float: Must be of type number and a floating point number.
     *   array: Must be an array as determined by Array.isArray.
     *   object: Must be of type object and not Array.isArray.
     *   enum: Value must exist in the enum.
     *   date: Value must be valid as determined by Date
     *   url: Must be of type url.
     *   hex: Must be of type hex.
     *   email: Must be of type email.
     */
    type?: string = 'string'
    required?: boolean
    pattern?: string | RegExp
    min?: number
    max?: number
    len?: number
    /**
     * To validate a value from a list of possible values use the enum type with a enum property listing the valid values for the field,
     */
    enum?: Array<any>
    fields?: object
    defaultField?: object | Array<object>
    transform?: Function
    message?: any
    validator?: (rule: ValidatorRule, value: any, callback: Function) => any
    asyncValidator?: (rule: ValidatorRule, value: any, callback: Function) => any

    /**
     * 创建一个包含 required 和 message 属性的规则对象
     * @param message 验证失败时提示的消息
     */
    static createRequired(message: string) {
        const instance = new ValidatorRule()
        instance.required = true
        instance.message = message
        return instance
    }

    /**
     * 创建一个对字符串字段进行验证的正则表达式规则对象
     * @param pattern 指定对字符串类型验证的正则表达式
     * @param message 验证失败时提示的消息
     */
    static createPattern(pattern: string | RegExp, message: string) {
        const instance = new ValidatorRule()
        instance.pattern = pattern
        instance.message = message
        return instance
    }

    /**
     * 创建采用自定义验证规则验证目标字段的规则对象
     * @param validator 自定义验证规则方法
     * @param message 验证失败时提示的消息
     */
    static createValidator(validator: (rule: ValidatorRule, value: any, callback: Function) => any, message: string) {
        const instance = new ValidatorRule()
        instance.validator = validator
        instance.message = message
        return instance
    }

    /**
     * 创建一个验证目标值的范围（如：长度、最大最小值等）的验证规则对象
     * @param min 最小值或最小长度
     * @param max 最大值或最大长度
     * @param message 验证失败时提示的消息
     */
    static createRange(min: number, max: number, message: string, type: string = 'string') {
        const instance = new ValidatorRule()
        instance.min = min
        instance.max = max
        instance.type = type
        instance.message = message
        return instance
    }
}