<template>
  <header>
    <div class="topbar">
      <div class="container">
        <div class="row">
          <div class="col-sm-8 text-sm">
            <div class="site-info">
              <a href="#"
                ><span class="mai-call text-primary"></span> +00 123 4455
                6666</a
              >
              <span class="divider">|</span>
              <a href="#"
                ><span class="mai-mail text-primary"></span>
                SoTiemChung@gmail.com</a
              >
            </div>
          </div>
          <div class="col-sm-4 text-right text-sm">
            <div class="social-mini-button">
              <a href="#"><span class="mai-logo-facebook-f"></span></a>
              <a href="#"><span class="mai-logo-twitter"></span></a>
              <a href="#"><span class="mai-logo-dribbble"></span></a>
              <a href="#"><span class="mai-logo-instagram"></span></a>
            </div>
          </div>
        </div>
        <!-- .row -->
      </div>
      <!-- .container -->
    </div>
    <!-- .topbar -->

    <nav class="navbar navbar-expand-lg navbar-light shadow-sm">
      <div class="container">
        <a class="navbar-brand" href="#"
          ><span class="text-primary">One</span>-Health</a
        >

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

        <button
          class="navbar-toggler"
          type="button"
          data-toggle="collapse"
          data-target="#navbarSupport"
          aria-controls="navbarSupport"
          aria-expanded="false"
          aria-label="Toggle navigation"
        >
          <span class="navbar-toggler-icon"></span>
        </button>

        <div class="collapse navbar-collapse" id="navbarSupport">
          <ul class="navbar-nav ml-auto">
            <li
              class="nav-item active"
              @click="$router.push({ name: 'STC-dien-tu' })"
            >
              <a class="nav-link">Trang chủ</a>
            </li>
            <div
              class="nav-item-text"
              @click="$router.push({ name: 'dang-ky-tiem' })"
              :class="{ 'option-focus': currentRouteName == '/dang-ky-tiem' }"
            >
              Đăng ký tiêm
            </div>

            <li class="nav-item">
              <a class="nav-link" href="doctors.html">vắc xin</a>
            </li>
            <li class="nav-item">
              <a class="nav-link" href="blog.html">Cẩm nang tiêm chủng</a>
            </li>
            <li class="nav-item">
              <a class="nav-link" href="contact.html">Tư vấn</a>
            </li>
            <li class="nav-item">
              <a class="btn btn-primary" href="signup.html">Đăng xuất</a>
            </li>
          </ul>
        </div>
        <!-- .navbar-collapse -->
      </div>
      <!-- .container -->
    </nav>
  </header>
</template>

<script>

export default {
  data() {
    return {
      collapseNavbar: true,
    };
  },

  computed: {
    currentRouteName() {
      // return this.$route.name;
      console.log("CurrentRoutName = " + this.$route.fullPath.split("/")[1]);
      return this.$route.fullPath.split("/")[1];
    },
  },
  watch: {
    // $route(to) {
    //   this.show = false;
    // },
  },
  methods: {},
};
</script>

<style>
</style>
