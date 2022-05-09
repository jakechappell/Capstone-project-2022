<template>
<div class="container text-center" style="margin: 0px; min-width: 100%">
    <div class="row">
        <div class="col-md-2 sidebar-container">
            <Sidebar></Sidebar>
        </div>
        <div id="references-page" class="col-md-10">
            <div class="spinner-border loading" v-if="loading"></div>
            <div v-else class="grid grid-cols-10">
                <div id="documentation" class="col-span-6 text-left py-4 px-9">
                    <div class="endpoint-container">
                        <h1 class="text-5xl"><strong id="endpoint-name" class="text-accuBlue">{{endpoint.endpointName}}</strong></h1>
                        <button id="edit-mode-button" v-if="editToggle==false" data-modal-toggle="large-modal" type="button"
                            class="align-top focus-within:self-start inline-block text-white bg-accuBlue 
                            hover:bg-opacity-90 focus:ring-4 focus:outline-none 
                            focus:ring-blue-300 font-medium rounded-lg text-sm 
                            px-3 py-1 text-center dark:bg-blue-600 dark:hover:bg-blue-700 mb-2
                            dark:focus:ring-blue-800" @click="activeColor='#FF800D'; editToggle=true; saveOriginalValues()">Edit <b-icon icon="pencil" aria-hidden="true"></b-icon>
                        </button>

                        <div v-if="editToggle==true">
                            <b-button-group>
                                <button id="save-edit" 
                                    class="align-top focus-within:self-start inline-block text-white bg-accuBlue 
                                    hover:bg-opacity-90 focus:ring-4 focus:outline-none 
                                    focus:ring-blue-300 font-medium rounded-lg text-sm 
                                    px-3 py-1 text-center dark:bg-blue-600 dark:hover:bg-blue-700 mb-2
                                    dark:focus:ring-blue-800" @click="saveEdit()"> Save All
                                    <b-icon icon="folder" aria-hidden="true"></b-icon>
                                </button>

                                <button id="cancel-edit" 
                                    class="align-top focus-within:self-center inline-block text-white bg-accuOrange 
                                    hover:bg-opacity-90 focus:ring-4 focus:outline-none 
                                    focus:ring-blue-300 font-medium rounded-lg text-sm
                                    px-3 py-1 text-center dark:bg-blue-600 dark:hover:bg-blue-700 mb-2
                                    dark:focus:ring-blue-800" @click="stopEdit()"> Cancel
                                    <b-icon icon="backspace-fill" aria-hidden="true"></b-icon> 
                                </button>

                                <button id="edit-overview" v-b-modal.PageEdits-modal 
                                    class="align-top focus-within:self-end inline-block text-white bg-black 
                                    hover:bg-opacity-90 focus:ring-4 focus:outline-none 
                                    focus:ring-blue-300 font-medium rounded-lg text-sm
                                    px-3 py-1 text-center dark:bg-blue-600 dark:hover:bg-blue-700 mb-2
                                    dark:focus:ring-blue-800" > Edit Overview
                                    <b-badge variant="light" style="color:black text-white">{{calcTotalEdits()}}</b-badge>
                                </button>
                            </b-button-group>

                            <b-modal id="PageEdits-modal" size="lg" hide-footer title="Pending Edits Overview" header-class="title-content-center">
                                <div>
                                    <div class="row">
                                        <button id="NoChanges" 
                                            class="col-md-3 align-top focus-within:self-start inline-block text-white bg-accuBlue 
                                            hover:bg-opacity-90 focus:ring-4 focus:outline-none 
                                            focus:ring-blue-300 font-medium rounded-lg text-sm 
                                            px-3 py-1 text-center dark:bg-blue-600 dark:hover:bg-blue-700 mb-2
                                            dark:focus:ring-blue-800"> No Changes
                                        </button>
                                        <p class="col">  <strong> # </strong> No Unsaved Edits</p>
                                    </div>
                                    <div class="row">
                                        <button id="YesChanges" 
                                            class="col-md-3 align-top focus-within:self-center inline-block text-white bg-accuOrange 
                                            hover:bg-opacity-90 focus:ring-4 focus:outline-none 
                                            focus:ring-blue-300 font-medium rounded-lg text-sm 
                                            px-3 py-1 text-center dark:bg-blue-600 dark:hover:bg-blue-700 mb-2
                                            dark:focus:ring-blue-800"> Pending Changes
                                        </button>
                                        <p class="col"> <strong> # </strong> Unsaved Changes </p>
                                        <p> Pressing the Save Locally Button when an edit is made will only save the edit locally.  </p>
                                        <p> To completely save your changes press the (Save All) button on the main page.</p>
                                    </div><br>
                                </div>

                                <div class="PendingEdits" role="tablist">

                                    <div id="editsTable" selectable>
                                        <div id="title-row" class="container">

                                            <h2><strong> Endpoint Description </strong></h2>
                                            <div class="endpoint-container row" v-for="request in endpoint.requests" v-bind:key="request.requestId">
                                                <b-card no-body class="mmb-1 px-0" >
                                                    <b-card-header header-tag="header" class="pendingEdits" role="tab" >
                                                        <div v-if="getOriginalEndpointDescription()==getPendingEndpointDescription()">
                                                            <button v-b-toggle.accordion-1 
                                                                class="w-full h-full align-top focus-within:self-start inline-block text-white bg-accuBlue 
                                                                hover:bg-opacity-90 focus:ring-4 focus:outline-none 
                                                                focus:ring-blue-300 font-medium rounded-lg text-lg 
                                                                px-3 py-1 text-center dark:bg-blue-600 dark:hover:bg-blue-700 mb-0
                                                                dark:focus:ring-blue-800 center-block"
                                                                ><strong>{{ endpoint.endpointName }} Description </strong>
                                                            </button>
                                                        </div>
                                                        <div v-else>
                                                            <button v-b-toggle.accordion-1 
                                                                class="w-full h-full align-top focus-within:self-start inline-block text-white bg-accuOrange 
                                                                hover:bg-opacity-90 focus:ring-4 focus:outline-none 
                                                                focus:ring-blue-300 font-medium rounded-lg text-lg 
                                                                px-3 py-1 text-center dark:bg-blue-600 dark:hover:bg-blue-700 mb-0
                                                                dark:focus:ring-blue-800 center-block"
                                                                > <strong>{{ endpoint.endpointName }} Description </strong>
                                                                <div> </div>
                                                            </button>
                                                        </div>
                                                    </b-card-header>
                                                    <b-collapse id="accordion-1" :accordion="'accordianDetails-'+endpoint.endpointName" role="tabpanel" >
                                                        <b-card-body>
                                                            <div id="editsTable1" >
                                                                <div id="title-row" class="container">

                                                                    <div class="row">
                                                                        <div class="col-md-5">
                                                                            <h5><strong> Current Save </strong></h5>
                                                                        </div>
                                                                        <div class="col-md-2"></div>
                                                                        <div class="col-md-5">
                                                                            <h5><strong> Pending Save </strong></h5>
                                                                        </div>
                                                                    </div>

                                                                    <div class="row">
                                                                        <div class="col-md-5"> 
                                                                            <b-card-text>{{getOriginalEndpointDescription()}}</b-card-text> 
                                                                        </div>

                                                                        <div class="col-md-2"></div>

                                                                        <div class="col-md-5" >
                                                                            <b-card-text>
                                                                                <div v-if="getOriginalEndpointDescription()==getPendingEndpointDescription()">{{ getPendingEndpointDescription() }}</div>
                                                                                <div v-else class="text-accuOrange" id="pend"><strong> {{ getPendingEndpointDescription() }} </strong></div>
                                                                            </b-card-text>
                                                                        </div>
                                            
                                                                    </div>
                                                                    <br><br><br><br>

                                                                    <div class="row">
                                                                        <div class="col-md-12">
                                                                            <b-input-group class="center-block">
                                                                                <b-button @click="undoEndpointDescriptionEdits()" variant="dark">Undo Changes</b-button>
                                                                                <b-button @click="changeOriginalLocalEndpointDescription()" variant="light">Save Locally</b-button>
                                                                            </b-input-group> 
                                                                        </div>
                                                                    </div>
                                                                    <br>
                                                                </div>
                                                            </div>
                                                            <br><br>
                                                        </b-card-body>
                                                    </b-collapse>
                                                </b-card>
                                            
                                                <div class=pendingParameterEdits>
                                                    <br><br><br>
                                                    <h2><strong> Pending Parameter Edits </strong></h2>
                                                    <div class="parameter-container row" v-for="(parameter, index) in request.parameters" v-bind:key="parameter.parameterId" >
                                                        
                                                        <b-card no-body class="mb-1 px-0 text-center bg-color:orange" :identifier="parameter.parameterId">
                                                            <b-card-header class="" header-tag="header" role="tab">

                                                                <div v-if="getPendingParameterDescription(parameter.parameterId) == getOriginalParameterDescription(parameter.parameterId)">
                                                                    <button v-b-toggle="'accordian-'+index"
                                                                        class="w-full h-full align-top focus-within:self-start inline-block text-white bg-accuBlue 
                                                                        hover:bg-opacity-90 focus:ring-4 focus:outline-none 
                                                                        focus:ring-blue-300 font-medium rounded-lg text-lg 
                                                                        px-3 py-1 text-center dark:bg-blue-600 dark:hover:bg-blue-700 mb-0
                                                                        dark:focus:ring-blue-800"> <strong> {{parameter.parameterName}} </strong>
                                                                    </button>
                                                                </div>

                                                                <div v-else>
                                                                    <button v-b-toggle="'accordian-'+index"
                                                                        class="w-full h-full align-top focus-within:self-start inline-block text-white bg-accuOrange 
                                                                        hover:bg-opacity-90 focus:ring-4 focus:outline-none 
                                                                        focus:ring-blue-300 font-medium rounded-lg text-lg 
                                                                        px-3 py-1 text-center dark:bg-blue-600 dark:hover:bg-blue-700 mb-0
                                                                        dark:focus:ring-blue-800"> <strong> {{parameter.parameterName}} </strong>
                                                                    </button>
                                                                </div>

                                                            </b-card-header>
                                                            <b-collapse :id="'accordian-'+index" 
                                                                :accordion="'accordianDetails-'+parameter" 
                                                                role="tabpanel"
                                                            >
                                                                <b-card-body>
                                                                    <b-card-text><h4><strong> Overview of {{parameter.parameterName}} Changes </strong></h4></b-card-text><br>

                                                                    <div id="editsTable" >
                                                                        <div id="title-row" class="container">
                                                                            <div class="row">
                                                                                <div class="col-md-5">
                                                                                    <h5><strong> Current Save </strong></h5>
                                                                                </div>
                                                                                <div class="col-md-2">

                                                                                </div>
                                                                                <div class="col-md-5">
                                                                                    <h5><strong> Pending Save </strong></h5>
                                                                                </div>
                                                                            </div>

                                                                            <div class="row">
                                                                                <div class="col-md-5"> 
                                                                                    <b-card-text :id="'saved-'+index"> {{ getOriginalParameterDescription(parameter.parameterId) }} </b-card-text>
                                                                                </div>
                                                                                <div class="col-md-2" v-bind:key="parameter.parameterId"> </div>
                                                                                <div class="col-md-5">
                                                                                    <b-card-text> 
                                                                                        <div v-if="getPendingParameterDescription(parameter.parameterId) == getOriginalParameterDescription(parameter.parameterId)">{{getPendingParameterDescription(parameter.parameterId)}}</div>
                                                                                        <div v-else class="text-accuOrange"><strong> {{ getPendingParameterDescription(parameter.parameterId) }} </strong></div>
                                                                                    </b-card-text>
                                                                                </div>
                                                                            </div>
                                                                            <div class="row">
                                                                                
                                                                            </div>

                                                                            <br><br><br><br>

                                                                            <div class="row">
                                                                                <div class="col-md-12">
                                                                                    <b-input-group class="center-block" :id="'button-group-'+index">
                                                                                        <b-button id="'undoButton-'+parameter.parameterId" @click="undoParameterChange(parameter.parameterId) " variant="dark"> Undo Changes </b-button> 
                                                                                        <b-button id="'saveButton-'+parameter.parameterId" @click="changeOriginalLocalParameter(parameter.parameterId, getPendingParameterDescription(parameter.parameterId))" variant="light"> Save Locally </b-button>
                                                                                    </b-input-group> 
                                                                                </div>
                                                                            </div><br>

                                                                        </div>
                                                                    </div><br><br>

                                                                </b-card-body>
                                                            </b-collapse>
                                                        </b-card>
                            
                                                    </div>
                                                </div>

                                            </div>

                                        </div>
                                    </div>

                                </div>
                                <br><br><br>

                            </b-modal>

                        </div>
                        <br>
                        <div class="endpoint-container" v-for="request in endpoint.requests" v-bind:key="request.requestId">
                            
                            <p v-if="endpoint.description != null" id="endpoint-description" :contenteditable="editToggle" @input="endpointInputChange(endpoint.description)" v-bind:style="{color:activeColor}">{{endpoint.description}}</p>
                            <p v-else id="endpoint-description" :contenteditable="editToggle" @input="endpointInputChange(pendingEndpointDescription(endpoint.description))" v-bind:style="{color:activeColor}">No description for endpoint</p>

                            <p v-if="endpoint.editDateTime != null" class="text-sm">(<em>Edited by {{endpoint.editUser}} at {{endpoint.editDateTime}}</em>)</p>
                            <br>
                            <h2 class="border-b border-black pb-3"><strong>Request</strong></h2>
                            <h4 class="pt-2"><span class="bg-blue-500 rounded mr-1 p-0.5 pt-0 pb-0 text-white font-bold no-underline" v-if="request.type == 1"> GET</span>
                            <span class="bg-green-500 rounded mr-1 p-0.5 pt-0 pb-0 text-white font-bold no-underline" v-if="request.type == 2"> POST</span>
                            <span style="background-color: orange" class="bg-orange-500 rounded mr-1 p-0.5 pt-0 pb-0 text-white font-bold no-underline" v-if="request.type == 3"> PUT</span>
                            <span class="bg-red-500 rounded mr-1 p-0.5 pt-0 pb-0 text-white font-bold no-underline" v-if="request.type == 4"> DELETE</span><span id="endpointUrl">{{endpoint.urlsuffix}}</span></h4>
                            <br>
                                <div v-if="request.parameters != null">
                                    <div v-for="parameter in request.parameters" v-bind:key="parameter.parameterId" class="pl-11">
                                        <p class=""><span class="ParameterName text-lg" :name="parameter.parameterId"><strong>{{parameter.parameterName}}</strong></span> <em>{{parameter.values}}</em> <sup v-if="parameter.required == true" class="text-red-500 font-bold">*required </sup></p>
                                        <p  :id="'ParameterDescription-'+parameter.parameterId" :key="parameter.parameterId"  :contenteditable="editToggle" @input="parameterInputChange(parameter.parameterId, pendingParameterDescription(parameter.parameterId) )" v-bind:style="{color:activeColor}" class="ParameterDescription pl-8">{{parameter.description}}</p>
                                        <p v-if="parameter.editDateTime != null" class="text-sm pl-8">(<em>Edited by {{parameter.editUser}} at {{parameter.editDateTime}}</em>)</p>
                                        <p v-if="parameter.parameterLocation == 1" class="pl-8">Located in path</p>
                                        <p v-if="parameter.parameterLocation == 2" class="pl-8">Located in query</p>
                                    </div>
                                </div>
                            <br>
                        </div>
                        <div v-if="endpoint.responses != null">
                            <h2 class="border-b border-black pb-3"><strong class="pr-4">Responses</strong>
                                <button id="statusCode" v-for="response in endpoint.responses" v-bind:key="response.responseId"
                                    class="text-base font-bold pr-4 hover:text-accuOrange" @click="getStatusCode($event)">{{response.statusCode}}
                                </button>
                            </h2>
                            <div v-for="response in endpoint.responses" v-bind:key="response.responseId">
                                <div v-if="response.statusCode == activeCode">
                                    <p><strong>{{activeCode}}</strong></p>
                                    <p class="pl-9" v-if="response.descript != null">{{response.description}}</p>
                                    <p class="pl-9" v-else>No description for response</p>
                                    <div class="pl-9">
                                        <pre v-if="activeCode == 400" class="rounded-md p-4 bg-gray-100 shadow-sm min-h-72 overflow-y-scroll">string</pre>
                                        <pre v-else-if="activeCode == 401" class="rounded-md p-4 bg-gray-100 shadow-sm min-h-72 overflow-y-scroll" v-text="{'type': 'string','title': 'string','status': 0,'detail': 'string','instance': 'string','additionalProp1': {},'additionalProp2': {},'additionalProp3': {}}"></pre>
                                        <pre v-else class="rounded-md p-4 bg-gray-100 shadow-sm min-h-72 overflow-y-scroll">{{responseSchema}}</pre>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="console-sandbox" class="col-span-4 pt-10 pr-6 text-left">
                    <h4 class="align-middle"><strong>Try It Out</strong></h4>
                    
                    <div class="text-center text-sm py-4 break-words">
                        <a v-if="this.fullEndpointUrl != null" id="endpointUrl" role="button" @click="copyEndpointUrl()" class="mb-0 text-black no-underline hover:underline">
                            <strong class="p-1 link-hover">{{this.fullEndpointUrl}}</strong>
                        </a><br>
                        <span ref="urlCopied" class="copiedAlert text-green-400 ml-2"><strong>URL copied to clipboard</strong></span>
                    </div>
                    <div v-for="request in endpoint.requests" v-bind:key="request.requestId">
                        <div v-if="request.type == 1">
                            <div class="pb-4 pt-0">
                                <div>
                                    <div v-for="request in endpoint.requests" v-bind:key="request.requestId" class="text-left">
                                        <div class="parameter-input-container align-middle" v-for="parameter in request.parameters" v-bind:key="parameter.parameterId">
                                            <label id="parameter-label" for="parameter-input" class="parameter-input-label">
                                                {{parameter.parameterName}} <sup v-if="parameter.required == true" class="text-red-500 font-bold">*required </sup><span class="text-gray-400"><em>{{parameter.values}}</em></span>
                                            </label>
                                            <br>
                                            <input :id="parameter.parameterName" type="text" placeholder="Enter a parameter value" class="border-2 parameter-input border-gray-700 rounded-lg p-1 w-full" @change="updateFullUrl"/>
                                            <br><br>
                                        </div>
                                    </div>
                                </div>
                                <button id="execute-button" data-modal-toggle="medium-modal" type="button" 
                                    class="align-top mr-5 text-white bg-accuBlue 
                                    hover:bg-opacity-90 focus:ring-4 focus:outline-none 
                                    focus:ring-blue-300 font-medium rounded-lg text-sm 
                                    w-full py-1.5 text-center dark:bg-blue-600 dark:hover:bg-blue-700 mb-4
                                    dark:focus:ring-blue-800" @click="consoleFunctionality()">Execute</button><br>
                                <div class="modal-body p-4 bg-gray-100 shadow-md rounded-md min-h-96 max-h-96 overflow-y-scroll text-left">
                                    <div class="spinner-border loading" v-if="sendingCall == true"></div>
                                    <pre id="console-response" class="block whitespace-pre-wrap mb-0">{{consoleResponse}}</pre>
                                </div>
                            </div>
                        </div>
                        <div v-else>
                            <p class="text-center text-lg">The sandbox console is not available for <span class="bg-green-500 rounded p-0.5 pt-0 pb-0 text-white font-bold no-underline">Post</span>,
                            <span style="background-color: orange" class="bg-orange-500 rounded p-0.5 pt-0 pb-0 text-white font-bold no-underline">Put</span>,
                            and <span class="bg-red-500 rounded p-0.5 pt-0 pb-0 text-white font-bold no-underline">Delete</span> Endpoints</p>
                            <p class="text-md">Try a <span class="bg-blue-500 rounded mr-1 p-0.5 pt-0 pb-0 text-white font-bold no-underline">GET</span>endpoint among this collection.
                            Or, click the URL above to copy and test the URL in an HTTP method testing software of your choice!
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
</template>

