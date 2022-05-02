<template>
  <div
    class="payment-detail-component"
    @keydown.esc="btnCloseOnClick"
    @keydown.ctrl.83.prevent.stop.exact="btnSaveOnClick(0)"
  >
  <div class="background-opacity"></div>
    <div class="container">
      <div class="header-layout">
        <div class="top-header">
          <!-- <div class="icon-form">
            <div class="icon-form-img"></div>
          </div> -->
          <div class="title-name">Thêm bảo dưỡng tài sản</div>
          <div class="header-button">
            <div class="button-header">
              <div class="buttons btn-close" @click="btnCloseOnClick()"></div>
            </div>
          </div>
        </div>
      </div>
      <div class="body-layout display-flex-column">
        <div class="body-information">
          <div class="main-information">
            <div class="position-relative">
              <div class="width-3-4 position-left">
                <div class="position-relative">
                  <div class="width-4-5 positon-left">
                    <div class="display-flex-column">
                      <div
                        class="row"
                        style="display: flex; justify-content: space-between"
                      >
                        <div style="margin-right: 8px; width: 30%">
                          <InputText
                            :inputLabel="{ label: 'Tên tài sản', require: '*' }"
                            :inputValue="record.tentaisan"
                            v-model="record.tentaisan"
                            :disabled="stateReadonly"
                          />
                        </div>
                        <div style="margin-right: 8px; width: 30%">
                          <InputText
                            :inputLabel="{
                              label: 'Loại tài sản',
                              require: '*',
                            }"
                            :inputValue="record.tenloaitaisan"
                            v-model="record.tenloaitaisan"
                            :disabled="stateReadonly"
                          />
                        </div>
                        <div style="width: 30%">
                          <InputText
                            :inputLabel="{
                              label: 'Bộ phận sử dụng',
                              require: '',
                            }"
                            :inputValue="record.bophansudung"
                            v-model="record.bophansudung"
                            :disabled="stateReadonly"
                          />
                        </div>
                      </div>
                      <div class="row" style=" padding-bottom: 0; margin-top: 4px;">
                        <span
                          style="
                            font-weight: bold;
                            display: flex;
                            align-items: center;
                            font-size: 14px;
                          "
                          >Kế hoạch bảo dưỡng</span
                        >
                      </div>
                      <div
                        class="row"
                        style="display: flex; justify-content: space-between"
                      >
                        <div
                          class="input-date"
                          style="margin-right: 8px; width: 30%"
                        >
                          <InputDate
                            :inputLabel="{
                              label: 'Ngày dự kiến',
                              require: '*',
                            }"
                            :inputValue="record.ngaydukien"
                            v-model="record.ngaydukien"
                            ref="inputAccountingDate"
                            @blur="tabAccountingDate()"
                            :disabled="stateReadonly"
                          />
                        </div>
                        <div style="margin-right: 8px; width: 30%">
                          <InputText
                            :inputLabel="{
                              label: 'Dự toán',
                              require: '*',
                            }"
                            :inputValue="record.dutoan"
                            v-model="record.dutoan"
                            :disabled="stateReadonly"
                            @keyup="keyUpReasonMaster"
                            @change="updateIsChangeExplain"
                          />
                        </div>
                        <div style="width: 30%">
                          <InputText
                            :inputLabel="{
                              label: 'Loại bảo dưỡng',
                              require: '*',
                            }"
                            :inputValue="record.loaibaoduong"
                            v-model="record.loaibaoduong"
                            :disabled="stateReadonly"
                            @keyup="keyUpReasonMaster"
                            @change="updateIsChangeExplain"
                          />
                        </div>
                      </div>
                      <div class="row" style="margin-top: 12px;">
                        <div style="width: 50%">
                          <InputText
                            :inputLabel="{
                              label: 'Mô tả',
                              require: '',
                            }"
                            :inputValue="record.mota"
                            v-model="record.mota"
                            :disabled="stateReadonly"
                            @keyup="keyUpReasonMaster"
                            @change="updateIsChangeExplain"
                          />
                        </div>
                        <div style="width: 50%"></div>
                      </div>

                      <!-- <div class="reference">
                        <div class="ref-name">Tham chiếu</div>
                        <div class="ref-more">...</div>
                      </div> -->
                    </div>
                  </div>
                </div>
              </div>
              <div class="width-1-4 position-right display-flex-column">
                <!-- <div class="text-right">Tổng tiền</div>
                <div class="text-right number-total">
                  {{ formatMoney(totalMoney) }},0
                </div> -->
              </div>
            </div>
          </div>
        </div>
      </div>

      <div class="footer" v-if="!stateReadonly">
        <div class="footer-main">
          <div class="btn-simple">
            <div class="button-rectangle" @click="btnCancelOnClick()">Hủy</div>
          </div>
          <div class="display-flex-row">
            <div class="btn-simple">
              <div class="button-rectangle btn-save" @click="btnSaveOnClick(0)">
                Đồng ý
              </div>
            </div>
            <div class="btn-dropdown" v-if="stateButton == 'save_and_add'">
              <ButtonDropdown
                :buttonName="'Cất và Thêm'"
                :borderMain="'3px 0 0 3px'"
                :borderDropdown="'0 3px 3px 0'"
                :backgroundColor="'#06a2f0'"
                :padding="'6px 14px 6px 20px'"
                @btnDropDownOnClick="btnSaveOnClick(1)"
                @btnOptionDropdown="btnOptionDropdown"
                ref="btnDropdown"
              />
            </div>

            <div class="btn-dropdown" v-if="stateButton == 'save_and_close'">
              <ButtonDropdown
                :buttonName="'Cất và Đóng'"
                :borderMain="'3px 0 0 3px'"
                :borderDropdown="'0 3px 3px 0'"
                :backgroundColor="'#06a2f0'"
                :padding="'6px 14px 6px 20px'"
                @btnDropDownOnClick="btnSaveOnClick(2)"
                @btnOptionDropdown="btnOptionDropdown"
                ref="btnDropdown"
              />
            </div>
          </div>
        </div>
      </div>

      <div class="footer" v-if="stateReadonly">
        <div class="footer-main">
          <div class="btn-simple display-flex-row position-left">
            <div class="button-rectangle2">
              <div class="btn-rec rec-1"></div>
            </div>
            <div class="button-rectangle2">
              <div class="btn-rec rec-2"></div>
            </div>
          </div>
          <div class="position-center display-flex-row">
            <div class="btn-center display-flex-row">
              <div class="btn-center-icon ic-print"></div>
              <div class="btn-label">In</div>
              <div class="ic-drop"></div>
            </div>
            <div class="btn-center display-flex-row border-left">
              <div class="btn-center-icon ic-tool"></div>
              <div class="btn-label">Tiện ích</div>
            </div>
          </div>
          <div class="position-right display-flex-row">
            <div class="btn-simple">
              <div class="button-rectangle" @click="btnEditOnClick">Sửa</div>
            </div>
            <div class="btn-simple">
              <div class="button-green">Ghi sổ</div>
            </div>
          </div>
        </div>
      </div>
    </div>
    <BaseLoading ref="loading" />
    <BaseConfirm
      ref="baseConfirm"
      @processActionYes="processActionYes"
      @processActionNo="processActionNo"
    />
    <RecordAction ref="recordAction" @processAction="processDropDownAction" />
  </div>
