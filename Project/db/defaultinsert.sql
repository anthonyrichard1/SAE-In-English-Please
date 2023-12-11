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
INSERT INTO `group_` (`id`, `num`, `year`, `sector`) VALUES
(1, '1', '2022', 'Computer Science'),
(2, '2', '2023', 'Network Administration'),
(3, '1', '2023', 'Computer Science');

-- Users
INSERT INTO `user_` (`id`, `password`, `email`, `name`, `surname`, `nickname`, `image`, `extraTime`, `groupID`) VALUES
(1, '$2y$10$ZwmRqiLwb2.2QOyoXtgcYOhLX8ZF/f8eroxrsRJqMyF4uI/44VhR6', 'francois.dupont@etu.uca.fr', 'François', 'Dupont', 'dupfranc', '', 0, 1),
(3, '$2y$10$ZwmRqiLwb2.2QOyoXtgcYOhLX8ZF/f8eroxrsRJqMyF4uI/44VhR6', 'jean.bombeur@etu.uca.fr', 'Jean', 'Bombeur', 'jambombeurre', '', 0, 2),
(6, '$2y$10$ZwmRqiLwb2.2QOyoXtgcYOhLX8ZF/f8eroxrsRJqMyF4uI/44VhR6', 'tony.tonic@etu.uca.fr', 'Tony', 'Tonic', 'tonytonic', '', 0, 3),
(10, '$2y$10$RHgtbmnMWixD/ztTz55L9elDisjiyDy.NobsWa8L8pzYDgQYJGL.y', 'student@uca.fr', 'Student', 'UCA', 'student', '', NULL, 2),
(5, '$2y$10$ZwmRqiLwb2.2QOyoXtgcYOhLX8ZF/f8eroxrsRJqMyF4uI/44VhR6', 'michel.singinou@ext.uca.fr', 'Michel', 'Singinou', 'mich', '', NULL, NULL),
(20, '$2y$10$vvY7Dny2Qt0LdRgIxcZ.5uZ3LygRd1hMhqtjjj/v5tF57yos0JEmG', 'teacher@uca.fr', 'Teacher', 'UCA', 'teacher', '', NULL, NULL),
(30, '$2y$10$STTT3uR83dcwduiqqyKRde3b02LQi9iavkzn47NbA.xUrt92PalgW', 'admin@uca.fr', 'Admin', 'UCA', 'admin', '', NULL, NULL);

-- Role attribution
INSERT INTO `be` (`userID`, `roleID`) VALUES
(1, 3),
(3, 3),
(5, 2),
(6, 3),
(10, 3),
(20, 2),
(30, 1);

-- Vocabulary list
INSERT INTO `vocabularylist` (`id`, `name`, `image`, `userID`) VALUES
(1, 'Animaux', '', 5),
(2, 'Informatique', '', 5),
(3, 'Moyens de transport', '', 20),
(4, 'Entreprise', '', 20);

-- Vocabulary
INSERT INTO Vocabulary VALUES (1, "Chat");
INSERT INTO Vocabulary VALUES (2, "Chien");
INSERT INTO Vocabulary VALUES (3, "Lapin");
INSERT INTO Vocabulary VALUES (4, "Souris");
INSERT INTO Vocabulary VALUES (5, "Poisson");
INSERT INTO Vocabulary VALUES (6, "Ordinateur");
INSERT INTO Vocabulary VALUES (7, "Moto");

-- Register : FR
INSERT INTO Register VALUES ('French', 1);
INSERT INTO Register VALUES ('French', 2);
INSERT INTO Register VALUES ('French', 3);
INSERT INTO Register VALUES ('French', 4);
INSERT INTO Register VALUES ('French', 5);
INSERT INTO Register VALUES ('French', 6);
INSERT INTO Register VALUES ('French', 7);

