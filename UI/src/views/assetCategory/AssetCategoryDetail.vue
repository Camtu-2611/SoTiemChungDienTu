<template>
  <div
    class="popup"
    v-show="isActive"
    @keydown.esc="hideForm"
    @keydown.ctrl.83.prevent.stop.exact="btnSaveOnClick"
  >
    <div class="popup-base"></div>
    <div class="popup-main" v-bind:style="{ width: widthForm }">
      <div class="resize-form" @click="resizeForm()" ref="resizeForm"></div>
      <div class="popup-header">
        <div class="popup-header-left">
          <div class="title-popup">Chi tiết loại tài sản</div>
        </div>
        <div class="popup-header-right">
          <div class="header-help"></div>
          <div class="header-close" @click="hideForm"></div>
        </div>
      </div>
      <div class="popup-content">
        <div class="popup-content-main">
          <div class="basic-infomation">
            <div class="row">
              <div class="position-input-left width-1-4">
                <InputText
                  :inputLabel="{ label: 'Mã loại tài sản', require: '*' }"
                  :inputValue="account.maloaits"
                  v-model="account.maloaits"
                  ref="inputAccountNumber"
                  @blur="
                    tabValidate(
                      'inputAccountNumber',
                      'Mã loại tài sản không được để trống.'
                    )
                  "
                />
              </div>
            </div>
            <div class="row">
              <div class="position-input-left width-1-2">
                <InputText
                  :inputLabel="{ label: 'Tên loại tài sản', require: '*' }"
                  :inputValue="account.tenloaits"
                  v-model="account.tenloaits"
                  ref="inputAccountName"
                  @blur="
                    tabValidate(
                      'inputAccountName',
                      'Tên loại tài sản không được để trống.'
                    )
                  "
                />
              </div>
              <div class="position-input-right width-1-2">
                <InputText
                  :inputLabel="{ label: 'Thông tin chi tiết', require: '' }"
                  :inputValue="account.thongtinchitiet"
                  v-model="account.thongtinchitiet"
                />
              </div>
            </div>

            <div class="row">
              <div class="position-input-left width-1-2">
                <div class="position-input-left width-1-2">
                  <ComboboxPlus
                    :inputLabel="{ label: 'Loại tài sản cha', require: '' }"
                    :comboboxValue="valueAccountParent"
                    :inputValue="account.maloaitscha"
                    v-model="account.maloaitscha"
                  />
                </div>
                <div class="position-1-4-right width-1-2">
                  <ComboboxPlus
                    :inputLabel="{ label: 'Trạng thái', require: '*' }"
                    :comboboxValue="valueCharacter"
                    :inputValue="account.tentinhtrang"
                    v-model="account.tentinhtrang"
                    ref="inputCharacter"
                    @blur="
                      tabValidate(
                        'inputCharacter',
                        'Trạng thái không được để trống.'
                      )
                    "
                  />
                </div>
              </div>
            </div>
            <div class="row-large">
              <div class="input-label">
                Ghi chú
                <span> </span>
              </div>
              <textarea v-model="account.ghichu"></textarea>
            </div>
            <div class="row-checkbox">
              <div class="row-checkbox-main">
                <!-- <div class="input-checkbox">
                  <input
                    type="checkbox"
                    v-model="account.foreignCurrencyAccounting"
                  />
                  <div class="label-checkbox">Sử dụng</div>
                </div> -->
              </div>
            </div>
          </div>
          <div class="collapse-information">
            <div class="collapse-header" @click="btnCollapseOnClick()">
              <div
                class="collapse-header-icon icon-dropdown-close"
                ref="iconCollapse"
              ></div>
              <div class="collapse-header-label">Thông tin chi tiết</div>
            </div>
            <!-- <div class="content-item" v-show="isCollapseInfo">
              <div class="row-item">
                <div class="row-width-1-2">
                  <div class="row-width-5-6">
                    <div class="row-width-1-2">
                      <input type="checkbox" v-model="account.isObject" />
                      <div class="label-checkbox">Đối tượng</div>
                    </div>
                    <div class="row-width-1-2">
                      <ComboboxPlus
                        readonly
                        :inputLabel="{ label: '', require: '' }"
                        :comboboxValue="valueObject"
                        :isEnable="account.isObject"
                        :inputValue="account.object"
                        v-model="account.object"
                      />
                    </div>
                  </div>
                </div>
                <div class="row-width-1-2">
                  <div class="row-width-5-6">
                    <div class="row-width-1-2">
                      <input type="checkbox" v-model="account.isBankAccount" />
                      <div class="label-checkbox">Tài khoản ngân hàng</div>
                    </div>
                    <div class="row-width-1-2"></div>
                  </div>
                </div>
              </div>
              <div class="row-item">
                <div class="row-width-1-2">
                  <div class="row-width-5-6">
                    <div class="row-width-1-2">
                      <input type="checkbox" v-model="account.isObjectThcp" />
                      <div class="label-checkbox">Đối tượng THCP</div>
                    </div>
                    <div class="row-width-1-2">
                      <ComboboxPlus
                        readonly
                        :inputLabel="{ label: '', require: '' }"
                        :comboboxValue="valueCombobox"
                        :isEnable="account.isObjectThcp"
                        :inputValue="account.objectThcp"
                        v-model="account.objectThcp"
                      />
                    </div>
                  </div>
                </div>
                <div class="row-width-1-2">
                  <div class="row-width-5-6">
                    <div class="row-width-1-2">
                      <input type="checkbox" v-model="account.isConstruction" />
                      <div class="label-checkbox">Công trình</div>
                    </div>
                    <div class="row-width-1-2">
                      <ComboboxPlus
                        readonly
                        :inputLabel="{ label: '', require: '' }"
                        :paddingLabel="'0px'"
                        :comboboxValue="valueCombobox"
                        :isEnable="account.isConstruction"
                        :inputValue="account.construction"
                        v-model="account.construction"
                      />
                    </div>
                  </div>
                </div>
              </div>
              <div class="row-item">
                <div class="row-width-1-2">
                  <div class="row-width-5-6">
                    <div class="row-width-1-2">
                      <input
                        type="checkbox"
                        v-model="account.isPurchaseOrder"
                      />
                      <div class="label-checkbox">Đơn đặt hàng</div>
                    </div>
                    <div class="row-width-1-2">
                      <ComboboxPlus
                        readonly
                        :inputLabel="{ label: '', require: '' }"
                        :comboboxValue="valueCombobox"
                        :isEnable="account.isPurchaseOrder"
                        :inputValue="account.purchaseOrder"
                        v-model="account.purchaseOrder"
                      />
                    </div>
                  </div>
                </div>
                <div class="row-width-1-2">
                  <div class="row-width-5-6">
                    <div class="row-width-1-2">
                      <input
                        type="checkbox"
                        v-model="account.isConstractSale"
                      />
                      <div class="label-checkbox">Hợp đồng bán</div>
                    </div>
                    <div class="row-width-1-2">
                      <ComboboxPlus
                        readonly
                        :inputLabel="{ label: '', require: '' }"
                        :paddingLabel="'0px'"
                        :comboboxValue="valueCombobox"
                        :isEnable="account.isConstractSale"
                        :inputValue="account.contractSale"
                        v-model="account.contractSale"
                      />
                    </div>
                  </div>
                </div>
              </div>
              <div class="row-item">
                <div class="row-width-1-2">
                  <div class="row-width-5-6">
                    <div class="row-width-1-2">
                      <input
                        type="checkbox"
                        v-model="account.isPurchaseContract"
                      />
                      <div class="label-checkbox">Hợp đồng mua</div>
                    </div>
                    <div class="row-width-1-2">
                      <ComboboxPlus
                        readonly
                        :inputLabel="{ label: '', require: '' }"
                        :paddingLabel="'0px'"
                        :comboboxValue="valueCombobox"
                        :isEnable="account.isPurchaseContract"
                        :inputValue="account.purchaseContract"
                        v-model="account.purchaseContract"
                      />
                    </div>
                  </div>
                </div>
                <div class="row-width-1-2">
                  <div class="row-width-5-6">
                    <div class="row-width-1-2">
                      <input type="checkbox" v-model="account.isItemsCp" />
                      <div class="label-checkbox">Khoản mục CP</div>
                    </div>
                    <div class="row-width-1-2">
                      <ComboboxPlus
                        readonly
                        :inputLabel="{ label: '', require: '' }"
                        :paddingLabel="'0px'"
                        :comboboxValue="valueCombobox"
                        :isEnable="account.isItemsCp"
                        :inputValue="account.itemsCp"
                        v-model="account.itemsCp"
                      />
                    </div>
                  </div>
                </div>
              </div>
              <div class="row-item">
                <div class="row-width-1-2">
                  <div class="row-width-5-6">
                    <div class="row-width-1-2">
                      <input type="checkbox" v-model="account.isUnit" />
                      <div class="label-checkbox">Đơn vị</div>
                    </div>
                    <div class="row-width-1-2">
                      <ComboboxPlus
                        readonly
                        :inputLabel="{ label: '', require: '' }"
                        :comboboxValue="valueCombobox"
                        :isEnable="account.isUnit"
                        :inputValue="account.unit"
                        v-model="account.unit"
                      />
                    </div>
                  </div>
                </div>
                <div class="row-width-1-2">
                  <div class="row-width-5-6">
                    <div class="row-width-1-2">
                      <input
                        type="checkbox"
                        v-model="account.isStatisticalSale"
                      />
                      <div class="label-checkbox">Mã thống kê</div>
                    </div>
                    <div class="row-width-1-2">
                      <ComboboxPlus
                        readonly
                        :inputLabel="{ label: '', require: '' }"
                        :comboboxValue="valueCombobox"
                        :isEnable="account.isStatisticalSale"
                        :inputValue="account.statisticalCode"
                        v-model="account.statisticalCode"
                      />
                    </div>
                  </div>
                </div>
              </div>
            </div> -->
          </div>
        </div>
      </div>
      <div class="popup-action">
        <div class="popup-action-main">
          <div class="popup-action-left">
            <div class="button-cancel" @click="hideForm">Hủy</div>
          </div>
          <div class="popup-action-right">
            <div class="button-save" @click="btnSaveOnClick">Cất</div>
            <div class="button-saveadd" @click="btnSaveAddOnClick">
              Cất và Thêm
            </div>
          </div>
        </div>
      </div>
    </div>
    <BaseLoading ref="loading" />
    <BaseConfirm ref="baseConfirm" />
  </div>
