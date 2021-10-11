import { shallow } from "enzyme";
import { shallowToJson } from "enzyme-to-json";
import React from 'react';
import { Board } from "../BoardLogic";
import { DOWN, LEFT, N, RIGHT, UP } from "../KeyCodes";



describe("board tests", () => {
    beforeEach(() => {
        jest.spyOn(global.Math, 'random').mockReturnValue(0.22352352);
    });
    
    afterEach(() => {
        jest.spyOn(global.Math, 'random').mockRestore();
    });

    it('renders initial board correctly', () => {
        const wrapper = shallow(<Board/>);
        expect(shallowToJson(wrapper)).toMatchSnapshot();
    });

    it('re-renders initial board correctly', () => {
        const wrapper = shallow(<Board/>);
        wrapper.find("table").simulate('keydown', {keyCode: N});
        expect(shallowToJson(wrapper)).toMatchSnapshot();
    });

    it('moves board to the left correctly', () => {
        const wrapper = shallow(<Board/>);
        wrapper.find("table").simulate('keydown', {keyCode: LEFT});
        expect(shallowToJson(wrapper)).toMatchSnapshot();
    });

    it('moves board to the right correctly', () => {
        const wrapper = shallow(<Board/>);
        wrapper.find("table").simulate('keydown', {keyCode: RIGHT});
        expect(shallowToJson(wrapper)).toMatchSnapshot();
    });

    it('moves board up correctly', () => {
        const wrapper = shallow(<Board/>);
        wrapper.find("table").simulate('keydown', {keyCode: UP});
        expect(shallowToJson(wrapper)).toMatchSnapshot();
    });

    it('moves board down correctly', () => {
        const wrapper = shallow(<Board/>);
        wrapper.find("table").simulate('keydown', {keyCode: DOWN});
        expect(shallowToJson(wrapper)).toMatchSnapshot();
    });
});
