<template>
  <div>
    <div
      class="page-banner overlay-dark bg-image"
      style="background-image: url(../assets/img/bg_image_1.jpg)"
    >
      <div class="banner-section">
        <div class="container text-center wow fadeInUp">
          <h3 class="font-weight-normal">SỔ TIÊM CHỦNG CÁ NHÂN</h3>
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
                Trang cá nhân
              </li>
            </ol>
          </nav>
        </div>
        <!-- .container -->
      </div>
      <!-- .banner-section -->
    </div>
    <v-tabs v-model="tab">
      <v-tab>
        <h10>THÔNG TIN CÁ NHÂN</h10>
      </v-tab>
      <v-tab>
        <h10>LỊCH SỬ TIÊM CHỦNG</h10>
      </v-tab>
      <v-tab @click="getInjectionRegister('')">
        <h10>DANH SÁCH VACXIN ĐÃ ĐĂNG KÝ TIÊM</h10>
      </v-tab>
    </v-tabs>
    <v-tabs-items v-model="tab">
      <v-tab-item>
        <div class="container">
          <div class="row">
            <div class="col-sm-9">
              <form class="contact-form mt-5">
                <div class="row mb-3">
                  <div class="col-sm-6 py-2 wow">
                    <label for="fullName"
                      >Mã sổ tiêm <span style="color: #ff0000">*</span>
                    </label>
                    <input
                      type="text"
                      id="masotiem"
                      class="form-control"
                      placeholder=""
                      v-model="sotiem.masotiem"
                      :disabled="disableMasotiem"
                      readonly
                    />
                  </div>

                  <div class="col-sm-6 py-2 wow">
                    <label for="fullName"
                      >Họ tên <span style="color: #ff0000">*</span>
                    </label>
                    <input
                      type="text"
                      id="fullName"
                      class="form-control"
                      placeholder="Họ tên.."
                      v-model="sotiem.hoten"
                      readonly
                      disabled
                      :class="{ 'class-error': validation.fullNameVal }"
                      :title="validation.fullNameValMsg"
                      @blur="
                        tabValidate('fullName', 'Họ tên không được để trống.')
                      "
                      @tab="
                        tabValidate('fullName', 'Họ tên không được để trống.')
                      "
                    />
                  </div>
                  <div class="col-sm-6 py-2 wow" data-wow-delay="300ms">
                    <label for="date">Ngày sinh </label>
                    <input
                      type="date"
                      class="form-control"
                      v-model="sotiem.ngaysinh"
                    />
                  </div>
                  <div class="col-sm-6 py-2 wow" data-wow-delay="300ms">
                    <label for="subject">Giới tính</label>
                    <select
                      name="gt"
                      id="gt"
                      class="custom-select"
                      v-model="sotiem.gioitinh"
                    >
                      <option value="1">Nam</option>
                      <option value="2">Nữ</option>
                      <option value="0">Khác</option>
                    </select>
                  </div>
                  <div class="col-sm-6 py-2 wow">
                    <label for="emailAddress"
                      >Email <span style="color: #ff0000">*</span></label
                    >
                    <input
                      type="email"
                      id="emailAddress"
                      class="form-control"
                      placeholder="Nhập địa chỉ email"
                      v-model="sotiem.email"
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
                  <div class="col-sm-6 py-2 wow" data-wow-delay="300ms">
                    <label for="SDT"
                      >Số điện thoại <span style="color: #ff0000">*</span>
                    </label>
                    <input
                      type="text"
                      id="phonenumber"
                      class="form-control"
                      v-model="sotiem.sodienthoai"
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
                  <div class="col-sm-6 py-2 wow" data-wow-delay="300ms">
                    <label for="CMND"
                      >CMND <span style="color: #ff0000"></span>
                    </label>
                    <input
                      type="text"
                      id="cmnd"
                      class="form-control"
                      v-model="sotiem.cmnd"
                    />
                  </div>
                  <div class="col-sm-6 py-2 wow" data-wow-delay="300ms">
                    <label for="tuoi"
                      >Tuổi <span style="color: #ff0000"></span>
                    </label>
                    <input
                      type="text"
                      id="tuoi"
                      class="form-control"
                      v-model="sotiem.tuoi"
                    />
                  </div>
                  <div class="col-sm-12 py-2 wow">
                    <label for="diachi">Địa chỉ</label>
                    <input
                      type="text"
                      id="diachi"
                      class="form-control"
                      placeholder="Địa chỉ.."
                      v-model="sotiem.diachi"
                    />
                  </div>
                  <div
                    class="py-2 wow btn btn-primary"
                    @click="updateRecord('')"
                    style="height: 45px"
                  >
                    Cập nhật thông tin
                  </div>
                </div>
              </form>
            </div>
            <div class="col-sm-3">
              <form class="contact-form mt-5">
                <div class="row mb-3">
                  <div class="col-sm-12 py-2 wow fadeInright">
                    <label for="fullName"></label>
                    <vue-qr
                      :bgSrc="src"
                      :logoSrc="src2"
                      :text="
                        sotiem.masotiem +
                        sotiem.hoten +
                        sotiem.sodienthoai +
                        sotiem.email +
                        sotiem.cmnd
                      "
                      :size="200"
                    ></vue-qr>
                  </div>
                </div>
              </form>
            </div>
          </div>
        </div>
      </v-tab-item>

      <v-tab-item>
        <BaseConfirm ref="baseConfirm" />
        <LSTiemChung :maSoTiem="sotiem.masotiem" />
      </v-tab-item>
      <v-tab-item>
        <div>
          <div class="injection-register content">
            <div class="container">
              <div class="content-nav">
                <div class="features-pane">
                  <div class="features-pane-left">
                    <input
                      id="assetSearchBox"
                      class="input-search"
                      type="text"
                      placeholder="Tìm kiếm... "
                      v-model="inputSearch"
                      @change="getInjectionRegister('filter')"
                    />
                    <div class="icon-search" title="Tìm kiếm"></div>
                  </div>

                  <div class="features-pane-right">
                    <div
                      class="btn-add-asset btn features-pane-item"
                      @click="$router.push({ name: 'dang-ky-tiem' })"
                    >
                      Thêm
                    </div>

                    <div
                      @click="getInjectionRegister('')"
                      class="btn icon-refresh features-pane-item"
                      title="Tải lại"
                    ></div>
                    <!-- <div
              id="preventLeftClick"
              class="btn icon-trash features-pane-item"
              @click="showDeleteDialog()"
              title="Xóa nhiều bản ghi"
            ></div> -->
                  </div>
                </div>

                <div class="clear-float"></div>
              </div>

              <div id="loadBar"></div>
              <div class="content-grid grid" oncontextmenu="return false;">
                <table class="table-asset" id="tableAsset">
                  <colgroup>
                    <col width="50" />
                    <!-- <col width="120" /> -->
                    <col min-width="400" />
                    <col min-width="400" />
                    <col min-width="200" />
                    <col min-width="100" />
                    <col min-width="100" />
                  </colgroup>
                  <thead>
                    <tr>
                      <th style="text-align: center">STT</th>
                      <th
                        sortProp="price"
                        sortOrder="asc"
                        id="columnPrice"
                        class="hover-pointer"
                        style="text-align: center"
                      >
                        Danh sách vắc xin đã đăng ký
                      </th>
                      <th
                        sortProp="department"
                        sortOrder="asc"
                        id="columnDepartment"
                        class="hover-pointer"
                        style="text-align: center"
                      >
                        Ngày đăng ký tiêm
                      </th>
                      <th
                        sortProp="department"
                        sortOrder="asc"
                        id="columnDepartment"
                        class="hover-pointer"
                        style="text-align: center"
                      >
                        Địa chỉ đăng ký tiêm
                      </th>

                      <th style="text-align: left">Trạng thái</th>
                      
                    </tr>
                  </thead>

                  <tbody>
                    <tr
                      v-for="(TTDangKy, index) in listTTDangKy"
                      :key="TTDangKy.iddangky"
                      v-bind:class="
                        selectedRow(TTDangKy.iddangky) ? 'selected-row' : ''
                      "
                      @click="selectRow(TTDangKy.iddangky, $event)"
                      @click.right="showContexMenu(TTDangKy, $event)"
                      @dblclick="showDialog('update', TTDangKy.iddangky)"
                    >
                      <td class="no-border-left">{{ index + 1 }}</td>
                      <td>{{ TTDangKy.danhsachvacxin }}</td>

                      <td>
                        {{
                          TTDangKy.ngaydangkytiem
                            | formatDate(TTDangKy.ngaydangkytiem)
                        }}
                      </td>
                      <td>{{ TTDangKy.tentrungtam }}</td>
                      <td>
                        {{
                          TTDangKy.trangthai | formatStatus(TTDangKy.trangthai)
                        }}
                      </td>
                    
                    </tr>
                  </tbody>
                  <BaseLoading ref="loadingTTDKT_reft" />
                </table>
                <div class="ctx-menu" id="ctxMenu">
                  <div class="ctx-menu-item" @click="$router.push({ name: 'dang-ky-tiem' })">
                    Thêm
                  </div>
                  <div
                    class="ctx-menu-item"
                    @click="updateDKTiem(listSelectRow[0])"
                  >
                    Hủy đăng ký
                  </div>
                  <!-- <div
            id="preventLeftClick"
            class="ctx-menu-item"
            @click="showDeleteDialog(listSelectRow[0])"
          >
            Xóa
          </div> -->
                </div>
              </div>

              <div id="assetPopup"></div>
            </div>
            <InjectionRegisterDetail
              ref="ModalCreateInjectionRegister_ref"
              :formMode="formMode"
              :idDangKyUpdate="idDangKyUpdate"
              @reload="reload"
              @msgAlert="msgAlert"
            />
          </div>
        </div>
      </v-tab-item>
    </v-tabs-items>
    <BaseConfirm ref="baseConfirm" />
  </div>
