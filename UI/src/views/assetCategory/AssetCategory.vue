<template>
  <div class="content-body">
    <div class="body-right-blank"></div>
    <div class="content-body-main">
      <div class="layout-title">
        <div class="title-top">
          <div class="title-name">Danh mục Loại tài sản</div>
          <div class="title-tool">
            <div class="title-button">
              <ButtonRadius :buttonName="'Tiện ích'" />
            </div>
            <div class="title-button">
              <ButtonSimple
                :buttonName="'Thêm'"
                @buttonSimpleOnClick="btdAddOnClick()"
              />
            </div>
          </div>
        </div>
        <div class="title-bottom">
          <div class="title-bottom-icon"></div>
          <div class="title-bottom-content">Tất cả danh mục</div>
        </div>
      </div>
      <div class="grid-tool">
        <div class="grid-tool-main">
          <div class="grid-tool-left">
            <div class="text-input">
              <InputSearch
                ref="inputSearch"
                :inputValue="inputSearchValue"
                v-model="inputSearchValue"
                placeholder="Nhập thông tin tìm kiếm"
              />
            </div>
          </div>
          <div class="grid-tool-right">
            <div class="btn-action">
              <div
                class="collapse-expand"
                v-if="stateExpand"
                @click="btnCollapseOnClick"
              >
                Thu gọn
              </div>

              <div
                class="collapse-expand"
                v-if="!stateExpand"
                @click="btnExpandOnClick"
              >
                Mở rộng
              </div>

              <div class="btn-reload" @click="reloadData()"></div>
              <div class="btn-excel"></div>
            </div>
          </div>
        </div>
      </div>

      <div class="grid-main">
        <div class="grid-header">
          <div class="col-blank-left col-head"></div>
          <div class="col-1 col-head">Mã loại tài sản</div>
          <div class="col-2 col-head">Tên loại tài sản</div>
          <div class="col-3 col-head">Ghi chú</div>
          <div class="col-4 col-head">Trạng thái</div>
          <!-- <div class="col-5 col-head">Diễn giải</div>
          <div class="col-6 col-head">Trạng thái</div> -->
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
            v-for="(record, index) in listRecord"
            :key="index"
            @dblclick="updateRecord(record.idloaitaisan)"
            v-show="record.isShow"
            :class="{ 'row-parent': record.hasChild }"
          >
            <div class="col-blank-left"></div>
            <div
              class="col-1 col-body"
              :style="{ 'padding-left': record.level * 30 + 'px' }"
            >
              <div
                class="icon-row icon-expand"
                v-if="record.hasChild == true && record.isShowChild == false"
                @click="toggleChildren(record, index)"
              ></div>

              <div
                class="icon-row icon-collapse"
                v-if="record.hasChild == true && record.isShowChild == true"
                @click="toggleChildren(record, index)"
              ></div>

              {{ record.maloaits }}
            </div>
            <div class="col-2 col-body">
              {{ record.tenloaits }}
            </div>
            <div class="col-3 col-body">
              {{ record.ghichu }}
            </div>
            <div class="col-4 col-body">
              {{ record.tentinhtrang }}
            </div>
            <!-- <div class="col-5 col-body">
              {{ record.explain }}
            </div>
            <div class="col-6 col-body">
              {{ record.status }}
            </div> -->
            <div class="col-record-option col-body col-center">
              <div class="row-option">
                <div
                  class="row-option-button"
                  @click="updateRecord(record.idloaitaisan)"
                >
                  Sửa
                </div>
                <div
                  class="row-option-dropdown"
                  :ref="'recordAction_' + index"
                  @click="btnActionOnClick(record, index)"
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
        </div>
      </div>
    </div>
    <BaseLoading ref="loading" />
    <RecordAction ref="recordAction" @processAction="processAction" />
    <BaseConfirm ref="baseConfirm" @processActionYes="processActionYes" />
    <AssetCategoryDetail ref="accountDetail" :records="records" />
  </div>
</template>



<script>
import RecordAction from "@/components/common/baseControlAcounting/RecordAction";
import InputSearch from "@/components/common/baseControlAcounting/InputSearch";
import ButtonSimple from "@/components/common/baseControlAcounting/ButtonSimple";
import ButtonRadius from "@/components/common/baseControlAcounting/ButtonRadius";
import BaseConfirm from "@/components/common/baseControlAcounting/BaseConfirm";
import AssetCategoryDetail from "@/views/assetCategory/AssetCategoryDetail";
import BaseLoading from "@/components/common/baseControlAcounting/BaseLoading";

import axios from "axios";

