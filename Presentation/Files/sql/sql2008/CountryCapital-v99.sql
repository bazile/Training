/*

    СТОЛИЦЫ И ГОРОДА СТРАН МИРА

    - Страны и города в отдельных таблицах
	- Флаг страны
	- Дата независимости
	- Население страны и города
    - Координаты городов в geography типе данных

*/

USE master
GO
CREATE DATABASE BelhardTraining
    COLLATE Cyrillic_General_CI_AI
GO
USE BelhardTraining
GO

CREATE TABLE PartOfWorld
(
    Id   int         IDENTITY(1,1) PRIMARY KEY,
    Name varchar(20) NOT NULL UNIQUE
)
GO

CREATE TABLE Country
(
    Id            int             IDENTITY(1,1) PRIMARY KEY,
    PartOfWorldId int             NOT NULL,
    CapitalId     int             NULL,
    Name          nvarchar(50)    NOT NULL UNIQUE,
    [Population]  int             NULL,
    UNMemberSince date            NULL,
    IndepenceDate date            NULL,
    TLD           char(3)         NULL,
    Flag          varbinary(2000) NULL,
)
GO

ALTER TABLE dbo.Country
    ADD CONSTRAINT FK_Country_PartOfWorld
    FOREIGN KEY (PartOfWorldId) REFERENCES PartOfWorld(Id)
    ON UPDATE NO ACTION
    ON DELETE NO ACTION
GO

CREATE TABLE City
(
    Id            int          IDENTITY(1,1) PRIMARY KEY,
    CountryId     int          NOT NULL,
    Name          varchar(30)  NOT NULL,
    IsCapital     bit          NOT NULL DEFAULT(0),
    [Population]  int          NULL,
    Coordinates   geography    NULL,
    OfficialSite  varchar(100) NULL,
)
GO

ALTER TABLE dbo.City
    ADD CONSTRAINT FK_City_Country
    FOREIGN KEY (CountryId) REFERENCES Country(Id)
    ON UPDATE NO ACTION
    ON DELETE NO ACTION
ALTER TABLE dbo.Country
    ADD CONSTRAINT FK_Country_Capital
    FOREIGN KEY (CapitalId) REFERENCES City(Id)
    ON UPDATE NO ACTION
    ON DELETE NO ACTION
GO

-- ================================================================================
--  INSERT DATA
-- ================================================================================
INSERT INTO PartOfWorld (Name)
    VALUES ('Австралия и Океания')
         , ('Европа')
         , ('Азия')
         , ('Африка')
         , ('Северная Америка')
         , ('Южная Америка')
         , ('Америка')
         , ('Центральная Америка')
         , ('Евразия')
GO

