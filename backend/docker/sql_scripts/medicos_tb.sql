CREATE TABLE medicos_tb(
  id INT(11) NOT NULL AUTO_INCREMENT,
  crm VARCHAR(12) NOT NULL,
  nome VARCHAR(150) NOT NULL,
  sobrenome VARCHAR(150) NOT NULL,
  email VARCHAR(150) NOT NULL,
  dtnascimento VARCHAR(100) NOT NULL,
  especialidade VARCHAR(100) NOT NULL,
  telefone_fixo LONGTEXT NOT NULL,
  telefone_celular LONGTEXT, 
  senha VARCHAR(10) NOT NULL,
  PRIMARY KEY (id)
) ENGINE = innodb;