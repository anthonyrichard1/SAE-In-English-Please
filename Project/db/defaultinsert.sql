-- Delete all data
DELETE FROM Translate;
DELETE FROM Register;
DELETE FROM Practice;
DELETE FROM Be;
DELETE FROM VocabularyList;
DELETE FROM Vocabulary;
DELETE FROM User_;
DELETE FROM Group_;

-- Group
INSERT INTO Group_ VALUES (1, 1, 2022, "Computer Science");
INSERT INTO Group_ VALUES (2, 2, 2023, "Network Administration");
INSERT INTO Group_ VALUES (3, 1, 2023, "Computer Science");

-- User : student
INSERT INTO User_ VALUES (1, "Password*123", "francois.dupont@etu.uca.fr", "François", "Dupont", "dupfranc", "", false, 1);
INSERT INTO User_ VALUES (2, "Password*123", "sylvain.volvic@etu.uca.fr", "Sylvain", "Volvic", "sylvaincpt", "", true, 1);
INSERT INTO User_ VALUES (3, "Password*123", "jean.bombeur@etu.uca.fr", "Jean", "Bombeur", "jambombeurre", "", false, 2);
INSERT INTO User_ VALUES (6, "Password*123", "tony.tonic@etu.uca.fr", "Tony", "Tonic", "tonytonic", "", false, 3);
INSERT INTO User_ VALUES (10, "$2y$10$RHgtbmnMWixD/ztTz55L9elDisjiyDy.NobsWa8L8pzYDgQYJGL.y", "student@uca.fr", "Student", "UCA", "student", "", NULL, NULL);

-- User : teacher
INSERT INTO User_ VALUES (5, "Password*123", "michel.singinou@ext.uca.fr", "Michel", "Singinou", "mich", "", NULL, NULL);
INSERT INTO User_ VALUES (20, "$2y$10$vvY7Dny2Qt0LdRgIxcZ.5uZ3LygRd1hMhqtjjj/v5tF57yos0JEmG", "teacher@uca.fr", "Teacher", "UCA", "teacher", "", NULL, NULL);

-- User : admin
INSERT INTO User_ VALUES (30, "$2y$10$STTT3uR83dcwduiqqyKRde3b02LQi9iavkzn47NbA.xUrt92PalgW", "admin@uca.fr", "Admin", "UCA", "admin", "", NULL, NULL);

-- Role attribution
INSERT INTO Be VALUES (1, 3);
INSERT INTO Be VALUES (2, 3);
INSERT INTO Be VALUES (3, 3);
INSERT INTO Be VALUES (6, 3);
INSERT INTO Be VALUES (10, 3);


INSERT INTO Be VALUES (4, 1);
INSERT INTO Be VALUES (4, 2);
INSERT INTO Be VALUES (20, 2);

INSERT INTO Be VALUES (5, 2);
INSERT INTO Be VALUES (30, 1);

-- Vocabulary list
INSERT INTO VocabularyList VALUES (1, "Animaux", "", 5);
INSERT INTO VocabularyList VALUES (2, "Informatique", "", 5);
INSERT INTO VocabularyList VALUES (3, "Moyens de transport", "", 4);

-- Vocabulary creation : FR
INSERT INTO Vocabulary VALUES ("Chat");
INSERT INTO Vocabulary VALUES ("Chien");
INSERT INTO Vocabulary VALUES ("Ordinateur");
INSERT INTO Vocabulary VALUES ("Moto");
-- Register : FR
INSERT INTO Register VALUES ("French", "Chat");
INSERT INTO Register VALUES ("French", "Chien");
INSERT INTO Register VALUES ("French", "Ordinateur");
INSERT INTO Register VALUES ("French", "Moto");

-- Vocabulary creation : EN
INSERT INTO Vocabulary VALUES ("Cat");
INSERT INTO Vocabulary VALUES ("Dog");
INSERT INTO Vocabulary VALUES ("Computer");
INSERT INTO Vocabulary VALUES ("Bike");
INSERT INTO Vocabulary VALUES ("Motorbike");
-- Register : EN
INSERT INTO Register VALUES ("English", "Cat");
INSERT INTO Register VALUES ("English", "Dog");
INSERT INTO Register VALUES ("English", "Computer");
INSERT INTO Register VALUES ("English", "Bike");
INSERT INTO Register VALUES ("English", "Motorbike");

-- Translate
INSERT INTO Translate VALUES (null, "Chat", "Cat", 1);
INSERT INTO Translate VALUES (null, "Chien", "Dog", 1);

INSERT INTO Translate VALUES (null, "Ordinateur", "Computer", 2);

INSERT INTO Translate VALUES (null, "Moto", "Bike", 3);
INSERT INTO Translate VALUES (null, "Moto", "Motorbike", 3);

-- Practice
INSERT INTO Practice VALUES (1, 1);
INSERT INTO Practice VALUES (1, 2);

INSERT INTO Practice VALUES (2, 1);

INSERT INTO Practice VALUES (3, 3);
