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

INSERT INTO Be VALUES (20, 2);

INSERT INTO Be VALUES (5, 2);
INSERT INTO Be VALUES (30, 1);

-- Vocabulary list
INSERT INTO VocabularyList VALUES (1, "Animaux", "", 5);
INSERT INTO VocabularyList VALUES (2, "Informatique", "", 5);
INSERT INTO VocabularyList VALUES (3, "Moyens de transport", "", 20);

-- Vocabulary creation : FR
INSERT INTO Vocabulary VALUES ("Chat");
INSERT INTO Vocabulary VALUES ("Chien");
INSERT INTO Vocabulary VALUES ("Lapin");
INSERT INTO Vocabulary VALUES ("Souris");
INSERT INTO Vocabulary VALUES ("Poisson");
INSERT INTO Vocabulary VALUES ("Ordinateur");
INSERT INTO Vocabulary VALUES ("Moto");
-- Register : FR
INSERT INTO Register VALUES ("French", "Chat");
INSERT INTO Register VALUES ("French", "Chien");
INSERT INTO Register VALUES ("French", "Ordinateur");
INSERT INTO Register VALUES ("French", "Moto");
INSERT INTO Register VALUES ("French", "Lapin");
INSERT INTO Register VALUES ("French", "Souris");
INSERT INTO Register VALUES ("French", "Poisson");

-- Vocabulary creation : EN
INSERT INTO Vocabulary VALUES ("Cat");
INSERT INTO Vocabulary VALUES ("Dog");
INSERT INTO Vocabulary VALUES ("Rabbit");
INSERT INTO Vocabulary VALUES ("Mouse");
INSERT INTO Vocabulary VALUES ("Fish");
INSERT INTO Vocabulary VALUES ("Computer");
INSERT INTO Vocabulary VALUES ("Motorbike");
-- Register : EN
INSERT INTO Register VALUES ("English", "Cat");
INSERT INTO Register VALUES ("English", "Dog");
INSERT INTO Register VALUES ("English", "Rabbit");
INSERT INTO REGISTER VALUES ("English", "Mouse");
INSERT INTO REGISTER VALUES ("English", "Fish");
INSERT INTO Register VALUES ("English", "Computer");
INSERT INTO Register VALUES ("English", "Motorbike");

-- Translate
INSERT INTO Translate VALUES (null, "Chat", "Cat", 1);
INSERT INTO Translate VALUES (null, "Chien", "Dog", 1);
INSERT INTO Translate VALUES (null, "Lapin", "Rabbit", 1);
INSERT INTO Translate VALUES (null, "Souris", "Mouse", 1);
INSERT INTO Translate VALUES (null, "Poisson", "Fish", 1);

INSERT INTO Translate VALUES (null, "Ordinateur", "Computer", 2);

INSERT INTO Translate VALUES (null, "Moto", "Motorbike", 3);

-- Practice
INSERT INTO Practice VALUES (1, 1);
INSERT INTO Practice VALUES (1, 2);

INSERT INTO Practice VALUES (2, 1);

INSERT INTO Practice VALUES (3, 3);

-- FROM THE MAIL
INSERT INTO VocabularyList VALUES(4, "Entreprise", "", 5);

-- Vocabulary creation : EN
INSERT INTO Vocabulary VALUES ("Corporate Headquarters / Head Office");
INSERT INTO Vocabulary VALUES ("Corporate Brochure");
INSERT INTO Vocabulary VALUES ("The Board of Directors");
INSERT INTO Vocabulary VALUES ("Boardroom");
INSERT INTO Vocabulary VALUES ("C.E.O (Chief Executive Officer)");
INSERT INTO Vocabulary VALUES ("The Facilities (a facility = a building)");
INSERT INTO Vocabulary VALUES ("Plant / Factory");
INSERT INTO Vocabulary VALUES ("Workshop");
INSERT INTO Vocabulary VALUES ("Warehouse");
INSERT INTO Vocabulary VALUES ("Fence");
INSERT INTO Vocabulary VALUES ("Lobby/Entrance Hall");
INSERT INTO Vocabulary VALUES ("Branch");
INSERT INTO Vocabulary VALUES ("Nationwide");
INSERT INTO Vocabulary VALUES ("Overseas / Abroad");
INSERT INTO Vocabulary VALUES ("Executives");
INSERT INTO Vocabulary VALUES ("Corporations Firms / Companies");
INSERT INTO Vocabulary VALUES ("The Chairman");
INSERT INTO Vocabulary VALUES ("Management");
INSERT INTO Vocabulary VALUES ("A Supplier");
INSERT INTO Vocabulary VALUES ("Retailer");

