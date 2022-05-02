
import Vue from 'vue'
import Vuex from 'vuex'
import evaluate from './evaluate'

Vue.use(Vuex)

export default new Vuex.Store({
    modules: {
        evaluate,
    },
})