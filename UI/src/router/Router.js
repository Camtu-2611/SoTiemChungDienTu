import Vue from 'vue'
import VueRouter from 'vue-router'
//import Home from '../components/TheHome.vue'
import Asset from '@/components/dictionary/AssetManagement.vue'
import IncreaseAsset from '@/views/increaseAsset/IncreaseList.vue'
import EvaluateAsset from '@/views/evaluate/EvaluateAsset.vue'
import SearchAsset from '@/views/evaluate/SearchAsset.vue'
import TinhKhauHao from '@/views/KhauHao/TinhKhauHao.vue'
import GhiGiam from '@/views/KhauHao/GhiGiam.vue'
import Audit from '@/views/audit/Audit'
import AssetCategory from '@/views/assetCategory/AssetCategory'
import AuditDetail from '@/views/audit/AuditDetail'
import OwnerTransfer from '@/views/ownerTransfer/OwnerTransfer'
import OwnerTransferDetail from '@/views/ownerTransfer/OwnerTransferDetail'
import BaoDuong from '@/views/baoduong/BaoDuong'
import CTBaoDuong from '@/views/baoduong/CTBaoDuong'
import Admin from '@/views/Admin'
import Home from '@/views_Cus/Home'
import DKTiem from '@/views_Cus/DKTiem'
import Vacxin from '@/views_Cus/Vacxin'
import VacxinDetail from '@/views_Cus/VacxinDetail'
import Camnang from '@/views_Cus/Camnang'
import Tuvan from '@/views_Cus/Tuvan'
import TrangCaNhan from '@/views_Cus/TrangCaNhan'
import Customer from '@/views_Cus/Customer'
import Signin from "@/signin/Signin";
import SigninAdmin from "@/signin/SigninAdmin";
import InjectionRegister from "@/views/injection-register/InjectionRegister";
import InjectionRegisterDetail from "@/views/injection-register/InjectionRegisterDetail";
import InjectionBooks from "@/views/injection_books/InjectionBooks";
import InjectionBookDetail from "@/views/injection_books/InjectionBookDetail";
import InjectionSchedules from "@/views/injection_schedules/InjectionSchedules";
import InjectionScheduleDetail from "@/views/injection_schedules/InjectionScheduleDetail";
import ManageVaccines from "@/views/manage_vaccine/ManageVaccines";
import ManageVaccineDetail from "@/views/manage_vaccine/ManageVaccineDetail";

Vue.use(VueRouter)

export const router = new VueRouter({
    routes: [
       // { path: '/', component: Home, name: "home" },
       { path: '/asset/increase', component: IncreaseAsset, name: "increase" },
       { path: '/asset/evaluate', component: EvaluateAsset, name: "evaluate" },
       { path: '/search', component: SearchAsset, name: "search" },
       { path: '/asset/khauhao', component: TinhKhauHao, name: "khauhao" },
       { path: '/asset/ghigiam', component: GhiGiam, name: "ghigiam" },
       { path: '/asset/audit', component: Audit, name: "audit" },
       { path: '/asset/bao-duong', component: BaoDuong, name: "bao-duong" },
       { path: '/asset/asset-category', component: AssetCategory, name: "assetCategory" },
       { path: '/asset/owner-transfer', component: OwnerTransfer, name: "owner-tranfer" },
       { path: '/asset/audit-detail/:state/:id', component: AuditDetail, name: "audit-detail" },
       { path: '/asset/ctbaoduong/:state/:id', component: CTBaoDuong, name: "ctbaoduong" },
       { path: '/asset/owner-transfer-detail/:state/:id', component: OwnerTransferDetail, name: "owner-transfer-detail" },

       { path: '/admin', component: InjectionBooks, name: "admin" },
       { path: '/admin/injection-register', component: InjectionRegister, name: "injection-register" },      
       { path: '/admin/injection-register-detail', component: InjectionRegisterDetail, name: "injection-register-detail", props: true},      
       { path: '/admin/injection-books', component: InjectionBooks, name: "injection-books" },
       { path: '/admin/injection-book-detail', component: InjectionBookDetail, name: "injection-book-detail",  props: true},
       { path: '/admin/injection-schedules', component: InjectionSchedules, name: "injection-schedules" },
       { path: '/admin/injection-schedule-detail', component: InjectionScheduleDetail, name: "injection-schedule-detail",  props: true},
       { path: '/admin/manage-vaccines', component: ManageVaccines, name: "manage-vaccines" },
       { path: '/admin/manage-vaccine-detail', component: ManageVaccineDetail, name: "manage-vaccine-detail",  props: true},
       
        //{ path: '/admin', component: Admin, name: "admin" },      
        { path: '/dang-ky-tiem', component: DKTiem, name: "dang-ky-tiem" },      
        { path: '/', component: Signin, name: "dang-nhap" },      
        { path: '/signinAdmin', component: SigninAdmin, name: "signinAdmin" },
        { path: '/customer', component: Home, name: "STC-dien-tu" },   
        { path: '/trangcanhan', component: TrangCaNhan, name: "trang-ca-nhan" },  
        { path: '/vac-xin', component: Vacxin, name: "vac-xin" },  
        { path: '/vac-xin-detail', component: VacxinDetail, name: "vac-xin-detail" },      
        { path: '/cam-nang', component: Camnang, name: "cam-nang" },   
        { path: '/tu-van', component: Tuvan, name: "tu-van" },   
    ]
})