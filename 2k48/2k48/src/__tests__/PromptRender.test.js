import Prompt from "../PromptRender";
import { shallow } from "enzyme";
import { shallowToJson } from "enzyme-to-json";
import React from 'react';

it('renders propmt correctly', () => {
    const wrapper = shallow(<Prompt finalScore={1000}/>);
    expect(shallowToJson(wrapper)).toMatchSnapshot();
});