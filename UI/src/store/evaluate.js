// import Vue from "vue"

import axios from "axios";

export default {
    namespaced: true,

    // module assets
    state: {
        evaluateState: "testEva",
        selectedReport: null,
        evaluateReports: [],
        assetList: [],
        disableDetail: false,
    },
    getters: {
    },
    actions: {
        async getAssets({ commit }) {
            try {
                var res = await axios.get("https://localhost:44327/api/TaiSan/GetAll");
                commit("SET_ASSET_LIST", res.data)
            }
            catch (ex) {
                console.error("Get tai san loi roi" + ex);
            }
        },

        async getReports({ commit }) {
            try {
                var res = await axios.get("https://localhost:44382/api/v1/bienbandanhgiataisans");
                commit("SET_EVALUATE_REPORTS", res.data.data);
                console.log("LAY du lieu thanh cong");
            }
            catch (error) {
                console.error("LAy du lieu that bai");
            }
        },
        async getSelectedReport({ commit }, id) {
            try {
                var response = await axios.get("https://localhost:44382/api/v1/bienbandanhgiataisans/" + id);
                var responseDetails = await axios.get("https://localhost:44327/api/ChiTietDanhGia/GetAll/" + id);

                commit("SET_SELECTED_REPORT", {
                    report: response.data.data,
                    reportDetails: responseDetails.data,
                });
                return true;
            }
            catch (ex) {
                console.error("LAy du lieu that bai");
            }
        }

    },
    mutations: {
        SET_DISABLE_DETAIL(state, val) {
            state.disableDetail = val;
        },
        SET_EVALUATE_REPORTS(state, data) {
            state.evaluateReports = data;
        },
        SET_SELECTED_REPORT(state, data) {
            state.selectedReport = data;
        },
        SET_ASSET_LIST(state, data) {
            state.assetList = data;
        },

    },

}