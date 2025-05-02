CREATE TABLE IF NOT EXISTS accounts (
    id bigserial primary key,
    created_at timestamp(0) with time zone not null default now(),
    name text not null,
    account_type text not null,
    institution text not null
);