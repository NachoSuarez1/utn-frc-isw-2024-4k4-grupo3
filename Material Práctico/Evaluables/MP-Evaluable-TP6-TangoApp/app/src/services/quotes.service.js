import axios from "axios";

const BASE_URL = "http://localhost:4000/";
const endpoint = "quotes";
const api = axios.create({
  baseURL: BASE_URL,
  headers: {
    "Content-Type": "application/json",
  },
});

const get = async (filters) => {
  try {
    const response = await api.get({ params: filters });
    return response.data;
  } catch (error) {
    throw new Error("Error al obtener datos del servidor.");
  }
};

const put = async (data) => {
  try {
    const response = await api.get(data);
    return response.data;
  } catch (error) {
    throw new Error("Error al obtener datos del servidor.");
  }
};

export const quotesService = { get, put };
