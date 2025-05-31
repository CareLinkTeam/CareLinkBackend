-- Enable the UUID extension for PostgreSQL
CREATE EXTENSION IF NOT EXISTS "uuid-ossp";
DROP TABLE IF EXISTS role_mapping,
    users,
    role,
    posting,
    caretaker,
    work_period,
    working_detail,
    accepted_work,
    payment;
CREATE TABLE role (
    id SERIAL PRIMARY KEY,
    role_name VARCHAR
);
CREATE TABLE users (
    id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    username VARCHAR,
    password VARCHAR,
    name VARCHAR,
    phone VARCHAR,
    gender VARCHAR,
    address VARCHAR,
    image VARCHAR,
    age INT
);
CREATE TABLE role_mapping (
    id SERIAL PRIMARY KEY,
    role_id INT REFERENCES role(id),
    user_id UUID REFERENCES users(id)
);
CREATE TABLE posting (
    id SERIAL PRIMARY KEY,
    user_id UUID REFERENCES users(id),
    name VARCHAR,
    tel VARCHAR,
    age INT,
    gender VARCHAR,
    disease VARCHAR,
    location VARCHAR,
    start_time DATE,
    end_time DATE,
    status INT,
    working_date DATE
);
CREATE TABLE caretaker (
    id UUID PRIMARY KEY,
    user_id UUID REFERENCES users(id),
    education VARCHAR,
    working_history VARCHAR,
    skill VARCHAR
);

CREATE TABLE work_period (
    id SERIAL PRIMARY KEY,
    caretaker_id UUID REFERENCES caretaker(id),
    start_time DATE,
    end_time DATE,
    working_date DATE,
    is_active BOOLEAN
);

CREATE TABLE working_detail (
    id SERIAL PRIMARY KEY,
    accept_work_id UUID,
    work_detail VARCHAR,
    create_date DATE,
    update_date DATE
);

CREATE TABLE accepted_work (
    id SERIAL PRIMARY KEY,
    posting_id INT REFERENCES posting(id),
    caretaker_id UUID REFERENCES caretaker(id),
    rating INT,
    working_detail_id INT REFERENCES working_detail(id)
);

CREATE TABLE payment (
    id UUID PRIMARY KEY,
    payment_method INT,
    amount INT,
    payment_status INT,
    create_date DATE,
    update_date DATE,
    posting_id INT REFERENCES posting(id)
);

INSERT INTO role (role_name) VALUES
('customers'),
('caretakers'),
('admin');
