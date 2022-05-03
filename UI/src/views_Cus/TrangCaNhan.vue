<template>
  <div>
    <div
      class="page-banner overlay-dark bg-image"
      style="background-image: url(../assets/img/bg_image_1.jpg)"
    >
      <div class="banner-section">
        <div class="container text-center wow fadeInUp">
          <h3 class="font-weight-normal">SỔ TIÊM CHỦNG CÁ NHÂN</h3>
          <nav aria-label="Breadcrumb">
            <ol
              class="
                breadcrumb breadcrumb-dark
                bg-transparent
                justify-content-center
                py-0
                mb-2
              "
            >
              <li class="breadcrumb-item">
                <a @click="$router.push({ name: 'STC-dien-tu' })">Trang chủ</a>
              </li>
              <li class="breadcrumb-item active" aria-current="page">
                Trang cá nhân
              </li>
            </ol>
          </nav>
        </div>
        <!-- .container -->
      </div>
      <!-- .banner-section -->
    </div>

    <div class="container">
      <h5>THÔNG TIN CÁ NHÂN</h5>

      <form class="contact-form mt-5">
        <div class="row mb-3">
          <div class="col-sm-6 py-2 wow fadeInLeft">
            <label for="fullName">Họ tên </label>
            <input
              type="text"
              id="fullName"
              class="form-control"
              placeholder="Họ tên.."
            />
          </div>
          <div
            class="col-12 col-sm-6 py-2 wow fadeInLeft"
            data-wow-delay="300ms"
          >
            <label for="date">Ngày sinh </label>
            <input type="date" class="form-control" />
          </div>
          <div
            class="col-12 col-sm-6 py-2 wow fadeInRight"
            data-wow-delay="300ms"
          >
            <label for="subject">Giới tính</label>
            <select name="departement" id="departement" class="custom-select">
              <option value="general">Nam</option>
              <option value="cardiology">Nữ</option>
              <option value="cardiology">Khác</option>
            </select>
          </div>
          <div class="col-sm-6 py-2 wow fadeInRight">
            <label for="emailAddress">Email</label>
            <input
              type="text"
              id="emailAddress"
              class="form-control"
              placeholder="Email address.."
            />
          </div>
          <div class="col-12 py-2 wow fadeInUp">
            <label for="subject">Địa chỉ</label>
            <input
              type="text"
              id="subject"
              class="form-control"
              placeholder="Địa chỉ.."
            />
          </div>
        </div>
      </form>
    </div>
    <div class="container">
      <h5>LỊCH SỬ TIÊM CHỦNG</h5>
      <v-data-table :headers="headers" :items="desserts" class="elevation-1">
        <template v-slot:header.name="{ header }">
          {{ header.text.toUpperCase() }}
        </template>
      </v-data-table>
    </div>
  </div>
</template>

<script>
export default {
  name: "TrangCaNhan",
  data: () => ({
    headers: [
      {
        text: "Tên Vacxin",
        align: "start",
        value: "name",
      },
      { text: "Lần tiêm", value: "calories" },
      { text: "Ngày tiêm", value: "fat" },
      { text: "Phản ứng sau tiêm", value: "carbs" },
      { text: "Ngày hẹn", value: "protein" },
      { text: "Nơi tiêm", value: "iron" },
    ],
    desserts: [
      {
        name: "Vacxin 6 trong 1 Hexaxim(6in1)",
        calories: 2,
        fat: 2022-5-3,
        carbs: 1,
        protein: 2022-5-10,
        iron: "One-health, 16 Cau Giay",
      },
      {
        name: "Vacxin viêm gan B",
        calories: 1,
        fat: 2021-6-4,
        carbs: 1,
        protein: 2022-3-3,
        iron: "One-health, 16 Cau Giay",
      },
    ],
  }),
};
</script>

<style>
</style>
