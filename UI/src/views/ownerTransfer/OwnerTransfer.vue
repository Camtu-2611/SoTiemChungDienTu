<template>
  <div class="content-body">
    <div class="body-right-blank"></div>
    <div class="content-body-main">
      <div class="layout-title">
        <div class="title-top">
          <div class="title-name">Chuyển tài sản thuê thành tài sản sở hữu</div>
          <div class="title-tool">
            <div class="title-button">
              <ButtonGuide />
            </div>
            <div class="title-button">
              <ButtonDropdown2 :buttonName="'Tiện ích'" />
            </div>
            <div class="title-button">
              <ButtonDropdown
                :buttonName="'Thêm'"
                @btnDropDownOnClick="btnAddOnClick"
              />
            </div>
          </div>
        </div>
        <div class="title-bottom">
          <div class="title-bottom-icon"></div>
          <div class="title-bottom-content">Tất cả danh mục</div>
        </div>
      </div>
      <div class="overview" v-show="isOverView">
        <div class="inner-overview">
          <div class="overview-item overview-left overview-action">
            <div class="overview-item-icon"></div>
            <div class="overview-data-number">0,0</div>
            <div class="label-overview">Nợ quá hạn</div>
          </div>
          <div class="overview-item overview-center overview-action">
            <div class="overview-item-icon"></div>
            <div class="overview-data-number">0,0</div>
            <div class="label-overview">Tổng nợ phải trả</div>
          </div>
          <div class="overview-item overview-right">
            <div class="overview-data-number">0,0</div>
            <div class="label-overview">Đã thanh toán (30 ngày gần đây)</div>
          </div>
        </div>
      </div>
      <div class="grid-tool">
        <div class="collapse-overview" @click="btnOverviewOnClick">
          <div class="collapse-overview-icon"></div>
        </div>
        <div class="grid-tool-main">
          <div class="grid-tool-left">
            <div class="check-all-arrow">
              <div class="check-all-icon"></div>
            </div>

            <div class="tool-dropdown">
              <ButtonDropdown2
                :buttonName="'Thực hiện hàng loạt'"
                :textColor="'#9e9e9e'"
              />
            </div>

            <div class="tool-dropdown">
              <ButtonDropdown2 :buttonName="'Lọc'" />
            </div>
          </div>
          <div class="grid-tool-right">
            <div class="text-input">
              <InputSearch
                ref="inputSearch"
                :inputValue="inputSearchValue"
                v-model="inputSearchValue"
                placeholder="Nhập từ khóa tìm kiếm"
                @keyup="searchRecord(inputSearchValue)"
              />
            </div>
            <div class="btn-action">
              <div class="btn-reload" @click="reloadData()"></div>
              <div class="btn-excel"></div>
              <div class="btn-setting"></div>
            </div>
          </div>
        </div>
      </div>
      <div class="grid-main">
        <div class="grid-header">
          <div class="col-blank-left col-head"></div>
          <div class="col-checkbox">
            <input type="checkbox" class="input-checkbox" />
          </div>
          <div class="col-1 col-head">Mã chuyển đổi</div>
          <div class="col-2 col-head">Thời gian chuyển đổi</div>
          <div class="col-3 col-head col-right">Giá trị chênh lệch</div>
          <div class="col-4 col-head">Ghi chú</div>
          <div class="col-5 col-head col-right">Số tiền</div>
          <!-- <div class="col-6 col-head">Đã xử lý</div> -->
          <div
            class="col-record-option col-head col-center"
            style="border-left: 1px solid #c7c7c7"
          >
            Chức năng
          </div>
          <div class="col-blank-right col-head"></div>
        </div>
        <div class="grid-body">
          <div
            class="grid-body-row"
            v-for="(record, index) in records"
            :key="index"
            @dblclick="updateRecord(record.id)"
          >
            <div class="col-blank-left"></div>
            <div class="col-checkbox">
              <input type="checkbox" class="input-checkbox" />
            </div>
            <div class="col-1 col-body">
              {{ record.code }}
            </div>
            <div class="col-2 col-body">
              {{ record.time }}
            </div>
            <div class="col-3 col-body col-right">
              {{ record.inventory_date }}
            </div>
            <div class="col-4 col-body">
              {{ record.purpose }}
            </div>
            <div class="col-5 col-body col-right">
              {{ record.conclusion }}
            </div>
            <!-- <div class="col-6 col-body">
              {{ record.identityNumber }}
            </div> -->
            <div class="col-record-option col-body col-center">
              <div class="row-option">
                <div
                  class="row-option-button"
                  @click="updateRecord(record.recordId)"
                >
                  Sửa
                </div>
                <div
                  class="row-option-dropdown"
                  :ref="'recordAction_' + index"
                  @click="btnActionOnClick(index, record)"
                ></div>
              </div>
            </div>
            <div class="col-blank-right"></div>
          </div>
        </div>
      </div>
      <div class="grid-paging">
        <div class="grid-paging-content">
          <div class="paging-total">
            Tổng số:
            <span style="font-weight: bold">{{ totalRecord }}</span>
            <span> bản ghi</span>
          </div>
          <div class="paging-detail">
            <div class="record-in-page">
              <ComboboxPlus
                readonly
                :inputLabel="{ label: '', require: '' }"
                :comboboxValue="valueRecordInPage"
                :inputValue="pageSizeText"
                v-model="pageSizeText"
                @rowClicked="rowRecordInPageClick"
              />
            </div>
            <div
              class="page-pre pre-next"
              ref="pagePre"
              @click="btnPageOnClick(pageIndexCurrent - 1)"
            >
              Trước
            </div>
            <div
              class="number-page number-page-select"
              @click="btnPageOnClick(pageLeft)"
              ref="pageLeft"
            >
              {{ pageLeft }}
            </div>
            <div
              class="number-page"
              @click="btnPageOnClick(pageMid)"
              ref="pageMid"
            >
              {{ pageMid }}
            </div>
            <div
              class="number-page"
              @click="btnPageOnClick(pageRight)"
              ref="pageRight"
            >
              {{ pageRight }}
            </div>
            <div class="number-page"></div>
            <div
              class="page-next"
              ref="pageNext"
              @click="btnPageOnClick(pageIndexCurrent + 1)"
            >
              Sau
            </div>
          </div>
        </div>
      </div>
    </div>
    <BaseLoading ref="loading" />
    <RecordAction ref="recordAction" @processAction="processAction" />
    <BaseConfirm ref="baseConfirm" @processActionYes="processActionYes" />
  </div>
