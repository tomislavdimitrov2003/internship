import { shallow } from "enzyme";
import { shallowToJson } from "enzyme-to-json";
import React from 'react';
import RenderScoreboard from "../ScoreboardRenderer";


it('renders scoreboard correctly', () => {
    const rows = [['a', 50], ['b', 60]];
    const wrapper = shallow(<RenderScoreboard rows={rows}/>);
    expect(shallowToJson(wrapper)).toMatchSnapshot();
});

it('sort scoreboard by name correctly', () => {
    const rows = [['a', 50], ['b', 60]];
    const wrapper = shallow(<RenderScoreboard rows={rows}/>);
    wrapper.find('Score').simulate('click');
    expect(shallowToJson(wrapper)).toMatchSnapshot();
});

it('sort scoreboard by score correctly', () => {
    const rows = [['a', 50], ['b', 60]];
    const wrapper = shallow(<RenderScoreboard rows={rows}/>);
    wrapper.find('Score').simulate('click');
    expect(shallowToJson(wrapper)).toMatchSnapshot();
});