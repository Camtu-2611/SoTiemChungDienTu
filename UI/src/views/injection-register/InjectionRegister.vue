<template>
  <div class="injection-register content">
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
        <h5 class="mb-4">Danh sách đăng ký tiêm</h5>
        <div class="features-pane">
          <div class="features-pane-left">
            <input
              id="assetSearchBox"
              class="input-search"
              type="text"
              placeholder="Tìm kiếm theo họ tên, mã sổ tiêm "
              v-model="inputSearch"
              @change="getInjectionRegister('filter')"
            />
            <div class="icon-search" title="Tìm kiếm"></div>
          </div>

          <div class="features-pane-right">
            <div
              class="btn-add-asset btn features-pane-item"
              @click="showDetail('insert', 0)"
            >
              Thêm
            </div>

            <div
              id="preventLeftClick"
              class="btn icon-edit-pen features-pane-item"
              :class="['disable' ? '' : allowEdit]"
              @click="showDetail('update', null)"
              title="Sửa thông tin sổ tiêm"
            ></div>
            <div
              @click="getInjectionRegister('')"
              class="btn icon-refresh features-pane-item"
              title="Tải lại"
            ></div>
          </div>
        </div>

        <div class="clear-float"></div>
      </div>

      <div id="loadBar"></div>
      <div class="content-grid grid" oncontextmenu="return false;">
        <table class="table-asset" id="tableAsset">
          <colgroup>
            <col width="50" />
            <!-- <col width="120" /> -->
            <col width="120" />
            <col min-width="400" />
            <col min-width="200" />
            <col min-width="100" />
            <col width="450" />
            <col width="100" />
          </colgroup>
          <thead>
            <tr>
              <th style="text-align: center">STT</th>
              <th
                sortProp="name"
                sortOrder="asc"
                id="columnAssetName"
                class="hover-pointer"
                style="text-align: center"
              >
                Họ và tên
              </th>
              <th
                sortProp="type"
                style="text-align: center"
                sortOrder="asc"
                id="columnAssetType"
                class="hover-pointer"
              >
                Ngày sinh
              </th>
              <th
                sortProp="department"
                sortOrder="asc"
                id="columnDepartment"
                class="hover-pointer"
                style="text-align: center"
              >
                Giới tính
              </th>
              <th
                sortProp="department"
                sortOrder="asc"
                id="columnDepartment"
                class="hover-pointer"
                style="text-align: center"
              >
                Số điện thoại
              </th>
              <th
                sortProp="department"
                sortOrder="asc"
                id="columnDepartment"
                class="hover-pointer"
                style="text-align: center"
              >
                Địa chỉ
              </th>
              <th
                sortProp="department"
                sortOrder="asc"
                id="columnDepartment"
                class="hover-pointer"
                style="text-align: center"
              >
                Ngày đăng ký
              </th>
              <th
                sortProp="department"
                sortOrder="asc"
                id="columnDepartment"
                class="hover-pointer"
                style="text-align: center"
              >
                Tên trung tâm
              </th>
              <th
                sortProp="price"
                sortOrder="asc"
                id="columnPrice"
                class="hover-pointer"
                style="text-align: center"
              >
                Danh sách vắc xin
              </th>
              <th
                sortProp="price"
                sortOrder="asc"
                id="columnPrice"
                class="hover-pointer"
                style="text-align: center"
              >
                Trạng thái
              </th>
            </tr>
          </thead>

          <tbody>
            <tr
              v-for="(TTDangKy, index) in listTTDangKy"
              :key="TTDangKy.iddangky"
              v-bind:class="
                selectedRow(TTDangKy.iddangky) ? 'selected-row' : ''
              "
              @click="selectRow(TTDangKy.iddangky, $event)"
              @click.right="showContexMenu(TTDangKy.iddangky, $event)"
              @dblclick="showDetail('update', TTDangKy.iddangky)"
            >
              <td class="no-border-left">{{ index + 1 }}</td>
              <td>{{ TTDangKy.hoten }}</td>
              <td>{{ TTDangKy.ngaysinh | formatDate(TTDangKy.ngaysinh) }}</td>
              <td>
                {{ TTDangKy.gioitinh | formatGioiTinh(TTDangKy.gioiTinh) }}
              </td>
              <td>{{ TTDangKy.sodienthoai }}</td>
              <!-- <td>{{ TTDangKy.email }}</td> -->
              <td>{{ TTDangKy.diachi }}</td>
              <td>
                {{
                  TTDangKy.ngaydangkytiem | formatDate(TTDangKy.ngaydangkytiem)
                }}
              </td>
              <td>{{ TTDangKy.tentrungtam }}</td>
              <td>{{ TTDangKy.danhsachvacxin }}</td>
              <td>
                {{ TTDangKy.trangthai | formatStatus(TTDangKy.trangthai) }}
              </td>
            </tr>
          </tbody>
          <BaseLoading ref="loadingTTDKT_reft" />

          <div v-show="getEmty" class="loading-emty">Không có dữ liệu</div>
        </table>
        <div class="ctx-menu" id="ctxMenu">
          <div class="ctx-menu-item" @click="showDetail('insert', 0)">Thêm</div>
          <div
            class="ctx-menu-item"
            @click="showDetail('update', listSelectRow[0])"
          >
            Sửa
          </div>
          <!-- <div
            id="preventLeftClick"
            class="ctx-menu-item"
            @click="showDeleteDialog(listSelectRow[0])"
          >
            Xóa
          </div> -->
        </div>
      </div>

      <div class="table-summary">
        <div class="summary">
          <div class="asset-number">Tổng số bản ghi: {{ amountTTDangKy }}</div>

          <div class="paging-toolbar">
            <div class="leftchild">
              <div
                title="Trang đầu"
                class="p-button first-page"
                @click="firstPage()"
              ></div>
              <div
                title="Trang trước"
                class="p-button prev-page"
                @click="backPage()"
              ></div>
              <div>Trang</div>
              <input
                type="number"
                class="text-pagebumber"
                v-model="paging.pageNumber"
                @change="reloadPage()"
              />
              <div>Trên {{ paging.amountPage }}</div>

              <div
                title="Trang sau"
                class="p-button next-page"
                @click="nextPage()"
              ></div>
              <div
                title="Trang cuối"
                class="p-button last-page"
                @click="lastPage()"
              ></div>
              <div
                title="Tải lại"
                class="p-button refresh"
                @click="getInjectionRegister()"
              ></div>
              <select
                title="Số bản ghi trên 1 trang"
                name=""
                id=""
                class="select-quantitypage"
                v-model="paging.recordNumber"
                @change="getInjectionRegister('filter')"
              >
                <option value="25">25</option>
                <option value="50">50</option>
                <option value="100">100</option>
              </select>
            </div>
          </div>
        </div>
      </div>

      <div id="assetPopup"></div>
    </div>
    <BaseConfirm ref="baseConfirm" />
  </div>