-- Vocabulary creation : EN
INSERT INTO Vocabulary VALUES (8, "Cat");
INSERT INTO Vocabulary VALUES (9, "Dog");
INSERT INTO Vocabulary VALUES (10, "Rabbit");
INSERT INTO Vocabulary VALUES (11, "Mouse");
INSERT INTO Vocabulary VALUES (12, "Fish");
INSERT INTO Vocabulary VALUES (13, "Computer");
INSERT INTO Vocabulary VALUES (14, "Motorbike");

-- Register : EN
INSERT INTO Register VALUES ('English', 8);
INSERT INTO Register VALUES ('English', 9);
INSERT INTO Register VALUES ('English', 10);
INSERT INTO Register VALUES ('English', 11);
INSERT INTO Register VALUES ('English', 12);
INSERT INTO Register VALUES ('English', 13);
INSERT INTO Register VALUES ('English', 14);

-- Translate
INSERT INTO Translate VALUES (null, 1, 8, 1);
INSERT INTO Translate VALUES (null, 2, 9, 1);
INSERT INTO Translate VALUES (null, 3, 10, 1);
INSERT INTO Translate VALUES (null, 4, 11, 1);
INSERT INTO Translate VALUES (null, 5, 12, 1);

INSERT INTO Translate VALUES (null, 6, 13, 2);

INSERT INTO Translate VALUES (null, 7, 14, 3);

-- Practice
INSERT INTO Practice VALUES (1, 1);
INSERT INTO Practice VALUES (1, 2);

INSERT INTO Practice VALUES (2, 1);

INSERT INTO Practice VALUES (3, 3);

-- Vocabulary
INSERT INTO Vocabulary VALUES (21, "Corporate Headquarters / Head Office");
INSERT INTO Vocabulary VALUES (22, "Corporate Brochure");
INSERT INTO Vocabulary VALUES (23, "The Board of Directors");
INSERT INTO Vocabulary VALUES (24, "Boardroom");
INSERT INTO Vocabulary VALUES (25, "C.E.O (Chief Executive Officer)");
INSERT INTO Vocabulary VALUES (26, "The Facilities (a facility = a building)");
INSERT INTO Vocabulary VALUES (27, "Plant / Factory");
INSERT INTO Vocabulary VALUES (28, "Workshop");
INSERT INTO Vocabulary VALUES (29, "Warehouse");
INSERT INTO Vocabulary VALUES (30, "Fence");
INSERT INTO Vocabulary VALUES (31, "Lobby/Entrance Hall");
INSERT INTO Vocabulary VALUES (32, "Branch");
INSERT INTO Vocabulary VALUES (33, "Nationwide");
INSERT INTO Vocabulary VALUES (34, "Overseas / Abroad");
INSERT INTO Vocabulary VALUES (35, "Executives");
INSERT INTO Vocabulary VALUES (36, "Corporations Firms / Companies");
INSERT INTO Vocabulary VALUES (37, "The Chairman");
INSERT INTO Vocabulary VALUES (38, "Management");
INSERT INTO Vocabulary VALUES (39, "A Supplier");
INSERT INTO Vocabulary VALUES (40, "Retailer");

-- Register : EN
INSERT INTO Register VALUES ('English', 21);
INSERT INTO Register VALUES ('English', 22);
INSERT INTO Register VALUES ('English', 23);
INSERT INTO Register VALUES ('English', 24);
INSERT INTO Register VALUES ('English', 25);
INSERT INTO Register VALUES ('English', 26);
INSERT INTO Register VALUES ('English', 27);
INSERT INTO Register VALUES ('English', 28);
INSERT INTO Register VALUES ('English', 29);
INSERT INTO Register VALUES ('English', 30);
INSERT INTO Register VALUES ('English', 31);
INSERT INTO Register VALUES ('English', 32);
INSERT INTO Register VALUES ('English', 33);
INSERT INTO Register VALUES ('English', 34);
INSERT INTO Register VALUES ('English', 35);
INSERT INTO Register VALUES ('English', 36);
INSERT INTO Register VALUES ('English', 37);
INSERT INTO Register VALUES ('English', 38);
INSERT INTO Register VALUES ('English', 39);
INSERT INTO Register VALUES ('English', 40);

