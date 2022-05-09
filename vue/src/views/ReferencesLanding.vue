<template>
<div class="container text-center" style="margin: 0px; min-width: 100%">
    <div class="row">
        <div ref="sidebar" class="col-md-2 sidebar-container">
            <Sidebar></Sidebar>
        </div>  
        <div ref="main" class="col-md-10 text-left p-0">
            <div class="pl-8 pr-24 pt-10">
                <h1 class="text-6xl font-bold text-accuBlue">Cheetah API Documentation <span class="align-middle text-base bg-accuOrange w-21 px-2 py-1 text-center rounded-full font-light">v5.0.0</span></h1>
                <p class="text-xl text-gray-600">Conduct research and test the Cheetah API</p><br>
                <p>You can use the Cheetah API documentation featured on this site to discover all that Cheetah is capable of. Through 
                    different functionalities and overall usability of Cheetah, the app's API is extremely powerful and can be used to aquire
                    much information and knowledge. The Cheetah API docs allow users the capability of not only reading through the
                    aspects of each Cheetah API endpoint, but also the ability of testing each endpoint with live data to see what the endpoint
                    responds with.
                </p><br>
                <p>To begin with the Cheetah API docs, click a collection on the sidebar on the left side of the screen and pick an endpoint among that collection
                    that you would like to work with.
                </p><br>
                <p>
                    Unsure of where to start? Check out the "Get account information" endpoint featured 
                    <a class="text-accuOrange no-underline hover:text-accuOrange hover:underline" href="/references/1">here</a>. This endpoint
                    is a good place to start if you are unsure of where to go. Try testing the endpoint by filling in the "AccountNumber" parameter
                    with <em>00555</em> in the sandbox console section, labeled with "Try it out."
                </p><br>
                <p>
                    If you need more guidance on how to use the Cheetah API docs, check out the "Workflows" page by clicking
                    <a class="text-accuOrange no-underline hover:text-accuOrange hover:underline" href="/workflows">here</a>. This page
                    contains strategies for using this site as well as common workflows for using the Cheetah API.
                </p><br>
                <p>
                    For the sake of testing the API in an HTTP method testing software of your choice, the base path for the API
                    is <strong>https://ballstatetestingwebapi.accutech-systems.net</strong>
                </p><br>
            </div>
        </div>
    </div>
</div>
</template>

<script>
import Sidebar from "@/components/Sidebar.vue"

export default {
    components: {
    Sidebar,
  },
    data(){
        return {
            info: null,
            id: this.$route.params.id,
            loading: true,
            editsRecorded: []
        }
    }
}

</script>
    <style lang="less" scoped>
</style>