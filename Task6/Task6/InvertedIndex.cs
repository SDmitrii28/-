// Класс для представления инвертированных индексов
using System.Collections.Generic;

class InvertedIndex
{
    public Dictionary<string, List<string>> index = new Dictionary<string, List<string>>();

    // Метод для добавления термина и документа в индекс
    public void AddTerm(string term, string document)
    {
        if (!index.ContainsKey(term))
        {
            index[term] = new List<string>();
        }
        index[term].Add(document);
    }

    // Метод для выполнения запроса по алгоритму «грубой силы»
    public List<string> SimpleSearch(string term)
    {
        if (index.ContainsKey(term))
        {
            return index[term];
        }
        return new List<string>();
    }
}
