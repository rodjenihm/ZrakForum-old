INSERT INTO [dbo].[Threads]
([Name], [AuthorId], [ForumId])
VALUES
('Vucic u vlasotincu',1,1),
('Precednik opstine laze',2,1),
('FK Vlasina sampinjon vlasotinca',2,2),
('Bioskop ponovo radi (njeknja)',2,3),
('Muzika uzivo u kafani princ',2,4);

INSERT INTO [dbo].[Posts]
([Content], [AuthorId], [ThreadId])
VALUES
('Dolazi veliki vodja. Kako cmeo ga decekati bratjo vlasotincani?', 1, 1),
('Da li je moguce da nas precednik laze? Ovo nije istina!!!', 2, 2),
('Konacno titula za plave. Vlasina osvojila kup vlasotinca u neizvesnom duelu sa timom tehnicke skole', 2, 3),
('Bioskop opet radi. Trebalo im je dve godine da ga naprave sve im jebem', 2, 4),
('Kafana princ nudi odlican provod uz muziku uzivo. metalike stop!', 2, 5)