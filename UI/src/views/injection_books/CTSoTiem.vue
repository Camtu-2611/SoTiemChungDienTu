<template>
  <div class="history">
    <div class="modal-content">
      <div class="header">
        <div v-if="formMode == 'insert'" class="title">Chi tiết mũi tiêm</div>

        <div class="header-right">
          <div class="icon-help btn btn-help" title="Hỗ trợ"></div>
          <div
            class="icon-cancel btn btn-close"
            title="Đóng"
            @click="hide()"
          ></div>
        </div>
      </div>

      <div class="content">
        <div class="container-fluid">
          <form class="contact-form mt-5">
            <div class="row mb-3">
              <div class="col-sm-6 py-2 wow fadeInLeft">
                <label for="masotiem"
                  >Mã sổ tiêm <span style="color: #ff0000">*</span>
                </label>
                <input
                  type="text"
                  id="masotiem"
                  class="form-control"
                  placeholder=""
                  :disabled="disableMasotiem"
                  v-model="thongtinCTSoTiem.masotiem"
                  readonly
                />
              </div>
              <div class="col-sm-6 py-2 wow fadeInRight">
                <label for="hoten"
                  >Họ tên <span style="color: #ff0000">*</span>
                </label>
                <input
                  type="text"
                  id="hoten"
                  class="form-control"
                  placeholder="Họ tên.."
                  v-model="thongtinCTSoTiem.hoten"
                  :class="{ 'class-error': !validation.hotenVal }"
                  :title="validation.hotenValMsg"
                  @blur="tabValidate('hoten', 'Họ tên không được để trống.')"
                  @tab="tabValidate('hoten', 'Họ tên không được để trống.')"
                  readonly
                  disabled
                />
              </div>
              <!-- <div
                class="col-12 col-sm-6 py-2 wow fadeInRight"
                data-wow-delay="300ms"
              >
                <label for="sex"
                  >Giới tính <span style="color: #ff0000">*</span></label
                >
                <select
                  name="sex"
                  id="sex"
                  class="custom-select"
                  v-model="ttSoTiem.gioitinh"
                >
                  <option value="1">Nam</option>
                  <option value="2">Nữ</option>
                  <option value="0">Khác</option>
                </select>
              </div> -->
              <!-- <div class="col-sm-3 py-2 wow fadeInRight">
                <label for="mavacxin"
                  >Mã vắc xin<span style="color: #ff0000">*</span></label
                >
                <input
                  type="mavacxin"
                  id="mavacxin"
                  class="form-control"
                  placeholder=""
                  v-model="thongtinCTSoTiem.mavacxin"
                />
              </div> -->
              <div
                class="col-12 col-sm-6 py-2 wow fadeInLeft"
                data-wow-delay="300ms"
              >
                <label for="vacxin"
                  >Tên vắc xin<span style="color: #ff0000">*</span>
                </label>
                <input
                  type="text"
                  id="vacxin"
                  class="form-control"
                  v-model="thongtinCTSoTiem.tenvacxin"
                  disabled
                />
              </div>

              <div class="col-sm-3 py-2 wow fadeInRight">
                <label for="lantiem"
                  >Mũi tiêm <span style="color: #ff0000">*</span></label
                >
                <input
                  type="lantiem"
                  id="lantiem"
                  class="form-control"
                  placeholder=""
                  v-model="thongtinCTSoTiem.lantiem"
                />
              </div>
              <div
                class="col-3 col-sm-3 py-2 wow fadeInLeft"
                data-wow-delay="300ms"
              >
                <label for="date"
                  >Ngày tiêm <span style="color: #ff0000">*</span></label
                >
                <input
                  type="date"
                  class="form-control"
                  v-model="thongtinCTSoTiem.ngaytiem"
                  :class="{ 'class-error': !validation.ngaysinhVal }"
                  :title="validation.ngaysinhValMsg"
                  @blur="
                    tabValidate('ngaysinh', 'Ngày tiêm không được để trống.')
                  "
                  @tab="
                    tabValidate('ngaysinh', 'Ngày tiêm không được để trống.')
                  "
                />
              </div>
              <div class="col-sm-6 py-2 wow fadeInRight">
                <label for="phanung">Phản ứng sau tiêm</label>
                <input
                  type="text"
                  id="phanung"
                  class="form-control"
                  placeholder=""
                  v-model="thongtinCTSoTiem.phanungsautiem"
                />
              </div>
              <div
                class="col-12 col-sm-6 py-2 wow fadeInLeft"
                data-wow-delay="300ms"
              >
                <label for="date">Ngày hẹn tiêm mũi sau (nếu có)</label>
                <input
                  type="date"
                  class="form-control"
                  v-model="thongtinCTSoTiem.ngayhen"
                />
              </div>

              <div class="col-sm-6 py-2 wow fadeInRight">
                <label for="diachi">Nơi tiêm</label>
                <input
                  type="text"
                  id="diachi"
                  class="form-control"
                  placeholder="Nơi tiêm"
                  v-model="thongtinCTSoTiem.noitiem"
                />
              </div>
            </div>
          </form>
          <div class="footer">
            <v-button
              class="btn btn-primary align-center"
              color="primary"
              @click="save()"
              v-if="formMode == 'insert'"
            >
              Lưu</v-button
            >
            <v-button text class="btn ml-2 align-center" @click="hide()">
              Hủy</v-button
            >
          </div>
        </div>
      </div>
      <v-alert
        id="success-dialog"
        v-show="showSuccess"
        color="green"
        elevation="30"
        type="success"
      >
        {{ alerMsg }}</v-alert
      >
      <v-alert v-if="showWarning" id="required-choose" type="error">{{
        alerMsg
      }}</v-alert>
    </div>
    <BaseConfirm ref="baseConfirm" />
  </div>
