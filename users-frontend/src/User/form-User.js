import React, { PureComponent } from 'react';
import { withRouter } from 'react-router-dom';
import { connect } from 'react-redux';
import Form from 'carbon-react/lib/components/form';
import Textbox from 'carbon-react/lib/components/textbox';
import { Row, Column } from 'carbon-react/lib/components/row';

const style={
    main:{
        paddingLeft: '30px',
        paddingTop: '30px'
    },
    form:{
        borderRightColor: '#191717',
        borderRight: '2px solid',
        paddingRight: '20px'
    }
}

class FormUser extends PureComponent {

    constructor(props) {
        super(props)
        this.state = {
            Change: false
        }
        this.onSubmitPessoa=this.onSubmitPessoa.bind(this)
        this.onCancelIsEdit=this.onCancelIsEdit.bind(this)
      }

      onSubmitPessoa(){
        const { history } = this.props;
        history.push("/");
      }

      onCancelIsEdit(){
        const { history } = this.props;
        history.push("/");
      }

      formUser() {
        return <Row columns="2">
            <Column>
                <Textbox label="Nome" name="name"  />
                <Textbox label="Emali" name="email"  />
                <Textbox label="WebSite" name="webSite" />
            </Column>
            <Column>
            </Column>
        </Row>
    }

    render(){
        return(
            <div style={ style.main }>
                <Row>
                    <h1>Cadastro de Usuários</h1>
                    <Form
                        buttonAlign="left"
                        cancelText="Voltar"
                        saveText="Salvar"
                        onSubmit={this.onSubmitPessoa}
                        onCancel={this.onCancelIsEdit}
                        style={ style.form }>
                        {this.formUser()}
                    </Form>
                </Row>
            </div>
        )
    }
}

export default (withRouter(FormUser));
