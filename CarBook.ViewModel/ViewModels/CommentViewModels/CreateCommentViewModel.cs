using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.ViewModel.ViewModels.CommentViewModels
{
    public class CreateCommentViewModel
    {
        public string Name { get; set; }
        public string UserImageurl { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        public int BlogId { get; set; }
        public string Email { get; set; }
    }
}
