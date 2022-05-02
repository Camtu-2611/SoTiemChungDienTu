<template>
  <div class="button-dropdown-component">
    <button class="button-tool" v-bind:style="{color: textColor, 'border-color': borderColor}">
      <div class="button-tool-label">{{ buttonName }}</div>
      <div class="button-tool-icon"></div>
    </button>
  </div>
</template>

<script>
export default {
  props: ["buttonName", "textColor", "borderColor"],
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
.button-dropdown-component {
  font-family: MISA-Regular, MISA-Bold, MISA-Italic, MISA-Semibold !important;
  width: 100%;
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
  background-image: url("../baseResourcesAccounting/img/Sprites.64af8f61.svg");
  background-repeat: no-repeat;
  background-position: -560px -359px;
}
</style>