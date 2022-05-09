<template>
    <div class="sidebar text-center h-full text-white bg-accuBlue bg-opacity-95 shadow-md">
        <ul class="list-unstyled min-h-screen">
            <h4 class="font-bold pt-2 text-center">Collections</h4>

            <div class="spinner-border loading justify-center" v-if="loading"></div>
            <div v-else v-for="collection in info" v-bind:key="collection.collectionId" class="">
                <p class="pl-2 mb-1 text-left" v-b-toggle="'endpointsAccord-' + collection.collectionName">{{ collection.collectionName }}
                    <b-icon
                      icon="chevron-down"
                      aria-hidden="true"
                    ></b-icon>
                    <i class="fas fa-caret-down"></i></p>
                <b-collapse :id="'endpointsAccord-' + collection.collectionName" accordian="endpointsAccord" 
                role="tabpanel" class="">
                    <ul class="sidebar-nav list-unstyled components break-words">
                    <li class="sidebar-item loaded" v-for="endpoint in collection.endpoints" v-bind:key="endpoint.endpointId">
                        <a class="sidebar-link flex p-2 m-0 text-white hover:text-black hover:bg-gray-700 no-underline text-sm"
                         :href="'/references/' + endpoint.endpointId">
                         <span v-if="endpoint.requests.length != 0 && endpoint.requests[0].type == 1" class="bg-blue-500 rounded mr-1 p-0.5 pt-0 pb-0 text-white font-bold h-5">GET</span>
                         <span v-else-if="endpoint.requests.length != 0 && endpoint.requests[0].type == 2" class="bg-green-500 rounded mr-1 p-0.5 pt-0 pb-0 text-white font-bold h-5">POST</span>
                         <span v-else-if="endpoint.requests.length != 0 && endpoint.requests[0].type == 3" class="bg-orange-500 rounded mr-1 p-0.5 pt-0 pb-0 text-white font-bold h-5">PUT</span>
                         <span v-else-if="endpoint.requests.length != 0 && endpoint.requests[0].type == 4" class="bg-red-500 rounded mr-1 p-0.5 pt-0 pb-0 text-white font-bold h-5">DELETE</span>
                         <span v-else class="bg-gray-500 rounded mr-1 p-0.5 pt-0 pb-0 text-white font-bold">?</span>
                         <span class="break-all">{{truncatedSuffix(endpoint.urlsuffix)}}</span></a>
                    </li>
                </ul>
                </b-collapse>
            </div>
        </ul>
    </div>
</template>

<script>
import { RepositoryFactory } from './../repositories/RepositoryFactory'
const CollectionRepository = RepositoryFactory.get('collection')

export default {
    data(){
        return {
            info: null,
            loading: true,
            expanded: false
        }
    },
    created() {
        this.fetch();
    },
    methods: {
        async fetch () {
            const { data } = await CollectionRepository.getSidebar();
            this.loading = false;
            this.info = data;
            console.log(this.info);
        },
        truncatedSuffix(suffix) {
            return suffix.replace('/api/v6', '');
        }
    }
}
</script>

<style lang="less" scoped>
</style>