</template>

<script>
import LSTiemChung from "./LSTiemChung.vue";
import { trangthai, gioitinh } from "../enumeration/enumaration.js";
import BaseConfirm from "@/components/common/baseControlAcounting/BaseConfirm";
import axios from "axios";
import BaseLoading from "../components/common/BaseLoading.vue";
import VueQr from "vue-qr";

// Vue.component('qr-code', VueQRCodeComponent)

export default {
  name: "TrangCaNhan",
  components: {
    BaseLoading,
    BaseConfirm,
    VueQr,
    LSTiemChung,
  },
 props:{
        tenTaiKhoan : String
    },
  data() {
    return {
      tab: null,
      listTTDangKy: [],
      TTDangKy: {
        iddangky: null,
        hoten: null,
        ngaysinh: null,
        gioitinh: null,
        diachi: null,
        email: null,
        sodienthoai: null,
        tentrungtam: null,
        ngaydangkytiem: null,
        danhsachvacxin: null,
      },

      thongtinDK: {},
      defaultthongtinDK: {
        masotiem: "",
        hoten: "",
        ngaysinh: "",
        gioitinh: "",
        sodienthoai: "",
        email: "",
        diachi: "",
        tentrungtam: "",
        ngaydangkytiem: "",
        danhsachvacxin: [],
        nguoitao: "",
        ngaytao: new Date().toISOString(),
        nguoichinhsua: "",
        ngaychinhsua: new Date().toISOString(),
      },
      sotiem: {},
      TTDangKySelected: {},
      defaultsotiem: {
        idsotiem: "",
        masotiem: "",
        hoten: "",
        ngaysinh: "",
        gioitinh: "",
        sodienthoai: "",
        cmnd: "",
        email: "",
        diachi: "",
        tuoi: "",
        nguoitao: "",
        ngaytao: new Date().toISOString(),
        nguoichinhsua: "",
        ngaychinhsua: new Date().toISOString(),
      },

      formMode: "",
      alerMsg: "",

      idDangKyUpdate: null,
      listSelectRow: [],
      listIdDangKy: [],
      inputSearch: "",
      showSuccess: false,
      isError: false,
      getSuccess: true,
      getEmty: false,
      //   totalPrice: 0,
      amountTTDangKy: 0,
      showWarning: false,
      paging: {
        amountPage: 1,
        pageNumber: 1,
        recordNumber: 50,
        totalRecord: 0,
        startRecord: 0,
        endRecord: 0,
      },
      showMenuFilter: true,
      showMenuType: false,
      showMenuDepartment: true,
      disableMasotiem: false,

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
      allowEdit: false,
    };
  },
  timing: {
    scale: 1,
    protectors: false,
  },
  alignment: {
    scale: 1,
    protectors: false,
  },
  cornerAlignment: {
    scale: 1,
    protectors: true,
  },

  computed: {
    formTitle() {
      return this.editedIndex === -1 ? "New Item" : "Edit Item";
    },
  },

  created() {
    this.thongtinDK = this.defaultthongtinDK;
    this.sotiem = this.defaultsotiem;
    // this.getInjectionRegister();
    this.processkey();
  },
  mounted() {
    this.getInjectionRegister();
    this.hideContextMenu();
    this.updateRecord();
  },
  watch: {
    "sotiem.masotiem": async function () {
      console.log(this.sotiem.masotiem);
      this.getSoTiemByMaSoTiem();
    },
  },

  methods: {
    /**
     * Thực hiện lấy bản ghi của sổ tiêm theo mã sổ tiêm
     * */
    async getSoTiemByMaSoTiem() {
      try {
        await axios
          .get(`http://localhost:64016/api/SoTiem/bycode/${this.tenTaiKhoan}`)
          .then((response) => {
            if (response.data) {
              var res = response.data.data;
              if (res) {
                console.log(res);
                this.sotiem.idsotiem = res.idsotiem;
                this.sotiem.masotiem = res.masotiem;
                this.sotiem.hoten = res.hoten;
                this.sotiem.ngaysinh = res.ngaysinh;
                this.sotiem.ngaysinh = this.formatDate(this.sotiem.ngaysinh);
                this.sotiem.gioitinh = res.gioitinh;
                // this.sotiem.gioitinh = this.formatGt(this.sotiem.gioitinh);
                this.sotiem.email = res.email;
                this.sotiem.sodienthoai = res.sodienthoai;
                this.sotiem.cmnd = res.cmnd;
                this.sotiem.diachi = res.diachi;
                this.sotiem.tuoi = res.tuoi;
              }
            }
          })
          .catch(() => {});
      } catch (error) {
        console.log(error);
      }
    },

    /**
     * Thực hiện Cập nhật thông tin cá nhân
     * */
    async updateRecord() {
      try {
        let me = this;
        await axios
          .put(
            `http://localhost:64016/api/SoTiem/${this.sotiem.idsotiem}`,
            this.sotiem
          )
          .then(() => {
            // alert("Cập nhật thông tin thành công !");
            this.$refs.baseConfirm.showForm(
              "success",
              1,
              "Cập nhật thông tin thành công !"
            );
            this.$router.push({ name: "trang-ca-nhan" });
          })
          .catch(() => {});
      } catch (error) {
        console.log(error);
      }
    },

    /**
     * Thực hiện hủy thông tin đăng ký tiêm
     * */
    async updateDKTiem(Id) {
      try {
        if (Id === this.TTDangKySelected.iddangky) {
          this.TTDangKySelected.trangthai = 0;

          await axios
            .put(
              `http://localhost:64016/api/ThongTinDangKyTiem/${this.TTDangKySelected.iddangky}`,
              this.TTDangKySelected
            )
            .then(() => {
              this.$refs.baseConfirm.showForm(
                "success",
                1,
                "Hủy đăng ký tiêm thành công !"
              );
              this.$router.push({ name: "trang-ca-nhan" });
            })
            .catch(() => {});
        }
      } catch (error) {
        console.log(error);
      }
    },
    /**
     * Thực hiện lấy thông tin đăng ký tiêm theo số điện thoại
     * * CreatedBy: linhhn
     * */
    async getInjectionRegister(text) {
      if (text == "filter") {
        this.paging.pageNumber = 1;
      }
      var me = this;

      await axios
        .get(
          `http://localhost:64016/api/ThongTinDangKyTiem/bycode/${this.tenTaiKhoan}`
        )
        .then((response) => {
          if (response.data) {
            me.listTTDangKy = response.data.data;

            if (me.listTTDangKy.length == 0) {
              me.getEmty = true;
            }

            me.$refs.loadingTTDKT_reft.hide();
            me.listIdDangKy = [];
            me.paging.amountPage = response.data.totalPage;

            me.listTTDangKy.forEach((element) => {
              // duyệt qua tất cả các bản ghi
              me.listIdDangKy.push(element.iddangky); // push tất cả id vào mảng
              me.amountTTDangKy++; // đếm tổng số bản ghi
            });
          }
        })
        .catch((error) => {
          this.errorMessage = error.message;
          // console.error("GET ThongTinDangKy Failed: ", error.message);
          setTimeout(() => {
            me.$refs.loadingTTDKT_reft.hide(); // tắt dialog loading
            me.getEmty = true;
          }, 4000);
        });
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
        if (!this.sotiem.email) {
          this.validation.emailVal = true;
          this.emailValMsg = message;
        }
      } else if (id == "phonenumber") {
        console.log("sodienthoai");
        if (!this.sotiem.sodienthoai) {
          this.validation.sdtVal = true;
          this.sdtValMsg = message;
        }
      } else if (id == "fullName") {
        console.log("Hoten");
        if (!this.sotiem.hoten) {
          this.validation.fullNameVal = true;
          this.fullNameValMsg = message;
        }
      } else if (id == "tttiemchung") {
        console.log("tttiemchung");
        if (!this.sotiem.idtrungtam) {
          this.validation.tttiemchungVal = true;
          this.tttiemchungValMsg = message;
        }
      } else if (id == "ngaymuontiem") {
        console.log("ngaymuontiem");
        if (!this.sotiem.ngaydangkytiem) {
          this.validation.ngaymuontiemVal = true;
          this.ngaymuontiemValMsg = message;
        }
      } else if (id == "vacxin") {
        console.log("vacxin");
        if (!this.sotiem.danhsachvacxin) {
          this.validation.vacxinVal = true;
          this.vacxinValMsg = message;
        }
      }
    },
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
     * Thực hiện validate email không được bỏ trống
     * CreatedBy: nctu
     * */
    validateEmail() {
      var formatEmail = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(
        this.sotiem.email
      );
      console.log(formatEmail);
      if (!this.sotiem.email) {
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

    /**
     * Thực hiện validate số điện thoại không được bỏ trống
     * CreatedBy: linhhn
     * */
    validateSDT() {
      var formatSDT = /^((\+)33|0)[1-9](\d{2}){4}$/.test(
        this.sotiem.sodienthoai
      );
      if (!this.sotiem.sodienthoai) {
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
      } else {
        this.stateValidate = true;
        return true;
      }
    },
    /**
     * Thực hiện validate họ tên không được bỏ trống
     * CreatedBy: linhhn
     * */
    validatefullName() {
      if (!this.sotiem.hoten) {
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

    validateData() {
      this.validateEmail();
      this.validateSDT();
      this.validatefullName();

      if (
        this.validateEmail() &&
        this.validateSDT() &&
        this.validatefullName()
      ) {
        return true;
      } else {
        return false;
      }
    },

    test(dataUrl, id) {
      console.log(url, id);
    },
    msgAlert(text, value) {
      this.showWarning = value;
      this.alerMsg = text;
      var res = this;

      setTimeout(() => {
        res.showWarning = false;
      }, 3000);
    },

    /// todo hiển thị dialog thêm
    showDialog(text, Id) {
      // if (document.getElementById("ctxMenu") != null)
      //   document.getElementById("ctxMenu").style.display = "none";
      if (text == "insert") {
        this.formMode = "insert";
        this.alerMsg = "Thêm mới thành công";
      } else {
        this.formMode = "update";
        this.alerMsg = "Cập nhật thành công";
        this.idDangKyUpdate = Id;
      }
      console.log("showw");
      setTimeout(() => {
        this.$refs.ModalCreateInjectionRegister_ref.show();
        console.log("showwư");
      }, 300);
      // debugger; // eslint-disable-line no-debugger
    },

    // todo tải lại dữ liệu
    reload(value) {
      if (value == true) {
        this.getInjectionRegister("");
        this.showSuccess = true;
        setTimeout(() => {
          this.showSuccess = false;
        }, 3000);
      }
    },

    //todo hiển thị form xác nhận xóa
    showDeleteDialog(text) {
      // var res = this
      this.alerMsg = "Xóa thành công!";
      if (text != "inRow" && this.listSelectRow.length == 0) {
        this.showWarning = true;
        this.alerMsg = "Vui lòng chọn bản ghi";
      } else {
        this.$refs.ModalDeleteAsset_ref.show();
        this.showWarning = false;
      }
      setTimeout(() => {
        this.showWarning = false;
      }, 3000);
    },

    //  select hàng, nếu hàng đã được select thì xóa khỏi mẩng listSelectRow, và ngược lại
    selectRow(id, event) {
      if (event.ctrlKey == false && event.shiftKey == false) {
        this.listSelectRow = [];
        this.listSelectRow.push(id);
      } else if (event.shiftKey) {
        var idFirst = this.listSelectRow[0];
        this.listSelectRow = [];
        this.listSelectRow.push(idFirst);

        // vị trí đầu tiên trong mảng listSelectRow
        var idStart = this.listSelectRow[0];
        var indexStart = this.listIdDangKy.indexOf(idStart);

        var indexEnd = this.listIdDangKy.indexOf(id);
        if (indexStart > indexEnd) {
          indexStart--;
          var tem = indexStart;
          indexStart = indexEnd;
          indexEnd = tem;
        } else {
          indexStart++;
        }
        for (var i = indexStart; i <= indexEnd; i++) {
          this.listSelectRow.push(this.listIdDangKy[i]);
        }
      } else if (event.ctrlKey) {
        var index = this.listSelectRow.indexOf(id);
        if (index > -1) {
          this.listSelectRow.splice(index, 1);
        } else {
          this.listSelectRow.push(id);
        }
      }
    },

    // kiểm tra hàng đã được select hay chưa
    selectedRow(id) {
      if (this.listSelectRow.indexOf(id) > -1) return true;
      else return false;
    },

    // todo xử lý sự kiện mũi tên lên xuống để select row
    processkey() {
      var res = this;
      document.addEventListener("keydown", function (e) {
        var len1 = res.listSelectRow.length; // số phần tử của mảng listSelectRow
        var len2 = res.listIdDangKy.length; //số phần tử của mảng listIdDangKy
        switch (e.keyCode) {
          case 38:
            {
              //up arrow
              if (
                len1 == 0 ||
                res.listIdDangKy.indexOf(res.listSelectRow[0]) == 0
              ) {
                res.listSelectRow = [];
                res.listSelectRow.push(res.listIdDangKy[len2 - 1]);
              } else if (len1 > 0) {
                //res.listSelectRow = [];
                var indexIdFirst = res.listIdDangKy.indexOf(
                  res.listSelectRow[0]
                );
                res.listSelectRow = [];
                res.listSelectRow.push(res.listIdDangKy[indexIdFirst - 1]);
              }
            }
            break;
          case 40:
            {
              // //down arrow
              if (
                len1 == 0 ||
                res.listIdDangKy.indexOf(res.listSelectRow[len1 - 1]) ==
                  len2 - 1
              ) {
                res.listSelectRow = [];
                res.listSelectRow.push(res.listIdDangKy[0]);
              } else if (len1 > 0) {
                //res.listSelectRow = [];
                var indexIdLast = res.listIdDangKy.indexOf(
                  res.listSelectRow[len1 - 1]
                );
                res.listSelectRow = [];
                res.listSelectRow.push(res.listIdDangKy[indexIdLast + 1]);
              }
            }
            break;
          case 37:
            {
              res.backPage();
            }
            break;
          case 39:
            {
              res.nextPage();
            }
            break;
          default: {
            return true;
          }
        }
      });
    },

    // todo hiện và thao tác với context menu
    showContexMenu(ttdangky, e) {
      this.listSelectRow = [];
      this.listSelectRow.push(ttdangky.iddangky);
      this.TTDangKySelected = ttdangky;
      var ctx = document.getElementById("ctxMenu");
      ctx.style.display = "block";
      ctx.style.top = (e.screenY - 70).toFixed() + "px";
      ctx.style.left = e.screenX.toFixed() + "px";
    },

    // todo chuyển đến trang sau
    nextPage() {
      if (this.paging.pageNumber < this.paging.amountPage) {
        this.paging.pageNumber++;
        this.getInjectionRegister();
      }
    },
    // todo chuyển đến trang trước
    backPage() {
      if (this.paging.pageNumber > 1) {
        this.paging.pageNumber--;
        this.getInjectionRegister();
      }
    },
    hideContextMenu() {
      document.addEventListener("click", function () {
        if (document.getElementById("ctxMenu") != null)
          document.getElementById("ctxMenu").style.display = "none";
      });
    },
    lastPage() {
      this.paging.pageNumber = this.paging.amountPage;
      this.getInjectionRegister();
    },
    firstPage() {
      this.paging.pageNumber = 1;
      this.getInjectionRegister();
    },
    reloadPage() {
      if (
        parseInt(this.paging.pageNumber) <= this.paging.amountPage &&
        parseInt(this.paging.pageNumber) > 0
      ) {
        this.getInjectionRegister();
      } else alert("Trang không hợp lệ");
    },
  },
  filters: {
    formatStatus(status) {
      var statusDisplay = "";
      if (trangthai && status !== null) {
        statusDisplay = trangthai[status.toString()];
      }
      return statusDisplay;
    },
    formatGt(gt) {
      var gtDisplay = "";
      if (gioitinh && gt !== null) {
        gtDisplay = gioitinh[gt.toString()];
      }
      return gtDisplay;
    },
  },
};
</script>

<style lang="scss" scoped>
@import url(../style/scss/icon.scss);
@import url(../style/scss/button.scss);
#assetPopup {
  padding: 0 40px;
  height: 80px;
  background-color: #b1fdb3;
  color: black;
  font-size: 16px;
  border-left: 10px solid #e2f2ff;
  display: flex;
  padding-left: 26px;
  align-items: center;
  position: absolute;
  right: -500px;
  bottom: 80px;
  transition: right 1s;
}
#ctxMenu {
  background-color: white;
  position: fixed;
  z-index: 100;
  // display: none;
}

.ctx-menu {
  font-size: 14px;
  box-shadow: 2px 2px 4px grey;
  display: none;

  .ctx-menu-item {
    padding: 8px 34px 8px 18px;

    &:hover {
      background-color: #5973b3;
      cursor: pointer;
    }
  }
}
//TODO DATETIME theo định dạng d/m/y, bỏ chọn thời gian
//TODO Sử dụng được phím tab trong nhập liệu
//TODO Thay đổi font chữ của datetimepicker
//TODO Thêm khách hàng thành công;
#loadBar {
  width: 0;
  height: 3px;
  background-color: #00abfe;
  transition: 0.5s;
  margin-top: 8px;
  display: none;
  position: absolute;
}

