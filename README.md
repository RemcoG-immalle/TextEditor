# Analyseer

Bekijk de volledige commit-geschiedenis om te bestuderen hoe dit project tot stand gekomen is.

Probeer volgende vragen te beantwoorden:

i.v.m. MSTest:

- Welke Assert-methods worden naast `Assert.AreEqual` nog allemaal gebruikt?
--- Assert.IsTrue(), Assert.IsFalse()
- Waarom heeft `TestDirectories` een `Initialize`- en `CleanUp`-method?
--- Om de test directory te verwijderen, om er voor te zorgen dat deze er niet is als wij de opdrachten uitvoeren.
- Zijn de attributen `[TestMethod]`, `[TestClass]`, ... noodzakelijk? (Test uit!)
--- Ja
- Wat is de shortcut om alle tests uit te voeren in VS?
--- Ctrl + r, Ctrl + a

i.v.m. Files en Directories:

- Wat is het voordeel van `Path.Combine` i.v.m. strings aan elkaar plakken?
--- Path.Combine zorgt voor het juiste teken om de 2 strings aan elkaar te plakken.
- Wordt de return-waarde van `Directory.CreateDirectory(...)` steeds opgevangen? (TIP: gebruik `CTRL-SHIFT-F`)
--- Nee
- Wat is de return-waarde van `Directory.CreateDirectory(...)`?
--- DirectoryInfo
- Wanneer is het nuttig om de return-waarde van `Directory.CreateDirectory(...)` op te vangen?
--- Als je waarde van de directory moet gebruiken/nakijken.

i.v.m. duidelijkheid/geschiedenis van de code:

- Lukken de testen in de commit 3ffe2c86? Waarom (niet)?
--- Nee, Except en Assert zijn omgewisseld.
- Wat lost commit d0320b6a op?
--- Expected en Actual omgewisseld.
- Wat is het probleem met de files in commit 9d184949?
--- Niet genoeg uitgewerkt
- Wat doet commit 9b3e4065? Maakt dit de code makkelijker leesbaar? Makkelijker uitbreidbaar?
--- Verduidelijking, makkelijker leesbaar en uitbereidbaar. De code is meer geordend.