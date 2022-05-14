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
                placeholder="Mã nhân viên.."
              />
            </div>
            <div class="col-12 py-2 wow fadeInUp" data-wow-delay="300ms">
              <input
                type="password"
                class="form-control"
                placeholder="Mật khẩu.."
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
  </div>
</template>

<script>
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
  data() {
    return {};
  },
  methods: {
    btnSigninAdminnClick() {
      console.log(this.redirectString)
      this.redirectString = 'admin'
      this.isShowSigninAdmin = false
      console.log(this.redirectString, this.isShowSigninAdmin)
      this.$emit('redirect', this.redirectString, this.isShowSigninAdmin)
    },
  }
};
</script>

<style>
</style>
