CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

DROP TABLE IF EXISTS 
    role_mapping,
    users,
    role,
    post,
    caretaker,
    work_period,
    work_detail,
    accepted_work,
    payment
CASCADE;



-- Role table
CREATE TABLE role (
    id SERIAL PRIMARY KEY,
    role_name VARCHAR NOT NULL UNIQUE
);

-- Users table
CREATE TABLE users (
    id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    username VARCHAR NOT NULL UNIQUE,
    password VARCHAR NOT NULL, 
    name VARCHAR NOT NULL,
    phone VARCHAR,
    gender VARCHAR,
    address VARCHAR,
    image VARCHAR,
    age INT
);

-- Role mapping with ON DELETE CASCADE
CREATE TABLE role_mapping (
    id SERIAL PRIMARY KEY,
    role_id INT REFERENCES role(id) ON DELETE CASCADE,
    user_id UUID REFERENCES users(id) ON DELETE CASCADE
);

-- Post table with ON DELETE CASCADE on user_id
CREATE TABLE post (
    id SERIAL PRIMARY KEY,
    user_id UUID REFERENCES users(id) ON DELETE CASCADE,
    title VARCHAR,
    description TEXT,
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

-- Caretaker table with ON DELETE CASCADE on user_id
CREATE TABLE caretaker (
    id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    user_id UUID REFERENCES users(id) ON DELETE CASCADE,
    education VARCHAR,
    work_history VARCHAR,
    skill VARCHAR
);

-- Work period table with ON DELETE CASCADE on caretaker_id
CREATE TABLE work_period (
    id SERIAL PRIMARY KEY,
    caretaker_id UUID REFERENCES caretaker(id) ON DELETE CASCADE,
    start_time DATE,
    end_time DATE,
    working_date DATE,
    is_active BOOLEAN
);

CREATE TABLE accepted_work (
    id SERIAL PRIMARY KEY,
    post_id INT REFERENCES post(id) ON DELETE CASCADE,
    caretaker_id UUID REFERENCES caretaker(id) ON DELETE CASCADE,
    rating INT
);

CREATE TABLE work_detail (
    id SERIAL PRIMARY KEY,
    accept_work_id INT REFERENCES accepted_work(id) ON DELETE CASCADE,
    work_period_id INT REFERENCES work_period(id) ON DELETE CASCADE,
    create_date DATE,
    update_date DATE
);

-- Payment table with ON DELETE CASCADE on post_id
CREATE TABLE payment (
    id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    payment_method INT,
    amount INT,
    payment_status INT,
    create_date DATE,
    update_date DATE,
    post_id INT REFERENCES post(id) ON DELETE CASCADE
);


INSERT INTO role (role_name) VALUES
('Customer'),
('Caretaker'),
('Admin');
