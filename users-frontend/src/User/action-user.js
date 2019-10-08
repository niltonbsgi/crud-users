import { axios_fetch } from '../../src/axios-fetch';

export function _ListUser(url) {
    return (
        axios_fetch('', url)
        .then(
            (resp) => ({
                type: 'LIST_LOADED',
                payload: resp
            }),
            (err)=> ({
                type: 'ERROR',
                payload: err
            }))
        .catch( (err) => ({
            type: 'ERROR',
            payload: err
        }) )
    );
};


export function _DeleteUser(url) {
    return (
        axios_fetch('DELETE', url)
        .then(
            (resp) => ({
                type: 'DELETED',
                payload: resp
            }),
            (err)=> ({
                type: 'ERROR',
                payload: err
            }))
        .catch( (err) => ({
            type: 'ERROR',
            payload: err
        }) )
    );
};
