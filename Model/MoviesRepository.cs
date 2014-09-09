using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MoviesRepository
    {
        public static readonly Actor ChuckNorris = new Actor
        {
            FirstName = "Chuck",
            LastName = "Norris",
            PhotoURI = "/Assets;component/MoviesDB/Actors/ChuckNorrisWithUzis.jpg",
            OtherPhotosURIs = new []
            {
                "/Assets/MoviesDB/Actors/ChuckNorris1.jpg",
                "/Assets/MoviesDB/Actors/ChuckNorris2.jpg",
                "/Assets/MoviesDB/Actors/ChuckNorris3.jpg",
                "/Assets/MoviesDB/Actors/ChuckNorris4.jpg",
                "/Assets/MoviesDB/Actors/ChuckNorris5.jpg",
                "/Assets/MoviesDB/Actors/ChuckNorris6.jpg",
                "/Assets/MoviesDB/Actors/ChuckNorrisWithUzis.jpg"
            },
            Biography = @"===Early Life===
Norris was born in Ryan, Oklahoma on March 10, 1940, the son of Wilma (née Scarberry) and Ray Norris, who was a mechanic, bus driver, and truck driver.
Norris has English, and smaller amounts of Scottish, Welsh, and German, ancestry; he is also said to have Cherokee roots.
Norris was named after Carlos Berry, his father's minister.
He has two younger brothers, Wieland (deceased) and Aaron (a Hollywood producer).
When Norris was sixteen, his parents divorced, and he later relocated to Prairie Village, Kansas, and then to Torrance, California, with his mother and brothers.

Norris has described his childhood as downbeat. He was nonathletic, shy, and scholastically mediocre.

He joined the United States Air Force as an Air Policeman (AP) in 1958 and was sent to Osan Air Base, South Korea.
It was there that Norris acquired the nickname Chuck and began his training in Tang Soo Do (tangsudo), an interest that led to black belts in that art and the founding of the Chun Kuk Do (""Universal Way"") form.
When he returned to the United States, he continued to act as an AP at March Air Force Base in California.

Norris was discharged in August 1962. He worked for the Northrop Corporation and opened a chain of Karate schools including a storefront school in his then-hometown of Torrance on Hawthorne Boulevard. Norris' official website lists celebrity clients at the schools; among them Steve McQueen, Chad McQueen, Bob Barker, Priscilla Presley, Donny Osmond and Marie Osmond.

===Martial arts career===
Norris was defeated in his first two tournaments, dropping decisions to Joe Lewis and Allen Steen and three matches at the International Karate Championships to Tony Tulleners.
By 1967 Norris had improved enough that he scored victories over the likes of Lewis, Skipper Mullins, Arnold Urquidez, Victor Moore, Ron Marchini, and Steve Sanders.
In early 1968, Norris suffered the tenth and last loss of his career, losing an upset decision to Louis Delgado.
On November 24, 1968, he avenged his defeat to Delgado and by doing so won the Professional Middleweight Karate champion title, which he held for six consecutive years.
In 1969, he won Karate's triple crown for the most tournament wins of the year, and the Fighter of the Year award by Black Belt Magazine.

Norris made history in 1990 when he was the first Westerner in the documented history of Tae Kwon Do to be given the rank of 8th Degree Black Belt Grand Master.
In 1999, Norris was inducted into the Martial Arts History Museum's Hall of Fame.
On July 1, 2000, Norris was presented the Golden Lifetime Achievement Award by the World Karate Union Hall of Fame."
        };
        public static readonly Actor MelGibson = new Actor { FirstName = "Mel", LastName = "Gibson", PhotoURI = "/Assets;component/MoviesDB/Actors/MelGibson.jpg" };
        public static readonly Actor SylvesterStallone = new Actor { FirstName = "Sylvester", LastName = "Stallone", PhotoURI = "/Assets;component/MoviesDB/Actors/SylvesterStallone.jpg" };
        public static readonly Actor BruceWillis = new Actor { FirstName = "Bruce", LastName = "Willis", PhotoURI = "/Assets;component/MoviesDB/Actors/BruceWillis.jpg" };

        public static readonly Actor[] Actors = { ChuckNorris, MelGibson, SylvesterStallone, BruceWillis };

        public static readonly Movie[] Movies = null;

        static MoviesRepository()
        {
            Movie EnterTheDragon = new Movie { Title = "Enter The Dragon", PosterURI = "/Assets;component/MoviesDB/Posters/EnterTheDragon.jpg", ReleaseDate = new DateTime(1973, 07, 26), Actors = new[] { ChuckNorris } };
            Movie ReturnOfTheDragon = new Movie { Title = "Return Of The Dragon", PosterURI = "/Assets;component/MoviesDB/Posters/ReturnOfTheDragon.jpg", ReleaseDate = new DateTime(1972, 12, 30), Actors = new[] { ChuckNorris } };
            Movie GameOfDeath = new Movie { Title = "Game Of Death", PosterURI = "/Assets;component/MoviesDB/Posters/GameOfDeath.jpg", ReleaseDate = new DateTime(1978, 03, 23), Actors = new[] { ChuckNorris } };
            Movie CodeOfSilence = new Movie { Title = "Code Of Silence", PosterURI = "/Assets;component/MoviesDB/Posters/CodeOfSilence.jpg", ReleaseDate = new DateTime(1985, 05, 03), Actors = new[] { ChuckNorris } };
            Movie DeltaForce2 = new Movie { Title = "Delta Force 2", PosterURI = "/Assets;component/MoviesDB/Posters/DeltaForce2.jpg", ReleaseDate = new DateTime(1990, 08, 24), Actors = new[] { ChuckNorris } };
            Movie MissingInAction = new Movie { Title = "Missing In Action", PosterURI = "/Assets;component/MoviesDB/Posters/MissingInAction.jpg", Actors = new[] { ChuckNorris } };
            Movie SilentRage = new Movie { Title = "Silent Rage", PosterURI = "/Assets;component/MoviesDB/Posters/SilentRage.jpg", Actors = new[] { ChuckNorris } };
            Movie TheOctagon = new Movie { Title = "The Octagon", PosterURI = "/Assets;component/MoviesDB/Posters/TheOctagon.jpg", Actors = new[] { ChuckNorris } };

            Movie TheExpendables2 = new Movie { Title = "The Expendables 2", PosterURI = "/Assets;component/MoviesDB/Posters/TheExpendables2.jpg", Actors = new[] { ChuckNorris, SylvesterStallone, BruceWillis } };

            ChuckNorris.Movies = new[]
            {
                EnterTheDragon,
                ReturnOfTheDragon,
                GameOfDeath,
                CodeOfSilence,
                DeltaForce2,
                MissingInAction,
                SilentRage,
                TheOctagon,
                TheExpendables2
            };

            Movies = new[]
            {
                EnterTheDragon,
                ReturnOfTheDragon,
                GameOfDeath,
                CodeOfSilence,
                DeltaForce2,
                MissingInAction,
                SilentRage,
                TheOctagon,
                new Movie { Title = "Die Hard", PosterURI = "/Assets;component/MoviesDB/Posters/DieHard.jpg", Actors = new []{ BruceWillis } },
                new Movie { Title = "Die Hard 2", PosterURI = "/Assets;component/MoviesDB/Posters/DieHard2.jpg", Actors = new []{ BruceWillis } },
                new Movie { Title = "Die Hard 3", PosterURI = "/Assets;component/MoviesDB/Posters/DieHard3.jpg", Actors = new []{ BruceWillis } },
                new Movie { Title = "Die Hard 4", PosterURI = "/Assets;component/MoviesDB/Posters/DieHard4.jpg", Actors = new []{ BruceWillis } },
                new Movie { Title = "Die Hard 5", PosterURI = "/Assets;component/MoviesDB/Posters/DieHard5.jpg", Actors = new []{ BruceWillis } },
                new Movie { Title = "Lethal Weapon", PosterURI = "/Assets;component/MoviesDB/Posters/LethalWeapon.jpg", Actors = new []{ MelGibson } },
                new Movie { Title = "Lethal Weapon 2", PosterURI = "/Assets;component/MoviesDB/Posters/LethalWeapon2.jpg", Actors = new []{ MelGibson } },
                new Movie { Title = "Lethal Weapon 3", PosterURI = "/Assets;component/MoviesDB/Posters/LethalWeapon3.jpg", Actors = new []{ MelGibson } },
                new Movie { Title = "Lethal Weapon 4", PosterURI = "/Assets;component/MoviesDB/Posters/LethalWeapon4.jpg", Actors = new []{ MelGibson } },
                new Movie { Title = "The Expendables", PosterURI = "/Assets;component/MoviesDB/Posters/TheExpendables.jpg", Actors = new[]{ SylvesterStallone, BruceWillis } },
                TheExpendables2,
                new Movie { Title = "The Expendables 3", PosterURI = "/Assets;component/MoviesDB/Posters/TheExpendables3.jpg", Actors = new[]{ SylvesterStallone, MelGibson } },
                new Movie { Title = "The Sixth Sense", PosterURI = "/Assets;component/MoviesDB/Posters/TheSixthSense.jpg", Actors = new[]{ BruceWillis }  }
            };
        }
    }
}