<script>
import Sidebar from "@/components/Sidebar.vue"
import { RepositoryFactory } from './../repositories/RepositoryFactory'
const EndpointRepository = RepositoryFactory.get('endpoint')
const ParameterRepository = RepositoryFactory.get('parameter')
const ConsoleRepository = RepositoryFactory.get('console')

export default {
    components: {
    Sidebar,
  },
    data(){
        return {
            endpoint: null,
            id: this.$route.params.id,
            loading: true,
            editToggle: false,
            activeEndpointId: this.$route.params.id,
            consoleMode: false,
            activeEndpointUrl: '',
            baseUrl: 'https://ballstatetestingwebapi.accutech-systems.net',
            baseEndpointUrl: '',
            fullEndpointUrl: '',
            activeParameters: [],
            responseSchema: '{\n\tResponse schema is null\n}',
            consoleResponse: '{\n\tResponse will show up here\n}',
            sendingCall: false,
            activeCode: 200,
            savedOriginal: true,
            originalEndpoint: [],
            originalItems: [],
            form: {
                endpointDescription: '',
                parameterDescription: '',
            },
            activeColor: 'black',
        }
    },
    created() {
        this.fetch().then(() => {
            this.fillUrl();
        })
    },
    methods: {
        async fetch () {
            if(this.id != null){
                const { data } = await EndpointRepository.getById(this.id);
                this.loading = false;
                this.endpoint = data;
            }
            else{
                const { data } = await EndpointRepository.get();
                this.loading = false;
                this.endpoint = data;
            }
        },

        fillUrl() {
            this.baseEndpointUrl = this.baseUrl + this.endpoint.urlsuffix;
            this.fullEndpointUrl = this.baseEndpointUrl;
        },

        getStatusCode(event){
            this.activeCode = event.target.innerHTML;
        },

        closeConsole() {
            this.consoleMode = false;
            this.consoleResponse = '{\n\tResponse will show up here\n}';
        },

        updateFullUrl() {
            let params = [];
            let elements = document.getElementsByClassName('parameter-input');
            for (let i = 0; i < elements.length; i++){
                console.log(elements[i].value)
                let element = elements[i];
                let paramObj = {
                    paramName: element.id,
                    paramValue: element.value
                }
                if (paramObj.paramValue != '')
                    params.push(paramObj);
            }
            console.log(params);

            this.fullEndpointUrl = this.baseEndpointUrl;
            if(this.fullEndpointUrl.indexOf("{") > -1){
                // TODO: fix URL building with dynamic URLs
                // var originalUrl = this.fullEndpointUrl.substring(this.fullEndpointUrl.indexOf("{"), this.fullEndpointUrl.indexOf("}") + 1);
                // var substitutionOne = originalUrl.replace("{", "")
                // var substitutionTwo = substitutionOne.replace("}", "")
                // this.fullEndpointUrl = this.fullEndpointUrl.replace(originalUrl, params[substitutionTwo].paramValue)
                // params.splice(substitutionTwo, 2)
            }
            else{
                for (let i = 0; i < params.length; i++) {
                    if (i == 0) {
                        this.fullEndpointUrl = this.fullEndpointUrl + '?' + params[i].paramName + '=' + params[i].paramValue;
                    }
                    else {
                        this.fullEndpointUrl = this.fullEndpointUrl + '&' + params[i].paramName + '=' + params[i].paramValue;
                    }
                }
            }
        },

        copyEndpointUrl() {
            navigator.clipboard.writeText(this.fullEndpointUrl);
            if (this.$refs.urlCopied.classList.contains("fadeOut"))
                this.$refs.urlCopied.classList.toggle("fadeOut");
            this.$refs.urlCopied.classList.toggle("fadeIn");
            setTimeout(() => {
                this.$refs.urlCopied.classList.toggle("fadeOut");
                this.$refs.urlCopied.classList.toggle("fadeIn");
            }, 2000);
        },

        async consoleFunctionality() {
            this.activeEndpointUrl = document.getElementById("endpointUrl").innerHTML;
            this.consoleResponse = null;
            this.sendingCall = true;

            let elements = document.getElementsByClassName('parameter-input');
            var passingDict = []
            for (let i = 0; i < elements.length; i++){
                console.log(elements[i].value)
                var element = elements[i];
                var key = element.id
                var value = element.value
                this.activeParameters[key] = value
                passingDict.push({
                    Key: key,
                    Value: value
                })
            }
            if (this.activeEndpointUrl.indexOf("{") > -1){
                var curlysub = this.activeEndpointUrl.substring(this.activeEndpointUrl.indexOf("{"), this.activeEndpointUrl.indexOf("}") + 1);
                var firstcurlysub = curlysub.replace("{", "")
                var secondcurlysub = firstcurlysub.replace("}", "")
                this.activeEndpointUrl = this.activeEndpointUrl.replace(curlysub, this.activeParameters[secondcurlysub])
                passingDict.splice(secondcurlysub, 2)
            }
            let c = {
                activeEndpointUrl: this.activeEndpointUrl,
                activeEndpointParameters: passingDict,
                jwt: window.$cookies.get("jwt")
            }
            console.log(c)
            
            if (!this.testUrl(this.activeEndpointUrl)){
                await ConsoleRepository.testEndpointNormal(c).then((response)=>{
                    this.sendingCall = false;
                    this.consoleResponse = JSON.stringify(response.data, undefined, 2);
                    console.log(response.data);
                })
            }
            else{
                console.log("here")
                await ConsoleRepository.testEndpointDynamic(c).then((response)=>{
                    console.log(response);
                    this.sendingCall = false
                    this.consoleResponse = JSON.stringify(response.data, undefined, 2);
                }).then(()=>{
                    if (this.consoleResponse == JSON.stringify("Retry...")){
                        this.sendingCall = true
                        try{
                            this.tryagain(c)
                        }
                        catch(error){
                            console.log(error)
                            this.consoleResponse = "Endpoint unavailable"
                        }
                    }
                })
            }
            
            
            console.log("activeParameters keys: " + Object.keys(this.activeParameters));
            console.log("activeParameters values: " + Object.values(this.activeParameters));
        },

        async tryagain(obj){
            this.consoleResponse = null
            await ConsoleRepository.testEndpointNormal(obj).then((response)=>{
                this.sendingCall = false;
                this.consoleResponse = JSON.stringify(response.data, undefined, 2);
            })
        },

        testUrl(str){
            return /\d/.test(str.split("/")[4])
        },

        async saveEdit() {
            var descriptions = [] 
            var names = []

            for(let description of document.getElementsByClassName("ParameterDescription")){
                descriptions.push(description.innerHTML)
            }

            for(let name of document.getElementsByClassName("ParameterName")){
                names.push(name.getAttribute("name"))
            }

            console.log(descriptions)
            var pDict = []
            for(let i = 0; i < descriptions.length; i++){
                var key = names[i];
                var value = descriptions[i];
                pDict.push({
                    Key: key,
                    Value: value
                })
            }

            let d = {
                endpointId: this.activeEndpointId,
                description: document.getElementById("endpoint-description").innerHTML,
                editUser: window.$cookies.get("username")
            }
            let x = {
                parameterEdits: Object.values(pDict),
                editUser: window.$cookies.get("username"),
            }
            await EndpointRepository.editEndpoint(d).then(()=>{
                console.log(d)
                if (pDict != []){
                    ParameterRepository.editParameter(x)
                }
            }).then(()=>{
                console.log(Object.values(pDict))
            })
            this.stopEdit()
        },


        stopEdit() {
            this.editToggle=false
            this.activeColor='black'
            location.reload()
        },

        saveOriginalValues(){
            if (this.savedOriginal == true){
                this.savedOriginal = false
                var endpointDescription = document.getElementById("endpoint-description").innerHTML
                this.originalEndpoint.push({
                    Key: "endpoint-description",
                    Value: endpointDescription,
                    Pending: endpointDescription
                })
                console.log(this.originalEndpoint)

                var descriptions = []
                var names = []
                for(let description of document.getElementsByClassName("ParameterDescription")){
                    descriptions.push(description.innerHTML)
                }
                for(let name of document.getElementsByClassName("ParameterName")){
                    names.push(name.getAttribute("name"))
                }
                for(let i = 0; i < descriptions.length; i++){
                    var key = names[i];
                    var value = descriptions[i];
                    this.originalItems.push({
                        Key: key,
                        Value: value,
                        Pending: value,
                    })
                }
                console.log(this.originalItems)
            }
        },

        pendingEndpointDescription(){
            let ed = document.getElementById("endpoint-description").innerHTML
            return ed
        },

        pendingParameterDescription(paramID){
            var descriptions = [] 
            var names = []

            for(let description of document.getElementsByClassName("ParameterDescription")){
                descriptions.push(description.innerHTML)
            }

            for(let name of document.getElementsByClassName("ParameterName")){
                names.push(name.getAttribute("name"))
            }

            var val
            for(let i = 0; i < descriptions.length; i++){
                var key = names[i];
                var value = descriptions[i];
                if(key==paramID){
                    val = value
                }
            }
            return val
        },



        endpointInputChange(description){
            var val = this.originalEndpoint[0].Pending = description
            console.log(val)
        },

        undoEndpointDescriptionEdits(){
            var value = this.originalEndpoint[0].Pending = this.originalEndpoint[0].Value
            document.getElementById('endpoint-description').innerHTML = value
        },

        changeOriginalLocalEndpointDescription(){
            var value = this.originalEndpoint[0].Value = this.originalEndpoint[0].Pending
            document.getElementById('endpoint-description').innerHTML = value
        },

        getOriginalEndpointDescription(){
            console.log(this.originalEndpoint[0].Value)
            return this.originalEndpoint[0].Value
        },

        getPendingEndpointDescription(){
            console.log(this.originalEndpoint[0].Pending)
            return this.originalEndpoint[0].Pending
        },



        parameterInputChange(paramId, description){
            for(let i = 0; i < this.originalItems.length; i++){
                if (this.originalItems[i].Key == paramId){
                    var val = this.originalItems[i].Pending = description
                    console.log(val)
                }
            }
        },

        undoParameterChange(paramId){
            for(let i = 0, len = this.originalItems.length; i < len; i++){
                if (this.originalItems[i].Key == paramId){
                    var value = this.originalItems[i].Pending = this.originalItems[i].Value
                    document.getElementById('ParameterDescription-'+paramId).innerHTML = value
                    break
                }
            }
        },

        changeOriginalLocalParameter(paramId, description){
            for(let i = 0; i < this.originalItems.length; i++){
                if (this.originalItems[i].Key == paramId){
                    var val = this.originalItems[i].Value = description
                    console.log(val)
                }
            }
        },

        getOriginalParameterDescription(paramId){
            for(let i = 0; i < this.originalItems.length; i++){
                if (this.originalItems[i].Key == paramId){
                    var val = this.originalItems[i].Value
                    return val
                }
            }
        },

        getPendingParameterDescription(paramId){
            for(let i = 0; i < this.originalItems.length; i++){
                if (this.originalItems[i].Key == paramId){
                    var val = this.originalItems[i].Pending
                    return val
                }
            }
        },

        calcTotalEdits(){
            var editsTotal = 0
            if (this.originalEndpoint[0].Value != this.originalEndpoint[0].Pending){
                editsTotal = editsTotal + 1
            }
            for(let i = 0; i < this.originalItems.length; i++){
                if (this.originalItems[i].Value != this.originalItems[i].Pending){
                    editsTotal = editsTotal + 1
                }
            }
            return editsTotal
        }
    }
}
  

</script>

<style lang="less" scoped>
#references-page{
    padding: 0px;
    
}

#references-page-title{
    h1{
        text-decoration: underline;
    }
}

#response-parsing{
    text-align: left;
    #documentation{
        padding-left: 30px;
    }
    .row{
        text-align: center;
    }
    #title-row{
        text-align: center;
    }
    #row-one{
        text-align: center;
    }
    #row-two{
        text-align: center;
    }
}

#editsTable{
    text-align: center;
    border: true;
    
}

#documentation{
    a {
        text-decoration: none;
        color: black;
    }
}

.bold-hover:hover {
    font-weight: bold;
}

#object-hyperlinks{
    text-align: left;
}

.center-block{
    display: table;
    margin-left: auto;
    margin-right: auto;
}

.loading{
    margin-top: 10px;
}

.link-hover:hover {
    text-decoration: underline;
}

.copiedAlert {
    opacity: 0;
}

.fadeOut {
  visibility: hidden;
  opacity: 0;
  transition: visibility 0s linear 1000ms, opacity 1000ms;
}

.fadeIn {
  visibility: visible;
  opacity: 1;
  transition: visibility 0s linear 0s, opacity 300ms;
}

</style>
