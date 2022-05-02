<template>
  <div class="component-wrapper">
    <div class="header">
      <div class="align-left">
        <div class="tilte">Đánh giá lại tài sản</div>
      </div>
      <div class="align-right">
        <div class="btn-help">Hướng dẫn</div>
        <BaseButton class="active" @click="$emit('toggleShowDetail')"
          >Thêm đánh giá lại</BaseButton
        >
        <div class="btn icon-refresh features-pane-item" title="Tải lại"></div>
      </div>
    </div>
    <div class="content">
      <div class="table-container">
        <div class="table-content">
          <table>
            <colgroup>
              <col width="50" />
              <col width="150" />
              <col width="150" />
              <col min-width="800" />
              <col width="150" />
              <col width="130" />
            </colgroup>
            <thead>
              <tr>
                <th>
                  <div class="checkbox-icon" style="width: 16px">
                    <input class="checkboxAll1" type="checkbox" />
                  </div>
                </th>
                <th>Biên bản số</th>
                <th>Ngày lập</th>
                <th>Lý do</th>
                <th>Thời gian chỉnh sửa</th>
                <th class="text-center">Chức năng</th>
              </tr>
            </thead>

            <tbody>
              <tr
                v-for="item in evaluateReports"
                :key="item.bienBanDanhGiaTaiSanId"
              >
                <td>
                  <div class="checkbox-icon" style="width: 16px">
                    <input class="checkboxAll1" type="checkbox" />
                  </div>
                </td>
                <td class="text-active">{{ item.sobienban }}</td>
                <td>{{ formatDate(item.ngaylap) }}</td>
                <td>{{ item.lydo }}</td>
                <td>{{ formatDate(item.modifiedDate) }}</td>

                <td class="column-buttons">
                  <div class="btn-container">
                    <div
                      class="icon icon-view-details"
                      title="Chi tiết"
                      @click="showDetail(item.bienBanDanhGiaTaiSanId)"
                    ></div>
                    <div
                      class="icon icon-edit-pen"
                      title="Sửa"
                      @click="editDetail(item.bienBanDanhGiaTaiSanId)"
                    ></div>
                    <div
                      @click="deleteReport(item.bienBanDanhGiaTaiSanId)"
                      class="icon icon-trash-table"
                      title="Xóa"
                    ></div>
                  </div>
                </td>
              </tr>
            </tbody>
          </table>
        </div>
        <div class="table-pagination">
          <div class="record-count">
            Tổng số bản ghi: {{ evaluateReports.length }}
          </div>

          <div class="paging-toolbar">
            <div title="Trang đầu" class="p-button first-page"></div>
            <div title="Trang trước" class="p-button prev-page"></div>
            <div>Trang</div>
            <input type="number" value="1" class="text-pagebumber" />
            <div>Trên 1</div>

            <div title="Trang sau" class="p-button next-page"></div>
            <div title="Trang cuối" class="p-button last-page"></div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import BaseButton from "@/views/evaluate/base/BaseButton.vue";
import { mapState } from "vuex";
import axios from "axios";
import * as moment from "moment";

