<template>
  <div class="modal-register">
    <div class="modal-content">
      <div class="header">
        <div v-if="formMode == 'insert'" class="title">Thêm vắc xin</div>
        <div v-else class="title">Chi tiết vắc xin {{ maVacxin }}</div>

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
                  >Mã vắc xin <span style="color: #ff0000">*</span>
                </label>
                <input
                  type="text"
                  id="masotiem"
                  class="form-control"
                  placeholder="Mã vắc xin.."
                  v-model="ttVacxin.mavacxin"
                  :class="{ 'class-error': !validation.mavacxinVal }"
                  :title="validation.mavacxinValMsg"
                  @blur="
                    tabValidate('mavacxin', 'Mã vắc xin không được để trống.')
                  "
                  @tab="
                    tabValidate('mavacxin', 'Mã vắc xin không được để trống.')
                  "
                />
              </div>
              <div class="col-sm-6 py-2 wow fadeInRight">
                <label for="hoten"
                  >Tên vắc xin <span style="color: #ff0000">*</span>
                </label>
                <input
                  type="text"
                  id="hoten"
                  class="form-control"
                  placeholder="Tên vắc xin.."
                  v-model="ttVacxin.tenvacxin"
                  :class="{ 'class-error': !validation.tenvacxinVal }"
                  :title="validation.tenvacxinValMsg"
                  @blur="
                    tabValidate('tenvacxin', 'Tên vắc xin không được để trống.')
                  "
                  @tab="
                    tabValidate('tenvacxin', 'Tên vắc xin không được để trống.')
                  "
                />
              </div>
              <div
                class="col-6 col-sm-3 py-2 wow fadeInLeft"
                data-wow-delay="300ms"
              >
                <label for="solo"
                  >Số lô <span style="color: #ff0000">*</span></label
                >
                <input
                  type="text"
                  class="form-control"
                  v-model="ttVacxin.solo"
                  placeholder="Số lô.."
                  :class="{ 'class-error': !validation.soloVal }"
                  :title="validation.soloValMsg"
                  @blur="
                    tabValidate('solo', 'Số lô vắc xin không được để trống.')
                  "
                  @tab="tabValidate('solo', 'Số lô không được để trống.')"
                />
              </div>

              <div
                class="col-3 col-sm-3 py-2 wow fadeInLeft"
                data-wow-delay="300ms"
              >
                <label for="soluong"
                  >Số lượng <span style="color: #ff0000">*</span>
                </label>
                <input
                  type="text"
                  id="soluong"
                  class="form-control"
                  placeholder="Số lượng.."
                  v-model="ttVacxin.soluong"
                  :class="{ 'class-error': !validation.soluongVal }"
                  :title="validation.soluongValMsg"
                  @blur="
                    tabValidate('soluong', 'Số lượng không được để trống.')
                  "
                  @tab="tabValidate('soluong', 'Số lượng không được để trống.')"
                />
              </div>
              <div class="col-sm-3 py-2 wow fadeInRight">
                <label for="giavacxin">Đơn giá </label>
                <input
                  type="text"
                  id="giavacxin"
                  class="form-control"
                  placeholder="Nhập đơn giá"
                  v-model="ttVacxin.giavacxin"
                />
              </div>
              <div
                class="col-3 col-sm-3 py-2 wow fadeInLeft"
                data-wow-delay="300ms"
              >
                <label for="date"
                  >Ngày nhập <span style="color: #ff0000">*</span></label
                >
                <input
                  type="date"
                  class="form-control"
                  v-model="ttVacxin.ngaynhap"
                  :class="{ 'class-error': !validation.ngaynhapVal }"
                  :title="validation.ngaynhapValMsg"
                  @blur="
                    tabValidate('ngaynhap', 'Ngày nhập không được để trống.')
                  "
                  @tab="
                    tabValidate('ngaynhap', 'Ngày nhập không được để trống.')
                  "
                />
              </div>
              <div
                class="col-6 col-sm-6 py-2 wow fadeInLeft"
                data-wow-delay="300ms"
              >
                <label for="ngaysanxuat"
                  >Ngày sản xuất <span style="color: #ff0000">*</span>
                </label>
                <input
                  type="date"
                  id="ngaysanxuat"
                  class="form-control"
                  v-model="ttVacxin.ngaysanxuat"
                  :class="{ 'class-error': !validation.ngaysanxuatVal }"
                  :title="validation.ngaysanxuatValMsg"
                  @blur="
                    tabValidate(
                      'ngaysanxuat',
                      'Ngày sản xuất không được để trống.'
                    )
                  "
                  @tab="
                    tabValidate(
                      'ngaysanxuat',
                      'Ngày sản xuất không được để trống.'
                    )
                  "
                />
              </div>
              <div
                class="col-6 col-sm-6 py-2 wow fadeInLeft"
                data-wow-delay="300ms"
              >
                <label for="hansudung"
                  >Hạn sử dụng <span style="color: #ff0000">*</span>
                </label>
                <input
                  type="date"
                  id="hansudung"
                  class="form-control"
                  v-model="ttVacxin.hansudung"
                  :class="{ 'class-error': !validation.hansudungVal }"
                  :title="validation.hansudungValMsg"
                  @blur="
                    tabValidate('hansudung', 'Hạn sử dụng không được để trống.')
                  "
                  @tab="
                    tabValidate('hansudung', 'Hạn sử dụng không được để trống.')
                  "
                />
              </div>
              <div
                class="col-12 col-sm-6 py-2 wow fadeInRight"
                data-wow-delay="300ms"
              >
                <label for="loai">Thuộc loại</label>
                <select
                  name="loai"
                  id="loai"
                  class="custom-select"
                  v-model="ttVacxin.maloai"
                >
                  <option
                    v-for="(loai, index) in lstLoaiVacxin"
                    :key="index"
                    :value="loai.maloai"
                    >{{ loai.tenloai }}</option
                  >
                </select>
              </div>
              <div
                class="col-12 col-sm-6 py-2 wow fadeInRight"
                data-wow-delay="300ms"
              >
                <label for="status">Trạng thái </label>
                <select
                  name="status"
                  id="status"
                  class="custom-select"
                  v-model="ttVacxin.trangthai"
                >
                  <option
                    v-for="(st, index) in lstTrangThai"
                    :key="index"
                    :value="st.ma"
                    >{{ st.trangthai }}</option
                  >
                </select>
              </div>

              <div class="col-sm-12 py-2 wow fadeInRight">
                <label for="mota">Mô tả</label>
                <textarea
                  type="text"
                  id="mota"
                  class="form-control"
                  placeholder="Mô tả chi tiết ..."
                  v-model="ttVacxin.mota"
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
      </div>
    </div>
    <BaseConfirm ref="baseConfirm" />
  </div>