INSERT INTO Country (PartOfWorldId, Name, [Population], UNMemberSince, TLD)
    VALUES (1, 'Австралия'                                   ,   23367525, '1945-11-01', '.au') 
         , (2, 'Австрия'                                     ,    8572895, '1955-12-14', '.at') 
         , (3, 'Азербайджан'                                 ,    3897889, '1992-03-02', '.az') 
         , (2, 'Албания'                                     ,    3020209, '1955-12-14', '.al') 
         , (4, 'Алжир'                                       ,   38813722, '1962-10-08', '.dz') 
         , (4, 'Ангола'                                      ,    4965988, '1976-12-01', '.ao') 
         , (2, 'Андорра'                                     ,      13414, '1993-07-28', '.ad') 
         , (5, 'Антигуа и Барбуда'                           ,      54681, '1981-11-11', '.ag') 
         , (6, 'Аргентина'                                   ,   43417000, '1945-10-24', '.ar') 
         , (2, 'Армения'                                     ,    1867396, '1992-03-02', '.am') 
         , (3, 'Афганистан'                                  ,   31822848, '1946-11-19', '.af') 
         , (5, 'Багамские Острова'                           ,     109526, '1973-09-18', '.bs') 
         , (3, 'Бангладеш'                                   ,   49537147, '1974-09-17', '.bd') 
         , (5, 'Барбадос'                                    ,     230858, '1966-12-09', '.bb') 
         , (3, 'Бахрейн'                                     ,     162501, '1971-09-21', '.bh') 
         , (5, 'Белиз'                                       ,     324528, '1981-09-25', '.bz') 
         , (2, 'Белоруссия'                                  ,    9475100, '1945-10-24', '.by') 
         , (2, 'Бельгия'                                     ,   11150516, '1945-12-27', '.be') 
         , (4, 'Бенин'                                       ,    2431620, '1960-09-20', '.bj') 
         , (2, 'Болгария'                                    ,    7867374, '1955-12-14', '.bg') 
         , (6, 'Боливия'                                     ,    3353125, '1945-11-14', '.bo') 
         , (2, 'Босния и Герцеговина'                        ,    3531159, '1992-05-22', '.ba') 
         , (4, 'Ботсвана'                                    ,     524173, '1966-10-17', '.bw') 
         , (6, 'Бразилия'                                    ,  202656788, '1945-10-24', '.br') 
         , (3, 'Бруней'                                      ,      81817, '1984-09-21', '.bn') 
         , (4, 'Буркина-Фасо'                                ,    4829291, '1960-09-20', '.bf') 
         , (4, 'Бурунди'                                     ,    2786740, '1962-09-18', '.bi') 
         , (3, 'Бутан'                                       ,     224155, '1971-09-21', '.bt') 
         , (1, 'Вануату'                                     ,      63701, '1981-09-15', '.vu') 
         , (2, 'Ватикан'                                     ,       NULL, NULL, '.va') 
         , (2, 'Великобритания'                              ,   63181775, '1945-10-24', '.uk') 
         , (2, 'Венгрия'                                     ,    9983967, '1955-12-14', '.hu') 
         , (6, 'Венесуэла'                                   ,   28868486, '1945-11-15', '.ve') 
         , (3, 'Восточный Тимор'                             ,     499681, '2002-09-27', '.tl') 
         , (3, 'Вьетнам'                                     ,       NULL, '1977-09-20', '.vn') 
         , (4, 'Габон'                                       ,     498823, '1960-09-20', '.ga') 
         , (6, 'Гайана'                                      ,     560296, '1966-09-20', '.gy') 
         , (4, 'Гамбия'                                      ,     367929, '1965-09-21', '.gm') 
         , (4, 'Гана'                                        ,    6652516, '1957-03-08', '.gh') 
         , (5, 'Гватемала'                                   ,    4140636, '1945-11-21', '.gt') 
         , (4, 'Гвинея'                                      ,   10628972, '1958-12-12', '.gn') 
         , (4, 'Гвинея-Бисау'                                ,     635956, '1974-09-17', '.gw') 
         , (2, 'Германия'                                    ,   80500000, '1973-09-18', '.de') 
         , (5, 'Гондурас'                                    ,    2002333, '1945-12-17', '.hn') 
         , (5, 'Гренада'                                     ,      89861, '1974-09-17', '.gd') 
         , (2, 'Греция'                                      ,   10815197, '1945-10-25', '.gr') 
         , (3, 'Грузия'                                      ,    3729500, '1992-07-31', '.ge') 
         , (2, 'Дания'                                       ,    5639719, '1945-10-24', '.dk') 
         , (4, 'Джибути'                                     ,      83636, '1977-09-20', '.dj') 
         , (5, 'Доминика'                                    ,      60016, '1978-12-18', '.dm') 
         , (7, 'Доминиканская Республика'                    ,    3311788, '1945-10-24', '.do') 
         , (4, 'ДР Конго'                                    ,   15248246, '1960-09-20', '.cd') 
         , (4, 'Египет'                                      ,   27997745, '1945-10-24', '.eg') 
         , (4, 'Замбия'                                      ,   14309466, '1964-12-01', '.zm') 
         , (4, 'Зимбабве'                                    ,    3752390, '1980-08-25', '.zw') 
         , (3, 'Йемен'                                       ,   19685161, '1947-09-30', '.ye') 
         , (3, 'Израиль'                                     ,    8296900, '1949-05-11', '.il') 
         , (3, 'Индия'                                       , 1263200000, '1945-10-30', '.in') 
         , (3, 'Индонезия'                                   ,   88692697, '1950-09-28', '.id') 
         , (3, 'Иордания'                                    ,       NULL, '1955-12-14', '.jo') 
         , (3, 'Ирак'                                        ,    7289759, '1945-12-21', '.iq') 
         , (3, 'Иран'                                        ,   21958460, '1945-10-24', '.ir') 
         , (2, 'Ирландия'                                    ,    4593100, '1955-12-14', '.ie') 
         , (2, 'Исландия'                                    ,     317351, '1946-11-19', '.is') 
         , (2, 'Испания'                                     ,   30455000, '1955-12-14', '.es') 
         , (2, 'Италия'                                      ,   50199700, '1955-12-14', '.it') 
         , (4, 'Кабо-Верде'                                  ,     212247, '1975-09-16', '.cv') 
         , (3, 'Казахстан'                                   ,   17948816, '1992-03-02', '.kz') 
         , (3, 'Камбоджа'                                    ,    5720019, '1955-12-14', '.kh') 
         , (4, 'Камерун'                                     ,    5361367, '1960-09-20', '.cm') 
         , (5, 'Канада'                                      ,   35158300, '1945-11-09', '.ca') 
         , (3, 'Катар'                                       ,      47316, '1971-09-21', '.qa') 
         , (4, 'Кения'                                       ,    8105440, '1963-12-16', '.ke') 
         , (3, 'Кипр'                                        ,     572929, '1960-09-20', '.cy') 
         , (3, 'Киргизия'                                    ,       NULL, '1992-03-02', '.kg') 
         , (1, 'Кирибати'                                    ,      32970, '1999-09-14', '.ki') 
         , (3, 'Китайская Народная Республика'               , 1350695000, '1945-10-24', '.cn') 
         , (3, 'Китайская Республика'                        ,       NULL, NULL, '.tw') 
         , (6, 'Колумбия'                                    ,   16006395, '1945-11-05', '.co') 
         , (4, 'Коморы'                                      ,     190475, '1975-11-12', '.km') 
         , (3, 'Корейская Народно-Демократическая Республика',   24554000, '1991-09-17', '.kp') 
         , (5, 'Коста-Рика'                                  ,    1334044, '1945-11-02', '.cr') 
         , (4, 'Кот-д’Ивуар'                                 ,    3474724, '1960-09-20', '.ci') 
         , (8, 'Куба'                                        ,    7141130, '1945-10-24', '.cu') 
         , (3, 'Кувейт'                                      ,       NULL, '1963-05-14', '.kw') 
         , (3, 'Лаос'                                        ,    2119731, '1955-12-14', '.la') 
         , (2, 'Латвия'                                      ,    1989500, '1991-09-17', '.lv') 
         , (4, 'Лесото'                                      ,     851412, '1966-10-17', '.ls') 
         , (4, 'Либерия'                                     ,    1120314, '1945-11-02', '.lr') 
         , (3, 'Ливан'                                       ,    1804927, '1945-10-24', '.lb') 
         , (4, 'Ливия'                                       ,    1428435, '1955-12-14', '.ly') 
         , (2, 'Литва'                                       ,    3043429, '1991-09-17', '.lt') 
         , (2, 'Лихтенштейн'                                 ,      16504, '1990-09-18', '.li') 
         , (2, 'Люксембург'                                  ,     313970, '1945-10-24', '.lu') 
         , (4, 'Маврикий'                                    ,     659351, '1968-04-24', '.mu') 
         , (4, 'Мавритания'                                  ,     858316, '1961-10-27', '.mr') 
         , (4, 'Мадагаскар'                                  ,    5099371, '1960-09-20', '.mg') 
         , (4, 'Малави'                                      ,    3525127, '1964-12-01', '.mw') 
         , (3, 'Малайзия'                                    ,   30018242, '1957-09-17', '.my') 
         , (4, 'Мали'                                        ,    5098942, '1960-09-28', '.ml') 
         , (3, 'Мальдивы'                                    ,      88960, '1965-09-21', '.mv') 
         , (2, 'Мальта'                                      ,     326550, '1964-12-01', '.mt') 
         , (4, 'Марокко'                                     ,   12328534, '1956-11-12', '.ma') 
         , (1, 'Маршалловы Острова'                          ,      14665, '1991-09-17', '.mh') 
         , (5, 'Мексика'                                     ,  120286655, '1945-11-07', '.mx') 
         , (1, 'Микронезия'                                  ,      44539, '1991-09-17', '.fm') 
         , (4, 'Мозамбик'                                    ,    7647284, '1975-09-16', '.mz') 
         , (2, 'Молдавия'                                    ,       NULL, '1992-03-02', '.md') 
         , (2, 'Монако'                                      ,      18125, '1993-05-28', '.mc') 
         , (3, 'Монголия'                                    ,    2953190, '1961-10-27', '.mn') 
         , (3, 'Мьянма'                                      ,   21486424, '1948-04-19', '.mm') 
         , (4, 'Намибия'                                     ,     602545, '1990-04-23', '.na') 
         , (1, 'Науру'                                       ,      10084, '1999-09-14', '.nr') 
         , (3, 'Непал'                                       ,   26494504, '1955-12-14', '.np') 
         , (4, 'Нигер'                                       ,    3337141, '1960-09-20', '.ne') 
         , (4, 'Нигерия'                                     ,   45211614, '1960-10-07', '.ng') 
         , (2, 'Нидерланды'                                  ,   16829289, '1945-12-10', '.nl') 
         , (5, 'Никарагуа'                                   ,    1774574, '1945-10-24', '.ni') 
         , (1, 'Новая Зеландия'                              ,       NULL, '1945-10-24', '.nz') 
         , (2, 'Норвегия'                                    ,    5124383, '1945-11-27', '.no') 
         , (3, 'Объединённые Арабские Эмираты'               ,      89608, '1971-12-09', '.ae') 
         , (3, 'Оман'                                        ,     551737, NULL, '.om') 
         , (3, 'Пакистан'                                    ,   45540594, '1947-09-30', '.pk') 
         , (1, 'Палау'                                       ,       9638, '1994-12-15', '.pw') 
         , (8, 'Панама'                                      ,    1136090, '1945-11-13', '.pa') 
         , (1, 'Папуа — Новая Гвинея'                        ,    1966957, '1975-10-10', '.pg') 
         , (6, 'Парагвай'                                    ,    6455000, '1945-10-24', '.py') 
         , (6, 'Перу'                                        ,    9931518, '1945-10-31', '.pe') 
         , (2, 'Польша'                                      ,   38483957, '1945-10-24', '.pl') 
         , (2, 'Португалия'                                  ,    8857716, '1955-12-14', '.pt') 
         , (5, 'Республика Гаити'                            ,    3869288, '1945-10-24', '.ht') 
         , (4, 'Республика Конго'                            ,    1013581, '1960-09-20', '.cg') 
         , (3, 'Республика Корея'                            ,   25012374, '1991-09-17', '.kr') 
         , (2, 'Республика Косово'                           ,       NULL, NULL, NULL) 
         , (2, 'Республика Македония'                        ,    1471139, '1993-04-08', '.mk') 
         , (9, 'Россия'                                      ,  143666931, '1945-10-24', '.ru') 
         , (4, 'Руанда'                                      ,    2933424, '1962-09-18', '.rw') 
         , (2, 'Румыния'                                     ,   18406905, '1955-12-14', '.ro') 
         , (5, 'Сальвадор'                                   ,    2772970, '1945-10-24', '.sv') 
         , (1, 'Самоа'                                       ,     108645, '1976-12-15', '.ws') 
         , (2, 'Сан-Марино'                                  ,      15393, '1992-03-02', '.sm') 
         , (4, 'Сан-Томе и Принсипи'                         ,      64255, '1975-09-16', '.st') 
         , (3, 'Саудовская Аравия'                           ,    4072110, '1945-10-24', '.sa') 
         , (4, 'Свазиленд'                                   ,     349233, '1968-09-24', '.sz') 
         , (4, 'Сейшелы'                                     ,       NULL, '1976-09-21', '.sc') 
         , (4, 'Сенегал'                                     ,    3177737, '1960-09-28', '.sn') 
         , (6, 'Сент-Винсент и Гренадины'                    ,      80948, '1980-09-16', '.vc') 
         , (5, 'Сент-Китс и Невис'                           ,      51197, '1983-09-23', '.kn') 
         , (5, 'Сент-Люсия'                                  ,      89901, '1979-09-18', '.lc') 
         , (2, 'Сербия'                                      ,       NULL, '2000-11-01', '.rs') 
         , (3, 'Сингапур'                                    ,    5399200, '1965-09-21', '.sg') 
         , (3, 'Сирия'                                       ,    4592777, '1945-10-24', '.sy') 
         , (2, 'Словакия'                                    ,       NULL, '1993-01-19', '.sk') 
         , (2, 'Словения'                                    ,    2062874, '1992-05-22', '.si') 
         , (5, 'Соединённые Штаты Америки'                   ,  323952889, '1945-10-24', '.us') 
         , (1, 'Соломоновы Острова'                          ,     117869, '1978-09-19', '.sb') 
         , (4, 'Сомали'                                      ,    2756380, '1960-09-20', '.so') 
         , (4, 'Судан'                                       ,       NULL, '1956-11-12', '.sd') 
         , (6, 'Суринам'                                     ,     290137, '1975-12-04', '.sr') 
         , (4, 'Сьерра-Леоне'                                ,    2160111, '1961-09-27', '.sl') 
         , (3, 'Таджикистан'                                 ,       NULL, '1992-03-02', '.tj') 
         , (3, 'Таиланд'                                     ,   65981659, '1946-12-16', '.th') 
         , (4, 'Танзания'                                    ,   10074490, '1961-12-14', '.tz') 
         , (4, 'Того'                                        ,    1580513, '1960-09-20', '.tg') 
         , (1, 'Тонга'                                       ,      61600, '1999-09-14', '.to') 
         , (5, 'Тринидад и Тобаго'                           ,     848481, '1962-09-18', '.tt') 
         , (1, 'Тувалу'                                      ,       6104, '2000-09-05', '.tv') 
         , (4, 'Тунис'                                       ,   10835873, '1956-11-12', '.tn') 
         , (3, 'Туркмения'                                   ,    5125693, '1992-03-02', '.tm') 
         , (9, 'Турция'                                      ,   27553280, '1945-10-24', '.tr') 
         , (4, 'Уганда'                                      ,    6788211, '1962-10-25', '.ug') 
         , (3, 'Узбекистан'                                  ,   31576400, '1992-03-02', '.uz') 
         , (2, 'Украина'                                     ,   42800501, '1945-10-24', '.ua') 
         , (6, 'Уругвай'                                     ,    2538779, '1945-12-18', '.uy') 
         , (1, 'Фиджи'                                       ,     393383, '1970-10-13', '.fj') 
         , (3, 'Филиппины'                                   ,   92337852, '1945-10-24', '.ph') 
         , (2, 'Финляндия'                                   ,    5470437, '1955-12-14', '.fi') 
         , (2, 'Франция'                                     ,   66600000, '1945-10-24', '.fr') 
         , (2, 'Хорватия'                                    ,    4284889, '1992-05-22', '.hr') 
         , (4, 'Центральноафриканская Республика'            ,    1503501, '1960-09-20', '.cf') 
         , (4, 'Чад'                                         ,    3002596, '1960-09-20', '.td') 
         , (2, 'Черногория'                                  ,       NULL, '2006-06-28', '.me') 
         , (2, 'Чехия'                                       ,   10521646, '1993-01-19', '.cz') 
         , (2, 'Чехословакия'                                ,   15700000, NULL, '.cs') 
         , (6, 'Чили'                                        ,    7649026, '1945-10-24', '.cl') 
         , (2, 'Швейцария'                                   ,    8211700, '2002-09-10', '.ch') 
         , (2, 'Швеция'                                      ,    9747355, '1946-11-19', '.se') 
         , (3, 'Шри-Ланка'                                   ,       NULL, '1955-12-14', '.lk') 
         , (6, 'Эквадор'                                     ,    4514593, '1945-12-21', '.ec') 
         , (4, 'Экваториальная Гвинея'                       ,     252115, '1968-11-12', '.gq') 
         , (4, 'Эритрея'                                     ,    1404810, '1993-05-28', '.er') 
         , (2, 'Эстония'                                     ,    1313271, '1991-09-17', '.ee') 
         , (4, 'Эфиопия'                                     ,   22151218, '1945-11-13', '.et') 
         , (4, 'Южно-Африканская Республика'                 ,   54002000, '1945-11-07', '.za') 
         , (4, 'Южный Судан'                                 ,       NULL, '2011-07-14', '.ss') 
         , (5, 'Ямайка'                                      ,    2950210, '1962-09-18', '.jm') 
         , (3, 'Япония'                                      ,  128057352, '1956-12-18', '.jp') 
