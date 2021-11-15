CREATE TABLE consultas_tb(
  id INT AUTO_INCREMENT PRIMARY KEY,
  descricao LONGTEXT NOT NULL,
  anexo VARCHAR(150),
  dthora VARCHAR(100) NOT NULL,
  status VARCHAR(100) NOT NULL,
  transacao_id VARCHAR(20) NOT NULL,
  cpf VARCHAR(14) NOT NULL,
  nome VARCHAR(150) NOT NULL,
  sobrenome VARCHAR(150) NOT NULL,
  email VARCHAR(150) NOT NULL,
  dtnascimento VARCHAR(100) NOT NULL,
  telefone_fixo LONGTEXT NOT NULL,
  telefone_celular LONGTEXT, 
  CONSTRAINT fk_medico
  FOREIGN KEY (id) REFERENCES medicos_tb(id)
) ENGINE = innodb;