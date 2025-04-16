using OccupationalTherapist_Core.Entities;
using OccupationalTherapist_DataAccess.EFCore.Abstracts;
using OccupationalTherapist_DataAccess.Interface.Repositories;
using OccupationalTherapist_DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OccupationalTherapist_DataAccess.EFCore.Repositories
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(AppDbContext context) : base(context)
        {
        }
    }
}
