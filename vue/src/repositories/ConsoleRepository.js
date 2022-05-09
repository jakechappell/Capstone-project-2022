import Repository from "./Repository";

const resource = 'Console';

export default{
    testEndpointNormal(data){
        return Repository.post(`${resource}`, data);
    },
    testEndpointDynamic(data){
        return Repository.post(`${resource}\\dynamic`, data);
    }
}