DROP TABLE IF EXISTS Translate;
DROP TABLE IF EXISTS Register;
DROP TABLE IF EXISTS Practice;
DROP TABLE IF EXISTS Be;
DROP TABLE IF EXISTS VocabularyList;
DROP TABLE IF EXISTS Vocabulary;
DROP TABLE IF EXISTS Language;
DROP TABLE IF EXISTS User_;
DROP TABLE IF EXISTS Role_;
DROP TABLE IF EXISTS Group_;

CREATE TABLE Group_(
    id int(10) PRIMARY KEY AUTO_INCREMENT,
    num numeric NOT NULL,
    year numeric NOT NULL,
    sector varchar(50) NOT NULL
);

CREATE TABLE User_(
    id int(10) PRIMARY KEY AUTO_INCREMENT,
    password text NOT NULL,
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

CREATE TABLE VocabularyList(
    id int(10) PRIMARY KEY AUTO_INCREMENT,
    name varchar(30) NOT NULL,
    image text NOT NULL,
    userID int(10),
    FOREIGN KEY (userID) REFERENCES User_(id)
);

CREATE TABLE Practice(
    vocabID int(10),
    groupID int(10),
    FOREIGN KEY (vocabID) REFERENCES VocabularyList(id),
    FOREIGN KEY (groupID) REFERENCES Group_(id),
    PRIMARY KEY (vocabID, groupID)
);

CREATE TABLE Language(
    name varchar(30) PRIMARY KEY
);

CREATE TABLE Vocabulary(
    id int(10) PRIMARY KEY AUTO_INCREMENT,
    word varchar(255)
);

CREATE TABLE Translate(
    id int(10) PRIMARY KEY AUTO_INCREMENT,
    firstWordID int(10),
    secondWordID int(10),
    listVoc int(10),
    FOREIGN KEY (firstWordID) REFERENCES Vocabulary(id),
    FOREIGN KEY (secondWordID) REFERENCES Vocabulary(id),
    FOREIGN KEY (listVoc) REFERENCES VocabularyList(id)
);

CREATE TABLE Register(
    language varchar(30),
    idWord int(10),
    FOREIGN KEY (language) REFERENCES Language(name),
    FOREIGN KEY (idWord) REFERENCES Vocabulary(id),
    PRIMARY KEY (language, idWord)
);

INSERT INTO Role_ VALUES (1, 'admin');
INSERT INTO Role_ VALUES (2, 'teacher');
INSERT INTO Role_ VALUES (3, 'student');

INSERT INTO Language VALUES ('English');
INSERT INTO Language VALUES ('French');
