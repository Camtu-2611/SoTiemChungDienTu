<template>
  <div class="admin-page">
    <div class="body-container">
      <Navbar />
      <div class="body-right">
        <Header
          @activeFilterMenu="activeFilterMenu"
          :optionFilter="optionFilter"
        />
        <router-view
          tag="div"
          :isFilterMenu="isFilterMenu"
          @allAsset="allAsset"
        />
      </div>
    </div>
  </div>
</template>

<script>
import Header from "../components/layout/TheHeader.vue";
import Navbar from "../components/layout/TheNavbar.vue";

export default {
    name: 'Admin',
    components: {
    Header,
    Navbar
  },
//   props:{
//       isShowAdmin: Boolean
//   },
  methods: {
    activeFilterMenu(value) {
      this.isFilterMenu = value;
    },
    allAsset(value) {
      this.optionFilter = value;
    },
  },

  data() {
    return {
      isFilterMenu: false,
      optionFilter: "Tất cả",
    };
  },
}
</script>
