/*!40101 SET NAMES utf8 */;
DROP DATABASE IF EXISTS `vtms`;
CREATE DATABASE `vtms`;
DROP TABLE IF EXISTS `vtms`.`customer`;
CREATE TABLE `vtms`.`customer` 
	(   `id` VARCHAR(30) NOT NULL,  
		`name` VARCHAR(50) NOT NULL,  
		`phone` VARCHAR(15),  
		`address` VARCHAR(100),
  PRIMARY KEY (`id`)
	);
DROP TABLE IF EXISTS `vtms`.`vehicle`;
CREATE  TABLE `vtms`.`vehicle` (
	`serial` VARCHAR(15) NOT NULL ,
	`originid` VARCHAR(30) NOT NULL ,
	`originpic` BLOB NULL,
	`currentid` VARCHAR(30) NOT NULL ,
	`currentpic` BLOB NULL,
	`invoice` VARCHAR(20) NULL,
	`license` CHAR(5) NOT NULL ,
	`vin` VARCHAR(20) NOT NULL ,
	`vehicletype` CHAR(2) NOT NULL ,
	`brand` VARCHAR(50) NULL ,
	`certificate` VARCHAR(20) NULL ,
	`register` CHAR(6) NOT NULL ,
	`certification` CHAR(8) NOT NULL ,
	`actual` DECIMAL(11,2) NOT NULL ,
	`transactions` DECIMAL(11,2) NOT NULL ,
	`department` VARCHAR(50) NOT NULL,
	`company` VARCHAR(50) NULL,
	`saver` VARCHAR(15) NOT NULL ,
	`save_date` DATE NOT NULL ,
	`recorder` VARCHAR(10) NULL ,
	`record_date` DATE NULL ,
	`isrecorded` BIT NULL DEFAULT false ,
	`charger` VARCHAR(10) NULL ,
	`charge_date` DATE NULL ,
	`ischarged` BIT NULL DEFAULT false ,
	`printer` VARCHAR(10) NULL ,
	`print_date` DATE NULL ,
	`isprinted` BIT NULL DEFAULT false ,
	`refunder` VARCHAR(10) NULL ,
	`refund_date` DATE NULL ,
	`isrefund` BIT NULL DEFAULT false ,
	`granter` VARCHAR(10) NULL ,
	`grant_date` DATE NULL ,
	`isgrant` BIT NULL DEFAULT false ,
	`firstpic` MEDIUMBLOB NULL  ,
	`secondpic` MEDIUMBLOB NULL ,
	`thirdpic` MEDIUMBLOB NULL ,
	`forthpic` MEDIUMBLOB NULL ,
  PRIMARY KEY (`serial`));
DROP TABLE IF EXISTS `vtms`.`vehicleType`;
CREATE  TABLE `vtms`.`vehicleType` (
  `id` CHAR(2) NOT NULL ,
  `name` VARCHAR(45) NOT NULL ,
  `priority` INT NOT NULL DEFAULT 100 ,
  `isactive` BIT NOT NULL DEFAULT true ,
  PRIMARY KEY (`id`) );
INSERT INTO `vtms`.`vehicleType` VALUES ('00',' ','100',true),('01','轿车','100',true),('02','客车（19座以下）','100',true),('03','客车（19座以上）','100',true),('04','小货车','100',true),('05','大货车（4.5吨以上）','100',true),('06','微型货车（1800kg以下）','100',true),('07','租赁','100',true),('08','出租营转非','100',true),('09','营转非','100',true),('10','越野车','100',true),('11','特种车','100',true),('12','出租车','100',true),('13','摩托车','100',true),('14','营运车','100',true),('15','大型车','100',true),('16','中型普通货车','100',true),('17','公路客运车转非营运','100',true),('19','低速车','100',true),('20','教练汽车','100',true),('21','旅游客运','100',true),('22','公路客运','100',true),('23','公交客运','100',true),('18','中型厢式货车','100',true);
DROP TABLE IF EXISTS `vtms`.`company`;
CREATE  TABLE `vtms`.`company` (
  `id` CHAR(2) NOT NULL ,
  `name` VARCHAR(45) NOT NULL ,
  `priority` INT NOT NULL DEFAULT 100 ,
  `isactive` BIT NOT NULL DEFAULT true ,
  PRIMARY KEY (`id`) );
INSERT INTO `vtms`.`company` VALUES ('00','个人','100',true);
DROP TABLE IF EXISTS `vtms`.`users`;
CREATE  TABLE `vtms`.`users` (
  `id` INT NOT NULL ,
  `name` VARCHAR(45) NOT NULL ,
  `email` VARCHAR(100) NOT NULL ,
  `isactive` BIT NOT NULL DEFAULT 1 ,
  PRIMARY KEY (`id`) );
DROP TABLE IF EXISTS `vtms`.`register`;
CREATE TABLE `vtms`.`register` (
	`serial` VARCHAR(50) NOT NULL,
	`category` VARCHAR(50) NULL,
	`license` VARCHAR(50) NULL,
	`apply` VARCHAR(50) NULL,
	`revoke` VARCHAR(50) NULL,
	`brand` VARCHAR(50) NULL,
	`vin` VARCHAR(50) NULL,
	`obtain` VARCHAR(50) NULL,
	`purpose` VARCHAR(50) NULL,
	`ownerName` VARCHAR(50) NULL,
	`ownerAddress` VARCHAR(50) NULL,
	`ownerPostcode` VARCHAR(50) NULL,
	`ownerPhone` VARCHAR(50) NULL,
	`ownerEmail` VARCHAR(50) NULL,
	`ownerMobile` VARCHAR(50) NULL,
	`province` VARCHAR(50) NULL,
	`department` VARCHAR(50) NULL,
	`agentName` VARCHAR(50) NULL,
	`agentAddress` VARCHAR(50) NULL,
	`agentPostcode` VARCHAR(50) NULL,
	`agentPhone` VARCHAR(50) NULL,
	`agentEmail` VARCHAR(50) NULL,
	`handlerName` VARCHAR(50) NULL,
	`handlerPhone` VARCHAR(50) NULL, 
	`saver` VARCHAR(15) NOT NULL ,
	`save_date` DATE NOT NULL ,
	`printer` VARCHAR(10) NULL ,
	`print_date` DATE NULL ,
 PRIMARY KEY (`serial`));