</template>

<script>
// import ButtonGuide from "@/components/common/baseControlAcounting/ButtonGuide";
import InputText from "@/components/common/baseControlAcounting/InputText";
// import ComboboxPlus from "@/components/common/baseControlAcounting/ComboboxPlus";
import InputDate from "@/components/common/baseControlAcounting/InputDate";
import ButtonDropdown from "@/components/common/baseControlAcounting/ButtonDropdown";
import BaseLoading from "@/components/common/baseControlAcounting/BaseLoading";
import BaseConfirm from "@/components/common/baseControlAcounting/BaseConfirm";
import RecordAction from "@/components/common/baseControlAcounting/RecordAction";

import axios from "axios";
import * as moment from "moment";

export default {
  name: "CTBaoDuong",
  props: [],

  components: {
    // ButtonGuide,
    InputText,
    InputDate,
    ButtonDropdown,
    BaseLoading,
    BaseConfirm,
    RecordAction,
    // InputNumber,
  },

  data() {
    return {
      stateForm: "",
      stateReadonly: false,
      stateCombobox: "offline",
      stateButton: "save_and_add",
      stateSaveData: 0,
      idRecord: "",
      record: {},
      recordCompare: "",
      newCode: "",
      stateValidate: false,
      numberFormat: 0,
      accountingDate: null, // ngày hạch toán
      paymentDate: null, // ngày phiếu chi
      amountOfMoney: 0,
      totalMoney: 0,
      stateEditDate: true,
      typeMoney: "VND",
      valueTypeForm: {},
      valueObject: {},
      valueGridObject: {},
      valueEmployee: {},
      valueTypeMoney: {},
      valueDebtAccount: {},
      valueOwnAccount: {},
      valueBankAccount: {},
      providers: [],
      accounts: [],
      rowGrids: [],
      rowGrids2: [],
      watchChangeObject: "",
      providerCodeMaster: "",

      // số lượng chứng từ
      numberAmount: 0,
    };
  },

  created() {
    this.generateData();
    this.stateButton = window.localStorage.getItem("stateButton");
  },
  mounted() {
    this.stateForm = this.$route.params.state;
    this.idRecord = this.$route.params.id;
    this.processShowForm();
    this.$refs.inputObject?.$refs.inputComponent?.focus();
  },

  computed: {},
  watch: {
    // khi ngày hạch toán thay đổi, stateEditDate=true, thay đổi giá trị ngày phiếu chi theo ngày hạch toán
    accountingDate() {
      // nếu state = true, ngày hạch toán thay đổi, ngày chứng từ phải thay đổi theo
      if (this.stateEditDate == true) this.paymentDate = this.accountingDate;

      // nếu ngày hạch toán bằng ngày chứng từ, set trạng thái state = true, ngược lại set = false
      if (this.accountingDate == this.paymentDate) this.stateEditDate = true;
      else this.stateEditDate = false;
    },

    // nếu ngày hạch toán bằng ngày chứng từ, set trạng thái state = true, ngược lại set = false
    paymentDate() {
      if (this.accountingDate == this.paymentDate) this.stateEditDate = true;
      else this.stateEditDate = false;
    },
  },

  methods: {
    /**
     * Set giá trị cho combobox thể loại phiếu chi
     * CreatedBy: ntmanh(02/07/2021)
     * */
    async generateData() {
      await this.getAllProvider();
      await this.getAllAccount();
      this.setValueTypeForm();
      this.setValueObject();
      this.setValueTypeMoney();
      this.setValueEmployee();
      this.setValueDebtAccount();
      this.setValueOwnAccount();
      this.setValueBankAccount();
    },

    // ===================== khởi tạo giá trị cho các combobox, grid, ... ===================
    /**
     * Set giá trị cho combobox thể loại phiếu chi
     * CreatedBy: ntmanh(02/07/2021)
     * */
    setValueTypeForm() {
      this.valueTypeForm = {
        isPlus: false,
        isHeader: false,
        headerName: [],
        content: [
          ["1. Trả tiền nhà cung cấp (không theo hóa đơn)"],
          ["2. Tạm ứng cho nhân viên"],
          ["3. Chi mua ngoài có hóa đơn"],
          ["4. Gửi tiền vào ngân hàng "],
          ["5. Chi khác"],
        ],
        fieldSelected: 0,
        widthColumn: ["100%"],
        widthForm: "100%",
        maxHeight: "180px",
        positionLeft: "0px",
        positionTop: "35px",
      };
    },
    /**
     * Set giá trị cho combobox loại tiền
     * CreatedBy: ntmanh(02/07/2021)
     * */
    setValueTypeMoney() {
      this.valueTypeMoney = {
        isPlus: false,
        isHeader: true,
        headerName: ["Mã loại tiền", "Tên loại tiền"],
        content: [
          ["VND", "Việt Nam đồng"],
          ["USD", "Đô la Mỹ"],
        ],
        fieldSelected: 0,
        widthColumn: ["40%", "60%"],
        widthForm: "280px",
        maxHeight: "180px",
        positionLeft: "-150px",
        positionTop: "35px",
      };
    },
    /**
     * Set giá trị cho combobox đối tượng
     * CreatedBy: ntmanh(02/07/2021)
     * */
    setValueObject() {
      // lấy data từ nhà cung cấp
      var contents = [];
      this.providers.forEach((p) => {
        contents.push([
          p.providerCode,
          p.providerName,
          p.taxcode,
          p.address,
          p.telephoneNumber,
        ]);
      });
      this.valueObject = {
        isPlus: true,
        isHeader: true,
        headerName: [
          "Đối tượng",
          "Tên đối tượng",
          "Mã số thuế",
          "Địa chỉ",
          "Số điện thoại",
        ],
        content: contents,
        fieldSelected: 1,
        widthColumn: ["120px", "250px", "100px", "300px", "100px"],
        widthForm: "880px",
        maxHeight: "160px",
        positionLeft: "0px",
        positionTop: "35px",
      };

      this.valueGridObject = Object.assign({}, this.valueObject);
      this.valueGridObject.isPlus = false;
      this.valueGridObject.fieldSelected = 0;
      this.valueGridObject.positionLeft = "-575px";
    },

    setValueEmployee() {
      this.valueEmployee = {
        isPlus: true,
        isHeader: true,
        headerName: ["Mã nhân viên", "Tên nhân viên", "Đơn vị", "ĐT di động"],
        content: [
          ["NV0001", "Nguyễn Đức Anh", "Đơn vị 1", "(0974)-894 264"],
          ["NV0002", "Trần Văn Nam"],
          ["NV0003", "Dương Văn Hải", "Đơn vị 3", "(0963)-252 532"],
          ["NV0004", "Bùi Minh Anh", "Đơn vị 2", "(0922)-313 212"],
          ["NV0005", "Nguyễn Trọng Khang"],
          ["NV0006", "Hoàng Đức Cường"],
        ],
        fieldSelected: 1,
        widthColumn: ["120px", "200px", "120px", "120px"],
        widthForm: "570px",
        maxHeight: "160px",
        positionLeft: "0px",
        positionTop: "35px",
      };
    },

    // set giá trị cho tài khoản nợ

    setValueDebtAccount() {
      let contents = [];
      this.accounts.forEach((a) => {
        contents.push([a.accountNumber, a.accountName]);
      });
      this.valueDebtAccount = {
        isPlus: false,
        isHeader: true,
        headerName: ["Số tài khoản", "Tên tài khoản"],
        content: contents,
        fieldSelected: 0,
        widthColumn: ["33%", "67%"],
        widthForm: "382px",
        maxHeight: "180px",
        positionLeft: "0px",
        positionTop: "35px",
      };
    },

    // set giá trị cho tài khoản có
    setValueOwnAccount() {
      this.valueOwnAccount = {
        isPlus: false,
        isHeader: true,
        headerName: ["Số tài khoản", "Tên tài khoản"],
        content: [
          ["121322221", "Trần Văn Nam"],
          ["238349283", "Nguyễn Văn Bảy"],
        ],
        fieldSelected: 0,
        widthColumn: ["33%", "67%"],
        widthForm: "382px",
        maxHeight: "180px",
        positionLeft: "0px",
        positionTop: "35px",
      };
    },

    // set giá trị cho tài khoản có
    setValueBankAccount() {
      this.valueBankAccount = {
        isPlus: false,
        isHeader: true,
        headerName: ["Số tài khoản", "Tên tài khoản", "Chi nhánh"],
        content: [
          ["12123123", "Ngân hàng TMCP Á Châu", "Đống Đa"],
          ["18928123", "Ngân hàng Bản Việt", "Hai Bà Trưng"],
        ],
        fieldSelected: 0,
        widthColumn: ["150px", "250px", "120px"],
        widthForm: "532px",
        maxHeight: "180px",
        positionLeft: "-273px",
        positionTop: "35px",
      };
    },
    // giá trị mặc định hiển thị trên grid
    setValueDefaultGrid() {
      this.rowGrids = [
        {
          data: {
            explain: "Chi tiền cho",
            debtAccount: "",
            ownAccount: "1111",
            amountOfMoney: "",
            exchangeMoney: "",
            providerCode: "",
            providerName: "",
          },
          isText: true,
          isChangeExplain: true,
          isChangeExchangeMoney: true,
          isChangeObject: true,
        },
      ];

      this.rowGrids2 = [
        {
          data: {
            explain: "Chi tiền cho",
            debtAccount: "",
            ownAccount: "1111",
            amountOfMoney: "",
            exchangeMoney: "",
            providerCode: "",
            providerName: "",
          },
          isText: true,
          isChangeExplain: true,
          isChangeExchangeMoney: true,
          isChangeObject: true,
        },
      ];
    },

    // ================= xử lý các hành động khi bấm có trên form xác nhận ======================

    async processActionYes(idAction) {
      if (idAction == "deleteAllRow") {
        this.deleteAllRowGrid();
      }
      if (idAction == "autoIncrement") {
        await this.getNewCode();
        this.record.licenseNumber = this.newCode;
        this.btnSaveOnClick(this.stateSaveData);
      }
      if (idAction == "closePaymentDetail") {
        this.btnSaveOnClick(this.stateSaveData);
      }
    },

    // hiển thị các option khi bấm vào nút button dropdown
    btnOptionDropdown(top, left) {
      left = left - 58 + "px";
      top = top - 62 + "px";
      let itemActions = ["Cất và thêm", "Cất và đóng"];
      this.$refs.recordAction.showForm(left, top, itemActions);
    },

    // xử lý khi bấm vào icon xổ xuống pử dropdown
    processDropDownAction(id) {
      if (id == 0) {
        window.localStorage.setItem("stateButton", "save_and_add");
        this.stateButton = "save_and_add";
      }
      if (id == 1) {
        window.localStorage.setItem("stateButton", "save_and_close");
        this.stateButton = "save_and_close";
      }
    },

    processActionNo() {
      this.$router.go(-1);
    },
    // =================================điều hướng form===============================================

    /**
     * Thực hiện đóng form, điều hướng đến form khác
     * CreatedBy: ntmanh(02/07/2021)
     * */
    btnCloseOnClick() {
      try {
        if (this.stateForm == "view") return this.$router.go(-1);
        if (this.recordCompare != JSON.stringify(this.record)) {
          this.$refs.baseConfirm.showForm(
            "question",
            3,
            "Dữ liệu đã bị thay đổi. Bạn có muốn cất không?",
            "closePaymentDetail"
          );
        } else {
          this.$router.go(-1);
        }
      } catch (error) {
        error;
      }
    },

    btnCancelOnClick() {
      if (this.stateForm == "create") {
        this.$router.go(-1);
      } else {
        this.stateReadonly = true;
        this.stateCombobox = "offline";
        this.stateForm = "view";
      }
    },

    // ======================== set focus refs động ==================================

    /**
     * Focus ref động
     * CreatedBy: ntmanh(06/07/2021)
     * */

    setFocusDynamicRef(refName) {
      let me = this;
      setTimeout(() => {
        me.$refs[refName][0]?.$refs.inputComponent?.focus();
      }, 150);
    },

    // ==================== Xử lý phần table hạch toán =========================
    /**
     * Thực hiện ẩn hiện chế độ input/ hiển thị text ở table hạch toán
     * Dựa vào index của dòng được kích vào, thì chuyển trạng thái isText=false: bật các ô input
     * CreatedBy: ntmanh(02/07/2021)
     * */
    rowTableOnClick(index) {
      for (let i = 0; i < this.rowGrids.length; i++) {
        this.rowGrids[i].isText = true;
        if (i == index) {
          this.rowGrids[index].isText = false;
        }
      }

      //   let jsonCompare = JSON.stringify({});
      // let rowData = Object.assign([], this.rowGrids);
      //   for(let i = 0; i < rowData.length; i++){
      //     if(jsonCompare == JSON.stringify(rowData[i].data))
      //     {
      //       if(i == index) continue
      //       this.btnDeleteRowTable(i);
      //     }
      //   }
    },

    /**
     * Thực hiện thêm 1 dòng trong table
     * CreatedBy: ntmanh(02/07/2021)
     * */
    btnAddRowTable() {
      // 1. Đặt chế độ hiển thị text của tất cả các dòng bên trên bằng  true: chỉ hiển thị text, ẩn input
      this.rowGrids.forEach((element) => {
        element.isText = true;
      });

      // 2. Khởi tạo 1 dòng mới, và add vào rowBankAccounts
      this.rowGrids.push({
        data: {
          explain: this.rowGrids[this.rowGrids.length - 1].data.explain,
          debtAccount: this.rowGrids[this.rowGrids.length - 1].data.debtAccount,
          ownAccount: this.rowGrids[this.rowGrids.length - 1].data.ownAccount,
          amountOfMoney: "",
          exchangeMoney: "",
          providerCode:
            this.rowGrids[this.rowGrids.length - 1].data.providerCode,
          providerName:
            this.rowGrids[this.rowGrids.length - 1].data.providerName,
        },
        isText: false,
        isChangeExplain: true,
        isChangeExchangeMoney: true,
        isChangeObject: true,
      });

      //up date trạng thái được sửa diễn giải, đối tượng ở row grid

      this.updateIsChangeExplain();
      this.updateIsChangeObject();
    },

    btnAddRowTable2() {
      // 1. Đặt chế độ hiển thị text của tất cả các dòng bên trên bằng  true: chỉ hiển thị text, ẩn input
      this.rowGrids2.forEach((element) => {
        element.isText = true;
      });

      // 2. Khởi tạo 1 dòng mới, và add vào rowBankAccounts
      this.rowGrids2.push({
        data: {
          explain: this.rowGrids2[this.rowGrids2.length - 1].data.explain,
          debtAccount:
            this.rowGrids2[this.rowGrids2.length - 1].data.debtAccount,
          ownAccount: this.rowGrids2[this.rowGrids2.length - 1].data.ownAccount,
          amountOfMoney: "",
          exchangeMoney: "",
          providerCode:
            this.rowGrids2[this.rowGrids2.length - 1].data.providerCode,
          providerName:
            this.rowGrids2[this.rowGrids2.length - 1].data.providerName,
        },
        isText: false,
        isChangeExplain: true,
        isChangeExchangeMoney: true,
        isChangeObject: true,
      });

      //up date trạng thái được sửa diễn giải, đối tượng ở row grid

      this.updateIsChangeExplain();
      this.updateIsChangeObject();
    },

    /**
     * Thực hiện xóa 1 dòng ở trong gird
     * CreatedBy: ntmanh(02/07/2021)
     * */
    btnDeleteRowTable(index) {
      this.rowGrids.splice(index, 1);
      this.calculatorTotalMoney();
    },

    /**
     * Thực hiện xóa tất cả dòng trong gird
     * CreatedBy: ntmanh(02/07/2021)
     * */
    btnDeleteAllRowOnClick() {
      this.$refs.baseConfirm.showForm(
        "warning",
        2,
        "Bạn có thực sự muốn xóa tất cả các dòng đã nhập không?",
        "deleteAllRow"
      );
    },
    deleteAllRowGrid() {
      this.rowGrids = [
        {
          data: {
            explain: "",
            debtAccount: "",
            ownAccount: "1111",
            amountOfMoney: "",
            exchangeMoney: "",
            providerCode: "",
            providerName: "",
          },
          isText: true,
          isChangeExplain: true,
          isChangeExchangeMoney: true,
          isChangeObject: true,
        },
      ];
    },

    /**
     * Thực hiện hiển thị lại định dạng tiền
     * CreatedBy: ntmanh(02/07/2021)
     * */
    formatMoney(salary) {
      if (salary == null) {
        return "0";
      } else;
      {
        if (Number.isNaN(salary)) {
          return "";
        } else {
          salary = salary.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1.");
          if (salary == 0) salary = 0;
          return salary;
        }
      }
    },

    // splitNumberFromString(text) {
    //   if(text.trim == "" || text == null || text == undefined) text = '0'
    //   var number = text.match(/\d/g);
    //   number = number.join("");
    //   return number;
    // },

    calculatorTotalMoney() {
      let totalAmountOfMoney = 0;
      let totalExchangeMoney = 0;
      let exchangeRate = this.record.exchangeRate;
      exchangeRate = exchangeRate == "" ? 0 : exchangeRate;
      exchangeRate = parseInt(exchangeRate);
      let me = this;
      setTimeout(() => {
        for (let i = 0; i < me.rowGrids.length; i++) {
          // lấy giá trị số tiền dòng thứ i
          let amountOfMoney = me.rowGrids[i].data.amountOfMoney;
          amountOfMoney = amountOfMoney == "" ? 0 : amountOfMoney;
          amountOfMoney = parseInt(amountOfMoney);

          // lấy quy đổi dòng thứ i
          let exchangeMoney = me.rowGrids[i].data.exchangeMoney;
          exchangeMoney = exchangeMoney == "" ? 0 : exchangeMoney;
          exchangeMoney = parseInt(exchangeMoney);
          // nếu là tiền Việt
          if (me.typeMoney.toUpperCase() == "VND") {
            exchangeMoney = amountOfMoney;
          }
          // nếu không phải tiền Việt
          if (me.typeMoney.toUpperCase() != "VND") {
            // nếu tiền quy đổi ở trạng thái cho phép thay đổi
            if (me.rowGrids[i].isChangeExchangeMoney == true)
              exchangeMoney = amountOfMoney * exchangeRate;
          }
          this.rowGrids[i].data.exchangeMoney = exchangeMoney;
          totalAmountOfMoney += parseInt(amountOfMoney);
          totalExchangeMoney += parseInt(exchangeMoney);
        }
        // gán lại giá trị tổng tiền theo riêng loại tiền
        this.amountOfMoney = totalAmountOfMoney;
        // gán lại tổng tiền đã quy đổi về tiên Việt
        this.totalMoney = totalExchangeMoney;
      }, 0);
      return totalExchangeMoney;
    },

    // ================== xử lý grid ===========================

    // nếu như ô diễn giải ở dòng thứ i bị thay đổi thì set trạng thái không được thay đổi của dòng diễn giải đó

    setChangeExChangeMoney(index) {
      this.rowGrids[index].isChangeExchangeMoney = true;
    },

    // giá trị ô quy đổi bị thay đổi thì không cho phép chỉnh sửa
    changeValueExchange(index) {
      this.rowGrids[index].isChangeExchangeMoney = false;
    },

    // giá trị tài khoản bị thay đổi thì không cho phép chỉnh sửa

    // khi giá trị đối tượng thay đổi
    changeValueObject(index) {
      this.updateIsChangeObject();
      for (let i = 0; i < this.providers.length; i++) {
        if (
          this.rowGrids[index].data.providerCode ==
          this.providers[i].providerCode
        ) {
          this.rowGrids[index].data.providerName =
            this.providers[i].providerName;
        }
      }
    },

    // kiểm tra xem có dòng object nào trùng mới object master không
    // nếu trùng thì set trạng thái chính sửa bằng true, master thay đổi thì row ở grid thay đổi theo

    updateIsChangeObject() {
      for (let i = 0; i < this.rowGrids.length; i++) {
        if (this.rowGrids[i].data.providerCode == this.providerCodeMaster) {
          this.rowGrids[i].isChangeObject = true;
        } else this.rowGrids[i].isChangeObject = false;
      }
    },

    // khi lý do chi thay đổi => kiểm tra xem dòng diễn giải nào ở grid rỗng
    // hoặc trùng với lý do chi trên master, thì set trạng thái được chỉnh sửa cho các dòng đó

    keyUpReasonMaster() {
      for (let i = 0; i < this.rowGrids.length; i++) {
        if (this.rowGrids[i].isChangeExplain == true) {
          this.rowGrids[i].data.explain = this.record.reason;
        }
      }
    },

    // khi tab ra ngoài Input lý do chi, set trạng thái được phép chỉnh sửa cho các dòng ở dưới
    // nếu trùng với lý do chi ở master hoặc rỗng, thì set trạng thái chỉnh sửa là true

    updateIsChangeExplain() {
      for (let i = 0; i < this.rowGrids.length; i++) {
        if (
          this.rowGrids[i].data.explain.trim() == this.record.reason.trim() ||
          this.rowGrids[i].data.explain.trim() == ""
        ) {
          this.rowGrids[i].isChangeExplain = true;
        } else {
          this.rowGrids[i].isChangeExplain = false;
        }
      }
    },

    // ===================== xử lý phần mở form ===============

    /**
     * Thực hiện mở form thêm mới
     * CreatedBy: ntmanh(02/07/2021)
     * */

    async processShowForm() {
      if (this.stateForm == "create") {
        this.stateReadonly = false;
        this.stateCombobox = "online";
        this.record = {};
        await this.getNewCode();
        this.setValueDefaultGrid();
        this.record.licenseNumber = this.newCode;
        this.accountingDate = moment().format("YYYY-MM-DD");
        this.paymentDate = this.accountingDate;
        this.record.reason = "Chi tiền cho";
        this.totalMoney = 0;
        this.amountOfMoney = 0;
        this.recordCompare = JSON.stringify(Object.assign({}, this.record));
      }
      if (this.stateForm == "view") {
        await this.getRecordById(this.idRecord);
        this.newCode = this.record.licenseNumber;
        this.rowGrids = this.toListObject(this.record.accounting);
        this.typeMoney = this.record.typeMoney;
        this.totalMoney = this.record.amountOfMoney;
        this.paymentDate = moment(this.record.paymentDate).format("YYYY-MM-DD");
        this.accountingDate = moment(this.record.accountingDate).format(
          "YYYY-MM-DD"
        );
        this.calculatorTotalMoney();
        this.stateReadonly = true;
        this.stateCombobox = "offline";
      }
      if (this.stateForm == "clone") {
        await this.getRecordById(this.idRecord);
        this.rowGrids = this.toListObject(this.record.accounting);
        this.typeMoney = this.record.typeMoney;
        this.totalMoney = this.record.amountOfMoney;
        this.paymentDate = moment(this.record.paymentDate).format("YYYY-MM-DD");
        this.accountingDate = moment(this.record.accountingDate).format(
          "YYYY-MM-DD"
        );
        this.calculatorTotalMoney();
        await this.getNewCode();
        this.record.paymentId = undefined;
        this.record.createdDate = undefined;
        this.record.licenseNumber = this.newCode;
        this.stateReadonly = false;
        this.stateCombobox = "online";
        this.recordCompare = JSON.stringify(Object.assign({}, this.record));
      }
    },

    // ======================= xử lý định dạng Json =======================

    /**
     * Xử lý các list có dạng JSON:
     * 1. Parse list đó về thành Json Object
     * 2. Khởi tạo các ra 1 list chứa các object có định dạng: {index: "", data: {}, isText: ""}
     * 3. return về 1 list chứa các object có đúng định dạng trên
     * CreatedBy: ntmanh(21/06/2021)
     * */
    toListObject(obj) {
      if (obj == null || obj == "") return [];
      var rows = [];
      var data = JSON.parse(obj);
      data.forEach((element) => {
        rows.push({
          data: element,
          isText: true,
          isChangeExplain: true,
          isChangeExchangeMoney: true,
          isChangeObject: true,
        });
      });
      return rows;
    },

    /**
     * Thực hiện lấy phần data từ các array
     * CreatedBy: ntmanh(21/06/2021)
     * */
    getDataFromArray(arr) {
      var data = [];
      arr.forEach((element) => {
        data.push(element.data);
      });
      return data;
    },

    /**
     * Xử lý định dạng lại các thuộc tính có kiểu Json: từ Json Object => Json String
     * CreatedBy: ntmanh(23/06/2021)
     * */
    processToStringJson() {
      this.record.accounting = JSON.stringify(
        this.getDataFromArray(this.rowGrids)
      );
    },

    // ==================== phần tương tác với API ====================

    /**
     * Lấy 1 bản ghi phiếu chi theo Id
     * CreatedBy: ntmanh(02/07/2021)
     * */
    async getRecordById(id) {
      var me = this;
      await axios
        .get("https://localhost:44391/api/v1/Payments/" + id)
        .then((response) => {
          me.record = response.data.data;
          me.$refs.loading.hideLoading();
        })
        .catch();
    },

    /**
     * Lấy 1 bản ghi phiếu chi theo mã phiếu
     * CreatedBy: ntmanh(05/07/2021)
     * */
    async getByCode(code) {
      var me = this;
      await axios
        .get("https://localhost:44391/api/v1/Payments/GetByCode?code=" + code)
        .then((response) => {
          me.record = response.data.data;
          me.$refs.loading.hideLoading();
        })
        .catch();
    },

    /**
     * Lấy danh sách đối tượng từ bảng nhà cung cấp: gọi qua API
     * CreatedBy: ntmanh(02/07/2021)
     * */
    async getAllProvider() {
      var me = this;
      await axios
        .get("https://localhost:44391/api/v1/Providers")
        .then((response) => {
          me.providers = response.data.data;
          me.$refs.loading.hideLoading();
        })
        .catch();
    },

    /**
     * Lấy danh sách đối tượng từ bảng nhà cung cấp: gọi qua API
     * CreatedBy: ntmanh(02/07/2021)
     * */
    async getAllAccount() {
      var me = this;
      await axios
        .get("https://localhost:44391/api/v1/Accounts")
        .then((response) => {
          me.accounts = response.data.data;
          me.$refs.loading.hideLoading();
        })
        .catch();
    },

    /**
     * Lấy 1 mã số phiếu chi mới
     * CreatedBy: ntmanh(02/07/2021)
     * */
    async getNewCode() {
      let me = this;
      await axios
        .get("https://localhost:44391/api/v1/Payments/GetNewCode")
        .then((response) => {
          me.newCode = response.data.data;
          return response.data.data;
        })
        .catch();
    },

    /**
     * Check trùng mã số phiếu chi
     * trả về true: nếu không trùng/ trả về false: nếu trùng
     * CreatedBy: ntmanh(02/07/2021)
     * */
    async checkExistCode(code) {
      try {
        var me = this;
        await axios
          .get(
            "https://localhost:44391/api/v1/Payments/CheckDuplicateCode?code=" +
              code
          )

          .then((response) => {
            me.stateValidate = response.data.data;
            return response.data.data;
          })
          .catch();
      } catch (error) {
        console.log(error);
      }
    },

    /**
     * Thêm mới bản ghi
     * CreatedBy: ntmanh(02/07/2021)
     * */
    insertRecord() {
      try {
        this.processToStringJson();
        axios
          .post("https://localhost:44391/api/v1/Payments", this.record)
          .then(() => {
            console.log("Thêm thành công");
          })
          .catch();
      } catch (error) {
        error;
      }
    },

    /**
     * Sửa thông tin bản ghi
     * CreatedBy: ntmanh(02/07/2021)
     * */
    updateRecord() {
      try {
        this.processToStringJson();
        axios
          .put(
            "https://localhost:44391/api/v1/Payments/" + this.record.paymentId,
            this.record
          )
          .then(() => {
            console.log("sửa thành công");
          })
          .catch((error) => {
            console.log(error);
          });
      } catch (error) {
        console.log(error);
      }
    },
    // ==================== xử lý các item được chọn từ combobox ===================

    /**
     * Bind dữ liệu địa chỉ, lý do chi, khi đối tượng được chọn
     * CreatedBy: ntmanh(02/07/2021)
     * */
    rowObjectSelected(index) {
      let row = this.providers[index];
      this.providerCodeMaster = row.providerCode;
      this.record.providerId = row.providerId;
      this.record.address = row.address;
      this.record.reason = "Chi tiền cho " + row.providerName;

      for (let i = 0; i < this.rowGrids.length; i++) {
        if (this.rowGrids[i].isChangeObject == true) {
          this.rowGrids[i].data.providerCode = row.providerCode;
          this.rowGrids[i].data.providerName = row.providerName;
        }
        if (this.rowGrids[i].isChangeExplain == true) {
          this.rowGrids[i].data.explain = "Chi tiền cho " + row.providerName;
        }
      }
      this.updateIsChangeObject();
    },

    /**
     * Thay đổi thể loại tiền
     * CreatedBy: ntmanh(02/07/2021)
     * */
    rowTypeMoneyClicked(index) {
      // nếu là loại tiền VND
      if (index == 0) {
        this.typeMoney =
          this.valueTypeMoney.content[index][this.valueTypeMoney.fieldSelected];
        this.record.exchangeRate = "";
        this.valueTypeMoney.positionLeft = "-150px";
        this.calculatorTotalMoney();
      }
      // nếu là loại tiền khác
      if (index == 1) {
        this.typeMoney =
          this.valueTypeMoney.content[index][this.valueTypeMoney.fieldSelected];
        this.valueTypeMoney.positionLeft = "0px";
        this.record.exchangeRate = 23150;
        this.calculatorTotalMoney();
      }
    },

    // ==================== validate dữ liệu =========================

    tabAccountingDate() {
      let result = { validate: true, mess: "" };
      let input = this.$refs["inputAccountingDate"].$refs.inputComponent;
      if (this.paymentDate > this.accountingDate) {
        let message =
          "Ngày hạch toán phải lớn hơn hoặc bằng Ngày chứng từ <" +
          moment(this.paymentDate).format("DD/MM/YYYY") +
          ">. Xin vui lòng kiểm tra lại.";
        input.classList.add("class-error");
        input.setAttribute("title", message);
        result = { validate: false, mess: message };
      } else {
        input.classList.remove("class-error");
        input.setAttribute("title", "");
      }
      return result;
    },

    /**
     * Validate khi tab ra bên ngoài
     * CreatedBy: ntmanh(03/07/2021)
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
     * Validate khi tab ra bên ngoài: Sử dụng cho các :refs động
     * CreatedBy: ntmanh(03/07/2021)
     * */

    tabValidateDynamicRef(refName, message) {
      let input = this.$refs[refName][0].$refs.inputComponent;
      if (input.value.trim() == "") {
        input.classList.add("class-error");
        input.setAttribute("title", message);
      } else {
        input.classList.remove("class-error");
        input.setAttribute("title", "");
      }
    },

    //check trống input
    validateInputEmpty() {
      if (
        this.record.licenseNumber.trim() == "" ||
        this.record.licenseNumber == null
      ) {
        this.$refs.baseConfirm.showForm(
          "error",
          1,
          "Số phiếu chi không được để trống."
        );
        this.stateValidate = false;
        return false;
      }

      // validate tài khoản không được trống

      for (let i = 0; i < this.rowGrids.length; i++) {
        //check trống tài khoản nợ
        if (this.rowGrids[i].data.debtAccount.trim() == "") {
          this.$refs.baseConfirm.showForm(
            "error",
            1,
            "Tài khoản nợ không được để trống."
          );
          this.stateValidate = false;
          return false;
        }

        // check trống tài khoản có
        if (this.rowGrids[i].data.ownAccount.trim() == "") {
          this.$refs.baseConfirm.showForm(
            "error",
            1,
            "Tài khoản có không được để trống."
          );
          this.stateValidate = false;
          return false;
        }
      }
    },
    //3. check ngày hạch toán và ngày chứng từ
    validateAccountingDate() {
      let accDate = this.tabAccountingDate();
      if (accDate.validate == false) {
        this.$refs.baseConfirm.showForm("warning", 1, accDate.mess);
        this.stateValidate = false;
        return false;
      }
    },
    async validateExistCode() {
      await this.checkExistCode(this.record.licenseNumber);
      // nếu = false: đã trùng mã
      // hiển thị gợi ý tự động tăng
      if (this.stateValidate == false) {
        this.$refs.baseConfirm.showForm(
          "warning",
          2,
          "Số chứng từ <" +
            this.record.licenseNumber +
            "> đã tồn tại. Bạn có muốn chương trình tự động tăng số chứng từ không?",
          "autoIncrement"
        );
        this.stateValidate = false;
        return false;
      }
    },

    /**
     * Thực hiện validate dữ liệu trước khi cất
     * CreatedBy: ntmanh(02/07/2021)
     * */
    async validateObject() {
      let result = true;
      // validate ngày hạch toán
      result = this.validateAccountingDate();
      if (result == false) return;
      //số phiếu chi không được bỏ trống
      result = this.validateInputEmpty();
      if (result == false) return;
      //  check trùng mã
      if (this.stateForm == "create" || this.stateForm == "clone") {
        result = await this.validateExistCode();
        if (result == false) return;
      }
    },
    // ==================== Lưu dữ liệu ===============================

    /**
     * Kích hoạt chế độ sửa
     * CreatedBy: ntmanh(02/07/2021)
     * */
    btnEditOnClick() {
      this.stateReadonly = false;
      this.stateCombobox = "online";
      this.stateForm = "update";
      this.getByCode(this.record.licenseNumber);
      this.recordCompare = JSON.stringify(Object.assign({}, this.record));
    },
    /**
     * Thực hiên chức năng khi bấm nút Cất
     * CreatedBy: ntmanh(02/07/2021)
     * */
    async saveData() {
      // gán lại các giá trị
      this.record.typeMoney = this.typeMoney;
      this.record.paymentDate = this.paymentDate;
      this.record.accountingDate = this.accountingDate;
      this.record.amountOfMoney = this.totalMoney;

      // validate dữ liệu
      this.stateValidate = true;
      await this.validateObject();
      if (this.stateValidate == false) {
        return false;
      }
      if (this.stateForm == "create" || this.stateForm == "clone") {
        this.insertRecord();
      }
      if (this.stateForm == "update") {
        this.updateRecord();
      }
    },

    async btnSaveOnClick(btn) {
      let state = await this.saveData();
      this.stateSaveData = btn;
      if (state == false) return;
      if (btn == 0) {
        this.stateReadonly = true;
        this.stateCombobox = "offline";
        this.stateForm = "view";
        return;
      }
      if (btn == 1) {
        this.stateForm = "create";
        this.processShowForm();
      }
      if (btn == 2) {
        this.$router.go(-1);
      }
    },

    // nút cất và đóng
    // ====================== hết methods ==============================
  },
};
</script>

