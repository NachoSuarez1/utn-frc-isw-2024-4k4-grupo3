import React from "react";
import { useState } from "react";
import { QuoteForm } from "../components";
import { colors } from "../config/colors";

export const PaymentScreen = (props) => {
  const [quote, setQuote] = useState(null);

  const myQuote = {
    key: "1",
    transport_name: "Mike",
    qualification: 1,
    pick_up_date: "28/04/2024",
    delivery_date: "28/04/2024",
    amount: 1000,
    payment_options: ["Contado al retirar", "Tarjeta"],
    state: "Confirmada",
  };

  const getQuote = async () => {
    try {
      // await props.getQuote(data);
      return myQuote;
    } catch (error) {
      alert({ type: "info", message: "No se ha encontrado ninguna cotizacion" });
    } finally {
      setQuote(myQuote);
    }
  };

  const onPaymentSelect = async (payment, formValues) => {
    try {
      console.log("payment", payment);
      console.log("formValues", formValues);
    } catch (error) {
      alert({ type: "error", message: "Error al actualizar los datos" });
    }
  };

  return (
    <div className="quotes">
      <QuoteForm quote={myQuote} />
    </div>
  );
};
