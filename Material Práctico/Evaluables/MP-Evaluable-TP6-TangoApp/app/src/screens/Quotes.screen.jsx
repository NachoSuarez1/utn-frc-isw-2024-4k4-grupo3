import React, { useState, useEffect } from "react";
import { QuotesTable } from "../components";
import { colors } from "../config/colors";
import { useParams } from "react-router-dom";
import { quotesService } from "../services";

export const QuotesScreen = () => {
  const [quotes, setQuotes] = useState([]);
  const { orderId } = useParams();

  const getQuotes = async () => {
    try {
      const response = await quotesService.get(`/Get/${orderId}`);
      setQuotes(response);
    } catch (error) {
      console.error("Error al obtener las cotizaciones:", error);
    }
  };

  useEffect(() => {
    getQuotes();
  }, []); // Ejecutar una vez al montar el componente

  return (
    <div className="quotes">
      <h1 style={{ color: colors.oxfordBlue }}>Listado de Cotizaciones de Pedido #{orderId}</h1>
      <QuotesTable dataSource={quotes} orderId={orderId} />;
    </div>
  );
};
