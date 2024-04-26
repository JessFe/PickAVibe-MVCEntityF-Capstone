INSERT INTO MoviesVibes (FK_MovieID, FK_VibeID)
VALUES
((SELECT MovieID FROM Movies WHERE Title = 'Interstellar'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Exploring')),
((SELECT MovieID FROM Movies WHERE Title = 'Interstellar'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Thought Provoking')),
((SELECT MovieID FROM Movies WHERE Title = 'Interstellar'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Escaping')),
((SELECT MovieID FROM Movies WHERE Title = 'Interstellar'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Futuristic')),
((SELECT MovieID FROM Movies WHERE Title = 'Interstellar'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Adventure')),
((SELECT MovieID FROM Movies WHERE Title = 'Interstellar'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Suspense')),
((SELECT MovieID FROM Movies WHERE Title = 'Interstellar'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Touching')),

((SELECT MovieID FROM Movies WHERE Title = 'Avatar'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Adventure')),
((SELECT MovieID FROM Movies WHERE Title = 'Avatar'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Exploring')),
((SELECT MovieID FROM Movies WHERE Title = 'Avatar'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Futuristic')),
((SELECT MovieID FROM Movies WHERE Title = 'Avatar'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Escaping')),
((SELECT MovieID FROM Movies WHERE Title = 'Avatar'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Thought Provoking')),

((SELECT MovieID FROM Movies WHERE Title = 'Spaceman'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Crying')),
((SELECT MovieID FROM Movies WHERE Title = 'Spaceman'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Exploring')),
((SELECT MovieID FROM Movies WHERE Title = 'Spaceman'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Melancholy')),
((SELECT MovieID FROM Movies WHERE Title = 'Spaceman'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Thought Provoking')),
((SELECT MovieID FROM Movies WHERE Title = 'Spaceman'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Touching')),
((SELECT MovieID FROM Movies WHERE Title = 'Spaceman'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Futuristic')),

((SELECT MovieID FROM Movies WHERE Title = 'Split'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Suspense')),
((SELECT MovieID FROM Movies WHERE Title = 'Split'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Scaring')),
((SELECT MovieID FROM Movies WHERE Title = 'Split'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Mystery')),

((SELECT MovieID FROM Movies WHERE Title = 'Inception'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Action')),
((SELECT MovieID FROM Movies WHERE Title = 'Inception'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Exploring')),
((SELECT MovieID FROM Movies WHERE Title = 'Inception'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Suspense')),
((SELECT MovieID FROM Movies WHERE Title = 'Inception'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Thought Provoking')),
((SELECT MovieID FROM Movies WHERE Title = 'Inception'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Adventure')),

((SELECT MovieID FROM Movies WHERE Title = 'Mulan'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Cartoons')),
((SELECT MovieID FROM Movies WHERE Title = 'Mulan'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Motivation')),
((SELECT MovieID FROM Movies WHERE Title = 'Mulan'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Back To Childhood')),

((SELECT MovieID FROM Movies WHERE Title = 'Howl''s Moving Castle'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Cartoons')),

((SELECT MovieID FROM Movies WHERE Title = 'Dead Poets Society'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Thought Provoking')),
((SELECT MovieID FROM Movies WHERE Title = 'Dead Poets Society'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Touching')),
((SELECT MovieID FROM Movies WHERE Title = 'Dead Poets Society'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Nostalgia')),
((SELECT MovieID FROM Movies WHERE Title = 'Dead Poets Society'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Melancholy')),
((SELECT MovieID FROM Movies WHERE Title = 'Dead Poets Society'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Letting Go')),

((SELECT MovieID FROM Movies WHERE Title = 'Mrs. Doubtfire'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Touching')),
((SELECT MovieID FROM Movies WHERE Title = 'Mrs. Doubtfire'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Cheerful')),
((SELECT MovieID FROM Movies WHERE Title = 'Mrs. Doubtfire'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Back To Childhood')),
((SELECT MovieID FROM Movies WHERE Title = 'Mrs. Doubtfire'), (SELECT VibeID FROM Vibes WHERE VibeName = 'A Good Laugh')),

((SELECT MovieID FROM Movies WHERE Title = 'Jumanji'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Adventure')),
((SELECT MovieID FROM Movies WHERE Title = 'Jumanji'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Suspense')),
((SELECT MovieID FROM Movies WHERE Title = 'Jumanji'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Exploring')),
((SELECT MovieID FROM Movies WHERE Title = 'Jumanji'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Cheerful')),
((SELECT MovieID FROM Movies WHERE Title = 'Jumanji'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Back To Childhood')),

((SELECT MovieID FROM Movies WHERE Title = 'Jack'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Touching')),
((SELECT MovieID FROM Movies WHERE Title = 'Jack'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Back To Childhood')),
((SELECT MovieID FROM Movies WHERE Title = 'Jack'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Thought Provoking')),
((SELECT MovieID FROM Movies WHERE Title = 'Jack'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Cheerful')),
((SELECT MovieID FROM Movies WHERE Title = 'Jack'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Melancholy')),

((SELECT MovieID FROM Movies WHERE Title = 'Patch Adams'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Touching')),
((SELECT MovieID FROM Movies WHERE Title = 'Patch Adams'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Back To Childhood')),
((SELECT MovieID FROM Movies WHERE Title = 'Patch Adams'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Thought Provoking')),
((SELECT MovieID FROM Movies WHERE Title = 'Patch Adams'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Cheerful')),
((SELECT MovieID FROM Movies WHERE Title = 'Patch Adams'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Melancholy')),
((SELECT MovieID FROM Movies WHERE Title = 'Patch Adams'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Crying')),
((SELECT MovieID FROM Movies WHERE Title = 'Patch Adams'), (SELECT VibeID FROM Vibes WHERE VibeName = 'True Story')),

((SELECT MovieID FROM Movies WHERE Title = 'What Dreams May Come'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Crying')),
((SELECT MovieID FROM Movies WHERE Title = 'What Dreams May Come'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Melancholy')),
((SELECT MovieID FROM Movies WHERE Title = 'What Dreams May Come'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Letting Go')),
((SELECT MovieID FROM Movies WHERE Title = 'What Dreams May Come'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Tenderness')),
((SELECT MovieID FROM Movies WHERE Title = 'What Dreams May Come'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Thought Provoking')),
((SELECT MovieID FROM Movies WHERE Title = 'What Dreams May Come'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Touching')),

((SELECT MovieID FROM Movies WHERE Title = 'Bicentennial Man'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Dreaming')),
((SELECT MovieID FROM Movies WHERE Title = 'Bicentennial Man'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Crying')),
((SELECT MovieID FROM Movies WHERE Title = 'Bicentennial Man'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Melancholy')),
((SELECT MovieID FROM Movies WHERE Title = 'Bicentennial Man'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Tenderness')),
((SELECT MovieID FROM Movies WHERE Title = 'Bicentennial Man'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Thought Provoking')),
((SELECT MovieID FROM Movies WHERE Title = 'Bicentennial Man'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Touching')),

((SELECT MovieID FROM Movies WHERE Title = 'Rocky'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Sport')),
((SELECT MovieID FROM Movies WHERE Title = 'Rocky'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Action')),
((SELECT MovieID FROM Movies WHERE Title = 'Rocky'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Motivation')),
((SELECT MovieID FROM Movies WHERE Title = 'Rocky'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Venting')),
((SELECT MovieID FROM Movies WHERE Title = 'Rocky'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Touching')),

((SELECT MovieID FROM Movies WHERE Title = 'Cinderella Man'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Sport')),
((SELECT MovieID FROM Movies WHERE Title = 'Cinderella Man'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Action')),
((SELECT MovieID FROM Movies WHERE Title = 'Cinderella Man'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Motivation')),
((SELECT MovieID FROM Movies WHERE Title = 'Cinderella Man'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Venting')),
((SELECT MovieID FROM Movies WHERE Title = 'Cinderella Man'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Touching')),
((SELECT MovieID FROM Movies WHERE Title = 'Cinderella Man'), (SELECT VibeID FROM Vibes WHERE VibeName = 'True Story')),

((SELECT MovieID FROM Movies WHERE Title = 'Rush'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Sport')),
((SELECT MovieID FROM Movies WHERE Title = 'Rush'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Action')),
((SELECT MovieID FROM Movies WHERE Title = 'Rush'), (SELECT VibeID FROM Vibes WHERE VibeName = 'True Story')),

((SELECT MovieID FROM Movies WHERE Title = 'Laws of Attraction'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Falling In Love')),
((SELECT MovieID FROM Movies WHERE Title = 'Laws of Attraction'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Tenderness')),
((SELECT MovieID FROM Movies WHERE Title = 'Laws of Attraction'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Cheerful')),
((SELECT MovieID FROM Movies WHERE Title = 'Laws of Attraction'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Touching')),
((SELECT MovieID FROM Movies WHERE Title = 'Laws of Attraction'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Coziness')),

((SELECT MovieID FROM Movies WHERE Title = '50 First Dates'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Falling In Love')),
((SELECT MovieID FROM Movies WHERE Title = '50 First Dates'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Tenderness')),
((SELECT MovieID FROM Movies WHERE Title = '50 First Dates'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Cheerful')),
((SELECT MovieID FROM Movies WHERE Title = '50 First Dates'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Touching')),
((SELECT MovieID FROM Movies WHERE Title = '50 First Dates'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Coziness')),

((SELECT MovieID FROM Movies WHERE Title = 'Chicago'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Music')),

((SELECT MovieID FROM Movies WHERE Title = '8 Mile'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Music')),
((SELECT MovieID FROM Movies WHERE Title = '8 Mile'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Melancholy')),
((SELECT MovieID FROM Movies WHERE Title = '8 Mile'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Venting')),
((SELECT MovieID FROM Movies WHERE Title = '8 Mile'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Motivation')),

((SELECT MovieID FROM Movies WHERE Title = 'Into the Wild'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Traveling')),
((SELECT MovieID FROM Movies WHERE Title = 'Into the Wild'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Dreaming')),
((SELECT MovieID FROM Movies WHERE Title = 'Into the Wild'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Melancholy')),
((SELECT MovieID FROM Movies WHERE Title = 'Into the Wild'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Escaping')),
((SELECT MovieID FROM Movies WHERE Title = 'Into the Wild'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Thought Provoking')),
((SELECT MovieID FROM Movies WHERE Title = 'Into the Wild'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Touching')),
((SELECT MovieID FROM Movies WHERE Title = 'Into the Wild'), (SELECT VibeID FROM Vibes WHERE VibeName = 'True Story')),

((SELECT MovieID FROM Movies WHERE Title = 'The Motorcycle Diaries'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Traveling')),
((SELECT MovieID FROM Movies WHERE Title = 'The Motorcycle Diaries'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Melancholy')),
((SELECT MovieID FROM Movies WHERE Title = 'The Motorcycle Diaries'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Escaping')),
((SELECT MovieID FROM Movies WHERE Title = 'The Motorcycle Diaries'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Thought Provoking')),
((SELECT MovieID FROM Movies WHERE Title = 'The Motorcycle Diaries'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Touching')),
((SELECT MovieID FROM Movies WHERE Title = 'The Motorcycle Diaries'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Adventure')),
((SELECT MovieID FROM Movies WHERE Title = 'The Motorcycle Diaries'), (SELECT VibeID FROM Vibes WHERE VibeName = 'True Story')),

((SELECT MovieID FROM Movies WHERE Title = 'Demolition Man'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Revenge')),
((SELECT MovieID FROM Movies WHERE Title = 'Demolition Man'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Action')),
((SELECT MovieID FROM Movies WHERE Title = 'Demolition Man'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Adventure')),
((SELECT MovieID FROM Movies WHERE Title = 'Demolition Man'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Venting')),
((SELECT MovieID FROM Movies WHERE Title = 'Demolition Man'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Dystopia')),

((SELECT MovieID FROM Movies WHERE Title = 'Law Abiding Citizen'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Revenge')),
((SELECT MovieID FROM Movies WHERE Title = 'Law Abiding Citizen'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Action')),
((SELECT MovieID FROM Movies WHERE Title = 'Law Abiding Citizen'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Thought Provoking')),
((SELECT MovieID FROM Movies WHERE Title = 'Law Abiding Citizen'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Suspense')),

((SELECT MovieID FROM Movies WHERE Title = 'Moon'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Melancholy')),
((SELECT MovieID FROM Movies WHERE Title = 'Moon'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Touching')),
((SELECT MovieID FROM Movies WHERE Title = 'Moon'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Suspense')),
((SELECT MovieID FROM Movies WHERE Title = 'Moon'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Futuristic')),

((SELECT MovieID FROM Movies WHERE Title = 'The Truman Show'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Melancholy')),
((SELECT MovieID FROM Movies WHERE Title = 'The Truman Show'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Letting Go')),
((SELECT MovieID FROM Movies WHERE Title = 'The Truman Show'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Thought Provoking')),
((SELECT MovieID FROM Movies WHERE Title = 'The Truman Show'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Touching')),
((SELECT MovieID FROM Movies WHERE Title = 'The Truman Show'), (SELECT VibeID FROM Vibes WHERE VibeName = 'Coziness'));