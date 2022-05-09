import Repository from "./Repository";

const resource = 'Collection';

export default{
    get(){
        return Repository.get(`${resource}`);
    },

    getSidebar(){
        return Repository.get(`${resource}\\sidebar`);
    },

    getById(id){
        return Repository.get(`${resource}\\` + id);
    }
}