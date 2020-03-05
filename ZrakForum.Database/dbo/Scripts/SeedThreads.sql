INSERT INTO [dbo].[Threads]
([Name], [AuthorId], [ForumId])
VALUES
('Vučić u Vlasotincu',1,1),
('Predsednik opštine laže!?',2,1),
('FK Vlasina šampion Vlasotinca',2,2),
('Bioskop ponovo radi (njeknja)',2,3),
('Muzika uživo u kafani Princ',2,4);

INSERT INTO [dbo].[Posts]
([Content], [AuthorId], [ThreadId])
VALUES
('Dolazi veliki vođa. Kako ćemo ga dečekati braćo vlasotinčani?', 1, 1),
('Da li je moguće da naš predsednik laže? Ovo nije istina!!!', 2, 2),
('Konačno titula za plave. Vlasina osvojila kup vlasotinca u neizvesnom duelu protiv tima tehničke škole', 2, 3),
('Bioskop opet radi. Trebalo im je dve godine da ga naprave sve im je*em', 2, 4),
('Kafana princ nudi odličan provod uz muziku uživo. Metalike stop!', 2, 5)


INSERT INTO [dbo].[Posts]
([Content], [AuthorId], [ThreadId])
VALUES
('Bravo. Sledeće godine da pobede šesti tim osnovne škole 8. oktobar pa da budemo ponosni', 1, 3),
('Ma neeeeee, ne laže. To ti se samo čini xD', 1, 2),
('Sa lebom i solju kao pravi srpi', 2, 1)

