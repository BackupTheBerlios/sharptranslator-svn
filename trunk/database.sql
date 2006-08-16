drop table languages;
drop table words ;


-- languages
create table languages (
  id                        integer PRIMARY KEY AUTOINCREMENT,
  name                      varchar(20),
  UNIQUE(name)
) ;



-- words
create table words (
  id                        integer PRIMARY KEY AUTOINCREMENT,
  word                      varchar(200),
  sourcelang                integer,
  targetlang                integer,
  translation               varchar(200),
  UNIQUE(word, translation, sourcelang, targetlang)
) ;

create table expressions (
  id                        integer PRIMARY KEY AUTOINCREMENT,
  expression                varchar(200),
  sourcelang                integer,
  targetlang                integer,
  translation               varchar(200),
  UNIQUE(expression, translation, sourcelang, targetlang)
) ;


insert into languages values(  1,'Afar');
insert into languages values(  2,'Abkhazian');
insert into languages values(  3,'Avestan');
insert into languages values(  4,'Afrikaans');
insert into languages values(  5,'Amharic');
insert into languages values(  6,'Arabic');
insert into languages values(  7,'Assamese');
insert into languages values(  8,'Aymara');
insert into languages values(  9,'Azerbaijani');
insert into languages values( 10,'Bashkir');
insert into languages values( 11,'Belarusian');
insert into languages values( 12,'Bulgarian');
insert into languages values( 13,'Bihari');
insert into languages values( 14,'Bislama');
insert into languages values( 15,'Bengali');
insert into languages values( 16,'Tibetan');
insert into languages values( 17,'Breton');
insert into languages values( 18,'Bosnian');
insert into languages values( 19,'Catalan');
insert into languages values( 20,'Chechen');
insert into languages values( 21,'Chamorro');
insert into languages values( 22,'Corsican');
insert into languages values( 23,'Czech');
insert into languages values( 24,'Church Slavic');
insert into languages values( 25,'Chuvash');
insert into languages values( 26,'Welsh');
insert into languages values( 27,'Danish');
insert into languages values( 28,'German');
insert into languages values( 29,'Dzongkha');
insert into languages values( 30,'Greek');
insert into languages values( 31,'English');
insert into languages values( 32,'British English');
insert into languages values( 33,'American English');
insert into languages values( 34,'Esperanto');
insert into languages values( 35,'Spanish');
insert into languages values( 36,'Estonian');
insert into languages values( 37,'Basque');
insert into languages values( 38,'Farsi (Persian)');
insert into languages values( 39,'Finnish');
insert into languages values( 40,'Fijian');
insert into languages values( 41,'Faroese');
insert into languages values( 42,'French');
insert into languages values( 43,'Frisian');
insert into languages values( 44,'Irish Gaelic');
insert into languages values( 45,'Gaelic');
insert into languages values( 46,'Galician');
insert into languages values( 47,'Guarani');
insert into languages values( 48,'Gujarati');
insert into languages values( 49,'Manx');
insert into languages values( 50,'Hausa');
insert into languages values( 51,'Hebrew');
insert into languages values( 52,'Hindi');
insert into languages values( 53,'Hiri Motu');
insert into languages values( 54,'Croatian');
insert into languages values( 55,'Upper Sorbian');
insert into languages values( 56,'Hungarian');
insert into languages values( 57,'Armenian');
insert into languages values( 58,'Herero');
insert into languages values( 59,'Interlingua');
insert into languages values( 60,'Indonesian');
insert into languages values( 61,'Interlingue');
insert into languages values( 62,'Inupiaq');
insert into languages values( 63,'Ido');
insert into languages values( 64,'Icelandic');
insert into languages values( 65,'Italian');
insert into languages values( 66,'Inuktitut');
insert into languages values( 67,'Japanese');
insert into languages values( 68,'Javanese');
insert into languages values( 69,'Georgian');
insert into languages values( 70,'Kikuyu');
insert into languages values( 71,'Kazakh');
insert into languages values( 72,'Kalaallisut');
insert into languages values( 73,'Khmer');
insert into languages values( 74,'Kannada');
insert into languages values( 75,'Korean');
insert into languages values( 76,'Kashmiri');
insert into languages values( 77,'Kurdish');
insert into languages values( 78,'Komi');
insert into languages values( 79,'Cornish');
insert into languages values( 80,'Kirghiz');
insert into languages values( 81,'Latin');
insert into languages values( 82,'Luxembourgish');
insert into languages values( 83,'Limburgan');
insert into languages values( 84,'Lingala');
insert into languages values( 85,'Lao');
insert into languages values( 86,'Lithuanian');
insert into languages values( 87,'Latvian');
insert into languages values( 88,'Malagasy');
insert into languages values( 89,'Marshallese');
insert into languages values( 90,'Maori');
insert into languages values( 91,'Macedonian');
insert into languages values( 92,'Malayalam');
insert into languages values( 93,'Mongolian');
insert into languages values( 94,'Moldavian');
insert into languages values( 95,'Marathi');
insert into languages values( 96,'Malay');
insert into languages values( 97,'Maltese');
insert into languages values( 98,'Burmese');
insert into languages values( 99,'Nauru');
insert into languages values(100,'Norwegian Bokmål');
insert into languages values(101,'Ndebele, North');
insert into languages values(102,'Low Saxon');
insert into languages values(103,'Nepali');
insert into languages values(104,'Ndonga');
insert into languages values(105,'Dutch');
insert into languages values(106,'Norwegian Nynorsk');
insert into languages values(107,'Ndebele, South');
insert into languages values(108,'Northern Sotho');
insert into languages values(109,'Navajo');
insert into languages values(110,'Chichewa');
insert into languages values(111,'Occitan');
insert into languages values(112,'Oromo');
insert into languages values(113,'Oriya');
insert into languages values(114,'Ossetian');
insert into languages values(115,'Panjabi');
insert into languages values(116,'Pali');
insert into languages values(117,'Polish');
insert into languages values(118,'Pushto');
insert into languages values(119,'Portuguese');
insert into languages values(120,'Brazilian Portuguese');
insert into languages values(121,'Quechua');
insert into languages values(122,'Rundi');
insert into languages values(123,'Romanian');
insert into languages values(124,'Romany');
insert into languages values(125,'Russian');
insert into languages values(126,'Kinyarwanda');
insert into languages values(127,'Sanskrit');
insert into languages values(128,'Sardinian');
insert into languages values(129,'Sindhi');
insert into languages values(130,'Northern Sami');
insert into languages values(131,'Sango');
insert into languages values(132,'Sinhalese');
insert into languages values(133,'Slovak');
insert into languages values(134,'Slovenian');
insert into languages values(135,'Samoan');
insert into languages values(136,'Shona');
insert into languages values(137,'Somali');
insert into languages values(138,'Albanian');
insert into languages values(139,'Serbian');
insert into languages values(140,'Serbian Latin');
insert into languages values(141,'Swati');
insert into languages values(142,'Sotho, Southern');
insert into languages values(143,'Sundanese');
insert into languages values(144,'Swedish');
insert into languages values(145,'Swahili');
insert into languages values(146,'Tamil');
insert into languages values(147,'Telugu');
insert into languages values(148,'Tajik');
insert into languages values(149,'Thai');
insert into languages values(150,'Tigrinya');
insert into languages values(151,'Turkmen');
insert into languages values(152,'Tswana');
insert into languages values(153,'Tonga');
insert into languages values(154,'Turkish');
insert into languages values(155,'Tsonga');
insert into languages values(156,'Tatar');
insert into languages values(157,'Twi');
insert into languages values(158,'Tahitian');
insert into languages values(159,'Uighur');
insert into languages values(160,'Ukrainian');
insert into languages values(161,'Urdu');
insert into languages values(162,'Uzbek');
insert into languages values(163,'Venda');
insert into languages values(164,'Vietnamese');
insert into languages values(165,'Volapük');
insert into languages values(166,'Walloon');
insert into languages values(167,'Wolof');
insert into languages values(168,'Xhosa');
insert into languages values(169,'Yiddish');
insert into languages values(170,'Yoruba');
insert into languages values(171,'Zhuang');
insert into languages values(172,'Chinese');
insert into languages values(173,'Chinese Simplified');
insert into languages values(174,'Chinese (Hong Kong)');
insert into languages values(175,'Chinese Traditional');
insert into languages values(176,'Zulu');


--	CONSTRAINT KEY(LANG) REFERENCES LANGUAGES(ID)

--	CONSTRAINT KEY(LANG) REFERENCES LANGUAGES(ID),
--	CONSTRAINT KEY(SOURCE) REFERENCES WORDS(ID)




