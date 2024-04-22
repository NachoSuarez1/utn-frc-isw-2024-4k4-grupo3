import React from "react";
import { Link } from "react-router-dom";
import { Table, Tag, Button, Modal } from "antd";
import { useState } from "react";
import { colors } from "../../config/colors";
import "../css/TableQuotes.css";

export const TableQuotes = (props) => {
  const [selectedQuote, setSelectedQuote] = useState(null);
  const [modalVisible, setModalVisible] = useState(false);

  const isQuoteConfirmed = props.dataSource.find((quote) => quote.state === "Confirmada");

  const columns = [
    {
      title: "Transportista",
      dataIndex: "transport_name",
      key: "transport_name",
    },
    {
      title: "Calificación",
      dataIndex: "qualification",
      key: "qualification",
    },
    {
      title: "Fecha de Retiro",
      dataIndex: "pick_up_date",
      key: "pick_up_date",
    },
    {
      title: "Fecha de Entrega",
      dataIndex: "delivery_date",
      key: "delivery_date",
    },
    {
      title: "Formas de Pago",
      key: "payment_options",
      dataIndex: "payment_options",
      render: (_, { payment_options }) => (
        <>
          {payment_options.map((payment_option) => {
            let color;
            switch (payment_option) {
              case "Contado al retirar":
                color = "green";
                break;
              case "Contado contra entrega":
                color = "volcano";
                break;
              case "Tarjeta":
                color = "geekblue";
                break;
              default:
                color = "green";
            }
            return (
              <Tag color={color} key={payment_option}>
                {payment_option.toUpperCase()}
              </Tag>
            );
          })}
        </>
      ),
    },
    {
      title: "Acción",
      key: "action",
      render: (_, quote) => (
        <Button
          type="primary"
          onClick={() => handleCotizar(quote)}
          disabled={selectedQuote && selectedQuote.key !== quote.key}
          style={{ backgroundColor: colors.button }}
        >
          Seleccionar
        </Button>
      ),
    },
  ];

  const handleCotizar = (quote) => {
    setSelectedQuote(quote);
    handleModalOpen();
  };

  const handleModalOpen = () => {
    setModalVisible(true);
  };

  const handleModalClose = () => {
    setModalVisible(false);
    setSelectedQuote(null);
  };

  return (
    <div>
      <Modal
        title="Seleccionar Cotizacion"
        visible={modalVisible}
        onCancel={handleModalClose}
        footer={[
          <Button key="back" onClick={handleModalClose} type="primary" danger>
            Cancelar
          </Button>,
          <Button
            key="submit"
            type="primary"
            onClick={handleModalClose}
            className="btn-confirm"
            style={{ backgroundColor: colors.button }}
          >
            Confirmar Cotización
          </Button>,
        ]}
      >
        {/* Aquí puedes colocar el contenido que deseas mostrar dentro del modal */}
        <p>Contenido del modal...</p>
      </Modal>
      <Table
        dataSource={props.dataSource}
        columns={columns}
        className="tablaCotizaciones"
      />
    </div>
  );
};
