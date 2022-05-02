<template>
  <div class="detail-container" id="ThemKhauHao" v-if="isClose==false">
    <div class="summary-input">
         <div class="icon-cancel btn btn-close" @click="AddModal"></div>
      <div class="d-header">
        <div class="back-btn icon-back"></div>
        <div class="header-title">Tính khấu hao</div>
      </div>

      <div class="input-container">
        <div class="left-pane">
          <div class="first-line">
            <div class="input-field fd-c">
              <div class="input-label">Nội dung chứng từ</div>
              <input maxlength="255" class="bc input-two-third br-5" type="text" />
            </div>

            <!-- <div class="current-date">
              <div class="input-field">
                <div class="input-label">Ngày</div>
                <input type="date" />
              </div>
            </div> -->
          </div>

          <div class="reason">
            <div class="input-field">
              <div class="date-container">
                  <div> Tháng</div>
                  <input type="text" class="bc input-date br-5" id="i-month"/>
              </div>
              <div class="date-container">
                  <div> Năm</div>
                  <input type="text" class="bc input-date br-5"/>
              </div>
              <!-- <select>
                <option value="volvo">
                  Tháo dỡ một hay một số bộ phận tài sản giảm giá trị tài sản
                </option>
                <option value="saab">
                  Tháo dỡ một hay một số bộ phận tài sản giảm giá trị tài sản
                </option>
                <option value="fiat">
                  Đánh giá lại tài sản cố định để xác định giá trị doanh nghiệp
                </option>
                <option value="audi">
                  Đánh giá lại tài sản nhằm mục đích liên doanh, góp vốn, chia
                  tách, hợp nhất, giải thể
                </option>
              </select> -->
            </div>
          </div>
        </div>

        <div class="right-pane">
          <div class="record-date">
            <div class="input-field fd-c">
              <div class="input-label">Ngày chứng từ <b style="color:red; margin-left:4px;">*</b></div>
              <input type="date" class="bc br-5" id="i-date"/>
            </div>
          </div>
          <div class="record-number">
            <div class="input-field fd-c">
              <div class="input-label">Số chứng từ<b style="color:red; margin-left:4px;">*</b></div>
              <input type="text" class="bc br-5" id="i-trading"/>
            </div>
          </div>
        </div>
        <div class="total-2">
            <b>Tổng khấu hao tháng:</b><b style="margin-left:10px">50.000 đ</b>
        </div>
      </div>
    </div>
  
    <div class="detail-input">
       <div class="table-content" style="padding:20px 20px 0;">
          <div class="search" >
                <input
                id="assetSearchBox"
               class="br-5"
                type="text"
                placeholder="Nhập từ khóa tìm kiếm "
                v-model="inputSearch"
                @change="getAssetIncrease('filter')"
                />
                <div class="icon-search"></div>
            </div>
          <table>
             
            <thead>
              <tr>
                <th>STT</th>
                <th>Mã tài sản</th>
                <th>Tên tài sản</th>
                <th>Loại tài sản</th>
                <th>Bộ phận sử dụng</th>
                <th>Nguyên giá</th>
                <th>Giá trị khấu hao tháng</th>
                <th>Hao mòn lũy kế</th>
                <th>Giá trị còn lại</th>
              </tr>
            </thead>

            <tbody>
              <!-- <tr v-for="item in 100" :key="item"> -->
            <tr style="text-align:center;">
                <td>1</td>
                <td>TS0001</td>
                <td>Máy tính</td>
                <td>Thiết bị, máy móc</td>
                <td>Ban giám đốc</td>
                <td>10.000.000</td>
                <td>50.000</td>
                <td>200.000</td>
                <td>8.800.000</td>
              </tr>
            </tbody>
          </table >
           <div class="total" style="display:flex; padding: 10px 0px">
                <div style="margin-left:100px;"><b>Tổng</b></div>
                <div style="margin-left:739px;"><b>50.000</b></div>
                  <div style="margin-left:138px;"><b>200.000</b></div>
                    <div style="margin-left:93px;"><b>8.800.000</b></div>
                <!-- <div style="margin:10px 520px;"><b>50.000</b></div>
                <div style="margin:10px 520px;"><b>50.000</b></div> -->
            </div>
        </div>
        <div class="table-pagination">
                <!-- paging -->
   <div class="table-summary">
        <div class="summary">
          <!-- <div class="asset-number">Tổng số tài sản: {{ amountAsset }}</div> -->

          <div class="paging-toolbar">
            <div class="leftchild">
              <div
              title="Trang đầu"
                class="p-button first-page"
                @click="firstPage()"
              ></div>
              <div title="Trang trước" class="p-button prev-page" @click="backPage()"></div>
              <div >Trang</div>
              <input
                type="number"
                class="text-pagebumber"
                v-model="paging.pageNumber"
                @change="reloadPage()"
               
              />
              <div >
                Trên {{ paging.amountPage }}
              </div>

              <div title="Trang sau" class="p-button next-page" @click="nextPage()"></div>
              <div
              title="Trang cuối"
                class="p-button last-page"
                @click="lastPage()"
              ></div>
              <div title="Tải lại" class="p-button refresh" @click="getAsset()"></div>
              <select
              title="Số bản ghi trên 1 trang"
                name=""
                id=""
                class="select-quantitypage"
                v-model="paging.recordNumber"
                @change="getAsset('filter')"
              >
                <option value="25">25</option>
                <option value="50">50</option>
                <option value="100">100</option>
              </select>
            </div>
          </div>

          <div class="price-number">
            Tổng số: 1 bản ghi
          </div>
        </div>
      </div>
      <!-- pagging -->
        </div>
    </div>

    <div class="footer">
      <div class="align-left">
        <BaseButton>Hủy</BaseButton>
      </div>
      <div class="align-right">
        <BaseButton>Cất và đóng</BaseButton>
        <BaseButton>Cất và thêm</BaseButton>
      </div>
    </div>
  </div>