GO

INSERT INTO City (CountryId, Name, IsCapital, [Population], OfficialSite, Coordinates)
    VALUES (  1, 'Канберра'                 , 1, 381488, NULL, geography::STGeomFromText('POINT(149.142 -35.303)', 4326))
         , (  2, 'Вена'                     , 1, 1794770, 'http://www.wien.gv.at/', geography::STGeomFromText('POINT(16.373 48.208)', 4326))
         , (  3, 'Баку'                     , 1, 2122300, 'http://www.baku-ih.gov.az/', geography::STGeomFromText('POINT(49.835 40.367)', 4326))
         , (  4, 'Тирана'                   , 1, NULL, 'http://www.tirana.gov.al/?cid=2', geography::STGeomFromText('POINT(19.820 41.330)', 4326))
         , (  5, 'Алжир'                    , 1, 3415811, NULL, geography::STGeomFromText('POINT(3.059 36.776)', 4326))
         , (  6, 'Луанда'                   , 1, 6377246, NULL, geography::STGeomFromText('POINT(13.233 -8.833)', 4326))
         , (  7, 'Андорра-ла-Велья'         , 1, NULL, 'http://www.andorralavella.ad/', geography::STGeomFromText('POINT(1.500 42.500)', 4326))
         , (  8, 'Сент-Джонс'               , 1, NULL, NULL, geography::STGeomFromText('POINT(-61.845 17.121)', 4326))
         , (  9, 'Буэнос-Айрес'             , 1, 2890151, 'http://www.buenosaires.gob.ar/', geography::STGeomFromText('POINT(-58.382 -34.600)', 4326))
         , ( 10, 'Ереван'                   , 1, 1054698, 'http://www.yerevan.am', geography::STGeomFromText('POINT(44.517 40.183)', 4326))
         , ( 11, 'Кабул'                    , 1, 3678034, NULL, geography::STGeomFromText('POINT(69.166 34.533)', 4326))
         , ( 12, 'Нассау'                   , 1, 259300, 'http://www.bahamas.gov.bs', geography::STGeomFromText('POINT(-77.333 25.067)', 4326))
         , ( 13, 'Дакка'                    , 1, 6970105, 'http://www.dhakacity.org', geography::STGeomFromText('POINT(90.367 23.700)', 4326))
         , ( 14, 'Бриджтаун'                , 1, 110000, NULL, geography::STGeomFromText('POINT(-59.608 13.096)', 4326))
         , ( 15, 'Манама'                   , 1, NULL, 'http://www.capital.gov.bh', geography::STGeomFromText('POINT(50.583 26.217)', 4326))
         , ( 16, 'Бельмопан'                , 1, NULL, NULL, geography::STGeomFromText('POINT(-88.768 17.250)', 4326))
         , ( 17, 'Минск'                    , 1, 1921800, 'http://minsk.gov.by', geography::STGeomFromText('POINT(27.562 53.902)', 4326))
         , ( 18, 'Брюссель'                 , 1, 176124, 'http://www.bruxelles.be/', geography::STGeomFromText('POINT(4.355 50.847)', 4326))
         , ( 19, 'Порто-Ново'               , 1, NULL, 'http://www.villedeportonovo.com', geography::STGeomFromText('POINT(2.617 6.483)', 4326))
         , ( 20, 'София'                    , 1, 1286383, 'http://www.sofia.bg/en/index_en.asp', geography::STGeomFromText('POINT(23.333 42.700)', 4326))
         , ( 21, 'Ла-Пас'                   , 1, 877363, 'http://www.lapaz.bo/', geography::STGeomFromText('POINT(-68.148 -16.494)', 4326))
         , ( 22, 'Сараево'                  , 1, NULL, 'http://www.sarajevo.ba/ba/index.php', geography::STGeomFromText('POINT(18.417 43.867)', 4326))
         , ( 23, 'Габороне'                 , 1, 231626, 'http://www.gov.bw/en/Ministries--Authorities/Local-Authorities/Gaborone-City-Council', geography::STGeomFromText('POINT(25.909 -24.657)', 4326))
         , ( 24, 'Бразилиа'                 , 1, 2789761, 'http://www.brasilia.df.gov.br', geography::STGeomFromText('POINT(-47.883 -15.794)', 4326))
         , ( 25, 'Бандар-Сери-Бегаван'      , 1, 50000, 'http://www.municipal-bsb.gov.bn/', geography::STGeomFromText('POINT(114.917 4.917)', 4326))
         , ( 26, 'Уагадугу'                 , 1, 1626950, 'http://www.mairie-ouaga.bf/', geography::STGeomFromText('POINT(-1.535 12.357)', 4326))
         , ( 27, 'Бужумбура'                , 1, NULL, 'http://www.villedebujumbura.org', geography::STGeomFromText('POINT(29.361 -3.383)', 4326))
         , ( 28, 'Тхимпху'                  , 1, NULL, NULL, geography::STGeomFromText('POINT(89.633 27.483)', 4326))
         , ( 29, 'Порт-Вила'                , 1, 44040, NULL, geography::STGeomFromText('POINT(168.300 -17.750)', 4326))
         , ( 31, 'Лондон'                   , 1, 8416535, 'http://www.london.gov.uk/', geography::STGeomFromText('POINT(-0.128 51.507)', 4326))
         , ( 32, 'Будапешт'                 , 1, 1744665, 'http://www.budapest.hu', geography::STGeomFromText('POINT(19.041 47.498)', 4326))
         , ( 33, 'Каракас'                  , 1, 3273863, NULL, geography::STGeomFromText('POINT(-66.933 10.500)', 4326))
         , ( 34, 'Дили'                     , 1, 222323, NULL, geography::STGeomFromText('POINT(125.574 -8.559)', 4326))
         , ( 35, 'Ханой'                    , 1, 7587800, NULL, geography::STGeomFromText('POINT(105.850 21.033)', 4326))
         , ( 36, 'Либревиль'                , 1, 797003, 'http://libreville.ga', geography::STGeomFromText('POINT(9.454 0.390)', 4326))
         , ( 37, 'Джорджтаун'               , 1, 235017, NULL, geography::STGeomFromText('POINT(-58.167 6.783)', 4326))
         , ( 38, 'Банжул'                   , 1, NULL, NULL, geography::STGeomFromText('POINT(-16.578 13.453)', 4326))
         , ( 39, 'Аккра'                    , 1, 2291352, 'http://www.ghana.gov.gh/', geography::STGeomFromText('POINT(-0.217 5.550)', 4326))
         , ( 40, 'Гватемала'                , 1, 2110100, NULL, geography::STGeomFromText('POINT(-90.531 14.623)', 4326))
         , ( 41, 'Конакри'                  , 1, 1667864, NULL, geography::STGeomFromText('POINT(-13.712 9.509)', 4326))
         , ( 42, 'Бисау'                    , 1, 395954, NULL, geography::STGeomFromText('POINT(-15.596 11.859)', 4326))
         , ( 43, 'Бонн'                     , 1, 311287, 'http://www.bonn.de/', geography::STGeomFromText('POINT(7.100 50.734)', 4326))
         , ( 44, 'Тегусигальпа'             , 1, 1126534, 'http://www.lacapitaldehonduras.com/', geography::STGeomFromText('POINT(-87.207 14.094)', 4326))
         , ( 45, 'Сент-Джорджес'            , 1, NULL, NULL, geography::STGeomFromText('POINT(-61.742 12.044)', 4326))
         , ( 46, 'Афины'                    , 1, 664046, 'http://www.cityofathens.gr/', geography::STGeomFromText('POINT(23.717 38.000)', 4326))
         , ( 47, 'Тбилиси'                  , 1, 1118035, 'http://www.tbilisi.gov.ge', geography::STGeomFromText('POINT(44.783 41.717)', 4326))
         , ( 48, 'Копенгаген'               , 1, 569557, NULL, geography::STGeomFromText('POINT(12.569 55.676)', 4326))
         , ( 49, 'Джибути'                  , 1, 623891, NULL, geography::STGeomFromText('POINT(43.148 11.595)', 4326))
         , ( 50, 'Розо'                     , 1, NULL, NULL, geography::STGeomFromText('POINT(-61.383 15.300)', 4326))
         , ( 51, 'Санто-Доминго'            , 1, NULL, NULL, geography::STGeomFromText('POINT(-69.893 18.476)', 4326))
         , ( 52, 'Киншаса'                  , 1, 10125000, 'http://www.kinshasa.cd', geography::STGeomFromText('POINT(15.314 -4.332)', 4326))
         , ( 53, 'Каир'                     , 1, 7902085, 'http://www.cairo.yatb.info', geography::STGeomFromText('POINT(31.239 30.056)', 4326))
         , ( 54, 'Лусака'                   , 1, 2467467, 'http://www.lcc.gov.zm', geography::STGeomFromText('POINT(28.283 -15.417)', 4326))
         , ( 55, 'Хараре'                   , 1, 1606000, 'http://hararecity.co.zw', geography::STGeomFromText('POINT(31.030 -17.864)', 4326))
         , ( 56, 'Сана'                     , 1, 2957000, 'http://www.sanaacity.com/', geography::STGeomFromText('POINT(44.200 15.350)', 4326))
         , ( 57, 'Иерусалим'                , 1, 829900, 'http://www.jerusalem.muni.il', geography::STGeomFromText('POINT(35.233 31.783)', 4326))
         , ( 58, 'Нью-Дели'                 , 1, 249998, 'http://www.ndmc.gov.in/', geography::STGeomFromText('POINT(77.200 28.700)', 4326))
         , ( 59, 'Джакарта'                 , 1, 9607787, 'http://www.jakarta.go.id', geography::STGeomFromText('POINT(106.800 -6.167)', 4326))
         , ( 60, 'Амман'                    , 1, 4007526, 'http://www.ammancity.gov.jo', geography::STGeomFromText('POINT(35.933 31.950)', 4326))
         , ( 61, 'Багдад'                   , 1, NULL, 'http://www.baghdadgov.com', geography::STGeomFromText('POINT(44.417 33.350)', 4326))
         , ( 62, 'Тегеран'                  , 1, NULL, 'http://www.tehran.ir/', geography::STGeomFromText('POINT(51.417 35.700)', 4326))
         , ( 63, 'Дублин'                   , 1, 527612, 'http://www.dublincity.ie/', geography::STGeomFromText('POINT(-6.266 53.343)', 4326))
         , ( 64, 'Рейкьявик'                , 1, 121490, 'http://www.rvk.is', geography::STGeomFromText('POINT(-21.883 64.150)', 4326))
         , ( 65, 'Мадрид'                   , 1, 3207247, 'http://www.madrid.es/', geography::STGeomFromText('POINT(-3.692 40.419)', 4326))
         , ( 66, 'Рим'                      , 1, 518917, 'http://www.comune.roma.it', geography::STGeomFromText('POINT(12.483 41.893)', 4326))
         , ( 67, 'Прая'                     , 1, NULL, 'http://www.cmpraia.cv/', geography::STGeomFromText('POINT(-23.509 14.918)', 4326))
         , ( 68, 'Астана'                   , 1, 814401, 'http://astana.gov.kz/', geography::STGeomFromText('POINT(71.400 51.183)', 4326))
         , ( 69, 'Пномпень'                 , 1, 1501725, 'http://www.phnompenh.gov.kh', geography::STGeomFromText('POINT(104.917 11.550)', 4326))
         , ( 70, 'Яунде'                    , 1, 2440462, NULL, geography::STGeomFromText('POINT(11.517 3.867)', 4326))
         , ( 71, 'Оттава'                   , 1, 883391, 'http://www.ottawa.ca', geography::STGeomFromText('POINT(-75.700 45.417)', 4326))
         , ( 72, 'Доха'                     , 1, 1312947, NULL, geography::STGeomFromText('POINT(51.533 25.300)', 4326))
         , ( 73, 'Найроби'                  , 1, 3138369, 'http://www.citycouncilofnairobi.go.ke/', geography::STGeomFromText('POINT(36.817 -1.283)', 4326))
         , ( 74, 'Никосия'                  , 1, 55014, 'http://www.nicosia.org.cy', geography::STGeomFromText('POINT(33.350 35.167)', 4326))
         , ( 75, 'Бишкек'                   , 1, NULL, NULL, geography::STGeomFromText('POINT(74.567 42.867)', 4326))
         , ( 76, 'Южная Тарава'             , 1, NULL, NULL, geography::STGeomFromText('POINT(172.967 1.400)', 4326))
         , ( 77, 'Пекин'                    , 1, 21516000, 'http://www.beijing.gov.cn', geography::STGeomFromText('POINT(116.391 39.905)', 4326))
         , ( 78, 'Тайбэй'                   , 1, 2655515, 'http://www.gov.taipei/', geography::STGeomFromText('POINT(121.633 25.033)', 4326))
         , ( 79, 'Богота'                   , 1, 8543765, 'http://www.bogota.gov.co/', geography::STGeomFromText('POINT(-74.081 4.599)', 4326))
         , ( 80, 'Морони'                   , 1, NULL, NULL, geography::STGeomFromText('POINT(43.254 -11.704)', 4326))
         , ( 81, 'Пхеньян'                  , 1, 4138187, NULL, geography::STGeomFromText('POINT(125.730 39.030)', 4326))
         , ( 82, 'Сан-Хосе'                 , 1, 288054, NULL, geography::STGeomFromText('POINT(-84.083 9.933)', 4326))
         , ( 83, 'Ямусукро'                 , 1, 355573, 'http://yamoussoukro.org/en/index.htm', geography::STGeomFromText('POINT(-5.276 6.818)', 4326))
         , ( 84, 'Гавана'                   , 1, 2106146, NULL, geography::STGeomFromText('POINT(-82.383 23.117)', 4326))
         , ( 85, 'Кувейт'                   , 1, 637411, NULL, geography::STGeomFromText('POINT(47.980 29.375)', 4326))
         , ( 86, 'Вьентьян'                 , 1, NULL, NULL, geography::STGeomFromText('POINT(102.600 17.967)', 4326))
         , ( 87, 'Рига'                     , 1, 701977, 'http://www.riga.lv/', geography::STGeomFromText('POINT(24.107 56.948)', 4326))
         , ( 88, 'Масеру'                   , 1, 227880, NULL, geography::STGeomFromText('POINT(27.488 -29.322)', 4326))
         , ( 89, 'Монровия'                 , 1, NULL, NULL, geography::STGeomFromText('POINT(-10.805 6.311)', 4326))
         , ( 90, 'Бейрут'                   , 1, 361366, 'http://www.beirut.gov.lb/', geography::STGeomFromText('POINT(35.513 33.887)', 4326))
         , ( 91, 'Триполи'                  , 1, 1126000, 'http://www.tlc.gov.ly/', geography::STGeomFromText('POINT(13.183 32.900)', 4326))
         , ( 92, 'Вильнюс'                  , 1, 539939, NULL, geography::STGeomFromText('POINT(25.283 54.683)', 4326))
         , ( 93, 'Вадуц'                    , 1, NULL, 'http://www.vaduz.li', geography::STGeomFromText('POINT(9.522 47.140)', 4326))
         , ( 94, 'Люксембург'               , 1, 111287, 'http://www.vdl.lu', geography::STGeomFromText('POINT(6.133 49.610)', 4326))
         , ( 95, 'Порт-Луи'                 , 1, 148001, 'http://mpl.intnet.mu/home.htm', geography::STGeomFromText('POINT(57.500 -20.167)', 4326))
         , ( 96, 'Нуакшот'                  , 1, 958399, NULL, geography::STGeomFromText('POINT(-15.974 18.078)', 4326))
         , ( 97, 'Антананариву'             , 1, NULL, 'http://www.mairie-antananarivo.mg/', geography::STGeomFromText('POINT(47.521 -18.939)', 4326))
         , ( 98, 'Лилонгве'                 , 1, NULL, NULL, geography::STGeomFromText('POINT(33.783 -13.983)', 4326))
         , ( 99, 'Куала-Лумпур'             , 1, 1588750, 'http://www.visitkl.gov.my/visitklv2/', geography::STGeomFromText('POINT(101.700 3.160)', 4326))
         , (100, 'Бамако'                   , 1, NULL, NULL, geography::STGeomFromText('POINT(-7.992 12.646)', 4326))
         , (101, 'Мале'                     , 1, NULL, NULL, geography::STGeomFromText('POINT(73.500 4.167)', 4326))
         , (102, 'Валлетта'                 , 1, 6444, 'http://www.cityofvalletta.org', geography::STGeomFromText('POINT(14.513 35.898)', 4326))
         , (103, 'Рабат'                    , 1, 577827, 'http://www.rabat.ma', geography::STGeomFromText('POINT(-6.836 34.025)', 4326))
         , (104, 'Маджуро'                  , 1, NULL, NULL, geography::STGeomFromText('POINT(171.267 7.067)', 4326))
         , (105, 'Мехико'                   , 1, 8918653, 'http://www.cdmx.gob.mx', geography::STGeomFromText('POINT(-99.146 19.419)', 4326))
         , (106, 'Паликир'                  , 1, NULL, NULL, geography::STGeomFromText('POINT(158.185 6.918)', 4326))
         , (107, 'Мапуту'                   , 1, 1766184, 'http://www.cmmaputo.gov.mz', geography::STGeomFromText('POINT(32.576 -25.915)', 4326))
         , (108, 'Кишинёв'                  , 1, 723500, 'http://www.chisinau.md', geography::STGeomFromText('POINT(28.858 47.006)', 4326))
         , (109, 'Монако'                   , 1, NULL, NULL, geography::STGeomFromText('POINT(7.425 43.731)', 4326))
         , (110, 'Улан-Батор'               , 1, 1372000, 'http://www.ulaanbaatar.mn', geography::STGeomFromText('POINT(106.917 47.917)', 4326))
         , (111, 'Нейпьидо'                 , 1, NULL, NULL, geography::STGeomFromText('POINT(96.158 19.803)', 4326))
         , (112, 'Виндхук'                  , 1, 322500, 'http://www.windhoekcc.org.na/', geography::STGeomFromText('POINT(17.084 -22.570)', 4326))
         , (113, 'Ярен'                     , 1, 747, NULL, geography::STGeomFromText('POINT(166.921 -0.548)', 4326))
         , (114, 'Катманду'                 , 1, 975453, 'http://www.kathmandu.gov.np', geography::STGeomFromText('POINT(85.367 27.717)', 4326))
         , (115, 'Ниамей'                   , 1, 1026848, NULL, geography::STGeomFromText('POINT(2.111 13.509)', 4326))
         , (116, 'Абуджа'                   , 1, 1235880, 'http://www.fct.gov.ng/', geography::STGeomFromText('POINT(7.500 9.050)', 4326))
         , (117, 'Амстердам'                , 1, 825080, 'http://www.amsterdam.nl', geography::STGeomFromText('POINT(4.900 52.383)', 4326))
         , (118, 'Манагуа'                  , 1, 1028808, 'http://www.managua.gob.ni', geography::STGeomFromText('POINT(-86.267 12.150)', 4326))
         , (119, 'Веллингтон'               , 1, 398300, 'http://www.wellingtonnz.com', geography::STGeomFromText('POINT(174.777 -41.289)', 4326))
         , (120, 'Осло'                     , 1, 634463, 'http://www.oslo.kommune.no/', geography::STGeomFromText('POINT(10.753 59.911)', 4326))
         , (121, 'Абу-Даби'                 , 1, 621000, NULL, geography::STGeomFromText('POINT(54.369 24.478)', 4326))
         , (122, 'Маскат'                   , 1, NULL, 'http://www.mctmnet.gov.om/newweb/index.asp?lan=E', geography::STGeomFromText('POINT(58.592 23.614)', 4326))
         , (123, 'Исламабад'                , 1, NULL, 'http://www.islamabad.gov.pk/islamabad/default.asp', geography::STGeomFromText('POINT(73.067 33.717)', 4326))
         , (124, 'Нгерулмуд'                , 1, NULL, NULL, geography::STGeomFromText('POINT(134.624 7.501)', 4326))
         , (125, 'Панама'                   , 1, 880691, NULL, geography::STGeomFromText('POINT(-79.500 9.000)', 4326))
         , (126, 'Порт-Морсби'              , 1, 364125, NULL, geography::STGeomFromText('POINT(147.200 -9.500)', 4326))
         , (127, 'Асунсьон'                 , 1, 542023, 'http://www.asuncion.gov.py/', geography::STGeomFromText('POINT(-57.667 -25.267)', 4326))
         , (128, 'Лима'                     , 1, 8890792, 'http://www.munlima.gob.pe/', geography::STGeomFromText('POINT(-77.019 -12.035)', 4326))
         , (129, 'Варшава'                  , 1, 1735442, 'http://www.um.warszawa.pl/', geography::STGeomFromText('POINT(21.033 52.217)', 4326))
         , (130, 'Лиссабон'                 , 1, 545245, 'http://www.cm-lisboa.pt/', geography::STGeomFromText('POINT(-9.167 38.717)', 4326))
         , (131, 'Порт-о-Пренс'             , 1, 987310, NULL, geography::STGeomFromText('POINT(-72.339 18.543)', 4326))
         , (132, 'Браззавиль'               , 1, 1827000, 'http://www.brazzaville.cg', geography::STGeomFromText('POINT(15.283 -4.267)', 4326))
         , (133, 'Сеул'                     , 1, 9989795, 'http://www.seoul.go.kr', geography::STGeomFromText('POINT(127.000 37.583)', 4326))
         , (134, 'Приштина'                 , 1, NULL, NULL, geography::STGeomFromText('POINT(21.167 42.667)', 4326))
         , (135, 'Скопье'                   , 1, 506926, 'http://www.skopje.gov.mk/', geography::STGeomFromText('POINT(21.433 41.983)', 4326))
         , (136, 'Москва'                   , 1, 11503501, 'http://www.mos.ru/', geography::STGeomFromText('POINT(37.618 55.756)', 4326))
         , (137, 'Кигали'                   , 1, 1132686, 'http://www.kigalicity.gov.rw', geography::STGeomFromText('POINT(30.061 -1.954)', 4326))
         , (138, 'Бухарест'                 , 1, 1883425, NULL, geography::STGeomFromText('POINT(26.083 44.400)', 4326))
         , (139, 'Сан-Сальвадор'            , 1, 567698, NULL, geography::STGeomFromText('POINT(-89.190 13.690)', 4326))
         , (140, 'Апиа'                     , 1, NULL, NULL, geography::STGeomFromText('POINT(-171.833 -13.833)', 4326))
         , (141, 'Сан-Марино'               , 1, NULL, 'http://www.sanmarinosite.com/castelli/sanmarino/', geography::STGeomFromText('POINT(12.448 43.932)', 4326))
         , (142, 'Сан-Томе'                 , 1, NULL, NULL, geography::STGeomFromText('POINT(6.733 0.333)', 4326))
         , (143, 'Эр-Рияд'                  , 1, 5700000, 'http://www.arriyadh.com', geography::STGeomFromText('POINT(46.710 24.650)', 4326))
         , (144, 'Лобамба'                  , 1, NULL, NULL, geography::STGeomFromText('POINT(31.167 -26.417)', 4326))
         , (145, 'Виктория'                 , 1, 26450, NULL, geography::STGeomFromText('POINT(55.454 -4.624)', 4326))
         , (146, 'Дакар'                    , 1, NULL, 'http://villededakar.org', geography::STGeomFromText('POINT(-17.457 14.732)', 4326))
         , (147, 'Кингстаун'                , 1, NULL, NULL, geography::STGeomFromText('POINT(-61.233 13.167)', 4326))
         , (148, 'Бастер'                   , 1, NULL, NULL, geography::STGeomFromText('POINT(-62.734 17.298)', 4326))
         , (149, 'Кастри'                   , 1, 70000, 'http://www.castriescitycouncil.org/', geography::STGeomFromText('POINT(-60.983 14.017)', 4326))
         , (150, 'Белград'                  , 1, NULL, 'http://www.beograd.rs', geography::STGeomFromText('POINT(20.467 44.817)', 4326))
         , (151, 'Сингапур'                 , 1, 5399200, NULL, geography::STGeomFromText('POINT(103.800 1.300)', 4326))
         , (152, 'Дамаск'                   , 1, 1711000, 'http://www.damascus.gov.sy/', geography::STGeomFromText('POINT(36.292 33.513)', 4326))
         , (153, 'Братислава'               , 1, 415589, 'http://www.bratislava.sk/', geography::STGeomFromText('POINT(17.113 48.145)', 4326))
         , (154, 'Любляна'                  , 1, NULL, 'http://www.ljubljana.si', geography::STGeomFromText('POINT(14.517 46.050)', 4326))
         , (155, 'Вашингтон'                , 1, 601723, 'http://www.dc.gov/', geography::STGeomFromText('POINT(-77.037 38.895)', 4326))
         , (156, 'Хониара'                  , 1, 64609, NULL, geography::STGeomFromText('POINT(159.950 -9.433)', 4326))
         , (157, 'Могадишо'                 , 1, NULL, NULL, geography::STGeomFromText('POINT(45.343 2.041)', 4326))
         , (158, 'Хартум'                   , 1, 6527500, NULL, geography::STGeomFromText('POINT(32.600 15.567)', 4326))
         , (159, 'Парамарибо'               , 1, 240000, NULL, geography::STGeomFromText('POINT(-55.167 5.867)', 4326))
         , (160, 'Фритаун'                  , 1, 951000, NULL, geography::STGeomFromText('POINT(-13.233 8.483)', 4326))
         , (161, 'Душанбе'                  , 1, 778500, 'http://www.dushanbe.tj/', geography::STGeomFromText('POINT(68.786 38.573)', 4326))
         , (162, 'Бангкок'                  , 1, 8280925, NULL, geography::STGeomFromText('POINT(100.517 13.750)', 4326))
         , (163, 'Додома'                   , 1, 410956, 'http://www.dodoma.go.tz/', geography::STGeomFromText('POINT(35.750 -6.250)', 4326))
         , (164, 'Ломе'                     , 1, 837437, NULL, geography::STGeomFromText('POINT(1.223 6.132)', 4326))
         , (165, 'Нукуалофа'                , 1, NULL, NULL, geography::STGeomFromText('POINT(-175.208 -21.135)', 4326))
         , (166, 'Порт-оф-Спейн'            , 1, NULL, 'http://cityofportofspain.gov.tt/', geography::STGeomFromText('POINT(-61.517 10.667)', 4326))
         , (167, 'Фунафути'                 , 1, NULL, NULL, geography::STGeomFromText('POINT(179.217 -8.517)', 4326))
         , (168, 'Тунис'                    , 1, NULL, 'http://www.commune-tunis.gov.tn', geography::STGeomFromText('POINT(10.180 36.801)', 4326))
         , (169, 'Ашхабад'                  , 1, NULL, NULL, geography::STGeomFromText('POINT(58.383 37.950)', 4326))
         , (170, 'Анкара'                   , 1, 5270575, 'http://www.ankara.bel.tr/', geography::STGeomFromText('POINT(32.867 39.867)', 4326))
         , (171, 'Кампала'                  , 1, 1659600, 'http://www.kcc.go.ug/', geography::STGeomFromText('POINT(32.581 0.314)', 4326))
         , (172, 'Ташкент'                  , 1, 2352900, NULL, geography::STGeomFromText('POINT(69.267 41.300)', 4326))
         , (173, 'Киев'                     , 1, 2845023, 'http://kievcity.gov.ua', geography::STGeomFromText('POINT(30.524 50.450)', 4326))
         , (174, 'Монтевидео'               , 1, 1319108, NULL, geography::STGeomFromText('POINT(-56.167 -34.867)', 4326))
         , (175, 'Сува'                     , 1, 88271, NULL, geography::STGeomFromText('POINT(178.433 -18.133)', 4326))
         , (176, 'Манила'                   , 1, 1652171, 'http://www.manila.gov.ph', geography::STGeomFromText('POINT(121.000 14.583)', 4326))
         , (177, 'Хельсинки'                , 1, 603968, 'http://www.hel.fi/hki/Helsinki/en/Etusivu', geography::STGeomFromText('POINT(24.949 60.173)', 4326))
         , (178, 'Париж'                    , 1, 2240621, 'http://www.paris.fr', geography::STGeomFromText('POINT(2.352 48.857)', 4326))
         , (179, 'Загреб'                   , 1, 790017, 'http://www.zagreb.hr/', geography::STGeomFromText('POINT(15.950 45.800)', 4326))
         , (180, 'Банги'                    , 1, 734350, NULL, geography::STGeomFromText('POINT(18.555 4.361)', 4326))
         , (181, 'Нджамена'                 , 1, 1092066, NULL, geography::STGeomFromText('POINT(15.072 12.116)', 4326))
         , (182, 'Подгорица'                , 1, 187085, 'http://www.podgorica.me/', geography::STGeomFromText('POINT(19.266 42.440)', 4326))
         , (183, 'Прага'                    , 1, 1243201, 'http://www.praha.eu/', geography::STGeomFromText('POINT(14.421 50.089)', 4326))
         , (184, 'Прага'                    , 1, 1243201, 'http://www.praha.eu/', geography::STGeomFromText('POINT(14.421 50.089)', 4326))
         , (185, 'Сантьяго'                 , 1, 6158080, 'http://www.gobiernosantiago.cl', geography::STGeomFromText('POINT(-70.667 -33.450)', 4326))
         , (186, 'Берн'                     , 1, 137980, 'http://www.bern.ch', geography::STGeomFromText('POINT(7.439 46.951)', 4326))
         , (187, 'Стокгольм'                , 1, 917297, 'http://www.stockholm.se/', geography::STGeomFromText('POINT(18.069 59.329)', 4326))
         , (188, 'Шри-Джаяварденепура-Котте', 1, 115826, NULL, geography::STGeomFromText('POINT(79.916 6.900)', 4326))
         , (189, 'Кито'                     , 1, 2671191, 'http://www.quito.gob.ec/', geography::STGeomFromText('POINT(-78.510 -0.219)', 4326))
         , (190, 'Малабо'                   , 1, 187302, 'http://www.ayuntamientodemalabo.com/', geography::STGeomFromText('POINT(8.775 3.752)', 4326))
         , (191, 'Асмэра'                   , 1, 649000, NULL, geography::STGeomFromText('POINT(38.917 15.333)', 4326))
         , (192, 'Таллин'                   , 1, 393222, 'http://www.tallinn.ee', geography::STGeomFromText('POINT(24.745 59.437)', 4326))
         , (193, 'Аддис-Абеба'              , 1, 3384569, 'http://www.addisababacity.gov.et/', geography::STGeomFromText('POINT(38.737 9.027)', 4326))
         , (194, 'Претория'                 , 1, 741651, 'http://www.tshwane.gov.za/Pages/default.aspx', geography::STGeomFromText('POINT(28.244 -25.726)', 4326))
         , (195, 'Джуба'                    , 1, 372410, NULL, geography::STGeomFromText('POINT(31.600 4.850)', 4326))
         , (196, 'Кингстон'                 , 1, 937700, NULL, geography::STGeomFromText('POINT(-76.800 17.983)', 4326))
         , (197, 'Токио (Канто)'            , 1, 9272565, NULL, geography::STGeomFromText('POINT(139.774 35.684)', 4326))
