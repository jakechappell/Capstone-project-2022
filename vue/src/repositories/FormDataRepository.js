import Repository from "./Repository";

const resource = 'FormData';

export default{
    post(data){
        return Repository.post(`${resource}`, data);
    }
}