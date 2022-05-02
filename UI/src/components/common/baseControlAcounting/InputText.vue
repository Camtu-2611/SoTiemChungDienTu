<template>
  <div class="input-list-component">
    <div class="input-label" v-bind:style="{ 'padding-bottom': paddingLabel }">
      {{ inputLabel.label }}
      <span> {{ inputLabel.require }} </span>
    </div>
    <div class="input-container" v-bind:style="{ height: heightInput }">
      <div class="input-main">
        <input
          v-bind:style="{ 'text-align': cursorInput, border: border }"
          :class="classInput"
          :title="titleInput"
          v-bind="$attrs"
          v-bind:value="inputValue"
          v-on="inputListeners"
          ref="inputComponent"
          @blur="$emit('blur', $event.target.value)"
          @keyup="$emit('keyup', $event.target.value)"
          @change="$emit('change', $event.target.value)"
        />
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "InputText",

  props: [
    "inputLabel",
    "inputValue",
    "paddingLabel",
    "cursorInput",
    "heightInput",
    "border",
    "classInput",
    "titleInput",
  ],

  data() {
    return {
      
    };
  },
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

  watch: {},
  methods: {
    /**
     * Set focus cho ô Input
     * CreatedBy: ntmanh(30/06/2021)
     * */
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
.input-list-component {
  width: 100%;
  height: 100%;
  z-index: 0;
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

.input-container {
  height: 32px;
  width: 100%;
  position: relative;
}
.input-main {
  width: 100%;
  height: 100%;
  position: relative;
}
.input-main input {
  position: absolute;
  left: 0;
  top: 0;
  outline: none;
  height: 100%;
  width: 100%;
  padding: 6px 10px;
  box-sizing: border-box;
  outline: none;
  border: 1px solid #babec5;
  font-size: 13px;
  border-radius: 2px;
  background-color: #fff ;
  color: #494949;
}

input:focus {
  border: 1px solid #049ae6;
}
::placeholder {
  font-family: "Segoe UI", Tahoma, Geneva, Verdana, sans-serif;
  font-style: italic;
  font-size: 12px;
  color: #a9a9a9;
  /* color: #b6b6b6; */
}
input:disabled {
  background-color: #eff0f2;
}
input::-webkit-outer-spin-button,
input::-webkit-inner-spin-button {
  -webkit-appearance: none;
  margin: 0;
}
.disable {
  background-color: #eff0f2 !important;
}
.class-error {
  border-color: #ff0000 !important;
}
</style>

