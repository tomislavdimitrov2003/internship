import { mount, shallow } from "enzyme";
import { mountToJson, shallowToJson } from "enzyme-to-json";
import React from 'react';
import RenderScoreboard from "../ScoreboardRenderer";


it('renders default scoreboard correctly', () => {
    const rows = [{name: 'a', score: 50}, {name: 'b', score: 60}];
    const wrapper = mount(<RenderScoreboard rows={rows}/>);
    expect(mountToJson(wrapper)).toMatchSnapshot();
});

it('sort scoreboard by name correctly', () => {
    const rows = [{name: 'a', score: 50}, {name: 'b', score: 60}];
    const wrapper = mount(<RenderScoreboard rows={rows}/>);
    wrapper.find('span.nameHead').simulate('click');
    expect(mountToJson(wrapper)).toMatchSnapshot();
});

it('sort scoreboard by score correctly', () => {
    const rows = [{name: 'a', score: 50}, {name: 'b', score: 60}];
    const wrapper = mount(<RenderScoreboard rows={rows}/>);
    wrapper.find('span.scoreHead').simulate('click');
    expect(mountToJson(wrapper)).toMatchSnapshot();
});