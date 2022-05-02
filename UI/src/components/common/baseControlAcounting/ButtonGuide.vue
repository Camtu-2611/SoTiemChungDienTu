<template>
  <div class="guide-tour-component">
    <div class="guide-tour-icon"></div>
    <div class="guide-tour-label">Hướng dẫn</div>
  </div>
</template>

<script>
export default {

}
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
.guide-tour-component {
  position: relative;
  display: flex;
  align-items: center;
  cursor: pointer;
  font-family: MISA-Regular, MISA-Bold, MISA-Italic, MISA-Semibold !important;
}
.guide-tour-icon {
  width: 24px;
  height: 24px;
  background-image: url("../baseResourcesAccounting/img/Sprites.64af8f61.svg");
  background-repeat: no-repeat;
  background-position: -984px -144px;
}
.guide-tour-label {
  white-space: nowrap;
  padding-left: 5px;
  font-size: 13px;
  color: #0075c0;
}
.guide-tour-label:hover {
  text-decoration: underline;
}
</style>