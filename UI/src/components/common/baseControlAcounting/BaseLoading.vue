<template>
  <div class="baseloading" v-if="isLoading"></div>
</template>

<script>
export default {
  name: "BaseLoading",

  data() {
    return {
      isLoading: false,
    };
  },
  methods: {
    showLoading() {
      this.isLoading = true;
    },
    hideLoading() {
      this.isLoading = false;
    },
  },
};
</script>

<style scoped>
.baseloading {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-image: url("../baseResourcesAccounting/loading.svg");
  background-repeat: no-repeat;
  background-position: center;
  z-index: 9999;
}
</style>