using BookDB.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace BookDB.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private static List<Books> books = new List<Books>
            {
                //Buku Teknologi
                new Books
                {
                    Id = 1,
                    Title= "Dasar Internet Teknologi IoT (Internet of Thing) dan Bahasa HTML",
                    Image = "https://foto-finalproject.vercel.app/Teknologi1.png",
                    Author= "Rusito, S.Kom, M.Kom",
                    Category= "Teknologi",
                    Publication = 2021,
                    Publisher = "Yayasan Prima Agus Teknik \r\nRedaksi: Jln Majapahit No 605 Semarang\r\n",
                    File = "https://digilib.stekom.ac.id/assets/dokumen/ebook/feb_e3a990ba50b213e0479c55050f002fdcf21745a1_1642134188.pdf",
                },
                new Books
                {
                    Id = 2,
                    Title= "Educational Technology",
                    Image = "https://foto-finalproject.vercel.app/Teknologi2.png",
                    Author= "Alan Januszweski dan Michael Molenda",
                    Category= "Teknologi",
                    Publication = 2019,
                    Publisher = "Lawrence Erlbaum Associates Taylor & Francis\r\nGroup 270 Madison Avenue New York, NY\r\n10016",
                    File = "https://foto-finalproject.vercel.app/docs/Teknologi/etikaprofesional.pdf",
                },
                new Books
                { Id = 3,
                  Title = "Ilmu Teknologi Pangan",
                  Image = "https://foto-finalproject.vercel.app/Teknologi3.png",
                  Author = "aryam Razak, STP., M.Si. dan Muntikah, SP., M.Pd.",
                  Category = "Teknologi" ,
                  Publication = 2017,
                  Publisher = "Pusat Pendidikan Sumber Daya Manusia Kesehatan",
                  File = "https://digilib.stekom.ac.id/assets/dokumen/ebook/feb_e3a990ba50b213e0479c55050f002fdcf21745a1_1642134188.pdf",
                },
                new Books
                { Id = 4,
                  Title = "INOVASI TEKNOLOGI AKUAKULTUR",
                  Image = "https://foto-finalproject.vercel.app/Teknologi4.png",
                  Author = "Susi Pudjiastuti",
                  Category = "Teknologi" ,
                  Publication = 2016,
                  Publisher = "Sekretaris Direktorat Jenderal Perikanan Budidaya",
                  File = "https://foto-finalproject.vercel.app/docs/Teknologi/inovasiakuakultur.pdf",
                },
                new Books
                { Id = 5,
                  Title = "TEKNOLOGI FERMENTASI \r\nHASIL-HASIL PERTANIAN \r\n( WINE, SAKE, BREM  BALI  DAN\r\nVINEGAR)",
                  Image = "https://foto-finalproject.vercel.app/Teknologi5.png",
                  Author = "W. SUDJATHA dan NI WAYAN WISANIYASA",
                  Category = "Teknologi" ,
                  Publication = 2017,
                  Publisher = "Prof. Ir. W. Sudjatha\r\nNi Wayan Wisaniyasa, S.TP., MP",
                  File = "https://foto-finalproject.vercel.app/docs/Teknologi/teknologifermentasi.pdf",
                },
                //Buku Bisnis
                new Books
                { Id = 1,
                  Title = "597 Business Ideas You Can Start From Home",
                  Image = "https://foto-finalproject.vercel.app/Bisnis1.png",
                  Author = "Gundi Gabrielle",
                  Category = "Bisnis" ,
                  Publication = 2018,
                  File = "https://foto-finalproject.vercel.app/docs/Bisnis/597BusinessIdeasYoucanStartfromHome-doingwhatyouLOVE!(PDFDrive).pdf",
                  Publisher = "Happy Dolphin Enterprises LLC\r\n",
                },
                new Books
                { Id = 2,
                  Title = "BAGAIMANA MEMULAI BISNIS KECIL\r\nYANG SUKSES ",
                  Image = "https://foto-finalproject.vercel.app/Bisnis2.png",
                  Author = "AR. Rahadian",
                  Category = "Bisnis" ,
                  Publication = 2020,
                  File = "https://foto-finalproject.vercel.app/docs/Bisnis/BAGAIMANA_MEMULAI_BISNIS_KECIL_YANG_SUKS.pdf",
                  Publisher = "AR. Rahadian",
                },
                new Books
                { Id = 3,
                  Title = "eBook Gratis Cara memilih dan membangun bisnis hebat dari peluang usaha apapun [Step by Step]",
                  Image = "https://foto-finalproject.vercel.app/Bisnis3.png",
                  Author = "Rimawan I",
                  Category = "Bisnis" ,
                  Publication = 2018,
                  File = "https://foto-finalproject.vercel.app/docs/Bisnis/eBook_Gratis_Cara_memilih_dan_membangun.pdf",
                  Publisher = "https://www.academia.edu (Rimawan I)",
                },
                new Books
                { Id = 4,
                  Title = "Start and Run a Business From Home",
                  Image = "https://foto-finalproject.vercel.app/Bisnis4.png",
                  Author = "Paul Power",
                  Category = "Bisnis" ,
                  Publication = 2009,
                  File = "https://finalproject.vercel.app/docs/Bisnis/StartandRunABusinessFromHomeHowtoturnyourhobbyorinterestintoabusiness(SmallBusinessStart-Ups)(PDFDrive).pdf",
                  Publisher = "How To Content, \r\nA division of How To Books Ltd,\r\nSpring Hill House, Spring Hill Road,\r\nBegbroke, Oxford OX5 1RX, United Kingdom\r\nTel: (01865) 375794 Fax: (01865) 379162\r\n",
                },
                new Books
                { Id = 5,
                  Title = "The\t5\tSecond\tRule:\r\nTransform\tYour\tLife,\tWork,\tand\tConfidence\twith\tEveryday\tCourage\r\n",
                  Author = "Greg\tJohnson dan Rachel\tGreenberg\r\n",
                  Image = "https://foto-finalproject.vercel.app/Bisnis5.png",
                  Category = "Bisnis" ,
                  Publication = 2017,
                  File = "https://foto-finalproject.vercel.app/docs/Bisnis/The5SecondRule_TransformyourLifeWorkandConfidencewithEverydayCourage(PDFDrive).pdf",
                  Publisher = "SAVIO REPVBLIC",
                },
                //Buku Olahraga
                new Books
                { Id = 1,
                  Title = "MANAJEMEN PENJAS \r\nDAN OLAHRAGA",
                  Author = "Irfandi, M.Or dan Zikrur Rahmat, M.Pd.",
                  Image = "https://foto-finalproject.vercel.app/Olahraga1.png",
                  Category = "Olahraga" ,
                  Publication = 2020,
                  File = "https://foto-finalproject.vercel.app/docs/Olahraga/Manajemen_Penjas_dan_Olahraga.pdf",
                  Publisher = "Yuma Pustaka",
                },
                new Books
                { Id = 2,
                  Title = "Nutrition For Sport, Exercise and Performance",
                  Image = "https://foto-finalproject.vercel.app/Olahraga2.png",
                  Author = "Regina Belski, Adrienne Forsyth, dan Evangeline Mantzioris",
                  Category = "Olahraga" ,
                  Publication = 2020,
                  File = "https://foto-finalproject.vercel.app/docs/Olahraga/Nutrition-for-Sport-Exercise-and-Performance-A-practical-guide-for-students-sports-enthusiasts-and-professionals(PDFDrive).pdf",
                  Publisher = "Book 4",
                },
                new Books
                { Id = 3,
                  Title = "Sport Analytics And Data Science : Winning The Game With Methods and Models",
                  Image = "https://foto-finalproject.vercel.app/Olahraga3.png",
                  Author = "Thomas W. Miller",
                  Category = "Olahraga" ,
                  Publication = 2015,
                  File = "https://foto-finalproject.vercel.app/docs/Olahraga/Sports-Analytics-and-Data-Science-Winning-the-Game-with-Methods-and-Models-(PDFDrive).pdf",
                  Publisher = "Thomas W. Miller",
                },
                new Books
                { Id = 4,
                  Title = "SPORTS MATH\r\nAn Introductory Course in the Mathematics of Sports Science and Sports Analytics",
                  Image = "https://foto-finalproject.vercel.app/Olahraga4.png",
                  Author = "Roland B. Minton",
                  Category = "Olahraga" ,
                  Publication = 2019,
                  File = "https://foto-finalproject.vercel.app/docs/Olahraga/Sports-Math-An-Introductory-Course-in-the-Mathematicsof-Sports-Science-and-Sports-Analytics-(PDFDrive).pdf",
                  Publisher = "CRC Press Taylor & Francis Group",
                },
                new Books
                { Id = 5,
                  Title = "Sports \r\nPsychology\r\nFOR\r\nDUMmIES\r\n‰",
                  Image = "https://foto-finalproject.vercel.app/Olahraga5.png",
                  Author = "Leif H. Smith, PsyD, dan\r\nTodd M. Kays, PhD",
                  Category = "Olahraga" ,
                  Publication = 2017,
                  File = "https://foto-finalproject.vercel.app/docs/Olahraga/Sports-Psychology-For-Dummies-(PDFDrive).pdf",
                  Publisher = "John Wiley & Sons Canada Ltd.",
                },
                //Buku Kesehatan
                new Books
                { Id = 1,
                  Title = "Pendidikan Remaja Sebaya",
                  Author = "Palang Merah Indonesia (PMI)",
                  Image = "https://foto-finalproject.vercel.app/Kesehatan1.png",
                  Category = "Kesehatan" ,
                  Publication = 2018,
                  File = "https://foto-finalproject.vercel.app/docs/Kesehatan/Buku-PMI%E2%80%93Pendidikan-Kesehatan-Remaja-untuk-pendidik-sebaya-tahun-2008(PDFDrive).pdf",
                  Publisher = "Palang Merah Indonesia (PMI)",
                },
                new Books
                { Id = 2,
                  Title = "Kesehatan dan Keselamatan Kerja",
                  Image = "https://foto-finalproject.vercel.app/Kesehatan2.png",
                  Author = "KEMENKES RI",
                  Category = "Kesehatan" ,
                  Publication = 2018,
                  File = "https://foto-finalproject.vercel.app/docs/Kesehatan/Kesehatan-dan-Keselamatan-Kerja-(PDFDrive).pdf",
                  Publisher = "KEMENKES RI",
                },
                new Books
                { Id = 3,
                  Title = "Kesehatan Mental",
                  Image = "https://foto-finalproject.vercel.app/Kesehatan3.png",
                  Author = "Nur Mahardika, S.Pd, M.Pd",
                  Category = "Kesehatan" ,
                  Publication = 2017,
                  File = "https://foto-finalproject.vercel.app/docs/Kesehatan/kesehatan-mental.pdf",
                  Publisher = "BADAN PENERBIT UNIVERSITAS MURIAKUDUS",
                },
                new Books
                { Id = 4,
                  Title = "Buku Pedoman Lapangan Antar-lembaga \r\nKesehatan Reproduksi\r\ndalam Situasi Darurat Bencana",
                  Image = "https://foto-finalproject.vercel.app/Kesehatan4.png",
                  Author = "Inter-agency Working Group",
                  Category = "Kesehatan" ,
                  Publication = 2010,
                  File = "https://foto-finalproject.vercel.app/docs/Kesehatan/Kesehatan-Reproduksi-(PDFDrive).pdf",
                  Publisher = "Inter-agency Working Group on Reproductive Health in Crises",
                },
                new Books
                { Id = 5,
                  Title = "Light On Life : The Yoga Journey to Wholeness, Inner Peace, and Ultimate Freedom",
                  Image = "https://foto-finalproject.vercel.app/Kesehatan5.png",
                  Author = "Amy Waldman",
                  Category = "Kesehatan" ,
                  Publication = 2009,
                  File = "https://foto-finalproject.vercel.app/docs/Kesehatan/Light-on-Life-The-Yoga-Journey-to-Wholeness-Inner-Peace-and-Ultimate-Freedom-(PDFDrive).pdf",
                  Publisher = "The New York Time",
                },
            };

        [HttpGet]
        public async Task<ActionResult<List<Books>>> Get()
        {
            return Ok(books);
        }

        [HttpGet("{category}")]
        public async Task<ActionResult<List<Books>>> Get(string category)
        {
            var filteredBooks = books.Where(b => b.Category == category);
            if (filteredBooks == null) return NotFound("Product Not Found");
            return Ok(filteredBooks);
        }
    }
}