<style scoped>
.payment-detail-component {
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 100vh;
  z-index: 10;
  display: block;
}
div {
  display: block;
}
.background-opacity{
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 100vh;
  background: #000;
  opacity: 0.4;
  z-index: 10;
}
.container {
  width: 800px;
  height: 460px;
  background-color: #fff;
  display: flex;
  flex-direction: column;
  position: absolute;
  top: calc(50% - 230px);
  left: calc(50% - 400px);
  z-index: 100;
}
.header-layout {
  display: block;
  top: 0;
  width: 100%;
  background-color: #fff;
  z-index: 2;
}
.top-header {
  padding: 9px 16px;
  display: flex;
  margin-bottom: 7px;
  position: relative;
}
.icon-form {
  display: flex;
  align-items: center;
  justify-content: center;
}
.icon-form-img {
  height: 24px;
  width: 24px;
  background-image: url("../../components/common/baseResourcesAccounting/img/Sprites.64af8f61.svg");
  background-position: -648px -144px;
  background-repeat: no-repeat;
}
.title-name {
  font-weight: 700;
  font-size: 20px;
  padding: 0 0 0 16px;
  color: #111;
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
}
.header-combobox {
  width: 350px;
  display: flex;
  align-items: center;
  padding-left: 50px;
}
.header-button {
  height: 36px;
  display: flex;
  align-items: center;
  right: 16px;
  position: absolute;
}
.btn-guide {
  margin: 0px 12px;
}
.button-header {
  padding: 6px 8px;
  cursor: pointer;
  height: 100%;
  display: flex;
  align-items: center;
}
.buttons {
  width: 24px;
  height: 24px;
  background-image: url("../../components/common/baseResourcesAccounting/img/Sprites.64af8f61.svg");
  background-repeat: no-repeat;
}
.btn-setting {
  background-position: -32px -144px;
}
.btn-help {
  background-position: -89px -144px;
}
.btn-close {
  background-position: -144px -144px;
}

