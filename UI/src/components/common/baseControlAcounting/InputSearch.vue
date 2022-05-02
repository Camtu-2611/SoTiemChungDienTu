<template>
  <div class="input-search-component">
    <input
      type="text"
      :style="{
        border: border,
      }"
      ref="inputComponent"
      v-bind="$attrs"
      v-bind:value="inputValue"
      v-on="inputListeners"
      @blur="$emit('blur', $event.target.value)"
      @keyup="$emit('keyup', $event.target.value)"
    />
  </div>
</template>

<script>
export default {
  props: ["inputValue", "border"],

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
.input-search-component {
  width: 100%;
  height: 100%;
  font-family: MISA-Regular, MISA-Bold, MISA-Italic, MISA-Semibold !important;
}
::placeholder {
  font-style: italic;
  font-size: 12px;
}
.input-search-component input {
  width: 100%;
  height: 100%;
  outline: none;
  border: 1px solid #babec5;
  border-radius: 2px;
  box-sizing: border-box;
  padding: 6px 30px 6px 10px;
  background-image: url("../baseResourcesAccounting/img/icon-search.png");
  background-repeat: no-repeat;
  background-size: 25px;
  background-position-y: center;
  background-position-x: calc(100% - 6px);
}
::placeholder {
  font-family: "Segoe UI", Tahoma, Geneva, Verdana, sans-serif;
  font-style: italic;
  font-size: 12px;
  color: #a9a9a9;
  /* color: #b6b6b6; */
}
.input-search-component input:hover {
  outline: 1px solid #e2e2e2;
}
.input-search-component input:focus {
  border: 1px solid #049ae6;
}
</style>