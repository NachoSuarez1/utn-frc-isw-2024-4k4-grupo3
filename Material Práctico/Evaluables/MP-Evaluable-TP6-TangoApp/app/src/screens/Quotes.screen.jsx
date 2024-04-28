import React from "react";
import { useState, useEffect } from "react";
import { QuotesTable } from "../components";
import { colors } from "../config/colors";
import { useParams } from "react-router-dom";
import { quotesService } from "../services";

export const QuotesScreen = () => {
  const [quotes, setQuotes] = useState([]);
  const { orderId } = useParams();

  const dataSource = [
    {
      key: "1",
      transport_name: "Mike",
      qualification: 1,
      pick_up_date: "28/04/2024",
      delivery_date: "28/04/2024",
      amount: 1000,
      payment_options: ["Contado al retirar", "Tarjeta"],
      state: "Pendiente",
    },
    {
      key: "2",
      transport_name: "John",
      qualification: 5,
      pick_up_date: "28/04/2024",
      delivery_date: "28/04/2024",
      amount: 2000,
      payment_options: ["Contado contra entrega", "Tarjeta"],
      state: "Pendiente",
    },
  ];

  const getQuotes = async () => {
    try {
      // const response = await quotesService.get("quotes", { orderId });
      // const data = await response.json();
      setQuotes(dataSource);
    } catch (error) {
      console.error("Error al obtener las cotizaciones:", error);
    }
  };

  useEffect(() => {
    getQuotes();
  }, []);

  return (
    <div className="quotes">
      <h1 style={{ color: colors.oxfordBlue }}>Listado de Cotizaciones de Pedido #{orderId}</h1>
      <QuotesTable dataSource={quotes} orderId={orderId} />;
    </div>
  );
};