.content-nav {
  height: 70px;
  padding: 16px;
  box-sizing: border-box;

  .features-pane {
    display: flex;
    position: relative;
    align-items: center;
    margin: 10px 0;
    // width: 100%;
    padding-right: 10px;
    font-size: 14px;

    input {
      height: 34px;
      width: 320px;
      box-sizing: border-box;
    }
    .btn {
      height: 34px;
    }
    .btn-add-asset.btn {
      //   background-color: white;
      border: #e9e9e9 1px solid;
      font-size: 14px;
      padding: 0px 14px;
      border-radius: 4px;
      box-sizing: border-box;
      display: flex;
      align-items: center;
      height: 38px;
    }

    .btn-add-asset {
      padding: 0 36px;
      color: white;
      background-color: #00abfe;
      border: none;
    }

    .btn.btn-add-asset:hover,
    .btn.btn-save:hover {
      background-color: #29b8ff;
    }
    .btn-search {
      margin-left: 10px;
    }

    .features-pane-right {
      position: absolute;
      right: 0;

      .icon-refresh {
        background-image: url("../assets/UI/Icon/refresh.svg");
        background-repeat: no-repeat;
        background-size: 22px 22px;
        background-position: center;
        width: 40px;
        height: 40px;
      }

      .icon-trash {
        background-repeat: no-repeat;
        background-size: 20px 20px;
        background-position: center;
        width: 40px;
        height: 40px;
        padding: 6px;
        background: url(/img/qlts-icon.d656886f.svg) no-repeat -454px -104px;
      }
      // background-color:lightsalmon;
      display: flex;
      .features-pane-item {
        margin: 0px 5px;
      }
    }

    .features-pane-left {
      display: flex;
      align-items: center;
      .icon-search {
        position: relative;
        right: 45px;

        &:hover {
          cursor: pointer;
          //TODO sau này thêm action tìm kiếm vào đây
        }
      }
    }
  }
}

