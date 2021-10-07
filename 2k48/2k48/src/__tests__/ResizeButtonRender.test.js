import { ResizeButtons } from "../ResizeButtonsRender"
import { shallow } from "enzyme";
import { shallowToJson } from "enzyme-to-json";
import React from 'react';


it('renders resize buttons correctly', () => {
    const wrapper = shallow(<ResizeButtons/>);
    expect(shallowToJson(wrapper)).toMatchSnapshot();
});