</template>

<script>
import axios from "axios";
import BaseConfirm from "@/components/common/baseControlAcounting/BaseConfirm";

export default {
  components: {
    BaseConfirm,
  },
  props: {
    formMode: String,
    CTDangKy: Object,
  },
  data() {
    return {
      showWarning: false,
      isActive: false,
      showSuccess: false,
      thongtinCTSoTiem: {
        // idctsotiem: null,
        masotiem: "",
        hoten: "",
        mavacxin: "",
        tenvacxin: "",
        lantiem: 1,
        phanungsautiem: "",
        noitiem: "",
        ngayhen: "",
        ngaytiem: "",
      },
      validation: {
        ngaysinhVal: true,
        ngaysinhValMsg: "",
        hotenVal: true,
        hotenValMsg: "",
      },
      idCTSoTiemUpdate: "",
    };
  },
  created() {
    this.show();
  },
  methods: {
    // todo reset lại các input
    resetInput() {
      //   (this.thongtinCTSoTiem.idctsotiem = null),
      (this.thongtinCTSoTiem.masotiem = this.CTDangKy.masotiem),
        (this.thongtinCTSoTiem.hoten = this.CTDangKy.hoten),
        (this.thongtinCTSoTiem.mavacxin = this.CTDangKy.danhsachvacxin),
        (this.thongtinCTSoTiem.tenvacxin = this.CTDangKy.danhsachvacxin),
        (this.thongtinCTSoTiem.lantiem = 1),
        (this.thongtinCTSoTiem.ngaytiem = this.formatDate(
          this.CTDangKy.ngaydangkytiem
        )),
        (this.thongtinCTSoTiem.phanungsautiem = ""),
        (this.thongtinCTSoTiem.noitiem = this.CTDangKy.tentrungtam),
        (this.thongtinCTSoTiem.ngayhen = null),
        (this.thongtinCTSoTiem.manhanvien = ""),
        (this.thongtinCTSoTiem.nguoitao = "nctu2"),
        (this.thongtinCTSoTiem.ngaytao = new Date().toISOString()),
        (this.thongtinCTSoTiem.nguoichinhsua = "nctu2"),
        (this.thongtinCTSoTiem.ngaychinhsua = new Date().toISOString());
    },
    // todo hiện dialog
    async show() {
      var res = this;
      this.isActive = true;
      console.log(this.formMode);
      console.log(this.CTDangKy);
      if (this.formMode == "update") {
        await axios
          .get("http://localhost:64016/api/CTSoTiem" + this.idCTSoTiemUpdate)
          .then((response) => {
            res.thongtinCTSoTiem = response.data.data;
          })
          .catch((error) => {
            this.errorMessage = error.message;
            console.error("GET ctsotiem by id Failed: ", error.message);
          });
      } else {
        this.resetInput();
      }
    },

    // todo ẩn dialog
    hide() {
      this.isActive = false;
      console.log(this.CTDangKy.iddangky);
      this.$router.push({
        name: "injection-book-detail",
        params: {
          formMode: "update",
          idSoTiemUpdate: this.CTDangKy.iddangky,
        },
      });
    },

    // todo select tất cả nội dung ô input khi click
    selectAll() {
      document.getElementsByTagName("input").forEach((element) => {
        element.addEventListener("click", () => {
          element.select();
        });
      });
    },
    // định dạng ngày
    formatDate(inputDate) {
      var a = new Date(inputDate);
      console.log(inputDate);
      var month = a.getMonth() + 1;
      var day = a.getDate();
      if (month < 10) month = "0" + month.toString();
      if (day < 10) day = "0" + day.toString();
      var date = a.getFullYear().toString() + "-" + month + "-" + day;
      return date;
    },
    // todo chỉ cho phép nhập số
    formatNumber(e) {
      var key = e.key;
      if (!/^\d+/g.test(key)) {
        e.preventDefault();
      }
    },

    //todo định dạng kiểu tiền tệ
    formatMoney(money) {
      return money.replace(/\B(?=(\d{3})+(?!\d))/g, `.`);
    },
    /**
     * ẩn hết những ngày sau ngày hiện tại
     * CreatedBy: TVHIEN (13/04/2021)
     */
    disabledAfterToday(date) {
      const today = new Date();
      today.setHours(0, 0, 0, 0);
      return date > today;
    },

    // todo bỏ định dạng tiền tệ
    removeFormatMoney(money) {
      return money.replace(/\D+/g, "");
    },

    //todo chuyển số thành chuỗi
    numberToString(input) {
      if (input == null) return "";
      else return input.toString();
    },

    // todo chuyển chuỗi thành số
    stringToNumber(input) {
      if (input == "" || input == "0") return null;
      else return parseInt(input);
    },

    // todo lưu dữ liệu
    async save() {
      if (
        !this.thongtinCTSoTiem.masotiem ||
        !this.thongtinCTSoTiem.mavacxin ||
        !this.thongtinCTSoTiem.lantiem ||
        !this.thongtinCTSoTiem.hoten ||
        !this.thongtinCTSoTiem.tenvacxin
      ) {
        this.$refs.baseConfirm.showForm(
          "error",
          1,
          "Bạn đang bỏ trống các trường bắt buộc"
        );
        return;
      } else {
        if (this.formMode == "insert") {
          await axios
            .post(`http://localhost:64016/api/CTSoTiem/`, this.thongtinCTSoTiem)
            .then(() => {
              this.$refs.baseConfirm.showForm(
                "success",
                1,
                "Cập nhật thành công !"
              );
            })
            .catch(() => {});
            //  console.log(this.CTDangKy.iddangky);
            //   this.$router.push({
            //     name: "injection-books",
            //   });
        } else if (this.formMode == "update") {
          await axios
            .put(
              `http://localhost:64016/api/CTSoTiem/${this.idCTSoTiemUpdate}`,
              this.thongtinCTSoTiem
            )
            .then(() => {
              this.$refs.baseConfirm.showForm(
                "success",
                1,
                "Cập nhật thành công !"
              );
            })
            .catch(() => {});
        }
      }
    },

    showWarning(text) {
      this.$emit("msgAlert", text, true);
    },
    checkPostedDate() {
      this.$emit("reload", false);
    },
  },
  watch: {},
  computed: {
    // todo nhận được kiểu định dạng tiền tệ khi nguyên giá thay đổi
    formatedMoney() {
      return this.formatMoney(this.numberToString(this.asset.originalPrice));
    },
    formatedWearValue() {
      return this.formatMoney(this.numberToString(this.asset.wearValue));
    },
  },
  filters: {},
  mounted() {
    //this.selectAll();
  },
};
</script>

