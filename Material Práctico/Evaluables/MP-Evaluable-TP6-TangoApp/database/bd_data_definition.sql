CREATE TABLE Users (
    id INTEGER PRIMARY KEY,
    first_name TEXT,
    last_name TEXT,
    email TEXT,
    qualification INTEGER
);

CREATE TABLE States (
    id INTEGER PRIMARY KEY,
    description TEXT
);

CREATE TABLE Orders (
    id INTEGER PRIMARY KEY
    user_id INTEGER,
    FOREIGN KEY (user_id) REFERENCES Users(id)
);

CREATE TABLE Quotes (
    id INTEGER PRIMARY KEY,
    transport_id INTEGER,
    pick_up_date TEXT,
    delivery_date TEXT,
    amount INTEGER,
    state_id INTEGER,
    selected_payment_option_id INTEGER,

    FOREIGN KEY (transport_id) REFERENCES Users(id)
    FOREIGN KEY (state_id) REFERENCES States(id)
    FOREIGN KEY (selected_payment_option_id) REFERENCES Payment_Options(id)
);

CREATE TABLE Quotes_x_Payment_options (
    quote_id INTEGER,
    payment_option_id INTEGER,
    FOREIGN KEY (quote_id) REFERENCES Quotes(id),
    FOREIGN KEY (payment_option_id) REFERENCES Payment_Options(id),
    PRIMARY KEY (quote_id, payment_option_id)
);

CREATE TABLE Quotes_x_Order (
    order_id INTEGER,
    quote_id INTEGER,
    FOREIGN KEY (quote_id) REFERENCES Quotes(id),
    FOREIGN KEY (order_id) REFERENCES Orders(id),
    PRIMARY KEY (order_id, quote_id)
);

CREATE TABLE Payment_Options (
    id INTEGER PRIMARY KEY,
    description TEXT
);