using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using ChinookSystem.DAL;
using ChinookSystem.Entities;  //for sql and are internal
using ChinookSystem.ViewModels; //for data class to transfer data from BLL to webapp
using System.ComponentModel;
#endregion
namespace ChinookSystem.BLL
{
    [DataObject]
    public class AlbumController
    {
        #region QUERY
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<ArtistAlbums> Albums_GetArtistAlbums()
        {
            using (var context = new ChinookSystemContext())
            {
                IEnumerable<ArtistAlbums> results = from x in context.Albums select new ArtistAlbums
                {
                    Title = x.Title,
                    ReleaseYear = x.ReleaseYear,
                    ArtistName = x.Artist.Name

                };
                return results.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<ArtistAlbums> Albums_GetAlbumsForArtist(int artistid)
        {
            using (var context = new ChinookSystemContext())
            {
                IEnumerable<ArtistAlbums> results = from x in context.Albums
                                                    where x.ArtistId == artistid
                                                    select new ArtistAlbums
                                                    {
                                                        Title = x.Title,
                                                        ReleaseYear = x.ReleaseYear,
                                                        ArtistName = x.Artist.Name,
                                                        ArtistId = x.ArtistId                                                       
                                                    };
                return results.ToList();
            }
        }

        //query all album
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<AlbumItem> Albums_List()
        {
            using (var context = new ChinookSystemContext())
            {
                IEnumerable<AlbumItem> results = from x in context.Albums
                                                 select new AlbumItem
                                                 {
                                                     AlbumId = x.AlbumId,
                                                        Title = x.Title,
                                                        ReleaseYear = x.ReleaseYear,
                                                        ArtistId = x.ArtistId,
                                                        ReleaseLabel = x.ReleaseLabel
                                                    };
                return results.ToList();
            }
        }

        //query album by artist
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AlbumItem Albums_FindById(int albumid)
        {
            using (var context = new ChinookSystemContext())
            {
                var results = (from x in context.Albums
                                    where x.AlbumId == albumid
                                                    select new AlbumItem
                                                    {
                                                        AlbumId = x.AlbumId,
                                                        Title = x.Title,
                                                        ReleaseYear = x.ReleaseYear,
                                                        ArtistId = x.ArtistId,
                                                        ReleaseLabel = x.ReleaseLabel
                                                    }).FirstOrDefault();
                return results;
            }
        }

        #endregion

        #region CRUD

        //add
        [DataObjectMethod(DataObjectMethodType.Insert, false)]
        public int Album_Add(AlbumItem item)
        {
            using (var context = new ChinookSystemContext())
            {
                Album addItem = new Album()
                {
                    Title = item.Title,
                    ReleaseYear = item.ReleaseYear,
                    ArtistId = item.ArtistId,
                    ReleaseLabel = item.ReleaseLabel
                };
                context.Albums.Add(addItem);
                context.SaveChanges();
                return addItem.AlbumId;
            }
        }

        //update
        [DataObjectMethod(DataObjectMethodType.Update, false)]
        public void Album_Update(AlbumItem item)
        {
            using (var context = new ChinookSystemContext())
            {
                Album updateItem = new Album()
                {
                    AlbumId = item.AlbumId,
                    Title = item.Title,
                    ReleaseYear = item.ReleaseYear,
                    ArtistId = item.ArtistId,
                    ReleaseLabel = item.ReleaseLabel
                };
                context.Entry(updateItem).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        //delete
       
        public void Album_Delete(int albumid)
        {
            using (var context = new ChinookSystemContext())
            {
                var exists = context.Albums.Find(albumid);
                context.Albums.Remove(exists);
                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public void Album_Delete(AlbumItem item)
        {
            Album_Delete(item.AlbumId);            
        }

        #endregion
    }
}