export default {
  name: "AssetCategory",

  components: {
    RecordAction,
    InputSearch,
    ButtonSimple,
    ButtonRadius,
    BaseConfirm,
    AssetCategoryDetail,
    BaseLoading,
  },

  data() {
    return {
      statePopup: false,
      inputSearchValue: "",
      totalRecord: 100,
      stateValidate: true,
      records: [],
      nodeRoots: [],
      tree: [],
      recordSelected: {},
      recordTree: [],
      listRecord: [],
      stateExpand: true,
    };
  },
  created() {},

  mounted() {
    this.$refs.inputSearch?.$refs.inputComponent?.focus();
    this.getAllRecord();
    this.processTreeAccount();
  },
  updated() {},
  methods: {
    /**
     * Thực hiện hiển thị ra các action tương ứng với từng dòng bản ghi
     * CreatedBy: ntmanh(25/06/2021)
     * */
    btnActionOnClick(record, index) {
      this.recordSelected = record;

      var top =
        this.$refs["recordAction_" + index][0].getBoundingClientRect().y;
      var left =
        this.$refs["recordAction_" + index][0].getBoundingClientRect().x;
      top = top - 22 + "px";
      left = left - 305 + "px";
      var itemActions = ["Nhân bản", "Xóa", "Ngừng sử dụng"];
      this.$refs.recordAction.showForm(left, top, itemActions);
    },

    btdAddOnClick() {
      this.statePopup = true;
      this.$refs.accountDetail.showFormInsert();
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
            me.totalRecord = response.data.length;
          })
          .catch(() => {});
      } catch (error) {
        console.log(error);
      }
    },

    /**
     * Thực hiện lấy toàn bộ bản ghi của Nhà cung cấp
     * CreatedBy: ntmanh(25/06/2021)
     * */
    async getRecordTree() {
      try {
        this.$refs.loading.showLoading();
        var me = this;
        await axios
          .get("https://localhost:44327/api/LoaiTaiSan/GetTree")
          .then((response) => {
            me.recordTree = response.data;
            me.$refs.loading.hideLoading();
          })
          .catch(() => {});
      } catch (error) {
        console.log(error);
      }
    },

    /**
     * Thực hiện xóa 1 bản ghi tài khoản
     * CreatedBy: ntmanh(23/06/2021)
     * */
    async deleteRecord(id) {
      try {
        await axios
          .delete("https://localhost:44327/api/LoaiTaiSan/" + id)
          .then(() => {
            console.log("xóa tài khoản thành công");
          })
          .catch(() => {
            console.error();
          });
      } catch (error) {
        console.log(error);
      }
    },
    /**
     * Show form Update bản ghi
     * CreatedBy: ntmanh(28/06/2021)
     * */
    updateRecord(id) {
      this.$refs.accountDetail.showFormUpdate(id);
    },

    /**
     * Kiểm tra xem 1 bản ghi có được phép xóa hay không
     * CreatedBy: ntmanh(28/06/2021)
     * */
    checkInvalidDelete() {
      let result = true;
      this.records.forEach((e) => {
        if (this.recordSelected.idloaitaisan == e.idloaitscha) {
          result = false;
        }
      });
      return result;
    },
    /**
     * Xử lý các option ở cột chức năng
     * CreatedBy: ntmanh(28/06/2021)
     * */
    processAction(indexAction) {
      // index = 0 : Nhân bản

      // chế độ xóa
      if (indexAction == 1) {
        let isValid = this.checkInvalidDelete();
        if (isValid == false) {
          this.$refs.baseConfirm.showForm(
            "error",
            1,
            "Không thể xóa danh mục cha nếu chưa xóa tất cả các danh mục con.",
            "Xóa không thành công."
          );

          return;
        } else {
          this.$refs.baseConfirm.showForm(
            "warning",
            2,
            "Bạn có thực sự muốn xóa Loại tài sản <" +
              this.recordSelected.maloaits +
              "> không?"
          );
        }
      }
    },

    /**
     * Thực hiện hành động khi ấn yes ở form confirm
     * CreatedBy: ntmanh(23/06/2021)
     * */
    async processActionYes() {
      await this.deleteRecord(this.recordSelected.idloaitaisan);
      this.reloadData();
    },
    /**
     * Thực hiện làn tươi dữ liệu
     * CreatedBy: ntmanh(28/06/2021)
     * */
    reloadData() {
      this.getAllRecord();
      this.processTreeAccount();
    },
    async processTreeAccount() {
      await this.getRecordTree();
      await this.buildTree();
      this.updateHasChild();
    },

    /**
     * Xây dưng cây phân cấp
     * CreatedBy: ntmanh(04/07/2021)
     * */

    buildTree() {
      this.listRecord = this.recordTree.slice();
      for (let i = 0; i < this.listRecord.length; i++) {
        if (this.listRecord[i].children.length > 0) {
          for (let j = 0; j < this.listRecord[i].children.length; j++) {
            this.listRecord.splice(
              i + j + 1,
              0,
              this.listRecord[i].children[j]
            );
          }
        }
      }
    },

    //cập nhật tình trạng có con hay không của các bản ghi
    updateHasChild() {
      // cấp nhật lại tình trạng có con hay không
      for (let i = 0; i < this.listRecord.length; i++) {
        this.listRecord[i].hasChild = false;
        for (let j = 0; j < this.listRecord.length; j++) {
          if (
            this.listRecord[i].idloaitaisan == this.listRecord[j].idloaitscha &&
            this.listRecord[i].idloaitaisan != this.listRecord[j].idloaitaisan
          ) {
            this.listRecord[i].hasChild = true;
            break;
          }
        }
      }
    },
    toggleChildren(record, index) {
      this.listRecord[index].isShowChild = !this.listRecord[index].isShowChild;

      for (let i = 0; i < this.listRecord.length; i++) {
        // tìm ra những thằng là con

        let accNumberParent = this.listRecord[i].maloaits.substr(
          0,
          record.maloaits.length
        );
        // nếu các bản ghi có trùng phần đầu với cha thì các bản ghi đó chính là con
        if (
          record.maloaits == accNumberParent &&
          record.idloaitaisan != this.listRecord[i].idloaitaisan
        ) {
          this.listRecord[i].isShow = this.listRecord[index].isShowChild;
        }
      }

      this.updateHasChild();
    },

    btnExpandOnClick() {
      this.stateExpand = true;
      for (let i = 0; i < this.listRecord.length; i++) {
        this.listRecord[i].isShow = true;
      }
    },

    btnCollapseOnClick() {
      this.stateExpand = false;

      for (let i = 0; i < this.listRecord.length; i++) {
        if (this.listRecord[i].idloaitscha == null) {
          this.listRecord[i].isShow = true;
          continue;
        }
        this.listRecord[i].isShow = false;
      }
    },

    // ======================= hết method ===============================
  },
};
</script>

