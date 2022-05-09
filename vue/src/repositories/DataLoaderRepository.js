import Repository from "./Repository";

const resource = 'ApiJson';

export default{
    runDataLoader(){
        return Repository.get(`${resource}`);
    }
}