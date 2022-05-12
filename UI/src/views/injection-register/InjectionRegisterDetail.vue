<template>
  <div v-show="isActive" class="modal-register">
    <div class="modal-background"></div>
    <div class="modal-content">
      <div class="header">
        <div v-if="formMode == 'insert'" class="title">Đăng ký tiêm</div>
        <div v-else class="title">Sửa</div>

        <div class="header-right">
          <div class="icon-help btn btn-help" title="Hỗ trợ"></div>
          <div
            class="icon-cancel btn btn-close"
            title="Đóng"
            @click="hide()"
          ></div>
        </div>
      </div>

      <div class="content ">
        <v-stepper v-model="e1" class="step-content">
          <v-stepper-header class="col-12">
            <v-stepper-step :complete="e1 > 1" step="1">
              Thông tin đăng ký tiêm</v-stepper-step
            >

            <v-divider></v-divider>

            <v-stepper-step :complete="e1 > 2" step="2">
              Thông tin dịch vụ</v-stepper-step
            >

            <!-- <v-divider></v-divider> -->
          </v-stepper-header>

          <v-stepper-items class="col-12">
            <v-stepper-content step="1">
              <v-card class="mb-6" color="#FFFFFF" height="100%">
                <div class="container">
                  <form class="contact-form mt-5">
                    <div class="row mb-3">
                      <div class="col-sm-6 py-2 wow fadeInLeft">
                        <label for="fullName">Họ tên </label>
                        <input
                          type="text"
                          id="fullName"
                          class="form-control"
                          placeholder="Họ tên..."
                          v-model="thongtinDK.hoten"
                        />
                      </div>
                      <div
                        class="col-12 col-sm-6 py-2 wow fadeInLeft"
                        data-wow-delay="300ms"
                      >
                        <label for="date">Ngày sinh </label>
                        <input
                          type="date"
                          class="form-control"
                          v-model="thongtinDK.ngaysinh"
                        />
                      </div>
                      <div
                        class="col-12 col-sm-6 py-2 wow fadeInRight"
                        data-wow-delay="300ms"
                      >
                        <label for="subject">Giới tính</label>
                        <select
                          name="departement"
                          id="departement"
                          class="custom-select"
                          v-model="thongtinDK.gioitinh"
                        >
                          <option value="1">Nam</option>
                          <option value="2">Nữ</option>
                          <option value="0">Khác</option>
                        </select>
                      </div>
                      <div class="col-sm-6 py-2 wow fadeInRight">
                        <label for="emailAddress">Email</label>
                        <input
                          type="email"
                          id="emailAddress"
                          class="form-control"
                          placeholder="Email address.."
                          v-model="thongtinDK.email"
                          :class="{ 'class-error': validation.emailVal }"
                          :title="validation.emailValMsg"
                          @blur="
                            tabValidate(
                              'emailAddress',
                              'email không được để trống.'
                            )
                          "
                          @tab="
                            tabValidate(
                              'emailAddress',
                              'email không được để trống.'
                            )
                          "
                        />
                      </div>
                      <div
                        class="col-12 col-sm-6 py-2 wow fadeInLeft"
                        data-wow-delay="300ms"
                      >
                        <label for="SDT">Số điện thoại </label>
                        <input
                          type="text"
                          class="form-control"
                          v-model="thongtinDK.sodienthoai"
                        />
                      </div>
                      <div class="col-sm-6 py-2 wow fadeInRight">
                        <label for="diachi">Địa chỉ</label>
                        <input
                          type="text"
                          id="diachi"
                          class="form-control"
                          placeholder="Địa chỉ.."
                          v-model="thongtinDK.diachi"
                        />
                      </div>
                    </div>
                  </form>
                </div>
              </v-card>

              <v-btn color="primary" @click="e1 = 2"> Tiếp tục </v-btn>

              <v-btn text> Hủy </v-btn>
            </v-stepper-content>

            <v-stepper-content step="2">
              <v-card class="mb-6" color="#FFFFFF" height="100%">
                <div class="container">
                  <!-- <h4>THÔNG TIN DỊCH VỤ</h4> -->

                  <form class="contact-form mt-5">
                    <div class="row mb-3">
                      <div
                        class="col-12 col-sm-6 py-2 wow fadeInRight"
                        data-wow-delay="300ms"
                      >
                        <label for="subject"
                          >Trung tâm tiêm chủng muốn tiêm</label
                        >
                        <select
                          name="tttiemchung"
                          id="tttiemchung"
                          class="custom-select"
                          v-model="thongtinDK.tentrungtam"
                        >
                          <option
                            v-for="(record, index) in listTrungTam"
                            :key="index"
                            :value="record.matrungtam"
                            >{{ record.tentrungtam }}</option
                          >
                        </select>
                      </div>
                      <div
                        class="col-12 col-sm-6 py-2 wow fadeInLeft"
                        data-wow-delay="300ms"
                      >
                        <label for="ngaytiem">Ngày mong muốn tiêm</label>
                        <input
                          type="date"
                          class="form-control"
                          v-model="thongtinDK.ngaydangkytiem"
                        />
                      </div>
                      <div
                        class="col-12 py-2 wow fadeInUp"
                        data-wow-delay="300ms"
                      >
                        <label for="vacxin">Loại vắc xin muốn tiêm</label>

                        <v-expansion-panels>
                          <v-expansion-panel>
                            <v-expansion-panel-header>
                              Vắc xin lẻ
                            </v-expansion-panel-header>
                            <v-expansion-panel-content>
                              <v-container fluid>
                                <v-row>
                                  <v-col
                                    cols="12"
                                    sm="6"
                                    md="6"
                                    v-for="(record, index) in listRecord"
                                    :key="index"
                                  >
                                    <v-card
                                      class="mx-auto"
                                      max-width="344"
                                      outlined
                                      color="#eef6ff"
                                    >
                                      <v-list-item three-line>
                                        <v-list-item-content>
                                          <div class="text-overline mb-4">
                                            <v-checkbox
                                              v-model="
                                                thongtinDK.danhsachvacxin
                                              "
                                              :label="record.tenvacxin"
                                              :value="record.mavacxin"
                                            ></v-checkbox>
                                          </div>
                                          <v-list-item-title
                                            class="text-h5 mb-1"
                                          >
                                            106.000 VNĐ
                                          </v-list-item-title>
                                          <v-list-item-subtitle>
                                            {{
                                              record.mota
                                            }}</v-list-item-subtitle
                                          >
                                        </v-list-item-content>
                                      </v-list-item>
                                    </v-card>
                                  </v-col>
                                </v-row>
                              </v-container>
                            </v-expansion-panel-content>
                          </v-expansion-panel>
                        </v-expansion-panels>

                        <v-expansion-panels>
                          <v-expansion-panel>
                            <v-expansion-panel-header>
                              Vắc xin gói
                            </v-expansion-panel-header>
                            <v-expansion-panel-content>
                              <v-container fluid>
                                <v-row>
                                  <v-col
                                    cols="12"
                                    sm="6"
                                    md="6"
                                    v-for="(record, index) in listRecord"
                                    :key="index"
                                  >
                                    <v-card
                                      class="mx-auto"
                                      max-width="344"
                                      outlined
                                      color="#eef6ff"
                                    >
                                      <v-list-item three-line>
                                        <v-list-item-content>
                                          <div class="text-overline mb-4">
                                            <v-checkbox
                                              v-model="
                                                thongtinDK.danhsachvacxin
                                              "
                                              :label="record.tenvacxin"
                                              :value="record.mavacxin"
                                            ></v-checkbox>
                                          </div>
                                          <v-list-item-title
                                            class="text-h5 mb-1"
                                          >
                                            106.000 VNĐ
                                          </v-list-item-title>
                                          <v-list-item-subtitle>
                                            {{
                                              record.mota
                                            }}</v-list-item-subtitle
                                          >
                                        </v-list-item-content>
                                      </v-list-item>
                                    </v-card>
                                  </v-col>
                                </v-row>
                              </v-container>
                            </v-expansion-panel-content>
                          </v-expansion-panel>
                        </v-expansion-panels>
                      </div>
                    </div>
                  </form>
                </div>
              </v-card>

              <v-btn color="primary" @click="insertRecord()"> Đăng ký </v-btn>

              <v-btn text @click="e1 = 1"> Quay lại </v-btn>
            </v-stepper-content>
          </v-stepper-items>
        </v-stepper>
      </div>
      <!-- <div class="footer">
        <div class="btn btn-cancel" tabindex="0" @click="hide()">Hủy</div>

        <div class="btn btn-save" tabindex="0" @click="save()">Lưu</div>
      </div> -->
    </div>
    <BaseConfirm ref="baseConfirm" />
  </div>
