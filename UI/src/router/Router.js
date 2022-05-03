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
import Customer from '@/views_Cus/Customer'
import Signin from "@/signin/Signin";
import InjectionRegister from "@/views/injection-register/InjectionRegister";
Vue.use(VueRouter)

export const router = new VueRouter({
    routes: [
       // { path: '/', component: Home, name: "home" },
        { path: '/asset', component: Asset, name: "asset" },
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
        { path: '/injection-register', component: InjectionRegister, name: "injection-register" },      

        //{ path: '/admin', component: Admin, name: "admin" },      
        { path: '/dang-ky-tiem', component: DKTiem, name: "dang-ky-tiem" },      
        { path: '/', component: Signin, name: "dang-nhap" },      
        { path: '/customer', component: Home, name: "STC-dien-tu" },      
    ]
})