<style scoped>
.content-body {
  margin-left: 20px;
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
  height: 68px;
  padding: 16px 16px 10px;
  box-sizing: border-box;
  position: sticky;
  left: 0;
  background-color: #fff;
}
.grid-tool-main {
  width: 100%;
  height: 32px;
  margin-bottom: 10px;
  position: relative;
  display: flex;
}
.grid-tool-left {
  height: fit-content;
  position: absolute;
  left: 0;
  display: flex;
  align-items: center;
}
.grid-tool-right {
  position: absolute;
  right: 0;
  display: flex;
  align-items: center;
}
.text-input {
  display: flex;
  width: 250px;
  height: 32px;
}
.btn-action {
  height: 100%;
  width: max-content;
  display: flex;
  flex-direction: row;
  align-items: center;
}
.collapse-expand {
  color: #0075c0;
  margin-right: 12px;
  cursor: pointer;
}
.btn-reload {
  width: 24px;
  height: 24px;
  padding: 0px 20px;
  background-image: url("../../components/common/baseResourcesAccounting/img/Sprites.64af8f61.svg");
  background-repeat: no-repeat;
  background-position: -417px -201px;
  cursor: pointer;
}
.btn-reload:hover {
  background-position: -1091px -88px;
}

.btn-excel {
  width: 24px;
  height: 24px;
  padding: 0px 6px;
  background-image: url("../../components/common/baseResourcesAccounting/img/Sprites.64af8f61.svg");
  background-repeat: no-repeat;
  background-position: -698px -200px;
  cursor: pointer;
}
.btn-excel:hover {
  background-position: -698px -256px;
}
.grid-main {
  width: auto;
  background-color: #fff;
  box-sizing: border-box;
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
  z-index: 5;
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
  box-sizing: border-box;
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

.col-center {
  justify-content: space-around;
}
.col-1 {
  min-width: 250px;
}
.col-2 {
  width: 320px;
  min-width: 320px;
}
.col-3 {
  width: 220px;
  min-width: 220px;
}
.col-4 {
  width: 250px;
  min-width: 250px;
}
/* .col-5 {
  max-width: 300px;
  min-width: 100px;
  width: -webkit-fill-available;
}
.col-6 {
  width: 120px;
  min-width: 120px;
} */

.col-record-option {
  width: 200px;
  min-width: 200px;
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
  width: 26px;
  height: 16px;
  margin: 10px;
  cursor: pointer;
  background-image: url("../../components/common/baseResourcesAccounting/img/Sprites.64af8f61.svg");
  background-repeat: no-repeat;
  background-position: -892px -360px;
  box-sizing: border-box;
}
.btn-dropdown {
  border: 1px solid;
}
.icon-row {
  width: 16px;
  height: 16px;
  min-width: 16px;
  min-height: 16px;
  background-image: url("../../components/common/baseResourcesAccounting/img/Sprites.64af8f61.svg");
  background-repeat: no-repeat;
  background-position: -559px -312px;
  cursor: pointer;
  margin-right: 0.5rem;
}
.icon-collapse {
  background-position: -559px -312px !important;
}
.icon-expand {
  background-position: -607px -311px;
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
.layout-title {
  width: 100%;
  position: sticky;
  top: 0;
  left: 0;
  padding: 22px 0px 16px;
  background-color: #f4f5f8;
  z-index: 10;
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

.row-parent {
  font-weight: bold;
}
</style>

