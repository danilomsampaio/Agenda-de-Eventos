-- Gerado por Oracle SQL Developer Data Modeler 17.3.0.261.1529
--   em:        2017-11-24 20:04:27 BRST
--   site:      SQL Server 2012
--   tipo:      SQL Server 2012



CREATE TABLE agdContato 
    (
     agdContatoID INTEGER IDENTITY(1,1), 
     agdUsuarioID INTEGER NOT NULL , 
     actNome VARCHAR (100) NOT NULL , 
     actSexo BIT NOT NULL , 
     actTelefone VARCHAR (20) , 
     actDataNascimento DATE NOT NULL , 
     actEndereco VARCHAR (120) , 
     actFoto VARCHAR (200) 
    )
    ON "default"
GO

ALTER TABLE agdContato ADD CONSTRAINT agdContato_PK PRIMARY KEY CLUSTERED (agdContatoID)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
     ON "default" 
    GO

CREATE TABLE agdConvite 
    (
     agdConviteID INTEGER IDENTITY(1,1), 
     agdContatoIDConvidado INTEGER NOT NULL , 
     agdContatoIDEmissor INTEGER NOT NULL , 
     agdEventoID INTEGER NOT NULL , 
     acvDataHoraEnvio DATETIME NOT NULL , 
     acvConfirmado BIT NOT NULL 
    )
    ON "default"
GO

ALTER TABLE agdConvite ADD CONSTRAINT agdConvite_PK PRIMARY KEY CLUSTERED (agdConviteID)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
     ON "default" 
    GO

CREATE TABLE agdEvento 
    (
     agdEventoID INTEGER IDENTITY(1,1), 
     agdContatoID INTEGER NOT NULL , 
     aevNome VARCHAR (100) NOT NULL , 
     aevFoto VARCHAR (200) , 
     aevDataHora DATETIME NOT NULL , 
     aevLocal VARCHAR (200) NOT NULL , 
     aevDescricao VARCHAR (1000) NOT NULL 
    )
    ON "default"
GO

ALTER TABLE agdEvento ADD CONSTRAINT agdEvento_PK PRIMARY KEY CLUSTERED (agdEventoID)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
     ON "default" 
    GO

CREATE TABLE agdUsuario 
    (
     agdUsuarioID INTEGER IDENTITY(1,1), 
     ausEmail VARCHAR (254) NOT NULL UNIQUE , 
     ausSenha VARCHAR (12) NOT NULL 
    )
    ON "default"
GO

ALTER TABLE agdUsuario ADD CONSTRAINT agdUsuario_PK PRIMARY KEY CLUSTERED (agdUsuarioID)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
     ON "default" 
    GO

ALTER TABLE agdContato 
    ADD CONSTRAINT agdContato_agdUsuario_FK FOREIGN KEY 
    ( 
     agdUsuarioID
    ) 
    REFERENCES agdUsuario 
    ( 
     agdUsuarioID 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE agdConvite 
    ADD CONSTRAINT agdConvite_agdContato_FK FOREIGN KEY 
    ( 
     agdContatoIDConvidado
    ) 
    REFERENCES agdContato 
    ( 
     agdContatoID 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE agdConvite 
    ADD CONSTRAINT agdConvite_agdContato_FKv2 FOREIGN KEY 
    ( 
     agdContatoIDEmissor
    ) 
    REFERENCES agdContato 
    ( 
     agdContatoID 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE agdConvite 
    ADD CONSTRAINT agdConvite_agdEvento_FK FOREIGN KEY 
    ( 
     agdEventoID
    ) 
    REFERENCES agdEvento 
    ( 
     agdEventoID 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE agdEvento 
    ADD CONSTRAINT agdEvento_agdContato_FK FOREIGN KEY 
    ( 
     agdContatoID
    ) 
    REFERENCES agdContato 
    ( 
     agdContatoID 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO



-- Relatório do Resumo do Oracle SQL Developer Data Modeler: 
-- 
-- CREATE TABLE                             4
-- CREATE INDEX                             0
-- ALTER TABLE                              9
-- CREATE VIEW                              0
-- ALTER VIEW                               0
-- CREATE PACKAGE                           0
-- CREATE PACKAGE BODY                      0
-- CREATE PROCEDURE                         0
-- CREATE FUNCTION                          0
-- CREATE TRIGGER                           0
-- ALTER TRIGGER                            0
-- CREATE DATABASE                          0
-- CREATE DEFAULT                           0
-- CREATE INDEX ON VIEW                     0
-- CREATE ROLLBACK SEGMENT                  0
-- CREATE ROLE                              0
-- CREATE RULE                              0
-- CREATE SCHEMA                            0
-- CREATE SEQUENCE                          0
-- CREATE PARTITION FUNCTION                0
-- CREATE PARTITION SCHEME                  0
-- 
-- DROP DATABASE                            0
-- 
-- ERRORS                                   0
-- WARNINGS                                 0
