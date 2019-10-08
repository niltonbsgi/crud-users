import React from 'react';
import { BrowserRouter as Router, Route, Redirect, Switch } from 'react-router-dom';
import User from './User/User';
import FormUser from './User/form-User';
function Routes({ auth }) {
    return (
      <Router>
        <div>
          <Switch>
            <Route exact path='/user_table/' component={User} />
            <Route exact path='/user_form/:id' component={FormUser} />
            <Route exact path='/user_form/new' component={FormUser} />
            <Route path='/' component={User} />
          </Switch>
        </div>
      </Router>
    );
  }
  
  export default Routes;
