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
                vase.Title = "Schnurösengefäß mit Schiffsdarstellung";
                vase.Detail = "Datenautobahn Nil";
                vase.Detail_en = "Data Highway Nile";
                vase.Description = "Auf dieser Vase ist die abstrakte Darstellung eines Schiffes zu sehen. Die Abbildung gibt Auskunft darüber, wie die alten Ägypter sich mit Menschen aus weit entfernten Gebieten ausgetauscht haben - über den Seeweg. Der Nil war nicht nur Handelsstraße, sondern auch so etwas wie eine Datenautobahn, auf der Informationen viel schneller verschickt werden konnten als über Land.";
                vase.Creationdate = "um 3300-3100 v. Chr. (Negade II, prädynastisch)";
                vase.Findspot = "Ägypten";
                vase.Material = "Ton";
                vase.InventoryNumber = "1919.2";
                vase.Prio = 1;
                vase.Url = "http://sammlungonline.mkg-hamburg.de/de/object/Schnurösengefäß-mit-Schiffsdarstellung/1919.2/dc00125086";
                vase.Id = 1;
                items.Add(vase);

                var tonfiguren = new Item();
                tonfiguren.Title = "Harpokrates";
                tonfiguren.Detail = "Mein Gott! Dein Gott!";
                tonfiguren.Detail_en = "My God! Your God!";
                tonfiguren.Description = "Die Tonfigur des Gottes Harpokrates zeigt, wie Griechen den altägyptischen Horuskind-Gott in ihren Glauben übernahmen. In Alexandria lebte eine multikulturelle Gesellschaft aus Ägyptern, Orientalen, Griechen, Römern, Juden und anderen, deren unterschiedliche religiöse Vorstellungen sich allmählich vermischten. Die Figuren dienten als Kinderspielzeug, aber auch Kultsymbole, Grabbeigaben und magische Objekte zur Bannung böser Mächte.";
                tonfiguren.Creationdate = "1.-2. Jahrhundert n. Chr.";
                tonfiguren.Findspot = "Ägypten";
                tonfiguren.Material = "Ton";
                tonfiguren.Era = "Frühe Kaiserzeit (Römische Antike), Mittlere Kaiserzeit (Römische Antike)";
                tonfiguren.InventoryNumber = "1989.349";
                tonfiguren.Prio = 2;
                tonfiguren.Url = "http://sammlungonline.mkg-hamburg.de/de/object/Harpokrates/1989.349/dc00126886";
                tonfiguren.Id = 2;
                items.Add(tonfiguren);

                var mumienporträt = new Item();
                mumienporträt.Title = "Mumienporträt einer Frau";
                mumienporträt.Detail = "Vernetzte Traditionen";
                mumienporträt.Detail_en = "Connected Traditions";
                mumienporträt.Description = "Wie kommt das Bild einer römischen Frau auf ein ägyptisches Mumienporträt? Solche Mumienporträts geben uns ein aufschlussreiches Bild vom Aussehen der Bevölkerung des Nillandes. Sie zeigen auch, dass dort lebende Orientalen, Griechen, Juden und Römer die ägyptische Tradition übernommen haben, bei der auf Holztafeln gemalte Bilder mit langen Mumienbinden über dem Gesicht der Verstorbenen befestigt wurden. Die Bildnisse von Beamten, Offizieren, Kaufleuten und Priestern der gehobene Bürgerschicht informieren auch über Moden, Frisuren, Schmuck und anderes.";
                mumienporträt.Creationdate = "spätes 2. Jahrhundert n. Chr.";
                mumienporträt.Findspot = "Ägypten (Er-Rubayat (Fayum))";
                mumienporträt.Material = "Holz";
                mumienporträt.Era = "Mittlere Kaiserzeit, Severer";
                mumienporträt.InventoryNumber = "1928.42";
                mumienporträt.Prio = 3;
                mumienporträt.Url = "http://sammlungonline.mkg-hamburg.de/de/object/Mumienporträt-einer-Frau/1928.42/dc00125645";
                mumienporträt.Id = 3;
                items.Add(mumienporträt);

                var perserkanne = new Item();
                perserkanne.Title = "Oinochoe (Perser-Kanne)";
                perserkanne.Detail = "Nackter Barbare";
                perserkanne.Detail_en = "Naked Barbarian";
                perserkanne.Description = "Die Oinochoe trägt wohl eine der bedeutendsten Darstellungen griechischer Vasenkunst, die einen historischen Bezug aufweisen. Auf Seite A ist ein nach rechts laufender Grieche dargestellt. Der im Profil gezeigte Kopf weist einen Spitzbart sowie eine Bartpartie an der Wange auf. Er ist mit einem nach hinten wehenden Mäntelchen bekleidet, dessen Enden vor der Brust verknotet sind. Während der linke Arm vorgestreckt ist, hält er mit seiner angewinkelten Rechten seinen Phallus. Aus seinem Mund kommt die Inschrift 'Eurymedon eimi. Kybade Hekaste' ('Ich bin Eurymedon. ...') hervor, die schräg nach unten verlaufend zur Figur auf Seite B vermittelt. Dort steht ein nach vorn übergebeugter Mann in einem langen Jacken-Hosen-Kostüm, den Kopf frontal dem Betrachter zugewandt, die Hände beidseits des Kopfes in einem Schreckensgestus erhoben. An seinem linken Arm baumelt ein Gorytos (Pfeilköcher) mit Bogen herab. Auf dem Kopf trägt er eine sog. Phrygische Mütze, die ihn in Verbindung mit seinem Gewand als Orientalen kennzeichnet. Beide Figuren stehen auf einer umlaufenden tongrundigen Linie; oben wird das Bild von einem schmalen Mäanderband am Übergang zum Hals abgeschlossen. Der Name 'Eurymedon' erlaubt eine Deutung der Szene: An dem gleichnamigen kleinasiatischen Fluss (in der Nähe des heutigen Antalya) gelang dem Attisch-Delischen Seebund unter der Führung Athens und seines Strategen Kimon 469 oder 466 v. Chr. in einer Doppelschlacht zu Lande und zu Wasser ein umfänglicher Sieg. Der Sieg wird auf dieser Kanne brutal und erniedrigend dargestellt, wird doch in der nächsten Sekunde der Grieche den Perser erreicht haben und ihn sexuell missbrauchen. Wieso wird ein solcher Sieg in dieser Weise dargestellt? Warum ist der Grieche eher unkonventionell, geradezu halb-barbarisch gezeigt? Vermutlich steht die Darstellung in Verbindung mit einem possenhaften Theaterstück.";
                perserkanne.Creationdate = "um 460 v. Chr.";
                perserkanne.Findspot = "Athen";
                perserkanne.Material = "Ton";
                perserkanne.Era = "Strenger Stil (frühklassisch)";
                perserkanne.InventoryNumber = "1981.173";
                perserkanne.Prio = 4;
                perserkanne.Url = "http://sammlungonline.mkg-hamburg.de/de/object/Oinochoe-Eurymedon-Kanne-oder-Perser-Kanne/1981.173/dc00126657?s=griechen&h=0";
                perserkanne.Id = 4;
                items.Add(perserkanne);

                var afrikanerkopf = new Item();
                afrikanerkopf.Title = "Kännchen in Form eines Afrikanerkopfes";
                afrikanerkopf.Detail = "Exotik im Kopf";
                afrikanerkopf.Detail_en = "Exotic in the Head";
                afrikanerkopf.Description = "Krauses Haar, wulstigen Lippen und schwarze, glänzende Oberfläche charakterisieren die Figur auf diesem Kännchen als Afrikaner. Während umfangreicher Entdeckungs- und Handelsreisen entwickeln die Griechen eine Vorliebe für das Exotische. Sie schlägt sich auch in der Produktion von Bildern, Skulpturen und Gebrauchsgegenständen nieder.";
                afrikanerkopf.Creationdate = "Mitte 4. Jahrhundert v. Chr.";
                afrikanerkopf.Findspot = "Athen";
                afrikanerkopf.Material = "Material:	Ton";
                afrikanerkopf.Era = "Spätklassik (Griechische Antike)";
                afrikanerkopf.InventoryNumber = "1962.126";
                afrikanerkopf.Prio = 5;
                afrikanerkopf.Url = "http://sammlungonline.mkg-hamburg.de/de/object/Kännchen-in-Form-eines-Afrikanerkopfes/1962.126/dc00126056";
                afrikanerkopf.Id = 5;
                items.Add(afrikanerkopf);

                var bettler = new Item();
                bettler.Title = "Statuette eines Buckligen";
                bettler.Detail = "Personifikationen des Übels";
                bettler.Detail_en = "Personifications of Evil";
                bettler.Description = "Klein, dunkel, bucklig und hässlich - skurrile Figuren wie diese waren in der hellenistischen Kleinkunst beliebt. Die Darstellungen von Schauspielern, Akrobaten, Zwergen und Straßentypen riefen mit ihrem komischen Aussehen allgemeine Heiterkeit hervor. Man erfreute sich der eigenen Unversehrtheit. Körperliches Anderssein war auch Ausweis eines schlechten Charakters, sodass die Grotesken als Personifikationen des Übels galten. Man war der Auffassung, dass nur mit dem Anblick des Übels das Üble zu bannen sei. So wurden Missgestaltete durch die Stadt geführt, um alles Unheil auf sie zu übertragen.";
                bettler.Creationdate = "3. Jahrhundert v. Chr.";
                bettler.Findspot = "Ägypten (vermutlich Alexandria)";
                bettler.Material = "Bronze, Silber (Augen)";
                bettler.Era = "frühhellenistisch (Griechische Antike)";
                bettler.InventoryNumber = "1949.40";
                bettler.Prio = 6;
                bettler.Url = "http://sammlungonline.mkg-hamburg.de/de/object/Statuette-eines-Buckligen/1949.40/dc00125916";
                bettler.Id = 6;
                items.Add(bettler);

                var sphinx = new Item();
                sphinx.Title = "Sphinx";
                sphinx.Detail = "Das Mischwesen";
                sphinx.Detail_en = "The Mixed Beast";
                sphinx.Description = "Der Körper einer Raubkatze, Flügel und ein menschlicher Kopf - diese Skulptur stellt eine Sphinx dar. Ursprünglich stammte dieses Mischwesen aus dem Orient, fand jedoch seit dem 7. Jahrhundert vor Christus Eingang in das griechische und etruskische Kunstschaffen. Paarweise aufgestellt bewachten solche Sphinxe etruskische Gräber. Gegenüber früheren Vorstellungen hat ein Wandel stattgefunden: Gezeigt wird nicht mehr ein Schrecken und Angst einflößendes, dämonisches Wesen, sondern eine gütige Wächterin.";
                sphinx.Creationdate = "3. Viertel 6. Jahrhundert v. Chr.";
                sphinx.Findspot = "Italien (vermutlich Vulci)";
                sphinx.Material = "Tuffstein (Nenfro-Tuff)";
                sphinx.InventoryNumber = "1973.43";
                sphinx.Prio = 7;
                sphinx.Url = "http://sammlungonline.mkg-hamburg.de/de/object/Sphinx/1973.43/dc00126601";
                sphinx.Id = 7;
                items.Add(sphinx);


                var tour = new Tour();
                tour.Author = "no one";
                tour.Title = "Begegnungen mit dem Fremden";
                tour.Description = "Eine Tour durch die Antike.";
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
