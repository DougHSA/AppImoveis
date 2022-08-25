-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema appimoveisdb
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema appimoveisdb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `appimoveisdb` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci ;
USE `appimoveisdb` ;

-- -----------------------------------------------------
-- Table `appimoveisdb`.`cliente`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `appimoveisdb`.`cliente` (
  `CPF` BIGINT NOT NULL,
  `Nome` VARCHAR(45) NOT NULL,
  `Email` VARCHAR(45) NULL DEFAULT NULL,
  `Telefone` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`CPF`),
  UNIQUE INDEX `idCliente_UNIQUE` (`CPF` ASC) VISIBLE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `appimoveisdb`.`imoveltb`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `appimoveisdb`.`imoveltb` (
  `idImovel` INT NOT NULL AUTO_INCREMENT,
  `CEP` INT NOT NULL,
  `Estado` VARCHAR(255) NOT NULL,
  `Cidade` VARCHAR(255) NOT NULL,
  `Bairro` VARCHAR(255) NOT NULL,
  `Numero` VARCHAR(255) NOT NULL,
  `Complemento` VARCHAR(255) NOT NULL,
  `Logradouro` VARCHAR(255) NOT NULL,
  `Alugado` TINYINT NULL DEFAULT NULL,
  PRIMARY KEY (`idImovel`),
  UNIQUE INDEX `idImovel_UNIQUE` (`idImovel` ASC) VISIBLE)
ENGINE = InnoDB
AUTO_INCREMENT = 13
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `appimoveisdb`.`locacao`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `appimoveisdb`.`locacao` (
  `idLocacao` INT NOT NULL AUTO_INCREMENT,
  `CPFLocatario` BIGINT NOT NULL,
  `IdImovel` INT NOT NULL,
  PRIMARY KEY (`idLocacao`),
  UNIQUE INDEX `idLocacao_UNIQUE` (`idLocacao` ASC) VISIBLE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `appimoveisdb`.`proprietario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `appimoveisdb`.`proprietario` (
  `idProprietario` INT NOT NULL AUTO_INCREMENT,
  `CPF` BIGINT NOT NULL,
  `idImovel` INT NOT NULL,
  PRIMARY KEY (`idProprietario`),
  UNIQUE INDEX `CPF_UNIQUE` (`idProprietario` ASC) VISIBLE)
ENGINE = InnoDB
AUTO_INCREMENT = 2
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
