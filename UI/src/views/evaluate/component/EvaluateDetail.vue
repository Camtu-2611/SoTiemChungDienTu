<template>
  <div class="detail-container">
    <div class="summary-input">
      <div class="d-header">
        <div class="back-btn icon-back" @click="closeDetail"></div>
        <div class="header-title">
          Đánh giá lại tài sản cố định
          {{ selectedReport ? selectedReport.sobienban : "" }}
        </div>
      </div>

      <div class="input-container">
        <div class="left-pane">
          <div class="first-line">
            <div class="input-field">
              <div class="input-label">Biên bản số</div>
              <input
                v-model="soBienBan"
                  :disabled="disableDetail"
                maxlength="255"
                class="input-two-third"
                type="text"
              />
            </div>

            <div class="current-date">
              <div class="input-field">
                <div class="input-label">Ngày</div>
                <!-- <input v-model="ngayLap" type="date" /> -->
                <datepicker
                  class="date-picker"
                  :disabled="disableDetail"
                  v-model="ngayLap"
                  format="dd - MM - yyyy"
                  required
                ></datepicker>
              </div>
            </div>
          </div>
          <!-- <h1>{{lyDo}}</h1> -->
          <div class="reason">
            <div class="input-field">
              <div class="input-label">Lý do</div>
              <v-autocomplete
                :items="listLyDo"
                item-text="text"
                  :disabled="disableDetail"
                item-value="value"
                v-model="lyDo"
              ></v-autocomplete>
              <!-- <select v-model="lyDo">
                <option
                  v-for="(item, index) in listLyDo"
                  :key="index"
                  :value="item"
                >
                  {{ item }}
                </option>
              </select> -->
            </div>
          </div>
        </div>
      </div>
    </div>

    <div class="detail-input">
      <div class="detail-label">Chi tiết điều chỉnh</div>
      <div class="table-wrapper">
        <table>
          <colgroup>
            <col width="5" />
            <col min-width="10" />
            <col min-width="100" />
            <col min-width="50" />
            <col min-width="50" />
            <col min-width="50" />
          </colgroup>
          <thead>
            <tr>
              <th rowspan="2">#</th>
              <th rowspan="2">Mã tài sản</th>
              <th rowspan="2">Tên tài sản</th>
              <th colspan="3">Giá trị còn lại</th>
              <th colspan="3">Thời gian sử dụng còn lại (tháng)</th>
              <th colspan="3">Khấu hao năm</th>
            </tr>
            <tr>
              <th>Trước điều chỉnh</th>
              <th>Sau điều chỉnh</th>
              <th>Chênh lệch</th>

              <th>Trước điều chỉnh</th>
              <th>Sau điều chỉnh</th>
              <th>Chênh lệch</th>

              <th>Trước điều chỉnh</th>
              <th>Sau điều chỉnh</th>
              <th>Chênh lệch</th>
            </tr>
          </thead>

          <tbody>
            <tr v-for="(item, index) in detailList" :key="item.id">
              <td>
                {{ index }}
              </td>
              <td>
                <v-autocomplete
                  :items="availableAsset"
                  item-text="mataisan"
                  item-value="idtaisan"
                  v-model="item.assetId"
                  no-data-text="Không có dữ liệu"
                  cache-items="true"
                  :disabled="disableDetail"
                  @change="onChangeAsset(item)"
                ></v-autocomplete>
              </td>
              <td>
                <v-autocomplete
                  :items="availableAsset"
                  :disabled="disableDetail"
                  item-text="tentaisan"
                  item-value="idtaisan"
                  v-model="item.assetId"
                  cache-items="true"
                  no-data-text="Không có dữ liệu"
                  @change="onChangeAsset(item)"
                ></v-autocomplete>
              </td>
              <td>
                {{ item.valueBefore }}
              </td>
              <td>
                <div class="input-field">
                  <input
                    v-model="item.valueAfter"
                  :disabled="disableDetail"
                    class="input-two-third"
                    type="number"
                  />
                </div>
              </td>
              <td>
                {{ item.valueBefore - item.valueAfter }}
              </td>
              <td>{{ item.timeBefore }}</td>
              <td>
                <div class="input-field">
                  <input
                    v-model="item.timeAfter"
                  :disabled="disableDetail"
                    class="input-two-third"
                    type="number"
                  />
                </div>
              </td>
              <td>
                {{ item.timeBefore - item.timeAfter }}
              </td>
              <td>{{ item.depreciationBefore }}</td>
              <td>
                <div class="input-field">
                  <input
                    v-model="item.depreciationAfter"
                  :disabled="disableDetail"
                    class="input-two-third"
                    type="number"
                  />
                </div>
              </td>
              <td>
                {{ item.depreciationBefore - item.depreciationAfter }}
              </td>
            </tr>
          </tbody>
        </table>
      </div>

      <div class="table-button" v-show="!disableDetail">
        <BaseButton class="solid" @click="addDetailLine"
          >Thêm dòng mới</BaseButton
        >
        <BaseButton class="solid" @click="deleteLastLine"
          >Xóa dòng cuối</BaseButton
        >
        <BaseButton class="solid" @click="deleteAllLine"
          >Xóa hết dòng</BaseButton
        >
      </div>
    </div>

    <div class="footer">
      <div class="align-left">
        <BaseButton @click="closeDetail">Hủy</BaseButton>
      </div>
      <div class="align-right" v-show="!disableDetail">
        <BaseButton @click="saveAndNew">Cất và thêm</BaseButton>
        <BaseButton @click="saveAndClose" class="active-contrast"
          >Cất và đóng</BaseButton
        >
      </div>
    </div>
  </div>
