<template>
  <div class="confirm" v-if="isActive">
    <div class="base-confirm"></div>
    <div class="main-confirm">
      <div class="title-form">
        {{ titleForm }}
      </div>
      <div class="content">
        <div class="content-icon" :class="nameIcon + 'Custom' "></div>
        <div class="content-mess">
          <div class="mess-form">
            {{ messageForm }}
          </div>
        </div>
      </div>
      <div class="mess-line"></div>
      <div class="mess-footer" v-if="type == 1">
        <div class="button-close" @click="hideForm">Đóng</div>
      </div>
      <div class="mess-footer" v-if="type == 2">
        <div class="position-left">
          <div class="button-no" @click="hideForm">Không</div>
        </div>
        <div class="position-right">
          <div class="button-yes" @click="processActionYes">Có</div>
        </div>
      </div>
      <div class="mess-footer" v-if="type == 3">
        <div class="position-left">
          <div class="button-no" @click="hideForm">Hủy</div>
        </div>
        <div class="position-right">
          <div class="button-no" @click="processActionNo">Không</div>
          <div class="button-yes" @click="processActionYes">Có</div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "ConfirmYesNo",
  components: {},
  data() {
    return {
      messageForm: "",
      isActive: false,
      nameIcon: "question",
      type: 2,
      idAction: null,
      titleForm: "",
    };
  },
  methods: {
    /**
     * Thực hiện mở hiển thị form Confirm Delete
     * CreatedBy: ntmanh(19/05/2021)
     * */
    showForm(nameIcon, type, message, idAction, title) {
      this.nameIcon = nameIcon;
      this.type = type;
      this.messageForm = message;
      this.isActive = true;
      this.idAction = idAction;
      this.titleForm = title;
    },

    /**
     * Thực hiện ẩn form Confirm Delete
     * CreatedBy: ntmanh(19/05/2021)
     * */
    hideForm() {
      this.isActive = false;
    },

    /**
     * Thực thi hành động khi ấn nút có
     * Khi ấn nút có sẽ gọi đến hàm xóa nhân viên ở component cha, và thực hiện xóa
     * Sau khi xóa, tiến hành làm mới lại dữ liệu
     * CreatedBy: ntmanh(19/05/2021)
     * */
    processActionYes() {
      this.isActive = false;
      this.$emit("processActionYes", this.idAction);
    },
    processActionNo() {
      this.isActive = false;
      this.$emit("processActionNo");
    },
  },
};
</script>

<style scoped>
@font-face {
  font-family: "MISA-Bold";
  src: url("../baseResourcesAccounting/fonts/notosans-bold.3ede5aff.woff2") format("opentype");
}
@font-face {
  font-family: "MISA-Italic";
  src: url("../baseResourcesAccounting/fonts/notosans-italic.1c1aaac9.woff2") format("opentype");
}
@font-face {
  font-family: "MISA-Regular";
  src: url("../baseResourcesAccounting/fonts/notosans-regular.2cb88a13.woff2") format("opentype");
}
@font-face {
  font-family: "MISA-Semibold";
  src: url("../baseResourcesAccounting/fonts/notosans-semibold.df3e6dc4.woff2") format("opentype");
}
.confirm {
  height: 100%;
  font-family: MISA-Regular, MISA-Bold, MISA-Italic, MISA-Semibold !important;
}
.base-confirm {
  width: 100%;
  background: rgba(0, 0, 0, 0.4);
  position: fixed;
  left: 0;
  top: 0;
  height: 100%;
  z-index: 100;
  transition: all 0.25s ease;
  opacity: 1;
}
.main-confirm {
  min-width: 444px;
  max-width: 203px;
  /* width: 444px;
  height: 203px; */
  background-color: #fff;
  position: fixed;
  left: calc((100% - 444px) / 2);
  top: calc((100% - 203px) / 2);
  z-index: 100;
  padding: 32px;
  display: flex;
  flex-direction: column;
  box-sizing: border-box;
}
.content {
  width: 100%;
  display: flex;
}
.content-icon {
  width: 48px;
  height: 48px;
  background-image: url("../baseResourcesAccounting/img/Sprites.64af8f61.svg");
  background-repeat: no-repeat;
}
.warningCustom {
  background-position: -592px -456px;
}
.errorCustom {
  background-position: -24px -954px;
}
.questionCustom {
  background-position: -826px -456px;
}
.content-mess {
  width: calc(100% - 42px);
  height: 100%;
  margin: 12px 0px 0px 16px;
  padding-bottom: 32px;
  color: #111111;
  box-sizing: border-box;
}
.title-form {
  padding-left: 62px;
  font-weight: bold;
}
.mess-line {
  height: 19px;
  border-top: 1px solid #b8bcc3;
}
.mess-footer {
  height: 36px;
  width: 100%;
  position: relative;
}
.button-close {
  position: absolute;
  left: calc((100% - 74px) / 2);
  height: 36px;
  padding: 8px 20px;
  border-radius: 3px;
  background-color: #038cd1;
  color: #fff;
  box-sizing: border-box;
  border: 1px;
  font-weight: bold;
  cursor: pointer;
}
.button-no {
  height: 36px;
  padding: 8px 20px;
  border: 1px solid #8d9096;
  color: #111;
  box-sizing: border-box;
  border-radius: 3px;
  font-size: 13px;
  font-weight: bold;
}
.button-no:hover {
  background-color: #d2d3d6;
  cursor: pointer;
}
.button-yes {
  height: 36px;
  padding: 8px 20px;
  border-radius: 3px;
  background-color: #038cd1;
  color: #fff;
  box-sizing: border-box;
  border: 1px;
  font-weight: bold;
  margin-left: 8px;
}
.position-left {
  position: absolute;
  left: 0;
  display: flex;
  height: 100%;
}
.position-right {
  position: absolute;
  right: 0;
  display: flex;
  height: 100%;
}
.button-yes:hover {
  background-color: #06a2f0;
  cursor: pointer;
}
</style>