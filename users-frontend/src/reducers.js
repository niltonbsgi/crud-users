import { combineReducers } from 'redux';
import UserReducer from '../src/User/reducer-user';

const rootReducer = combineReducers({
    userreducer: UserReducer
});

export default rootReducer;
