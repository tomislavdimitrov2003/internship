import { renderBoard } from "../BoardRender";
import { shallow } from "enzyme";
import { shallowToJson } from "enzyme-to-json";
import React from 'react';


it('reanders board correctly', () => {
    const board = [[0, 0, 0, 0],
                   [0, 0, 0, 0],
                   [0, 0, 0, 0],
                   [0, 0, 0, 0]];
    const score = 0;
    const message = "Test Message";               
    const wrapper = shallow(<renderBoard board={board} score={score} message={message}/>);
    expect(shallowToJson(wrapper)).toMatchSnapshot();
});