<template>
  <div class="modal-register">
    <div class="modal-content">
      <div class="header">
        <div v-if="formMode == 'insert'" class="title">Thêm vắc xin</div>
        <div v-else class="title">Chi tiết văc xin {{ this.masotiem }}</div>

        <div class="header-right">
          <div class="icon-help btn btn-help" title="Hỗ trợ"></div>
          <div
            class="icon-cancel btn btn-close"
            title="Đóng"
            @click="hide()"
          ></div>
        </div>
      </div>

      <div class="content"></div>
    </div>
    <BaseConfirm ref="baseConfirm" />
  </div>
</template>
<script>
import axios from "axios";
import BaseConfirm from "@/components/common/baseControlAcounting/BaseConfirm";
export default {
  components: {
    BaseConfirm,
  },
  props: {
    formMode: String,
    idVacxinUpdate: String,
    maVacxin: String,
  },
  data() {
    return {
      lstvacxin: [],
      ttVacxin: {},
    };
  },
  created() {
    this.show();
  },
  methods: {
    /**
     * Thực hiện lấy bản ghi của sổ tiêm có mã là mã truyển vào
     * */
    async getVacxinByCode() {
      try {
        await axios
          .get(
            `http://localhost:64016/api/Vacxin/bycode/${this.ttVacxin.mavacxin}`
          )
          .then((response) => {
            if (response.data) {
              var res = response.data.data;
              if (res) {
                this.ttVacxin = res;
              }
            }
          })
          .catch(() => {});
      } catch (error) {
        console.log(error);
      }
    },

    // todo hiện dialog
    async show() {
      var me = this;
      this.isActive = true;
      this.dup = false;
      console.log(this.formMode);
      if (this.formMode == "update") {
        await axios
          .get("http://localhost:64016/api/Vacxin/" + this.idVacxinUpdate)
          .then((response) => {
            if (response.data) {
              var res = response.data.data;
              if (res) {
                this.disableMasotiem = true;
                me.ttVacxin = res;
                console.log(me.ttVacxin);
              }
            }
          })
          .catch((error) => {
            this.errorMessage = error.message;
            console.error("GET TTDKT by id Failed: ", error.message);
          });
      } else {
        this.resetInput();
      }
    },

    // todo reset lại các input
    resetInput() {},

    // todo ẩn dialog
    hide() {
      this.isActive = false;
      this.$router.push({ name: "manage-vaccines" });
    },

    /**
     * Thực hiện validate input bị trống
     * CreatedBy: nctu2
     * */
    tabValidate(id, message) {
      if (id == "tenvacxin") {
        console.log("tenvacxin");
        if (!this.ttVacxin.tenvacxin) {
          this.validation.tenvacxinVal = true;
          this.tenvacxinMsg = message;
        }
      }
    },

    /**
     * Thực hiện validate email không được bỏ trống
     * CreatedBy: nctu
     * */
    validateTenVacxin() {
      if (!this.ttVacxin.tenvacxin) {
        this.$refs.baseConfirm.showForm(
          "error",
          1,
          "Tên vắc xin không được để trống"
        );
        this.stateValidate = false;
        return false;
      } else {
        this.stateValidate = true;
        return true;
      }
    },
    validateData() {
      if (validateTenVacxin()) {
        return true;
      } else {
        return false;
      }
    },
  },
};
</script>

<style lang="scss" scoped>
.modal-register {
  width: 100%;
  height: 100%;
  font-size: 14px;
}
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

.input-search {
  width: 200px;
  padding: 8px 46px 8px 16px;
  border: 1px solid #beccc9;
}

.input-field .input-black {
  background-color: #f5f5f5;
  pointer-events: none;
}

.input-field .input-two-third {
  width: 437px;
}

.input-field .input-one-third {
  width: 210px;
}

.custom-autocomplete input {
  border: none;
  padding-left: 10px;
  font-size: 14px;
}

.v-text-field > .v-input__control > .v-input__slot:before {
  border-style: none;
}

.v-input {
  padding-top: 0px;
  margin-top: 0px;
}

.v-text-field__details {
  display: none;
}

.v-input__slot {
  margin-bottom: 0px;
}

.v-list-item__content .v-list-item__title {
  font-size: 14px;
}

.test-autocomplete {
  border: 1px solid black;
}

.modal-register .validate-warning {
  font-family: GoogleSans-Regular;
  font-size: 13px;
  color: red;
  background-color: white;
  /* z-index: 22; */
  position: absolute;
}

.modal-content {
  width: 100%;
  height: 100%;
  background-color: white;
  resize: both;
  overflow: auto;
  min-height: 530px;
  min-width: 705px;

  .header {
    width: 100%;
    height: 60px;
    display: flex;
    padding: 0 6px;
    box-sizing: border-box;
    display: flex;
    align-items: center;

    .title {
      line-height: 30px;
      font-family: GoogleSans-Bold;
      font-size: 16px;
    }

    .header-right {
      position: absolute;
      right: 0;
      display: flex;
      align-items: center;
      padding: 0 12px;

      .icon-cancel {
        background-size: 16px;
        margin-left: 2px;
      }
    }
  }

  .content {
    width: 100%;
    height: 100%;
    // padding: 6px 6px 6px 6px;
    box-sizing: border-box;
    overflow-y: auto;
    overflow-x: hidden;
    .step-content {
      width: 100%;
      height: 100%;
      box-sizing: border-box;

      .v-stepper__step {
        padding: 12px !important;
      }
      .v-stepper__items {
        height: calc(100% - 70px) !important;
        .v-stepper__content {
          padding: 0 !important;
          .v-stepper__wrapper {
            height: 100% !important;
          }
          .v-sheet.v-card {
            height: calc(100% - 75px);
          }
          .v-sheet.v-card:not(.v-sheet--outlined) {
            box-shadow: none;
          }
        }
        ::v-deep .v-input__slot {
          justify-content: center !important;
          margin-top: 4px;
          top: 10px;
        }
      }
      .contact-form {
        width: 100%;
        // height: calc(100% - 100px)
      }
    }
    .input-field {
      float: left;
      padding: 0 16px 16px 0px;
      position: relative;
      height: 77px;

      label {
        display: block;
        padding: 2px 2px 4px 2px;
      }

      input {
        height: 34px;
        box-sizing: border-box;
        border: #e4e4e4 1px solid;
        // outline-color: lightgreen;
        padding: 4px;
      }
    }
  }

  .footer {
    width: 100%;
    height: 50px;
    display: flex;
    align-items: center;
    position: absolute;
    padding: 10px;
    bottom: 30px;
    right: 20px;
    justify-content: end;
  }
}

.validate-warning {
  display: none;
  position: absolute;
  font-style: italic;
  padding-right: 0;
}
.hover-validate:hover ~ .validate-warning {
  display: block;
}
.modal-content .header .title {
  font-family: GoogleSans-Bold !important;
}
.borderRed {
  border: 1px solid red !important;
}
</style>
