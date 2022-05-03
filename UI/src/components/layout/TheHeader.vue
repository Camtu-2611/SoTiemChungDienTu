<template>
  <div class="div-container header" id="header">
    <!-- <div class="header-left">
      <div class="parent-section">Danh mục</div>
      <div class="icon-seperator"></div>
      <div class="child-section">Tài sản</div>
    </div>

    <div class="header-right">
      <div class="header-right-item" style="font-family: GoogleSans-Regular">
        Sở tài chính
      </div>
      <div class="header-right-item">
        <div class="combobox">
          <div class="combobox-text hover-pointer">{{ optionFilter }}</div>
          <div class="icon-updown hover-pointer" @click="showMenuFilter()"></div>
        </div>
      </div>
      <div class="icon-help header-right-item hover-pointer"></div>
      <div class="icon-bell header-right-item hover-pointer">
        <div class="notification">1</div>
      </div>
      <div class="icon-divider"></div>
      <div class="header-right-user">
        <div class="avatar hover-pointer">
          <img src="../../assets/icon/avatar-default.png" alt="" />
        </div>
        <div class="icon-down hover-pointer"></div>
      </div>
    </div> -->
    <v-app-bar color="white" dense>
      <!-- <v-app-bar-nav-icon></v-app-bar-nav-icon> -->

      <v-toolbar-title>{{pageTitle}}</v-toolbar-title>

      <v-spacer></v-spacer>

      <v-btn icon>
        <v-icon>mdi-heart</v-icon>
      </v-btn>

      <v-btn icon>
        <v-icon>mdi-magnify</v-icon>
      </v-btn>

      <!-- <v-menu left bottom>
        <template v-slot:activator="{ on, attrs }">
          <v-btn icon v-bind="attrs" v-on="on">
            <v-icon>mdi-dots-vertical</v-icon>
          </v-btn>
        </template>

        <v-list>
          <v-list-item v-for="n in 5" :key="n" @click="() => {}">
            <v-list-item-title>Option {{ n }}</v-list-item-title>
          </v-list-item>
        </v-list>
      </v-menu> -->
      <v-menu
        bottom
        left
      >
        <template v-slot:activator="{ on }">
          <v-btn
          class="mx-1"
            icon
            v-on="on"
          >
            <v-avatar
              color="purple"
              size="30"
            >
              <span class="white--text button">{{ user.initials }}</span>
            </v-avatar>
          </v-btn>
        </template>
        <v-card>
          <v-list-item-content class="justify-end align-end">
            <div class="mx-auto text-center">
              <v-avatar
                color="purple"
              >
                <span class="white--text text-button">{{ user.initials }}</span>
              </v-avatar>
              <h3 class="text-body1 my-1">{{ user.fullName }}</h3>
              <p class="text-caption mt-1">
                {{ user.email }}
              </p>
              <v-divider class="my-1"></v-divider>
              <v-btn
                depressed
                text
                class="text-body2"
              >
                Chỉnh sửa thông tin
              </v-btn>
              <v-divider class="my-1"></v-divider>
              <v-btn
                depressed
                text
                class="text-body2"
              >
                Đăng xuất
              </v-btn>
            </div>
          </v-list-item-content>
        </v-card>
      </v-menu>
    </v-app-bar>
  </div>
</template>

<script>
export default {
  name: "Header",
  props: {
    optionFilter: String,
    pageTitle: String
  },
  created(){
    this.pageTitle = "Đăng ký tiêm chủng"
  },
  data() {
    return {
      activeFilterMenu: false,
      user: {
        initials: 'CT',
        fullName: 'Cẩm Tú',
        email: 'camtunghiadan@gmail.com',
      },
    };
  },
  methods: {
    showMenuFilter() {
      this.activeFilterMenu = !this.activeFilterMenu;
      this.$emit("activeFilterMenu", this.activeFilterMenu);
    },
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style lang="scss" scoped>
@import url("../../style/_variables.scss");
.header {
  height: 60px;
  // height: $header-height;
  width: calc(100% - 200px);
  margin-left: 200px;
  box-sizing: border-box;
  border-bottom: #e2e1e6 1px solid;
  overflow: visible;
  // margin-left: $navbar-width-max;
  margin-left: 210px;
  transition: all 0.5s;

  .header-left {
    height: 60px;
    line-height: 60px;
    padding-left: 16px;
    font-weight: bold;
    font-size: 15px;
    display: flex;
    align-items: center;

    .parent-section {
      color: #178aa9;
      font-family: GoogleSans-Regular;

      &:hover {
        cursor: pointer;
      }
    }
  }

  .header-right {
    display: flex;
    height: 60px;
    align-items: center;
    .icon-bell {
      position: relative;
      .notification {
        width: 12px;
        height: 12px;
        position: absolute;
        background-color: #00abfe;
        color: white;
        right: 2px;
        border-radius: 50%;
        top: 2px;
        line-height: 12px;
        font-size: 8px;
        text-align: center;
      }
    }
    .header-right-user {
      display: flex;
      align-items: center;
      margin-right: 16px;
      .avatar {
        width: 32px;
        height: 32px;
        margin: 0 10px 0 6px;

        img {
          width: 100%;
          height: 100%;
        }
      }
    }

    .header-right-item {
      line-height: 60px;
      // padding: 6px;
      margin: 0 10px;
      font-weight: bolder;
    }

    .user-setting {
      height: 60px;
      padding: 0 6px;
      width: 50px;

      //   &.icon-more {
      //     background-image: url("../../assets/icon-more.png");
      //     background-repeat: no-repeat;
      //     background-position: center;
      //     background-size: 20px 20px;
      //   }
    }
  }
}

.header .header-right {
  position: absolute;
  right: 0;
}

.content {
  height: 60px;
  /* width: calc(100% - 200px); */
  position: relative;
  /* margin-left: 210px; */
  box-sizing: border-box;
  border-bottom: #e2e1e6 1px solid;
  /* overflow: visible; */
  margin-left: 210px;
  transition: all 0.5s;
  width: calc(100% - 210px);
}

.header {
  height: 60px;
  width: 100%;
  position: relative;
  display: flex;
  margin-left: 0px;
  box-sizing: border-box;
  border-bottom: #e2e1e6 1px solid;
  transition: all 0.5s;
}
.header .header-left {
  /* float: left; */
  float: none;
  height: 60px;
  line-height: 60px;
  padding-left: 16px;
  font-weight: bold;
  font-size: 15px;
  display: flex;
  align-items: center;
}
.combobox {
  position: relative;
}
.icon-down {
  opacity: 0.6 !important;
}
.header {
  height: 40px;
  align-items: center;
  width: 100%;
  position: relative;
  display: flex;
  margin-left: 0px;
  box-sizing: border-box;
  border-bottom: #e2e1e6 1px solid;
  transition: all 0.5s;
}
.header .header-right .header-right-user .avatar {
  width: 28px;
  height: 28px;
  margin: 0 10px 0 6px;
}
.combobox {
  height: 27px;
}
</style>
