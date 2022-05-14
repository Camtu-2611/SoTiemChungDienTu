<template>
  <div class="modal-register">
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

      <div class="content">
        <v-stepper v-model="e1" class="step-content">
          <v-stepper-header class="col-12">
            <v-stepper-step :complete="e1 > 1" step="1">
              Thông tin đăng ký tiêm</v-stepper-step
            >

            <v-divider></v-divider>

            <v-stepper-step :complete="e1 > 2" step="2">
              Sàng lọc trước khi tiêm</v-stepper-step
            >
            <v-divider></v-divider>

            <v-stepper-step :complete="e1 > 3" step="3">
              Thông tin dịch vụ</v-stepper-step
            >

            <!-- <v-divider></v-divider> -->
          </v-stepper-header>

          <v-stepper-items class="col-12">
            <v-stepper-content step="1" style="height: 100% !important">
              <v-card class="mb-6" color="#FFFFFF">
                <div class="container">
                  <form class="contact-form mt-5">
                    <div class="row mb-3">
                      <div
                        class="col-12 col-sm-6 py-2 wow fadeInRight"
                        data-wow-delay="300ms"
                      >
                        <label for="subject">Chọn mã sổ tiêm</label>
                        <select
                          name="masotiem"
                          id="masotiem"
                          class="custom-select"
                          v-model="thongtinDK.masotiem"
                          :disabled="disableMasotiem"
                        >
                          <option
                            v-for="(record, index) in lstMaSoTiem"
                            :key="index"
                            :value="record.masotiem"
                            >{{ record.masotiem }}</option
                          >
                        </select>
                      </div>
                      <div class="col-12 col-sm-6 py-2 wow"></div>
                      <div class="col-sm-6 py-2 wow fadeInLeft">
                        <label for="fullName">Họ tên </label>
                        <input
                          type="text"
                          id="fullName"
                          class="form-control"
                          placeholder="Họ tên..."
                          v-model="thongtinDK.hoten"
                          readonly
                          disabled
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
                          readonly
                          disabled
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
                          disabled
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
                          ref="emailAddress"
                          class="form-control"
                          placeholder="Email address.."
                          readonly
                          disabled
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
                          readonly
                          disabled
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
                          readonly
                          disabled
                        />
                      </div>
                    </div>
                  </form>
                </div>
              </v-card>

              <div class="footer">
                <v-btn color="primary" @click="e1 = 2"> Tiếp tục </v-btn>

                <v-btn text class="ml-2"> Hủy </v-btn>
              </div>
            </v-stepper-content>
            <v-stepper-content step="2">
              <v-card class="mb-4" color="#FFFFFF">
                <div class="container-fluid px-0 mx-0">
                  <v-simple-table fixed-header height="400px">
                    <template v-slot:default>
                      <thead>
                        <tr>
                          <th class="text-left col-sm-10"><h7>Câu hỏi</h7></th>
                          <th class="text-center"><h7></h7></th>
                        </tr>
                      </thead>
                      <tbody>
                        <tr>
                          <td class="text-left col-sm-10">
                            1. Tiền sử phản vệ, sốc mạnh sau lần tiêm chủng
                            trước
                          </td>
                          <td class="text-center">
                            <v-checkbox
                              class="text-center"
                              v-model="thongtinDK.cauhoi1"
                            ></v-checkbox>
                          </td>
                        </tr>
                        <tr>
                          <td class="text-left col-sm-10">
                            2. Tiền sử mắc COVID-19 trong 6 tháng qua
                          </td>
                          <td class="text-center">
                            <v-checkbox
                              class="text-center"
                              v-model="thongtinDK.cauhoi2"
                            ></v-checkbox>
                          </td>
                        </tr>
                        <tr>
                          <td class="text-left col-sm-10">
                            3. Đang bị suy giảm miễn dịch nặng, ung thư giai
                            đoạn cuối đang điều trị, xạ trị, hóa trị
                          </td>
                          <td class="text-center">
                            <v-checkbox
                              class="text-center"
                              v-model="thongtinDK.cauhoi3"
                            ></v-checkbox>
                          </td>
                        </tr>
                        <tr>
                          <td class="text-left col-sm-10">
                            4. Mắc các bệnh bẩm sinh, bệnh mạn tính ở tim, phổi,
                            hệ tiêu hóa, máu,...
                          </td>
                          <td class="text-center">
                            <v-checkbox
                              class="text-center"
                              v-model="thongtinDK.cauhoi4"
                            ></v-checkbox>
                          </td>
                        </tr>
                        <tr>
                          <td class="text-left col-sm-10">
                            5. Phụ nữ mang thai, phụ nữ đang nuôi con bằng sữa
                            mẹ
                          </td>
                          <td class="text-center">
                            <v-checkbox
                              class="text-center"
                              v-model="thongtinDK.cauhoi5"
                            ></v-checkbox>
                          </td>
                        </tr>
                        <tr>
                          <td class="text-left col-sm-10">
                            6. Tiêm vắc xin khác trong vòng 14 ngày trước
                          </td>
                          <td class="text-center">
                            <v-checkbox
                              class="text-center"
                              v-model="thongtinDK.cauhoi6"
                            ></v-checkbox>
                          </td>
                        </tr>
                        <tr>
                          <td class="text-left col-sm-10">
                            7. Trong vòng 14 ngày trước có điều trị corticoid
                            liều cao (tương đương prednisolon ≥ 2 mg/kg/ngày
                            trong ≥ 7 ngày)
                          </td>
                          <td class="text-center">
                            <v-checkbox
                              class="text-center"
                              v-model="thongtinDK.cauhoi7"
                            ></v-checkbox>
                          </td>
                        </tr>
                        <tr>
                          <td class="text-left col-sm-10">
                            8. Giảm tiểu cầu và/hoặc rối loạn đông máu.
                          </td>
                          <td class="text-center">
                            <v-checkbox
                              class="text-center"
                              v-model="thongtinDK.cauhoi8"
                            ></v-checkbox>
                          </td>
                        </tr>
                        <tr>
                          <td class="text-left col-sm-10">
                            9. Rối loại tri giác, rối loạn hành vi
                          </td>
                          <td class="text-center">
                            <v-checkbox
                              class="text-right"
                              v-model="thongtinDK.cauhoi9"
                            ></v-checkbox>
                          </td>
                        </tr>
                        <tr>
                          <td class="text-left col-sm-10">
                            10. Tiền sử dị ứng với bất kì dị nguyên nào
                          </td>
                          <td class="text-center">
                            <v-checkbox
                              class="text-right"
                              v-model="thongtinDK.cauhoi10"
                            ></v-checkbox>
                          </td>
                        </tr>
                      </tbody>
                    </template>
                  </v-simple-table>
                </div>
              </v-card>
              <div class="footer">
                <v-btn color="primary" @click="e1 = 3"> Tiếp tục </v-btn>
                <v-btn text @click="e1 = 1"> Quay lại </v-btn>
              </div>
            </v-stepper-content>
            <v-stepper-content step="3" style="height: 100% !important">
              <v-card class="mb-6" color="#FFFFFF">
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
                          v-model="thongtinDK.idtrungtam"
                        >
                          <option
                            v-for="(record, index) in listTrungTam"
                            :key="index"
                            :value="record.idtrungtam"
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
                                            {{ record.giavacxin }}
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

              <div class="footer">
                <v-btn color="primary" @click="insertRecord()"> Đăng ký </v-btn>

                <v-btn text class="ml-2" @click="e1 = 1"> Quay lại </v-btn>
              </div>
            </v-stepper-content>
          </v-stepper-items>
        </v-stepper>
      </div>
    </div>
    <BaseConfirm ref="baseConfirm" />
  </div>
