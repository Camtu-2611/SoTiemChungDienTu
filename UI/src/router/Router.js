import Vue from 'vue'
import VueRouter from 'vue-router'
//import Home from '../components/TheHome.vue'
import SearchAsset from '@/views/evaluate/SearchAsset.vue'
import Audit from '@/views/audit/Audit'
import AssetCategory from '@/views/assetCategory/AssetCategory'
import AuditDetail from '@/views/audit/AuditDetail'
import OwnerTransfer from '@/views/ownerTransfer/OwnerTransfer'
import OwnerTransferDetail from '@/views/ownerTransfer/OwnerTransferDetail'
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
import CTSoTiem from "@/views/injection_books/CTSoTiem";
import InjectionSchedules from "@/views/injection_schedules/InjectionSchedules";
import InjectionScheduleDetail from "@/views/injection_schedules/InjectionScheduleDetail";
import ManageVaccines from "@/views/manage_vaccine/ManageVaccines";
import ManageVaccineType from "@/views/manage_vaccine/ManageVaccineType";
import ManageVaccinePackage from "@/views/manage_vaccine/ManageVaccinePackage";
import ManageVaccineDetail from "@/views/manage_vaccine/ManageVaccineDetail";

Vue.use(VueRouter)

export const router = new VueRouter({
    routes: [
       // { path: '/', component: Home, name: "home" },
       { path: '/search', component: SearchAsset, name: "search" },
       { path: '/asset/audit', component: Audit, name: "audit" },
       { path: '/asset/asset-category', component: AssetCategory, name: "assetCategory" },
       { path: '/asset/owner-transfer', component: OwnerTransfer, name: "owner-tranfer" },
       { path: '/asset/audit-detail/:state/:id', component: AuditDetail, name: "audit-detail" },
       { path: '/asset/owner-transfer-detail/:state/:id', component: OwnerTransferDetail, name: "owner-transfer-detail" },

       { path: '/admin', component: InjectionBooks, name: "admin" },
       { path: '/admin/injection-register', component: InjectionRegister, name: "injection-register" },      
       { path: '/admin/injection-register-detail', component: InjectionRegisterDetail, name: "injection-register-detail", props: true},      
       { path: '/admin/injection-books', component: InjectionBooks, name: "injection-books" },
       { path: '/admin/injection-book-detail', component: InjectionBookDetail, name: "injection-book-detail",  props: true},
       { path: '/admin/injection-book-history', component: CTSoTiem, name: "injection-book-history",  props: true},
       { path: '/admin/injection-schedules', component: InjectionSchedules, name: "injection-schedules" },
       { path: '/admin/injection-schedule-detail', component: InjectionScheduleDetail, name: "injection-schedule-detail",  props: true},
       { path: '/admin/manage-vaccines', component: ManageVaccines, name: "manage-vaccines" },
       { path: '/admin/manage-vaccine-detail', component: ManageVaccineDetail, name: "manage-vaccine-detail",  props: true},
       { path: '/admin/manage-vaccine-type', component: ManageVaccineType, name: "manage-vaccine-type" },
       { path: '/admin/manage-vaccine-package', component: ManageVaccinePackage, name: "manage-vaccine-package" },

       
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