.body-layout {
  overflow: auto;
  position: relative;
  height: calc(100% - 111px);
  z-index: 0;
}
::-webkit-scrollbar {
  width: 10px;
  height: 10px;
  background: #f1f1f1;
}
::-webkit-scrollbar-thumb {
  background: #b8bcc3;
}
.body-information {
  background-color: #fff;
  width: 100%;
  position: sticky;
  left: 0;
  z-index: 5;
}
.main-information {
  padding: 16px 30px 24px;
  height: 215px;
}
.position-relative {
  position: relative;
  display: flex;
}
.width-1-2 {
  width: 50%;
}
.width-3-4 {
  width: 100%;
}
.width-1-4 {
  width: 25%;
}
.width-4-5 {
  width: 100%;
}
.width-1-5 {
  width: 20%;
}
.width-3-7 {
  width: calc(3 * 100% / 7);
}
.width-4-7 {
  width: calc(4 * 100% / 7);
  height: 100%;
}
.w-240 {
  width: 240px;
  height: 54px;
  display: flex;
}
.position-left {
  position: absolute;
  left: 0;
}
.position-right {
  position: absolute;
  right: 0;
}
.display-flex-row {
  display: flex;
  flex-direction: row;
}
.display-flex-column {
  display: flex;
  flex-direction: column;
}
.row {
  height: 54px;
  width: 100%;
  display: flex;
  flex-direction: row;
  padding: 0px 16px 12px 0px;
  margin-top: 5px;
}
.input-date {
  height: 54px;
  padding-bottom: 2px;
}
.row-input-right {
  height: 54px;
  width: 168px;
  padding-bottom: 2px;
  padding-left: 16px;
  border-left: 1px solid #d4d7dc;
  margin-left: 16px;
  z-index: 1;
  margin-top: 5px;
}
.text-right {
  text-align: right;
}
.number-total {
  font-size: 36px;
  font-weight: 700;
}
.reference {
  width: 100%;
  display: flex;
  padding: 14px;
}
.ref-name {
  margin-right: 16px;
}
.ref-more {
  cursor: pointer;
  color: #0075c0;
  font-weight: 700;
  white-space: nowrap;
  overflow: hidden;
  font-size: 12px;
}
.grid {
  background: #fff;
  width: 100%;
  position: sticky;
  left: 0;
  display: flex;
  flex-direction: column;
  z-index: 4;
}
.grid-tool {
  width: calc(100% - 38px);
  height: 32px;
  padding: 26px 19px;
  display: flex;
  align-items: center;
  position: relative;
}
.grid-content {
  z-index: 3;
}
.grid-header {
  display: flex;
}
.col-header {
  padding: 6px 10px;
  border-right: 1px solid #c7c7c7;
  border-bottom: 2px solid #c7c7c7;
  background-color: #eceef1;
  box-sizing: border-box;
  display: flex;
  font-weight: bold;
  text-transform: uppercase;
  font-size: 12px;
}
.grid-body {
  display: flex;
  flex-direction: column;
}
.grid-row {
  display: flex;
}
.col-body-2 {
  padding: 10.5px 10px;
  box-sizing: border-box;
  display: flex;
  border-right: 1px dotted #c7c7c7;
  border-bottom: 1px solid #c7c7c7;
  background-color: #fff;
}
.col-body-1 {
  padding: 3.5px 10px;
  box-sizing: border-box;
  display: flex;
  border-right: 1px dotted #c7c7c7;
  border-bottom: 1px solid #c7c7c7;

  background-color: #fff;
}
.grid-row:hover .col-body-1 {
  background-color: #f3f9f9 !important;
}
.grid-row:hover .col-body-2 {
  background-color: #f3f9f9 !important;
}
.col-input {
  background-color: #f4f5f8 !important ;
}
.col-1 {
  min-width: 40px;
  position: sticky;
  left: 30px;
  z-index: 1;
}
.col-2 {
  min-width: 120px;
}
.col-2-1 {
  min-width: 200px;
}
.col-3 {
  min-width: 200px;
}
.col-3-1 {
  min-width: 250px;
}
.col-4 {
  min-width: 160px;
}
.col-4-1 {
  min-width: 1000px;
}
.col-5 {
  min-width: 150px;
}
.col-6 {
  min-width: 150px;
}
.col-7 {
  min-width: 150px;
}
.col-8 {
  min-width: 150px;
  width: -webkit-fill-available;
}
.col-9 {
  min-width: 40px;
  position: sticky;
  right: 30px;
}
.col-bottom {
  background-color: #fff;
  display: flex;
  align-items: center;
  padding: 4px 9px 4px 8px;
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
  color: #111;
  box-sizing: border-box;
}
.col-blank-left {
  background-color: #fff !important;
  position: sticky;
  left: 0;
  border: 0;
  z-index: 10;
  padding: 0px 15px;
}
.col-blank-right {
  background-color: #fff !important;
  position: sticky;
  right: 0;
  border: 0;
  z-index: 1;
  padding: 0px 15px;
}

