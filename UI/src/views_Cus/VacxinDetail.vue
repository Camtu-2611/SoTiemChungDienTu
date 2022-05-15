<template>
  <div v-show="isActive" class="div-container">
    <div class="modal-background"></div>
    <div class="modal-content">
      <div class="modal-header">
        THÔNG TIN CHI TIẾT VẮC XIN
        <span @click="hide()"
          ><div data-v-1b34bf39="" class="icon-cancel btn btn-close"></div
        ></span>
      </div>
     
        <div class="content-grid grid" oncontextmenu="return false;">
        <table class="table-asset" id="tableAsset">
          <colgroup>
            <col width="100" />
            <col width="400" />

          </colgroup>
          <thead>
          
          </thead>

          <tbody>
            <tr>
              <td>Tên vắc xin</td>
              <td>{{ctVacxin.tenvacxin}}</td> 
            </tr>
             <tr>
              <td>Số lô vắc xin</td>
              <td>{{ctVacxin.solo}}</td> 
            </tr>
            <tr>
              <td>Ngày sản xuất</td>
              <td>{{ctVacxin.ngaysanxuat}}</td> 
            </tr>
            <tr>
              <td>Hạn sử dụng</td>
              <td>{{ctVacxin.hansudung}}</td> 
            </tr>
             <tr>
              <td>Giá vắc xin</td>
              <td>{{ctVacxin.giavacxin}}</td> 
            </tr>
            <tr>
              <td>Mô tả chi tiết</td>
              <td>{{ctVacxin.mota}}</td> 
            </tr>
          </tbody>
          
        </table>
      
      </div>

    
       
      
      <div class="modal-footer">
        <div class="btn" @click="hide()">Đóng</div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";
export default {
  name: "DKTiem",

  props: {
    idvacxin: String,
  },
  data() {
    return {
      e1: 1,
      selected: [""],
      ctVacxin: {},
      isActive: false,
    };
  },
  created() {
    this.getVacxinbyID();
    console.log(this.idvacxin);
  },

  watch: {
    idvacxin() {
      this.getVacxinbyID();
    },
  },
  methods: {
    /**
     * Thực hiện lấy bản ghi của vacxin theo id
     * */
    async getVacxinbyID() {
      try {
        console.log(this.idvacxin + " detail");
        await axios
          .get(`http://localhost:64016/api/Vacxin/${this.idvacxin}`)
          .then((response) => {
            if (response.data) {
              var res = response.data.data;
              if (res) {
                this.ctVacxin = res;
              }
            }
          })
          .catch(() => {});
      } catch (error) {
        console.log(error);
      }
    },
    show() {
      this.isActive = true;
    },

    hide() {
      this.isActive = false;
    },
  },
};
</script>


<style lang='scss' scoped>
.div-container {
  position: relative;
  width: 100%;
  height: 100%;
  z-index: 2;
}
.modal-background {
  position: fixed;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background-color: black;
  opacity: 0.5;
}
.btn.btn-confirm-delete {
  background-color: #ff4646;
  color: white;
}
.btn.btn-confirm-delete:hover {
  background-color: #ff7777;
}

.modal-content {
  position: relative;
  top: calc(50% - 100px);
  left: calc(50% - 175px);
  width: 500px;
  height: 350px;
  background-color: white;

  .modal-header {
    height: 60px;
    padding: 0 16px;
    line-height: 60px;
    font-size: 18px;
    font-weight: 500;
  }

  .modal-content {
    height: calc(100% - 110px);
    padding: 16px;
  }
  .modal-footer {
    height: 50px;
    display: flex;
    align-items: center;
    justify-content: flex-end;
    background-color: #f5f5f5;
    padding: 0 10px;
    //TODO set auto focus vao nut xoa
    .btn {
      margin: 0 6px;
      height: 34px;
    }
  }
}
.modal-content {
  border-radius: 4px;
}
l .modal-content .modal-header {
  border-bottom: 1px solid #e6e6e6;
}

.modal-content .modal-footer {
  border-radius: 4px;
}

.modal-content .modal-header {
  height: 50px;
}
.icon-cancel {
  background-image: url(/img/cancel.cbb32219.svg);
  background-repeat: no-repeat;
  background-size: 14px 18px;
  background-position: center;
  /* width: 20px; */
  /* height: 20px; */
  position: absolute;
  right: 12px;
  top: 5px;
  cursor: pointer;
}
.modal-content .modal-header {
  display: flex;
  align-items: center;
}
</style>