<style lang="scss" scoped>
.history {
  width: 100%;
  height: 100%;
  font-size: 14px;
}
.history .validate-warning {
  font-family: GoogleSans-Regular;
  font-size: 13px;
  color: red;
  background-color: white;
  /* z-index: 22; */
  position: absolute;
}
input {
  padding: 8px 16px;
  outline: none;
  border: #beccc9 1px solid;
}

input.required {
  border: red 1px solid !important;
}

.input-search {
  width: 200px;
  padding: 8px 46px 8px 16px;
  border: 1px solid #beccc9;
}

.input-field .input-black {
  background-color: #f5f5f5;
  pointer-events: none;
}

.input-field .input-two-third {
  width: 437px;
}

.input-field .input-one-third {
  width: 210px;
}

.custom-autocomplete input {
  border: none;
  padding-left: 10px;
  font-size: 14px;
}

.v-text-field > .v-input__control > .v-input__slot:before {
  border-style: none;
}

.v-input {
  padding-top: 0px;
  margin-top: 0px;
}

.v-text-field__details {
  display: none;
}

.v-input__slot {
  margin-bottom: 0px;
}

.v-list-item__content .v-list-item__title {
  font-size: 14px;
}

// ::-webkit-scrollbar {
//   width: 8px;
//   height: 8px;
//  }

