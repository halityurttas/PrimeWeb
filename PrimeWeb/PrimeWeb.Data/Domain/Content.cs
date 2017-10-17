using PrimeWeb.Core.Data;
using PrimeWeb.Data.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeWeb.Data.Domain
{
    public class Content : IIdentityEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public short Status { get; set; }
        public int AuthorId { get; set; }
        public string SeoUrl { get; set; }
        public string PageTitle { get; set; }
        public string PageKeywords { get; set; }
        public string PageDescription { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public User Author { get; set; }
    }
}