</template>

<script>
import InputText from '@/components/common/baseControlAcounting/InputText'
import ComboboxPlus from '@/components/common/baseControlAcounting/ComboboxPlus'
import BaseLoading from '@/components/common/baseControlAcounting/BaseLoading'
import BaseConfirm from '@/components/common/baseControlAcounting/BaseConfirm'

import axios from "axios";

export default {
  name: "AssetCategoryDetail",

  components: {
    InputText,
    ComboboxPlus,
    BaseLoading,
    BaseConfirm,
  },

  data() {
    return {
      isActive: false,
      widthForm: "800px",
      isCollapseForm: true,
      isCollapseInfo: false,
      account: {},
      records: [],
      stateForm: false,
      accountSelected: {},
      valueAccountParent: {},
      valueCharacter: {},
      valueCombobox: {},
      valueObject: {},
    };
  },
  created() {},
  computed: {},
  methods: {
    //  mở form Dialog
    showForm() {
      this.isActive = true;
      this.widthForm = "800px";
      this.setValueAccountParent();
      this.setValueCharacter();
      this.setValueObject();
      this.setValueCombobox();
      let inputs = document.querySelectorAll("input");
      inputs.forEach((e) => {
        e.classList.remove("class-error");
      });
      this.setAutoFocus("inputAccountNumber");
    },

    hideForm() {
      this.isActive = false;
      // console.log('reload');
      this.$emit("reloadData");
    },

    // điều chỉnh kích thước của form Dialog
    resizeForm() {
      this.isCollapseForm = !this.isCollapseForm;
      // nếu isCollapseForm = true: đang thu gọn
      if (this.isCollapseForm) {
        this.widthForm = "800px";
        this.$refs.resizeForm.classList.remove("resize-form-rotate");
      } else {
        this.widthForm = "calc(100% - 5px)";
        this.$refs.resizeForm.classList.add("resize-form-rotate");
      }
    },

    btnCollapseOnClick() {
      this.isCollapseInfo = !this.isCollapseInfo;
      if (!this.isCollapseInfo) {
        this.$refs.iconCollapse.classList.remove("icon-dropdown-close");
      } else {
        this.$refs.iconCollapse.classList.add("icon-dropdown-close");
      }
    },

    /**
     * Set focus cho 1 input, combobox, ...
     * CreatedBy: ntmanh(03/07/2021)
     * */
    setAutoFocus(refName) {
      const me = this;
      this.timeOut = setTimeout(() => {
        me.$refs[refName]?.$refs.inputComponent.focus();
      }, 200);
    },

    // set giá trị cho trường Tài khoản tổng hợp
    setValueAccountParent() {
      let contents = [];
      this.records.forEach((e) => {
        contents.push([e.maloaits, e.tenloaits
        ]);
      });
      this.valueAccountParent = {
        isPlus: false,
        isHeader: true,
        headerName: ["Mã loại tài sản", "Tên loại tài sản"],
        content: contents,
        fieldSelected: 0,
        widthColumn: ["40%", "60%"],
        widthForm: "212%",
        maxHeight: "160px",
        positionLeft: "0px",
        positionTop: "35px",
      };
    },

    // set giá trị cho trường tính chất
    setValueCharacter() {
      this.valueCharacter = {
        isPlus: false,
        isHeader: false,
        headerName: [],
        content: [["Đang sử dụng"], ["Ngưng sử dụng"]],
        fieldSelected: 0,
        widthColumn: ["100%"],
        widthForm: "100%",
        maxHeight: "160px",
        positionLeft: "0px",
        positionTop: "35px",
      };
    },

    // set giá trị cho trường đối tượng
    setValueObject() {
      this.valueObject = {
        isPlus: false,
        isHeader: false,
        headerName: [],
        content: [["Nhà cung cấp"], ["Khách hàng"], ["Nhân viên"]],
        fieldSelected: 0,
        widthColumn: ["100%"],
        widthForm: "100%",
        maxHeight: "160px",
        positionLeft: "0px",
        positionTop: "35px",
      };
    },

    // set giá trị mặc định cho các trường combobox
    setValueCombobox() {
      this.valueCombobox = {
        isPlus: false,
        isHeader: false,
        headerName: [],
        content: [["Chỉ cảnh báo"], ["Bắt buộc nhập"]],
        fieldSelected: 0,
        widthColumn: ["100%"],
        widthForm: "100%",
        maxHeight: "160px",
        positionLeft: "0px",
        positionTop: "35px",
      };
    },

    findIdAccountByCode(code) {
      for (let i = 0; i < this.records.length; i++) {
        if (this.records[i].maloaits == code) {
          return this.records[i].idloaitaisan;
        }
      }
      return "";
    },

    /**
     * Thực hiện lấy toàn bộ bản ghi của Nhà cung cấp
     * CreatedBy: ntmanh(25/06/2021)
     * */
    async getAllRecord() {
      try {
        var me = this;
        await axios
          .get("https://localhost:44327/api/LoaiTaiSan/GetAll")
          .then((response) => {
            me.records = response.data;
          })
          .catch(() => {});
      } catch (error) {
        console.log(error);
      }
    },

    /**
     * Thực hiện lấy 1 bản ghi theo ID, gọi từ API
     * Load sẵn dữ liệu theo các trường tương ứng
     * CreatedBy: ntmanh(28/06/2021)
     * */
    async getRecordById(id) {
      try {
        var me = this;
        await axios
          .get("https://localhost:44327/api/LoaiTaiSan/GetById/" + id)
          .then((response) => {
            me.account = response.data;
            me.$refs.loading.hideLoading();
          })
          .catch(() => {});
      } catch (error) {
        console.log(error);
      }
    },

    /**
     * Thực hiện lấy 1 bản ghi theo ID, gọi từ API
     * Load sẵn dữ liệu theo các trường tương ứng
     * CreatedBy: ntmanh(28/06/2021)
     * */
    async checkDuplicateCode(code) {
      try {
        var me = this;
        await axios
          .get(
            "https://localhost:44327/api/LoaiTaiSan/CheckDupCode?code=" +
              code
          )
          .then((response) => {
            me.stateValidate = response.data;
            me.$refs.loading.hideLoading();
          })
          .catch(() => {});
      } catch (error) {
        console.log(error);
      }
    },

    /**
     * Thực hiện thêm mới bản ghi
     * CreatedBy: ntmanh(28/06/2021)
     * */
    async insertRecord() {
      try {
        let me = this;
        await axios
          .post("https://localhost:44327/api/LoaiTaiSan", this.account)
          .then(() => {
            me.$refs.loading.hideLoading();
          })
          .catch(() => {});
      } catch (error) {
        console.log(error);
      }
    },

    /**
     * Thực hiện sửa thông tin của 1 bản ghi : Hệ thống tài khoản
     * CreatedBy: ntmanh(28/06/2021)
     * */
    async putRecord() {
      try {
        let me = this;
        await axios
          .put(
            "https://localhost:44327/api/LoaiTaiSan/" + this.account.idloaitaisan,
            this.account
          )
          .then(() => {
            me.$refs.loading.hideLoading();
            // console.log("sửa tài khoản thành công");
          })
          .catch(() => {
            console.error();
          });
      } catch (error) {
        console.log(error);
      }
    },
    /**
     * Thực hiện hiển thị form update dữ liệu
     * Load sẵn dữ liệu theo các trường tương ứng
     * dữ liệu được gọi API theo ID của bản ghi
     * CreatedBy: ntmanh(28/06/2021)
     * */
    showFormUpdate(id) {
      this.$refs.loading.showLoading();
      this.stateForm = true;
      this.showForm();
      this.getRecordById(id);
      this.getAllRecord();
    },

    /**
     * Thực hiện mở form với chế độ thêm mới
     * CreatedBy: ntmanh(28/06/2021)
     * */
    async showFormInsert() {
      await this.getAllRecord();
      this.showForm();
      this.stateForm = false;
      this.account = {
        tentinhtrang: "Đang sử dụng",
      };
    },

    // ============================= validate dữ liệu =============================

    /**
     * Thực hiện validate input bị trống
     * CreatedBy: ntmanh(05/07/2021)
     * */
    tabValidate(refName, message) {
      let input = this.$refs[refName].$refs.inputComponent;
      if (input.value.trim() == "") {
        input.classList.add("class-error");
        input.setAttribute("title", message);
      } else {
        input.classList.remove("class-error");
        input.setAttribute("title", "");
      }
    },

    /**
     * Thực hiện validate số tài khoản
     * CreatedBy: ntmanh(05/07/2021)
     * */

    validateAccountNumber() {
      if (
        this.account.maloaits == "" ||
        this.account.maloaits == null
      ) {
        this.$refs.baseConfirm.showForm(
          "error",
          1,
          "Mã loại tài sản không được để trống"
        );
        this.stateValidate = false;
        return false;
      }
      if (this.account.maloaits.length < 3) {
        this.$refs.baseConfirm.showForm(
          "error",
          1,
          "Mã loại tài sản phải có độ dài >= 3 ký tự."
        );
        this.stateValidate = false;
        return false;
      } else {
        let accParent = this.account.maloaitscha;
        let accChild = this.account.maloaits;
        accParent = accParent == null ? "" : accParent;
        for (let i = 0; i < accParent.length; i++) {
          if (accParent[i] != accChild[i]) {
            this.$refs.baseConfirm.showForm(
              "error",
              1,
              "Mã loại tài sản không hợp lệ. Mã loại tài sản chi tiết phải bắt đầu bằng số của Mã loại tài sản cha."
            );
            this.stateValidate = false;
            return false;
          }
        }
      }
    },

    /**
     * Thực hiện validate tên tài khoàn
     * CreatedBy: ntmanh(05/07/2021)
     * */
    validateAccountName() {
      if (this.account.tenloaits == "" || this.account.tenloaits == null) {
        this.$refs.baseConfirm.showForm(
          "error",
          1,
          "Tên loại tài sản không được để trống"
        );
        this.stateValidate = false;
        return false;
      }
    },

    /**
     * Thực hiện validate Tính chất
     * CreatedBy: ntmanh(05/07/2021)
     * */
    validateCharacter() {
      if (this.account.tentinhtrang == "" || this.account.tentinhtrang == null) {
        this.$refs.baseConfirm.showForm(
          "error",
          1,
          "Trạng thái không được để trống"
        );
        this.stateValidate = false;
        return false;
      }
    },

    async validateCheckCode() {
      // check trùng mã
      await this.checkDuplicateCode(this.account.maloaits);
      if (this.stateValidate == false) {
        this.$refs.baseConfirm.showForm("error", 1, "Mã loại tài sản đã tồn tại.");
        this.stateValidate = false;
        return false;
      }
    },
    validateData() {
      this.validateAccountNumber();
      this.validateAccountName();
      this.validateCharacter();
    },

    // =================== Thực hiện lưu dữ liệu =========================

    /**
     * Thực hiện Cất dữ liệu
     * CreatedBy: ntmanh(28/06/2021)
     * */
    async btnSaveOnClick() {
      let idParent = this.findIdAccountByCode(this.account.maloaitscha);
      this.account.idloaitscha = idParent == "" ? undefined : idParent;
      this.stateValidate = true;
      this.validateData();
      if (this.stateValidate == false) return;
      //form ở chế độ Thêm mới
      if (this.stateForm == false) {
        this.$refs.loading.showLoading();
        this.stateValidate = true;
        await this.validateCheckCode();
        if (this.stateValidate == false) return;
        await this.insertRecord();
        this.hideForm();
      }
      // form ở chế độ Sửa
      else {
        this.$refs.loading.showLoading();
        await this.putRecord();
        this.hideForm();
      }
    },

    /**
     * Thực hiện Cất và thêm bản ghi
     * CreatedBy: ntmanh(23/06/2021)
     * */

    async btnSaveAddOnClick() {
      let idParent = this.findIdAccountByCode(this.account.maloaitscha);
      this.account.idloaitscha = idParent == "" ? undefined : idParent;
      this.stateValidate = true;
      this.validateData();
      if (this.stateValidate == false) return;
      //form ở chế độ Thêm mới
      if (this.stateForm == false) {
        this.stateValidate = true;
        await this.validateCheckCode();
        if (this.stateValidate == false) return;
        await this.insertRecord();
      }
      // form ở chế độ Sửa
      else {
        await this.putRecord();
      }
      this.showFormInsert();
    },
  },

  //===================================== hết methods ===============================
};
</script>


