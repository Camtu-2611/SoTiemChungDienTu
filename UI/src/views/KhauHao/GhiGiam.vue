<template>
  <div class="component-wrapper">
    <div class="header">
      <div class="align-left">
        <h2 class="tilte">Ghi giảm tài sản cố định</h2>
      </div>
      <div class="align-right">
          <button class="btn btn-add" @click="AddModal()">Thêm ghi giảm</button>
      </div>
    </div>
    <div class="content">
      <div class="table-container">
          <div class="filter" style="display:flex; align-items:center; margin-bottom:1rem;">
            <div class="tool-dropdown">
              <ButtonDropdown2 :buttonName="'Lọc'" />
            </div>
            <!-- <button class="btn btn-filter fw-7" style="margin-right:15px; height:35px">Lọc</button> -->
            <div class="font-14">Đầu năm đến hiện tại</div>

            <div class="search" style="margin-left:835px;">
                <input
                id="assetSearchBox"
               class="font-12 br-5"
                type="text"
                placeholder="Nhập từ khóa tìm kiếm "
               v-model="key_search"
                @change="timKiem()"
                />
                <div @click="timKiem()" class="icon-search"></div>
            </div>
      
           <div class="btn-action">
              <div class="btn-reload" @click="getAllRecord()"></div>
              <!-- <div class="btn-excel"></div> -->
              <div class="btn-setting"></div>
            </div>
        </div>
          <!-- <select class="form-control" >
              <option>Choose Province</option>
              <option v-for="(item,index) in listPhieuGhiGiam" :key="index" v-bind:value="item.soChungTu" >{{ item.soChungTu }}</option>
          </select> -->
        <div class="table-content" style="padding:0px 20px;overflow:auto; height:350px;">
          <table>
             
            <thead style="background-color:#fff !important">
              <tr>
                <th></th>
                <th>Số chứng từ</th>
                <th>Ngày chứng từ</th>
                <th>Nội dung chứng từ</th>
                <!-- <th>Tổng thu hồi</th> -->
                <th>Người lập</th>
                <th>Chức năng</th>
              </tr>
            </thead>

            <tbody>
              <!-- <tr v-for="item in 100" :key="item"> -->
            <tr style="text-align:center;" v-for="(item,index) in listPhieuGhiGiam" :key="index">
                <td><input type="checkbox"></td>
                <td>{{item.soChungTu}}</td>
                <td>{{item.ngayChungTu}}</td>
                <td> {{item.noiDung}}</td>
                <!-- <td>{{item.tongGiaTriThuHoi}}</td> -->
                <td>{{item.nguoiLap}}</td>
                <td><a>Xem chi tiết</a></td>
              </tr>
            </tbody>
           

            <!-- <BaseLoading ref="BaseLoading_ref" /> -->
          </table>
           <!-- <div class="total" style="display:flex;">
                <div style="margin:10px 0; margin-left:140px"><b>Tổng</b></div>
                <div style="margin:10px 0; margin-left:609px"><b>50.000</b></div>
            </div> -->
        </div>
        <div class="table-pagination">
                <!-- paging -->
   <!-- <div class="table-summary">
        <div class="summary"> -->
          <!-- <div class="asset-number">Tổng số tài sản: {{ amountAsset }}</div> -->

          <!-- <div class="paging-toolbar">
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
      </div> -->
      <!-- pagging -->
        </div>
      </div>
    </div>

<ThemGhiGiam v-if="isShow==true"/>
  </div>
</template>

