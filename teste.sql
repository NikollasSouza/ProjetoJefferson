CREATE DATABASE login_db;

USE login_db;

CREATE TABLE usuarios (
    id INT AUTO_INCREMENT PRIMARY KEY,
    email VARCHAR(100) NOT NULL,
    senha VARCHAR(100) NOT NULL
);

-- Adicione um usuário de teste
INSERT INTO usuarios (email, senha) VALUES
('teste@email.com', '123456');

select * from usuarios
