using Kursovaya.DAL.ArticleKeyWords;
using Kursovaya.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeyWordsDTL = Kursovaya.DTL.ArticleKeyWords.KeyWords;
namespace Kursovaya.BLL.ArticleKeyWords
{
    public static class KeyWords
    {
        public static List<KeyWordsDTL> GetExistingKeyWords(List<string> keyWords)
        {
            var dm = DataManager.GetDataManager<IKeyWordDataManager>();
            return dm.GetExistingKeyWords(keyWords);
        }
    }
}