</template>

<script src="https://unpkg.com/vuejs-datepicker/dist/locale/translations/fr.js"></script>

<script>
import axios from "axios";
import DatePicker from "vue2-datepicker";
//  import 'vue2-datepicker/locale/vi';
import BaseConfirm from "@/components/common/baseControlAcounting/BaseConfirm";

export default {
  components: {
    DatePicker,
    BaseConfirm,
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
      selected: [""],
      thongtinDK: {},
      listRecord: [],
      listTrungTam: [],
      lstMaSoTiem: [],
      validation: {
        emailVal: false,
        emailValMsg: "",
        sdtVal: true,
      },
      stateValidate: true,
      disableMasotiem: false,
    };
  },
  created() {
    this.getAllVacxin(); // lấy thông tin vắc xin
    this.getAllTrungTam(); // lấy thông tin trung tâm
    this.getAllSoTiem(); // lấy danh sách sổ tiêm
    this.show();
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
      } else {
        this.stateValidate = true;
        return true;
      }
    },
    validateData() {
      if (this.validateEmail()) {
        return true;
      } else return false;
    },

    // todo reset lại các input
    resetInput() {
      (this.thongtinDK.hoten = ""),
        (this.thongtinDK.ngaysinh = ""),
        (this.thongtinDK.gioitinh = ""),
        (this.thongtinDK.sodienthoai = ""),
        (this.thongtinDK.email = ""),
        (this.thongtinDK.diachi = ""),
        (this.thongtinDK.cauhoi1 = false),
        (this.thongtinDK.cauhoi2 = false),
        (this.thongtinDK.cauhoi3 = false),
        (this.thongtinDK.cauhoi4 = false),
        (this.thongtinDK.cauhoi5 = false),
        (this.thongtinDK.cauhoi6 = false),
        (this.thongtinDK.cauhoi7 = false),
        (this.thongtinDK.cauhoi8 = false),
        (this.thongtinDK.cauhoi9 = false),
        (this.thongtinDK.cauhoi10 = false),
        (this.thongtinDK.trangthai = 1),
        (this.thongtinDK.tentrungtam = ""),
        (this.thongtinDK.idtrungtam = "00000000-0000-0000-0000-000000000000"),
        (this.thongtinDK.ngaydangkytiem = new Date().toISOString()),
        (this.thongtinDK.danhsachvacxin = []),
        (this.thongtinDK.nguoitao = ""),
        (this.thongtinDK.ngaytao = new Date().toISOString()),
        (this.thongtinDK.nguoichinhsua = ""),
        (this.thongtinDK.ngaychinhsua = new Date().toISOString());
      console.log(this.thongtinDK.hoten + "1");
    },
    // todo hiện dialog
    async show() {
      var me = this;
      this.isActive = true;
      this.dup = false;
      if (this.formMode == "update") {
        await axios
          .get(
            "http://localhost:64016/api/ThongTinDangKyTiem/" +
              this.idDangKyUpdate
          )
          .then((response) => {
            if (response.data) {
              var res = response.data.data;
              if (res) {
                this.disableMasotiem = true;
                me.thongtinDK = res;
                me.thongtinDK.ngaysinh = this.formatDate(
                  me.thongtinDK.ngaysinh
                );
                me.thongtinDK.ngaydangkytiem = this.formatDate(
                  me.thongtinDK.ngaydangkytiem
                );
                console.log(me.thongtinDK);
              }
            }
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
      this.$router.push({ name: "injection-register" });
      //document.getElementsByClassName("body-right")[0].style.zIndex = "0";
    },

    // todo select tất cả nội dung ô input khi click
    selectAll() {
      document.getElementsByTagName("input").forEach((element) => {
        element.addEventListener("click", () => {
          element.select();
        });
      });
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
    // định dạng ngày
    formatDate(inputDate) {
      var a = new Date(inputDate);
      var month = a.getMonth();
      var day = a.getDate();
      if (month < 10) month = "0" + month.toString();
      if (day < 10) day = "0" + day.toString();
      var date = a.getFullYear().toString() + "-" + month + "-" + day;
      return date;
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
          if (this.formMode == "insert") {
            await axios
              .post(
                "http://localhost:64016/api/ThongTinDangKyTiem",
                this.thongtinDK
              )
              .then(() => {
                // alert("Đăng ký tiêm thành công !");
                this.$refs.baseConfirm.showForm(
                  "sucess",
                  1,
                  "Đăng ký tiêm thành công !"
                );
                this.$router.push({ name: "injection-register" });
              })
              .catch(() => {});
          } else if (this.formMode == "update") {
            await axios
              .put(
                `http://localhost:64016/api/ThongTinDangKyTiem/${this.idDangKyUpdate}`,
                this.thongtinDK
              )
              .then(() => {
                // alert("Đăng ký tiêm thành công !");
                this.$refs.baseConfirm.showForm(
                  "sucess",
                  1,
                  "Sửa thông tin thành công !"
                );
                this.$router.push({ name: "injection-register" });
              })
              .catch(() => {});
          }
        } else {
          return;
        }
      } catch (error) {
        console.log(error);
      }
    },

    /**
     * Thực hiện lấy toàn bộ bản ghi của Vacxin
     * */
    async getAllVacxin() {
      try {
        var me = this;
        await axios
          .get("http://localhost:64016/api/Vacxin")
          .then((response) => {
            if (response.data) {
              me.listRecord = response.data.data;
            }
          })
          .catch(() => {});
      } catch (error) {
        console.log(error);
      }
    },
    /**
     * Thực hiện lấy toàn bộ bản ghi của Trung tâm tiêm chủng
     * */
    async getAllTrungTam() {
      try {
        var me = this;
        await axios
          .get("http://localhost:64016/api/TrungTamTiemChung")
          .then((response) => {
            if (response.data) {
              me.listTrungTam = response.data.data;
            }
          })
          .catch(() => {});
      } catch (error) {
        console.log(error);
      }
    },
    /**
     * Thực hiện lấy toàn bộ bản ghi của sổ tiêm
     * */
    async getAllSoTiem() {
      try {
        var me = this;
        await axios
          .get("http://localhost:64016/api/SoTiem")
          .then((response) => {
            if (response.data) {
              me.lstMaSoTiem = response.data.data;
            }
          })
          .catch(() => {});
      } catch (error) {
        console.log(error);
      }
    },

    /**
     * Thực hiện lấy toàn bộ bản ghi của sổ tiêm
     * */
    async getSoTiemByCode() {
      try {
        await axios
          .get(
            `http://localhost:64016/api/SoTiem/bycode/${this.thongtinDK.masotiem}`
          )
          .then((response) => {
            if (response.data) {
              var res = response.data.data;
              if (res) {
                this.thongtinDK.hoten = res.hoten;
                this.thongtinDK.ngaysinh = res.ngaysinh;
                this.thongtinDK.ngaysinh = this.formatDate(
                  this.thongtinDK.ngaysinh
                );
                this.thongtinDK.gioitinh = res.gioitinh;
                this.thongtinDK.email = res.email;
                this.thongtinDK.sodienthoai = res.sodienthoai;
                this.thongtinDK.diachi = res.diachi;
                console.log(this.thongtinDK.hoten + "3");
              }
            }
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
    "thongtinDK.masotiem": async function() {
      console.log(this.thongtinDK.masotiem);
      this.getSoTiemByCode();
      console.log(this.thongtinDK.hoten + "2");
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
  filters: {
    // định dạng ngày
    formatDate(inputDate) {
      var a = new Date(inputDate);
      var month = a.getMonth();
      var day = a.getDate();
      if (month < 10) month = "0" + month.toString();
      if (day < 10) day = "0" + day.toString();
      var date = day + "-" + month + "-" + a.getFullYear().toString();
      return date;
    },
  },
  mounted() {
    this.selectAll();
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

#assetInput5 {
  text-align: right;
}
#assetInput6 {
  text-align: right;
}

// input[type="date"] {
//   opacity: 1;
//   display: block;
//   background: url(../../assets/icon/calendar.svg) no-repeat;
//   width: 30px;
//   height: 30px;
//   border-width: thin;
//   margin-top: 20px;
//   transform: translateX(5px);
// }
// @import url("../../style/scss/common.scss");
// @import url("../../style/scss/icon.scss");
// @import url("../../style/scss/button.scss");
// @import url("./../../style/scss/combobox.scss");
// @import url("../../style/scss/table.scss");
//  @import url("../../style/scss/date_picker.scss");
</style>
