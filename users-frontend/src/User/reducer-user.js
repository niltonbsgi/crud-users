const INITIAL_STATE = {
    list: [],
    success: false,
    errorMessage: '',
    error : false
}

export default (state = INITIAL_STATE, action) => {
    switch(action.type) {
        case 'LIST_LOADED':
            return {
                ...state,
                list: action.payload.data,
                success: true,
                errorMessage: '',
                error: false }
        case 'DELETED':
            return {
                ...state,
                success: action.payload.data,
                errorMessage: '',
                error: false }
        case 'ERROR':
            return {
                ...state,
                success: false,
                errorMessage: '',
                error: true }
        default:
            return state
    }
};
