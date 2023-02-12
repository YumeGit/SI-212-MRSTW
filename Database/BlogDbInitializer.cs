using MRSTW.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace MRSTW.Database
{
	public class BlogDbInitializer: DropCreateDatabaseAlways<BlogDbContext>
	{
		protected override void Seed(BlogDbContext context)
		{
			var u = new User()
			{
				Name = "Moonly Days",
				Password = "test",
				Email = "test@gmail.com"
			};
            context.Users.Add(u);

			context.Posts.Add(new Post()
			{
				Name = "Welcome to my blog",
				Author = u,
				ShortStory = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam pellentesque, purus a porta semper, ligula nulla tempus erat, a dictum nunc erat ut lacus. Vivamus pellentesque vitae nisi vel tristique. Donec egestas ultricies mauris, ut eleifend orci porta id. Cras facilisis sed neque quis dictum. Nullam a enim tincidunt, tempor est et, condimentum nisi. Nulla dignissim convallis magna nec dapibus. Vivamus ultricies accumsan ante.\r\n\r\n",
				FullStory = "Morbi laoreet ex non libero molestie, sit amet vulputate quam lacinia. Vestibulum vehicula venenatis sem non maximus. Integer erat odio, varius eget arcu id, dignissim laoreet tortor. Mauris vestibulum erat id metus pretium consequat. Nullam feugiat ac ex ac pretium. Suspendisse nec sem non orci egestas dignissim ac et mauris. Quisque volutpat faucibus lectus ac dapibus. Nunc vehicula eu magna ut tempor. Donec in magna libero. Sed interdum enim sem, nec condimentum ligula bibendum sed. Nulla facilisi. Maecenas at risus diam. Nullam massa metus, ultricies non cursus ac, pulvinar vitae elit.\r\n\r\nNam efficitur volutpat diam, eget elementum risus tempor vel. Ut a imperdiet nibh. Duis sem ante, egestas a pulvinar in, mollis a diam. Vivamus scelerisque massa turpis, nec consectetur arcu imperdiet ac. Sed sed gravida metus. Mauris viverra, lectus id luctus dapibus, nunc neque facilisis urna, ut tempus lacus magna vitae leo. Praesent varius scelerisque enim eu finibus. Etiam ut diam fringilla, euismod orci ut, lobortis est. Cras non tortor pretium, posuere nisl congue, vestibulum tortor. Fusce feugiat dui dui, ac lobortis dolor efficitur in. Praesent at tempor est, vel tristique nulla. Morbi vitae dolor consectetur, iaculis metus quis, scelerisque mi.",
				Created = DateTime.Now,
				Comments = new List<Comment>() {
					new Comment()
					{
						Author = u,
						Message = "Such an amazing post!",
					},
					new Comment()
					{
						Author = u,
						Message = "Cringe",
					},
					new Comment()
					{
						Author = u,
						Message = "Hello",
					}
				}
			});

            context.Posts.Add(new Post()
            {
                Name = "Second post",
                Author = u,
                ShortStory = "Lorem ipsum...",
                FullStory = "Lorem ipsum dolor set amen...",
                Created = DateTime.Now.AddDays(-1)
            });

            base.Seed(context);
		}
	}
}