<template>
  <div class="input-combobox-component">
    <div class="input-label" v-bind:style="{ 'padding-bottom': paddingLabel }">
      {{ inputLabel.label }}
      <span> {{ inputLabel.require }} </span>
    </div>

    <div class="input-list" ref="inputCombobox">
      <div class="input-main">
        <div class="selected-item" ref="multiSelected" v-if="multiInput">
          <div
            class="item-input"
            v-for="(item, index) in inputValue"
            :key="index"
          >
            <div class="item-text">{{ item.data }}</div>
            <div class="icon-x" @click="removeItemInput(index)"></div>
          </div>
        </div>
        <input
          type="text"
          ref="inputComponent"
          v-if="multiInput"
          :style="{ 'padding-left': positionCursorInput }"
          v-on:keyup="searchItem($event)"
          @focus="inputMultiOnFocus"
        />
        <input
          v-if="!multiInput"
          type="text"
          ref="inputComponent"
          v-bind="$attrs"
          :value="inputValue"
          v-on="inputListeners"
          v-on:keyup="searchItem($event)"
          @blur="$emit('blur', $event.target.value)"
          @keyup="$emit('keyup', $event.target.value)"
          @change="$emit('change', $event.target.value)"
        />
      </div>
      <div class="input-select-icon">
        <div class="icon-select border-right" v-if="comboboxValue.isPlus">
          <div class="icon-plus"></div>
        </div>
        <div class="icon-select" @click="btnComboMenuOnClick()">
          <div class="icon-dropdown" ref="iconDropdown"></div>
        </div>
      </div>
      <div
        class="combo-menu"
        ref="comboboxList"
        v-if="isCombobox"
        v-bind:style="{
          left: comboboxValue.positionLeft,
          top: comboboxValue.positionTop,
          width: comboboxValue.widthForm,
        }"
      >
        <div class="combo-menu-header" v-if="comboboxValue.isHeader">
          <div
            class="column"
            v-for="(itemHeader, index) in comboboxValue.headerName"
            :key="index"
            :style="{ width: comboboxValue.widthColumn[index] }"
          >
            {{ itemHeader }}
          </div>
        </div>
        <div
          class="combo-menu-content"
          :style="{ 'max-height': comboboxValue.maxHeight }"
        >
          <div
            class="menu-row"
            v-for="(rows, index) in valueDropdown"
            :key="index"
            :class="{ 'row-selected': rowIndexSelected[index] }"
            @click="
              rowSelectedOnClick(rows[comboboxValue.fieldSelected], index)
            "
          >
            <div
              class="column cell"
              v-for="(cell, i) in rows"
              :key="i"
              :style="{ width: comboboxValue.widthColumn[i] }"
              :title="cell"
            >
              {{ cell }}
            </div>

            <div class="cell-check" v-if="multiInput">
              <div :class="{ 'icon-check': iconCheck[index] }"></div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "ComboboxPlus",
  comments: [],
  props: [
    "inputLabel",
    "paddingLabel",
    "inputValue",
    "comboboxValue",
    "isEnable",
    "multiInput",
  ],

  data() {
    return {
      isCombobox: false,
      rowIndexSelected: [],
      iconCheck: [],
      timeOut: 0,
      valueDropdown: [],
      positionCursorInput: "10px",
    };
  },
  created() {},
  computed: {
    inputListeners() {
      var me = this;
      return Object.assign({}, this.$inputListeners, {
        input(event) {
          me.$emit("input", event.target.value);
        },
      });
    },
  },

  mounted() {},
  watch: {
    isEnable() {
      if (this.isEnable == true) {
        this.$refs.inputComponent.classList.remove("disable");
        this.$emit(
          "input",
          this.comboboxValue.content[0][this.comboboxValue.fieldSelected]
        );
      }

      if (this.isEnable == false) {
        this.$refs.inputComponent.classList.add("disable");
        this.$emit("input", "");
      }

      if (this.isEnable == "online") {
        this.$refs.inputComponent.classList.remove("disable");
      }
      if (this.isEnable == "offline") {
        this.$refs.inputComponent.classList.add("disable");
      }
    },

    isCombobox() {
      if (this.isCombobox == true)
        this.$refs.iconDropdown.classList.add("icon-dropdown-close");
      else this.$refs.iconDropdown.classList.remove("icon-dropdown-close");
    },
  },
  methods: {
    /**
     * Hàm ẩn hiện ra combo box menu
     * Hiển thị các items có trong isCombobox
     * CreatedBy: ntmanh(10/06/2021)
     * */
    btnComboMenuOnClick() {
      this.$refs.inputComponent.focus();

      this.isCombobox = !this.isCombobox;

      // nếu trạng thái list dropdown = true
      if (this.isCombobox) {
        // nếu Combobox đang set = disable
        if (this.isEnable == false || this.isEnable == "offline") {
          this.isCombobox = false;
          return;
        }
        if (this.multiInput == true) {
          this.setIconSelected(this.inputValue);
        }
        this.valueDropdown = this.comboboxValue.content;
        this.findRowSelected();
      }
    },

    /**
     * Tìm kiếm xem row nào đang mapping với data ở ô Input
     * CreatedBy: ntmanh(24/06/2021)
     * */
    findRowSelected() {
      if (this.multiInput == false || this.multiInput == undefined) {
        let rows = this.comboboxValue.content;
        let indexRow = -1;
        let inputValue = this.inputValue == null ? "" : this.inputValue;

        rows.forEach((row) => {
          indexRow++;
          let stringCompare = row[this.comboboxValue.fieldSelected];
          stringCompare = stringCompare == null ? "" : stringCompare;
          if (
            stringCompare.toLowerCase().trim() ==
            inputValue.toLowerCase().trim()
          ) {
            this.setRowSelected(indexRow);
            return;
          }
        });
      }
    },
    /**
     * Click chuột vào 1 item Set giá trị selected cho row đó
     * CreatedBy: ntmanh(24/06/2021)
     * */
    setRowSelected(index) {
      let totalRow = this.valueDropdown.length;
      for (let i = 0; i < totalRow; i++) {
        if (i == index) {
          this.rowIndexSelected[i] = true;
          continue;
        }
        this.rowIndexSelected[i] = false;
      }
    },

    /**
     * Set các icon tích xanh ở các rows  trong combobox chọn nhiều
     * Thực hiện kiểm tra xem những row nào đang được chọn, thì hiển thị dấu tích xanh
     * CreatedBy: ntmanh(29/06/2021)
     * */
    setIconSelected(listItem) {
      this.iconCheck = [];
      for (let i = 0; i < this.comboboxValue.content.length; i++) {
        this.iconCheck[i] = false;
        for (let j = 0; j < listItem.length; j++) {
          if (
            this.comboboxValue.content[i][this.comboboxValue.fieldSelected] ==
            listItem[j].data
          ) {
            this.iconCheck[i] = true;
            break;
          }
        }
      }
    },

    /**
     * Thực hiện thêm xóa dữ liệu của combobox chọn nhiều
     * Nếu item chưa có trong list thì thêm mới vào list
     * Nếu item đã có trong list thì loại bỏ khỏi list
     * CreatedBy: ntmanh(29/06/2021)
     * */
    setValuesItemInput(item) {
      this.$refs.inputComponent.focus();
      let listItem = this.inputValue;

      // lặp để kiểm tra xem item đã có trong list chọn nhiều hay chưa
      // nếu đã có: xóa khỏi list đó, kết thúc hàm luôn
      for (let i = 0; i < listItem.length; i++) {
        if (listItem[i].data == item) {
          listItem.splice(i, 1);
          this.$emit("input", listItem);
          this.setIconSelected(listItem);
          return;
        }
      }
      // nếu iteam chưa tồn tại, thêm mới 1 item vào list
      listItem.push({ data: item });
      this.$emit("input", listItem);
      this.setIconSelected(listItem);
    },

    /**
     * Xóa từng item ở combobox chọn nhiều
     * CreatedBy: ntmanh(29/06/2021)
     * */
    removeItemInput(index) {
      if (this.isEnable == "offline") return;
      let listItem = this.inputValue;
      listItem.splice(index, 1);
      this.$emit("input", listItem);
      this.setIconSelected(listItem);
      this.$refs.inputComponent.focus();
    },

    /**
     * Click chuột vào 1 item thì gán giá trị cho input
     * CreatedBy: ntmanh(24/06/2021)
     * */
    rowSelectedOnClick(value, index) {
      // nếu là combobox chọn nhiều
      if (this.multiInput == true) {
        // set giá trị cho combobox chọn nhiều
        this.setValuesItemInput(value);
      } else {
        this.$emit("input", value);
        this.$emit("rowClicked", index);
        this.isCombobox = false;
        this.$refs.inputComponent.focus();
      }
    },

    /**
     * Tìm kiếm phần tử trong List dropdown
     * CreatedBy: ntmanh(24/06/2021)
     * */
    searchItem(event) {
      const me = this;
      let input = event.target.value;

      // nếu keyCode == 9 thì return luôn
      if (event.keyCode == 9) return;

      // cho hiện list rows lên
      this.isCombobox = true;

      // clear timeout
      clearTimeout(this.timeOut);

      //set timeout
      this.timeOut = setTimeout(function () {
        // làm rỗng list kết quả
        me.valueDropdown = [];
        // lặp từng dòng
        for (let i = 0; i < me.comboboxValue.content.length; i++) {
          let t = me.comboboxValue.content[i].length;
          // lặp từng cột
          for (let j = 0; j < t; j++) {
            // nếu tìm thấy
            let comboboxValue = me.comboboxValue.content[i][j];
            comboboxValue = comboboxValue == null ? "" : comboboxValue;
            if (
              comboboxValue
                .trim()
                .toLowerCase()
                .indexOf(input.trim().toLowerCase()) != -1
            ) {
              // tìm thấy: gán dòng kết quả vào list valueDropdown
              me.valueDropdown.push(me.comboboxValue.content[i]);
              break;
            }
          }
        }
        // nếu text ở input = rỗng | input đang là ô chọn nhiều
        // thì không hiển thị dải màu xanh đậm của các ô được chọn
        if (input.trim() == "" || me.multiInput == true) {
          me.setRowSelected(-1);
          return;
        }
        me.setRowSelected(0);
      }, 500);
    },


    /**
     * Set vị trí con trỏ trong ô input khi ở chế độ combobox chọn nhiều
     * CreatedBy: ntmanh(29/06/2021)
     * */
    inputMultiOnFocus() {
      if (this.isEnable == "offline") return;
      clearTimeout(this.timeOut);
      var me = this;
      this.timeOut = setTimeout(function () {
        var left = me.$refs.multiSelected.clientWidth;
        me.positionCursorInput = left + 10 + "px";
      }, 1);
    },
  },
};
</script>