</template>

<script>
// import BaseDatetimePicker from "@/views/evaluate/base/BaseDatetimePicker.vue";
// import BaseAutocomplete from "@/views/evaluate/base/BaseAutocomplete.vue";
import BaseButton from "@/views/evaluate/base/BaseButton.vue";
import axios from "axios";
import { mapState } from "vuex";
import Dropdown from "vue-simple-search-dropdown";
import datepicker from "vuejs-datepicker";

export default {
  components: {
    // BaseDatetimePicker,
    // BaseAutocomplete,
    BaseButton,
    datepicker,
    Dropdown,
  },
  props: {},
  data() {
    return {
      bienBanDanhGiaTaiSanId: null,
      soBienBan: "",
      ngayLap: "",
      lyDo: null,
      listLyDo: [
        {
          text: "Tháo dỡ một hay một số bộ phận tài sản giảm giá trị tài sản",
          value: "Tháo dỡ một hay một số bộ phận tài sản giảm giá trị tài sản",
        },
        {
          text: "Đánh giá lại tài sản nhằm mục đích liên doanh, góp vốn, chia tách, hợp nhất, giải thể",
          value:
            "Đánh giá lại tài sản nhằm mục đích liên doanh, góp vốn, chia tách, hợp nhất, giải thể",
        },
        {
          text: "Đánh giá lại theo yêu cầu kê biên tài sản của cơ quan có thẩm quyền nhà nước",
          value:
            "Đánh giá lại theo yêu cầu kê biên tài sản của cơ quan có thẩm quyền nhà nước",
        },
      ],
      detailList: [],
    };
  },
  mounted() {
    this.bienBanDanhGiaTaiSanId = this.generateGUID();
    this.addDetailLine();
  },
  methods: {
    async saveDetailLine(line) {
      try {
        var req = {
          giatritruocdieuchinh: line.valueBefore,
          giatrisaudieuchinh: line.valueBefore,
          thoigiantruocdieuchinh: line.timeBefore.toString(),
          thoigiansaudieuchinh: line.timeAfter.toString(),
          khauhaotruocdieuchinh: line.depreciationBefore,
          khauhaosaudieuchinh: line.depreciationAfter,
          bienBanDanhGiaTaiSanId: this.bienBanDanhGiaTaiSanId,
          idtaisan: line.assetId,
        };
        console.log("Req chi tiet: " + JSON.stringify(req));
        await axios.post("https://localhost:44327/api/ChiTietDanhGia", req);
      } catch {
        console.error("Thêm chi tiết biên bản bị lỗi");
        throw "Thêm chi tiết biên bản bị lỗi";
      }
    },

    onChangeAsset(item) {
      // console.log("CHANGE VUETIFYY");
      // Vue.set(item, "assetId", item.assetId);
      item.valueAfter = this.getAssetValue(item.assetId, "giatriconlai");
      item.valueBefore = item.valueAfter;
      item.timeAfter = this.getAssetValue(item.assetId, "thoigianconlai");
      item.timeBefore = item.timeAfter;
      item.depreciationAfter = this.getAssetValue(
        item.assetId,
        "giatritinhkhauhao"
      );
      item.depreciationBefore = item.depreciationAfter;
    },
    getAssetValue(assetId, propName) {
      // console.log("VAo get asset value r");
      try {
        return this.assetList.filter((x) => x.idtaisan == assetId)[0][propName];
      } catch {
        return 0;
      }
    },
    isAssetIdChoosen(assetId) {
      for (let index = 0; index < this.detailList.length; index++) {
        const element = this.detailList[index];
        if (element.assetId == assetId) {
          return true;
        }
      }
      return false;
    },
    deleteAllLine() {
      this.detailList = [];
      this.addDetailLine();
    },
    deleteLastLine() {
      this.detailList.splice(this.detailList.length - 1, 1);
      if (this.detailList.length == 0) {
        this.addDetailLine();
      }
    },

    addDetailLine() {
      this.detailList.push({
        id: this.generateGUID(),
        assetId: null,
        valueBefore: null,
        valueAfter: null,
        timeBefore: null,
        timeAfter: null,
        depreciationBefore: null,
        depreciationAfter: null,
      });
    },

    generateGUID() {
      return "xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx".replace(
        /[xy]/g,
        function (c) {
          var r = (Math.random() * 16) | 0,
            v = c == "x" ? r : (r & 0x3) | 0x8;
          return v.toString(16);
        }
      );
    },

    /**
     * đóng form detail
     */
    closeDetail() {
      this.$emit("toggleShowDetail");
      this.clearExistingDetail();
    },
    /**
     * Xóa dữ liệu detail hiện tại
     */
    clearExistingDetail() {
      this.soBienBan = "";
      this.ngayLap = Date();
      this.lyDo = "";
      this.detailList = [];
      this.addDetailLine();
      this.$store.commit("evaluate/SET_SELECTED_REPORT", null);
    },

    validate() {
      if (!this.soBienBan) {
        this.$toast.error("Số biên bản không được để trống");
        return false;
      }
      if (!this.ngayLap) {
        this.$toast.error("Ngày lập không được để trống");
        return false;
      }
      if (!this.lyDo) {
        this.$toast.error("Lý do không được để trống");
        return false;
      }

      for (let index = 0; index < this.detailList.length; index++) {
        const data = this.detailList[index];
        for (var key in data) {
          if (!data[key]) {
            this.$toast.error("Không được để trống trường " + key);
            return false;
          }
        }
      }
      return true;
    },

    /**
     * Cất và thêm
     *  */
    async saveAndNew() {
      if (this.validate() == false) return;

      try {
        await this.saveEvaluateDetail();
        this.clearExistingDetail();
      } catch {
        console.error("Loi xay ra roi");
      }
    },
    /**
     * Cất và đóng
     *  */
    async saveAndClose() {
      if (this.validate() == false) return;

      try {
        await this.saveEvaluateDetail();
        this.closeDetail();
      } catch {
        console.error("Loi xay ra roi");
      }
    },
    /**
     * Lưu chi tiết biên bản đánh giá
     */
    async saveEvaluateDetail() {
      try {
        var req = {
          bienBanDanhGiaTaiSanId: this.bienBanDanhGiaTaiSanId,
          ngaylap: this.ngayLap,
          lydo: this.lyDo,
          sobienban: this.soBienBan,
        };

        console.log("Bienbandanhgia before post: " + JSON.stringify(req));
        var res = await axios.post(
          "https://localhost:44382/api/v1/bienbandanhgiataisans",
          req
        );
        for (let index = 0; index < this.detailList.length; index++) {
          const line = this.detailList[index];
          await this.saveDetailLine(line);
        }

        this.$toast.success("Lưu biên bản thành công");
        this.$store.dispatch("evaluate/getReports");
        console.log("Post bienbandanhgia successfully " + JSON.stringify(res));
        return res;
      } catch (err) {
        console.error(err.response);
        if (!this.ngayLap) this.$toast.error("Ngày lập không được để trống");
        else this.$toast.error("Lưu biên bản thất bại");
        this.bienBanDanhGiaTaiSanId = this.generateGUID();
        throw err;
      }
    },
  },
  computed: {
    ...mapState({
      selectedReport: (state) => state.evaluate.selectedReport,
      assetList: (state) => state.evaluate.assetList,
      disableDetail: (state) => state.evaluate.disableDetail,
    }),

    /**
     * Tài sản còn có thể chọn
     */
    availableAsset() {
      return this.assetList;
      // if (this.detailList.length <= 1) return this.assetList;
      // return this.assetList.filter((x) => !this.isAssetIdChoosen(x.idtaisan));
    },
  },
  watch: {
    selectedReport(newVal) {
      if (newVal) {
        this.soBienBan = newVal.report.sobienban;
        this.ngayLap = newVal.report.ngaylap;
        this.lyDo = newVal.report.lydo;
        this.bienBanDanhGiaTaiSanId = newVal.report.bienBanDanhGiaTaiSanId;
        this.detailList = [];
        for (let index = 0; index < newVal.reportDetails.length; index++) {
          const d = newVal.reportDetails[index];
          this.detailList.push({
            id: d.chiTietBienBanDanhGiaId,
            assetId: d.idtaisan,
            valueBefore: d.giatritruocdieuchinh,
            valueAfter: d.giatrisaudieuchinh,
            timeBefore: d.thoigiantruocdieuchinh,
            timeAfter: d.thoigiansaudieuchinh,
            depreciationBefore: d.khauhaotruocdieuchinh,
            depreciationAfter: d.khauhaosaudieuchinh,
          });
          // Vue.set(this.detailList[index], "assetId", d.idtaisan);
        }
      } else {
        this.bienBanDanhGiaTaiSanId = this.generateGUID();
      }
    },
  },
};
</script>
<style lang="scss" scoped>
@import "@/style/_variables.scss";

