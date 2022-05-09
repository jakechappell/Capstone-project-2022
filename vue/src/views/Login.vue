<template>
    <div id="login-page" class="text-center flex justify-center">
        <div id="medium-modal" tabindex="-1" class="flex items-center justify-center align-middle pb-10 overflow-y-auto overflow-x-hidden right-0 left-0 w-full min-h-screen md:inset-0 h-modal md:h-full">
            <div class="relative p-4 w-full max-w-2xl h-full md:h-auto">
                <!-- Modal content -->
                <div class="relative bg-gray-100 rounded-lg shadow border border-gray-400 dark:bg-gray-700">
                    <img src="@/assets/accutech.png" class="w-9 h-9 inline mb-1 mt-4"/>
                    <!-- Modal body -->
                    <div class="px-36 pb-14 pt-10 space-y-6">
                        <h1 class="text-center text-2xl">Sign in with Accutech</h1>
                        <input type="text" placeholder="Username" v-model="loginForm.username" ref="Username" id="Username" name="Username" class="border-1 parameter-input border-gray-700 rounded-lg px-3 py-3 w-full"/>
                        <input type="password" placeholder="Password" v-model="loginForm.password" ref="Password" id="Password" name="Password" class="border-1 parameter-input border-gray-700 rounded-lg px-3 py-3 w-full"/>
                        <div id="gain-access-btn" class="items-center pt-4">
                            <button class="align-top mr-5 text-white bg-accuBlue 
                                hover:bg-opacity-90 focus:ring-4 focus:outline-none 
                                focus:ring-blue-300 font-medium rounded-full text-sm 
                                w-full py-1.5 text-center dark:bg-blue-600 dark:hover:bg-blue-700
                                dark:focus:ring-blue-800" v-if="this.posting == false" @click="loginUser();">Gain Access</button>
                            <div class="spinner-border loading" v-if="this.posting == true"></div>
                        </div>
                        <br><span id="errorMessage" class="text-red-500" v-if="this.loginAccepted=='Not authenticated'">Error: Login failed. Check username and password.</span>
                        <br><span id="errorMessage" class="text-red-500" v-if="this.loginAccepted=='Accutech down'">Error: Unable to communicate with Accutech Servers. Please try again later</span>

                        <p class="text-sm text-left pb-4 pt-9">Want access to the documentation? <a v-b-modal.modal-1 class="text-blue-600 no-underline hover:underline">Request Access</a></p>
                    </div>
                </div>
            </div>
        </div>
        <b-modal id="modal-1" title="Request Access Form">
            <form v-on:submit.prevent="printForm">
                <div class="requestModalLeft">
                    <div class="form-group">   
                        <label for="firstNameInput" class="form-label mt-4" >First Name</label>
                        <input type="text" class="form-control" name="firstName" id="firstNameInput" v-model="form.firstName" placeholder="Enter your first name" required>
                    </div>
                    <div class="form-group"> 
                        <label for="emailInput" class="form-label mt-4">Email Address</label>
                        <input type="email" class="form-control" name="emailAddress" id="emailInput" v-model="form.emailAddress" placeholder="example@email.com" required>
                    </div>
                </div>
                <div class="requestModalRight">
                    <div class="form-group"> 
                        <label for="lastNameInput" class="form-label mt-4">Last Name</label>
                        <input type="text" class="form-control" name="lastName" id="lastNameInput" v-model="form.lastName" placeholder="Enter your last name" required>
                    </div>
                    <div class="form-group"> 
                        <label for="companyInput" class="form-label mt-4">Company Name</label>
                        <input type="text" class="form-control" name="company" id="companyInput" v-model="form.companyName" placeholder="Enter your company's name" required>
                    </div>
                </div>

                <div>
                    <label for="occupationRadioGroup" class="form-label mt-4">Occupation</label>
                    <div id="occupationRadioGroup" class="form-group">
                        <div class="requestModalLeft">
                            <input type="radio" id="dev" name="occupation" v-model="form.occupation" value="Developer" checked="checked">
                            <label for="dev">&#160;Developer</label>
                        </div>
                        <div class="requestModalRight">
                            <input type="radio" id="projMan" name="occupation" v-model="form.occupation" value="Project Manager">
                            <label for="projMan">&#160;Project Manager</label>
                        </div>
                        
                        <br>

                        <div class="requestModalLeft">
                            <input type="radio" id="softEng" name="occupation" v-model="form.occupation" value="Software Engineer">
                            <label for="softEng">&#160;Software Engineer</label>
                        </div>
                        <div class="requestModalRight">
                            <input type="radio" id="busiAnalyst" name="occupation" v-model="form.occupation" value="Business Analyst">
                            <label for="busiAnalyst">&#160;Business Analyst</label>
                        </div>
                    </div>
                </div>

                <br>

                <div class="form-group">
                    <label  for="reasonInput" class="form-label mt-4" >Reason for Access Request</label>
                    <br>
                    <textarea rows = "3" cols = "60" name="reason" id="reasonInput" v-model="form.reason" placeholder="Enter your reason for requesting access" required></textarea>
                </div>
            </form>
            <div slot="modal-footer" class="form-group">
                    <b-btn variant="primary" v-if="!sending" v-on:click="printForm">Submit Form</b-btn>
            </div>
        </b-modal>
    </div>
