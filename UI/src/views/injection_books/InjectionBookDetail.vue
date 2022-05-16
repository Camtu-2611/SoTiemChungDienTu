<template>
  <div class="modal-register">
    <div class="modal-content">
      <div class="header">
        <div v-if="formMode == 'insert'" class="title">Thêm sổ tiêm</div>
        <div v-else class="title">Chi tiết sổ tiêm {{ maSoTiem }}</div>

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
        <v-card>
          <v-tabs v-model="tab" background-color="" left icons-and-text>
            <v-tabs-slider></v-tabs-slider>

            <v-tab href="#tab-1">
              Thông tin sổ tiêm
              <v-icon>mdi-account-box</v-icon>
            </v-tab>

            <v-tab href="#tab-2">
              Danh sách đăng ký tiêm
              <v-icon>mdi-format-list-checkbox</v-icon>
            </v-tab>

            <v-tab href="#tab-3">
              Lịch sử tiêm chủng
              <v-icon>mdi-clipboard-text-clock</v-icon>
            </v-tab>
          </v-tabs>
          <v-tabs-items v-model="tab">
            <!-- Tab thông tin sổ tiêm -->
            <v-tab-item value="tab-1">
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
                        v-model="ttSoTiem.masotiem"
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
                        v-model="ttSoTiem.hoten"
                        :class="{ 'class-error': !validation.hotenVal }"
                        :title="validation.hotenValMsg"
                        @blur="
                          tabValidate('hoten', 'Họ tên không được để trống.')
                        "
                        @tab="
                          tabValidate('hoten', 'Họ tên không được để trống.')
                        "
                      />
                    </div>
                    <div
                      class="col-12 col-sm-6 py-2 wow fadeInLeft"
                      data-wow-delay="300ms"
                    >
                      <label for="date"
                        >Ngày sinh <span style="color: #ff0000">*</span></label
                      >
                      <input
                        type="date"
                        class="form-control"
                        v-model="ttSoTiem.ngaysinh"
                        :class="{ 'class-error': !validation.ngaysinhVal }"
                        :title="validation.ngaysinhValMsg"
                        @blur="
                          tabValidate(
                            'ngaysinh',
                            'Ngày sinh không được để trống.'
                          )
                        "
                        @tab="
                          tabValidate(
                            'ngaysinh',
                            'Ngày sinh không được để trống.'
                          )
                        "
                      />
                    </div>
                    <div
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
                    </div>

                    <div
                      class="col-12 col-sm-6 py-2 wow fadeInLeft"
                      data-wow-delay="300ms"
                    >
                      <label for="SDT"
                        >Số điện thoại <span style="color: #ff0000">*</span>
                      </label>
                      <input
                        type="text"
                        id="SDT"
                        class="form-control"
                        v-model="ttSoTiem.sodienthoai"
                        :disabled="formMode == 'update'"
                        :readonly="formMode == 'update'"
                        :class="{ 'class-error': !validation.sdtVal }"
                        :title="validation.sdtValMsg"
                        @blur="
                          tabValidate(
                            'SDT',
                            'Số điện thoại không được để trống.'
                          )
                        "
                        @tab="
                          tabValidate(
                            'SDT',
                            'Số điện thoại không được để trống.'
                          )
                        "
                      />
                    </div>
                    <div class="col-sm-6 py-2 wow fadeInRight">
                      <label for="emailAddress"
                        >Email <span style="color: #ff0000">*</span></label
                      >
                      <input
                        type="email"
                        id="emailAddress"
                        class="form-control"
                        placeholder="Nhập địa chỉ email"
                        v-model="ttSoTiem.email"
                      />
                    </div>
                    <div
                      class="col-12 col-sm-6 py-2 wow fadeInLeft"
                      data-wow-delay="300ms"
                    >
                      <label for="CMND"
                        >CMND/CCCD <span style="color: #ff0000">*</span>
                      </label>
                      <input
                        type="text"
                        id="cmnd"
                        class="form-control"
                        v-model="ttSoTiem.cmnd"
                        :class="{ 'class-error': !validation.cmndVal }"
                        :title="validation.cmndValMsg"
                        @blur="
                          tabValidate('cmnd', 'CMND/CCCD không được để trống.')
                        "
                        @tab="
                          tabValidate('cmd', 'CMND/CCCD không được để trống.')
                        "
                      />
                    </div>

                    <div class="col-sm-6 py-2 wow fadeInRight">
                      <label for="diachi">Địa chỉ</label>
                      <input
                        type="text"
                        id="diachi"
                        class="form-control"
                        placeholder="Địa chỉ.."
                        v-model="ttSoTiem.diachi"
                      />
                    </div>
                  </div>
                </form>
                <div class="footer">
                  <v-button
                    class="btn btn-primary align-center"
                    color="primary"
                    @click="insertRecord()"
                    v-if="formMode == 'insert'"
                  >
                    Lưu</v-button
                  >
                  <v-button
                    class="btn btn-primary align-center"
                    color="primary"
                    @click="updateRecord()"
                    v-else
                    >Cập nhật</v-button
                  >
                  <v-button text class="btn ml-2 align-center" @click="hide()">
                    Hủy</v-button
                  >
                </div>
              </div>
            </v-tab-item>
            <v-tab-item value="tab-2">
              <DSDangKyTiem :maSoTiem="ttSoTiem.masotiem"
            /></v-tab-item>
            <v-tab-item value="tab-3">
              <LichSuTiemChung :maSoTiem="ttSoTiem.masotiem" />
            </v-tab-item>
          </v-tabs-items>
        </v-card>
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
import LichSuTiemChung from "../LichSuTiemChung.vue";
import DSDangKyTiem from "./DSDangKyTiem.vue";
import BaseConfirm from "@/components/common/baseControlAcounting/BaseConfirm";
export default {
  components: {
    BaseConfirm,
    LichSuTiemChung,
    DSDangKyTiem,
  },
  props: {
    formMode: String,
    idSoTiemUpdate: String,
    maSoTiem: String,
  },
  data() {
    return {
      tab: null,
      lstMaSoTiem: [],
      ttSoTiem: {},
      showSuccess: false,
      showWarning: false,
      alertMsg: "",
      ttDefault: {
        masotiem: "",
        hoten: "",
        ngaysinh: "",
        gioitinh: "",
        sodienthoai: "",
        email: "",
        cmnd: "",
        diachi: "",
        nguoitao: "nctu",
        ngaytao: new Date().toISOString(),
        nguoichinhsua: "nctu",
        ngaychinhsua: new Date().toISOString(),
      },
      validation: {
        ngaysinhVal: true,
        ngaysinhValMsg: "",
        sdtVal: true,
        sdtValMsg: "",
        hotenVal: true,
        hotenValMsg: "",
        cmndVal: true,
        cmndValMsg: "",
        emailVal: true,
        emailValMsg: "",
      },
      maSoTiemMoi: "",
    };
  },
  created() {
    this.show();
  },
  methods: {
    /**
     * Thực hiện lấy toàn bộ bản ghi của sổ tiêm
     * */
    async getSoTiemByCode() {
      try {
        await axios
          .get(
            `http://localhost:64016/api/SoTiem/bycode/${this.ttSoTiem.masotiem}`
          )
          .then((response) => {
            if (response.data) {
              var res = response.data.data;
              if (res) {
                this.ttSoTiem.hoten = res.hoten;
                this.ttSoTiem.ngaysinh = res.ngaysinh;
                this.ttSoTiem.ngaysinh = this.formatDate(
                  this.ttSoTiem.ngaysinh
                );
                this.ttSoTiem.gioitinh = res.gioitinh;
                this.ttSoTiem.email = res.email;
                this.ttSoTiem.sodienthoai = res.sodienthoai;
                this.ttSoTiem.diachi = res.diachi;
                console.log(this.ttSoTiem.hoten + "3");
              }
            }
          })
          .catch(() => {});
      } catch (error) {
        console.log(error);
      }
    },

    /**
     * Thực hiện thêm mới bản ghi
     * */
    async insertRecord() {
      try {
        if (this.validateData()) {
          if (this.formMode == "insert") {
            await axios
              .post("http://localhost:64016/api/SoTiem", this.ttSoTiem)
              .then(() => {
                this.$refs.baseConfirm.showForm(
                  "sucess",
                  1,
                  "Thêm mới sổ tiêm thành công !"
                );
                this.$router.push({ name: "injection-books" });
              })
              .catch((error) => {
                this.showWarning = true;
                this.alertMsg = "Có lỗi xảy ra! Thêm mới thất bại";
                setTimeout(() => {
                  this.showWarning = false;
                }, 1000);
              });
          } else {
          }
        } else {
          return;
        }
      } catch (error) {
        console.log(error);
      }
    },

    async updateRecord() {
      try {
        if (this.validateData()) {
          if (this.formMode == "update") {
            await axios
              .put(
                `http://localhost:64016/api/SoTiem/${this.idSoTiemUpdate}`,
                this.ttSoTiem
              )
              .then(() => {
                this.$refs.baseConfirm.showForm(
                  "sucess",
                  1,
                  "Cập nhật thành công !"
                );
                this.$router.push({ name: "injection-books" });
              })
              .catch((error) => {
                this.showWarning = true;
                this.alertMsg = "Cập nhật thất bại";
                setTimeout(() => {
                  this.showWarning = false;
                }, 1000);
              });
          } else {
          }
        } else {
          return;
        }
      } catch (error) {}
    },

    // todo hiện dialog
    async show() {
      var me = this;
      this.isActive = true;
      this.dup = false;
      console.log(this.formMode + " " + this.idSoTiemUpdate);
      if (this.formMode == "update") {
        await axios
          .get("http://localhost:64016/api/SoTiem/" + this.idSoTiemUpdate)
          .then((response) => {
            if (response.data) {
              var res = response.data.data;
              if (res) {
                this.disableMasotiem = true;
                me.ttSoTiem = res;
                me.ttSoTiem.ngaysinh = this.formatDate(me.ttSoTiem.ngaysinh);
              }
            }
          })
          .catch((error) => {
            this.errorMessage = error.message;
            console.error("GET TTDKT by id Failed: ", error.message);
          });
      } else {
        await axios
          .get(`http://localhost:64016/api/SoTiem/generateCode/`)
          .then((response) => {
            if (response.data) {
              var res = response.data.data;
              if (res) {
                this.ttDefault.masotiem = res;
                console.log(this.ttDefault);
                this.ttSoTiem = this.ttDefault;
                console.log(this.ttSoTiem.masotiem);
              } else {
                this.ttSoTiem.masotiem = "ST0001";
              }
            }
          })
          .catch((error) => {
            this.errorMessage = error.message;
            console.error("Generate ma SoTiem Failed: ", error.message);
          });
      }
    },

    // todo reset lại các input
    resetInput() {
      (this.ttSoTiem.masotiem = ""),
        (this.ttSoTiem.hoten = ""),
        (this.ttSoTiem.ngaysinh = ""),
        (this.ttSoTiem.gioitinh = ""),
        (this.ttSoTiem.sodienthoai = ""),
        (this.ttSoTiem.email = ""),
        (this.ttSoTiem.cmnd = ""),
        (this.ttSoTiem.diachi = ""),
        (this.ttSoTiem.nguoitao = ""),
        (this.ttSoTiem.ngaytao = new Date().toISOString()),
        (this.ttSoTiem.nguoichinhsua = ""),
        (this.ttSoTiem.ngaychinhsua = new Date().toISOString());
    },

    // todo ẩn dialog
    hide() {
      this.isActive = false;
      this.$router.push({ name: "injection-books" });
    },

    /**
     * Thực hiện validate input bị trống
     * CreatedBy: nctu2
     * */
    tabValidate(id, message) {
      if (id == "ngaysinh") {
        console.log("ngaysinh");
        if (!this.ttSoTiem.ngaysinh) {
          this.validation.ngaysinhVal = false;
          this.ngaysinhValMsg = message;
        } else {
          this.validation.ngaysinhVal = true;
        }
      } else if (id == "hoten") {
        if (!this.ttSoTiem.hoten) {
          this.validation.hotenVal = false;
          this.hotenValMsg = message;
        } else {
          this.validation.hotenVal = true;
        }
      } else if (id == "SDT") {
        if (!this.ttSoTiem.sodienthoai) {
          this.validation.sdtVal = false;
          this.sdtValMsg = message;
        } else {
          this.validation.sdtVal = true;
        }
      } else if (id == "cmnd") {
        if (!this.ttSoTiem.cmnd) {
          this.validation.cmndVal = false;
          this.cmndValMsg = message;
        } else {
          this.validation.cmndVal = true;
        }
      }
    },

    /**
     * Thực hiện validate Họ tên không được bỏ trống
     * CreatedBy: nctu
     * */
    validateHoTen() {
      if (!this.ttSoTiem.hoten) {
        this.$refs.baseConfirm.showForm(
          "error",
          1,
          "Họ tên không được để trống"
        );
        return false;
      } else {
        return true;
      }
    },
    /**
     * Thực hiện validate SĐT không được bỏ trống
     * CreatedBy: nctu
     * */
    validateSoDienThoai() {
      if (!this.ttSoTiem.sodienthoai) {
        this.$refs.baseConfirm.showForm(
          "error",
          1,
          "Số điện thoại không được để trống"
        );
        return false;
      } else {
        return true;
      }
    },
    /**
     * Thực hiện validate ngày sinh không được bỏ trống
     * CreatedBy: nctu
     * */
    validateNgaySinh() {
      if (!this.ttSoTiem.ngaysinh) {
        this.$refs.baseConfirm.showForm(
          "error",
          1,
          "Ngày sinh không được để trống"
        );
        return false;
      } else {
        return true;
      }
    },

    /**
     * Thực hiện validate ngày sinh không được bỏ trống
     * CreatedBy: nctu
     * */
    validateCMND() {
      if (!this.ttSoTiem.cmnd) {
        this.$refs.baseConfirm.showForm(
          "error",
          1,
          "CMND/CCCD không được để trống"
        );
        return false;
      } else {
        return true;
      }
    },
    /**
     * Thực hiện validate email không đúng định dạng
     * CreatedBy: nctu
     * */
    validateEmail() {
      var emailval = String(this.ttSoTiem.email)
        .toLowerCase()
        .match(
          /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
        );
      if (!emailval) {
        this.$refs.baseConfirm.showForm(
          "error",
          1,
          "Email không đúng định dạng"
        );
        return false;
      } else {
        return true;
      }
    },
    validateData() {
      if (
        this.validateHoTen() &&
        this.validateSoDienThoai() &&
        this.validateCMND() &&
        this.validateNgaySinh() &&
        this.validateEmail()
      ) {
        return true;
      } else return false;
    },

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
  },
};
</script>