</template>

<script src="https://unpkg.com/vuejs-datepicker/dist/locale/translations/fr.js"></script>

<script>
import axios from "axios";
import DatePicker from "vue2-datepicker";
//  import 'vue2-datepicker/locale/vi';
import BaseConfirm from '@/components/common/baseControlAcounting/BaseConfirm'

export default {
  components: {
    DatePicker,
    BaseConfirm
  },
  props: {
    // listAssetType: Array,
    // listDepartment: Array,
    formMode: String,
    idDangKyUpdate: String,
  },
  data() {
    return {
      e1: 1,
      isActive: false,
      showSuccess: true,
      dup: false,
      lang: {
        formatLocale: {
          firstDayOfWeek: 1,
        },
        days: ["CN", "Thứ 2", "Thứ 3", "Thứ 4", "Thứ 5", "Thứ 6", "Thứ 7"],
        months: [
          "Tháng 1",
          "Tháng 2",
          "Tháng 3",
          "Tháng 4",
          "Tháng 5",
          "Tháng 6",
          "Tháng 7",
          "Tháng 8",
          "Tháng 9",
          "Tháng 10",
          "Tháng 11",
          "Tháng 12",
        ],
        weekdays: [
          "Chủ nhật",
          "thứ hai",
          "thứ ba",
          "thứ tư",
          "thứ năm",
          "thứ sáu",
          "Thứ Bảy",
        ],
        weekdaysMin: ["CN", "T2", "T3", "T4", "T5", "T6", "T7"],
        yearFormat: "YYYY",
        monthsShort: [
          "T01",
          "T02",
          "T03",
          "T04",
          "T05",
          "T06",
          "T07",
          "T08",
          "T09",
          "T10",
          "T11",
          "T12",
        ],
        monthFormat: "TMM",
      },
      selected: [""],
      thongtinDK: {},
      defaultthongtinDK: {
        hoten: "",
        ngaysinh: "",
        gioitinh: "",
        sodienthoai: "",
        email: "",
        diachi: "",
        idtrungtam: "",
        ngaydangkytiem: "",
        danhsachvacxin: [],
        nguoitao: "",
        ngaytao: new Date().toISOString(),
        nguoichinhsua: "",
        ngaychinhsua: new Date().toISOString(),
      },
      listRecord: [],
      listTrungTam: [],
      validation: {
        emailVal: false,
        emailValMsg: "",
        sdtVal: true,
      },
      stateValidate: true,
    };
  },
  methods: {
    /**
     * Thực hiện validate input bị trống
     * CreatedBy: nctu2
     * */
    tabValidate(id, message) {
      if (id == "emailAddress") {
        console.log("email");
        if (!this.thongtinDK.email) {
          this.validation.emailVal = true;
          this.emailValMsg = message;
        }
      }
    },

    /**
     * Thực hiện validate email không được bỏ trống
     * CreatedBy: nctu
     * */
    validateEmail() {
      if (!this.thongtinDK.email) {
        this.$refs.baseConfirm.showForm(
          "error",
          1,
          "Email không được để trống"
        );
        this.stateValidate = false;
        return false;
      }
    },
    validateData(){
      this.validateEmail()
    },

    // todo reset lại các input
    resetInput() {
      (this.thongtinDK.hoten = ""),
        (this.thongtinDK.ngaysinh = ""),
        (this.thongtinDK.gioitinh = ""),
        (this.thongtinDK.sodienthoai = ""),
        (this.thongtinDK.email = ""),
        (this.thongtinDK.diachi = ""),
        (this.thongtinDK.idtrungtam = "00000000-0000-0000-0000-000000000000"),
        (this.thongtinDK.ngaydangkytiem = new Date().toISOString()),
        (this.thongtinDK.danhsachvacxin = []),
        (this.thongtinDK.nguoitao = ""),
        (this.thongtinDK.ngaytao = new Date().toISOString()),
        (this.thongtinDK.nguoichinhsua = ""),
        (this.thongtinDK.ngaychinhsua = new Date().toISOString());
    },
    // todo hiện dialog
    async show() {
      console.log("show detail");
      console.log(this.isActive);
      var res = this;
      this.isActive = true;
      this.dup = false;
      console.log(this.isActive);

      if (this.formMode == "update") {
        await axios
          .get(
            "http://localhost:64016/api/ThongTinDangKyTiem" +
              this.idDangKyUpdate
          )
          .then((Response) => {
            res.asset.departmentId = "";
            res.asset = Response.data.data;
          })
          .catch((error) => {
            this.errorMessage = error.message;
            console.error("GET TTDKT by id Failed: ", error.message);
          });
      } else {
        this.resetInput();
      }
    },

    // todo ẩn dialog
    hide() {
      this.isActive = false;
      document.getElementsByClassName("body-right")[0].style.zIndex = "0";
    },

    // todo select tất cả nội dung ô input khi click
    selectAll() {
      document.getElementsByTagName("input").forEach((element) => {
        element.addEventListener("click", () => {
          element.select();
        });
      });
    },

    // todo lấy dữ liệu tên phòng ban
    getDepartmentName() {
      var res = this;
      this.listDepartment.forEach((element) => {
        if (element.departmentId == res.asset.departmentId) {
          res.asset.departmentName = element.departmentName;
        }
      });
    },

    //todo lấy dữ liệu tên loại tài sản
    getAssetTypeName() {
      var res = this;
      this.listAssetType.forEach((element) => {
        if (element.assetTypeId == res.asset.assetTypeId) {
          res.asset.assetTypeName = element.assetTypeName;
        }
      });
    },

    // todo chỉ cho phép nhập số
    formatNumber(e) {
      var key = e.key;
      if (!/^\d+/g.test(key)) {
        e.preventDefault();
      }

      // if((this.asset.originalPrice == null ) && this.asset.wearValue == null)
      // {
      //   this.asset.originalPrice = "0";
      //   this.asset.wearValue  = "0"
      // }
      // if( this.asset.originalPrice == '')
      // {
      //   this.asset.originalPrice = "0";
      // }
      // if(this.asset.wearValue == '')
      // {
      //   this.asset.wearValue  = "0"
      // }

      // setTimeout(() => {
      //   if (
      //     parseInt(this.asset.originalPrice) <= parseInt(this.asset.wearValue)
      //   ) {
      //     this.asset.wearValue = null;
      //   }
      // }, 200);
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

    // update input
    updateInput(text, e) {
      if (text == "wearValue")
        this.asset.wearValue = this.removeFormatMoney(e.target.value);
      else this.asset.originalPrice = this.removeFormatMoney(e.target.value);
    },

    // validate trống trường dữ liệu mã tài sản
    async validateAssetCode() {
      this.dup = false;
      var warning = document.getElementById("assetInput1");
      if (this.asset.assetCode == null || this.asset.assetCode == "") {
        // warning.style.border = "1px solid red";
        warning.classList.add("borderRed");
        warning.classList.add("hover-validate");
      } else {
        warning.style.border = "#e4e4e4 1px solid";
        warning.classList.remove("hover-validate");
        warning.classList.remove("borderRed");
      }
    },

    // todo validate trường dữ liệu tên tài sản
    validateAssetName() {
      var warning = document.getElementById("assetInput2");
      if (this.asset.assetName == null || this.asset.assetName == "") {
        warning.classList.add("borderRed");
        warning.classList.add("hover-validate");
      } else {
        warning.style.border = "#e4e4e4 1px solid";
        warning.classList.remove("hover-validate");
        warning.classList.remove("borderRed");
      }
    },

    // todo lưu dữ liệu
    async save() {
      this.validateAssetName();
      this.validateAssetCode();
      if (
        parseInt(this.asset.originalPrice) <= parseInt(this.asset.wearValue)
      ) {
        document.getElementById("assetInput8").classList.add("borderRed");
        return;
      } else {
        document.getElementById("assetInput8").classList.remove("borderRed");
      }
      var res = this;
      if (res.asset.originalPrice == "") res.asset.originalPrice = null;
      if (res.asset.wearValue == "") res.asset.wearValue = null;

      if (
        this.asset.assetCode == null ||
        this.asset.assetName == null ||
        this.asset.assetCode == "" ||
        this.asset.assetName == ""
      ) {
        return;
      } else {
        if (this.formMode == "insert") {
          //nếu là form thêm dữ liệu
          await axios
            .post("https://localhost:44382/api/v1/assets/", this.asset)
            .then((respone) => {
              // nếu không gặp lỗi badrequest
              if (respone.data.errorCode == 400) {
                var warning = document.getElementById("assetInput1");
                res.dup = true;
                warning.classList.add("borderRed");

                res.$emit("reload", false);
                return;
              } else if (
                respone.data.errorCode != 400 &&
                parseInt(res.asset.originalPrice) <=
                  parseInt(res.asset.wearValue)
              ) {
                res.dup = false;
                return;
              } else {
                res.dup = false;
                res.hide();
                res.$emit("reload", true);
              }
            })
            .catch((error) => {
              res.$emit("reload", false);
              console.log(error);
              alert("Có lỗi xảy ra, vui lòng liên hệ MISA để được trợ giúp");
            });
        } else {
          // nếu là form sửa dữ liệu

          await axios
            .put("https://localhost:44382/api/v1/assets/", this.asset)
            .then((respone) => {
              if (respone.data.errorCode != 400) {
                res.hide();
                res.$emit("reload", true);
              } else {
                res.dup = true;
                document
                  .getElementById("assetInput1")
                  .classList.add("borderRed");

                res.$emit("reload", false);
                return;
              }
            })
            .catch((error) => {
              console.log(error);
              res.$emit("reload", false);
              alert("Có lỗi xảy ra, vui lòng liên hệ MISA để được trợ giúp!");
            });
        }
      }
    },

    showWarning(text) {
      this.$emit("msgAlert", text, true);
    },
    checkPostedDate() {
      this.$emit("reload", false);
    },
    /**
     * Thực hiện thêm mới bản ghi
     * */
    async insertRecord() {
      try {
        let me = this;
        if (this.validateData()) {
          let dsdangky = this.thongtinDK.danhsachvacxin.toString();
          this.thongtinDK.danhsachvacxin = dsdangky;
          await axios
            .post(
              "http://localhost:64016/api/ThongTinDangKyTiem",
              this.thongtinDK
            )
            .then(() => {
              console.log("106");
              alert("Đăng ký tiêm thành công !");
              this.$router.push({ name: "STC-dien-tu" });
            })
            .catch(() => {});
        }
        else{
          console.log("email empty")
          return
        }
      } catch (error) {
        console.log(error);
      }
    },

    /**
     * Thực hiện lấy toàn bộ bản ghi của Vacxin
     * */
    async getAllRecord() {
      try {
        var me = this;
        await axios
          .get("http://localhost:64016/api/Vacxin")
          .then((response) => {
            me.listRecord = response.data.data;
            me.totalRecord = response.data.length;
          })
          .catch(() => {});
      } catch (error) {
        console.log(error);
      }
    },
    /**
     * Thực hiện lấy toàn bộ bản ghi của Trung tâm tiêm chủng
     * */
    async getAllRecordTrungTam() {
      try {
        var me = this;
        await axios
          .get("http://localhost:64016/api/TrungTamTiemChung")
          .then((response) => {
            me.listTrungTam = response.data.data;
            me.totalRecord = response.data.length;
          })
          .catch(() => {});
      } catch (error) {
        console.log(error);
      }
    },
  },
  watch: {
    // todo theo dõi id phòng ban để lấy ra tên phòng ban tương ứng
    "asset.departmentId": function() {
      if (this.asset.departmentId == null) this.asset.departmentName = null;
      else this.getDepartmentName();
    },

    // todo theo dõi mã loại tài sản để lấy ra tên loại tài sản tương ứng
    "asset.assetTypeId": function() {
      if (this.asset.assetTypeId == null) this.asset.assetTypeId = null;
      else this.getAssetTypeName();
    },
  },
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
    this.selectAll();
  },
};
</script>