.detail-container {
  width: 100%;
  height: 100%;

  .input-field {
    .input-label {
      font-family: "GoogleSans-Bold";
    }
    input {
      height: 36px;
      box-sizing: border-box;
      border: #d6d6d6 1px solid;
      padding: 10px;
      background-color: white;
    }
    .date-picker {
      border: #d6d6d6 1px solid;
    }
    select {
      background-color: white;
      border: #d6d6d6 1px solid;
      height: 34px;
      min-width: 100px;
      padding-left: 10px;
    }
  }

  .summary-input {
    background-color: $background-evalutate;
    padding: 16px 16px 0px 16px;
    height: fit-content;

    .d-header {
      height: 60px;
      display: flex;
      align-items: center;
      font-size: 1.6rem;
      margin-bottom: 16px;
      .back-btn {
        cursor: pointer;
        margin-right: 20px;
      }

      .header-title {
        font-family: "GoogleSans-Bold";
      }
    }
    .input-container {
      width: 100%;
      display: flex;
      .left-pane {
        width: 80%;
        // border-right: solid 1px grey;
        padding-right: 16px;

        .first-line {
          display: flex;
          justify-content: flex-start;
          margin-bottom: 12px;
          div {
            margin-right: 12px;
          }
        }

        .reason {
          width: 100%;
          .input-field {
            width: 100%;
            select {
              width: 100%;
            }
          }
        }
      }
      .right-pane {
        padding-left: 16px;
        width: 40%;

        .record-date {
          width: 300px;
          margin-bottom: 12px;
        }
      }
    }
  }

  .detail-input {
    padding: 16px;
    height: calc(100% - 347px);

    .detail-label {
      font-size: 1.2rem;
      font-family: "GoogleSans-Bold";
      margin-bottom: 8px;
    }

    .table-wrapper {
      height: calc(100% - 85px);
      overflow: auto;
      border: $border-button-basic solid 1px;
      table {
        thead {
          tr:nth-child(2) {
            th {
              top: 40px !important;
            }
          }

          tr {
            th {
              border-right: 1px solid #d6d6d6;
              z-index: 1;
            }
          }
        }
        tbody {
          tr {
            td {
              input {
                width: 100%;
              }
              //   input[type="text"]:disabled {
              //     background: #ececec;
              //   }
            }
          }
        }
      }
    }
    .table-button {
      display: flex;
      height: 65px;
      align-items: center;
      div {
        margin-right: 16px;
      }
    }
  }
  .footer {
    height: 60px;
    background-color: lightgrey;
    padding: 0 16px;
    align-items: center;
    display: flex;
    justify-content: space-between;
    .align-right {
      display: flex;
      div {
        margin-left: 16px;
      }
    }
  }
}
</style>