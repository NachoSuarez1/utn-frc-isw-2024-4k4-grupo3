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

CREATE TABLE Quotes (
    id INTEGER PRIMARY KEY,
    user_id INTEGER,
    pick_up_date TEXT,
    delivery_date TEXT,
    amount INTEGER,
    FOREIGN KEY (user_id) REFERENCES Users(id)
);

CREATE TABLE Quotes_x_payment_options (
    id INTEGER PRIMARY KEY,
    quote_id INTEGER,
    payment_option_id INTEGER,
    FOREIGN KEY (quote_id) REFERENCES Quotes(id),
    FOREIGN KEY (payment_option_id) REFERENCES Payment_Options(id)
);

CREATE TABLE Payment_Options (
    id INTEGER PRIMARY KEY,
    description TEXT
);