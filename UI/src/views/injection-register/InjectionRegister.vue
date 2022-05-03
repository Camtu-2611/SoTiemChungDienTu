<template>
  <div class="injection-register">
    <div class="content">
      <div class="content-grid">
        <v-data-table
          :headers="headers"
          :items="dsthongtindangky"
          sort-by="stt"
          class="elevation-1 content-grid"
        >
          <template v-slot:top>
            <v-toolbar flat>
              <v-toolbar-title>Danh sách đăng ký tiêm</v-toolbar-title>
              <v-divider class="mx-4" inset vertical></v-divider>
              <v-spacer></v-spacer>
              <v-dialog v-model="dialog" max-width="500px">
                <template v-slot:activator="{ on, attrs }">
                  <v-btn
                    color="primary"
                    dark
                    class="mb-2"
                    v-bind="attrs"
                    v-on="on"
                  >
                    Thêm mới
                  </v-btn>
                </template>
                <v-card>
                  <v-card-title>
                    <span class="text-h5">{{ formTitle }}</span>
                  </v-card-title>

                  <v-card-text>
                    <v-container>
                      <v-row>
                        <v-col cols="12" sm="6" md="4">
                          <v-text-field
                            v-model="editedItem.name"
                            label="Dessert name"
                          ></v-text-field>
                        </v-col>
                        <v-col cols="12" sm="6" md="4">
                          <v-text-field
                            v-model="editedItem.calories"
                            label="Calories"
                          ></v-text-field>
                        </v-col>
                        <v-col cols="12" sm="6" md="4">
                          <v-text-field
                            v-model="editedItem.fat"
                            label="Fat (g)"
                          ></v-text-field>
                        </v-col>
                        <v-col cols="12" sm="6" md="4">
                          <v-text-field
                            v-model="editedItem.carbs"
                            label="Carbs (g)"
                          ></v-text-field>
                        </v-col>
                        <v-col cols="12" sm="6" md="4">
                          <v-text-field
                            v-model="editedItem.protein"
                            label="Protein (g)"
                          ></v-text-field>
                        </v-col>
                      </v-row>
                    </v-container>
                  </v-card-text>

                  <v-card-actions>
                    <v-spacer></v-spacer>
                    <v-btn color="blue darken-1" text @click="close">
                      Hủy
                    </v-btn>
                    <v-btn color="blue darken-1" text @click="save">
                      Lưu
                    </v-btn>
                  </v-card-actions>
                </v-card>
              </v-dialog>
              <v-dialog v-model="dialogDelete" max-width="500px">
                <v-card>
                  <v-card-title class="text-h5"
                    >Bạn có chắc chắn muốn xóa bản ghi này?</v-card-title
                  >
                  <v-card-actions>
                    <v-spacer></v-spacer>
                    <v-btn color="blue darken-1" text @click="closeDelete"
                      >Hủy</v-btn
                    >
                    <v-btn color="blue darken-1" text @click="deleteItemConfirm"
                      >Đồng ý</v-btn
                    >
                    <v-spacer></v-spacer>
                  </v-card-actions>
                </v-card>
              </v-dialog>
            </v-toolbar>
          </template>
          <template v-slot:item.actions="{ item }">
            <v-icon small class="mr-2" @click="editItem(item)">
              mdi-pencil
            </v-icon>
            <v-icon small @click="deleteItem(item)">
              mdi-delete
            </v-icon>
          </template>
          <template v-slot:no-data>
            <v-btn color="primary" @click="getInjectionRegister()">
              Reset
            </v-btn>
          </template>
        </v-data-table>
      </div>
    </div>
  </div>
</template>
<script>
import axios from "axios";
export default {
  name: "InjectionRegister",
  data() {
    return {
      dialog: false,
      dialogDelete: false,
      headers: [
        {
          text: "STT",
          align: "start",
          sortable: false,
          value: "stt",
        },
        { text: "Họ và tên", value: "hoten", sortable: true },
        { text: "Số điện thoại", value: "sodienthoai", sortable: true },
        { text: "Ngày tháng năm sinh", value: "ngaysinh", sortable: true },
        { text: "Địa chỉ", value: "diachi", sortable: true },
        { text: "email", value: "email", sortable: true },
        { text: "Thao tác", value: "actions", sortable: false },
      ],
      dsthongtindangky: [],
      editedIndex: -1,
      editedItem: {
        stt: 0,
        hoten: "",
        sodienthoai: "",
        ngaysinh: "",
        diachi: "",
        email: "",
      },
      defaultItem: {
        stt: 0,
        hoten: "",
        sodienthoai: "",
        ngaysinh: "",
        diachi: "",
        email: "",
      },
    };
  },

  computed: {
    formTitle() {
      return this.editedIndex === -1 ? "New Item" : "Edit Item";
    },
  },

  watch: {
    dialog(val) {
      val || this.close();
    },
    dialogDelete(val) {
      val || this.closeDelete();
    },
  },

  created() {
    this.getInjectionRegister();
  },

  methods: {

    async getInjectionRegister(){
      var me = this;
      await axios
        .get("http://localhost:64016/api/ThongTinDangKyTiem")
        .then((response) => {
          if(response.data){
              me.dsthongtindangky = response.data.data;
          }
        })
        .catch((error) => {
          this.errorMessage = error.message;
          console.error("GET ThongTinDangKy Failed: ", error.message);
        });
    },
    initialize() {
      this.dsthongtindangky = [
        {
          stt: 1,
          hoten: "Hà Ngọc Linh",
          sodienthoai: "087265145672",
          ngaysinh: "10/06/1999",
          diachi: "Bắc Giang",
          email: "hnlinh@gmail.com",
        },
        {
          stt: 2,
          hoten: "Ngô Thị Cẩm Tú",
          sodienthoai: "0373223330",
          ngaysinh: "26/11/1999",
          diachi: "Hưng Yên",
          email: "nctu@gmail.com",
        },
      ];
    },

    editItem(item) {
      this.editedIndex = this.dsthongtindangky.indexOf(item);
      this.editedItem = Object.assign({}, item);
      this.dialog = true;
    },

    deleteItem(item) {
      this.editedIndex = this.dsthongtindangky.indexOf(item);
      this.editedItem = Object.assign({}, item);
      this.dialogDelete = true;
    },

    deleteItemConfirm() {
      this.dsthongtindangky.splice(this.editedIndex, 1);
      this.closeDelete();
    },

    close() {
      this.dialog = false;
      this.$nextTick(() => {
        this.editedItem = Object.assign({}, this.defaultItem);
        this.editedIndex = -1;
      });
    },

    closeDelete() {
      this.dialogDelete = false;
      this.$nextTick(() => {
        this.editedItem = Object.assign({}, this.defaultItem);
        this.editedIndex = -1;
      });
    },

    save() {
      if (this.editedIndex > -1) {
        Object.assign(this.dsthongtindangky[this.editedIndex], this.editedItem);
      } else {
        this.dsthongtindangky.push(this.editedItem);
      }
      this.close();
    },
  },
};
</script>

<style lang="scss" scoped>
.injection-register {
  background-color: #f1f1f1;
  width: 100%;
  height: 100%;

  .content {
    height: calc(100vh - 60px);
    transition: all 0.25s;
    user-select: none;
    margin: 8px;
    background-color: white;

    .content-grid {
      width: 100%;
      height: 100%;
    }
    .v-data-table__wrapper::v-deep {
      width: 100%;
      height: calc(100% - 124px);
    }
  }
}
</style>