<style lang="scss" scoped>
.modal-register {
  position: fixed;
  top: 0;
  left: 0;
  bottom: 0;
  right: 0;
  z-index: 1000;
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

// ::-webkit-scrollbar {
//   width: 8px;
//   height: 8px;
//  }

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
  position: absolute;
  top: calc(50% - 300px);
  left: calc(50% - 380px);
  width: 705px;
  height: 530px;
  background-color: white;
  resize: both;
  overflow: auto;
  min-height: 530px;
  min-width: 705px;
  height: 600px;
  width: 760px;

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
    padding: 6px 6px 6px 6px;
    box-sizing: border-box;
    overflow-y: auto;
    overflow-x: hidden;
    .step-content {
      width: 100%;
      height: 100%;
      box-sizing: border-box;
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
        padding: 10px;
      }
    }
  }

  .footer {
    width: 100%;
    height: 50px;
    background-color: #f5f5f5;
    display: flex;
    align-items: center;
    position: relative;
    padding: 0 16px;
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

input[type="date"] {
  opacity: 1;
  display: block;
  background: url(../../assets/icon/calendar.svg) no-repeat;
  width: 30px;
  height: 30px;
  border-width: thin;
  margin-top: 20px;
  transform: translateX(5px);
}
// @import url("../../style/scss/common.scss");
// @import url("../../style/scss/icon.scss");
// @import url("../../style/scss/button.scss");
// @import url("./../../style/scss/combobox.scss");
// @import url("../../style/scss/table.scss");
//  @import url("../../style/scss/date_picker.scss");
</style>