<style lang="scss" scoped>
.modal-register {
  width: 100%;
  height: 100%;
  font-size: 14px;
}
.class-error {
  border-color: #ff0000 !important;
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

.test-autocomplete {
  border: 1px solid black;
}

.modal-register .validate-warning {
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
    padding: 0 6px;
    box-sizing: border-box;
    display: flex;
    align-items: center;

    .title {
      line-height: 30px;
      font-family: GoogleSans-Bold;
      font-size: 16px;
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
    height: 100%;
    // padding: 6px 6px 6px 6px;
    box-sizing: border-box;
    overflow-y: auto;
    overflow-x: hidden;
    .v-sheet.v-card {
      height: 100%;
      ::v-deep .v-window {
        height: calc(100% - 72px);
        .v-window__container {
          padding: 0;
          height: 100%;
        }
        .v-window-item {
          height: 100%;
        }
      }
    }
    .v-sheet.v-card:not(.v-sheet--outlined) {
      box-shadow: none;
    }

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
        padding: 4px;
      }
    }
  }
  .content-grid {
    margin: 8px;
    height: calc(100% - 149px);
    position: relative;
    overflow: auto;
    box-sizing: border-box;
  }
  .v-sheet.v-alert {
    position: absolute;
    z-index: 2;
    right: 0px;

    animation-name: alert;
    width: 220px;
    animation-duration: 3s;
    white-space: nowrap;
    padding: 16px 0px;
    bottom: 0px;
  }

  @keyframes alert {
    0% {
      width: 220px;
      padding: 16px;
    }
    50% {
      width: 220px;
      padding: 16px;
    }
    100% {
      width: 0px;
      padding: 16px 0px;
    }
  }
  .not-active {
    display: none;
  }

  .features-box {
    display: flex;
    align-items: center;
    visibility: hidden;
    .table-icon {
      width: 15px;
      height: 15px;
      margin: 0 4px;
      &:hover {
        cursor: pointer;
      }
    }
  }

  .table-summary {
    font-size: 14px;
    font-family: GoogleSans-Medium;
    display: flex;
    position: relative;
    margin: 18px 16px 0 16px;
    height: 45px;
    margin: 0 8px;

    .price-number {
      position: absolute;
      //TODO sẽ phải sửa lại cái này cho chuẩn với cột nguyên giá
      right: 120px;
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
</style>
