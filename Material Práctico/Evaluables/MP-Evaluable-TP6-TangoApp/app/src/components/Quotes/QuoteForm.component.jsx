import React, { useState } from "react";
import { Form, Input, Select, Button, Rate, Row, Col, Modal } from "antd";
import { colors } from "../../config/colors";
import "../css/FormItems.css";

const { Option } = Select;

export const QuoteForm = ({ quote, submit }) => {
  const [form] = Form.useForm();
  const [paymentMethod, setPaymentMethod] = useState("");
  const [cardType, setCardType] = useState("");
  const [showCardFields, setShowCardFields] = useState(false);

  const handlePaymentMethodChange = (value) => {
    setPaymentMethod(value);
    setCardType("");
    setShowCardFields(value === "Tarjeta");
  };

  const handleCardTypeChange = (value) => {
    setCardType(value);
  };

  const validateNumeric = (rule, value, callback) => {
    if (isNaN(value)) {
      callback("Por favor, ingresa solo números.");
    } else {
      callback();
    }
  };

  const onSuccess = (endpoint, paymentMethod) => {
    Modal.success({
      content: "Confirmado",
      centered: true,
      style: { color: colors.oxfordBlue },
      okButtonProps: {
        style: { backgroundColor: colors.green, color: "white" },
        onClick: () => {
          submit(endpoint, paymentMethod);
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

  const submitForm = async () => {
    try {
      const values = await form.validateFields();
      const selectedPaymentOption = values.payment_options;
      const card = showCardFields
        ? {
            cardType: values.card_type,
            cardNumber: values.card_number,
            pin: values.pin,
            fullName: values.full_name,
            documentType: values.document_type,
            documentNumber: values.document_number,
          }
        : null;

      const paymentMethod = {
        payment_option: selectedPaymentOption,
        card: card,
      };

      const endpoint = `/quotes/${quote.order_id}/${quote.id}`;

      onSuccess(endpoint, paymentMethod);
    } catch (error) {
      console.error("Validation failed:", error);
      onError(error);
    }
  };

  const formItemStyle = {
    maxWidth: 300,
  };

  return (
    <div style={{ padding: 50, textAlign: "center" }}>
      <h1 style={{ color: colors.oxfordBlue }}>Cotización #{quote.id}</h1>
      <Form
        form={form}
        name="quoteForm"
        initialValues={quote}
        onFinish={submitForm}
        style={{ display: "flex", justifyContent: "center", alignItems: "center" }}
      >
        <Row gutter={24}>
          <Col span={showCardFields ? 12 : 24}>
            <Form.Item label="Transportista" name="transport_name" style={formItemStyle}>
              <Input disabled style={{ color: colors.oxfordBlue }} />
            </Form.Item>

            <Form.Item label="Calificación" name="qualification" style={formItemStyle}>
              <Rate
                disabled
                defaultValue={quote.qualification}
                style={{ color: colors.honeydew }}
              />
            </Form.Item>

            <Form.Item label="Fecha de Retiro" name="pick_up_date" style={formItemStyle}>
              <Input disabled style={{ color: colors.oxfordBlue }} />
            </Form.Item>

            <Form.Item label="Fecha de Entrega" name="delivery_date" style={formItemStyle}>
              <Input disabled style={{ color: colors.oxfordBlue }} />
            </Form.Item>

            <Form.Item label="Monto" name="amount" style={formItemStyle}>
              <Input disabled style={{ color: colors.oxfordBlue }} />
            </Form.Item>

            <Form.Item
              label="Forma de Pago"
              name="payment_options"
              style={formItemStyle}
              rules={[{ required: true, message: "La forma de pago no fue ingresada" }]}
            >
              <Select onChange={handlePaymentMethodChange}>
                {quote.payment_options.map((option) => (
                  <Option key={option} value={option}>
                    {option}
                  </Option>
                ))}
              </Select>
            </Form.Item>
          </Col>

          {showCardFields && (
            <Col span={12}>
              <Form.Item
                label="Tipo de Tarjeta"
                name="card_type"
                style={formItemStyle}
                rules={[{ required: true, message: "El tipo de tarjeta no fue ingresado" }]}
              >
                <Select onChange={handleCardTypeChange}>
                  <Option value="Crédito">Crédito</Option>
                  <Option value="Débito">Débito</Option>
                </Select>
              </Form.Item>
              <Form.Item
                label="Número de Tarjeta"
                name="card_number"
                style={formItemStyle}
                rules={[
                  { required: true, message: "El número de tarjeta no fue ingresado" },
                  { validator: validateNumeric },
                ]}
              >
                <Input maxLength={16} style={{ backgroundColor: colors.honeydew }} />
              </Form.Item>
              <Form.Item
                label="PIN"
                name="pin"
                style={formItemStyle}
                rules={[
                  { required: true, message: "El PIN no fue ingresado" },
                  { validator: validateNumeric },
                ]}
              >
                <Input.Password maxLength={3} style={{ backgroundColor: colors.honeydew }} />
              </Form.Item>
              <Form.Item
                label="Nombre Completo"
                name="full_name"
                style={formItemStyle}
                rules={[{ required: true, message: "El nombre no fue ingresado" }]}
              >
                <Input style={{ textTransform: "uppercase", backgroundColor: colors.honeydew }} />
              </Form.Item>
              <Form.Item
                label="Tipo de Documento"
                name="document_type"
                style={formItemStyle}
                rules={[{ required: true, message: "El tipo de documento no fue ingresado" }]}
              >
                <Select>
                  <Option value={"DNI"}>{"DNI"}</Option>
                  <Option value={"Pasaporte"}>{"Pasaporte"}</Option>
                  <Option value={"Cédula de Identidad"}>{"Cédula de Identidad"}</Option>
                </Select>
              </Form.Item>
              <Form.Item
                label="Número de Documento"
                name="document_number"
                style={formItemStyle}
                rules={[
                  { required: true, message: "El número de documento no fue ingresado" },
                  { validator: validateNumeric },
                ]}
              >
                <Input maxLength={8} style={{ backgroundColor: colors.honeydew }} />
              </Form.Item>
            </Col>
          )}
        </Row>
      </Form>
      <div style={{ textAlign: "center", marginTop: "20px" }}>
        <Button type="primary" onClick={submitForm}>
          {cardType === "Crédito" || cardType === "Débito" ? "Pagar y Aceptar" : "Aceptar"}
        </Button>
      </div>
    </div>
  );
};
