CREATE TABLE Users (
    id INTEGER PRIMARY KEY,
    first_name TEXT,
    last_name TEXT,
    email TEXT,
    qualification INTEGER
);

CREATE TABLE Payment_Options (
    id INTEGER PRIMARY KEY,
    description TEXT
);

CREATE TABLE States (
    id INTEGER PRIMARY KEY,
    description TEXT
);


CREATE TABLE Orders (
    id INTEGER PRIMARY KEY,
    user_id INTEGER,
    FOREIGN KEY (user_id) REFERENCES Users(id)
);

CREATE TABLE Quotes (
    id INTEGER,
    order_id INTEGER,
    transport_id INTEGER,
    pick_up_date TEXT,
    delivery_date TEXT,
    amount INTEGER,
    state_id INTEGER,
    selected_payment_option_id INTEGER,
    FOREIGN KEY (order_id) REFERENCES Orders(id),
    FOREIGN KEY (transport_id) REFERENCES Users(id),
    FOREIGN KEY (state_id) REFERENCES States(id),
    FOREIGN KEY (selected_payment_option_id) REFERENCES Payment_Options(id),
    PRIMARY KEY (quote_id, payment_option_id)
);

CREATE TABLE Quotes_x_Payment_options (
    quote_id INTEGER,
    order_id INTEGER,
    payment_option_id INTEGER,
    FOREIGN KEY (quote_id, order_id) REFERENCES Quotes(id, order_id),
    FOREIGN KEY (payment_option_id) REFERENCES Payment_Options(id),
    PRIMARY KEY (quote_id, order_id, payment_option_id)
);