-- Register : EN
INSERT INTO Register VALUES ("English", "Corporate Headquarters / Head Office");
INSERT INTO Register VALUES ("English", "Corporate Brochure");
INSERT INTO Register VALUES ("English", "The Board of Directors");
INSERT INTO Register VALUES ("English", "Boardroom");
INSERT INTO Register VALUES ("English", "C.E.O (Chief Executive Officer)");
INSERT INTO Register VALUES ("English", "The Facilities (a facility = a building)");
INSERT INTO Register VALUES ("English", "Plant / Factory");
INSERT INTO Register VALUES ("English", "Workshop");
INSERT INTO Register VALUES ("English", "Warehouse");
INSERT INTO Register VALUES ("English", "Fence");
INSERT INTO Register VALUES ("English", "Lobby/Entrance Hall");
INSERT INTO Register VALUES ("English", "Branch");
INSERT INTO Register VALUES ("English", "Nationwide");
INSERT INTO Register VALUES ("English", "Overseas / Abroad");
INSERT INTO Register VALUES ("English", "Executives");
INSERT INTO Register VALUES ("English", "Corporations Firms / Companies");
INSERT INTO Register VALUES ("English", "The Chairman");
INSERT INTO Register VALUES ("English", "Management");
INSERT INTO Register VALUES ("English", "A Supplier");
INSERT INTO Register VALUES ("English", "Retailer");

-- Vocabulary creation : FR
INSERT INTO Vocabulary VALUES ("le siège de la société");
INSERT INTO Vocabulary VALUES ("plaquette de la société");
INSERT INTO Vocabulary VALUES ("le conseil d’administration");
INSERT INTO Vocabulary VALUES ("salle du conseil");
INSERT INTO Vocabulary VALUES ("le PDG");
INSERT INTO Vocabulary VALUES ("les installations");
INSERT INTO Vocabulary VALUES ("usine");
INSERT INTO Vocabulary VALUES ("atelier");
INSERT INTO Vocabulary VALUES ("entrepôt, dépôt");
INSERT INTO Vocabulary VALUES ("clôture");
INSERT INTO Vocabulary VALUES ("l’entrée");
INSERT INTO Vocabulary VALUES ("agence");
INSERT INTO Vocabulary VALUES ("à l’échelle nationale");
INSERT INTO Vocabulary VALUES ("à l’étranger");
INSERT INTO Vocabulary VALUES ("les dirigeants");
INSERT INTO Vocabulary VALUES ("entreprises");
INSERT INTO Vocabulary VALUES ("président");
INSERT INTO Vocabulary VALUES ("la gestion, ou les cadres de l’entreprise");
INSERT INTO Vocabulary VALUES ("fournisseur");
INSERT INTO Vocabulary VALUES ("détaillant");

-- Register : FR
INSERT INTO Register VALUES ("French", "le siège de la société");
INSERT INTO Register VALUES ("French", "plaquette de la société");
INSERT INTO Register VALUES ("French", "le conseil d’administration");
INSERT INTO Register VALUES ("French", "salle du conseil");
INSERT INTO Register VALUES ("French", "le PDG");
INSERT INTO Register VALUES ("French", "les installations");
INSERT INTO Register VALUES ("French", "usine");
INSERT INTO Register VALUES ("French", "atelier");
INSERT INTO Register VALUES ("French", "entrepôt, dépôt");
INSERT INTO Register VALUES ("French", "clôture");
INSERT INTO Register VALUES ("French", "l’entrée");
INSERT INTO Register VALUES ("French", "agence");
INSERT INTO Register VALUES ("French", "à l’échelle nationale");
INSERT INTO Register VALUES ("French", "à l’étranger");
INSERT INTO Register VALUES ("French", "les dirigeants");
INSERT INTO Register VALUES ("French", "entreprises");
INSERT INTO Register VALUES ("French", "président");
INSERT INTO Register VALUES ("French", "la gestion, ou les cadres de l’entreprise");
INSERT INTO Register VALUES ("French", "fournisseur");
INSERT INTO Register VALUES ("French", "détaillant");

-- Translate
INSERT INTO Translate VALUES (null, "le siège de la société", "Corporate Headquarters / Head Office", 4);
INSERT INTO Translate VALUES (null, "plaquette de la société", "Corporate Brochure", 4);
INSERT INTO Translate VALUES (null, "le conseil d’administration", "The Board of Directors", 4);
INSERT INTO Translate VALUES (null, "salle du conseil", "Boardroom", 4);
INSERT INTO Translate VALUES (null, "le PDG", "C.E.O (Chief Executive Officer)", 4);
INSERT INTO Translate VALUES (null, "les installations", "The Facilities (a facility = a building)", 4);
INSERT INTO Translate VALUES (null, "usine", "Plant / Factory", 4);
INSERT INTO Translate VALUES (null, "atelier", "Workshop", 4);
INSERT INTO Translate VALUES (null, "entrepôt, dépôt", "Warehouse", 4);
INSERT INTO Translate VALUES (null, "clôture", "Fence", 4);
INSERT INTO Translate VALUES (null, "l’entrée", "Lobby/Entrance Hall", 4);
INSERT INTO Translate VALUES (null, "agence", "Branch", 4);
INSERT INTO Translate VALUES (null, "à l’échelle nationale", "Nationwide", 4);
INSERT INTO Translate VALUES (null, "à l’étranger", "Overseas / Abroad", 4);
INSERT INTO Translate VALUES (null, "les dirigeants", "Executives", 4);
INSERT INTO Translate VALUES (null, "entreprises", "Corporations Firms / Companies", 4);
INSERT INTO Translate VALUES (null, "président", "The Chairman", 4);
INSERT INTO Translate VALUES (null, "la gestion, ou les cadres de l’entreprise", "Management", 4);
INSERT INTO Translate VALUES (null, "fournisseur", "A Supplier", 4);
INSERT INTO Translate VALUES (null, "détaillant", "Retailer", 4);