<script>
import ButtonDropdown2 from '@/components/common/baseControlAcounting/ButtonDropdown2'
import ThemGhiGiam from '@/views/KhauHao/ThemGhiGiam'
import axios from "axios"
export default {
    components: {

    ButtonDropdown2,
    ThemGhiGiam

  },
    data() {
    return {
      listPhieuGhiGiam:[],
      // phieuGhiGiamMoi:{
      //   soChungTu:"",
      //   noiDung:"",
      //   ngayChungTu:""

      // },
     isShow:false,
     key_search:"",
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
    created() {
     this.getAllRecord();
    //  this.AddModal();
    // this.processTreeAccount();
  },
  methods: {
    timKiem(){
       try {
        var me = this;
       axios
          .get("https://localhost:44382/GetSearchPhieuGhiGiam/"+this.key_search)
          .then((response) => {
            me.listPhieuGhiGiam = response.data.data;
          })
          .catch(() => {});
      } catch (error) {
        console.log(error);
      }
    },
     async getAllRecord() {
      try {
        var me = this;
        await axios
          .get("https://localhost:44382/GetAllPhieuGhiGiam")
          .then((response) => {
            me.listPhieuGhiGiam = response.data.data;
            me.totalRecord = response.data.data.length;
          })
          .catch(() => {});
      } catch (error) {
        console.log(error);
      }
    },
    AddModal(){
      this.isShow=!this.isShow;
     this.createPhieuGhiGiam();
    
    },
     createPhieuGhiGiam(){
       // khởi tạo thêm một phiếu ghi giảm
      try {
         axios
          .post("https://localhost:44382/InsertGhiGiam")
          .then(() => {
            // me.totalRecord = response.data.data.length;
            console.log("tao phieu moi");
          })
          .catch(() => {});
      } catch (error) {
        console.log(error);
      }
    },
    showDialog(text, Id) {
      if (document.getElementById("ThemKhauHao") != null)
        document.getElementById("ThemKhauHao").style.display = "none";
      if (text == "insert") {
        this.formMode = "insert";
        this.alerMsg = "Thêm mới thành công";
      } else {
        this.listSelectRow = [];
        this.listSelectRow.push(Id);
        this.formMode = "update";
        this.alerMsg = "Cập nhật thành công";
        this.assetIdUpdate = Id;
      }
      setTimeout(() => {
        this.$refs.ModalCreateAsset_ref.show();
      }, 300);
      // debugger; // eslint-disable-line no-debugger
    },
  },

};
</script>

<style lang='scss' scoped>


.component-wrapper {
  height: calc(100% - 40px);
  padding: 32px 16px 10px 16px;
  // position: relative;
  background-color: #f1f1f1;
  .header {
    height: 60px;
    display: flex;
  }
.btn{
    
    align-items: center;
    display: flex;
    width: fit-content;
    height: 40px;
    border-radius: 30px;
    background-color: #1BA3C9;
    justify-content: center;
}
.btn-filter{
  border: 2px solid #000;
  background-color: #fff;
   
}
.btn-print{
    
    align-items: center;
    display: flex;
    width: 20px;
    border-radius: 0;
    height: 35px;
    color: #000;
     border:1px solid;
    justify-content: center;
}
.header .align-right{
    position: absolute;
    color: #fff;

    right: 16px;
    justify-content: center;
    border: none;
    color:#fff;
  

}

.filter{
    padding: 20px 20px 0;
}
.search{
    display: flex;
    height: 35px;
    border-radius: 5px;
    border: 1px solid #beccc9;
    align-items: center;
    flex-direction: row-reverse;
    margin-left: 600px;
    padding: 0px !important;
}
.search #assetSearchBox{
   
    border-radius: 5px;
    border: none;
    padding: 0 5px !important;
}
.fw-7{
  font-weight:700;
}
.font-12{
    font-size:12px;
}
.font-13{
    font-size:13px;
}
.font-14{
    font-size:14px;
}
.font-15{
    font-size:16px;
}
.br-5{
    border-radius: 5px;
}
.tool-dropdown{
  margin-right:20px;
}
 .icon-search {
width: 20px;
        height: 25px;

        &:hover {
          cursor: pointer;
          //TODO sau này thêm action tìm kiếm vào đây
        }
 }
 .refresh-icon {
  background: url(../../assets/icon/common-icon.png) no-repeat -846px -122px;
  margin-left:10px;
  height: 30px;
  width: 30px;
  margin-right: 10px;
  border: #beccc9 1px solid
}
.print{
    width: 10px;
}
.print .icon-print {
     background: url(../../assets/icon/qlts-icon.svg) no-repeat -324px -60px;
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
        background-color: #f8f9fe;
      }
    }
  }
}
.button-tool-icon {
  width: 16px;
  height: 16px;
  background-image: url("/baseResourcesAccounting/img/Sprites.64af8f61.svg");
  background-repeat: no-repeat;
  background-position: -560px -359px;
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

.component-wrapper .content {
height: fit-content;
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

// .content-nav {
//     position: relative;
// }

// .content-nav  :after {
//     content: '';
//     display: block;
//     border-bottom: 3px solid #00abfe;
//     width: 0;
//     position: absolute;
//     left: 0;
//     -webkit-transition: 1s ease;
//     transition: 1s ease;
// }

// .content-nav :hover:after {
//     width: 100%;
// }

.content-nav {
  height: 70px;
  padding: 16px;
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
      padding: 0 !important;
    }

    .btn-search {
      margin-left: 10px;
    }

    .features-pane-right {
      position: absolute;
      right: 0;

      // background-color:lightsalmon;
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
        height: 10px;

        &:hover {
          cursor: pointer;
          //TODO sau này thêm action tìm kiếm vào đây
        }
      }
    }
  }
}

.content-grid {
  margin: 16px 16px 16px 16px;
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