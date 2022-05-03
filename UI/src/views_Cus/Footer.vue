<template>
    <footer class="page-footer">
    <div class="container">
      <div class="row px-md-3">
        <div class="col-sm-6 col-lg-3 py-3">
          <h5>Hệ thống One-health</h5>
          <ul class="footer-menu">
            <li><a @click="$router.push({ name: 'STC-dien-tu' })">Trang chủ</a></li>
          </ul>
        </div>
        <div class="col-sm-6 col-lg-3 py-3">
          <h5>Đăng ký tiêm chủng</h5>
          <ul class="footer-menu">
            <li><a  @click="$router.push({ name: 'dang-ky-tiem' })">Đăng ký ngay</a></li>
          </ul>
        </div>
        <div class="col-sm-6 col-lg-3 py-3">
          <h5>Tư vấn tiêm chủng</h5>
          <ul class="footer-menu">
            <li><a @click="$router.push({ name: 'dang-ky-tiem' })">Tư vấn ngay</a></li>
          </ul>
        </div>
        <div class="col-sm-6 col-lg-3 py-3">
          <h5>Liên hệ hỗ trợ</h5>
          <a href="#" class="footer-link">+00 123 44556666</a>
          <a href="#" class="footer-link">SoTiemChung@gmail.com</a>
        </div>
      </div>

      <hr>

      <p id="copyright"> <a @click="$router.push({ name: 'STC-dien-tu' })">One-health</a>. Sổ tiêm chủng điện tử</p>
    </div>
  </footer>
</template>

<script>
export default {
    name: 'Footer',
    data() {
        return {
            textFooter: 'Hello Footer'
        }
    }
}
</script>

<style>

</style>