</template>



<script>
import RecordAction from "@/components/common/baseControlAcounting/RecordAction";
import InputSearch from "@/components/common/baseControlAcounting/InputSearch";
import ButtonDropdown from "@/components/common/baseControlAcounting/ButtonDropdown";
import ButtonGuide from "@/components/common/baseControlAcounting/ButtonGuide";
import ButtonDropdown2 from "@/components/common/baseControlAcounting/ButtonDropdown2";
import BaseLoading from "@/components/common/baseControlAcounting/BaseLoading";
import BaseConfirm from "@/components/common/baseControlAcounting/BaseConfirm";
import ComboboxPlus from "@/components/common/baseControlAcounting/ComboboxPlus";

import axios from "axios";

export default {
  name: "OwnerTransfer",

  components: {
    RecordAction,
    InputSearch,
    ButtonDropdown2,
    ButtonGuide,
    ButtonDropdown,
    BaseLoading,
    BaseConfirm,
    ComboboxPlus,
  },

  data() {
    return {
      isOverView: false,
      inputSearchValue: "",
      stateSearch: false,
      timeOut: 0,
      totalRecord: 100,
      records: [],
      recordSelected: {},
      pageSizeText: "20 bản ghi trên 1 trang",
      pageSizeCurrent: 20,
      pageIndexCurrent: 1,
      pageLeft: 1,
      pageMid: 2,
      pageRight: 3,
      valueRecordInPage: {
        isPlus: false,
        isHeader: false,
        headerName: [],
        content: [
          ["10 bản ghi trên 1 trang"],
          ["20 bản ghi trên 1 trang"],
          ["30 bản ghi trên 1 trang"],
          ["50 bản ghi trên 1 trang"],
          ["100 bản ghi trên 1 trang"],
        ],
        fieldSelected: 0,
        widthColumn: ["100%"],
        widthForm: "100%",
        maxHeight: "180px",
        positionLeft: "0px",
        positionTop: "-171px",
      },
    };
  },

  created() {
    // this.getLimitRecord(this.pageSizeCurrent, this.pageIndexCurrent);
    for (let i = 1; i <= 100; i++) {
      this.records.push({
        code: "ChuyenDoi_00" + i,
        time: "26/10/2020",
        inventory_date: 2000000 + i * 100000 + " đ",
        purpose: "Ghi chú về phiếu chuyển đổi sở hữu ChuyenDoi_00" + i,
        conclusion: i * 1000000 + " đ",
      });
    }
  },

  mounted() {
    this.$refs.loading.hideLoading();
    this.$refs.inputSearch?.$refs.inputComponent?.focus();
  },
  watch: {
    inputSearchValue() {
      if (this.inputSearchValue.trim() == "" || this.inputSearchValue == null) {
        this.stateSearch = false;
        console.log(this.stateSearch);

        // this.getLimitRecord(this.pageSizeCurrent, this.pageIndexCurrent);
      } else {
        // this.searchRecord(this.inputSearchValue);
        this.stateSearch = true;
        console.log(this.stateSearch);
      }
    },
  },
  methods: {
    /**
     * Thực hiện lấy toàn bộ bản ghi của Nhà cung cấp
     * CreatedBy: ntmanh(17/06/2021)
     * */
    getAllRecord() {
      try {
        var me = this;
        axios
          .get("https://localhost:44391/api/v1/records")
          .then((response) => {
            me.records = response.data.data;
            me.totalRecord = response.data.data.length;
            this.$refs.loading.hideLoading();
          })
          .catch(() => {});
      } catch (error) {
        console.log(error);
      }
    },

    /**
     * Thực hiện hiển thị ra các action tương ứng với từng dòng bản ghi
     * CreatedBy: ntmanh(15/06/2021)
     * */
    btnActionOnClick(index, recordSelected) {
      this.recordSelected = recordSelected;
      var top =
        this.$refs["recordAction_" + index][0].getBoundingClientRect().y;
      var left =
        this.$refs["recordAction_" + index][0].getBoundingClientRect().x;
      top = top - 20 + "px";
      left = left - 300 + "px";
      var itemActions = ["Xem", "Sửa", "Nhân bản", "Xóa", "Ngưng sử dụng"];
      this.$refs.recordAction.showForm(left, top, itemActions);
    },

    /**
     * Thực hiện hiển thị form chỉnh sửa
     * CreatedBy: ntmanh(15/06/2021)
     * */
    btnUpdateOnClick() {
      this.$refs.recordDetail.showForm();
    },
    /**
     * Thực hiện hiển thị form thêm mới
     * CreatedBy: ntmanh(15/06/2021)
     * */
    btnAddOnClick() {
      // this.$refs.recordDetail.showFormInsert();
      this.$router.push("/asset/owner-transfer-detail/create/new");
    },

    /**
     * Thực hiện ẩn hiện vùng overview
     * CreatedBy: ntmanh(15/06/2021)
     * */
    btnOverviewOnClick() {
      this.isOverView = !this.isOverView;
      var btnOverview = document.querySelector(".collapse-overview-icon");
      if (this.isOverView == false) {
        btnOverview.classList.add("overview-icon2");
      } else btnOverview.classList.remove("overview-icon2");
    },
    /**
     * Thực hiện gọi đến hàm mở form ở popup
     * CreatedBy: ntmanh(15/06/2021)
     * */
    updateRecord(id) {
      this.$refs.recordDetail.showFormUpdate(id);
    },

    /**
     * Thực hiện reload lại data ở table
     * CreatedBy: ntmanh(23/06/2021)
     * */
    reloadData() {
      this.$refs.loading.showLoading();
      if (this.stateSearch == false)
        this.getLimitRecord(this.pageSizeCurrent, this.pageIndexCurrent);
      else this.searchRecord(this.inputSearchValue);
    },

    /**
     * Thực hiện xóa 1 nhà cung cấp
     * CreatedBy: ntmanh(23/06/2021)
     * */
    async deleteRecord(id) {
      try {
        await axios
          .delete("https://localhost:44391/api/v1/records/" + id)
          .then(() => {
            console.log("xóa thành công");
          })
          .catch(() => {
            console.error();
          });
      } catch (error) {
        console.log(error);
      }
    },
    /**
     * Thực hiện hành động khi ấn yes ở form confirm
     * CreatedBy: ntmanh(23/06/2021)
     * */
    async processActionYes() {
      await this.deleteRecord(this.recordSelected.providerId);
      this.reloadData();
    },
    /**
     * Xử lý các option ở cột chức năng
     * CreatedBy: ntmanh(23/06/2021)
     * */
    processAction(indexAction) {
      // index = 0 : Xem bản ghi
      if (indexAction == 0) {
        this.$refs.recordDetail.showFormReadOnly(
          this.recordSelected.providerId
        );
      }
      // chế độ sửa bản ghi
      if (indexAction == 1) {
        this.$refs.recordDetail.showFormUpdate(this.recordSelected.providerId);
      }
      // chế độ xóa
      if (indexAction == 3) {
        this.$refs.baseConfirm.showForm(
          "warning",
          2,
          "Bạn có thực sự muốn xóa Nhà cung cấp <" +
            this.recordSelected.providerCode +
            "> không?"
        );
      }
    },

    //======================== Phần phân trang =======================

    /**
     * Lẩy các bản ghi theo giới hạn
     * pageSize: số lượng bản ghi 1 trang
     * pageIndex: trang thứ n cần lấy
     * CreatedBy: ntmanh(30/06/2021)
     * */
    async getLimitRecord(pageSize, pageIndex) {
      try {
        var me = this;
        await axios
          .get(
            "https://localhost:44391/api/v1/records/GetLimitRecord?pageSize=" +
              pageSize +
              "&pageIndex=" +
              pageIndex
          )
          .then((response) => {
            me.records = response.data.data.records;
            me.totalRecord = response.data.data.totalResult;
            me.$refs.loading.hideLoading();
          })
          .catch(() => {});
      } catch (error) {
        console.log(error);
      }
    },

    /**
     * Thực hiện cập nhật chỉ số trang thanh cuối cùng
     * Trạng thái = 1: Chế độ thêm mới
     * CreatedBy: ntmanh(30/06/2021)
     * */
    refreshPageIndex() {
      if (this.pageIndexCurrent < 1) this.pageIndexCurrent = 1;

      if (this.pageIndexCurrent == 1) {
        this.pageLeft = this.pageIndexCurrent;
        this.pageMid = this.pageLeft + 1;
        this.pageRight = this.pageMid + 1;
        this.$refs.pageLeft.classList.add("number-page-select");
        this.$refs.pageMid.classList.remove("number-page-select");
        this.$refs.pagePre.classList.add("pre-next");
      } else {
        this.pageLeft = this.pageIndexCurrent - 1;
        this.pageMid = this.pageIndexCurrent;
        this.pageRight = this.pageIndexCurrent + 1;
        this.$refs.pageLeft.classList.remove("number-page-select");
        this.$refs.pageMid.classList.add("number-page-select");
        this.$refs.pagePre.classList.remove("pre-next");
      }
    },

    rowRecordInPageClick(index) {
      if (index == 0) this.pageSizeCurrentChange(1, 10);
      if (index == 1) this.pageSizeCurrentChange(1, 20);
      if (index == 2) this.pageSizeCurrentChange(1, 30);
      if (index == 3) this.pageSizeCurrentChange(1, 50);
      if (index == 4) this.pageSizeCurrentChange(1, 100);
    },
    /**
     * Thực hiện lấy dữ liệu theo cách phân trang mới, khi số lượng bản được hiển thị trên 1 trang bị thay đổi
     * Trạng thái = 1: Chế độ thêm mới
     * CreatedBy: ntmanh(30/06/2021)
     * */
    pageSizeCurrentChange(indexCurrent, sizeCurrent) {
      // b1: cập nhật lại pageSizeCurrent
      this.pageSizeCurrent = sizeCurrent;

      // b2: cập nhật lại pageIndexCurrenrt
      this.pageIndexCurrent = indexCurrent;

      // b3: Làm mới lại chỉ số page hiển thị phía dưới cùng
      this.refreshPageIndex();

      // b4: lấy đúng số nhân viên phù hợp khi phân trang
      this.$refs.loading.showLoading();
      // nếu không phải chế độ tìm kiếm
      if (this.stateSearch == false)
        this.getLimitRecord(this.pageSizeCurrent, this.pageIndexCurrent);
      // nếu là chế độ tìm kiếm
      else this.searchRecord(this.inputSearchValue);
    },

    /**
     * Thực hiện lấy dữ liệu theo cách phân trang mới, khi số lượng nhân viên được hiển thị trên 1 trang bị thay đổi
     * Trạng thái = 1: Chế độ thêm mới
     * CreatedBy: ntmanh(30/06/2021)
     * */
    btnPageOnClick(indexPage) {
      this.$refs.loading.showLoading();

      // cập nhật mới lại pageIndexCurrent
      this.pageIndexCurrent = indexPage;

      this.refreshPageIndex();

      // lấy nhân viên theo đúng phân trang

      // nếu không phải chế độ tìm kiếm
      if (this.stateSearch == false)
        this.getLimitRecord(this.pageSizeCurrent, this.pageIndexCurrent);
      // nếu là chế độ tìm kiếm
      else this.searchRecord(this.inputSearchValue);
    },

    // ========================== Tìm kiếm  ====================
    /**
     * Thực hiện tìm kiếm bản ghi theo input đầu vào
     * CreatedBy: ntmanh(30/06/2021)
     * */
    searchRecord(input) {
      try {
        const me = this;
        clearTimeout(this.timeOut);
        this.timeOut = setTimeout(async function () {
          me.$refs.loading.showLoading();
          await axios
            .get(
              "https://localhost:44391/api/v1/records/SearchLimitRecord?keyWord=" +
                input.trim() +
                "&pageSize=" +
                me.pageSizeCurrent +
                "&pageIndex=" +
                me.pageIndexCurrent
            )
            .then((response) => {
              me.records = response.data.data.records;
              me.totalRecord = response.data.data.totalResult;
              me.$refs.loading.hideLoading()();
            })
            .catch(() => {});
        }, 500);
      } catch (error) {
        console.log(error);
      }
    },
  },
};
</script>

