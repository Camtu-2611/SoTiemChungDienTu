<template>
  <div class=" blue darken-3 div-container nav" id="navbar">
    <div class="nav-item header">
      <div class="icon-nav logo-page" @click="toggleNavbar('icon')"></div>
      <div class="nav-item-text">SỔ TIÊM CHỦNG</div>
      <div class="icon-hamburger-menu" @click="toggleNavbar('no')"></div>
    </div>
    <div
      id="navItem1"
      class="nav-item option nav-item-icon"
      @click="redirect('injection-register')"
      :class="{ 'option-focus': currentRouteName == 'injection-register' }"
    >
      <div class="icon-nav icon-computer-line"></div>
      <div class="nav-item-text">
        Đăng ký tiêm
      </div>
    </div>
    <div
      id="navItem2"
      class="nav-item option nav-item-icon"
      @click="redirect('injection-books')"
      :class="{ 'option-focus': currentRouteName == 'injection-books' }"
    >
      <div class="icon-nav icon-community-line"></div>
      <div class="nav-item-text">
        Sổ tiêm
      </div>
      <!-- <div class="icon-submenu" @click="$router.push({ name: 'asset' })"></div>
      <div class="sub-navbar">
        <div
          class="sub-navbar-item"
          @click="$router.push({ name: 'dang-ky-tiem' })"
        >
          Thêm sổ tiêm
        </div>
        <div class="sub-navbar-item" @click="$router.push({ name: 'khauhao' })">
          Tính khấu hao
        </div>
        <div class="sub-navbar-item" @click="$router.push({ name: 'ghigiam' })">
          Ghi giảm
        </div>

        <div
          class="sub-navbar-item"
          @click="$router.push({ name: 'evaluate' })"
        >
          Đánh giá lại
        </div>
        <div class="sub-navbar-item" @click="$router.push({ name: 'audit' })">
          Kiểm kê tài sản
        </div>

        <div
          class="sub-navbar-item"
          @click="$router.push({ name: 'owner-tranfer' })"
        >
          Chuyển tài sản thuê thành tài sản sở hữu
        </div>
        <div
          class="sub-navbar-item"
          @click="$router.push({ name: 'bao-duong' })"
        >
          Bảo dưỡng tài sản
        </div>
      </div> -->
    </div>
    <div
      id="navItem3"
      class="nav-item option nav-item-icon"
      @click="redirect('injection-schedules')"
      :class="{ 'option-focus': currentRouteName == 'injection-schedules' }"
    >
      <div class="icon-nav icon-paint-brush-line"></div>
      <div class="nav-item-text">
        Lịch tiêm
      </div>
      <!-- <div class="icon-submenu"></div> -->
      <!-- <div class="sub-navbar">
        <div class="sub-navbar-item">Sản phẩm sản xuất</div>
        <div class="sub-navbar-item">Dụng cụ</div>
      </div> -->
    </div>
    <div
      id="navItem4"
      class="nav-item option nav-item-icon"
      :class="{
        'option-focus':
          (currentRouteName == 'manage-vaccines')
          | (currentRouteName == 'manage-vaccine-type')
          | (currentRouteName == 'manage-vaccine-package'),
      }"
    >
      <div class="icon-nav icon-common"></div>
      <div class="nav-item-text">
        Quản lý vắc xin
      </div>
      <div class="icon-submenu"></div>
      <div class="sub-navbar">
        <div
          class="sub-navbar-item"
          @click="redirect('manage-vaccines')"
          :class="{ 'option-focus': currentRouteName == 'manage-vaccines' }"
        >
          Vắc xin
        </div>
        <div
          class="sub-navbar-item"
          @click="redirect('manage-vaccine-type')"
          :class="{ 'option-focus': currentRouteName == 'manage-vaccine-type' }"
        >
          Nhóm Vắc xin
        </div>
        <div
          class="sub-navbar-item"
          @click="redirect('manage-vaccine-package')"
          :class="{
            'option-focus': currentRouteName == 'manage-vaccine-package',
          }"
        >
          Gói Vắc xin
        </div>
        <!-- <div class="sub-navbar-item">Nguyên liệu</div> -->
      </div>
    </div>
    <!-- <div
      id="navItem5"
      @click="$router.push({ name: 'search' })"
      class="nav-item option nav-item-icon"
    >
      <div class="icon-nav icon-search-eye"></div>
      <div class="nav-item-text">Tra cứu</div>
    </div> -->
    <div id="navItem6" class="nav-item option nav-item-icon">
      <div class="icon-nav icon-setting"></div>
      <div class="nav-item-text">Hệ thống</div>
    </div>
    <!-- <div id="navItem7" class="nav-item option nav-item-icon">
      <div class="icon-nav icon-pie-chart-line"></div>
      <div class="nav-item-text">Báo cáo</div>
    </div> -->
  </div>
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
      var length = this.$route.fullPath.split("/").length;
      return this.$route.fullPath.split("/")[length - 1];
    },
  },
  watch: {
    // $route(to) {
    //   this.show = false;
    // },
  },
  methods: {
    redirect(routername) {
      if (this.currentRouteName !== routername) {
        this.$router.push({ name: routername });
      }
    },
    toggleNavbar(text) {
      this.collapseNavbar = !this.collapseNavbar;
      var navbar = document.getElementById("navbar");
      var bodyRight = document.getElementsByClassName("body-right")[0];
      var itemText = document.getElementsByClassName("nav-item-text");
      var iconSubmenu = document.getElementsByClassName("icon-submenu");

      if (text == "icon" && this.collapseNavbar == true) {
        navbar.style.width = "210px";
        bodyRight.style.marginLeft = "210px";
        bodyRight.style.width = "calc(100% - 210px)";

        document.getElementsByClassName(
          "icon-hamburger-menu"
        )[0].style.display = "block";

        itemText.forEach((element) => {
          element.style.display = "block";
        });

        iconSubmenu.forEach((element) => {
          element.style.border = "5px solid";
          element.style.bottom = "auto";
          element.style.right = "12px";
          element.style.borderColor =
            "transparent transparent transparent white";
        });
      } else {
        navbar.style.width = "60px";
        bodyRight.style.marginLeft = "60px";
        bodyRight.style.width = "calc(100% - 60px)";

        document.getElementsByClassName(
          "icon-hamburger-menu"
        )[0].style.display = "none";

        itemText.forEach((element) => {
          element.style.display = "none";
        });
        iconSubmenu.forEach((element) => {
          element.style.border = "3px solid";
          element.style.bottom = "0";
          element.style.right = "2px";
          element.style.borderColor = "transparent white white transparent";
        });
      }
    },
  },
};
</script>

