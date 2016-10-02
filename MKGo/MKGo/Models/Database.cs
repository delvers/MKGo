using SQLite;
using SQLite.Net;
using SQLiteNetExtensions;
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
            database.CreateTable<Item>();
            database.CreateTable<Exhibition>();
            database.CreateTable<Tour>();
            database.CreateTable<TourItem>();
            database.CreateTable<CollectionItem>();
            database.CreateTable<Quest>();
            database.CreateTable<Room>();

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
                var olpe = new Item();
                olpe.Title = "Olpe mit Tierfriesen";
                olpe.Description = "Das schlanke Gefäß mit weit ausladender Mündung und dreiteiligem Rotellenhenkel ist " +
                    "mit drei durch Firnisstreifen getrennten Bildfriesen geschmückt. Der obere Fries zeigt eine zurückb" +
                    "lickende Sirene zwischen heraldisch angeordneten Sphingen zwischen schreitenden Panthern. Der mittl" +
                    "ere Panther, Damhirsch, Panther, Damhirsch, Löwe und Ziege, der untere eine zurückblickende Sirene " +
                    "zwischen zwei Sphingen zwischen Löwen und Panther sowie Stier, Löwe, Ziege, Panther. Die Räume zwis" +
                    "chen den Figuren sind mit Punktrosetten gefüllt. Unten, von dem Bildfries durch eine breite Firnisz" +
                    "one getrennt, befindet sich ein Strahlenkranz. Der schwarze Gefäßhals und Rotellen am Henkel sind mi" +
                    "t weißen Punktrosetten verziert. Im 7. Jahrhundert v. Chr. steigt Korinth zur wichtigsten Handelsmac" +
                    "ht unter den griechischen Stadtstaaten auf; deutlich erkennbar an der weiten Verbreitung der Keramik" +
                    ", die andere Kunstlandschaften stark beeinflusst, allen voran Athen. In Korinth werden zudem ein kom" +
                    "plexer Brennvorgang und die schwarzfigurige Technik entwickelt. Charakteristisch ist der gelbliche T" +
                    "on. Die Verzierungen bestehen aus Tierfriesen, Reitern, Kämpfen, Gelagen sowie zahlreichen Füllornamenten.";
                olpe.InventoryNumber = "1962.41";
                olpe.Prio = 5;
                olpe.Url = "http://sammlungonline.mkg-hamburg.de/de/object/Olpe-mit-Tierfriesen/1962.41/dc00126052";
                olpe.Id = 0;

                var hydria = new Item();
                hydria.Title = "Hydria (Naiskos-Szene)";
                hydria.Description = "Die monumentale Hydria wurde aus mehreren Teilen getöpfert; ihre Einzelteile sind " +
                    "schief aufeinander gesetzt. Das reich bemalte Gefäß zeigt auf der Vorderseite einen Naiskos mit drei" +
                    " Personen und außerhalb zu beiden Seiten je drei weitere Figuren. Der Naiskos steht auf einer breiten" +
                    " Mäanderbasis; seine Deckenbalken sind perspektivisch dargestellt; auf dem flachen Giebel befinden si" +
                    "ch drei Palmettenakrotere. Im Grabmal sitzt eine Frau auf einem reich verzierten Stuhl mit roter Decke" +
                    ", die Füße auf einen Schemel gestellt. Mit ihrer Rechten hält sie das über den Kopf gelegte Manteltuch" +
                    " und in der Linken ein geöffnetes Kästchen. Sie ist durch eine weiße Bemalung als Verstorbene hervorge" +
                    "hoben. Links und rechts stehen zwei Frauen, die wie die Sitzende mit kurzärmeligen Chitonen in verschi" +
                    "edenen Farben bekleidet sind. Die eine hält eine Tänie, die andere einen Fächer in der Hand. Auf den f" +
                    "reien Flächen verteilt sind ein Fächer, eine Tänie, ein Ball, eine Binde und eine Lekythos. Links vom " +
                    "Naiskos stehen zwei Figuren, ein nackter Jüngling und eine Frau, darüber ist eine weitere Frau in gela" +
                    "gerter Haltung zu sehen. Rechts befindet sich eine ähnliche Gruppe; die Liegende lagert unbekleidet au" +
                    "f ihrem Mantel. Die Rückseite ist bedeckt von reich wuchernden Palmettenornamenten, darunter ein umlau" +
                    "fender Kreuzplattenmäander.";
                hydria.InventoryNumber = "1984.447.b";
                hydria.Prio = 5;
                hydria.Url = "http://sammlungonline.mkg-hamburg.de/de/object/Hydria-Naiskos-Szene/1984.447.b/dc00126708";
                hydria.Id = 1;

                var pelike = new Item();
                pelike.Title = "Pelike (Boreas entführt Oreithyia)";
                pelike.Description = "Die Pelike ist aus zahlreichen Fragmenten zusammengesetzt. Fuß und unterer Teil des " +
                    "Gefäßkörpers sind ergänzt. Am Hals befindet sich auf beiden Seiten eine Leiste mit runden, umschriebe" +
                    "nen Palmetten. Unter den Figuren läuft ein Mäanderband mit regelmäßig eingestreuten Kreuzplatten um. " +
                    "Auf Seite A ist die Verfolgung der Oreithyia durch den Windgott Boreas dargestellt. Der geflügelte und" +
                    " bärtige Boreas eilt von links heran und hat seinen linken Arm um die Schulter der athenischen Königst" +
                    "ochter gelegt, mit der Rechten zwei Speere mit roten Wurfschlingen haltend. Boreas trägt eine Fuchspel" +
                    "zmütze (giech. alopekis), einen kurzen, gegürteten Chiton und einen gemusterten Mantel. Oreithyia ist " +
                    "mit einem langärmeligen Chiton und einem Diadem in den Haaren bekleidet; zudem trägt sie Schmuck um Arme" +
                    "und Hals. In den Gesichtszügen der Königstochter sind keine Anzeichen von Schrecken oder Ängstlichkeit" +
                    "abzulesen Die Hauptgruppe wird von zwei Figuren flankiert, die beide nach außen streben. Rechts der greise" +
                    "Vater Oreithyias, der athenische König Erechtheus. Links eine Gefährtin der Oreithyia. Seite B zeigt den" +
                    " Auszug des athenischen Heros Theseus, der heroisch nackt, nach rechts stehend, im Redegestus seinem Geg" +
                    "enüber die Rechte entgegenstreckt. Die Linke umfasst zwei lange Speere mit roten Wurfschlingen. Links, Theseus" +
                    "gegenüber, steht sein Vater, der König Aigeus von Athen, mit einem Chiton und einem Mantel mit gemusterter" +
                    "Bordüre bekleidet und einem Reif im Haar.";
                pelike.InventoryNumber = "1980.174";
                pelike.Prio = 5;
                pelike.Url = "http://sammlungonline.mkg-hamburg.de/de/object/Pelike-Boreas-entführt-Oreithyia/1980.174/dc00126652";
                pelike.Id = 2;

                lock (App.dbLock)
                {
                    database.Insert(olpe);
                    database.Insert(hydria);
                    database.Insert(pelike);

                }
            }
        }
    }
}
