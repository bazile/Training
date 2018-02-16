/*

    Запросы для базы данных "Столицы и города стран мира"

*/

USE TrainingCenter_Capitals
GO

-- Количество новых членов ООН по десятилетиям
SELECT
    (YEAR(UNMemberSince) - (YEAR(UNMemberSince) % 10)) AS DecadeBegin,
    (YEAR(UNMemberSince) - (YEAR(UNMemberSince) % 10) + 9) AS DecadeEnd
    , COUNT(*) AS NewUNMembers
FROM
    Country
WHERE
    UNMemberSince IS NOT NULL
GROUP BY
    (YEAR(UNMemberSince) - (YEAR(UNMemberSince) % 10)), (YEAR(UNMemberSince) - (YEAR(UNMemberSince) % 10) + 9)
ORDER BY DecadeBegin
