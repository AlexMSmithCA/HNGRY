using HNGRY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HNGRY.ViewModels.Ajax
{
    public class UpdateFeedEntryAjaxViewModel
    {
        public int Id { get; set; }
        public UpdateFeedEntryChangeType ChangeType { get; set; }
    }
}
