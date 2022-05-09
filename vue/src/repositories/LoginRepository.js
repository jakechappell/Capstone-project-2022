import Repository from "./Repository";

const resource = 'Login';

export default{
    postLogin(data){
        return Repository.post(`${resource}`, data);
    },
    verifyJWT(){
        return Repository.get(`${resource}`);
    },
    logout(){
        return Repository.get(`${resource}\\logout`)
    }
}