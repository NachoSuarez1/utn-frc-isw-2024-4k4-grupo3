import React from "react";
import { Link } from "react-router-dom";
import { Table, Tag, Button, Modal } from "antd";
import { useState } from "react";
import { TableQuotes } from "../components";

export const CotizacionesScreen = () => {
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
    <div className="cotizaciones">
      <h1>Listado de Cotizaciones de Pedido #1234</h1>
      <TableQuotes dataSource={dataSource} />;
    </div>
  );
};
