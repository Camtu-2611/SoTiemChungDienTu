<template>
  <v-app>
    <v-main id="app">
      <div id="app">
        <Signin
          v-show="isShow"
          :redirectString="redirectString"
          :isShow="isShow"
          @redirect="redirect"
        />
        <!-- {{isShowAdmin}}
        {{isShowCustomer}} -->
        <Customer v-if="redirectString === 'customer'" :tentaikhoan="tenTK"/>
        <Admin v-else-if="redirectString === 'admin'" />
        <SigninAdmin
          :redirectString="redirectString"
          :isShow="isShowSigninAdmin"
          @redirect="redirect"
          v-show="isShowSigninAdmin"
        />

      </div>
    </v-main>
  </v-app>
</template>

<script>
 import Admin from "./views/Admin.vue";
import Customer from "./views_Cus/Customer.vue";
import Header from "./components/layout/TheHeader.vue";
import Navbar from "./components/layout/TheNavbar.vue";

import Signin from "./signin/Signin.vue";
import SigninAdmin from "./signin/SigninAdmin.vue";

import Head from "./components/layout/Head.vue";
import Home from "./views_Cus/Home.vue";
import Footer from "./views_Cus/Footer.vue";

export default {
  name: "App",

  components: {
    Header,
    Navbar,
    Home,
    Head,
    Footer,
    Signin,
    SigninAdmin,
     Admin,
    Customer,
  },
  methods: {
    activeFilterMenu(value) {
      this.isFilterMenu = value;
    },
    allAsset(value) {
      this.optionFilter = value;
    },
    redirect(redirectString, showLogin, tentaikhoan) {
      this.tenTK = tentaikhoan;
      this.redirectString = redirectString;
      this.isShow = showLogin;
      if (this.redirectString === "admin") {
        this.isShowSigninAdmin = this.showLogin;
        this.$router.push({ name: "admin" });
      } else if (this.redirectString === "customer") {
        this.$router.push({ name: "STC-dien-tu" });
      } else if (this.redirectString === "signinAdmin") {
        this.$router.push({ name: "signinAdmin" });
        this.isShowSigninAdmin = true
      }
    },
  },

  data() {
    return {
      isFilterMenu: false,
      optionFilter: "Tất cả",
      isShowCustomer: true,
      isShowAdmin: false,
      isShow: true,
      isShowSigninAdmin: false,
      redirectString: "",
      tenTK : "",
    };
  },
};
</script>

<style lang="scss" >
@import "../public/assets/css/maicons.css";
@import "../public/assets/css/bootstrap.css";
@import "../public/assets/vendor/owl-carousel/css/owl.carousel.css";
@import "../public/assets/vendor/animate/animate.css";
@import "../public/assets/css/theme.css";

@import "~bootstrap/dist/css/bootstrap.css";

@import url("style/scss/common.scss");
@import url("style/scss/icon.scss");
@import url("style/scss/button.scss");
@import url("./style/scss/combobox.scss");
@import url("style/scss/input.scss");
@import url("style/scss/table.scss");
@import url("style/scss/modal.scss");
@import url("style/scss/date_picker.scss");

@font-face {
  font-family: GoogleSans;
  src: url("./assets/font/Roboto-Regular.ttf");
}
@font-face {
  font-family: GoogleSans-Bold;
  src: url("./assets/font/Roboto-Bold.ttf");
}
@font-face {
  font-family: GoogleSans-Regular;
  src: url("./assets/font/Roboto-Regular.ttf");
}
@font-face {
  font-family: GoogleSans-Medium;
  src: url("./assets/font/Roboto-Medium.ttf");
}

.div-container {
  width: 100%;
  height: 100%;
}
body {
  margin: 0;
  font-family: GoogleSans;
  // font-family: 'GoogleSans';
  font-size: 13px !important;
}

::-webkit-scrollbar {
  width: 8px;
  height: 8px;
  display: block;
}
// /* Track */
::-webkit-scrollbar-track:hover {
  background: rgb(235, 235, 235);
  // background: rgb(194, 194, 194);
  margin-top: 32px;
  border-radius: 10px;
}
/* Track */
::-webkit-scrollbar-track {
  background: transparent;
  margin-top: 32px;
}
/* Handle */
::-webkit-scrollbar-thumb {
  background: rgb(194, 194, 194);
  border-radius: 10px;
  // opacity: 0.5;
}
/* Handle on hover */
::-webkit-scrollbar-thumb:hover {
  background: rgb(131, 131, 131);
  /* filter: brightness(50%); */
}
.body-right {
  height: 100vh;
  width: calc(100% - 210px);
  z-index: 0;
}
.body-app {
  display: flex;
}
.body-left {
  height: auto;
  width: auto;
}

.body-right {
  /* width: calc(100% - 210px); */
  /* float: left; */
  margin-left: 210px;
  box-sizing: border-box;
  overflow: hidden;
  transition: all 0.5s;
}
.body-container {
  display: flex;
  position: relative;
}
::-webkit-scrollbar-track {
  background: transparent;
  margin-top: 40px;
}
table tbody tr td {
  font-size: 13px !important;
}
table thead tr th {
  background: #f5f5f5;
}
input {
  background-color: #fff !important;
}
</style>