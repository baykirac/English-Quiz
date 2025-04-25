using TranslatedValueApi.Infrastructure.BaseItems;

namespace TranslatedValueApi.Domain.Entites
{
    public class Translations : BaseEntity
    {
        public string TranslatedValue { get; set; }
        public int WordId { get; set; }

        private Translations(string translatedValue, int wordId)
        {
            TranslatedValue = translatedValue;
            WordId = wordId;
        }

        public static Translations Create(string _translatedValue, int _wordId)
        {
            Validate(_translatedValue);
            return new Translations(_translatedValue, _wordId);
        }

        public void Update(string _translatedValue)
        {
            Validate(_translatedValue);
            TranslatedValue = _translatedValue;
        }

        private static void Validate(string value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            if (string.IsNullOrWhiteSpace(value) || value.Length > 100)
                throw new Exception("Kelime karakter içermeli ve uzunluğu 100 karakterden fazla olmamalıdır.");
        }
    }
}
