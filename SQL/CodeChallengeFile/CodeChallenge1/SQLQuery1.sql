
DROP TABLE IF EXISTS Books;
--1 Question
CREATE TABLE Books (
    id INT PRIMARY KEY,
    title VARCHAR(20),
    author VARCHAR(20),
    isbn BIGINT UNIQUE,
    published_date DATE
);

INSERT INTO Books(id, title, author, isbn, published_date)
VALUES
(1, 'My First SQL Book', 'Mary Parker', 8447367383, '2022-02-22'),
(2, 'My Second SQL Book', 'Miller', 3637373748, '1982-07-03'),
(3, 'My Third SQL Book', 'Cary Flint', 5464747474, '2013-10-18');

-- View output
SELECT * FROM Books;

-- Find books where author ends with 'er'
SELECT * FROM Books
WHERE author LIKE '%er';

--2 Question
CREATE TABLE Review (
    id INT PRIMARY KEY,
    book_id INT,
    reviewer_name VARCHAR(20),
    content VARCHAR(20),
    rating INT,
    published_date DATE,
    CONSTRAINT id_fk FOREIGN KEY (book_id) REFERENCES Books(id)
);

INSERT INTO Review (id, book_id, reviewer_name, content, rating, published_date)
VALUES 
    (1, 1, 'Smith', 'My First Review', 4, '2012-12-10'),
    (2, 2, 'Smith', 'My Second Review', 3, '2014-10-13'),
    (3, 2, 'Alice Walker', 'Another Review', 1, '2007-10-22');

SELECT b.title, b.author, r.reviewer_name 
FROM Books as b, Review as r 
WHERE r.book_id = b.id;
