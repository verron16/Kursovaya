using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeyWordsDTL = Kursovaya.DTL.ArticleKeyWords.KeyWords;

namespace Kursovaya.DAL.ArticleKeyWords
{
    public interface IKeyWordDataManager
    {
        List<KeyWordsDTL> GetExistingKeyWords(List<string> keyWords);
    }
}