</template>
<script>
import axios from "axios";
import BaseConfirm from "@/components/common/baseControlAcounting/BaseConfirm";
import { trangthaiVacxin } from "../../enumeration/enumaration";
export default {
  components: {
    BaseConfirm,
  },
  props: {
    formMode: String,
    idVacxinUpdate: String,
    maVacxin: String,
  },
  data() {
    return {
      lstvacxin: [],
      lstLoaiVacxin: [],
      lstTrangThai: [],
      ttVacxin: {},
      validation: {
        mavacxinVal: true,
        mavacxinValMsg: "",
        tenvacxinVal: true,
        tenvacxinValMsg: "",
        soloVal: true,
        soloValMsg: "",
        ngaynhapVal: true,
        ngaynhapValMsg: "",
        soluongVal: true,
        soluongValMsg: "",
        ngaysanxuatVal: true,
        ngaysanxuatValMsg: "",
        hansudungVal: true,
        hansudungValMsg: "",
      },
    };
  },
  created() {
    this.show();
    this.getLoaiVacxin();
    this.getTrangThai();
  },
  methods: {

    
    /**
     * Thực hiện thêm mới bản ghi
     * */
    async insertRecord() {
      try {
        if (this.validateData()) {
          if (this.formMode == "insert") {
            await axios
              .post("http://localhost:64016/api/Vacxin", this.ttVacxin)
              .then(() => {
                this.$refs.baseConfirm.showForm(
                  "success",
                  1,
                  "Thêm mới vắc xin thành công !"
                );
                this.$router.push({ name: "manage-vaccines" });
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
                `http://localhost:64016/api/Vacxin/${this.idVacxinUpdate}`,
                this.ttVacxin
              )
              .then(() => {
                this.$refs.baseConfirm.showForm(
                  "success",
                  1,
                  "Cập nhật thành công !"
                );
                this.$router.push({ name: "manage-vaccines" });
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
    /**
     * Thực hiện lấy bản ghi của sổ tiêm có mã là mã truyển vào
     * */
    async getVacxinByCode() {
      try {
        await axios
          .get(
            `http://localhost:64016/api/Vacxin/bycode/${this.ttVacxin.mavacxin}`
          )
          .then((response) => {
            if (response.data) {
              var res = response.data.data;
              if (res) {
                this.ttVacxin = res;
              }
            }
          })
          .catch(() => {});
      } catch (error) {
        console.log(error);
      }
    },

    /**
     * Thực hiện lấy tất cả loại vắc xin
     * */
    async getLoaiVacxin() {
      try {
        await axios
          .get(`http://localhost:64016/api/LoaiVacxin`)
          .then((response) => {
            if (response.data) {
              var res = response.data.data;
              if (res) {
                this.lstLoaiVacxin = res;
              }
            }
          })
          .catch(() => {});
      } catch (error) {
        console.log(error);
      }
    },

    /**
     * Thực hiện lấy trạng thái của vắc xin: còn hàng, hết hàng, sắp hết hàng,...
     * */
    getTrangThai() {
      try {
        this.lstTrangThai = [];
        for (var i = 0; i < 3; i++) {
          var item = { ma: i, trangthai: trangthaiVacxin[i.toString()] };
          this.lstTrangThai.push(item);
        }
      } catch (error) {
        console.log(error);
      }
    },

    // todo hiện dialog
    async show() {
      var me = this;
      this.isActive = true;
      console.log(this.formMode);
      console.log(this.idVacxinUpdate);
      if (me.formMode == "update") {
        await axios
          .get(`http://localhost:64016/api/Vacxin/${me.idVacxinUpdate}`)
          .then((response) => {
            if (response.data) {
              var res = response.data.data;
              if (res) {
                me.disableMasotiem = true;
                me.ttVacxin = res;
                me.ttVacxin.ngaynhap = me.formatDate(me.ttVacxin.ngaynhap);
                me.ttVacxin.ngaysanxuat = me.formatDate(
                  me.ttVacxin.ngaysanxuat
                );
                me.ttVacxin.hansudung = me.formatDate(me.ttVacxin.hansudung);
              }
            }
          })
          .catch((error) => {
            me.errorMessage = error.message;
            console.error("GET TTDKT by id Failed: ", error.message);
          });
      } else {
        me.resetInput();
      }
    },

    // todo reset lại các input
    resetInput() {},

    // todo ẩn dialog
    hide() {
      this.isActive = false;
      this.$router.push({ name: "manage-vaccines" });
    },

    /**
     * Thực hiện validate input bị trống
     * CreatedBy: nctu2
     * */
    tabValidate(id, message) {
      if (id == "tenvacxin") {
        console.log("tenvacxin");
        if (!this.ttVacxin.tenvacxin) {
          this.validation.tenvacxinVal = true;
          this.tenvacxinMsg = message;
        }
      }
    },

    /**
     * Thực hiện validate email không được bỏ trống
     * CreatedBy: nctu
     * */
    validateTenVacxin() {
      if (!this.ttVacxin.tenvacxin) {
        this.$refs.baseConfirm.showForm(
          "error",
          1,
          "Tên vắc xin không được để trống"
        );
        return false;
      } else {
        return true;
      }
    },

    /**
     * Thực hiện validate email không được bỏ trống
     * CreatedBy: nctu
     * */
    validateMaVacxin() {
      if (!this.ttVacxin.mavacxin) {
        this.$refs.baseConfirm.showForm(
          "error",
          1,
          "Mã vắc xin không được để trống"
        );
        return false;
      } else {
        return true;
      }
    },
    validateData() {
      if (this.validateTenVacxin() && this.validateMaVacxin()) {
        return true;
      } else {
        return false;
      }
    },
    // định dạng ngày
     formatDate(inputDate) {
      var a = new Date(inputDate);
      console.log(inputDate)
      var month = a.getMonth() + 1;
      var day = a.getDate();
      if (month < 10) month = "0" + month.toString();
      if (day < 10) day = "0" + day.toString();
      var date = a.getFullYear().toString() + "-" + month + "-" + day;
      return date;
    },
    // định dạng trạng thái
    formatStatus(status) {
      var statusDisplay = "";
      if (trangthaiVacxin && status !== null) {
        statusDisplay = trangthaiVacxin[status.toString()];
      }
      return statusDisplay;
    },
    // định dạng tiền
    formatMoney: function(money) {
      if (money != null)
        var num = money.toFixed(0).replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1,");
      else return "0";
      return num;
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
    .step-content {
      width: 100%;
      height: 100%;
      box-sizing: border-box;

      .v-stepper__step {
        padding: 12px !important;
      }
      .v-stepper__items {
        height: calc(100% - 70px) !important;
        .v-stepper__content {
          padding: 0 !important;
          .v-stepper__wrapper {
            height: 100% !important;
          }
          .v-sheet.v-card {
            height: calc(100% - 75px);
          }
          .v-sheet.v-card:not(.v-sheet--outlined) {
            box-shadow: none;
          }
        }
        ::v-deep .v-input__slot {
          justify-content: center !important;
          margin-top: 4px;
          top: 10px;
        }
      }
      .contact-form {
        width: 100%;
        // height: calc(100% - 100px)
      }
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