.row-end div {
  background-color: #fff !important;
}
.col-center {
  justify-content: center;
  align-items: center;
}
.col-right {
  justify-content: flex-end;
}
.text-bold {
  font-weight: bold;
}

.col-delete {
  width: 43px;
  height: 100%;
  box-sizing: border-box;
  min-width: 43px;
  position: sticky;
  right: 30px;
  border-left: 1px dotted #c7c7c7;
  border-right: 0px;
  display: flex;
  align-items: center;
  justify-content: space-between;
  z-index: 1000;
}
.icon-delete {
  width: 16px;
  height: 16px;
  background-image: url("../../components/common/baseResourcesAccounting/img/Sprites.64af8f61.svg");
  background-position: -464px -312px;
  cursor: pointer;
}
.row-option {
  color: #0075c0;
  font-weight: bold;
  display: flex;
  align-items: center;
}
.row-option-button {
  cursor: pointer;
}

.row-option-dropdown {
  width: 16px;
  height: 16px;
  margin-left: 20px;
  cursor: pointer;
  border: none;
  background-image: url("../../components/common/baseResourcesAccounting/img/Sprites.64af8f61.svg");
  background-repeat: no-repeat;
  background-position: -896px -359px;
}
.tab-label {
  height: max-content;
  position: absolute;
  left: 19px;
  padding: 0px 16px;
  color: #0075c0;
  font-weight: 700;
  text-decoration: underline;
}
.grid-option {
  position: absolute;
  right: 30px;
  align-items: center;
  justify-content: flex-end;
  display: flex;
}
.grid-option-item {
  display: flex;
}
.label-option {
  display: flex;
  align-items: center;
  padding: 0px 10px 0px 20px;
}
.combobox-option {
  width: 100px;
}
.number-group {
  width: 90px;
}
input:focus {
  border: 1px solid #2ca01c;
}
.grid-control {
  width: 100%;
  padding: 0 30px 26px;
  box-sizing: border-box;
  background-color: #fff;
  position: sticky;
  left: 0;
  z-index: 0;
}
.btn-grid {
  padding: 10px 0px 32px;
  display: flex;
}
.btn-item {
  margin-right: 10px;
  padding: 2px 20px;
  border: 1px solid #8d9096;
  border-radius: 2.5px;
  font-size: 12px;
  font-weight: 700;
  cursor: pointer;
}
.btn-disable {
  color: #afafaf;
  margin-right: 10px;
  padding: 2px 20px;
  border: 1px solid #8d9096;
  border-radius: 2.5px;
  font-size: 12px;
  font-weight: 700;
  cursor: pointer;
}