.content-grid {
  margin: 16px 16px 16px 16px;
  height: calc(100% - 149px);
  position: relative;
  overflow: auto;
  box-sizing: border-box;
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

  .price-number {
    position: absolute;
    //TODO sẽ phải sửa lại cái này cho chuẩn với cột nguyên giá
    right: 120px;
  }
}

.content-nav {
  padding-top: 26px;
  padding-bottom: 6px;
}
.content-nav .features-pane {
  margin: 0px;
}
.div-container {
  position: relative;
}
.table-summary {
  font-size: 14px;
  font-family: GoogleSans-Medium;
  display: flex;
  /* position: relative; */
  position: absolute;
  bottom: 0px;
  /* margin: 18px 16px 0 16px; */
  height: 63px;
}

.content-grid {
  margin: 16px 16px 16px 16px;
  height: calc(100% - 165px);
  /* height: 100%; */
  position: relative;
  overflow: auto;
  box-sizing: border-box;
}
.table-summary {
  font-size: 14px;
  font-family: GoogleSans-Medium;
  display: flex;
  /* position: relative; */
  width: 100%;
  position: absolute;
  bottom: 0px;
  /* align-items: center; */
  /* margin: 18px 16px 0 16px; */
  height: 63px;
  padding: 18px 16px;
  box-sizing: border-box;
}
.table-summary .summary {
  height: 100%;
  width: 100%;
  display: flex;
  align-items: center;
}

