<template>
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
            <li class="breadcrumb-item"><a href="index.html">Trang chủ</a></li>
            <li class="breadcrumb-item active" aria-current="page">
              Đăng nhập
            </li>
          </ol>
        </nav>
        <h1 class="font-weight-normal">Đăng nhập ngay</h1>
        <form class="main-form">
          <div class="row mt-5">
            <div class="col-12 py-2 wow fadeInUp" data-wow-delay="300ms">
              <input
                type="text"
                class="form-control"
                placeholder="Số điện thoại.."
              />
            </div>
            <div class="col-12 py-2 wow fadeInUp" data-wow-delay="300ms">
              <input
                type="text"
                class="form-control"
                placeholder="Mật khẩu.."
              />
            </div>
          </div>
          <div
            class="btn btn-primary mt-3 wow zoomIn"
            @click="btnSigninClick()"
          >
            Đăng nhập
          </div>
          <div class="col-12 py-2 wow fadeInUp" data-wow-delay="300ms">
            <li class="breadcrumb-item">
              <a href="signup.html">Chưa có tài khoản? Đăng ký ngay</a>
            </li>
          </div>
        </form>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "Signin",
  props: {
    redirectString: String,
    isShow: Boolean
  },
  data() {
    return {};
  },
  methods: {
    btnSigninClick() {
      console.log(this.redirectString)
      this.redirectString = 'customer'
      this.isShow = false
      console.log(this.redirectString, this.isShow)
      this.$emit('redirect', this.redirectString, this.isShow)
    },
  },
};
</script>

<style>
</style>