-- Vocabulary creation : FR
INSERT INTO Vocabulary VALUES (41, "le siège de la société");
INSERT INTO Vocabulary VALUES (42, "plaquette de la société");
INSERT INTO Vocabulary VALUES (43, "le conseil d’administration");
INSERT INTO Vocabulary VALUES (44, "salle du conseil");
INSERT INTO Vocabulary VALUES (45, "le PDG");
INSERT INTO Vocabulary VALUES (46, "les installations");
INSERT INTO Vocabulary VALUES (47, "usine");
INSERT INTO Vocabulary VALUES (48, "atelier");
INSERT INTO Vocabulary VALUES (49, "entrepôt, dépôt");
INSERT INTO Vocabulary VALUES (50, "clôture");
INSERT INTO Vocabulary VALUES (51, "l’entrée");
INSERT INTO Vocabulary VALUES (52, "agence");
INSERT INTO Vocabulary VALUES (53, "à l’échelle nationale");
INSERT INTO Vocabulary VALUES (54, "à l’étranger");
INSERT INTO Vocabulary VALUES (55, "les dirigeants");
INSERT INTO Vocabulary VALUES (56, "entreprises");
INSERT INTO Vocabulary VALUES (57, "président");
INSERT INTO Vocabulary VALUES (58, "la gestion, ou les cadres de l’entreprise");
INSERT INTO Vocabulary VALUES (59, "fournisseur");
INSERT INTO Vocabulary VALUES (60, "détaillant");

-- Register : FR
INSERT INTO Register VALUES ('French', 41);
INSERT INTO Register VALUES ('French', 42);
INSERT INTO Register VALUES ('French', 43);
INSERT INTO Register VALUES ('French', 44);
INSERT INTO Register VALUES ('French', 45);
INSERT INTO Register VALUES ('French', 46);
INSERT INTO Register VALUES ('French', 47);
INSERT INTO Register VALUES ('French', 48);
INSERT INTO Register VALUES ('French', 49);
INSERT INTO Register VALUES ('French', 50);
INSERT INTO Register VALUES ('French', 51);
INSERT INTO Register VALUES ('French', 52);
INSERT INTO Register VALUES ('French', 53);
INSERT INTO Register VALUES ('French', 54);
INSERT INTO Register VALUES ('French', 55);
INSERT INTO Register VALUES ('French', 56);
INSERT INTO Register VALUES ('French', 57);
INSERT INTO Register VALUES ('French', 58);
INSERT INTO Register VALUES ('French', 59);
INSERT INTO Register VALUES ('French', 60);

-- Translate
INSERT INTO Translate VALUES (null, 41, 21, 4);
INSERT INTO Translate VALUES (null, 42, 22, 4);
INSERT INTO Translate VALUES (null, 43, 23, 4);
INSERT INTO Translate VALUES (null, 44, 24, 4);
INSERT INTO Translate VALUES (null, 45, 25, 4);
INSERT INTO Translate VALUES (null, 46, 26, 4);
INSERT INTO Translate VALUES (null, 47, 27, 4);
INSERT INTO Translate VALUES (null, 48, 28, 4);
INSERT INTO Translate VALUES (null, 49, 29, 4);
INSERT INTO Translate VALUES (null, 50, 30, 4);
INSERT INTO Translate VALUES (null, 51, 31, 4);
INSERT INTO Translate VALUES (null, 52, 32, 4);
INSERT INTO Translate VALUES (null, 53, 33, 4);
INSERT INTO Translate VALUES (null, 54, 34, 4);
INSERT INTO Translate VALUES (null, 55, 35, 4);
INSERT INTO Translate VALUES (null, 56, 36, 4);
INSERT INTO Translate VALUES (null, 57, 37, 4);
INSERT INTO Translate VALUES (null, 58, 38, 4);
INSERT INTO Translate VALUES (null, 59, 39, 4);
INSERT INTO Translate VALUES (null, 60, 40, 4);