.content .div-container {
  height: 100%;
}
.content {
  width: 100%;
  height: 100%;
  // padding: 6px 6px 6px 6px;
  box-sizing: border-box;
  overflow-y: auto;
  overflow-x: hidden;
  transition: all 0.25s;
  background-color: white;
  user-select: none;
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

table tr th {
  white-space: nowrap;
  cursor: auto !important;
}

table tbody tr {
  cursor: pointer;
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

.summary {
  display: flex;
}

#ctxMenu {
  position: relative;
  width: 152px;
  position: fixed !important;
}
#required-choose {
  display: block !important;
  margin-right: 8px;
}

.text-pagebumber::-webkit-outer-spin-button,
.text-pagebumber::-webkit-inner-spin-button {
  -webkit-appearance: none;
  margin: 0;
}

.btn-move-page {
  border-radius: 4px;
}

.p-number,
.btn-move-page {
  height: 34px;
  width: 34px;
  margin: 0 8px 0 8px;
  text-align: center;
  background-repeat: no-repeat;
  background-size: contain;
  background-size: 24px;
  background-position: center;
}

.p-number:hover,
.btn-move-page:hover {
  background-color: #bbbbbb;
  cursor: pointer;
}

.p-number {
  border-radius: 50%;
  border: 1px solid #bbbbbb;
  line-height: 34px;
}