.btn-item:hover {
  background-color: #d2d3d6;
}
.control-file {
  padding: 7px 0px;
}
.title-upload {
  display: flex;
  margin-bottom: 6px;
}
.label-icon {
  width: 18px;
  height: 18px;
  background-image: url("../../components/common/baseResourcesAccounting/img/Sprites.64af8f61.svg");
  background-position: -539px -203px;
}
.label-text {
  margin-left: 8px;
  font-weight: 700;
}
.title-detail {
  margin-left: 15px;
  color: #757575;
  white-space: nowrap;
}
.input-upload {
  background: #fff;
  padding: 16px 20px;
  box-sizing: border-box;
  border-radius: 2px;
  position: relative;
  border: 1px solid #babec5;
  display: flex;
  align-items: center;
  justify-content: center;
  flex-direction: column;
  float: left;
  min-width: 340px;
}
.file-upload {
  width: 100%;
  height: 100%;
  display: flex;
}
.input-upload input {
  position: absolute;
  width: 100%;
  height: 100%;
  opacity: 0;
  left: 0;
  top: 0;
  cursor: pointer;
}
input[type="file"] {
  appearance: none;
  background-color: initial;
  align-items: baseline;
  color: inherit;
  text-overflow: ellipsis;
  white-space: pre;
  text-align: start !important;
  border: initial;
  overflow: hidden !important;
}
.file-detail {
  width: 100%;
  color: #757575;
}
.file-name {
  width: 100%;
  margin: 0px 0px 10px 10px;
  display: flex;
  position: relative;
}
.file-name-text {
  color: #0075c0;
  text-overflow: ellipsis;
  overflow: hidden;
  cursor: pointer;
  display: block;
  max-width: calc(100% - 77px);
  white-space: nowrap;
  padding: 0;
  font-style: normal;
}
.file-name-size {
  margin-left: 6px;
  font-style: normal;
}
.x-file {
  position: absolute;
  right: 0;
  margin-right: 10px;
  cursor: pointer;
}
.file-detail {
  font-style: italic;
  font-size: 12px;
  text-align: center;
}

