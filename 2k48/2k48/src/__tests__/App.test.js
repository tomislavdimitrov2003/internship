import { mount, shallow } from "enzyme";
import { mountToJson, shallowToJson } from "enzyme-to-json";
import React from 'react';
import { App } from "../App";

it('renders App correctly', () => {
    const wrapper = shallow(<App/>);
    expect(shallowToJson(wrapper)).toMatchSnapshot();
});
describe('resizes correctly', () => {
    it('resizes 4x4 board correctly', () => {
        const wrapper = mount(<App/>);
        wrapper.find('.resize4').simulate("click");
        expect(mountToJson(wrapper)).toMatchSnapshot();
    });

    it('resizes 5x5 board correctly', () => {
        const wrapper = mount(<App/>);
        wrapper.find('.resize5').simulate("click");
        expect(mountToJson(wrapper)).toMatchSnapshot();
    });

    it('resizes 6x6 board correctly', () => {
        const wrapper = mount(<App/>);
        wrapper.find('.resize6').simulate("click");
        expect(mountToJson(wrapper)).toMatchSnapshot();
    });
})