.paging-toolbar {
  height: 100%;
  display: flex;
  margin-left: calc((100% - 752px) / 2);
  .leftchild {
    height: 100%;
    min-width: 330px;
    display: flex;
    align-items: center;
    .p-button {
      height: 24px;
      width: 24px;
      border: 1px solid #d0d0d0;
      border-radius: 3px;
      background-color: #fff;
      margin-right: 2px;
    }
    .first-page {
      background: url(../assets/icon/common-icon.png) no-repeat -649px -124px;
      width: 24px;
      height: 24px;
      background-color: #fff;
      border-radius: 3px;
      cursor: pointer;
    }

    .text-pagebumber,
    .select-quantitypage {
      border-radius: 3px;
      text-align: left;
      padding-left: 4px;
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
      background: url(../assets/icon/common-icon.png) no-repeat -849px -124px;
      border: 1px solid #6b6f9d !important;
    }
    .last-page {
      background: url(../assets/icon/common-icon.png) no-repeat -798px -124px;
    }
    .next-page {
      background: url(../assets/icon/common-icon.png) no-repeat -749px -124px;
    }

    .select-quantitypage {
      width: 52px;
      height: 26px;
      border: 1px solid #d0d0d0;
      outline: none !important;
    }
  }
}

.select-quantitypage {
  appearance: none;
  background: url(../assets/icon/arrow-down-line.png) no-repeat;
  background-position: 34px 11px;
  cursor: pointer;
}
::-webkit-scrollbar {
  display: none;
}

