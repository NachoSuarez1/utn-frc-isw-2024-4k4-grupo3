import React, { useEffect } from "react";
import { useState } from "react";
import { QuoteForm } from "../components";
import { useParams } from "react-router-dom";
import { colors } from "../config/colors";
import { Modal } from "antd";
import { quotesService } from "../services";

export const PaymentScreen = (props) => {
  const [quote, setQuote] = useState(null);
  const { orderId, quoteId } = useParams();

  const getQuote = async () => {
    try {
      const response = await quotesService.get(`Get/${orderId}/?quoteId=${quoteId}`);
      console.log(response);
      if (response && response.length > 0) {
        response[0].paymentOptions.unshift(null);
        setQuote(response[0]);
      } else {
        throw new Error("No se ha encontrado ninguna cotización");
      }
    } catch (error) {
      alert({ type: "info", message: error.message });
    }
  };

  const onSuccess = () => {
    Modal.success({
      content: "Confirmado",
      centered: true,
      style: { color: colors.oxfordBlue },
      okButtonProps: {
        style: { backgroundColor: colors.green, color: "white" },
        onClick: () => {
          window.location.href = "/quotes/" + quote.orderId;
        },
      },
    });
  };

  const onError = (error) => {
    Modal.error({
      title: "Error",
      content: error.message ? error.message : "Por favor, revisa los campos ingresados.",
      centered: true,
      okButtonProps: { style: { backgroundColor: colors.oxfordBlue, color: "white" } },
    });
  };

  const submit = async (endpoint, values) => {
    try {
      console.log("values", values);
      if(values.paymentOption == null){
        throw Error("Debe seleccionar un tipo de pago");
      }
      const response = await quotesService.put(endpoint, values);
      onSuccess();
    } catch (error) {
      onError(error);
    }
  };

  useEffect(() => {
    getQuote(); // Llamar a getQuote en useEffect
  }, [orderId, quoteId]); // Asegurarse de que useEffect se ejecute cuando cambien orderId o quoteId

  return (
    <div className="quotes">
      {(quote && quote.state === "Pendiente") && <QuoteForm quote={quote} submit={submit} />}
    </div>
  );
};
