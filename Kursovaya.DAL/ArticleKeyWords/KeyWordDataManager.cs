using Kursovaya.DTL.ArticleKeyWords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya.DAL.ArticleKeyWords
{
    public class KeyWordDataManager : IKeyWordDataManager
    {
        public List<KeyWords> GetExistingKeyWords(List<string> keyWords)
        {
            IQueryable<KeyWords> result = Enumerable.Empty<KeyWords>().AsQueryable();
            using (DAL.DataBase.Context db = new DAL.DataBase.Context())
            {
                if (keyWords.Count > 0)
                {
                    result = db.KeyWords.AsNoTracking().Where(i => keyWords.Any(s => i.KeyWord.Equals(s)));
                }
            }
            return result.ToList();
        }
    }
}
