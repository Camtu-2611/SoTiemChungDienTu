<template>
  <div>
    <div
      class="page-banner overlay-dark bg-image"
      style="background-image: url(../assets/img/bg_image_1.jpg)"
    >
      <div class="banner-section">
        <div class="container text-center wow fadeInUp">
          <h3 class="font-weight-normal">ĐĂNG KÝ TIÊM CHỦNG</h3>
          <nav aria-label="Breadcrumb">
            <ol
              class="
                breadcrumb breadcrumb-dark
                bg-transparent
                justify-content-center
                py-0
                mb-2
              "
            >
              <li class="breadcrumb-item">
                <a @click="$router.push({ name: 'STC-dien-tu' })">Trang chủ</a>
              </li>
              <li class="breadcrumb-item active" aria-current="page">
                Đăng ký tiêm
              </li>
            </ol>
          </nav>
        </div>
        <!-- .container -->
      </div>
      <!-- .banner-section -->
    </div>
    <v-stepper v-model="e1">
      <v-stepper-header>
        <v-stepper-step :complete="e1 > 1" step="1">
          Bước 1 : Thông tin đăng ký tiêm</v-stepper-step
        >

        <v-divider></v-divider>

        <v-stepper-step :complete="e1 > 2" step="2">
          Bước 2 : Sàng lọc trước khi tiêm</v-stepper-step
        >

        <v-divider></v-divider>
        <v-stepper-step :complete="e1 > 3" step="3">
          Bước 3 : Thông tin dịch vụ</v-stepper-step
        >
      </v-stepper-header>

      <v-stepper-items>
        <v-stepper-content step="1">
          <v-card class="mb-12" color="	#FFFFFF" >
            <div class="container">
              <h4>THÔNG TIN ĐĂNG KÝ TIÊM</h4>

              <form class="contact-form mt-5">
                <div class="row mb-3"
              
                >
                   <div class="col-sm-6 py-2 wow fadeInLeft">
                    <label for="fullName"
                      >Mã sổ tiêm <span style="color: #ff0000">*</span>
                    </label>
                    <input
                      type="text"
                      id="masotiem"
                      class="form-control"
                      placeholder=""
                      v-model="thongtinDK.masotiem"
                      :disabled="disableMasotiem"
                      readonly
                     
                    />
                  </div>
                  <div class="col-sm-6 py-2 wow fadeInLeft">
                    <label for="fullName"
                      >Họ tên <span style="color: #ff0000">*</span>
                    </label>
                    <input
                      type="text"
                      id="fullName"
                      class="form-control"
                      placeholder="Họ tên.."
                      v-model="thongtinDK.hoten"

                      disabled
                      readonly

                      :class="{ 'class-error': validation.fullNameVal }"
                      :title="validation.fullNameValMsg"
                      @blur="
                        tabValidate(
                          'fullName',
                          'Số điện thoại không được để trống.'
                        )
                      "
                      @tab="
                        tabValidate(
                          'fullName',
                          'Số điện thoại không được để trống.'
                        )
                      "
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
                    >
                      <option value="1">Nam</option>
                      <option value="2">Nữ</option>
                      <option value="0">Khác</option>
                    </select>
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
                    <label for="SDT"
                      >Số điện thoại <span style="color: #ff0000">*</span>
                    </label>
                    <input
                      type="text"
                      id="phonenumber"
                      class="form-control"
                      v-model="thongtinDK.sodienthoai"
                      :class="{ 'class-error': validation.sdtVal }"
                      :title="validation.sdtValMsg"
                      @blur="
                        tabValidate(
                          'phonenumber',
                          'Số điện thoại không được để trống.'
                        )
                      "
                      @tab="
                        tabValidate(
                          'phonenumber',
                          'Số điện thoại không được để trống.'
                        )
                      "
                    />
                  </div>
                  <div class="col-sm-12 py-2 wow fadeInRight">
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

          <v-btn text  @click="hide()"> Hủy </v-btn>
        </v-stepper-content>
        <v-stepper-content step="2">
          <v-card class="mb-12" color="	#FFFFFF" height="400" >
            <div class="container">
              <h4>SÀNG LỌC TRƯỚC KHI TIÊM</h4>

              <v-simple-table fixed-header height="340">
                <template v-slot:default>
                  <thead>
                    <tr>
                      <th class="text-left col-sm-8"><h7>Câu hỏi</h7></th>
                      <th class="text-left"><h7></h7></th>
                    </tr>
                  </thead>
                  <tbody>
                    <tr>
                      <td>
                        1. Tiền sử phản vệ, sốc mạnh sau lần tiêm chủng trước
                      </td>
                      <td>
                        <v-checkbox
                          class="text-right"
                          v-model="thongtinDK.cauhoi1"
                        ></v-checkbox>
                      </td>
                    </tr>
                    <tr>
                      <td>2. Tiền sử mắc COVID-19 trong 6 tháng qua</td>
                      <td>
                        <v-checkbox
                          class="text-right"
                          v-model="thongtinDK.cauhoi2"
                        ></v-checkbox>
                      </td>
                    </tr>
                    <tr>
                      <td>
                        3. Đang bị suy giảm miễn dịch nặng, ung thư giai đoạn cuối
                        đang điều trị, xạ trị, hóa trị
                      </td>
                      <td>
                        <v-checkbox
                          class="text-right"
                          v-model="thongtinDK.cauhoi3"
                        ></v-checkbox>
                      </td>
                    </tr>
                    <tr>
                      <td>
                        4. Mắc các bệnh bẩm sinh, bệnh mạn tính ở tim, phổi, hệ
                        tiêu hóa, máu,...
                      </td>
                      <td>
                        <v-checkbox
                          class="text-right"
                          v-model="thongtinDK.cauhoi4"
                        ></v-checkbox>
                      </td>
                    </tr>
                    <tr>
                      <td>
                        5. Phụ nữ mang thai, phụ nữ đang nuôi con bằng sữa mẹ
                      </td>
                      <td>
                        <v-checkbox
                          class="text-right"
                          v-model="thongtinDK.cauhoi5"
                        ></v-checkbox>
                      </td>
                    </tr>
                    <tr>
                      <td>6. Tiêm vắc xin khác trong vòng 14 ngày trước</td>
                      <td>
                        <v-checkbox
                          class="text-right"
                          v-model="thongtinDK.cauhoi6"
                        ></v-checkbox>
                      </td>
                    </tr>
                    <tr>
                      <td>
                        7. Trong vòng 14 ngày trước có điều trị corticoid liều cao
                        (tương đương prednisolon ≥ 2 mg/kg/ngày trong ≥ 7 ngày)
                      </td>
                      <td>
                        <v-checkbox
                          class="text-right"
                          v-model="thongtinDK.cauhoi7"
                        ></v-checkbox>
                      </td>
                    </tr>
                    <tr>
                      <td>8. Giảm tiểu cầu và/hoặc rối loạn đông máu.</td>
                      <td>
                        <v-checkbox
                          class="text-right"
                          v-model="thongtinDK.cauhoi8"
                        ></v-checkbox>
                      </td>
                    </tr>
                    <tr>
                      <td>9. Rối loại tri giác, rối loạn hành vi</td>
                      <td>
                        <v-checkbox
                          class="text-right"
                          v-model="thongtinDK.cauhoi9"
                        ></v-checkbox>
                      </td>
                    </tr>
                    <tr>
                      <td>10. Tiền sử dị ứng với bất kì dị nguyên nào</td>
                      <td>
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
          <v-btn color="primary" @click="e1 = 3"> Tiếp tục </v-btn>
          <v-btn text @click="e1 = 1"> Quay lại </v-btn>
          <v-btn text  @click="hide()"> Hủy </v-btn>
        </v-stepper-content>
        <v-stepper-content step="3">
          <v-card class="mb-12" color="	#FFFFFF" >
            <div class="container">
              <h4>THÔNG TIN DỊCH VỤ</h4>
              <form class="contact-form mt-5">
                <div class="row mb-3">
                  <div
                    class="col-12 col-sm-6 py-2 wow fadeInRight"
                    data-wow-delay="300ms"
                  >
                    <label for="subject"
                      >Trung tâm tiêm chủng muốn tiêm
                      <span style="color: #ff0000">*</span></label
                    >
                    <select
                      name="tttiemchung"
                      id="tttiemchung"
                      class="custom-select"
                      v-model="thongtinDK.idtrungtam"
                      :class="{ 'class-error': validation.tttiemchungVal }"
                      :title="validation.tttiemchungValMsg"
                      @blur="
                        tabValidate(
                          'tttiemchung',
                          'Vui lòng chọn Trung tâm tiêm chủng'
                        )
                      "
                      @tab="
                        tabValidate(
                          'tttiemchung',
                          'Vui lòng chọn Trung tâm tiêm chủng muốn tiêm'
                        )
                      "
                    >
                      <option
                        v-for="(record, index) in listTrungTam"
                        :key="index"
                        :value="record.idtrungtam"
                      >
                        {{ record.tentrungtam }}
                      </option>
                    </select>
                  </div>
                  <div
                    class="col-12 col-sm-6 py-2 wow fadeInLeft"
                    data-wow-delay="300ms"
                  >
                    <label for="ngaytiem"
                      >Ngày mong muốn tiêm
                      <span style="color: #ff0000">*</span></label
                    >
                    <input
                      type="date"
                      id="ngaymuontiem"
                      class="form-control"
                      v-model="thongtinDK.ngaydangkytiem"
                      :class="{ 'class-error': validation.ngaymuontiemVal }"
                      :title="validation.ngaymuontiemValMsg"
                      @blur="
                        tabValidate(
                          'ngaymuontiem',
                          'Vui lòng chọn ngày mong muốn tiêm.'
                        )
                      "
                      @tab="
                        tabValidate(
                          'ngaymuontiem',
                          'Vui lòng chọn ngày mong muốn tiêm.'
                        )
                      "
                    />
                  </div>
                  <div class="col-12 py-2 wow fadeInUp" data-wow-delay="300ms">
                    <label for="vacxin"
                      >Loại vắc xin muốn tiêm
                      <span style="color: #ff0000">*</span></label
                    >

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
                                          id="vacxin"
                                          v-model="thongtinDK.danhsachvacxin"
                                          :label="record.tenvacxin"
                                          :value="record.tenvacxin"
                                          :class="{
                                            'class-error': validation.vacxinVal,
                                          }"
                                          :title="validation.vacxinValMsg"
                                          @blur="
                                            tabValidate(
                                              'vacxin',
                                              'Vui lòng chọn vacxin muốn tiêm.'
                                            )
                                          "
                                          @tab="
                                            tabValidate(
                                              'vacxin',
                                              'Vui lòng chọn vacxin muốn tiêm.'
                                            )
                                          "
                                        ></v-checkbox>
                                      </div>
                                      <v-list-item-title class="text-h5 mb-1">
                                        {{ record.giavacxin }} VNĐ
                                      </v-list-item-title>
                                      <v-list-item-subtitle>
                                        {{ record.mota }}</v-list-item-subtitle
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
                                v-for="(record, index) in listRecordGoivacxin"
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
                                          v-model="thongtinDK.danhsachvacxin"
                                          :label="record.tengoi"
                                          :value="record.tengoi"
                                        ></v-checkbox>
                                      </div>
                                      <v-list-item-title class="text-h5 mb-1">
                                        {{ record.dongia }} VNĐ
                                      </v-list-item-title>
                                      <v-list-item-subtitle>
                                        {{ record.mota }}</v-list-item-subtitle
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
                  </div>hide
                </div>
              </form>
            </div>
          </v-card>

          <v-btn color="primary" @click="insertRecord()"> Đăng ký </v-btn>

          <v-btn text @click="e1 = 2"> Quay lại </v-btn>
          <v-btn text  @click="hide()"> Hủy </v-btn>
        </v-stepper-content>
      </v-stepper-items>
    </v-stepper>
    <BaseConfirm ref="baseConfirm" />
  </div>
