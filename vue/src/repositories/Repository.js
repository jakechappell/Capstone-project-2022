import axios from 'axios';

const baseDomain = "http://localhost:5000/api";
const baseURL = `${baseDomain}`;

export default axios.create({
    baseURL
});