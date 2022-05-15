<template>
  <div>
     
    <div
      class="page-banner overlay-dark bg-image"
      style="background-image: url(../assets/img/bg_image_1.jpg)"
    >
      <div class="banner-section">
        <div class="container text-center wow fadeInUp">
          <h3 class="font-weight-normal">THÔNG TIN VẮC XIN</h3>
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
                Vắc xin
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
        <h10>VACXIN LẺ</h10>
      </v-tab>
      <v-tab>
        <h10>VACXIN GÓI</h10>
      </v-tab>
    </v-tabs>
    <v-tabs-items v-model="tab">
      <v-tab-item>
        <div class="container">
          <form action="#">
            <div class="input-group input-navbar">
              <div class="input-group-prepend">
                <span class="input-group-text" id="icon-addon1"
                  ><span class="mai-search"></span
                ></span>
              </div>
              <input
                type="text"
                class="form-control"
                placeholder="Nhập để tìm kiếm.."
                aria-label="Username"
                aria-describedby="icon-addon1"
              />
            </div>
          </form>
      <VacxinDetail :idvacxin="idSelected" ref="VacxinDetail_ref" />
          <form class="contact-form mt-5">
            <div class="row mb-3">
              <div class="col-12 py-2 wow fadeInUp" data-wow-delay="300ms">
                <v-row>
                  <v-col
                    cols="12"
                    sm="4"
                    md="4"
                    v-for="(record, index) in listRecord"
                    :key="index"
                  >
                    <v-card
                      class="mx-auto"
                      width="400"
                      height="250"
                      outlined
                      color="rgb(211 224 238)"
                    >
                      <v-list-item three-line>
                        <v-list-item-content>
                          <div class="text-h6 mb-3">
                            {{ record.tenvacxin }}
                          </div>

                          <v-list-item-subtitle>
                            {{ record.mota }}</v-list-item-subtitle
                          ><br />
                          <br />
                          <br />
                          <v-list-item-title class="text-h6 mb-1">
                            {{ record.giavacxin }} VNĐ
                          </v-list-item-title>
                        </v-list-item-content>
                      </v-list-item>
                      <v-card-actions>
                        <v-btn
                          outlined
                          rounded
                          text
                          color="#003a78"
                          @click="btnVacxinDetail(record.idvacxin)"
                        >
                          Xem chi tiết
                        </v-btn>
                      </v-card-actions>
                    </v-card>
                  </v-col>
                </v-row>
              </div>
            </div>
          </form>
        </div>
      </v-tab-item>
      <v-tab-item>
        <div class="container">
          <form action="#">
            <div class="input-group input-navbar">
              <div class="input-group-prepend">
                <span class="input-group-text" id="icon-addon1"
                  ><span class="mai-search"></span
                ></span>
              </div>
              <input
                type="text"
                class="form-control"
                placeholder="Nhập để tìm kiếm.."
                aria-label="Username"
                aria-describedby="icon-addon1"
              />
            </div>
          </form>

          <form class="contact-form mt-5">
            <div class="row mb-3">
              <div class="col-12 py-2 wow fadeInUp" data-wow-delay="300ms">
                <v-row>
                  <v-col
                    cols="12"
                    sm="4"
                    md="4"
                    v-for="(record, index) in listRecordGoivacxin"
                    :key="index"
                  >
                    <v-card
                      class="mx-auto"
                      width="400"
                      height="250"
                      outlined
                      color="rgb(211 224 238)"
                    >
                      <v-list-item three-line>
                        <v-list-item-content>
                          <div class="text-h6 mb-3">
                            {{ record.tengoi }}
                          </div>

                          <v-list-item-subtitle>
                            {{ record.mota }}</v-list-item-subtitle
                          ><br />
                          <br />
                          <br />
                          <v-list-item-title class="text-h6 mb-1">
                            {{ record.dongia }} VNĐ
                          </v-list-item-title>
                        </v-list-item-content>
                      </v-list-item>
                      <v-card-actions>
                        <v-btn outlined rounded text color="#003a78">
                          Xem chi tiết gói
                        </v-btn>
                      </v-card-actions>
                    </v-card>
                  </v-col>
                </v-row>
              </div>
            </div>
          </form>
        </div>
      </v-tab-item>
    </v-tabs-items>

   
  </div>
</template>

<script>
import axios from "axios";
import VacxinDetail from "./VacxinDetail.vue";
export default {
  name: "DKTiem",
  components: {
    VacxinDetail,
  },
  data() {
    return {
      tab: null,
      e1: 1,
      selected: [""],
      VacxinbyID: {},
      thongtinDK: {},
      defaultthongtinDK: {
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
      idSelected: "",
      listRecord: [],
      listRecordGoivacxin: [],
      listTrungTam: [],
    };
  },
  created() {
    this.thongtinDK = this.defaultthongtinDK;
    this.getAllRecord();
    this.getAllRecordGoivacxin();
    this.getAllRecordTrungTam();
  },

  watch: {
    email(value) {
      // binding this to the data value in the email input
      this.email = value;
      this.validateEmail(value);
    },
  },
  methods: {
    btnVacxinDetail(Id) {
      // if (Id) {
        this.idSelected = Id;
        console.log(this.idSelected);
   
        setTimeout(() => {
          this.$refs.VacxinDetail_ref.show();
          console.log(this.idSelected);
        }, 300);
      // } else {
      //   console.log(Id);
      //   return;
      // }
      // this.$router.push({ name: "vac-xin-detail" });
    },

    /**
     * Thực hiện thêm mới bản ghi
     * */
    async insertRecord() {
      try {
        let me = this;
        let dsdangky = this.thongtinDK.danhsachvacxin.toString();
        console.log(dsdangky);
        this.thongtinDK.danhsachvacxin = dsdangky;
        await axios
          .post(
            "http://localhost:64016/api/ThongTinDangKyTiem",
            this.thongtinDK
          )
          .then(() => {
            // me.$refs.loading.hideLoading();
            console.log("106");
            alert("Đăng ký tiêm thành công !");
            this.$router.push({ name: "STC-dien-tu" });
          })
          .catch(() => {});
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
     * Thực hiện lấy bản ghi của vacxin theo id
     * */
    async getVacxinbyID() {
      try {
        await axios
          .get(
            `http://localhost:64016/api/Vacxin/287351b1-c282-4b05-9289-9863f7659a2d`
          )
          .then((response) => {
            if (response.data) {
              var res = response.data.data;
              if (res) {
                console.log(res);
                this.VacxinbyID.tenvacxin = res.tenvacxin;
                this.VacxinbyID.solo = res.solo;
                this.VacxinbyID.mota = res.mota;
                this.VacxinbyID.ngaysanxuat = this.formatDate(
                  this.VacxinbyID.ngaysanxuat
                );
                this.VacxinbyID.giavacxin = res.giavacxin;
                this.VacxinbyID.soluong = res.soluong;
                this.VacxinbyID.trangthai = res.trangthai;
              }
            }
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
};
</script>

<style>
</style>