</template>
<script>
import axios from "axios";
import BaseLoading from "../../components/common/BaseLoading.vue";
import InjectionRegisterDetail from "./InjectionRegisterDetail.vue";
import { trangthai, gioitinh } from "../../enumeration/enumaration";
import BaseConfirm from "@/components/common/baseControlAcounting/BaseConfirm";

export default {
  name: "InjectionRegister",
  components: {
    BaseLoading,
    InjectionRegisterDetail,
    BaseConfirm,
  },
  data() {
    return {
      listTTDangKy: [],
      TTDangKy: {
        iddangky: null,
        hoten: null,
        ngaysinh: null,
        gioitinh: null,
        diachi: null,
        email: null,
        sodienthoai: null,
        tentrungtam: null,
        ngaydangkytiem: null,
        danhsachvacxin: null,
      },
      formMode: "",
      alerMsg: "",
      idDangKyUpdate: null,
      listSelectRow: [],
      listIdDangKy: [],
      inputSearch: "",
      showSuccess: false,
      isError: false,
      getSuccess: true,
      getEmty: false,
      amountTTDangKy: 0,
      showWarning: false,
      paging: {
        amountPage: 1,
        pageNumber: 1,
        recordNumber: 50,
        totalRecord: 0,
        startRecord: 0,
        endRecord: 0,
      },
      showMenuFilter: true,
      showMenuType: false,
      showMenuDepartment: true,
      allowEdit: false,
    };
  },

  computed: {
    formTitle() {
      return this.editedIndex === -1 ? "New Item" : "Edit Item";
    },
  },

  watch: {
    idDangKyUpdate() {
      if (
        !this.idDangKyUpdate ||
        this.idDangKyUpdate === "00000000-0000-0000-0000-000000000000"
      ) {
        this.allowEdit = false;
        console.log(this.allowEdit + "w");
      } else {
        this.allowEdit = true;
      }
    },
    // dialog(val) {
    //   val || this.close();
    // },
    // dialogDelete(val) {
    //   val || this.closeDelete();
    // },
  },

  created() {
    this.processkey();
  },
  mounted() {
    this.getInjectionRegister();
    this.hideContextMenu();
  },

  methods: {
    msgAlert(text, value) {
      this.showWarning = value;
      this.alerMsg = text;
      var res = this;

      setTimeout(() => {
        res.showWarning = false;
      }, 3000);
    },

    async getInjectionRegister(text) {
      if (text == "filter") {
        this.paging.pageNumber = 1;
      }
      var me = this;
      me.amountTTDangKy = 0;
      this.$refs.loadingTTDKT_reft.show();
      await axios
        .get("http://localhost:64016/api/ThongTinDangKyTiem")
        .then((response) => {
          if (response.data) {
            me.listTTDangKy = response.data.data;

            if (me.listTTDangKy.length == 0) {
              me.getEmty = true;
            }

            me.$refs.loadingTTDKT_reft.hide();
            me.listIdDangKy = [];
            me.paging.amountPage = response.data.totalPage;

            me.listTTDangKy.forEach((element) => {
              // duyệt qua tất cả các bản ghi
              me.listIdDangKy.push(element.iddangky); // push tất cả id tài sản vào mảng
              me.amountTTDangKy++; // đếm tổng số bản ghi
            });
          }
        })
        .catch((error) => {
          this.errorMessage = error.message;
          console.error("GET ThongTinDangKy Failed: ", error.message);
          setTimeout(() => {
            me.$refs.loadingTTDKT_reft.hide(); // tắt dialog loading
            me.getEmty = true;
          }, 4000);
        });
    },
    /// todo hiển thị dialog thêm
    showDetail(text, Id) {
      this.allowEdit = false;
      this.formMode = "insert";

      if (text == "insert") {
        this.formMode = "insert";
        this.alerMsg = "Thêm mới thành công";
      } else {
        this.formMode = "update";
        this.alerMsg = "Cập nhật thành công";
        if(Id){
          this.idDangKyUpdate = Id;
        }
        if (
          this.idDangKyUpdate &&
          this.idDangKyUpdate !== "00000000-0000-0000-0000-000000000000"
        ) {
          this.allowEdit = true;
        } else {
          this.allowEdit = false;
        }
      }
      setTimeout(() => {
        if (this.allowEdit && text == "update") {
          this.$router.push({
            name: "injection-register-detail",
            params: {
              formMode: this.formMode,
              idDangKyUpdate: this.idDangKyUpdate,
            },
          });
        } else if (text == "insert") {
          this.$router.push({
            name: "injection-register-detail",
          });
        } else {
          this.$refs.baseConfirm.showForm(
            "warning",
            1,
            "Vui lòng chọn 1 bản ghi!"
          );
          return;
        }
      }, 300);
    },

    // todo tải lại dữ liệu
    reload(value) {
      if (value == true) {
        this.getInjectionRegister("");
        this.showSuccess = true;
        setTimeout(() => {
          this.showSuccess = false;
        }, 3000);
      }
    },

    //todo hiển thị form xác nhận xóa
    showDeleteDialog(text) {
      // var res = this
      this.alerMsg = "Xóa thành công!";
      if (text != "inRow" && this.listSelectRow.length == 0) {
        this.showWarning = true;
        this.alerMsg = "Vui lòng chọn bản ghi";
      } else {
        this.$refs.ModalDeleteAsset_ref.show();
        this.showWarning = false;
      }
      setTimeout(() => {
        this.showWarning = false;
      }, 3000);
    },

    //  select hàng, nếu hàng đã được select thì xóa khỏi mẩng listSelectRow, và ngược lại
    selectRow(id, event) {
      if (event.ctrlKey == false && event.shiftKey == false) {
        this.listSelectRow = [];
        this.listSelectRow.push(id);
      } else if (event.shiftKey) {
        var idFirst = this.listSelectRow[0];
        this.listSelectRow = [];
        this.listSelectRow.push(idFirst);

        // vị trí đầu tiên trong mảng listSelectRow
        var idStart = this.listSelectRow[0];
        var indexStart = this.listIdDangKy.indexOf(idStart);

        var indexEnd = this.listIdDangKy.indexOf(id);
        if (indexStart > indexEnd) {
          indexStart--;
          var tem = indexStart;
          indexStart = indexEnd;
          indexEnd = tem;
        } else {
          indexStart++;
        }
        for (var i = indexStart; i <= indexEnd; i++) {
          this.listSelectRow.push(this.listIdDangKy[i]);
        }
      } else if (event.ctrlKey) {
        var index = this.listSelectRow.indexOf(id);
        if (index > -1) {
          this.listSelectRow.splice(index, 1);
        } else {
          this.listSelectRow.push(id);
        }
      }
    },

    // kiểm tra hàng đã được select hay chưa
    selectedRow(id) {
      if (this.listSelectRow.indexOf(id) > -1) {
        this.idDangKyUpdate = id;
        return true;
      } else return false;
    },

    // todo xử lý sự kiện mũi tên lên xuống để select row
    processkey() {
      var res = this;
      document.addEventListener("keydown", function(e) {
        var len1 = res.listSelectRow.length; // số phần tử của mảng listSelectRow
        var len2 = res.listIdDangKy.length; //số phần tử của mảng listIdDangKy
        switch (e.keyCode) {
          case 38:
            {
              //up arrow
              if (
                len1 == 0 ||
                res.listIdDangKy.indexOf(res.listSelectRow[0]) == 0
              ) {
                res.listSelectRow = [];
                res.listSelectRow.push(res.listIdDangKy[len2 - 1]);
              } else if (len1 > 0) {
                //res.listSelectRow = [];
                var indexIdFirst = res.listIdDangKy.indexOf(
                  res.listSelectRow[0]
                );
                res.listSelectRow = [];
                res.listSelectRow.push(res.listIdDangKy[indexIdFirst - 1]);
              }
            }
            break;
          case 40:
            {
              // //down arrow
              if (
                len1 == 0 ||
                res.listIdDangKy.indexOf(res.listSelectRow[len1 - 1]) ==
                  len2 - 1
              ) {
                res.listSelectRow = [];
                res.listSelectRow.push(res.listIdDangKy[0]);
              } else if (len1 > 0) {
                //res.listSelectRow = [];
                var indexIdLast = res.listIdDangKy.indexOf(
                  res.listSelectRow[len1 - 1]
                );
                res.listSelectRow = [];
                res.listSelectRow.push(res.listIdDangKy[indexIdLast + 1]);
              }
            }
            break;
          case 37:
            {
              res.backPage();
            }
            break;
          case 39:
            {
              res.nextPage();
            }
            break;
          default: {
            return true;
          }
        }
      });
    },

    // todo hiện và thao tác với context menu
    showContexMenu(id, e) {
      this.listSelectRow = [];
      this.listSelectRow.push(id);
      var ctx = document.getElementById("ctxMenu");
      ctx.style.display = "block";
      ctx.style.top = (e.screenY - 70).toFixed() + "px";
      ctx.style.left = e.screenX.toFixed() + "px";
    },

    // todo chuyển đến trang sau
    nextPage() {
      if (this.paging.pageNumber < this.paging.amountPage) {
        this.paging.pageNumber++;
        this.getInjectionRegister();
      }
    },
    // todo chuyển đến trang trước
    backPage() {
      if (this.paging.pageNumber > 1) {
        this.paging.pageNumber--;
        this.getInjectionRegister();
      }
    },
    hideContextMenu() {
      document.addEventListener("click", function() {
        if (document.getElementById("ctxMenu") != null)
          document.getElementById("ctxMenu").style.display = "none";
      });
    },
    lastPage() {
      this.paging.pageNumber = this.paging.amountPage;
      this.getInjectionRegister();
    },
    firstPage() {
      this.paging.pageNumber = 1;
      this.getInjectionRegister();
    },
    reloadPage() {
      if (
        parseInt(this.paging.pageNumber) <= this.paging.amountPage &&
        parseInt(this.paging.pageNumber) > 0
      ) {
        this.getInjectionRegister();
      } else alert("Trang không hợp lệ");
    },
  },

  filters: {
    // định dạng ngày
    formatDate(inputDate) {
      var a = new Date(inputDate);
      var month = a.getMonth();
      var day = a.getDate();
      if (month < 10) month = "0" + month.toString();
      if (day < 10) day = "0" + day.toString();
      var date = day + "/" + month + "/" + a.getFullYear().toString();
      return date;
    },
    formatStatus(status) {
      var statusDisplay = "";
      if (trangthai && status !== null) {
        statusDisplay = trangthai[status.toString()];
      }
      return statusDisplay;
    },
    formatGioiTinh(gt) {
      var gtDisplay = "";
      if (gioitinh) {
        gtDisplay = gioitinh[gt.toString()];
      }
      return gtDisplay;
    },
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
      background-color: #1565C0;
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

.table-summary {
  font-size: 14px;
  font-family: GoogleSans-Medium;
  display: flex;
  position: relative;
  margin: 18px 16px 0 16px;
  height: 45px;

  .price-number {
    position: absolute;
    //TODO sẽ phải sửa lại cái này cho chuẩn với cột nguyên giá
    right: 120px;
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
.table-summary {
  font-size: 14px;
  font-family: GoogleSans-Medium;
  display: flex;
  /* position: relative; */
  position: absolute;
  bottom: 0px;
  /* margin: 18px 16px 0 16px; */
  height: 63px;
}

.content-grid {
  // margin: 16px 16px 16px 16px;
  height: calc(100% - 165px);
  /* height: 100%; */
  position: relative;
  overflow: auto;
  box-sizing: border-box;
}
.table-summary {
  font-size: 14px;
  font-family: GoogleSans-Medium;
  display: flex;
  /* position: relative; */
  width: 100%;
  position: absolute;
  bottom: 0px;
  /* align-items: center; */
  /* margin: 18px 16px 0 16px; */
  height: 63px;
  padding: 18px 16px;
  box-sizing: border-box;
}
.table-summary .summary {
  height: 100%;
  width: 100%;
  display: flex;
  align-items: center;
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

table tr th {
  white-space: nowrap;
  cursor: auto !important;
}

table tbody tr {
  cursor: pointer;
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
.table-summary .price-number {
  position: absolute;
  right: 72px;
}
</style>
