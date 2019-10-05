namespace PlayersAndMonsters.Common
{
    public static class ExceptionMessages
    {
        public const string InvalidUsenameNullOrEmpty = 
            "Player's username cannot be null or an empty string. ";

        public const string InvalidHealthLessThanZero = 
            "Player's health bonus cannot be less than zero. ";

        public const string InvalidDamagePointsBelowZero = 
            "Damage points cannot be less than zero.";

        public const string InvalidCardNameNullOrEmpty =
            "Card's damage points cannot be less than zero.";

        public const string InvalidCardDamagePointsBelowZero =
            "Card's damage points cannot be less than zero.";

        public const string InvalidCardHealthLessThanZero =
            "Card's HP cannot be less than zero.";

        public const string DeadPlayer =
            "Player is dead!";

        public const string CardCannotBeNull = 
            "Card cannot be null!";

        public const string CardsAlreadyExist =
            "Card {0} already exists!";

        public const string PlayerCannotBeNull =
            "Player cannot be null";

        public const string PlayerAlreadyExist =
            "Player {0} already exists!";
    }
}