<style lang="scss" scoped>
@import url("../../style/scss/icon.scss");
.option-focus {
  border-left: 4px solid #00abfe;
  background-color: #035797;
  outline: none;
  padding-left: 9px !important;
  transition: 0.2s;
}
.nav {
  // background-color: #0673c7;
  // color: rgb(5, 12, 75);
  font-size: 14px;
  width: 210px;
  height: 100vh;
  box-sizing: border-box;
  //border-right: #e2e1e6 1px solid;
  position: fixed;

  top: 0;
  left: 0;
  transition: width 0.5s;
  color: white;
  display: block;

  .nav-item {
    &.header {
      margin-bottom: 2px;
      padding-left: 6px;

      .icon-hamburger-menu {
        padding-left: 40px;
        background-position: right;
      }

      &:hover {
        cursor: pointer;
      }
    }

    &.nav-item-icon:hover {
      background-color: #035797;
      cursor: pointer;
      transition: 0.2s;

      .sub-navbar {
        display: block;
      }
    }

    &.option {
      padding-left: 0;
      transition: all 0.5s ease;
      padding: 0 9px;
      width: 100%;
    }

    .nav-title {
      font-weight: bold;
      font-family: GoogleSans-Bold;
      text-transform: uppercase;
      font-size: 24px;
      padding-left: 6px !important;
      transition: width 0.5s;
      margin-right: 46px;

      &:hover {
        cursor: pointer;
      }
    }
    .sub-navbar {
      // position: relative;
      // right:0;
      position: absolute;
      left: 100%;
      background-color: white;
      color: black;
      width: fit-content;
      box-shadow: 2px 2px 10px #c3c3c3;
      top: 0;
      display: none;

      .sub-navbar-item {
        padding: 10px 60px 10px 22px;
        &:hover {
          cursor: pointer;
          background-color: #eaeaea;
        }
      }
    }

    .nav-item-text {
      padding-left: 8px;
      transition: none;
    }
  }
}

.nav .nav-item.header .icon-hamburger-menu {
  padding-left: 40px;
  box-sizing: border-box;
  margin: 0px;
  background-position: right !important;
}
.nav .nav-item .sub-navbar {
  white-space: nowrap;
}
.nav:hover {
  z-index: 1;
}
.nav:hover .sub-navbar {
  z-index: 1;
}
.icon-submenu {
  border: 5px solid;
  border-color: transparent transparent transparent white;
  position: absolute;
  right: 12px;
}
.nav .nav-item {
  height: 48px;
  display: flex;
  box-sizing: border-box;
  align-items: center;
  padding-left: 13px;
  position: relative;
}

.nav-item:hover .icon-submenu {
  border-color: transparent transparent transparent #00abfe;
}
</style>
