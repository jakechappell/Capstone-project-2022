import Repository from "./Repository";

const resource = 'Endpoint';

export default {
    editEndpoint (data){
        return Repository.put(`${resource}`, data)
    },
    
    getById(id){
        return Repository.get(`${resource}\\` + id);
    }
}