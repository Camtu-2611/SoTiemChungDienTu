<template>
  <div class="component-wrapper">
    <EvaluateList
      :isShow="!isShowDetail"
      v-show="!isShowDetail"
      @toggleShowDetail="toggleShowDetail"
    />
    <EvaluateDetail
      v-show="isShowDetail"
      @toggleShowDetail="toggleShowDetail"
    />
  </div>
</template>

<script>
import EvaluateList from "@/views/evaluate/component/EvaluateList.vue";
import EvaluateDetail from "@/views/evaluate/component/EvaluateDetail.vue";
import { mapState } from "vuex";
export default {
  components: {
    EvaluateList,
    EvaluateDetail,
  },
  data() {
    return {
      isShowDetail: false,
    };
  },
  created() {
    this.$store.dispatch("evaluate/getReports");
    this.$store.dispatch("evaluate/getAssets");
  },
  computed: {
    ...mapState({
      evaluateState: (state) => state.evaluate.evaluateState,
      evaluateReports: (state) => state.evaluate.evaluateReports,
    }),
  },
  methods: {
    toggleShowDetail() {
      this.isShowDetail = !this.isShowDetail;
    },
  },
};
</script>

<style lang='scss' scoped>
@import "@/style/_variables.scss";

.component-wrapper {
  width: 100%;
  height: 100%;
}
</style>