.test-autocomplete {
  border: 1px solid black;
}
.modal {
  position: fixed;
  top: 0;
  left: 0;
  bottom: 0;
  right: 0;
  z-index: 1000;
  font-size: 14px;
}

.modal .modal-background {
  position: absolute;
  width: 100%;
  height: 100%;
  background-color: black;
  opacity: 0.5;
}

.modal .validate-warning {
  font-family: GoogleSans-Regular;
  font-size: 13px;
  color: red;
  background-color: white;
  /* z-index: 22; */
  position: absolute;
}

.modal-content {
  width: 100%;
  height: 100%;
  background-color: white;
  resize: both;
  overflow: auto;
  min-height: 530px;
  min-width: 705px;

  .header {
    width: 100%;
    height: 60px;
    display: flex;
    padding: 0 16px;
    box-sizing: border-box;
    display: flex;
    align-items: center;

    .title {
      line-height: 50px;
      font-family: GoogleSans-Bold;
      font-size: 20px;
    }

    .header-right {
      position: absolute;
      right: 0;
      display: flex;
      align-items: center;
      padding: 0 12px;

      .icon-cancel {
        background-size: 16px;
        margin-left: 2px;
      }
    }
  }

  .content {
    width: 100%;
    height: calc(100% - 110px);
    padding: 16px 0px 16px 16px;
    box-sizing: border-box;
    overflow-y: auto;
    overflow-x: hidden;

    .input-field {
      float: left;
      padding: 0 16px 16px 0px;
      position: relative;
      height: 77px;

      label {
        display: block;
        padding: 2px 2px 4px 2px;
      }

      input {
        height: 34px;
        box-sizing: border-box;
        border: #e4e4e4 1px solid;
        // outline-color: lightgreen;
        padding: 10px;
      }
    }
  }

  .footer {
    width: 100%;
    height: 50px;
    display: flex;
    align-items: center;
    position: absolute;
    padding: 10px;
    bottom: 30px;
    right: 20px;
    justify-content: end;
  }
}

.validate-warning {
  display: none;
  position: absolute;
  font-style: italic;
  padding-right: 0;
}
.hover-validate:hover ~ .validate-warning {
  display: block;
}
.modal-content .header .title {
  font-family: GoogleSans-Bold !important;
}
.borderRed {
  border: 1px solid red !important;
}

#assetInput5 {
  text-align: right;
}
#assetInput6 {
  text-align: right;
}

// @import url("../style/scss/common.scss");
// @import url("../style/scss/icon.scss");
// @import url("../style/scss/button.scss");
// @import url("../style/scss/combobox.scss");
// @import url("../style/scss/table.scss");
//  @import url("../style/scss/date_picker.scss");
</style>
