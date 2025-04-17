import axios from 'axios'

const API_BASE_URL = "https://localhost:44307/api"

export const apiClient = axios.create({
    baseURL: API_BASE_URL,
    headers: {
        'Content-Type': 'application/json',
        'Accept': 'application/json'
    },
})
