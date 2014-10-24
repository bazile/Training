/*

    СТОЛИЦЫ СТРАН МИРА. Третья версия.
	Для SQL Server 2005 и выше.

    Добавляем ограничения (constraints).
        Колонка PartOfWorld.Name -> UNIQUE
        Колонка CountryCapital -> UNIQUE
        Внешний ключ (FK) для таблицы CountryCapital

*/

USE master
GO
CREATE DATABASE BelhardTraining
    COLLATE Cyrillic_General_CS_AI
GO
USE BelhardTraining
GO

CREATE TABLE PartOfWorld
(
    Id   int         PRIMARY KEY,
    Name varchar(20) NOT NULL UNIQUE
)
GO

CREATE TABLE CountryCapital
(
    PartOfWorldId int         NOT NULL,
    Country       varchar(30) NOT NULL UNIQUE,
    CapitalCity   varchar(40) NOT NULL
)
GO

ALTER TABLE dbo.CountryCapital
    ADD CONSTRAINT FK_CountryCapital_PartOfWorld
    FOREIGN KEY (PartOfWorldId) REFERENCES PartOfWorld(Id)
    ON UPDATE NO ACTION
    ON DELETE NO ACTION

INSERT INTO PartOfWorld (Id, Name) VALUES (1, 'Европа')
INSERT INTO PartOfWorld (Id, Name) VALUES (2, 'Азия')
INSERT INTO PartOfWorld (Id, Name) VALUES (3, 'Африка')
INSERT INTO PartOfWorld (Id, Name) VALUES (4, 'Америка')
INSERT INTO PartOfWorld (Id, Name) VALUES (5, 'Австралия и Океания')

INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (1, 'Австрия', 'Вена')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (1, 'Албания', 'Тирана')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (1, 'Андорра', 'Андорра-ла-Велья')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (1, 'Беларусь', 'Минск')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (1, 'Бельгия', 'Брюссель')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (1, 'Болгария', 'София')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (1, 'Босния и Герцеговина', 'Сараево')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (1, 'Ватикан', 'Ватикан')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (1, 'Великобритания', 'Лондон')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (1, 'Венгрия', 'Будапешт')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (1, 'Германия', 'Берлин')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (1, 'Греция', 'Афины')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (1, 'Дания', 'Копенгаген')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (1, 'Исландия', 'Рейкьявик')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (1, 'Испания', 'Мадрид')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (1, 'Италия', 'Рим')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (1, 'Латвия', 'Рига')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (1, 'Литва', 'Вильнюс')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (1, 'Лихтенштейн', 'Вадуц')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (1, 'Люксембург', 'Люксембург')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (1, 'Македония', 'Скопье')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (1, 'Мальта', 'Валлетта')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (1, 'Молдавия', 'Кишинёв')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (1, 'Монако', 'Монако')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (1, 'Нидерланды', 'Амстердам')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (1, 'Норвегия', 'Осло')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (1, 'Польша', 'Варшава')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (1, 'Португалия', 'Лиссабон')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (1, 'Россия', 'Москва')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (1, 'Румыния', 'Бухарест')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (1, 'Сан-Марино', 'Сан-Марино')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (1, 'Сербия', 'Белград')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (1, 'Словакия', 'Братислава')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (1, 'Словения', 'Любляна')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (1, 'Украина', 'Киев')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (1, 'Финляндия', 'Хельсинки')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (1, 'Ирландия', 'Дублин')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (1, 'Франция', 'Париж')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (1, 'Хорватия', 'Загреб')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (1, 'Черногория', 'Подгорица')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (1, 'Чехия', 'Прага')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (1, 'Швейцария', 'Берн')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (1, 'Швеция', 'Стокгольм')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (1, 'Эстония', 'Таллин')

INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (2, 'Азербайджан', 'Баку')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (2, 'Армения', 'Ереван')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (2, 'Афганистан', 'Кабул')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (2, 'Бангладеш', 'Дакка')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (2, 'Бахрейн', 'Манама')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (2, 'Бруней', 'Бандар-Сери-Бегаван')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (2, 'Бутан', 'Тхимпху')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (2, 'Восточный Тимор', 'Дили')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (2, 'Вьетнам', 'Ханой')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (2, 'Грузия', 'Тбилиси')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (2, 'Израиль', 'Иерусалим')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (2, 'Индия', 'Дели (Нью-Дели)')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (2, 'Индонезия', 'Джакарта')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (2, 'Иордания', 'Амман')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (2, 'Ирак', 'Багдад')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (2, 'Иран', 'Тегеран')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (2, 'Йемен', 'Сана')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (2, 'Казахстан', 'Астана')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (2, 'Камбоджа', 'Пномпень')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (2, 'Катар', 'Доха')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (2, 'Кипр', 'Никосия')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (2, 'Киргизия', 'Бишкек')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (2, 'КНДР', 'Пхеньян')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (2, 'КНР', 'Пекин')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (2, 'Кувейт', 'Эль-Кувейт')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (2, 'Лаос', 'Вьентьян')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (2, 'Ливан', 'Бейрут')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (2, 'Малайзия', 'Куала-Лумпур')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (2, 'Мальдивы', 'Мале')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (2, 'Монголия', 'Улан-Батор')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (2, 'Мьянма', 'Нейпьидо')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (2, 'Непал', 'Катманду')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (2, 'ОАЭ', 'Абу-Даби')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (2, 'Оман', 'Маскат')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (2, 'Пакистан', 'Исламабад')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (2, 'Республика Корея', 'Сеул')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (2, 'Саудовская Аравия', 'Эр-Рияд')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (2, 'Сингапур', 'Сингапур')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (2, 'Сирия', 'Дамаск')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (2, 'Таджикистан', 'Душанбе')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (2, 'Таиланд', 'Бангкок')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (2, 'Туркмения', 'Ашхабад')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (2, 'Турция', 'Анкара')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (2, 'Узбекистан', 'Ташкент')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (2, 'Филиппины', 'Манила')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (2, 'Шри-Ланка', 'Шри-Джаяварденепура-Котте')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (2, 'Япония', 'Токио')

INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (3, 'Алжир', 'Алжир')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (3, 'Ангола', 'Луанда')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (3, 'Бенин', 'Порто-Ново')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (3, 'Ботсвана', 'Габороне')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (3, 'Буркина-Фасо', 'Уагадугу')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (3, 'Бурунди', 'Бужумбура')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (3, 'Габон', 'Либревиль')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (3, 'Гамбия', 'Банжул')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (3, 'Гана', 'Аккра')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (3, 'Гвинея-Бисау', 'Бисау')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (3, 'Гвинея', 'Конакри')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (3, 'Джибути', 'Джибути')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (3, 'ДР Конго', 'Киншаса')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (3, 'Египет', 'Каир')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (3, 'Замбия', 'Лусака')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (3, 'Зимбабве', 'Хараре')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (3, 'Кабо-Верде', 'Прая')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (3, 'Камерун', 'Яунде')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (3, 'Кения', 'Найроби')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (3, 'Коморы', 'Морони')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (3, 'Кот-д’Ивуар', 'Ямусукро')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (3, 'Лесото', 'Масеру')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (3, 'Либерия', 'Монровия')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (3, 'Маврикий', 'Порт-Луи')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (3, 'Мавритания', 'Нуакшот')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (3, 'Мадагаскар', 'Антананариву')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (3, 'Малави', 'Лилонгве')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (3, 'Мали', 'Бамако')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (3, 'Марокко', 'Рабат')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (3, 'Мозамбик', 'Мапуту')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (3, 'Намибия', 'Виндхук')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (3, 'Нигер', 'Ниамей')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (3, 'Нигерия', 'Абуджа')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (3, 'Республика Конго', 'Браззавиль')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (3, 'Руанда', 'Кигали')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (3, 'Сан-Томе и Принсипи', 'Сан-Томе')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (3, 'Свазиленд', 'Мбабане')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (3, 'Сейшельские Острова', 'Виктория')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (3, 'Сенегал', 'Дакар')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (3, 'Сомали', 'Могадишо')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (3, 'Судан', 'Хартум')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (3, 'Сьерра-Леоне', 'Фритаун')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (3, 'Танзания', 'Додома')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (3, 'Того', 'Ломе')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (3, 'Тунис', 'Тунис')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (3, 'Уганда', 'Кампала')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (3, 'Ливия', 'Триполи')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (3, 'ЦАР', 'Банги')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (3, 'Чад', 'Нджамена')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (3, 'Экваториальная Гвинея', 'Малабо')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (3, 'Эритрея', 'Асмэра')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (3, 'Эфиопия', 'Аддис-Абеба')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (3, 'ЮАР', 'Претория')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (3, 'Южный Судан', 'Джуба')

INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (4, 'Антигуа и Барбуда', 'Сент-Джонс')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (4, 'Аргентина', 'Буэнос-Айрес')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (4, 'Багамы', 'Нассау')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (4, 'Барбадос', 'Бриджтаун')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (4, 'Белиз', 'Бельмопан')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (4, 'Боливия', 'Сукре')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (4, 'Бразилия', 'Бразилиа')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (4, 'Венесуэла', 'Каракас')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (4, 'Гаити', 'Порт-о-Пренс')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (4, 'Гайана', 'Джорджтаун')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (4, 'Гватемала', 'Гватемала')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (4, 'Гвиана', 'Кайенна')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (4, 'Гондурас', 'Тегусигальпа')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (4, 'Гренада', 'Сент-Джорджес')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (4, 'Доминика', 'Розо')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (4, 'Доминиканская Республика', 'Санто-Доминго')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (4, 'Канада', 'Оттава')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (4, 'Колумбия', 'Богота')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (4, 'Коста-Рика', 'Сан-Хосе')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (4, 'Куба', 'Гавана')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (4, 'Мексика', 'Мехико')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (4, 'Никарагуа', 'Манагуа')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (4, 'Панама', 'Панама')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (4, 'Парагвай', 'Асунсьон')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (4, 'Перу', 'Лима')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (4, 'Сальвадор', 'Сан-Сальвадор')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (4, 'Сент-Винсент и Гренадины', 'Кингстаун')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (4, 'Сент-Китс и Невис', 'Бастер')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (4, 'Сент-Люсия', 'Кастри')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (4, 'Суринам', 'Парамарибо')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (4, 'США', 'Вашингтон')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (4, 'Тринидад и Тобаго', 'Порт-оф-Спейн')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (4, 'Уругвай', 'Монтевидео')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (4, 'Чили', 'Сантьяго')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (4, 'Эквадор', 'Кито')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (4, 'Ямайка', 'Кингстон')

INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (5, 'Австралия', 'Канберра')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (5, 'Вануату', 'Порт-Вила')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (5, 'Кирибати', 'Южная Тарава (Баирики)')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (5, 'Маршалловы Острова', 'Маджуро')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (5, 'Микронезия', 'Паликир')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (5, 'Новая Зеландия', 'Веллингтон')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (5, 'Палау', 'Нгерулмуд')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (5, 'Папуа — Новая Гвинея', 'Порт-Морсби')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (5, 'Самоа', 'Апиа')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (5, 'Соломоновы Острова', 'Хониара')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (5, 'Тонга', 'Нукуалофа')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (5, 'Тувалу', 'Фунафути')
INSERT INTO CountryCapital (PartOfWorldId, Country, CapitalCity) VALUES (5, 'Фиджи', 'Сува')

SELECT
    PartOfWorld.Name
    , CountryCapital.Country
    , CountryCapital.CapitalCity
FROM
    CountryCapital
    JOIN PartOfWorld ON PartOfWorld.Id = CountryCapital.PartOfWorldId

/*
USE master
DROP DATABASE BelhardTraining
*/
