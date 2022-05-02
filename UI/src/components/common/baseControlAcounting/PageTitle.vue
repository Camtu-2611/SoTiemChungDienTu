<template>
  <div class="layout-title">
    <div class="title-top">
      <div class="title-name">Danh mục nhà cung cấp</div>
      <div class="title-tool">
        <div class="guide-tour">
          <ButtonGuide />
        </div>
        <div class="tool-dropdown">
          <ButtonDropDown2 />
        </div>
        <div class="title-button">
          <!-- <ButtonDropdown :buttonName="'Thêm'" /> -->
          <ButtonSimple :buttonName="'Thêm'" />
        </div>
      </div>
    </div>
    <div class="title-bottom">
      <div class="title-bottom-icon"></div>
      <div class="title-bottom-content">Tất cả danh mục</div>
    </div>
  </div>
</template>

<script>
// import ButtonDropdown from "../Base/ButtonDropdown.vue";
import ButtonSimple from "@/components/Base/ButtonSimple";
import ButtonGuide from "@/components/Base/ButtonGuide";
import ButtonDropDown2 from '@/components/Base/ButtonDropDown2';

export default {
  name: "PageTitle",

  components: {
    // ButtonDropdown,
    ButtonSimple,
    ButtonGuide,
    ButtonDropDown2,
  },

  data() {
    return {};
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
  font-family: MISA-Regular, MISA-Bold, MISA-Italic, MISA-Semibold !important;
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
  height: 100%;
}

.tool-dropdown {
  height: 100%;
  margin-right: 12px;
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
  background-image: url("../baseResourcesAccounting/img/Sprites.64af8f61.svg");
  background-repeat: no-repeat;
  background-position: -224px -360px;
  display: flex;
  align-items: center;
}

.guide-tour{
  display: flex;
  align-items: center;
}
</style>