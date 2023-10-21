using CsvHelper.Configuration;
using EuroMillionsAPI.Entities;

namespace EuroMillionsAPI.Helpers.Mappers
{
    public class EuromillionsFdjCsvDrawMap : ClassMap<Draw>
    {
        public EuromillionsFdjCsvDrawMap()
        {
            Map(draw => draw.ID).Name("annee_numero_de_tirage");
            Map(draw => draw.Day).Name("jour_de_tirage");
            //TODO:essayer de passer par un type convertor
            Map(draw => draw.DrawDate).TypeConverterOption.Format("yyyymmdd", "dd/mm/yy", "dd/mm/yyyy").Name("date_de_tirage");

            Map(draw => draw.Number1).Name("boule_1");
            Map(draw => draw.Number2).Name("boule_2");
            Map(draw => draw.Number3).Name("boule_3");
            Map(draw => draw.Number4).Name("boule_4");
            Map(draw => draw.Number5).Name("boule_5");

            Map(draw => draw.Star1).Name("etoile_1");
            Map(draw => draw.Star2).Name("etoile_2");
        }
    }
}