export default {
  components: {
    BaseButton,
  },
  computed: {
    ...mapState({
      evaluateState: (state) => state.evaluate.evaluateState,
      evaluateReports: (state) => state.evaluate.evaluateReports,
    }),
  },
  methods: {
    formatDate(input) {
      return moment(input).format("DD-MM-YYYY");
      // return moment().format('MMMM Do YYYY, h:mm:ss a');;
      // return input;
    },
    async deleteReport(id) {
      try {
        var res = await axios.delete(
          "https://localhost:44382/api/v1/bienbandanhgiataisans/" + id
        );
        if (!res.data.isSuccess) {
          console.error("Unable to delete: " + id);
          throw "Xóa không thành công";
        }
        this.$toast.success("Xóa thành công");
      } catch {
        this.$toast.error("Xóa không thành công");
      } finally {
        this.$store.dispatch("evaluate/getReports");
      }
    },
    /**
     * Xem chi tiet bao cao
     */
    async showDetail(id) {
      try {
        await this.$store.dispatch("evaluate/getSelectedReport", id);
        this.$emit("toggleShowDetail");
        this.$store.commit("evaluate/SET_DISABLE_DETAIL", true);
      } catch (ex) {
        this.$toast.error("Lấy dữ liệu thất bại");
        console.error(ex);
      }
    },
    async editDetail(id) {
      try {
        await this.$store.dispatch("evaluate/getSelectedReport", id);
        this.$emit("toggleShowDetail");
      } catch (ex) {
        this.$toast.error("Lấy dữ liệu thất bại");
        console.error(ex);
      }
    },
  },
  watch: {
    isShow(newVal) {
      if (newVal) {
        this.$store.commit("evaluate/SET_DISABLE_DETAIL", false);
      }
    },
  },
  props: {
    isShow: Boolean,
  },
};
</script>
<style lang="scss" scoped>
@import "@/style/_variables.scss";
.component-wrapper {
  height: calc(100% - 40px);
  padding: 32px 0px 10px 16px;

  .header {
    height: 36px;
    display: flex;
    justify-content: space-between;
    margin-bottom: 24px;
    line-height: 36px;

    .align-left {
      font-family: "GoogleSans-Medium";
      font-size: 1.3rem;
    }

    .align-right {
      display: flex;
      align-content: center;
      div {
        margin: 0 8px;
      }
    }
  }
  .content {
    height: 100%;
    .table-container {
      height: calc(100% - 161px);
      .table-content {
        height: 100%;
        overflow: auto;
        border: solid 1px #eaeaea;
        border-right: 0;
        margin-bottom: 10px;

        .checkbox-icon {
          display: flex;
          align-items: center;
          justify-content: center;
        }
        .text-active {
          color: $sub-primary;
          cursor: pointer;
        }
        thead {
          text-align: left;

          .text-center {
            text-align: center;
          }
        }

        tbody {
          .column-buttons {
            .btn-container {
              display: flex;
              align-items: center;
              justify-content: space-evenly;
              .icon {
                width: 18px;
                height: 18px;
                cursor: pointer;
              }
            }
          }
        }
        // tr {
        //   // border: 1px solid #d0cece;
        // }
      }
      .table-pagination {
        position: relative;
        height: 60px;
        .record-count {
          position: absolute;
          top: 10px;
          left: 0;
          font-family: "GOOGLESANS-BOLD";
        }

        .paging-toolbar {
          height: 100%;
          display: flex;
          justify-content: center;
          padding-top: 10px;
          div {
            margin: 0 8px;
          }
          .p-button {
            height: 24px;
            width: 24px;
            border: 1px solid #d0d0d0;
            border-radius: 3px;
            background-color: #fff;
            margin-right: 2px;
          }
          .first-page {
            background: url(~@/assets/icon/common-icon.png) no-repeat -649px -124px;
            width: 24px;
            height: 24px;
            background-color: #fff;
            border-radius: 3px;
            cursor: pointer;
          }

          .text-pagebumber,
          .select-quantitypage {
            border-radius: 3px;
            text-align: center;
          }

          .text-pagebumber {
            width: 36px;
            height: 16px;
            padding: 4px 6px;
            border: 1px solid #d0d0d0;
            box-sizing: border-box;
            height: 24px;
          }

          .refresh {
            background: url(~@/assets/icon/common-icon.png) no-repeat -849px -124px;
            border: 1px solid #6b6f9d !important;
          }
          .last-page {
            background: url(~@/assets/icon/common-icon.png) no-repeat -798px -124px;
          }
          .next-page {
            background: url(~@/assets/icon/common-icon.png) no-repeat -749px -124px;
          }

          .select-quantitypage {
            width: 46px;
            height: 26px;
            border: 1px solid #d0d0d0;
            outline: none !important;
          }
        }
      }
    }
  }
}
</style>