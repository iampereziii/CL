using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VidzyCodeFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {


            //VidzyContext ctx = new VidzyContext();
            // Sorted by name , filter by action movie
            //IQueryable<Video> query = ctx.Videos.Where(x => x.GenreId.Equals(2)).OrderBy(x => x.Name);

            //Sort by release date filter vy drama and gold
            //IQueryable<Video> query = ctx.Videos.Where(x => x.GenreId.Equals(7) && ((byte)x.Classification).Equals((byte)Classification.Gold)).OrderByDescending(x => x.ReleaseDate);

            //Projection
            //IQueryable<Object> query = ctx.Videos.Select(x => new { MovieName = x.Name, MovieGenre = x.Genre.Name });

            //Grouping order by video name
            //var query = ctx.Videos.GroupBy(x => x.Classification).Select(group => new
            //{
            //    Classification = group.Key,
            //    Video = group.OrderBy(x => x.Name)
            //});

            //Grouping order by clasiification and count videos
            //var query = ctx.Videos.GroupBy(x => x.Classification).Select(group => new
            //{
            //    Classification = group.Key,
            //    VideoCount = group.Count()
            //}).OrderBy(x => x.Classification.ToString());
            //Console.WriteLine(String.Format("{0}({1})", group.Classification,group.VideoCount));


            //List genre and number of videos they include sorted by the number
            //var query = ctx.Genres.GroupJoin(ctx.Videos,
            //    genre => genre.Id,
            //    video => video.GenreId,
            //    (genre, movies) => new
            //    {
            //        GenreName = genre.Name,
            //        Movies = movies.Count()
            //    }
            //    ).OrderByDescending(x=>x.Movies);


            //VidzyContext ctx = new VidzyContext();
            ////Lazy loading

            ////var lazyLoad = ctx.Videos.ToList();

            ////Eager loading
            //var eagerLoad = ctx.Videos.Include(x => x.Genre);

            ////Explicit loading
            //var videoList = ctx.Videos.ToList();
            //var genreIds = videoList.Select(x => x.GenreId);
            //ctx.Genres.Load();


            //foreach (var item in videoList)
            //{
            //    Console.WriteLine(String.Format("{0} , {1}", item.Name, item.Genre.Name));
            //}

        }
        //public static void AddVideo(Video video)
        //{
        //    using (var context = new VidzyContext())
        //    {
        //        context.Videos.Add(video);
        //        context.SaveChanges();
        //    }
        //}

        //public static void AddTags(params string[] tagNames)
        //{
        //    using (var context = new VidzyContext())
        //    {
        //        // We load the tags with the given names first, to prevent adding duplicates.
        //        var tags = context.Tags.Where(t => tagNames.Contains(t.Name)).ToList();

        //        foreach (var name in tagNames)
        //        {
        //            if (!tags.Any(t => t.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase)))
        //                context.Tags.Add(new Tag { Name = name });
        //        }

        //        context.SaveChanges();
        //    }
        //}

        //// In terms of API design, this method expects tag names in the form of a string array.
        //// We shouldn't use TagId because that would only work if the given tag exists in the database.
        //// But often, in an application with a good user experience, the user should be able to pick a
        //// tag from a drop-down list, or add one at the same time as adding or editing a video. So, 
        //// we should use tag names to add a new tag to the database. Plus, tag names should be unique, 
        //// so conceptually, they can be treated as primary keys, but we use an int (TagId) for optimization.
        //public static void AddTagsToVideo(int videoId, params string[] tagNames)
        //{
        //    using (var context = new VidzyContext())
        //    {
        //        // This technique with LINQ leads to 
        //        // 
        //        // SELECT FROM Tags WHERE Name IN ('classics', 'drama')
        //        var tags = context.Tags.Where(t => tagNames.Contains(t.Name)).ToList();

        //        // So, first we load tags with the given names from the database 
        //        // to ensure we won't duplicate them. Now, we loop through the list of
        //        // tag names, and if we don't have such a tag in the database, we add
        //        // them to the list.
        //        foreach (var tagName in tagNames)
        //        {
        //            if (!tags.Any(t => t.Name.Equals(tagName, StringComparison.CurrentCultureIgnoreCase)))
        //                tags.Add(new Tag { Name = tagName });
        //        }

        //        var video = context.Videos.Single(v => v.Id == videoId);

        //        tags.ForEach(t => video.AddTag(t));

        //        context.SaveChanges();
        //    }
        //}

        //public static void RemoveTagsFromVideo(int videoId, params string[] tagNames)
        //{
        //    using (var context = new VidzyContext())
        //    {
        //        // We can use explicit loading to only load tags that we're going to delete.
        //        context.Tags.Where(t => tagNames.Contains(t.Name)).Load();

        //        var video = context.Videos.Single(v => v.Id == videoId);

        //        foreach (var tagName in tagNames)
        //        {
        //            // I've encapsulated the concept of removing a tag inside the Video class. 
        //            // This is the object-oriented way to implement this. The Video class
        //            // should be responsible for adding/removing objects to its Tags collection. 
        //            video.RemoveTag(tagName);
        //        }

        //        context.SaveChanges();
        //    }
        //}

        //public static void RemoveVideo(int videoId)
        //{
        //    using (var context = new VidzyContext())
        //    {
        //        var video = context.Videos.SingleOrDefault(v => v.Id == videoId);
        //        if (video == null) return;

        //        context.Videos.Remove(video);
        //        context.SaveChanges();
        //    }
        //}

        //public static void RemoveGenre(int genreId, bool enforceDeletingVideos)
        //{
        //    using (var context = new VidzyContext())
        //    {
        //        var genre = context.Genres.Include(g => g.Videos).SingleOrDefault(g => g.Id == genreId);
        //        if (genre == null) return;

        //        if (enforceDeletingVideos)
        //            context.Videos.RemoveRange(genre.Videos);

        //        context.Genres.Remove(genre);
        //        context.SaveChanges();
        //    }
        //}
    }
}
