DROP TABLE IF EXISTS Be;
DROP TABLE IF EXISTS Practice;
DROP TABLE IF EXISTS Role_;
DROP TABLE IF EXISTS Vocabulary;
DROP TABLE IF EXISTS User_;
DROP TABLE IF EXISTS Group_;

CREATE TABLE Group_(
    id int(10) PRIMARY KEY AUTO_INCREMENT,
    num numeric NOT NULL,
    year numeric NOT NULL,
    sector varchar(50) NOT NULL
);

CREATE TABLE User_(
    id int(10) PRIMARY KEY AUTO_INCREMENT,
    password varchar(30) NOT NULL,
    email text NOT NULL,
    name text NOT NULL,
    surname text NOT NULL,
    nickname varchar(30),
    image text NOT NULL,
    extraTime boolean,
    groupID int(10),
    FOREIGN KEY (groupID) REFERENCES Group_(id)
);

CREATE TABLE Role_(
    id int(1) PRIMARY KEY AUTO_INCREMENT,
    name varchar(10) NOT NULL
);

CREATE TABLE Be(
    userID int(10),
    roleID int(1),
    FOREIGN KEY (userID) REFERENCES User_(id),
    FOREIGN KEY (roleID) REFERENCES Role_(id),
    PRIMARY KEY (userID, roleID)
);

CREATE TABLE Vocabulary(
    id int(10) PRIMARY KEY AUTO_INCREMENT,
    name varchar(30) NOT NULL,
    image text NOT NULL,
    creator int(10),
    FOREIGN KEY (creator) REFERENCES User_(id)
);

CREATE TABLE Practice(
    vocabID int(10),
    groupID int(10),
    FOREIGN KEY (vocabID) REFERENCES Vocabulary(id),
    FOREIGN KEY (groupID) REFERENCES Group_(id),
    PRIMARY KEY (vocabID, groupID)
);

INSERT INTO Role_ VALUES (1, 'admin');
INSERT INTO Role_ VALUES (2, 'teacher');
INSERT INTO Role_ VALUES (3, 'student');
