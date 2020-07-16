// TODO think about authorization 

// Пользователь (имя, фамилия, айди ) -[r: HAVE_CREDENTIALS] -> Креды (хеш пароль, логин )
// Пользователь - слушает -> Группу
// Пользователь - слушает -> Песню
// Пользователю - нравится -> Жанр
// Группа - имеет -> Песню
// Песня - имеет - жанр

//Пользовательская информация:
//1) Хобби
//3) Любимые фильмы 
//    3.1) Название фильмов 
//    3.2) Жанры 
//    3.3) Режиссёры 
//    3.4) Актеры 
//4) Игры 
//    4.1) Названия игр 
//    4.2) Многопользовательская / одно

MATCH (n) DETACH DELETE n;

CREATE(u: User {name: "Dima", surname: "Kirieiev", login: "Dimanoit"})
CREATE(g: Group { name: "System of a Down"})
CREATE(s: Song { name: "Toxicity"})
CREATE(mg: MusicalGenre { name: "Rock"})
CREATE (u)-[r:LISTENING]->(g)
CREATE (u)-[r1:LIKE]->(s)
CREATE (u)-[r2:LIKE]->(mg)
CREATE (g)-[r3:HAVE_SONG]->(s)
CREATE (g)-[r4:HAVE_GENRE]->(mg)

//RUN IN SEPERATE TRANSACTION
CREATE CONSTRAINT unique_login
ON (u:User) ASSERT u.login IS UNIQUE