<style scoped>
.popup {
  height: 100%;
}
.popup-base {
  width: 100%;
  background: rgba(0, 0, 0, 0.4);
  position: fixed;
  left: 0;
  top: 0;
  height: 100%;
  z-index: 15;
  opacity: 1;
}
.popup-main {
  height: 100%;
  position: fixed;
  top: 0;
  right: 0;
  background-color: #fff;
  z-index: 15;
}
.resize-form {
  position: absolute;
  top: calc(50% - 60px);
  left: -6px;
  width: 12px;
  height: 50px;
  background-color: #fff;
  border: 1px solid #d4d7dc;
  border-radius: 8px;
  background-image: url("../../components/common/baseResourcesAccounting/img/Sprites.64af8f61.svg");
  background-position: -35px -343px;
  background-repeat: no-repeat;
  padding: 18px 0px;
  box-sizing: border-box;
  cursor: pointer;
}
.resize-form-rotate {
  transform: rotate(180deg);
}
.popup-header {
  width: 100%;
  height: 66px;
  display: flex;
  color: #111;
  position: relative;
  margin-bottom: 12px;
}
.popup-header-left {
  height: 100%;
  padding: 14px 16px 24px;
  display: flex;
  box-sizing: border-box;
  position: absolute;
  left: 0;
}
.title-popup {
  font-size: 24px;
  font-weight: 600;
}
.popup-header-right {
  height: 100%;
  padding: 12px;
  box-sizing: border-box;
  display: flex;
  position: absolute;
  right: 0;
}
.header-help {
  width: 24px;
  height: 24px;
  cursor: pointer;
  margin-right: 6px;
  background-image: url("../../components/common/baseResourcesAccounting/img/Sprites.64af8f61.svg");
  background-repeat: no-repeat;
  background-position: -89px -144px;
}
.header-close {
  width: 24px;
  height: 24px;
  cursor: pointer;
  background-image: url("../../components/common/baseResourcesAccounting/img/Sprites.64af8f61.svg");
  background-repeat: no-repeat;
  background-position: -144px -144px;
}

