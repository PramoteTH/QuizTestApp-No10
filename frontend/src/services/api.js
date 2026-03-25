import axios from 'axios'

const api = axios.create({
  baseURL: import.meta.env.VITE_API_URL ?? '/api'
})

export default {
  getItems() {
    return api.get('/test-all')
  },
  SubmitTest(data) {
    return api.post('/submit-test', data)
  }
}