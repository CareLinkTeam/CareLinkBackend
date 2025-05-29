CREATE TABLE role (
    id SERIAL PRIMARY KEY,
    role_name VARCHAR
);
CREATE TABLE "User" (
    id UUID PRIMARY KEY,
    username VARCHAR,
    password VARCHAR,
    name VARCHAR,
    tel VARCHAR,
    gender VARCHAR,
    address VARCHAR,
    image VARCHAR,
    age INT
);
CREATE TABLE role_mapping (
    id SERIAL PRIMARY KEY,
    role_id BIGINT REFERENCES role(id),
    user_id UUID REFERENCES "User"(id)
);
CREATE TABLE posting (
    id SERIAL PRIMARY KEY,
    user_id UUID REFERENCES "User"(id),
    name VARCHAR,
    tel VARCHAR,
    age BIGINT,
    gender VARCHAR,
    disease VARCHAR,
    location VARCHAR,
    start_time DATE,
    end_time DATE,
    status BIGINT,
    working_date DATE
);
CREATE TABLE caretaker (
    id UUID PRIMARY KEY,
    user_id UUID REFERENCES "User"(id),
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
    posting_id BIGINT REFERENCES posting(id),
    caretaker_id UUID REFERENCES caretaker(id),
    rating BIGINT,
    working_detail_id BIGINT REFERENCES working_detail(id)
);

CREATE TABLE payment (
    id UUID PRIMARY KEY,
    payment_method BIGINT,
    amount BIGINT,
    payment_status BIGINT,
    create_date DATE,
    update_date DATE,
    posting_id BIGINT REFERENCES posting(id)
);
