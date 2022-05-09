import Vue from "vue";
import VueRouter from "vue-router";
//import { RepositoryFactory } from './../repositories/RepositoryFactory'
//const LoginRespository = RepositoryFactory.get('login')

Vue.use(VueRouter);

export const router = new VueRouter({
  routes: [
    {
      path: "/",
      name: "Home",
      component: () =>
        import("../views/Home.vue"),
    },
    {
      path: "/login",
      name: "Login",
      component: () =>
        import("../views/Login.vue"),
    },
    {
      path: "/references",
      name: "References",
      component: () =>
        import("../views/ReferencesLanding.vue")
    },
    {
      path: "/references/:id",
      name: "Reference",
      component: () =>
        import("../views/References.vue")
    },
    {
      path: "/workflows",
      name: "Workflows",
      component: () =>
        import("../views/Workflows.vue")
    }
  ],
  mode: 'history'
})

router.beforeEach((to, from, next) => {
  const publicPages = ['/', '/login'];
  const authRequired = !publicPages.includes(to.path);

  verifyLogin().then(() => {
  const loggedIn = window.$cookies.get("jwt");

  if (authRequired && loggedIn=="Not authenticated") {
        return next({
          path: '/login'
        })
      }
  if (to.path == '/login' && loggedIn!="Not authenticated" && loggedIn!="Accutech down") {
    return next({
       path: '/references'
    })
  }

  next();
})
});


  

async function verifyLogin(){
  if (!window.$cookies.isKey("jwt")){
    window.$cookies.set("jwt", "Not authenticated", "1h");
  }
}