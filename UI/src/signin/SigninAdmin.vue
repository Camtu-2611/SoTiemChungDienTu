<template>
<div class="signinAdmin">
  <!-- <Admin v-if="redirectString === 'admin'" /> -->
  <div 
    class="page-hero bg-image overlay-dark"
    style="background-image: url(../assets/img/bg_image_1.jpg)"
  >
    <div class="hero-section">
      <div class="container text-center wow zoomIn">
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
          </ol>
        </nav>
        <h1 class="font-weight-normal">Đăng nhập dành cho Nhân viên y tế</h1>
        <form class="main-form">
          <div class="row mt-5">
            <div class="col-12 py-2 wow fadeInUp" data-wow-delay="300ms">
              <input
                type="text"
                class="form-control"
                placeholder="Tên tài khoản..."
                id = "tentaikhoan"
                 v-model="taikhoan.tentaikhoan"
                 :class="{ 'class-error': validation.tentaikhoanVal }"
                      :title="validation.tentaikhoanValMsg"
                      @blur="
                        tabValidate(
                          'tentaikhoan',
                          'Vui lòng nhập tên tài khoản'
                        )
                      "
                      @tab="
                        tabValidate(
                          'tentaikhoan',
                          'Vui lòng nhập tên tài khoản'
                        )
                      "
              />
            </div>
            <div class="col-12 py-2 wow fadeInUp" data-wow-delay="300ms">
              <input
                type="password"
                class="form-control"
                placeholder="Mật khẩu.."
                id = "matkhau"
                v-model="taikhoan.matkhau"
                 :class="{ 'class-error': validation.matkhauVal }"
                      :title="validation.matkhauValMsg"
                      @blur="
                        tabValidate(
                          'matkhau',
                          'Vui lòng nhập mật khẩu!'
                        )
                      "
                      @tab="
                        tabValidate(
                          'matkhau',
                          'Vui lòng nhập mật khẩu!'
                        )
                      "
              />
            </div>
          </div>
          <div
            class="btn btn-primary mt-3 wow zoomIn"
           @click="btnSigninAdminnClick()"
          >
            Đăng nhập
          </div>
         
        </form>
      </div>
    </div>
  </div>
  <BaseConfirm ref="baseConfirm" />
  </div>
</template>

<script>
import BaseConfirm from "@/components/common/baseControlAcounting/BaseConfirm";
import Admin from "../views/Admin.vue";
export default {
  name: "SigninAdmin",
   components: {
    Admin,    
  },
  props: {
    redirectString: String,
    isShowSigninAdmin: Boolean
  },
  components: {
    BaseConfirm,
  },
  data() {
    return {
       taikhoan : {
        tentaikhoan : "",
        matkhau : "",
      },
       validation: {
        tentaikhoanVal: false,
        tentaikhoanValMsg: "",
        matkhauVal: false,
        matkhauValMsg: "",
        
      },
    };
  },
  methods: {
     
    btnSigninAdminnClick() {
      let me = this;
        if (this.validateData()) {
      console.log(this.redirectString)
      this.redirectString = 'admin'
      this.isShowSigninAdmin = false
      console.log(this.redirectString, this.isShowSigninAdmin)
      this.$emit('redirect', this.redirectString, this.isShowSigninAdmin)
    }else {
          console.log("empty");
          return;
       }
        },

    /**
     * Thực hiện validate input bị trống
     * CreatedBy: nctu2
     * editBy : Linhhn
     * */
    tabValidate(id, message) {
      if (id == "tentaikhoan") {
        console.log("tentaikhoan");
        if (!this.taikhoan.tentaikhoan) {
          this.validation.tentaikhoanVal = true;
          this.tentaikhoanValMsg = message;
        }
      } else if (id == "matkhau") {
        console.log("matkhau");
        if (!this.taikhoan.matkhau) {
          this.validation.matkhauVal = true;
          this.matkhauValMsg = message;
        }
      } 
    },
     /**
     * Thực hiện validate không được bỏ trống
     * CreatedBy: linhhn
     * */
    validateTentaikhoan() {
      if (!this.taikhoan.tentaikhoan) {
        this.$refs.baseConfirm.showForm(
          "error",
          1,
          "Vui lòng nhập tên tài khoản"
        );
        this.stateValidate = false;
        return false;
      } else {
        this.stateValidate = true;
        return true;
      }
    },
     validateMatkhau() {
      if (!this.taikhoan.matkhau) {
        this.$refs.baseConfirm.showForm(
          "error",
          1,
          "Vui lòng nhập mật khẩu"
        );
        this.stateValidate = false;
        return false;
      } else {
        this.stateValidate = true;
        return true;
      }
    },
     validateData() {
      this.validateTentaikhoan();
      this.validateMatkhau();
      if (
        this.validateTentaikhoan() &&
        this.validateMatkhau() 
      ){
        return true
      }
      else{
        return false
      }
    },
  }
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