GO
-- ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

UPDATE Country SET CapitalId = (SELECT Id FROM City WHERE CountryId = Country.Id AND IsCapital = 1)
GO

-- ================================================================================
--  VIEWS
-- ================================================================================
CREATE VIEW v_SelectCapitals
AS
SELECT
    PartOfWorld.Name AS PartOfWorldName,
    Country.Name AS CountryName,
    Country.[Population] AS CountryPopulation,
    City.Name AS CapitalName,
    City.[Population] AS CapitalPopulation
FROM
    Country
    JOIN PartOfWorld ON PartOfWorld.Id = Country.PartOfWorldId
    LEFT JOIN City ON City.Id = Country.CapitalId
GO



-- ================================================================================
SELECT
    PartOfWorld.Name AS PartOfWorldName,
    Country.Name AS CountryName,
    Country.[Population] AS CountryPopulation,
    City.Name AS CityName,
    Coordinates.Lat AS Latitude,
    Coordinates.Long AS Longitude,
    City.[Population] AS CityPopulation,
    IsCapital,
    OfficialSite
FROM
    City
    LEFT JOIN Country ON Country.Id = City.CountryId
    LEFT JOIN PartOfWorld ON PartOfWorld.Id = Country.PartOfWorldId

/*
USE master
DROP DATABASE BelhardTraining
*/
