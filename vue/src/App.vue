<template>
  <div id="app" class="font-helvetica">
    <Navbar></Navbar>
    <div class="main-window">
      <router-view class="min-h-screen"/>
    </div>
      <Footer></Footer>
  </div>
</template>

<script>
import Navbar from "@/components/Navbar.vue"
import Footer from "@/components/Footer.vue"

export default {
  name: "App",
  components: {
    Navbar,
    Footer,
  }
};
</script>

<style lang="less" scoped>
@import "css/tailwind.css";
</style>