</template>

<script>
import BaseButton from "@/views/evaluate/base/BaseButton.vue";
export default {
    components: {
      BaseButton,

  },
    data() {
    return {
     isClose:false,
      paging: {
        amountPage: 1,
        pageNumber: 1,
        recordNumber: 50,
        totalRecord: 0,
        startRecord: 0,
        endRecord: 0,
      }
    }
    },
  methods: {
     AddModal() {
      this.$parent.AddModal();
    }
  },

};
</script>
<style lang="scss" scoped>
@import "@/style/_variables.scss";
@import "./css/common.css";
.btn-close{
        background-color: inherit;
        float:right;
}
.input-field .input-two-third {
    width: 650px;
}
.bc{
  background-color: efof2 !important;;
}
.detail-container {
  width: 100%;
  height: 100%;
    position: absolute;
    top:0;
    left:0;
    background-color: #fff;
  .input-field {
      display: flex;
    .input-label {
      font-family: "GoogleSans-Bold";

    }
    input {
      height: 34px;
      box-sizing: border-box;
      border: #d6d6d6 1px solid;
      padding: 10px;
      // background-color: white;
    }
    select {
      background-color: white;
      border: #d6d6d6 1px solid;
      height: 34px;
      min-width: 100px;
      padding-left: 10px;
    }
  }
.date-container{
        margin-right: 30px;
            font-family: 'GoogleSans-Bold';
}
.input-date{
    width:90px;

}
#i-date{
    width:170px;
}
#i-trading{
    width:170px;
}
.search{
    display: flex;
    height: 35px;
    width:fit-content;
    border-radius: 5px;
    border: 1px solid #beccc9;
    align-items: center;
    flex-direction: row-reverse;
    margin-bottom: 20px;
    padding: 0px !important;
    font-size: 12px;
}
.total-2{
    width:100%;
}
.total{
    width:100%;
   
}
  .content {
    height: calc(100% - 120px);
    .table-container {
      height: 100%;
      .table-content {
        height: 100%;
        overflow: auto;
        margin-bottom: 10px;
      }
      .table-pagination {
        height: 60px;
   background-color: #f8f9fe !important;
      }
    }
  
}
  .summary-input {
    background-color: $background-evalutate;
    padding: 16px 16px 24px 16px;
    height: fit-content;

    .d-header {
      height: 60px;
      font-size: 1.6rem;
      .header-title {
        font-family: "GoogleSans-Bold";
      }
    }
    .input-container {
      width: 100%;
      display: flex;
      .left-pane {
        width: initial;
        border-right: solid 1px grey;
        padding-right: 16px;

        .first-line {
          display: flex;
          justify-content: flex-start;
          margin-bottom: 12px;
          div {
            margin-right: 12px;
          }
        }

        .reason {
          width: 100%;
          .input-field {
            width: 100%;
            select {
              width: 100%;
            }
          }
        }
      }
      .right-pane {
        padding-left: 16px;
        width: 40%;

        .record-date {
          width: 300px;
          margin-bottom: 12px;
        }
      }
    }
  }

  .detail-input {
    height: calc(100% - 329px);
position: relative;
    .detail-label {
      font-size: 1.2rem;
      font-family: "GoogleSans-Bold";
      margin-bottom: 8px;
    }

    .table-wrapper {
      height: calc(100% - 71px);
      overflow: auto;
      border: $border-button-basic solid 1px;
      table {
        thead {
          tr:nth-child(2) {
            th {
              top: 40px !important;
            }
          }

          tr {
            th {
              border-right: 1px solid #d6d6d6;
            }
          }
        }
        tbody {
          tr {
            td {
              input {
                width: 100%;
              }
              //   input[type="text"]:disabled {
              //     background: #ececec;
              //   }
            }
          }
        }
      }
    }
    .table-button {
      display: flex;
      height: 50px;
      align-items: center;
      div {
        margin-right: 16px;
      }
    }
  }
  .footer {
    height: 60px;
    background-color: #031457;
    padding: 10px 16px 0 16px;
    display: flex;
    justify-content: space-between;
    .align-right {
      display: flex;
      div {
        margin-left: 16px;
      }
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
      width: 1322px!important;
        background-color: #f8f9fe;


  .price-number {
    position: absolute;
    //TODO sẽ phải sửa lại cái này cho chuẩn với cột nguyên giá
    right: 120px;
  }
}
.content {
  height: calc(100vh - 60px);
  width: calc(100% - 200px);
  margin-left: 210px;
  transition: all 0.25s;
  background-color: white;
  user-select: none;
}

.content-nav {
  padding-top: 26px;
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
.content {
  height: calc(100vh - 68px);
  width: calc(100% - 200px);
  height: fit-content;
  margin-left: 210px;
  transition: all 0.25s;
}

.content-grid {
  margin: 16px 16px 16px 16px;
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
  margin-left: 0;
  box-sizing: border-box;
  width: 100%;
  height: calc(100% - 60px);
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
  50%{
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

.btn-first-page {
  background-image: url("../../assets/icon/btn-firstpage.svg");
}

.prev-page {
  background: url(../../assets/icon/common-icon.png) no-repeat -700px -124px;
}

.paging-toolbar {
  height: 100%;
  display: flex;
  margin-left: calc((100% - 752px) / 2);
}

.paging-toolbar .leftchild {
  height: 100%;
  min-width: 330px;
  display: flex;
  align-items: center;
}

.paging-toolbar .leftchild .p-button {
  height: 24px;
  width: 24px;
  border: 1px solid #d0d0d0;
  border-radius: 3px;
  background-color: #fff;
  margin-right: 2px;
}

.paging-toolbar .leftchild .first-page {
  /* background: url(/QLCH/resources/images/common-icon.png) no-repeat -649px -124px;
    background: url(../../icon/common-icon.png) no-repeat;
    background-repeat: no-repeat;
    background-size: contain;
    background-position: center; */
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
  text-align: center;
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

.leftchild .last-page {
  background: url(../../assets/icon/common-icon.png) no-repeat -798px -124px;
}

.leftchild .next-page {
  background: url(../../assets/icon/common-icon.png) no-repeat -749px -124px;
}
.select-quantitypage {
  width: 46px;
  height: 26px;
  border: 1px solid #d0d0d0;
  outline: none !important;
}
.text-pagebumber,
.select-quantitypage {
  border-radius: 3px;
  text-align: center;
}

.select-quantitypage {
  appearance: none;
  background: url(../../assets/icon/arrow-down-line.png) no-repeat;
  background-position: 29px 11px;
  padding-left: 4px;
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

.filter-menu .item-type {
}
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
  background-image: url("../../assets/icon/add.png") !important;
  background-size: 16px;
  background-repeat: no-repeat;
  background-position: center;
  height: 28px;
  width: 28px;
}
.selected-row {
  background: #8dd2f369 !important
}
.p-button{
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