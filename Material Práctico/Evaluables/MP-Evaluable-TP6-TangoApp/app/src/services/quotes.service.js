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
    console.log(response);
    return response.data;
  } catch (error) {
    throw new Error("Error al obtener datos del servidor.");
  }
};

const put = async (endpoint, values) => {
  try {
    const response = await api.put(endpoint, values);
    return response.data;
  } catch (error) {
    console.log(error.response.data)
    throw new Error(error.response.data);
  }
};

export const quotesService = { get, put };
