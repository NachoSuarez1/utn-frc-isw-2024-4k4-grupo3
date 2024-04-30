import React, { useEffect } from "react";
import { useState } from "react";
import { QuoteForm } from "../components";
import { useParams } from "react-router-dom";
import { quotesService } from "../services";

export const PaymentScreen = (props) => {
  const [quote, setQuote] = useState(null);
  const { orderId, quoteId } = useParams();

  const myQuote = {
    id: "1",
    transport_name: "Mike",
    qualification: 1,
    pick_up_date: "28/04/2024",
    delivery_date: "28/04/2024",
    amount: 1000,
    payment_options: ["Contado al retirar", "Tarjeta"],
    state: "Confirmada",
    order_id: "1234",
  };

  const getQuote = async () => {
    try {
      // await quotesService.get({orderId: orderId,quoteId: quoteId});
      return myQuote;
    } catch (error) {
      alert({ type: "info", message: "No se ha encontrado ninguna cotizacion" });
    } finally {
      setQuote(myQuote);
    }
  };

  const updateQuote = async (quote) => {
    try {
      // await quotesService.put(quote);
    } catch (error) {
      alert({ type: "error", message: "Error al actualizar los datos" });
    }
  };

  const submit = async (values) => {
    try {
      console.log("values", values);

      // await quotesService.put(endpoint, values);
      window.location.href = "/quotes/" + orderId;
    } catch (error) {
      alert({ type: "error", message: "Error al actualizar los datos" });
    }
  };

  useEffect(() => {
    getQuote();
  }, [quoteId]);

  return (
    <div className="quotes">
      <QuoteForm quote={myQuote} submit={submit} />
    </div>
  );
};
