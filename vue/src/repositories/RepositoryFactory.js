import CollectionRepository from "./CollectionRepository";
import DataLoaderRepository from "./DataLoaderRepository";
import EndpointRepository from "./EndpointRepository";
import FormDataRepository from "./FormDataRepository";
import LoginRepository from "./LoginRepository";
import ConsoleRepository from "./ConsoleRepository";
import ParameterRepository from "./ParameterRepository";
// import SessionRepository from "./SessionRepository";

const testing = process.env.NODE_ENV == "test";

const repositories = (() => {
    if(testing){
        return {
            collection: CollectionRepository,
            endpoint: EndpointRepository,
            formdata: FormDataRepository,
            login: LoginRepository,
            dataLoader: DataLoaderRepository,
            console: ConsoleRepository,
            parameter: ParameterRepository
            // session: SessionRepository
        }
    }
    else{
        return {
            collection: CollectionRepository,
            endpoint: EndpointRepository,
            formdata: FormDataRepository,
            login: LoginRepository,
            dataLoader: DataLoaderRepository,
            console: ConsoleRepository,
            parameter: ParameterRepository
            // session: SessionRepository
        }
    }
})();

export const RepositoryFactory = {
    get: name => repositories[name]
};