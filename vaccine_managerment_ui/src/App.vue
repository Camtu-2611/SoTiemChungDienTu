
<template>
	<div id="app">
 		<Header/>
		<Home/>
		<Footer/>
	</div>
</template>

<script>

import Header from './components/Header.vue'
import Home from './components/Home.vue'
import Footer from './components/Footer.vue'

export default {
	name: 'app',
	data () {
		return {

		}
	},
	components: {
		Home,
		Header,
		Footer
	}
}
</script>

 
<style scoped lang="css">
@import '/public/assets/css/maicons.css';
@import '/public/assets/css/bootstrap.css';
@import '/public/assets/vendor/owl-carousel/css/owl.carousel.css';
@import '/public/assets/vendor/animate/animate.css';
@import '/public/assets/css/theme.css';

@import'~bootstrap/dist/css/bootstrap.css'
</style>
