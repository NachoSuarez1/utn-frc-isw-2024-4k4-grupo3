import React from "react";
import { Link } from "react-router-dom";
import { Table, Tag, Button, Rate } from "antd";
import { useState } from "react";
import { colors } from "../../config/colors";
import "../css/QuotesTable.css";

export const QuotesTable = (props) => {
  const isQuoteConfirmed = props.dataSource.find((quote) => quote.state === "Confirmada");

  const columns = [
    {
      title: "Transportista",
      dataIndex: "transport",
      key: "transport",
    },
    {
      title: "Calificación",
      dataIndex: "qualification",
      key: "qualification",
      render: (qualification) => (
        <Rate disabled defaultValue={qualification} style={{ color: colors.honeydew }} />
      ),
    },
    {
      title: "Fecha de Retiro",
      dataIndex: "pickUpDate",
      key: "pickUpDate",
    },
    {
      title: "Fecha de Entrega",
      dataIndex: "deliveryDate",
      key: "deliveryDate",
    },
    {
      title: "Monto",
      dataIndex: "amount",
      key: "amount",
      render: (amount) => <span>${amount}</span>,
    },
    {
      title: "Formas de Pago",
      key: "paymentOptions",
      dataIndex: "paymentOptions",
      render: (_, { paymentOptions }) => (
        <>
          {paymentOptions.map((payment_option) => {
            let color;
            switch (payment_option) {
              case "Contado al retirar":
                color = "geekblue";
                break;
              case "Contado contra entrega":
                color = colors.charcoal;
                break;
              case "Tarjeta":
                color = colors.oxfordBlue;
                break;
              default:
                color = colors.silver;
            }
            return (
              <Tag color={color} key={payment_option} typeof="">
                {payment_option.toUpperCase()}
              </Tag>
            );
          })}
        </>
      ),
    },
    {
      title: "Estado",
      dataIndex: "state",
      key: "state",
    },
    {
      title: "Acción",
      key: "action",
      render: (_, quote) => {
        if (!isQuoteConfirmed) {
          return (
            <Link to={`/quotes/${props.orderId}/${quote.id}`}>
              <Button
                type="primary"
                className="btn-confirm"
                style={{ backgroundColor: colors.oxfordBlue }}
              >
                Seleccionar
              </Button>
            </Link>
          );
        } else {
          return null; // O cualquier otro contenido que desees renderizar si la cotización está confirmada
        }
      },
    },
  ];

  return (
    <div>
      <Table dataSource={props.dataSource} columns={columns} />
    </div>
  );
};