<style scoped>
.content-body {
  margin-left: 10px;
  position: relative;
  display: flex;
}

.body-right-blank {
  position: absolute;
  right: 10px;
  width: 30px;
  height: calc(100% - 10px);
  background-color: #f4f5f6;
  z-index: 10;
}

.content-body-main {
  overflow: scroll;
  width: 100%;
  height: calc(100vh - 48px);
  padding-right: 30px;
  background-color: #f4f5f8;
}
::-webkit-scrollbar {
  width: 10px;
  height: 10px;
  background: #f1f1f1;
}
::-webkit-scrollbar-thumb {
  background: #b8bcc3;
}

.grid-tool {
  width: 100%;
  height: 73px;
  position: sticky;
  left: 0;
  margin-top: 14px;
}
.collapse-overview {
  width: 30px;
  height: 28px;
  border: 2px solid #e2e9f2;
  box-sizing: border-box;
  background: #f2f5f8;
  position: absolute;
  top: -14px;
  right: 0;
  cursor: pointer;
  display: flex;
  align-items: center;
  justify-content: center;
  z-index: 1;
}
.collapse-overview-icon {
  width: 16px;
  height: 16px;
  background-image: url("../../components/common/baseResourcesAccounting/img/Sprites.64af8f61.svg");
  background-repeat: no-repeat;
  background-position: -128px -360px;
}
.overview-icon2 {
  background-position: -176px -360px !important;
}
.grid-tool-main {
  width: 100%;
  height: 73px;
  background-color: #fff;
  position: relative;
  display: flex;
  padding: 16px 16px 20px;
  box-sizing: border-box;
}
.grid-tool-left {
  height: fit-content;
  position: absolute;
  left: 16px;
  display: flex;
  align-items: center;
}
.grid-tool-right {
  position: absolute;
  right: 16px;
  display: flex;
  align-items: center;
}
.text-input {
  display: flex;
  width: 213px;
  height: 32px;
}
.btn-action {
  height: 100%;
  width: max-content;
  display: flex;
  flex-direction: row;
}
.btn-reload {
  width: 24px;
  height: 24px;
  margin-left: 12px;
  background-image: url("../../components/common/baseResourcesAccounting/img/Sprites.64af8f61.svg");
  background-repeat: no-repeat;
  background-position: -423px -201px;
  cursor: pointer;
}
.btn-reload:hover {
  background-position: -1097px -88px;
}

