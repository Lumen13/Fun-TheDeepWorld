import ElementPlus from 'element-plus';
import ru from 'element-plus/es/locale/lang/ru';
import axios from 'axios';
import VueAxios from 'vue-axios';
import moment from 'moment';
import 'bootstrap';

import { createApp } from 'vue';
import App from './App.vue';

import 'bootstrap/dist/css/bootstrap.min.css';

global.jQuery = require('jquery');

const $ = global.jQuery;
window.$ = $;

moment.locale('ru');

fetch(process.env.BASE_URL + 'authConfig.json').then((json) => {
  json.json().then(async () => {
    const app = createApp(App);
    app.config.productionTip = false;

    app.use(ElementPlus, { locale: ru });
    app.use(VueAxios, axios);
    app.use(moment);

    app.mount('#app');
  });
});
