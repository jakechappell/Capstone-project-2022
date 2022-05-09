import Repository from "./Repository";

const resource = 'Parameter';

export default {
    editParameter (data){
        return Repository.put(`${resource}`, data)
    }
}