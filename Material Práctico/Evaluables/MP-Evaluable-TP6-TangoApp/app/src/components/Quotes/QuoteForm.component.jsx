import React, { useState } from "react";
import { Form, Input, Select, Button, Rate } from "antd";
import { colors } from "../../config/colors";

const { Option } = Select;

export const QuoteForm = ({ quote }) => {
  const [paymentMethod, setPaymentMethod] = useState("");
  const [cardType, setCardType] = useState("");

  const handlePaymentMethodChange = (value) => {
    setPaymentMethod(value);
    // Reset card type when changing payment method
    setCardType("");
  };

  const handleCardTypeChange = (value) => {
    setCardType(value);
  };

  return (
    <div
      style={{
        display: "flex",
        justifyContent: "center",
        alignItems: "center",
        height: "100vh",
        flexDirection: "column",
      }}
    >
      <h1 style={{ color: colors.oxfordBlue }}>Cotizacion #{quote.key}</h1>
      <Form
        name="quoteForm"
        initialValues={quote}
        onFinish={(values) => {
          console.log("Form values:", values);
        }}
      >
        <Form.Item label="Transportista" name="transport_name">
          <Input disabled style={{ color: colors.oxfordBlue }} />
        </Form.Item>

        <Form.Item label="Calificación" name="qualification">
          <Rate disabled defaultValue={quote.qualification} style={{ color: colors.honeydew }} />
        </Form.Item>

        <Form.Item label="Fecha de Retiro" name="pick_up_date">
          <Input disabled style={{ color: colors.oxfordBlue }} />
        </Form.Item>

        <Form.Item label="Fecha de Entrega" name="delivery_date">
          <Input disabled style={{ color: colors.oxfordBlue }} />
        </Form.Item>

        <Form.Item label="Monto" name="amount">
          <Input disabled style={{ color: colors.oxfordBlue }} />
        </Form.Item>

        <Form.Item label="Forma de Pago" name="payment_options">
          <Select onChange={handlePaymentMethodChange}>
            {quote.payment_options.map((option) => (
              <Option key={option} value={option}>
                {option}
              </Option>
            ))}
          </Select>
        </Form.Item>

        {paymentMethod === "Tarjeta" && (
          <Form.Item label="Tipo de Tarjeta" name="card_type">
            <Select onChange={handleCardTypeChange}>
              <Option value="Crédito">Crédito</Option>
              <Option value="Débito">Débito</Option>
            </Select>
          </Form.Item>
        )}

        <Form.Item>
          <Button type="primary" htmlType="submit">
            Submit
          </Button>
        </Form.Item>
      </Form>
    </div>
  );
};