.filter-menu {
  height: 80px;
  width: 102px;
  display: flex;
  flex-direction: column;
  position: absolute;
  top: -14px;
  z-index: 100;
  border-radius: 2px;
  right: 214px;
  font-size: 14px;
  box-shadow: 2px 2px 4px grey;
  background: white;
  cursor: pointer;
}

// .filter-menu .item-type {
// }
.filter-menu .item-filter {
  height: 50%;
  display: flex;
  align-items: center;
}

.filter-menu .menu-child {
  width: 150px;
  height: 400px;
  display: flex;
  flex-direction: column;
  overflow: auto;
  box-shadow: 2px 2px 4px grey;
}
.filter-menu .menu-child .item {
  height: 40px;
  display: flex;
  align-items: center;
  background: white;
  padding: 10px 5px;
  text-align: center;
}

.filter-menu .menu-container {
  position: absolute;
  left: 102px;
  top: 15px;
}

.filter-menu .text {
  padding: 0px 5px;
}
.filter-menu .item:hover {
  background: #eaeaea;
}

.filter-menu .menu-department {
  top: 40px;
}
.filter-menu .menu-child {
  display: none;
}

.item-filter:hover .menu-child {
  display: block;
}
.menu-child:hover {
  display: block;
}
table {
  position: relative;
}

.loading-emty {
  font-size: 24px;
  font-style: italic;
  white-space: nowrap;
  position: absolute;
  left: calc((100% - 180px) / 2);
  margin-top: 21px;
}

.v-icon {
  background-image: url(../assets/icon/add.png) !important;
  background-size: 16px;
  background-repeat: no-repeat;
  background-position: center;
  height: 28px;
  width: 28px;
}
.selected-row {
  background: #8dd2f369 !important;
}
.p-button {
  cursor: pointer;
}
.paging-toolbar .leftchild {
  justify-content: space-between;
  width: 355px;
}
.table-summary .price-number {
  position: absolute;
  right: 72px;
}
</style>

