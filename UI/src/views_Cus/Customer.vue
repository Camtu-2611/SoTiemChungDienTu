<template>
  <div class="customer">
    <Head />
    <div>
      <!-- <Home/> -->
      <router-view
        tag="div"
        :isFilterMenu="isFilterMenu"
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
    // props:{
    //     isShowCustomer: Boolean
    // },
    data() {
        return {
            
        }
    }
}
</script>
