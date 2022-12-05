using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cegefos.Api.Classes
{
    public class QueryParameters
    {
        public const int MaxSize = 5;

        public int Page { get; set; }

        public int Size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = Math.Min(MaxSize, value);
            }
        }
        private int _size = 2;

        public string Libelle { get; set; }

        public string Code { get; set; }

        public string SortBy
        {
            get { return _sortBy; }
            set
            {
                if (value == "asc" || value == "desc")
                {
                    _sortBy = value;
                }
            }
        }
        private string _sortBy = "asc";
    }
}