.popup-content {
  width: 100%;
  height: calc(100% - 146px);
  padding: 0 16px 16px 16px;
  box-sizing: border-box;
  overflow-y: auto;
  overflow-x: hidden;
  display: flex;
  flex-direction: column;
  flex: 1;
  min-height: 0;
  min-width: 0;
}
::-webkit-scrollbar {
  width: 10px;
  height: 10px;
  background: #f1f1f1;
}
::-webkit-scrollbar-thumb {
  background: #b8bcc3;
}
.popup-content-main {
  width: 100%;
  height: auto;
  position: relative;
}

.row {
  height: 54px;
  width: 100%;
  display: flex;
  flex-direction: row;
  margin-bottom: 12px;
}
.row-large {
  height: 77px;
  width: 100%;
  display: flex;
  flex-direction: column;
  margin-bottom: 12px;
}
.row-checkbox {
  margin-bottom: 18px;
}
.row-checkbox-main {
  display: flex;
  align-items: center;
}
.input-checkbox {
  display: flex;
  align-items: center;
}
.label-checkbox {
}
input[type="checkbox"] {
  position: relative;
  cursor: pointer;
}
input[type="checkbox"]:before {
  content: "";
  display: block;
  position: absolute;
  width: 16px;
  height: 16px;
  top: -2px;
  left: 0;
  border: 1px solid #babec5;
  border-radius: 3px;
  background-color: white;
}
input[type="checkbox"]:checked:before {
  animation: spin 1s linear 1s;
}
input[type="checkbox"]:checked:after {
  content: "";
  display: block;
  width: 5px;
  height: 10px;
  border: solid #06a2f0;
  border-width: 0 2px 2px 0;
  -webkit-transform: rotate(45deg);
  -ms-transform: rotate(45deg);
  transform: rotate(45deg);
  position: absolute;
  /* top: 2px; */
  left: 6px;
  animation: spin 1s linear 1s;
}
.input-label {
  font-weight: bold;
  padding-bottom: 4px;
  display: flex;
  align-items: center;
  font-size: 12px;
}
.input-label span {
  color: #ff0000;
  font-weight: normal;
  margin-left: 4px;
}

