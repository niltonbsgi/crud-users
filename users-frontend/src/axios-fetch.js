import axios from 'axios';

export function axios_fetch(method, urlWithParams, body) {
    switch (method) {
        case 'PUT': {
            return (axios.put(urlWithParams, JSON.stringify(body)))
        }
        case 'POST': {
            return axios.post(urlWithParams,JSON.stringify(body))
        }
        case 'DELETE':
            return axios.delete(urlWithParams)
        default:
            return axios.get(urlWithParams)

    }
}
