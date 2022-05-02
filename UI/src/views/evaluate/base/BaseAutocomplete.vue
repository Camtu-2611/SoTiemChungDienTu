<template>
  <v-autocomplete
    tag="div"
    class="custom-autocomplete input-one-third"
    item-value="departmentId"
    item-text="departmentCode"
    background-color="white"
  ></v-autocomplete>
</template>

<script>
export default {};
</script>
<style lang="scss" scoped>
.custom-autocomplete input {
  border: none;
  padding-left: 10px;
  font-size: 14px;
}
</style>