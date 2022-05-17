<template>
   <div>
    <div class="page-hero bg-image overlay-dark" style="background-image: url(../assets/img/bg_image_1.jpg);">
    <div class="hero-section">
      <div class="container text-center wow zoomIn">
        <h1 >TIÊM VẮC XIN</h1>
        <span class="subhead">Bảo vệ chính mình, người thân và cộng đồng</span> <br><br>
 
         <div class="py-2 wow btn btn-primary" 
         style="height : 45px"
             @click="$router.push({ name: 'tu-van' })"
            >
           Đăng ký tiêm ngay
            </div>
           
      </div>
    </div>
  </div>


  <div class="bg-light">
    <div class="page-section py-3 mt-md-n5 custom-index">
      <div class="container">
        <div class="row justify-content-center">
          <div class="col-md-4 py-3 py-md-0">
            <div class="card-service wow fadeInUp">
              <div class="circle-shape bg-secondary text-white">
                <span class="mai-chatbubbles-outline"></span>
              </div>
              <p><span>Cẩm nang</span> </p>
            </div>
          </div>
          <div class="col-md-4 py-3 py-md-0">
            <div class="card-service wow fadeInUp">
              <div class="circle-shape bg-primary text-white">
                <span class="mai-shield-checkmark"></span>
              </div>
              <p><span>Đăng ký tiêm</span></p>
            </div>
          </div>
          <div class="col-md-4 py-3 py-md-0">
            <div class="card-service wow fadeInUp">
              <div class="circle-shape bg-accent text-white">
                <span class="mai-basket"></span>
              </div>
              <p><span>Vắc xin</span></p>
            </div>
          </div>
        </div>
      </div>
    </div> <!-- .page-section -->

    <div class="page-section pb-0">
      <div class="container">
        <div class="row align-items-center">
          <div class="col-lg-6 py-3 wow fadeInUp">
            <h2>NHỮNG ĐIỀU CẦN BIẾT TRƯỚC<br>KHI TIÊM CHỦNG</h2>
            <p class="text-grey mb-4">Khám sàng lọc trước tiêm chủng <br>

              1. Tại sao cần khám sàng lọc trước khi tiêm chủng <br>
              
              Khám sàng lọc trước khi tiêm chủng là việc rất cần thiết nhằm phát hiện những bất thường cần lưu ý để quyết định cho trẻ (người được tiêm) tiêm chủng, tạm hoãn việc tiêm chủng hay không được tiêm một loại vắc xin nào đó.
              
              Vì vậy, người nhà của trẻ hay người đi tiêm chủng và bác sĩ cần hợp tác với nhau để đảm bảo việc tiêm chủng là đúng thời điểm, hiệu quả và an toàn.
              
              Kết quả khám sàng lọc trước tiêm chủng được căn cứ trên những thông tin người nhà hay người đi tiêm chủng cung cấp cho bác sĩ và những thông tin bác sĩ phát hiện sau khi thăm khám.</p>
              <div class="py-2 wow btn btn-primary" 
              style="height : 45px"
             @click="$router.push({ name: 'cam-nang' })"
            >
           Xem thêm
            </div>
           
          </div>
          <div class="col-lg-6 wow fadeInRight" data-wow-delay="400ms">
            <div class="img-place custom-img-1">
              <img src="../../public/assets/img/bg-doctor.png" alt="">
            </div>
          </div>
        </div>
      </div>
    </div> <!-- .bg-light -->
  </div> <!-- .bg-light -->



 
<script type="application/javascript" defer src="../public/assets/js/theme.js"></script>
<script type="application/javascript" defer src="../public/assets/js/jquery-3.5.1.min.js"></script>
<script type="application/javascript" defer src="../public/assets/js/bootstrap.bundle.min.js"></script>
   </div>
</template>

<script>
export default {
    name: 'Home',
    data() {
        return {
           e1: 1,
      selected: [""],
      thongtinDK: {},
      defaultthongtinDK: {
        hoten:"",
        ngaysinh:"",
        gioitinh:"",
        sodienthoai:"",
        email:"",
        diachi:"",
        tentrungtam:"",
        ngaydangkytiem:"",
        danhsachvacxin:[],
        nguoitao:"",
        ngaytao:new Date().toISOString(),
        nguoichinhsua:"",
        ngaychinhsua:new Date().toISOString()

      },
      listRecord: [],
      listTrungTam:[],
            
        }
    },
    
}
</script>

<style>

</style>
