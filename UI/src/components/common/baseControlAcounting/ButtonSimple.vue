<template>
  <div class="title-button-component">
    <button class="btn-main" @click="btnOnClick">{{ buttonName }}</button>
  </div>
</template>


<script>
export default {
  name: "ButtonSimple",

  props: ["buttonName"],

  methods:{
    btnOnClick(){
      this.$emit("buttonSimpleOnClick");
    }
  }
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
  font-family: MISA-Regular, MISA-Bold, MISA-Italic, MISA-Semibold !important;
}
button.btn-main {
  border-radius: 30px 30px 30px 30px;
  padding: 8px 20px;
  height: 36px;
  border: 1px solid transparent;
  color: #fff;
  background-color: #038cd1;
  font-weight: bold;
  font-size: revert;
}
.title-button-component button:hover {
  background-color: #06a2f0;
  cursor: pointer;
}
</style>