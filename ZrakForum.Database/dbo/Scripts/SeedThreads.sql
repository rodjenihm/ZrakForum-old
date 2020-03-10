INSERT INTO [dbo].[Threads]
([Name], [AuthorId], [ForumId])
VALUES
('Vučić u Vlasotincu',2,1),
('FK Vlasina šampion Vlasotinca',4,2),
('Bioskop ponovo radi (njeknja)',2,3),
('Predsednik opštine laže!?',3,1),
('Muzika uživo u kafani Princ',4,4);


INSERT INTO [dbo].[Posts]
([Content], [AuthorId], [ThreadId])
VALUES
('Dolazi veliki vođa. Kako ćemo ga dočekati braćo vlasotinčani?', 2, 1),
('Da li je moguće da naš predsednik laže? Ovo nije istina!!!', 3, 4),
('Konačno titula za plave. Vlasina osvojila kup vlasotinca u neizvesnom duelu protiv tima tehničke škole', 4, 2),
('Bioskop opet radi. Trebalo im je dve godine da ga naprave sve im je*em', 2, 3),
('Kafana princ nudi odličan provod uz muziku uživo. Metalike stop!', 4, 5)


INSERT INTO [dbo].[Posts]
([Content], [AuthorId], [ThreadId])
VALUES
('Bravo. Sledeće godine da pobede šesti tim osnovne škole 8. oktobar pa da budemo ponosni', 3, 2),
('Ma neeeeee, ne laže. To ti se samo čini xD', 2, 4),
('Sa lebom i solju kao pravi srpi', 4, 1)