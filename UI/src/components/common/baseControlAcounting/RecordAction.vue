<template>
  <div
    class="tool-click"
    v-bind:style="{ 'left': positionLeft, 'top': positionTop, 'width': widthForm }"
    v-show="isFormAction"
    @blur="test()"
  >
    <div
      class="tool-click-item"
      v-for="(item, index) in itemActions"
      :key="index"
      @click="processAction(index)"
    >
      {{ item }}
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      isFormAction: false,
      positionLeft: "",
      positionTop: "",
      widthForm:"",
      itemActions: [],
    };
  },
  methods: {
    showForm( x, y, itemActions) {
      this.isFormAction = !this.isFormAction;
      if (this.isFormAction == true) {
        this.positionLeft = x;
        this.positionTop = y;
        this.itemActions = itemActions;
      }
    },

    hideForm(){
      this.isFormAction = false;
    },
    processAction(index){
      this.isFormAction = false;
      this.$emit("processAction", index);
    },

  },
};
</script>

<style scoped>
@font-face {
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
}
.tool-click {
  position: absolute;
  height: max-content;
  z-index: 101;
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  padding: 2px 1px;
  border-radius: 2px;
  border: 1px solid #babec5;
  z-index: 1;
  min-width: 100px;
  /* font-family: MISA-Regular, MISA-Bold, MISA-Italic, MISA-Semibold !important; */
  font-size: 13px;
}
.tool-click-item {
  width: 100%;
  display: flex;
  align-items: center;
  background-color: #fff;
  padding: 5.5px 10px;
  box-sizing: border-box;
  white-space: nowrap;
  text-overflow: ellipsis;
  overflow: hidden;
}
.tool-click-item:hover {
  background-color: #e8e9ec;
  color: #049ae6;
  cursor: pointer;
}
</style>
