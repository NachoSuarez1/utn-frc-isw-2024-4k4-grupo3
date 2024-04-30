import axios from "axios";

const BASE_URL = "https://localhost:7131/";
const api = axios.create({
  baseURL: BASE_URL,
  headers: {
    "Content-Type": "application/json",
  },
});


const get = async (endpoint) => {
  try {
    const response = await api.get(endpoint);
    return response.data;
  } catch (error) {
    throw new Error("Error al obtener datos del servidor.");
  }
};

const put = async (endpoint, data) => {
  try {
    const response = await api.get(endpoint, data);
    return response.data;
  } catch (error) {
    throw new Error("Error al obtener datos del servidor.");
  }
};

export const quotesService = { get, put };
