<template>
  <div class="title-button-component">
    <button
      class="btn-main"
      v-bind:style="{
        'border-radius': borderMain,
        'background-color': backgroundColor,
        padding: padding,
      }"
      @click="btnDropDownOnClick()"
    >
      {{ buttonName }}
    </button>
    <div
      class="line-straight"
      v-bind:style="{
        'background-color': backgroundColor,
      }"
    >
      <div class="line-white"></div>
    </div>
    <button
      class="btn-dropdown"
      v-bind:style="{
        'border-radius': borderDropdown,
        'background-color': backgroundColor,
      }"
      @click="btnOption()"
      ref="btnIconDropdown"
    >
      <div class="btn-dropdown-icon"></div>
    </button>
  </div>
</template>


<script>
export default {
  name: "ButtonDropDown",

  props: [
    "buttonName",
    "borderMain",
    "borderDropdown",
    "backgroundColor",
    "padding",
    "idBtnOption"
  ],
  methods: {
    btnDropDownOnClick() {
      this.$emit("btnDropDownOnClick");
    },

    btnOption(){
      let top = this.$refs['btnIconDropdown'].getBoundingClientRect().y
      let left = this.$refs['btnIconDropdown'].getBoundingClientRect().x
      this.$emit("btnOptionDropdown", top, left );
      
    }
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
.title-button-component {
  display: flex;
  font-family: MISA-Regular;
  width: 100%;
  height: 100%;
  font-family: MISA-Regular, MISA-Bold, MISA-Italic, MISA-Semibold !important;
}
button.btn-main {
  border-radius: 30px 0 0 30px;
  padding: 8px 14px 8px 20px;
  height: 100%;
  border: 1px solid transparent;
  color: #fff;
  background-color: #038cd1;
  font-weight: bold;
  font-family: "MISA-Regular";
  font-size: revert;
}

button.btn-dropdown {
  width: 46px;
  height: 100%;
  padding: 0;
  border: 1px solid transparent;
  border-radius: 0 30px 30px 0;
  color: #fff;
  background-color: #038cd1;
  display: flex;
  align-items: center;
  justify-content: center;
}

.line-straight {
  width: 1px;
  background-color: #038cd1;
  display: flex;
  align-items: center;
}
.line-white {
  width: 1px;
  height: 20px;
  background-color: #fff;
}
.btn-dropdown-icon {
  width: 16px;
  height: 16px;
  background-image: url("../baseResourcesAccounting/img/Sprites.64af8f61.svg");
  background-repeat: no-repeat;
  background-position: -848px -359px;
}
.title-button-component button:hover {
  background-color: #06a2f0;
  cursor: pointer;
}
</style>