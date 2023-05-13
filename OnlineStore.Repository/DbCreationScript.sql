DROP TABLE IF EXISTS SaleProduct;
DROP TABLE IF EXISTS Sale;
DROP TABLE IF EXISTS ProductImage;
DROP TABLE IF EXISTS CartProduct;
DROP TABLE IF EXISTS Product;
DROP TABLE IF EXISTS Cart;
DROP TABLE IF EXISTS User;

CREATE TABLE User (
	userId INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    username VARCHAR(255) NOT NULL,
    password VARCHAR(255) NOT NULL
);

CREATE TABLE Cart (
	cartId INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    userId INT NOT NULL,
    FOREIGN KEY `cart_to_user` (userId) REFERENCES User(userId)
);

CREATE TABLE Category (
	categoryId INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(255)
);

CREATE TABLE Product (
	productId INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    categoryId INT NOT NULL,
    FOREIGN KEY `product_to_category` (categoryId) REFERENCES Category(categoryId),
    sku VARCHAR(12) NOT NULL UNIQUE,
    name VARCHAR(255),
    description TEXT(1000),
    manufacturerInfo TEXT(1000),
    rating DECIMAL(3, 1),
    dimensions VARCHAR(255),
    weight DECIMAL(10, 2),
    price DECIMAL(10, 2),
    inventory DECIMAL(10, 2)
);

CREATE TABLE CartProduct (
	cartProductId INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    cartId INT NOT NULL,
    FOREIGN KEY `cartProduct_to_cart` (cartId) REFERENCES Cart(cartId),
    productId INT NOT NULL,
    FOREIGN KEY `cartProduct_to_product` (productId) REFERENCES Product(productId),
    quantity DECIMAL(10, 2)
);

CREATE TABLE ProductImage (
	imageId INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    productId INT NOT NULL,
    FOREIGN KEY `image_to_product` (productId) REFERENCES Product(productId),
    path VARCHAR(255)
);

CREATE TABLE Sale (
	saleId INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    amountOff DECIMAL(10, 2),
    percentOff DECIMAL(5, 2),
    startDate VARCHAR(255),
    endDate VARCHAR(255)
);

CREATE TABLE SaleProduct (
	saleProductId INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    saleId INT NOT NULL,
    FOREIGN KEY `saleProduct_to_sale` (saleId) REFERENCES Sale(saleId),
    productId INT NOT NULL,
    FOREIGN KEY `saleProduct_to_product` (productId) REFERENCES Product(productId)
);
