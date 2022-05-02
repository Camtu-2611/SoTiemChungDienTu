<template>
  <div class="btn" @click="$emit('click')">
    <!-- <div class="base-btn"> -->
    <slot></slot>
  </div>
</template>

<script>
export default {};
</script>
<style lang="scss" scoped>
@import "@/style/_variables.scss";

.btn {
  height: 36px;
  line-height: 36px;
  padding: 0 12px;
  background-color: white;

  &:hover {
    background-color: $border-button-basic;
  }

  &.active {
    background-color: $primary;
    color: white;

    &:hover {
      background-color: $sub-primary;
    }
  }
  &.solid {
    height: 30px;
    font-family: "GoogleSans-Bold";
    line-height: 30px;
    padding: 4px 10px;
    border: 1px solid grey;
  }

  &.active-contrast {
    background-color: $table-header;
    color: white;
    border: none;
    &:hover {
      background-color: $sub-primary;
    }
  }
}
</style>