import React, { PureComponent } from 'react';
import { withRouter } from 'react-router-dom';
import { connect } from 'react-redux';
import { Row } from 'carbon-react/lib/components/row';
import { TableRow, TableHeader, Table, TableCell } from 'carbon-react/lib/components/table';
import Button from 'carbon-react/lib/components/button';
import Icon from 'carbon-react/lib/components/icon';
import { _ListUser, _DeleteUser } from './action-user';


function mapStateToProps(state) {
    const { list, error } = state.userreducer;
    return { list, error };
  }

  function mapDispatchToProps(dispatch) {
    return {
        onGetList: () => {
            const promise = _ListUser("http://localhost:5000/api/users/");
            dispatch(promise);
            return promise;
        },
        onDeleteItem: (id) => {
            const promise = _DeleteUser(`http://localhost:5000/api/users/${id}`);
            dispatch(promise);
            return promise;
        }
    }
  }

const style={
    main:{
        paddingLeft: '30px',
        paddingTop: '30px'
    },
    button_Style: {
        borderRadius: '20px',
        marginRight: '10px'
    },
    button_Style_2: {
        borderRadius: '20px'
    }
}

class User extends PureComponent {

    constructor(props) {
        super(props)
        this.state = {
            Users: [{ id: '', name: '', email: '', webSite: '' }]
        }
        this.onClickDelete=this.onClickDelete.bind(this)
        this.onClickEdit=this.onClickEdit.bind(this)
        this.onClickView=this.onClickView.bind(this)
      }

      onClickNew = () => {
        const { history } = this.props;
        history.push(`/user_form/new`);
    }

    onClickView = (id) => {
        const { history } = this.props;
        history.push(`/user_form/${id}`);
    }

    onClickEdit = (id) => {
        const { history } = this.props;
        history.push(`/user_form/${id}`);
    }

    onClickDelete = (id) => {
        const { onDeleteItem } = this.props
        onDeleteItem(id)
            .then((resp)=>{
                console.log(resp)
            })
    }

    componentDidMount(){
        const { onGetList } = this.props
        onGetList()
            .then(()=> {
                this.setState({...this.state, Users: this.props.list})
            })
    }

    buildRows = () => {
        let rows = [
            <TableRow key='header' as='header'>
                <TableHeader align='center'>
                    Nome
                </TableHeader>
                <TableHeader align='center'>
                    Email
                </TableHeader>
                <TableHeader align='center'>
                    WebSite
                </TableHeader>
                <TableHeader align='center'>
                    [Ações]
                </TableHeader>
            </TableRow>
        ];

        this.state.Users.forEach((row, index) => {
            rows.push(
                <TableRow key={index} uniqueID={`${index}`}>
                    <TableCell>{row.name}</TableCell>
                    <TableCell>{row.email}</TableCell>
                    <TableCell>{row.webSite}</TableCell>
                    <TableCell align='center'>
                        <Button style={ style.button_Style  } onClick={() => this.onClickView(row.id)}> <Icon type="view" /> </Button>
                        <Button style={ style.button_Style } onClick={() => this.onClickEdit(row.id)}> <Icon type="edit" /> </Button>
                        <Button style={ style.button_Style_2 } onClick={() => this.onClickDelete(row.id, row.nome)}> <Icon type="delete" /> </Button>
                    </TableCell>
                </TableRow>
            );
        });
        return rows;
    }

    render(){
        return(
            <div style={ style.main }>
                <Row>
                    <h1>Listagem de Usuários</h1>
                    <Table shrink={true}>
                        { this.buildRows() }
                    </Table>
                </Row>
            </div>
        )
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(withRouter(User));

