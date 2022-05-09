import { mount } from '@vue/test-utils';
import Login from "../../src/views/Login.vue";
import { expect } from 'chai';

describe("Login.vue", () => {
    const wrapper = mount(Login);
    it("login page exists", () => {
        expect(wrapper.exists()).to.be.true;
    })
    it("login is accepted from Cheetah", () => {
        const loginAccept = true;
        wrapper.setData({ loginForm: {username: 'AndrewS', password: 'BallState#Student@21'}, loginAccepted: true });
        wrapper.vm.loginUser();
        expect(wrapper.vm.loginAccepted).to.equal(loginAccept);
    })
})