</template>

<script>
import { RepositoryFactory } from './../repositories/RepositoryFactory'
//const SessionRepository = RepositoryFactory.get('session')
const FormDataRepository = RepositoryFactory.get('formdata')
const LoginRespository = RepositoryFactory.get('login')

export default{
    name: 'PostFormAxios',
    data(){
        return{
            form: {
                firstName: '',
                lastName: '',
                companyName: '',
                emailAddress: '',
                occupation: '',
                reason: ''
            },
            loginForm: {
                username: '',
                password: '',
                token: ''
            },
            headers: {
                 "Content-Type": "application/json",
            },
            sending: false,
            posting: false,
            response: null,
            loginResponse: null,
            loginAccepted: null
        }
    },
    methods:{
        printForm(){
            this.sending = true;
            this.response = FormDataRepository.post({
                firstName: this.form.firstName,
                lastName: this.form.lastName,
                companyName: this.form.companyName,
                emailAddress: this.form.emailAddress,
                occupation: this.form.occupation,
                reason: this.form.reason
            });
        },
        loginUser() {
            this.posting = true;
            this.loginResponse = LoginRespository.postLogin({
                username: this.loginForm.username,
                password: this.loginForm.password
            }).then((response)=>{
                this.loginAccepted = response.data; 
                //localStorage.setItem("username", this.loginForm.username);
                window.$cookies.set("username", this.loginForm.username);
                window.$cookies.set("jwt", this.loginAccepted, "1h");
                // console.log("Login accept : " + this.loginAccepted);
                }).then(()=>{
                    if (this.loginAccepted!="Not authenticated" && this.loginAccepted!="Accutech down")
                    {
                        this.$router.push('/references');
                    }   
                }).then(() => {
                    this.posting = false;
                })
            console.log(this.loginResponse);
        },
        backdoor() {
            this.loginForm.username = 'AndrewS';
            this.loginForm.password = 'BallState#Student@21';
            this.loginUser();
        }
    },
    watch:{
        response(){
            this.sending = false;
            this.$bvModal.hide('modal-1')
        }
    }
}
</script>

<style lang="less" scoped>
h1 {
    font-weight: bold;
}
h3 {
    text-decoration: underline;
}

#gain-access-btn {
    a {
        background-color: #d3d3d3;
        color: black;
    }
}

#request-access-btn {
    a {
        background-color: #d3d3d3;
        color: black;
    }
}

.form-control {
    border-width: 2px;
}

.col-md-6{
    h1{
        height: 44px;
    }
}

.requestModalLeft{
    float: left;

}

.requestModalRight{
    float: right;

}

.occupationRadioGroup {
    margin: auto;
}

::-webkit-input-placeholder{
    font-size: 14px;
}
</style>