import { Message } from '@arco-design/web-vue';

export default {
  info(msg: string) {
    Message.info(msg);
  },
  warn(msg: string) {
    Message.warning(msg);
  },
  error(msg: string) {
    Message.error(msg);
  },
  success(msg: string) {
    Message.success(msg);
  }
}
