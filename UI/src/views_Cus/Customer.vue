<template>
  <div class="customer">
    <Head />
    <div>
      <!-- <Home/> -->
      <router-view
        tag="div"
        :isFilterMenu="isFilterMenu"
        :tenTaiKhoan="tentaikhoan"
        @allAsset="allAsset"
      />
      <Footer />
    </div>
  </div>
</template>

<script>
import Head from "../components/layout/Head.vue";
import Home from "./Home.vue";
import Footer from "./Footer.vue";
export default {
    name: 'Customer',
    components:{
    Home,
    Head,
    Footer,
    },
    props:{
        tentaikhoan : String
    },
    data() {
        return {
            
        }
    }
}
</script>
<style lang="css" >
@import "../../public/assets/css/maicons.css";
@import "../../public/assets/css/bootstrap.css";
@import "../../public/assets/vendor/owl-carousel/css/owl.carousel.css";
@import "../../public/assets/vendor/animate/animate.css";
@import "../../public/assets/css/theme.css";

@import "~bootstrap/dist/css/bootstrap.css";
</style>