namespace NewsAPI.Entities.Enums
{
    public enum ErrorType
    {
        ApiKeyExhausted,
        ApiKeyMissing,
        ApiKeyInvalid,
        ApiKeyDisabled,
        ParametersMissing,
        ParametersIncompatible,
        ParameterInvalid,
        RateLimited,
        RequestTimeout,
        SourcesTooMany,
        SourceDoesNotExist,
        SourceUnavailableSortedBy,
        SourceTemporarilyUnavailable,
        UnexpectedError,
        UnknownError
    }
}
