using WordApi.Infrastructure.BaseItems;

namespace WordApi.Domain.Entities
{
    public class Words : BaseEntity
    {
        public string Word { get; private set; }

        private Words(string word)
        {
            Word = word;
        }

        public static Words Create(string word)
        {
            Validate(word);
            return new Words(word);
        }

        public void Update(string newWord)
        {
            Validate(newWord);
            Word = newWord;
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
