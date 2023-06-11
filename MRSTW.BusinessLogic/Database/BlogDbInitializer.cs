﻿using MRSTW.Domain.Entities;
using MRSTW.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace MRSTW.BusinessLogic.Database
{
    public class BlogDbInitializer : DropCreateDatabaseIfModelChanges<BlogDbContext>
	{
		protected override void Seed(BlogDbContext context)
		{
            var dan = context.Users.Add(new User()
            {
                Name = "Daniel Basiuc-Brinzei",
                PasswordHash = AuthHelper.GeneratePasswordHash("123"),
                Email = "daniil.basiuc-brinzei@isa.utm.md",
                Avatar = "https://pbs.twimg.com/profile_images/1615039593828450326/mDTwNfzL_400x400.jpg",
                Role = UserRole.Admin
            });

            context.Users.Add(new User()
            {
                Name = "Maxim Resetnicov",
                PasswordHash = AuthHelper.GeneratePasswordHash("123"),
                Email = "maxim.resetnicov@isa.utm.md",
                Avatar = "https://cdn.discordapp.com/attachments/936193756007366707/1094700225672773652/image.png"
            });

			context.Users.Add(new User() 
            { 
                Name = "Dmitrii Strusovschii", 
                PasswordHash = AuthHelper.GeneratePasswordHash("123"), 
                Email = "dmitrii.strusovschii@isa.utm.md", 
                Avatar = "https://cdn.discordapp.com/attachments/936193756007366707/1094700812934070312/image.png" 
            });

            context.Users.Add(new User()
            {
                Name = "Ecaterina Xenzenko",
                PasswordHash = AuthHelper.GeneratePasswordHash("123"),
                Email = "ecaterina.xenzenko@isa.utm.md",
                Avatar = "https://cdn.discordapp.com/attachments/1021106566289707122/1094700826695573575/novyj-trejler-genshin-impact-posvyatili-5-zvyozdochnoj-geroine-yae-miko_164450266941021586.png",
                Role = UserRole.Admin
            });

            context.Users.Add(new User()
            {
                Name = "Oleg Somov",
                PasswordHash = AuthHelper.GeneratePasswordHash("123"),
                Email = "oleg.somov@isa.utm.md",
                Avatar = "https://i.pinimg.com/280x280_RS/51/e4/cf/51e4cf308d19ddc5f5d143313115e78c.jpg"
            });

            context.Users.Add(new User()
            {
                Name = "Umklaidet",
                PasswordHash = AuthHelper.GeneratePasswordHash("123"),
                Email = "umklaidet@ampersoftware.com",
                Avatar = "https://cdna.artstation.com/p/users/avatars/002/047/238/large/b49f8832128df65856fd73d936c753bd.jpg"
            });

            //---------------------------------------------------//

            context.Posts.Add(new Post()
            {
                Name = "Влияние аниме \"Наруто\" на поколение нулевых (2000-х)",
                Author = dan,
                Story = "Аниме \"Наруто\" является одним из самых популярных аниме 2000-х годов и оказало огромное влияние на поколение того времени. Оно стало чрезвычайно популярным в Японии и за ее пределами, привлекая миллионы зрителей по всему миру. \"Наруто\" оказало огромное влияние на аниме-культуру и стало ярким примером того, как аниме может обладать глубокой смысловой нагрузкой и быть не только просто развлечением.\r\n\r\nПервое, что делает аниме \"Наруто\" таким уникальным и особенным, это то, что оно не только является ярким и интересным приключением, но и представляет глубокие философские и моральные вопросы. Оно рассказывает историю о молодом ниндзя по имени Наруто Узумаки, который пытается стать лучшим ниндзя в своей деревне и защитить ее от врагов. Но, помимо этого, аниме затрагивает многие другие темы, такие как дружба, любовь, предательство, самопожертвование, многократные попытки и терпение, и многое другое. Эти темы стали очень актуальными для многих зрителей, особенно для тех, кто был в том же возрасте, что и Наруто.\r\n\r\nКроме того, \"Наруто\" стал первым аниме, которое показало нам, что быть \"главным героем\" не всегда означает быть совершенным. Наруто имел свои недостатки, он не всегда был лучшим в своем классе, и даже когда ему удавалось победить своих врагов, он всегда делал это с помощью своих друзей и команды. Это стало важным уроком для многих зрителей, которые начали понимать, что успех не зависит только от индивидуальных способностей, но и от способности работать в команде и поддерживать друг друга.\r\n\r\n\r\nМузыкальная тема тоже является важным фактором влияния. Она стала одной из самых известных в мире аниме и на сегодняшний день она всегда ассоциируется с сериалом. Музыкальные композиции в сериале были очень важными, они передавали настроение и эмоции персонажей, что делало сериал еще более живым и захватывающим.\r\n\r\nНаконец, \"Наруто\" внес значительный вклад в развитие японской культуры в мире. Он помог многим людям узнать больше о Японии, ее культуре и традициях. Аниме стало так популярным, что оно вызвало новый виток интереса к японской культуре в целом, в том числе к музыке, косплею и языку.\r\n\r\nВ целом, аниме \"Наруто\" оказало большое влияние на поколение 2000-х годов. Оно стало одним из самых значимых аниме-сериалов в истории, и до сих пор на него ссылаются и обращаются миллионы людей по всему миру. \"Наруто\" стал настоящим культурным феноменом, который сформировал множество традиций и культурных элементов, которые до сих пор используются и развиваются.\r\n\r\n\r\nБлагодаря этому сериалу, многие подростки смогли почерпнуть мотивацию, силу воли и уверенность в своих силах, чтобы преодолевать трудности и идти к своим целям. В итоге, можно с уверенностью сказать, что \"Наруто\" оставил неизгладимый след в истории аниме и продолжает оказывать влияние на подрастающие поколения в настоящее время.",
                Created = DateTime.Now.AddDays(-9),
                Thumbnail = "https://cdn.discordapp.com/attachments/882643299473694801/1094941594358124604/wp8112346.png",
                CatergoryName = "Anime",
                Comments = new List<Comment>()
                {
                    new Comment()
                    {
                        Message = "Deez",
                        Author = dan,
                        Comments = new List<Comment>()
                        {
                            new Comment() 
                            {
                                Message = "Nuts",
                                Author = dan,
                            }
                        }

                    }
                }
            });

            context.Posts.Add(new Post()
            {
                Name = "Обзор на Капибару",
                Author = dan,
                Story = "Капибара - это крупнейший грызун в мире, который обитает в Центральной и Южной Америке. Животное имеет толстый короткий мех и может достигать веса до 66 кг и длины до 1,3 метра. Капибара живет в близкой связи с водой и является отличным пловцом. Они обитают в речных долинах, болотах и лесистых районах.\r\n\r\nПитание капибары состоит из травы, веток, корней и плодов, которые они находят на берегах рек и озер. Животное является социальным и живет в группах до 20 особей. Капибары являются жертвами для ряда хищников, включая ягуаров и кайманов, однако из-за их размера они могут легко убежать в воду.\r\n\r\nСуществует множество научных исследований, посвященных капибарам. Одно из них изучало их социальное поведение и установило, что капибары проявляют большую солидарность и взаимодействуют между собой, чтобы защитить свою территорию от других животных. Они также проявляют заботу о молодых особях и помогают им выживать в течение первых недель жизни.\r\n\r\nКапибары являются важными для экосистемы, так как являются растительноядными животными и распространяют семена различных растений, что влияет на разнообразие растительности в регионах, где они обитают.\r\n\r\nКапибара является объектом исследований не только биологов и зоологов, но и антропологов. Например, в одном исследовании изучалась роль капибар в культуре племен в Амазонии. Исследователи обнаружили, что капибары играют важную роль в религиозных обрядах и мифологии этих народов.\r\n\r\nТаким образом, капибара является уникальным животным, которое продолжает привлекать внимание исследователей различных областей на весь мир. \r\n\r\nИх социальное поведение, способность к плаванию и растительноядный режим питания делают их интересными объектами для научных исследований. Кроме того, капибары играют важную роль в экосистемах, распространяя семена различных растений.\r\n\r\nНесмотря на то, что капибары не являются на первый взгляд угрозой для людей, их мясо и кожа до сих пор используются местными жителями для пищи и других целей. Из-за массовой охоты на капибар и уничтожения их естественных местообитаний, они находятся под угрозой вымирания.\r\n\r\nТаким образом, сохранение и изучение капибары имеет не только научную, но и прикладную значимость для сохранения биоразнообразия нашей планеты.",
                Created = DateTime.Now,
                CatergoryName = "Nature",
                Thumbnail = "https://cdn.discordapp.com/attachments/882643299473694801/1094941483485900810/the-capybara-club-will-bullas.png",
                Reactions = new List<Reaction>()
                {
                    new Reaction()
                    {
                        Author = dan,
                        Emoji = "🎈"
                    }
                }
            });

            context.Posts.Add(new Post()
            {
                Name = "Чему стоит поучиться у персонажей \"Team Fortress\"",
                Author = dan,
                Story = "Team Fortress – это игра, которая вышла в 2007 году и стала одной из наиболее популярных многопользовательских игр в мире. Она известна своими яркими и запоминающимися персонажами, которые могут научить нас многим важным урокам.\r\n\r\nПервый урок, который мы можем извлечь из персонажей Team Fortress, это умение работать в команде. Каждый из персонажей имеет свои сильные и слабые стороны, но они все нужны для достижения цели. Играчи учатся сотрудничать, координировать свои действия и доверять своим товарищам по команде. Этот урок может помочь не только в игре, но и в жизни, ведь в большинстве случаев, успехи зависят от того, как хорошо вы умеете работать с другими людьми.\r\n\r\nВторой урок, который мы можем извлечь из персонажей Team Fortress, это умение иметь чувство юмора. Персонажи игры, несмотря на то, что они серьезно относятся к своей работе, всегда остаются забавными и развлекательными. Играчи учатся не брать все слишком серьезно, а иногда просто наслаждаться моментом и радоваться жизни.\r\n\r\nТретий урок, который мы можем извлечь из персонажей Team Fortress, это умение быть адаптивным. В игре может происходить все что угодно, и игрокам нужно уметь быстро адаптироваться к изменяющимся обстоятельствам. Персонажи Team Fortress показывают, что необходимо быть готовым к любым изменениям и находить решения в самых неожиданных ситуациях.\r\n\r\nИ, наконец, четвертый урок, который мы можем извлечь из персонажей Team Fortress, это умение принимать поражение. Несмотря на то, что каждый игрок в команде старается выиграть, поражение иногда бывает неизбежно. Вместо того, чтобы злиться и винить других, персонажи игры просто принимают поражение и готовятся к следующей игре. Этот урок может помочь в жизни, ведь поражения бывают в любой сфере, и важно уметь приним",
                Created = DateTime.Now.AddDays(-8),
                Thumbnail = "https://pbs.twimg.com/profile_images/1456723881117560841/s4_uQ5RC_400x400.jpg",
            });

            context.Posts.Add(new Post()
            {
                Name = "Как быть хорошим программистом",
                Author = dan,
                Story = "В современном мире программисты играют ключевую роль в развитии технологий и создании программного обеспечения, которое помогает упрощать и улучшать жизнь людей. Однако, чтобы стать хорошим программистом, необходимо иметь определенные качества и навыки. В этой статье я расскажу, что нужно делать, чтобы стать успешным программистом.\r\n\r\nПервое, что нужно понимать, это то, что программирование – это не просто набор инструкций, а творческий процесс, который требует от программиста логического мышления и умения решать сложные задачи. Хороший программист должен уметь смотреть на проблемы с разных сторон и находить эффективные решения.\r\n\r\nВторое, что необходимо для успешной карьеры в программировании, это постоянное обучение и изучение новых технологий. Мир информационных технологий меняется с огромной скоростью, и программисты должны постоянно следить за новыми трендами и развитием технологий. Хороший программист должен обладать жаждой знаний и стремиться улучшать свои навыки.\r\n\r\nТретье, что необходимо для того, чтобы стать хорошим программистом, это умение работать в команде. Хотя программирование часто связано с работой в одиночку, большинство проектов требуют сотрудничества с другими людьми. Хороший программист должен уметь работать в команде, быть готовым к компромиссам и уметь выслушивать идеи других людей.\r\n\r\nЧетвертое, что необходимо для успешной карьеры в программировании, это хорошие коммуникативные навыки. Хороший программист должен уметь объяснять сложные технические вопросы простым языком, чтобы люди без технического образования могли понять, что происходит. Это поможет программисту успешно сотрудничать с другими членами команды и создавать продукты, которые будут полезны для людей.\r\n\r\nИ, наконец, пятое, что необходимо для того, чтобы стать хорошим программистом, это умение принимать критику. Хороший программист должен понимать, что его работа может быть несовершенной, и он должен быть готов принимать критику и использовать ее для улучшения своих навыков. Критика может приходить как от коллег, так и от пользователей, которые используют созданные программы. Хороший программист должен уметь анализировать критику, отвечать на нее конструктивно и использовать ее для улучшения своей работы.\r\n\r\nВ заключение, стать хорошим программистом не так просто, но это возможно, если у вас есть желание и настойчивость. Для того, чтобы стать успешным программистом, нужно иметь логическое мышление, постоянно обучаться и изучать новые технологии, уметь работать в команде и обладать хорошими коммуникативными навыками, а также уметь принимать критику. Если вы готовы развивать эти качества, то вы сможете стать успешным программистом и внести свой вклад в развитие информационных технологий.",
                Created = DateTime.Now.AddDays(-2),
                CatergoryName = "IT",
                Thumbnail = "https://cdn.discordapp.com/attachments/882643299473694801/1094941721462325318/Christine_Bailey_programming_wallpaper_hd.png",
            });

            context.Posts.Add(new Post()
            {
                Name = "Летопись противостояния Древних Русов и Ящеров",
                Author = dan,
                Story = "Некогда, в давние времена, жили на земле Древние Русы, благородный народ, который любил свою землю и заботился о ее благополучии. Но однажды на землю Русскую сошли Ящеры - чудовищные существа с кожей, словно камень, и зубами, как острые ножи.\r\n\r\nЯщеры, жаждущие власти и богатства, начали захватывать земли Русские, грабить и убивать безжалостно. Древние Русы оказались в безвыходном положении - ни вооружения, ни армии у них не было, и они не могли сопротивляться Ящерам.\r\n\r\nНо Русы не сдались без боя. Они собрались вместе и начали искать способы борьбы с Ящерами. И вот, благодаря уму и мужеству вождей Русских, была разработана стратегия, как одолеть врага.\r\n\r\nРусы начали строить крепости и укреплять свои города, чтобы защититься от нападений Ящеров. Они также начали изучать Ящеров, изучать их сильные и слабые стороны, чтобы понимать, как с ними бороться.\r\n\r\nИ наконец, Русы нашли свой секретный оружие - они начали использовать лук и стрелы, которые были эффективны против Ящеров, потому что они были быстры и ловки.\r\n\r\nСражение между Русами и Ящерами продолжалось многие годы, но в конце концов Русы вышли победителями. Они доказали, что ум и мужество могут победить даже самого сильного врага.\r\n\r\nИ так, Древние Русы продолжали жить на своей земле, защищая ее от новых угроз и прославляя свою мужество и умение сражаться.",
                Created = DateTime.Now.AddDays(-2),
                Thumbnail = "https://cdn.discordapp.com/attachments/882643299473694801/1106622070395244554/image_2023-05-12_19-36-52.png",
            });
            context.Posts.Add(new Post()
            {
                Name = "Если бы автомобили были придуманы в 17 веке",
                Author = dan,
                Story = "Если бы автомобили были придуманы в 17 веке, то они, вероятно, оказали бы значительное влияние на искусство того времени. Однако, необходимо учитывать, что автомобили являются сравнительно новым изобретением, и не было бы никаких американских автомобилей в 17 веке, так как Соединенные Штаты Америки еще не существовали.\r\n\r\nНесмотря на это, можно представить, что в 17 веке автомобили, если бы они были придуманы, могли бы оказать влияние на искусство того времени. Например, роскошные колесницы, используемые в те времена для перевозки людей, могли бы быть заменены на более быстрые и эффективные автомобили. Это могло бы привести к созданию новых форм и стилей в искусстве, которые бы отражали эти новые технологии.\r\n\r\nКроме того, с развитием автомобилей могли бы возникнуть новые темы для изображений в живописи, скульптуре и других видах искусства. Например, изображения гонок на автомобилях, дорог и пейзажей, связанных с автомобильным движением, могли бы стать популярными среди художников.\r\n\r\nТаким образом, если бы автомобили были придуманы в 17 веке, они могли бы оказать значительное влияние на искусство того времени, хотя это было бы очень различным от современного влияния американских автомобилей на искусство.",
                Created = DateTime.Now.AddDays(-2),
                CatergoryName = "Meow",
                Thumbnail = "https://cdn.discordapp.com/attachments/644931521173782528/1106629953052758187/64.png",
            });

            base.Seed(context);
		}
	}
}