.footer {
  padding: 8px 16px;
  box-sizing: border-box;
  position: absolute;
  bottom: 0;
  width: 100%;
  color: #000;
  border-top: 1px solid #cacaca;
  background-color: #fff;
}
.footer-main {
  display: flex;
  position: relative;
  justify-content: flex-end;
  align-items: center;
  height: 34px;
}
.btn-simple {
  margin-right: 6px;
  color: #000;
}
.btn-save {
  background: #06a2f0;
  color: #fff;
}
.button-rectangle {
  padding: 7px 20px;
  border: 1px solid #8d9096;
  /* color: #fff; */
  box-sizing: border-box;
  display: flex;
  justify-content: center;
  align-items: center;
  font-weight: 600;
  font-size: 13px;
  border-radius: 3px;
  cursor: pointer;
  margin-right: 6px;
}

.button-rectangle2 {
  border: 1px solid #b1b2b3;
  color: #fff;
  border-radius: 3px;
  cursor: pointer;
  margin-right: 6px;
  padding: 8px;
}
.btn-rec {
  width: 16px;
  height: 16px;
  background-image: url("../../components/common/baseResourcesAccounting/img/Sprites.64af8f61.svg");
  background-repeat: no-repeat;
}
.rec-1 {
  background-position: -33px -408px;
}

