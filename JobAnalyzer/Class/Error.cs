namespace JobAnalyzer
{
    class Err
    {
        public Err()
        {
            errors = new Errors[] { };
            bad_arguments = new BadArguments[] { };
        }

        public Errors[] errors { get; set; }
        public BadArguments[] bad_arguments { get; set; }

        public string description { get; set; }
        public string bad_argument { get; set; }
    }

    /// <summary>
    /// Типовой класс ошибок HH (остальные официально не поддерживаются)
    /// </summary>
    class Errors
    {
        public string type { get; set; }
        public string value { get; set; }
    }

    class BadArguments
    {
        public string name { get; set; }
        public string description { get; set; }
    }
}