</template>

<script>
import BaseConfirm from "@/components/common/baseControlAcounting/BaseConfirm";
import axios from "axios";

export default {
  components: {
    BaseConfirm,
  },
  name: "DKTiem",
  props:{
        tenTaiKhoan : String
    },
  data() {
    return {
      e1: 1,
      selected: [""],
      thongtinDK: {},
      defaultthongtinDK: {
        masotiem:"",
        hoten: "",
        ngaysinh: "",
        gioitinh: "",
        sodienthoai: "",
        email: "",
        diachi: "",
        tentrungtam: "",
        ngaydangkytiem: "",
        danhsachvacxin: [],
        danhsachgoivacxin: [],
        nguoitao: "",
        ngaytao: new Date().toISOString(),
        nguoichinhsua: "",
        ngaychinhsua: new Date().toISOString(),
        cauhoi1: false,
        cauhoi2: false,
        cauhoi3: false,
        cauhoi4: false,
        cauhoi5: false,
        cauhoi6: false,
        cauhoi7: false,
        cauhoi8: false,
        cauhoi9: false,
        cauhoi10: false,
      },
      listRecord: [],
      listRecordGoivacxin: [],
      listTrungTam: [],
      Cauhoi: [],
      soTiemByCode: [],

      checkbox1: false,
      checkbox2: false,
      checkbox3: false,
      checkbox4: false,
      checkbox5: false,
      checkbox6: false,
      checkbox7: false,
      checkbox8: false,
      checkbox9: false,
      checkbox10: false,

      validation: {
        emailVal: false,
        emailValMsg: "",
        sdtVal: false,
        sdtValMsg: "",
        fullNameVal: false,
        fullNameValMsg: "",
        tttiemchungVal: false,
        tttiemchungValMsg: "",
        ngaymuontiemVal: false,
        ngaymuontiemValMsg: "",
        vacxinVal: false,
        vacxinValMsg: "",
      },
      stateValidate: true,
      disableMasotiem: false
    };
  },
  created() {
    this.thongtinDK = this.defaultthongtinDK;
    this.getAllRecord();
    this.getAllRecordGoivacxin();
    this.getAllRecordTrungTam();
    this.getRecordSoTiemByCode();
  },

  watch: {
    "thongtinDK.masotiem": async function() {
      console.log(this.thongtinDK.masotiem)
      this.getSoTiemByCode();
    },
  },
  methods: {
    /**
     * Thực hiện thêm mới bản ghi
     * */
    async insertRecord() {
      try {
        let me = this;
        if (this.validateData()) {
          let dsdangky = this.thongtinDK.danhsachvacxin.toString();
          // console.log(dsdangky);
          this.thongtinDK.danhsachvacxin = dsdangky;
          await axios
            .post(
              "http://localhost:64016/api/ThongTinDangKyTiem",
              this.thongtinDK
            )
            .then(() => {
              // me.$refs.loading.hideLoading();
              console.log("106");
              // alert("Đăng ký tiêm thành công !");
              this.$refs.baseConfirm.showForm(
                  "sucess",
                  1,
                  "Đăng ký tiêm thành công !"
                );
              this.$router.push({ name: "dang-ky-tiem" });
              this.resetInput();
            })
            .catch(() => {});
        } else {
          console.log("empty");
          return;
        }
      } catch (error) {
        console.log(error);
      }
    },

    /**
     * Thực hiện lấy toàn bộ bản ghi của sổ tiêm by code
     * */
    async getSoTiemByCode() {
      try {
        await axios
          .get(
            `http://localhost:64016/api/SoTiem/bycode/${this.tenTaiKhoan}`
          )
          .then((response) => {
            if (response.data) {
              var res = response.data.data;
              if (res) {
                console.log(res)
                this.thongtinDK.masotiem = res.masotiem;
                this.thongtinDK.hoten = res.hoten;
                this.thongtinDK.ngaysinh = res.ngaysinh
                this.thongtinDK.ngaysinh = this.formatDate(this.thongtinDK.ngaysinh);
                this.thongtinDK.gioitinh = res.gioitinh;
                this.thongtinDK.email = res.email;
                this.thongtinDK.sodienthoai = res.sodienthoai;
                this.thongtinDK.diachi = res.diachi;

              }
            }
          })
          .catch(() => {});
      } catch (error) {
        console.log(error);
      }
    },

    /**
     * Thực hiện lấy toàn bộ bản ghi của Vacxin
     * * CreatedBy: linhhn
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
     * Thực hiện lấy toàn bộ bản ghi của gói Vacxin
     * * CreatedBy: linhhn
     * */
    async getAllRecordGoivacxin() {
      try {
        var me = this;
        await axios
          .get("http://localhost:64016/api/GoiVacxin")
          .then((response) => {
            me.listRecordGoivacxin = response.data.data;
            me.totalRecord = response.data.length;
          })
          .catch(() => {});
      } catch (error) {
        console.log(error);
      }
    },
    /**
     * Thực hiện lấy toàn bộ bản ghi của Trung tâm tiêm chủng
     * * CreatedBy: linhhn
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
  
     // todo reset lại các input
    resetInput() {
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
    },
    /**
     * Thực hiện validate input bị trống
     * CreatedBy: nctu2
     * editBy : Linhhn
     * */
    tabValidate(id, message) {
      if (id == "emailAddress") {
        console.log("email");
        if (!this.thongtinDK.email) {
          this.validation.emailVal = true;
          this.emailValMsg = message;
        }
      } else if (id == "phonenumber") {
        console.log("sodienthoai");
        if (!this.thongtinDK.sodienthoai) {
          this.validation.sdtVal = true;
          this.sdtValMsg = message;
        }
      } else if (id == "fullName") {
        console.log("Hoten");
        if (!this.thongtinDK.hoten) {
          this.validation.fullNameVal = true;
          this.fullNameValMsg = message;
        }
      } else if (id == "tttiemchung") {
        console.log("tttiemchung");
        if (!this.thongtinDK.idtrungtam) {
          this.validation.tttiemchungVal = true;
          this.tttiemchungValMsg = message;
        }
      } else if (id == "ngaymuontiem") {
        console.log("ngaymuontiem");
        if (!this.thongtinDK.ngaydangkytiem) {
          this.validation.ngaymuontiemVal = true;
          this.ngaymuontiemValMsg = message;
        }
      } else if (id == "vacxin") {
        console.log("vacxin");
        if (!this.thongtinDK.danhsachvacxin) {
          this.validation.vacxinVal = true;
          this.vacxinValMsg = message;
        }
      }
    },

    /**
     * Thực hiện validate email không được bỏ trống
     * CreatedBy: nctu
     * */
    validateEmail() {
      var formatEmail = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(
        this.thongtinDK.email
      );
      console.log(formatEmail);
      if (!this.thongtinDK.email) {
        this.$refs.baseConfirm.showForm(
          "error",
          1,
          "Email không được để trống"
        );
        this.stateValidate = false;
        return false;
      } else if (!formatEmail) {
        this.$refs.baseConfirm.showForm(
          "error",
          1,
          "Vui lòng nhập đúng định dạng email"
        );
        this.stateValidate = false;
        return false;
      } else {
        this.stateValidate = true;
        return true;
      }
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
     * Thực hiện validate số điện thoại không được bỏ trống
     * CreatedBy: linhhn
     * */
    validateSDT() {
       var formatSDT =/^((\+)33|0)[1-9](\d{2}){4}$/.test(
        this.thongtinDK.sodienthoai
      );
      if (!this.thongtinDK.sodienthoai) {
        this.$refs.baseConfirm.showForm(
          "error",
          1,
          "Số điện thoại không được để trống"
        );
        this.stateValidate = false;
        return false;
      } else if (!formatSDT) {
        this.$refs.baseConfirm.showForm(
          "error",
          1,
          "Vui lòng nhập đúng định dạng Số điện thoại"
        );
        this.stateValidate = false;
        return false;
      }
      else {
        this.stateValidate = true;
        return true;
      }
    },
    /**
     * Thực hiện validate họ tên không được bỏ trống
     * CreatedBy: linhhn
     * */
    validatefullName() {
      if (!this.thongtinDK.hoten) {
        this.$refs.baseConfirm.showForm(
          "error",
          1,
          "Họ tên không được để trống"
        );
        this.stateValidate = false;
        return false;
      } else {
        this.stateValidate = true;
        return true;
      }
    },
    /**
     * Thực hiện validate trung tâm tiêm chủng không được bỏ trống
     * CreatedBy: linhhn
     * */
    validatetttiemchung() {
      if (!this.thongtinDK.idtrungtam) {
        this.$refs.baseConfirm.showForm(
          "error",
          1,
          "Vui lòng chọn Trung tâm tiêm chủng muốn tiêm"
        );
        this.stateValidate = false;
        return false;
      } else {
        this.stateValidate = true;
        return true;
      }
    },

    /**
     * Thực hiện validate ngày mong muốn tiêm không được bỏ trống
     * CreatedBy: linhhn
     * */
    validatengaymuontiem() {
      if (!this.thongtinDK.ngaydangkytiem) {
        this.$refs.baseConfirm.showForm(
          "error",
          1,
          "Vui lòng nhập ngày mong muốn tiêm"
        );
        this.stateValidate = false;
        return false;
      } else {
        this.stateValidate = true;
        return true;
      }
    },
    /**
     * Thực hiện validate vacxin muốn tiêm không được bỏ trống
     * CreatedBy: linhhn
     * */
    validatevacxin() {
      if (!this.thongtinDK.danhsachvacxin) {
        this.$refs.baseConfirm.showForm(
          "error",
          1,
          "Vui lòng chọn vacxin mong muốn tiêm"
        );
        this.stateValidate = false;
        return false;
      } else {
        this.stateValidate = true;
        return true;
      }
    },

    validateData() {
      this.validateEmail();
      this.validateSDT();
      this.validatefullName();
      this.validatetttiemchung();
      this.validatengaymuontiem();
      this.validatevacxin();
      if (
        this.validateEmail() &&
        this.validateSDT() &&
        this.validatefullName() &&
        this.validatetttiemchung() &&
        this.validatengaymuontiem() &&
        this.validatevacxin()
      ){
        return true
      }
      else{
        return false
      }
      
    },
    
    // todo ẩn dialog
    hide() {
      this.isActive = false;
      this.resetInput();
      this.$router.push({ name: "dang-ky-tiem" });
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
  },
};
</script>

<style>
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
</style>
