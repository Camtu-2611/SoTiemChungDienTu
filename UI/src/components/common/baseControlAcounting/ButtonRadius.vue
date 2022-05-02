<template>
  <div class="button-radius-component">
    <button class="button-tool">
      {{ buttonName }}
    </button>
  </div>
</template>

<script>
export default {
  props: ["buttonName"],
};
</script>

<style scoped>
button.button-tool {
  height: 36px;
  padding: 8px 20px;
  border: 1px solid #8d9096;
  border-radius: 30px;
  display: flex;
  justify-content: center;
  align-items: center;
  cursor: pointer;
  font-family: MISA-Regular, MISA-Bold, MISA-Italic, MISA-Semibold !important;
  color: #111;
  font-weight: 600;
}
button.button-tool:hover {
  background-color: #d2d3d6;
}

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
</style>