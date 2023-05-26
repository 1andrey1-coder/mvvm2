--
-- Скрипт сгенерирован Devart dbForge Studio 2020 for MySQL, Версия 9.0.391.0
-- Домашняя страница продукта: http://www.devart.com/ru/dbforge/mysql/studio
-- Дата скрипта: 26.05.2023 11:23:14
-- Версия сервера: 10.3.38
-- Версия клиента: 4.1
--

-- 
-- Отключение внешних ключей
-- 
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;

-- 
-- Установить режим SQL (SQL mode)
-- 
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

-- 
-- Установка кодировки, с использованием которой клиент будет посылать запросы на сервер
--
SET NAMES 'utf8';

--
-- Установка базы данных по умолчанию
--
USE `mvvm dz`;

--
-- Удалить таблицу `TblProduct`
--
DROP TABLE IF EXISTS TblProduct;

--
-- Удалить таблицу `TblCategory`
--
DROP TABLE IF EXISTS TblCategory;

--
-- Удалить таблицу `TblProvider`
--
DROP TABLE IF EXISTS TblProvider;

--
-- Установка базы данных по умолчанию
--
USE `mvvm dz`;

--
-- Создать таблицу `TblProvider`
--
CREATE TABLE TblProvider (
  id int(11) NOT NULL AUTO_INCREMENT,
  Provider varchar(255) DEFAULT NULL,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 162,
AVG_ROW_LENGTH = 819,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_general_ci;

--
-- Создать таблицу `TblCategory`
--
CREATE TABLE TblCategory (
  id int(11) NOT NULL AUTO_INCREMENT,
  Category varchar(255) DEFAULT NULL,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 21,
AVG_ROW_LENGTH = 819,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_general_ci;

--
-- Создать таблицу `TblProduct`
--
CREATE TABLE TblProduct (
  id int(11) NOT NULL AUTO_INCREMENT,
  Name varchar(255) DEFAULT NULL,
  Category int(11) DEFAULT NULL,
  ProviderId int(11) DEFAULT NULL,
  CostOfOne int(11) DEFAULT NULL,
  Discount varchar(255) DEFAULT NULL,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 41,
AVG_ROW_LENGTH = 819,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_general_ci;

--
-- Создать внешний ключ
--
ALTER TABLE TblProduct
ADD CONSTRAINT FK_tbl_product_tbl_category_id FOREIGN KEY (Category)
REFERENCES TblCategory (id) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Создать внешний ключ
--
ALTER TABLE TblProduct
ADD CONSTRAINT FK_tbl_product_tbl_manufacturer_id FOREIGN KEY (ProviderId)
REFERENCES TblProvider (id) ON DELETE NO ACTION ON UPDATE NO ACTION;

-- 
-- Вывод данных для таблицы TblProvider
--
INSERT INTO TblProvider VALUES
(1, ' Apple'),
(2, ' Lenovo'),
(3, ' ASICS'),
(4, ' Ferrero'),
(5, ' Under Armor'),
(6, ' Lavazza'),
(7, ' LG'),
(8, ' L''Oreal'),
(9, ' Apple'),
(10, ' Lancome'),
(11, ' Tefal'),
(12, ' Koh-I-Noor'),
(13, ' Lipton'),
(14, ' Dell'),
(15, ' Philips'),
(16, ' ASUS'),
(17, ' JBL'),
(18, ' Davidoff'),
(19, ' IKEA'),
(20, 'GuCHi');

-- 
-- Вывод данных для таблицы TblCategory
--
INSERT INTO TblCategory VALUES
(1, ' литература'),
(2, ' техника'),
(3, ' техника'),
(4, ' спортивные товары'),
(5, ' продукты питания'),
(6, ' товары для школы'),
(7, ' продукты питания'),
(8, ' бытовая техника'),
(9, ' товары для здоровья'),
(10, ' техника'),
(11, ' товары для красоты'),
(12, ' товары для кухни'),
(13, ' товары для творчества'),
(14, ' продукты питания'),
(15, ' компьютеры и комплектующие'),
(16, ' кухонная техника'),
(17, ' компьютеры и комплектующие'),
(18, ' аудиотехника'),
(19, ' товары для красоты'),
(20, ' товары для дома');

-- 
-- Вывод данных для таблицы TblProduct
--
INSERT INTO TblProduct VALUES
(1, ' Книга "Гарри Поттер и философский камень"', 1, 1, 500, '0,1'),
(2, ' Смартфон iPhone 12 Pro', 2, 2, 99990, '0,05'),
(3, ' Ноутбук IdeaPad 3', 3, 3, 44990, '0,15'),
(4, ' Кроссовки Gel-Kayano 27', 4, 4, 12990, '0,2'),
(5, ' Шоколадная конфета Ferrero Rocher', 5, 5, 150, ' без скидки'),
(6, ' Рюкзак Back To School', 6, 6, 2990, '0,1'),
(7, ' Кофе в зернах "Arabica"', 7, 7, 700, ' без скидки'),
(8, ' Стиральная машина WM 1080', 8, 8, 29990, '0,07'),
(9, ' Шампунь "Elseve" для волос', 9, 9, 300, '0,08'),
(10, ' Ноутбук MacBook Air', 10, 10, 89990, '0,05'),
(11, ' Парфюм "La Vie Est Belle"', 11, 11, 7900, '0,12'),
(12, ' Керамическая сковорода "Titanium"', 12, 12, 1590, '0,2'),
(13, ' Набор фломастеров "Capitan"', 13, 13, 490, ' без скидки'),
(14, ' Чай "Голден Сенча"', 14, 14, 250, '0,15'),
(15, ' Монитор UltraSharp 27', 15, 15, 33990, '0,1'),
(16, ' Блендер UltraBlend', 16, 16, 5990, ' без скидки'),
(17, ' Маршрутизатор RT-AC86U', 17, 17, 16490, '0,05'),
(18, ' Колонки Xtreme 3', 18, 18, 14990, '0,1'),
(19, ' Гель для душа "Cool Water"', 19, 19, 590, ' без скидки'),
(20, ' Лампа настольная "Ella"', 20, 20, 1590, '0,15');

-- 
-- Восстановить предыдущий режим SQL (SQL mode)
--
/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;

-- 
-- Включение внешних ключей
-- 
/*!40014 SET FOREIGN_KEY_CHECKS = @OLD_FOREIGN_KEY_CHECKS */;