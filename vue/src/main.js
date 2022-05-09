import App from "./App.vue";
import { router } from "./router";
import Vue from "vue";
import { BootstrapVue, IconsPlugin } from 'bootstrap-vue'
import VueTailwind from 'vue-tailwind'
import VueCookies from 'vue-cookies'

// Import Bootstrap an BootstrapVue CSS files (order is important)
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'

import './css/sidebar.css'

import {
  TInput,
  TTextarea,
} from 'vue-tailwind/dist/components';

const settings = {
  't-input' : {
    componenet: TInput,
    props: {
      classes: 'border-2 block w-full rounded text-gray-800'
      // ...More settings
    }
  },
  't-textarea': {
    componenet: TTextarea,
    props: {
      classes: 'border-2 block w-full rounded text-gray-800'
      // ...More settings
    }
  }
}

Vue.use(BootstrapVue);
Vue.use(IconsPlugin);
Vue.use(VueTailwind, settings);
Vue.use(VueCookies);

Vue.config.productionTip = false;

new Vue({
  router,
  render: (h) => h(App)
}).$mount("#app");