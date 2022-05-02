<template>
  <div class="input-text-component">
    <div class="input-label" v-bind:style="{ 'padding-bottom': paddingLabel }">
      {{ inputLabel.label }}
      <span> {{ inputLabel.require }} </span>
    </div>
    <div class="input-container">
      <input
        type="date"
        v-bind="$attrs"
        v-bind:value="inputValue"
        v-on="inputListeners"
        ref="inputComponent"
        @blur="$emit('blur', $event.target.value)"
      />
    </div>
  </div>
</template>

<script>
export default {
  name: "InputDate",

  props: ["inputLabel", "inputValue", "paddingLabel"],

  data() {
    return {};
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

  method: {},
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

.input-text-component {
  height: 100%;
  width: 100%;
  z-index: 100;
}
.input-label {
  display: flex;
  align-items: center;
  font-size: 12px;
  font-weight: 700;
  color: #212121;
  padding-bottom: 4px;
  white-space: nowrap;
}

.input-label span {
  color: #ff0000;
  font-weight: normal;
  margin-left: 4px;
}
.input-container {
  height: calc(100% - 22px);
  width: 100%;
  display: flex;
  justify-content: space-between;
  position: relative;
}

.input-container input {
  outline: none;
  height: 100%;
  width: 100%;
  padding: 6px 10px;
  box-sizing: border-box;
  outline: none;
  border: 1px solid #babec5;
  font-size: 13px;
  border-radius: 2px;
  font-family: MISA-Regular, MISA-Bold, MISA-Italic, MISA-Semibold !important;
}

input[type="date"]::-webkit-calendar-picker-indicator {
  background-image: url("../baseResourcesAccounting/img/Sprites.64af8f61.svg");
  background-repeat: no-repeat;
  background-position: -123px -310px;
}

input:focus {
  border: 1px solid #049ae6;
}
::placeholder {
  font-style: italic;
  font-size: 12px;
}
input:disabled {
  background-color: #eff0f2;
}
.error {
  border-color: #ff0000 !important;
}
</style>