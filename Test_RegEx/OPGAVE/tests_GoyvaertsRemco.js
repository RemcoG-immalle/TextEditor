// Pas in de eerste vraag enkel de variabele `re` aan. Niet de testen!
// Voor de laatste vraag voeg je onderaan een nieuwe QUnit.test(...) toe.
// Hernoem je bestand tests_AchernaamVoornaam.js en upload in de juiste map.
// (Enkel het .js bestand uploaden is voldoende)

QUnit.test("De woorden die beginnen met `b`, `m` of `h` en eindigen op `al`", function(assert) {
    // Gebruik een character range!
    var re = /[bmh]\w*al\b/;
    var str = "bal";
    var exc = "bal";
    assert.equal(re.exec(str), exc, "`bal` moet gematched worden");

    str = "mal";
    exc = "mal";
    assert.equal(re.exec(str), exc, "`mal` moet gematched worden");

    str = "malle";
    exc = null;
    assert.equal(re.exec(str), exc, "`malle` mag niet gematched worden want eindigt niet op `al`");

    str = "pal";
    exc = null;
    assert.equal(re.exec(str), exc, "`pal` mag niet gematched worden want begint niet met `b`, `m` of `h`");

    str = "hal";
    exc = "hal";
    assert.equal(re.exec(str), exc, "`hal` moet gematched worden");

    str = "halal";
    exc = "halal";
    assert.equal(re.exec(str), exc, "`halal` moet gematched worden");

    str = "banaal";
    exc = "banaal";
    assert.equal(re.exec(str), exc, "`banaal` moet gematched worden");
});

QUnit.test("Alle strings die er uit zien als een IP-adres, d.w.z. 4 getallen gescheiden door puntjes (vereenvoudigd).", function(assert) {
    var re = /\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}/;
    var str = "192.168.1.1";
    var exc = "192.168.1.1";
    assert.equal(re.exec(str), exc, "moet gematched worden");

    str = "255.255.255.0";
    exc = "255.255.255.0";
    assert.equal(re.exec(str), exc, "moet gematched worden");

    str = "12.12.12.12";
    exc = "12.12.12.12";
    assert.equal(re.exec(str), exc, "moet gematched worden");

    str = "0.0.0.0";
    exc = "0.0.0.0";   
    assert.equal(re.exec(str), exc, "moet gematched worden");

    // om het makkelijk te houden, mogen getallen groter dan 255 ook gebruikt worden
    // hoewel dit eigenlijk geen IP-adressen zijn!
    str = "256.0.0.0";
    exc = "256.0.0.0";
    assert.equal(re.exec(str), exc, "moet gematched worden");

    // getallen groter dan 999 mogen echter NIET gematched worden
    str = "1000.0.0.0";
    exc = null;
    assert.equal(re.exec(str), exc, "mag niet gematched worden");

    str = "ab.123.123.123";
    exc = null;
    assert.equal(re.exec(str), exc, "mag niet gematched worden");

    str = "12.12.344";
    exc = null;
    assert.equal(re.exec(str), exc, "mag niet gematched worden");

    str = "0.0";
    exc = null;   
    assert.equal(re.exec(str), exc, "mag niet gematched worden");
});

QUnit.test("Alle nummerplaten die bestaan uit 3 letters, een streepje en 3 cijfers.", function(assert) {
    var re = /^\w{3}\-\d{3}/;
    var str = "ABC-123";
    var exc = "ABC-123"; 
    assert.equal(re.exec(str), exc, "moet gematched worden");

    str = "1-ABC-123";
    exc = null; 
    assert.equal(re.exec(str), exc, "mag niet gematched worden");

    str = "9-ABC-123";
    exc = null; 
    assert.equal(re.exec(str), exc, "mag niet gematched worden");

    str = "10-ABC-123";
    exc = null; 
    assert.equal(re.exec(str), exc, "mag niet gematched worden");

    str = "A-ABC-123";
    exc = null; 
    assert.equal(re.exec(str), exc, "mag niet gematched worden");

    str = "AB-123";
    exc = null;
    assert.equal(re.exec(str), exc, "mag niet gematched worden");

    str = "ABC-D12";
    exc = null;
    assert.equal(re.exec(str), exc, "mag niet gematched worden");

    str = "ABC123";
    exc = null;
    assert.equal(re.exec(str), exc, "mag niet gematched worden");
});

QUnit.test("Een adres-regel bestaande uit een 4-cijferige postcode en een gemeente waarbij postcode en gemeente geparset worden. Gemeente kan streepjes bevatten", function(assert) {
    var re = /(\d{4})\s(\w+\-*\w*)/;
    var str = "2390 Malle";
    var r = re.exec(str);
    assert.equal(r[0], "2390 Malle");
    assert.equal(r[1], "2390");
    assert.equal(r[2], "Malle");

    str = "2000 Antwerpen";
    r = re.exec(str);
    assert.equal(r[0], "2000 Antwerpen");
    assert.equal(r[1], "2000");
    assert.equal(r[2], "Antwerpen");

    str = "Antwerpen";
    exc = null;
    assert.equal(re.exec(str), exc, "mag niet gematched worden");

    str = "123 XYZ";
    exc = null;
    assert.equal(re.exec(str), exc, "mag niet gematched worden");
});

// Schrijf zelf de tests voor een regex die alle bestanden die eindigen op `.pdf` en zorg ervoor dat de bestandsnaam (zonder de `.pdf`) ook aanwezig in de match.

QUnit.test("De filenames van alle .pdf bestanden (zonder de extensie)", function(assert) {
	var re = /(\w*)\.pdf/;
	var str = "bestandsnaam.pdf";
	var r = re.exec(str);
	assert.equal(r[0], "bestandsnaam.pdf");
	assert.equal(r[1], "bestandsnaam");
	
	str = "naam_van_bestand.pdf";
	r = re.exec(str);
	assert.equal(r[0], "naam_van_bestand.pdf");
	assert.equal(r[1], "naam_van_bestand");
});

