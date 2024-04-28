import axios from 'axios';

const BASE_URL = 'http://localhost:4000/'; 


const api = axios.create({
  baseURL: BASE_URL,
  headers: {
    'Content-Type': 'application/json',
  },
});

const validateCard = async (endpoint, data) => {
  try {
    const response = await api.post(endpoint, data);
    return response.data;
  } catch (error) {
    throw new Error('Error al enviar datos al servidor.');
  }
};

export const cardService = { validateCard};