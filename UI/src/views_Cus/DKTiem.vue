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
        <v-stepper-step :complete="e1 > 1" step="1"> Bước 1 </v-stepper-step>

        <v-divider></v-divider>

        <v-stepper-step :complete="e1 > 2" step="2"> Bước 2 </v-stepper-step>

        <v-divider></v-divider>
      </v-stepper-header>

      <v-stepper-items>
        <v-stepper-content step="1">
          <v-card class="mb-12" color="	#FFFFFF" height="350px">
            <div class="container">
                <h4>THÔNG TIN ĐĂNG KÝ TIÊM</h4>

                <form class="contact-form mt-5">
                  <div class="row mb-3">
                    <div class="col-sm-6 py-2 wow fadeInLeft">
                      <label for="fullName">Họ tên </label>
                      <input
                        type="text"
                        id="fullName"
                        class="form-control"
                        placeholder="Họ tên.."
                        v-model="thongtinDK.hoten"
                      />
                    </div>
                    <div
                      class="col-12 col-sm-6 py-2 wow fadeInLeft"
                      data-wow-delay="300ms"
                    >
                      <label for="date">Ngày sinh </label>
                      <input type="date" class="form-control" 
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
                        type="text"
                        id="emailAddress"
                        class="form-control"
                        placeholder="Email address.."
                        v-model="thongtinDK.email"
                      />
                    </div>
                     <div
                      class="col-12 col-sm-6 py-2 wow fadeInLeft"
                      data-wow-delay="300ms"
                    >
                      <label for="SDT">Số điện thoại </label>
                      <input type="text" class="form-control" 
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
          <v-card class="mb-12" color="	#FFFFFF" height="350px">
             <div class="container">
                <h4>THÔNG TIN DỊCH VỤ</h4>

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
                        <option value="1">One-health, 16 Cau Giay</option>
                        <option value="2">One-health, 1 Truong Chinh</option>
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
                      <label for="vacxin"
                        >Loại vắc xin muốn tiêm</label
                      >
                      <v-container fluid>
                      
                        <v-row>
                          <v-col 
                          cols="12" sm="6" md="6"
                          v-for="(record, index) in listRecord"
                          :key="index"
                          >
                            <v-checkbox
                              v-model="thongtinDK.danhsachvacxin"
                              :label="record.tenvacxin"
                              :value="record.mavacxin"
                            ></v-checkbox>
                             <!-- <v-checkbox
                              v-model="thongtinDK.danhsachvacxin"
                              label="Vacxin 6 trong 1"
                              value="VX02"
                            ></v-checkbox> -->
                          </v-col>
                          <!-- <v-col cols="12" sm="6" md="6">
                            <v-checkbox
                              v-model="thongtinDK.danhsachvacxin"
                              label="Vacxin viêm gan B"
                              value="VX03"
                            ></v-checkbox>
                            <v-checkbox
                              v-model="thongtinDK.danhsachvacxin"
                              label="Vacxin B"
                              value="VX04"
                            ></v-checkbox>
                          </v-col> -->
                          
                        </v-row>
                      </v-container>
                      
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
</template>

<script>
import axios from "axios";
export default {
  name: "DKTiem",
  data() {
    return {
      e1: 1,
      selected: [""],
      thongtinDK: {},
      defaultthongtinDK: {
        hoten:"",
        ngaysinh:"",
        gioitinh:"",
        sodienthoai:"",
        email:"",
        diachi:"",
        tentrungtam:"",
        ngaydangkytiem:"",
        danhsachvacxin:[],
        nguoitao:"",
        ngaytao:new Date().toISOString(),
        nguoichinhsua:"",
        ngaychinhsua:new Date().toISOString()

      },
      listRecord: [],
      vacxins:[]

    };
  },
  created(){
  this.thongtinDK=this.defaultthongtinDK
  this.getAllRecord()
  },
  //  created:function(){
  //       this.danhsach_vacxin();
  //     },

  methods: {
    /**
     * Thực hiện thêm mới bản ghi
     * */
    async insertRecord() {
      try {
        let me = this;
        let dsdangky = this.thongtinDK.danhsachvacxin.toString()
        console.log(dsdangky)
        this.thongtinDK.danhsachvacxin = dsdangky
        await axios
          .post("http://localhost:64016/api/ThongTinDangKyTiem", this.thongtinDK)
          .then(() => {
            // me.$refs.loading.hideLoading();
            console.log("106")
           this.$router.push({ name: 'STC-dien-tu' })
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
     * Thực hiện lấy toàn bộ bản ghi của Vacxin
     * */
  danhsach_vacxin(){
           this.axios.get("http://localhost:64016/api/Vacxin").then((response)=>{
             this.vacxins=response.data;
            });
          }

  },
  
}
</script>

<style>
</style>