<style scoped>
/* @font-face {
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
} */
.input-combobox-component {
  width: 100%;
  /* font-family: MISA-Regular, MISA-Bold, MISA-Italic, MISA-Semibold !important; */
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

.input-list {
  height: 32px;
  width: 100%;
  position: relative;
}
.input-main {
  width: 100%;
  height: 100%;
  position: relative;
}
.selected-item {
  display: flex;
  align-items: center;
  position: absolute;
  left: 0;
  top: 0;
  z-index: 1;
  height: 100%;
}
.item-input {
  display: flex;
  align-items: center;
  border: 1px solid #ccc;
  border-radius: 3px;
  background-color: #f0f0f0;
  padding: 2px 3px 2px 5px;
  margin: 4px;
  overflow: hidden;
  text-overflow: ellipsis;
  font-size: 12px;
}
.icon-x {
  width: 16px;
  height: 16px;
  margin-left: 4px;
  box-sizing: border-box;
  background-image: url("../baseResourcesAccounting/img/Sprites.64af8f61.svg");
  background-position: -80px -312px;
  cursor: pointer;
}
.input-main input {
  position: absolute;
  left: 0;
  top: 0;
  outline: none;
  height: 100%;
  width: 100%;
  padding: 6px 32px 6px 12px;
  box-sizing: border-box;
  outline: none;
  border: 1px solid #babec5;
  font-size: 13px;
  border-radius: 2px;
  color: #494949;
}
::placeholder {
  font-family: "Segoe UI", Tahoma, Geneva, Verdana, sans-serif;
  font-style: italic;
  font-size: 12px;
  color: #a9a9a9;
  /* color: #b6b6b6; */
}
.input-select-icon {
  /* width: 64px; */
  height: calc(100% - 2px);
  display: flex;
  position: absolute;
  right: 1px;
  top: 1px;
}
.input-select-icon :hover {
  background-color: #e0e0e0;
}
.border-right {
  border-right: 1px solid #babec5;
  box-sizing: border-box;
}
.icon-select {
  width: 32px;
  display: flex;
  align-items: center;
  justify-content: center;
  cursor: pointer;
}
.icon-plus {
  width: 16px;
  height: 16px;
  background-image: url("../baseResourcesAccounting/img/Sprites.64af8f61.svg");
  background-repeat: no-repeat;
  background-position: -32px -312px;
}
.icon-dropdown {
  width: 16px;
  height: 16px;
  background-image: url("../baseResourcesAccounting/img/Sprites.64af8f61.svg");
  background-repeat: no-repeat;
  background-position: -560px -359px;
}
.icon-dropdown-close {
  transform: rotate(180deg);
  transition: transform 0.3s linear;
}
input:focus {
  border: 1px solid #049ae6;
}
.combo-menu {
  position: absolute;
  z-index: 2;
  background-color: #fff;
  border: 1px solid #babec5;
  border-radius: 2px;
  overflow: hidden;
  box-sizing: border-box;
  font-size: 13px;
  padding: 2px 0px;
}
.combo-menu-header {
  height: 32px;
  width: 100%;
  background: #f4f5f8;
  display: flex;
  font-size: 13px;
  font-weight: bold;
  justify-content: space-between;
}
.combo-menu-content {
  width: 100%;
  overflow-y: auto;
  max-height: 160px;
}
::-webkit-scrollbar {
  width: 10px;
  height: 10px;
  background: #f1f1f1;
}
::-webkit-scrollbar-thumb {
  background: #888888;
}
.menu-row {
  width: 100%;
  height: 32px;
  display: flex;
  margin-top: 1px;
  position: relative;
}
.menu-row:hover {
  color: #049ae6;
  background-color: #ebedf0;
  cursor: pointer;
}
.column {
  height: 100%;
  display: flex;
  align-items: center;
  padding: 0px 10px;
  box-sizing: border-box;
  text-align: left;
}

.disable {
  background-color: #eff0f2;
}
.row-selected {
  color: #fff !important;
  background-color: #049ae6 !important;
}
.cell-check {
  width: 36px;
  height: 100%;
  display: flex;
  align-items: center;
  position: absolute;
  right: 0;
}
.cell-check .icon-check {
  width: 16px;
  height: 16px;
  background-image: url("../baseResourcesAccounting/img/Sprites.64af8f61.svg");
  background-position: -896px -312px;
}
input[type="text"]:disabled {
  background-color: #eff0f2;
}
.class-error {
  border-color: #ff0000 !important;
}
</style>

