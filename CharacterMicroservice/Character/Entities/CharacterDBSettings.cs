using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharacterAPI.Entities
{
    //public interface ICharacterDBSettings
    //{
    //    public string ConnectionString { get; set; }
    //    public string DatabaseName { get; set; }
    //    public string CollectionName { get; set; }
    //}
    public class CharacterDBSettings //: ICharacterDBSettings
    {
        public string ConnectionString { get; set; } = null;
        public string DatabaseName { get; set; } = null;
        public string CollectionName { get; set; } = null;

    }
}
