<template>
  <div class="injection-schedules content">
    <div class="div-container">
      <div class="content-nav">
        <v-alert
          id="success-dialog"
          v-show="showSuccess"
          color="green"
          elevation="30"
          type="success"
        >
          {{ alerMsg }}</v-alert
        >
        <v-alert v-if="showWarning" id="required-choose" type="warning">{{
          alerMsg
        }}</v-alert>
        <h5 class="mb-4">Lịch tiêm</h5>
        <div class="features-pane">
        </div>

        <div class="clear-float"></div>
      </div>

      <div id="loadBar"></div>
      <div class="content-grid grid" oncontextmenu="return false;">
        <div class="ctx-menu" id="ctxMenu">
          <div class="ctx-menu-item" @click="showDetail('insert', 0)">Thêm</div>
          <div
            class="ctx-menu-item"
            @click="showDetail('update', listSelectRow[0])"
          >
            Sửa
          </div>
          <div
            id="preventLeftClick"
            class="ctx-menu-item"
            @click="Cancel(listSelectRow[0])"
          >
            Hủy đăng ký
          </div>
        </div>
      </div>
      <div id="assetPopup"></div>
    </div>
    <BaseConfirm ref="baseConfirm" />
  </div>
</template>
<script>
export default {
  name: "InjectionSchedules",
  data() {
    return {};
  },
};
</script>

<style lang="scss" scoped>
@import url(../../style/scss/icon.scss);
@import url(../../style/scss/button.scss);
.disable {
  pointer-events: none;
}
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

.content {
  height: calc(100vh - 60px);
  width: calc(100% - 200px);
  transition: all 0.25s;
  background-color: white;
  user-select: none;
}

.content-nav {
  height: 80px;
  margin: 8px;
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
      background-color: #1565c0;
      border: none;
    }

    .btn.btn-add-asset:hover,
    .btn.btn-save:hover {
      background-color: #00abfe;
    }
    .btn-search {
      margin-left: 10px;
    }

    .features-pane-right {
      position: absolute;
      right: 0;

      .icon-refresh {
        background-image: url("../../assets/UI/Icon/refresh.svg");
        background-repeat: no-repeat;
        background-size: 22px 22px;
        background-position: center;
        width: 40px;
        height: 40px;
      }

      .icon-edit-pen {
        background-repeat: no-repeat;
        background-size: 20px 20px;
        background-position: center;
        width: 40px;
        height: 40px;
        padding: 6px;
      }
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
  margin: 8px;
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


.content-nav {
  // padding-top: 26px;
  padding-bottom: 6px;
}
.content-nav .features-pane {
  margin: 0px;
}
.div-container {
  position: relative;
}


.content-grid {
  // margin: 16px 16px 16px 16px;
  height: calc(100% - 165px);
  /* height: 100%; */
  position: relative;
  overflow: auto;
  box-sizing: border-box;
}


.content .div-container {
  height: 100%;
}

.content {
  position: relative;
  box-sizing: border-box;
  width: 100%;
  height: 100%;
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
      background: url(../../assets/icon/common-icon.png) no-repeat -649px -124px;
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
      background: url(../../assets/icon/common-icon.png) no-repeat -849px -124px;
      border: 1px solid #6b6f9d !important;
    }
    .last-page {
      background: url(../../assets/icon/common-icon.png) no-repeat -798px -124px;
    }
    .next-page {
      background: url(../../assets/icon/common-icon.png) no-repeat -749px -124px;
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
  background: url(../../assets/icon/arrow-down-line.png) no-repeat;
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
  background-image: url(../../assets/icon/add.png) !important;
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

</style>
