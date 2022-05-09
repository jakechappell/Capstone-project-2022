<template>
    <header>
      <nav id="top-nav" class="navbar navbar-light navbar-expand navigation-clean bg-accuBlue">
        <div class="container-fluid">
          <a class="navbar-brand" style="color:#FF800D" href="/"><img src="@/assets/accutech.png" style="width:30px;height:30px;display:inline;margin-bottom:4px;"/> Cheetah API Docs </a>
          <div id="links">
            <ul class="navbar-nav me-auto pr-5 space-x-2">
              <li class="nav-item">
                <a id="nav-link" v-if="$route.name=='Home' && this.dataLoading == false" style="border-color: transparent; box-shadow: none" class="btn text-end ms-auto" 
                role="button" @click="runDataLoader()">Run Data Loading</a>
                <div v-else-if="$route.name=='Home' && this.dataLoading == true" class="spinner-border mr-5 text-white" role="status"></div>
              </li>
              <li v-if="$route.name=='Home' && this.loggedIn == 'Not authenticated' || this.loggedIn == 'Accutech down'" class="nav-item">
                <a id="nav-link" style="border-color: transparent; box-shadow: none" class="btn text-end ms-auto accu-button" role="button" href="/login">Login</a>
              </li>
              <li class="nav-item">
                <a id="nav-link" style="border-color: transparent; box-shadow: none" class="btn text-end ms-auto" role="button" href="/">Home</a>
              </li>
              <li class="nav-item">
                <b-dropdown v-show="this.loggedIn !== 'Not authenticated' && this.loggedIn !== 'Accutech down'" id="nav-dropdown" right variant="link" class="nav-item" style="box-shadow: none;" toggle-class="text-white text-decoration-none">
                  <b-dropdown-group class="pl-4">Welcome, {{this.username}}!</b-dropdown-group>
                  <b-dropdown-divider></b-dropdown-divider>
                  <b-dropdown-item href="/references">References</b-dropdown-item>
                  <b-dropdown-divider></b-dropdown-divider>
                  <b-dropdown-item href="/workflows">Workflows/Tutorials</b-dropdown-item>
                  <b-dropdown-divider></b-dropdown-divider>
                  <b-dropdown-item @click="logoutUser()">Logout</b-dropdown-item>
                </b-dropdown>
              </li>
            </ul>
          </div>
        </div>
      </nav>
    </header>
</template>

<script>
import { RepositoryFactory } from './../repositories/RepositoryFactory'
const DataLoaderRepository = RepositoryFactory.get('dataLoader')
//const SessionRepository = RepositoryFactory.get('session')
export default {
    data(){
        return {
            loggedIn: "",
            dataLoading: false,
            username: "",
            dropdownToggled: false
        }
    },
    updated() {
        //this.loggedIn = JSON.parse(localStorage.getItem('loggedIn')); 
        this.loggedIn = window.$cookies.get("jwt");
        this.username = this.$cookies.get("username");
    },
    methods:{
      runDataLoader() {
        this.dataLoading = true;
        let loaderResponse = DataLoaderRepository.runDataLoader().then(()=>{
          this.dataLoading = false;
        });
        console.log(loaderResponse);
      },
      logoutUser() {
        window.$cookies.remove("jwt")
        //this.$cookies.set("loggedIn", response);
        this.$router.push('/login').then(()=>{
          this.$cookies.remove("username");
        })
      }
    }
}

</script>

<style lang="less" scoped>
#top-nav {
  a.navbar-brand {
    // color: black;
    font-family:"Segoe UI", Tahoma, Geneva, Verdana, sans-serif;
    font-weight: bold;
  }
  // background-color: #02204C !important;
  padding-bottom: 10px;
}

#links {
  #nav-link{
    background: rgba(0,123,255,0);;
    color: white;
  }
  #nav-link:hover{
    color: #FF800D;
  }
  font-family: "Segoe UI", Tahoma, Geneva, Verdana, sans-serif;
  font-weight: bold;
  padding-top: 0px;
  padding-bottom: 0px;
}

ul.dropdown-menu {
  background-color: lightgrey;
  border-color: #1266F1;
}
</style>