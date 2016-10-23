using SQLite;
using SQLite.Net;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MKGo
{
    public class Database
    {
        static object locker = new object();
        static private SQLiteConnection database;

        public Database()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            lock (App.dbLock)
            {
                database.CreateTable<Item>();
                database.CreateTable<Exhibition>();
                database.CreateTable<Tour>();
                database.CreateTable<TourItem>();
                database.CreateTable<CollectionItem>();
                database.CreateTable<Quest>();
                database.CreateTable<Room>();
            }

        }

        public SQLiteConnection GetConnection()
        {
            return database;
        }

        public void createExampleData()
        {
            var a = App.Items.GetItems().ToList();
            if (a.Count < 1)
            {
                // create Rooms
                var rooms = new List<Room>();
                rooms.Add(new Room("1. Das Alte Ägypten"));
                rooms.Add(new Room("2. Ägypten das Land der Pharaonen"));
                rooms.Add(new Room("3. Koptische Textilien"));
                rooms.Add(new Room("4. Homers Helden - Mythos & Wahrheit"));
                rooms.Add(new Room("5. Zeitalter der Tyrannis"));
                rooms.Add(new Room("6. Klassik und Wirklichkeit"));
                rooms.Add(new Room("7. Schönheit und Realismus"));
                rooms.Add(new Room("8. Das rätselhafte Volk der Etrusker"));

                // create Exhibition
                var exhibition = new Exhibition();
                exhibition.Title = "Antike";
                exhibition.Description = "Wer waren die Ägypter, Griechen und Römer? Drei Hochkulturen zu unterschiedlichen Zeiten. Doch es gab auch Austausch zwischen ihnen und mit anderen Völkern.";
                exhibition.Rooms = rooms;


                // create Items
                var items = new List<Item>();

                var vase = new Item();
                vase.Title = "Datenautobahn Nil | Data Highway Nile";
                vase.Description = "Schnurösengefäß mit Schiffsdarstellung \n"+
                "Auf den Schnurösengefäßen der vor-pharaonischen Zeit finden sich immer wieder Szenen mit vielrudrigen Schiffen. Das eiförmige Gefäß zeigt auf beiden Seiten jeweils ein Schiff. Das Schiff besitzt Kabinen, am Bug einen Zweig, dahinter Standarten. Am Gefäßfuß sind drei Bäume dargestellt. Es handelt sich um ein frühes Nilpanorama. \n" +
                "Herstellung: 	um 3300-3100 v. Chr. (Negade II, prädynastisch), Ägypten\n" +
                "Material: 	Ton";
                vase.InventoryNumber = "1919.2";
                vase.Prio = 1;
                vase.Url = "http://sammlungonline.mkg-hamburg.de/de/object/Schnurösengefäß-mit-Schiffsdarstellung/1919.2/dc00125086";
                vase.Id = 1;
                items.Add(vase);

                var tonfiguren = new Item();
                tonfiguren.Title = "Mein Gott, Dein Gott | My God, Your God";
                tonfiguren.Description = "Harpokrates\n"+
                "Der auf einer mehrfach profilierten Basis stehende Gott Harpokrates ist lediglich mit dem ägyptischen Nemes-Tuch, dem Kopftuch der Pharaonen, bekleidet. An eine Säule gelehnt, hält er in seinem angewinkelten linken Arm eine kleine Keule. Den Zeigefinger der rechten Hand führt er zum Mund. Die Figur zählt zur Gruppe der sog. Fayum-Terrakotten. In Alexandria, dem internationalen, griechisch geprägten Zentrum Ägyptens, lebt eine multikulturelle Gesellschaft aus Ägyptern, Orientalen, Griechen, Römern, Juden und anderen, deren unterschiedliche religiöse Vorstellungen sich allmählich vermischen. Einblicke in diese Glaubenswelt erlauben die sog. Fayum-Terrakotten. Sie sind Teil des religiösen Haushaltes, Kinderspielzeug, \"Nippesfiguren\", aber auch Kultsymbole, Grabbeigaben, Wallfahrtsbilder, Votivgaben und magische Objekte zur Bannung böser Mächte. Man findet sie in Häusern, Gräbern und Heiligtümern.\n" +
                "Herstellung: 	1.-2. Jahrhundert n. Chr., Ägypten\n" +
                "Material: 	Ton\n"+
                "Epoche/Stil: 	Frühe Kaiserzeit (Römische Antike), Mittlere Kaiserzeit (Römische Antike)";
                tonfiguren.InventoryNumber = "1989.349";
                tonfiguren.Prio = 2;
                tonfiguren.Url = "http://sammlungonline.mkg-hamburg.de/de/object/Harpokrates/1989.349/dc00126886";
                tonfiguren.Id = 2;
                items.Add(tonfiguren);

                var mumienporträt = new Item();
                mumienporträt.Title = "Vernetzte Traditionen | Connected Traditions ";
                mumienporträt.Description = "Mumienporträt einer Frau\n"+
                "Mumienporträts, mit Wachsfarben oder in Tempera-Technik ausgeführt, sind zu Hunderten im Fayum, einer Oase etwa 70 km südlich von Kairo, sowie in Mittel- und Oberägypten gefunden worden. Diese aus Holztafeln aus Zypresse, Linde oder Zeder gemalten Bilder wurden mit langen Mumienbinden über dem Gesicht der Verstorbenen befestigt. Von der frühen Kaiserzeit bis um 400 n. Chr. vermitteln sie ein eindringliches Bild vom Aussehen der Bevölkerung des Nillandes, die sich aus Ägyptern, Orientalen, Griechen, Juden und Römern zusammensetzte. Über die Auftraggeber informieren die Bildnisse selbst. Es ist die gehobene Bürgerschicht von Offizieren, Beamten, Kaufleuten und Priestern. Die Bildnisse informieren über Moden, Frisuren, Schmuck und anderes.\n"+
                "Herstellung:	spätes 2. Jahrhundert n. Chr., Ägypten (Er-Rubayat (Fayum))\n"+
                "Material:	Holz\n"+
                "Epoche/Stil:	Mittlere Kaiserzeit, Severer";
                mumienporträt.InventoryNumber = "1928.42";
                mumienporträt.Prio = 3;
                mumienporträt.Url = "http://sammlungonline.mkg-hamburg.de/de/object/Mumienporträt-einer-Frau/1928.42/dc00125645";
                mumienporträt.Id = 3;
                items.Add(mumienporträt);

                var perserkanne = new Item();
                perserkanne.Title = "Nackter Barbare | Naked Barbarian";
                perserkanne.Description = "Oinochoe ('Eurymedon-Kanne' oder 'Perser-Kanne')\n"+
                "Die Oinochoe trägt wohl eine der bedeutendsten Darstellungen griechischer Vasenkunst, die einen historischen Bezug aufweisen. Auf Seite A ist ein nach rechts laufender Grieche dargestellt. Der im Profil gezeigte Kopf weist einen Spitzbart sowie eine Bartpartie an der Wange auf. Er ist mit einem nach hinten wehenden Mäntelchen bekleidet, dessen Enden vor der Brust verknotet sind. Während der linke Arm vorgestreckt ist, hält er mit seiner angewinkelten Rechten seinen Phallus. Aus seinem Mund kommt die Inschrift 'Eurymedon eimi. Kybade Hekaste' ('Ich bin Eurymedon. ...') hervor, die schräg nach unten verlaufend zur Figur auf Seite B vermittelt. Dort steht ein nach vorn übergebeugter Mann in einem langen Jacken-Hosen-Kostüm, den Kopf frontal dem Betrachter zugewandt, die Hände beidseits des Kopfes in einem Schreckensgestus erhoben. An seinem linken Arm baumelt ein Gorytos (Pfeilköcher) mit Bogen herab. Auf dem Kopf trägt er eine sog. Phrygische Mütze, die ihn in Verbindung mit seinem Gewand als Orientalen kennzeichnet. Beide Figuren stehen auf einer umlaufenden tongrundigen Linie; oben wird das Bild von einem schmalen Mäanderband am Übergang zum Hals abgeschlossen. Der Name 'Eurymedon' erlaubt eine Deutung der Szene: An dem gleichnamigen kleinasiatischen Fluss (in der Nähe des heutigen Antalya) gelang dem Attisch-Delischen Seebund unter der Führung Athens und seines Strategen Kimon 469 oder 466 v. Chr. in einer Doppelschlacht zu Lande und zu Wasser ein umfänglicher Sieg. Der Sieg wird auf dieser Kanne brutal und erniedrigend dargestellt, wird doch in der nächsten Sekunde der Grieche den Perser erreicht haben und ihn sexuell missbrauchen. Wieso wird ein solcher Sieg in dieser Weise dargestellt? Warum ist der Grieche eher unkonventionell, geradezu halb-barbarisch gezeigt? Vermutlich steht die Darstellung in Verbindung mit einem possenhaften Theaterstück.\n"+
                "Herstellung:	um 460 v. Chr., Athen\n"+
                "Material:	Ton\n"+
                "Epoche/Stil:	Strenger Stil (frühklassisch)";
                perserkanne.InventoryNumber = "1981.173";
                perserkanne.Prio = 4;
                perserkanne.Url = "http://sammlungonline.mkg-hamburg.de/de/object/Oinochoe-Eurymedon-Kanne-oder-Perser-Kanne/1981.173/dc00126657?s=griechen&h=0";
                perserkanne.Id = 4;
                items.Add(perserkanne);

                var afrikanerkopf = new Item();
                afrikanerkopf.Title = "Exotik im Kopf | Exotic in the Head";
                afrikanerkopf.Description = "Kännchen in Form eines Afrikanerkopfes\n"+
                "Das Kännchen hat einen schlanken, hohen Hals mit Kleeblattausguss und einen hohen Henkel. Diese Partien sind außen und innen schwarz gefirnisst; um das untere Ende des Halses zieht sich ein heller Perlfries. Der Bauch der Kanne wird durch den Kopf gebildet, der bis zu den Schulteransätzen wiedergegeben ist. Das krause Haar, die wulstigen Lippen und die schwarze, glänzende Oberfläche charakterisieren ihn als Afrikaner. Er trägt eine phrygische Mütze, die noch rosa Farbreste aufweist. Auf den Lippen und an der Standfläche des Gefäßes sind Reste roter Farbe zu erkennen. Augen und Zähne sind weiß, an den Augen auch Spuren von grüner Farbe. Während umfangreicher Entdeckungs- und Handelsreisen entwickeln die Griechen, insbesondere aber die Athener, eine Vorliebe für das Exotische. Sie schlägt sich auch in der Produktion von Bildern, Skulpturen und Gebrauchsgegenständen nieder.\n"+
                "Herstellung:	Mitte 4. Jahrhundert v. Chr., Athen\n"+
                "Material:	Ton\n"+
                "Epoche/Stil:	Spätklassik (Griechische Antike)";
                afrikanerkopf.InventoryNumber = "1962.126";
                afrikanerkopf.Prio = 5;
                afrikanerkopf.Url = "http://sammlungonline.mkg-hamburg.de/de/object/Kännchen-in-Form-eines-Afrikanerkopfes/1962.126/dc00126056";
                afrikanerkopf.Id = 5;
                items.Add(afrikanerkopf);

                var bettler = new Item();
                bettler.Title = "Der Bucklige Bettler | The Ugly Beggar";
                bettler.Description = "Statuette eines Buckligen\n"+
                "Die meisterhaft modellierte Kleinbronze mit den in Silber eingelegten Augen und Zähnen gehört zur Gruppe von Schauspielern, Akrobaten, Zwergen und Straßentypen, die in der hellenistischen Kleinkunst beliebt waren. Aus Alexandria und Kleinasien sind solche Darstellungen seit dem 3. Jahrhundert v. Chr. in großer Zahl bekannt. Mit ihren komischen Bewegungen oder ihrem Aussehen riefen sie allgemeine Heiterkeit hervor, wenn sie bei Gastmählern oder Festspielen auftraten, und man freute sich der eigenen Unversehrtheit. Körperliches Anderssein war auch Ausweis eines schlechten Charakters, sodass die Grotesken als Personifikationen des Übels galten. Man war der Auffassung, dass nur mit dem Anblick des Übels das Üble zu bannen sei. So wurden Missgestaltete durch die Stadt geführt, um alles Unheil auf sie zu übertragen.\n"+
                "Herstellung:	3. Jahrhundert v. Chr., Ägypten (vermutlich Alexandria)\n"+
                "Material:	Bronze, Silber (Augen)\n"+
                "Epoche/Stil:	frühhellenistisch (Griechische Antike)";
                bettler.InventoryNumber = "1949.40";
                bettler.Prio = 6;
                bettler.Url = "http://sammlungonline.mkg-hamburg.de/de/object/Statuette-eines-Buckligen/1949.40/dc00125916";
                bettler.Id = 6;
                items.Add(bettler);

                var sphinx = new Item();
                sphinx.Title = "Das Mischwesen | The Mixed Beast";
                sphinx.Description = "Sphinx\n"+
                "Die 'Hamburger Sphinx' im geläufigen griechischen Sitzschema zählt zum Besten, was an archaischer etruskischer Plastik erhalten ist. Der walzenförmige Löwenkörper des mächtigen Mischwesens ist im Profil gezeigt, während der menschengestaltige Kopf den Betrachter frontal ansieht. Die Flügel sind sichelförmig aufwärts gebogen, der Schwanz ist schwungvoll um den rechten hinteren Schenkel gelegt. In einigen Details, so der Bildung des Mundes, der Augen und der Frisur, hat die griechische Kunst unverkennbar ihre Spuren hinterlassen. Der poröse Stein der hockenden Sphinx war ursprünglich mit einer dünnen Stuckschicht überzogen, die in lebhaften Farben bemalt war. Sphingen, Löwen, Hippokampen und andere Tiere standen vor den Eingängen etruskischer Gräber, um für den Schutz der Anlage Sorge zu tragen. Gegenüber früheren Vorstellungen hat ein Wandel stattgefunden: Gezeigt wird nicht mehr ein Schrecken und Angst einflößendes, dämonisches Wesen, sondern eine gütige Wächterin.\n"+
                "Herstellung:	3. Viertel 6. Jahrhundert v. Chr., Italien (vermutlich Vulci)\n"+
                "Material:	Tuffstein (Nenfro-Tuff)";
                sphinx.InventoryNumber = "1973.43";
                sphinx.Prio = 7;
                sphinx.Url = "http://sammlungonline.mkg-hamburg.de/de/object/Sphinx/1973.43/dc00126601";
                sphinx.Id = 7;
                items.Add(sphinx);


                var tour = new Tour();
                tour.Author = "no one";
                tour.Title = "Begegnungen mit dem Fremden";
                tour.MapFile = "item19893491.jpg";
                tour.Exhibition = exhibition;
                tour.Items = items;

                lock (App.dbLock)
                {

                    database.InsertAll(rooms);
                    database.InsertWithChildren(exhibition, recursive: true);
                    database.InsertAllWithChildren(items, recursive:true);
                    database.InsertWithChildren(tour, recursive: true);
                }
            }
        }
    }
}