.rec-2 {
  background-position: -80px -407px;
}
.button-green {
  height: 34px;
  padding: 6px 20px;
  box-sizing: border-box;
  color: #fff;
  font-weight: bold;
  background-color: #35bf22;
  border-radius: 3px;
  cursor: pointer;
}
.btn-dropdown {
  width: fit-content;
  height: 34px;
}
.position-center {
  text-align: center;
}
.btn-center {
  padding: 4px 16px;
  align-items: center;
  justify-content: center;
}
.border-left {
  border-left: 1px solid #b8bcc3;
}
.btn-center-icon {
  background-image: url("../../components/common/baseResourcesAccounting/img/Sprites.64af8f61.svg");
  background-repeat: no-repeat;
  width: 24px;
  height: 24px;
  margin-right: 8px;
}
.btn-label {
  color: #b8bcc3;
  font-weight: bold;
}
.ic-print {
  background-position: -33px -200px;
}
.ic-tool {
  background-position: -200px -199px;
}
.ic-drop {
  background-image: url("../../components/common/baseResourcesAccounting/img/Sprites.64af8f61.svg");
  background-repeat: no-repeat;
  width: 16px;
  height: 16px;
  background-position: -844px -358px;
}

input:disabled {
  background-color: #eff0f2;
}
.disable {
  background-color: #eff0f2 !important;
}

.row-checkbox {
  display: flex;
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
  padding: 0px 10px;
}
input[type="checkbox"] {
  position: relative;
  cursor: pointer;
}
input[type="checkbox"]:before {
  content: "";
  display: block;
  position: absolute;
  width: 18px;
  height: 18px;
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
  width: 6px;
  height: 11px;
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
</style>