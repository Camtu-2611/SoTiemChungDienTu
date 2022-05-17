<template>
  <div class="customer">
    <Head :redirectString="redirectString" @logout="logout" />
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
        tentaikhoan : String,
        redirectString: String,
        // isShowCustomer: Boolean
    },
    data() {
        return {
            
        }
    },
    methods: {
      logout(redirectString){
        this.redirectString = redirectString
        // this.isShowCustomer = false
        console.log(this.redirectString)
        this.$emit('redirect', this.redirectString)
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