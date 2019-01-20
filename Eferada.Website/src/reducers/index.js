const initialState = { name: "" };

export default function reducer(state = initialState, action) {
  if (action.type == '"CHANGE_NAME"') {
    return { name: action.payload };
  }
  return state;
}