textarea {
  outline: none;
  height: 100%;
  width: 100%;
  padding: 9px;
  box-sizing: border-box;
  outline: none;
  border: 1px solid #babec5;
  font-size: 13px;
  font-family: Arial, Helvetica, sans-serif;
  border-radius: 3px;
  background-color: #fff !important;
  resize: none;
}
textarea:focus {
  border: 1px solid #049ae6;
}
::placeholder {
  font-family: "Segoe UI", Tahoma, Geneva, Verdana, sans-serif;
  font-style: italic;
  font-size: 12px;
}
.label-checkbox {
  margin: 0px 10px;
  color: #111;
}
.width-1-4 {
  width: 25%;
  height: 54px;
}
.width-1-2 {
  width: 50%;
  height: 54px;
}
.position-input-left {
  position: absolute;
  left: 0;
  padding-right: 12px;
  box-sizing: border-box;
  display: flex;
}
.position-input-right {
  position: absolute;
  right: 0;
}
.position-1-4-right {
  position: absolute;
  right: 0;
  padding-right: 12px;
  box-sizing: border-box;
}
.collapse-information {
  display: flex;
  flex-direction: column;
}
.collapse-header {
  padding: 10px 14px;
  display: flex;
  align-items: center;
  position: relative;
  height: 24px;
  width: 180px;
}
.collapse-header:hover {
  cursor: pointer;
  color: #35bf22;
}

