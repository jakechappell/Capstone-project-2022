import Repository from "./Repository";

const resource = 'Session';

export default{
    postToken(data){ //CHANGE POST -- FOR DELETE?
        return Repository.post(`${resource}`, data, action);
    },
    getToken(username){ //CHANGE GET -- TO GET TOKEN?
        return Repository.get(`${resource}`, username);
    }
}