.btn-excel {
  width: 24px;
  height: 24px;
  margin-left: 12px;
  background-image: url("../../components/common/baseResourcesAccounting/img/Sprites.64af8f61.svg");
  background-repeat: no-repeat;
  background-position: -704px -200px;
  cursor: pointer;
}
.btn-excel:hover {
  background-position: -704px -256px;
}

.btn-setting {
  width: 24px;
  height: 24px;
  margin-left: 12px;
  background-image: url("../../components/common/baseResourcesAccounting/img/Sprites.64af8f61.svg");
  background-repeat: no-repeat;
  background-position: -88px -200px;
  cursor: pointer;
}
.btn-setting:hover {
  background-position: -88px -256px;
}
.grid-main {
  width: max-content;
  background-color: #fff;
  box-sizing: border-box;
  z-index: 0;
}
.grid-header {
  width: 100%;
  height: 34px;
  font-size: 12px;
  font-weight: bold;
  text-transform: uppercase;
  color: #111111;
  display: flex;
  align-items: center;
  position: sticky;
  top: 93px;
  left: 0;
  z-index: 1;
}
.grid-body {
  width: 100%;
  z-index: 3;
}
.grid-body-row {
  /* height: 47px; */
  font-size: 13px;
  box-sizing: border-box;
  display: flex;
  color: #111111;
}
.grid-body-row:hover div {
  background-color: #f3f9f9;
}
.col-head {
  border-right: 1px solid #c7c7c7;
  border-bottom: 1px solid #c7c7c7;
  background-color: #eceef1;
  display: flex;
  align-items: center;
  padding: 0px 10px;
  box-sizing: border-box;
  height: 100%;
}
.col-body {
  border-right: 1px dotted #c7c7c7;
  border-bottom: 1px solid #c7c7c7;
  background-color: #fff;
  display: flex;
  align-items: center;
  padding: 5px 10px;
  color: #111;
  min-height: 47px;
  white-space: pre-wrap;
  box-sizing: border-box;
}
.grid-header .col-checkbox {
  height: 34px;
}
.grid-header .col-checkbox .input-checkbox {
  width: 18px;
  height: 18px;
  cursor: pointer;
}
.grid-body-row .col-checkbox .input-checkbox {
  width: 18px;
  height: 18px;
  cursor: pointer;
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
  top: 0;
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
  border: solid #2ca01c;
  border-width: 0 2px 2px 0;
  -webkit-transform: rotate(45deg);
  -ms-transform: rotate(45deg);
  transform: rotate(45deg);
  position: absolute;
  top: 2px;
  left: 6px;
  animation: spin 1s linear 1s;
}
.col-blank-left {
  width: 16px;
  min-width: 16px;
  max-width: 16px;
  background: #fff !important;
  position: sticky;
  left: 0;
  border: 0;
  z-index: 3;
  padding: 0;
}
.col-blank-right {
  width: 30px;
  min-width: 30px;
  max-width: 30px;
  background: #fff !important;
  position: sticky;
  right: 0;
  border: 0;
  z-index: 3;
  padding: 0;
}
.col-checkbox {
  width: 40px;
  box-sizing: border-box;
  min-width: 40px;
  max-width: 40px;
  position: sticky;
  left: 16px;
  display: flex;
  align-items: center;
  justify-content: center;
}
.grid-header .col-checkbox {
  border-right: 1px solid #c7c7c7;
  border-bottom: 1px solid #c7c7c7;
  background-color: #eceef1;
}
.grid-body-row .col-checkbox {
  border-right: 1px dotted #c7c7c7;
  border-bottom: 1px solid #c7c7c7;
  background-color: #fff;
}
.col-center {
  justify-content: space-around;
}
.col-right {
  justify-content: flex-end;
}
.col-1 {
  width: 150px;
  min-width: 150px;
}
.col-2 {
  width: 180px;
  min-width: 180px;
}
.col-3 {
  width: 200px;
  min-width: 200px;
}
.col-4 {
  width: 300px;
  min-width: 300px;
}
.col-5 {
  width: 200px;
  min-width: 200px;
}
/* .col-6 {
  width: 180px;
  min-width: 180px;
} */
.col-record-option {
  width: 160px;
  min-width: 160px;
  position: sticky;
  right: 30px;
  border-left: 1px dotted #c7c7c7;
  border-right: 0px;
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
.grid-paging {
  width: 100%;
  height: 46px;
  position: sticky;
  bottom: 0;
  left: 0;
  font-size: 13px;
  display: flex;
  align-items: center;
  background-color: #fff;
  z-index: 1;
}
.grid-paging-content {
  width: 100%;
  height: 30px;
  position: relative;
}
.paging-total {
  position: absolute;
  left: 20px;
  height: 100%;
  display: flex;
  align-items: center;
}
.paging-total span {
  text-indent: 5px;
}
.paging-detail {
  height: 100%;
  position: absolute;
  right: 60px;
  display: flex;
  align-items: center;
}
.record-in-page {
  width: 230px;
  height: 32px;
  padding: 0px 16px;
  display: flex;
  align-items: center;
}
.record-in-page select {
  width: 200px;
  height: 32px;
  padding: 0px 12px;
  border: 1px solid #babec5;
  outline: none;
  font-size: 13px;
  cursor: pointer;
  border-radius: 2px;
  -webkit-appearance: none;
  background-image: url("../../components/common/baseResourcesAccounting/img/icon-select.png");
  background-position: right center;
  background-repeat: no-repeat;
}
.page-pre {
  margin-right: 13px;
  cursor: pointer;
}
.page-next {
  margin-left: 13px;
  cursor: pointer;
}
.number-page {
  padding: 0px 6.5px;
  cursor: pointer;
}
.pre-next {
  color: #9e9e9e;
  cursor: default;
}
.number-page-select {
  border: 1px solid #e0e0e0;
  box-sizing: border-box;
  font-weight: bold;
}
.check-all-arrow {
  padding: 13px 12px 0 12px;
}
.check-all-icon {
  width: 24px;
  height: 24px;
  background-image: url("../../components/common/baseResourcesAccounting/img/Sprites.64af8f61.svg");
  background-repeat: no-repeat;
  background-position: -256px -143px;
  cursor: pointer;
}

.label-disable {
  color: #9e9e9e;
}
.tool-dropdown {
  height: 100%;
  margin-right: 12px;
}
button.button-tool {
  height: 36px;
  padding: 0px 16px;
  border: 2px solid #3b3c3f;
  border-radius: 30px;
  display: flex;
  justify-content: center;
  align-items: center;
  background-color: #fff;
  cursor: pointer;
}
button.button-tool:hover {
  background-color: #d2d3d6;
}

.button-tool-label {
  font-size: 13px;
  font-weight: 600;
  margin-right: 4px;
}
.button-tool-icon {
  width: 16px;
  height: 16px;
  background-image: url("../../components/common/baseResourcesAccounting/img/Sprites.64af8f61.svg");
  background-repeat: no-repeat;
  background-position: -560px -359px;
}

.overview {
  width: 100%;
  height: 75px;
  margin-bottom: 36px;
  position: sticky;
  left: 0;
}
.inner-overview {
  width: 100%;
  height: 75px;
  display: flex;
  justify-content: space-between;
  position: relative;
}
.overview-item {
  width: calc(100% / 3);
  height: max-content;
  cursor: pointer;
  padding: 6px 10px;
  box-sizing: border-box;
  display: flex;
  flex-direction: column;
  color: #fff;
}
.overview-left {
  background-color: #ff7f2c;
  position: absolute;
  bottom: 0;
  left: 0;
}
.overview-right {
  background-color: #74cb2f;
  position: absolute;
  bottom: 0;
  right: 0;
}
.overview-center {
  width: calc(100% / 3 - 13px) !important;
  background-color: #b8bcc3;
  position: absolute;
  bottom: 0;
  left: calc(100% / 3 + 6.5px);
}

.overview-action:hover {
  border-bottom: 6px solid #95979a;
  top: 0;
}
.overview-item-icon {
  height: 22px;
  position: absolute;
  width: 18px;
  right: 8px;
  background-image: url("../../components/common/baseResourcesAccounting/img/Sprites.64af8f61.svg");
  background-repeat: no-repeat;
  background-position: -1814px -202px;
}
.overview-data-number {
  width: 100%;
  height: 36px;
  font-size: 24px;
}

.layout-title {
  width: 100%;
  position: sticky;
  top: 0;
  left: 0;
  padding: 22px 0px 16px;
  background-color: #f4f5f8;
  z-index: 4;
  display: flex;
  flex-direction: column;
}
.title-top {
  width: 100%;
  height: 36px;
  position: relative;
  display: flex;
  flex-direction: row;
}
.title-name {
  width: max-content;
  height: 100%;
  font-size: 24px;
  font-weight: 700;
  color: #111;
}
.title-tool {
  position: absolute;
  right: 0;
  top: 0;
  cursor: pointer;
  display: flex;
  align-items: center;
  height: 100%;
}
.title-button {
  margin-left: 12px;
  height: 36px;
  display: flex;
  align-items: center;
}
.title-bottom {
  width: 100%;
  height: 19px;
  display: flex;
  flex-direction: row;
  color: #0075c0;
  cursor: pointer;
}
.title-bottom-icon {
  width: 16px;
  height: 16px;
  background-image: url("../../components/common/baseResourcesAccounting/img/Sprites.64af8f61.svg");
  background-repeat: no-repeat;
  background-position: -224px -360px;
  display: flex;
  align-items: center;
}
</style>