.collapse-header-icon {
  position: absolute;
  left: 0;
  width: 16px;
  height: 16px;
  background-image: url("../../components/common/baseResourcesAccounting/img/Sprites.64af8f61.svg");
  background-repeat: no-repeat;
  background-position: -320px -360px;
  cursor: pointer;
}
.icon-dropdown-close {
  transform: rotate(90deg);
  transition: transform 0.3s linear;
}
.collapse-header-label {
  font-size: 16px;
  position: absolute;
  left: 20px;
}

.content-item {
  padding: 0px 10px 10px;
}
.row-item {
  height: 32px;
  width: 100%;
  padding-bottom: 12px;
  position: relative;
  display: flex;
}
.combobox-label {
  display: flex;
}
.row-width-1-2 {
  width: 50%;
  display: flex;
}
.row-width-5-6 {
  width: 83.33333%;
  display: flex;
  justify-content: center;
  align-items: center;
  white-space: nowrap;
}
.popup-action {
  width: 100%;
  height: 68px;
  display: flex;
  padding: 16px;
  box-sizing: border-box;
}
.popup-action-main {
  width: 100%;
  height: 100%;
  position: relative;
}
.popup-action-left {
  position: absolute;
  left: 0;
}
.button-cancel {
  height: 36px;
  padding: 8px 20px;
  border: 1px solid #8d9096;
  color: #111;
  box-sizing: border-box;
  display: flex;
  justify-content: center;
  align-items: center;
  font-weight: 600;
  font-size: 13px;
  border-radius: 3px;
  cursor: pointer;
}
.button-cancel:hover {
  background-color: #d2d3d6;
}
.popup-action-right {
  position: absolute;
  right: 0;
  display: flex;
}
.button-save {
  height: 36px;
  padding: 8px 20px;
  border: 1px solid #8d9096;
  color: #111;
  box-sizing: border-box;
  display: flex;
  justify-content: center;
  align-items: center;
  font-weight: 600;
  font-size: 13px;
  border-radius: 3px;
  margin: 0px 9.75px;
  cursor: pointer;
}
.button-save:hover {
  background-color: #d2d3d6;
}
.button-saveadd {
  height: 36px;
  padding: 8px 20px;
  border: 1px solid #8d9096;
  color: #fff;
  box-sizing: border-box;
  display: flex;
  justify-content: center;
  align-items: center;
  font-weight: 600;
  font-size: 13px;
  border-radius: 3px;
  background-color: #038cd1;
  cursor: pointer;
}

.button-saveadd:hover {
  background-color: #06a2f0;
}
input {
  z-index: 0 !important;
}
.combo-menu {
  z-index: 10000 !important;
}
</style>