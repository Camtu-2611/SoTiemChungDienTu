import Vue from 'vue'
import App from './App.vue'
import vuetify from './plugins/vuetify'
import VueMask from 'v-mask'
import Vuex from 'vuex'
import { router } from './router/Router'
import VueToast from 'vue-toast-notification';
import 'vue-toast-notification/dist/theme-sugar.css';
import store from './store/index.js';
import 'jquery/src/jquery.js';
import 'popper.js/dist/popper.min.js';
import BootstrapVue from 'bootstrap-vue'
import 'bootstrap/dist/css/bootstrap.css'
//import 'bootstrap-vue/dist/bootstrap-vue.css'
import 'bootstrap/dist/js/bootstrap.min.js';
// Vue.config.productionTip = false
Vue.config.silent = true

//Vue.use(BootstrapVue)
Vue.use(Vuex)
Vue.use(VueMask);
Vue.use(VueToast, {
    // One of the options
    position: 'top-right'
})
new Vue({
    router,
    vuetify,
    store,
    render: h => h(App)
}).$mount('#app')