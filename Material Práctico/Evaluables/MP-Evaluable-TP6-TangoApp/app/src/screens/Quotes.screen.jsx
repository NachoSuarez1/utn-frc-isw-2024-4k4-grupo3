import React from "react";
import { useState } from "react";
import { TableQuotes } from "../components";
import { colors } from "../config/colors";

export const QuotesScreen = () => {
  const [quotes, setQuotes] = useState([]);

  const dataSource = [
    {
      key: "1",
      transport_name: "Mike",
      qualification: 1,
      pick_up_date: "28/04/2024",
      delivery_date: "28/04/2024",
      amount: 1000,
      payment_options: ["Contado al retirar", "Tarjeta"],
      state: "Confirmada",
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

  return (
    <div className="quotes">
      <h1 style={{ color: colors.oxfordBlue }}>Listado de Cotizaciones de Pedido #1234</h1>
      <TableQuotes dataSource={dataSource} />;
    </div>
  );
};
