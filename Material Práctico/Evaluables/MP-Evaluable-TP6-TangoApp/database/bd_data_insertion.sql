--STATES
INSERT INTO States(ID, DESCRIPTION) VALUES
(1, 'Confirmado'),
(2, 'Descartado'),
(3, 'Pendiente');

--PAYMENT_OPTIONS
INSERT INTO PAYMENT_OPTIONS(ID, DESCRIPTION) VALUES
(1, 'Tarjeta'),
(2, 'Contado al retirar'),
(3, 'Contado contra entrega');

--USERS
INSERT INTO USERS(ID, FIRST_NAME, LAST_NAME, EMAIL, QUALIFICATION) VALUES
(1, 'José', 'Cabral', 'cabraljose1210@gmail.com', 4),
(2, 'Benjamín', 'Cabral', 'cabralbenja2001@gmail.com', 3),
(3, 'Santiago', 'Gutierrez', 'santi0gutierrez0@gmail.com', 5),
(4, 'Ignacio', 'Suarez', 'ignaciosuarez321@gmail.com', 2);

--ORDERS
INSERT INTO ORDERS(ID, USER_ID) VALUES
(1111, 3),
(1234, 3);

--QUOTES
INSERT INTO QUOTES(ID, TRANSPORT_ID, PICK_UP_DATE, DELIVERY_DATE, AMOUNT, STATE_ID) VALUES
(1, 1234, 1, '05/05/2024', '10/05/2024', 600, 3),
(2, 1234, 2, '05/05/2024', '06/05/2024', 800, 3),
(3, 1234, 4, '05/05/2024', '06/05/2024', 1200, 3);

--QUOTES_X_PAYMENT_OPTIONS
INSERT INTO QUOTES_X_PAYMENT_OPTIONS(QUOTE_ID, ORDER_ID, PAYMENT_OPTION_ID) VALUES
(1, 1234, 1),
(1, 1234, 2),
(1, 1234, 3),
(2, 1234, 1),
(2, 1234, 3),
(3, 1234, 2),
(3, 1234, 3);

--QUOTES_X_ORDERS
INSERT INTO QUOTES_X_ORDER(ORDER_ID, QUOTE_ID) VALUES
(1234, 1),
(1234, 2),
(1234, 3);